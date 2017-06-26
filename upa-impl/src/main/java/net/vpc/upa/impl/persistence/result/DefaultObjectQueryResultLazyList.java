package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.persistence.NativeField;
import net.vpc.upa.impl.persistence.QueryExecutor;
import net.vpc.upa.impl.persistence.QueryResultLazyList;
import net.vpc.upa.impl.util.CacheMap;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.persistence.QueryResult;
import net.vpc.upa.persistence.ResultField;
import net.vpc.upa.persistence.ResultMetaData;
import net.vpc.upa.types.ManyToOneType;

import java.sql.SQLException;
import java.util.*;

/**
 * Created by vpc on 6/18/16.
 */
public class DefaultObjectQueryResultLazyList<T> extends QueryResultLazyList<T> {
    protected boolean updatable;
    protected boolean loadManyToOneRelations;
    protected ResultMetaData metaData;
    protected CacheMap<NamedId, Object> referencesCache;
    protected Map<String, Object> hints;
    protected ObjectFactory ofactory;
    protected boolean defaultsToDocument;
    protected boolean relationAsDocument;
    TypeInfo[] typeInfos;
    //    protected int entityIndex = 0;
    LinkedHashMap<String, TypeInfo> bindingToTypeInfos;
    private QueryResultItemBuilder resultBuilder;
    private QueryResultRelationLoader loader;
    private LoaderContext loaderContext;
//    private Command[] parseCommands;

    public DefaultObjectQueryResultLazyList(
            PersistenceUnit pu,
            QueryExecutor queryExecutor,
            boolean loadManyToOneRelations,
            boolean defaultsToDocument,
            boolean relationAsDocument,
            boolean supportCache,
            boolean updatable,
            QueryResultRelationLoader loader,
            QueryResultItemBuilder resultBuilder
    ) throws SQLException {
        super(queryExecutor);
        this.resultBuilder = resultBuilder;
        this.loader = loader;
        this.defaultsToDocument = defaultsToDocument;
        this.relationAsDocument = relationAsDocument;
        this.loadManyToOneRelations = loadManyToOneRelations;
        metaData = queryExecutor.getMetaData();
        hints = queryExecutor.getHints();
        if (hints == null) {
            hints = new HashMap<String, Object>();
        } else {
            hints = new HashMap<String, Object>(hints);
        }
        if (supportCache) {
            CacheMap<NamedId, Object> sharedCache = (CacheMap<NamedId, Object>) hints.get("queryCache");
            if (sharedCache == null) {
                sharedCache = new CacheMap<NamedId, Object>(1000);
                hints.put("queryCache", sharedCache);
            }
            referencesCache = sharedCache;
        }
        loaderContext = new LoaderContext(referencesCache, hints);
        LinkedHashMap<String, TypeInfo> bindingToTypeInfos0 = new LinkedHashMap<String, TypeInfo>();
        ofactory = pu.getFactory();
        NativeField[] fields = queryExecutor.getFields();
        for (int i = 0; i < fields.length; i++) {
            NativeField nativeField = fields[i];
            FieldInfo f = new FieldInfo();
            f.dbIndex = i;
            f.nativeField = nativeField;
            f.name = nativeField.getName();
            String gn = nativeField.getGroupName();
            if (gn == null) {
                gn = nativeField.getExprString();
            }
            TypeInfo t = bindingToTypeInfos0.get(gn);
            if (t == null) {
                if (nativeField.getBindingField() != null) {
                    t = new TypeInfo(gn, nativeField.getBindingField().getEntity());
                    t.document = gn.contains(".") ? relationAsDocument : defaultsToDocument;
                    bindingToTypeInfos0.put(gn, t);
                } else if (nativeField.getField() != null) {
                    t = new TypeInfo(gn, nativeField.getField().getEntity());
                    t.document = gn.contains(".") ? relationAsDocument : defaultsToDocument;
                    bindingToTypeInfos0.put(gn, t);
                } else {
                    t = new TypeInfo(gn, null);
                    t.document = false;//n.contains(".") ? relationAsDocument : defaultsToDocument;
                    bindingToTypeInfos0.put(gn, t);
                }
//                if(!bindingToTypeInfos0.containsKey(nativeField.getExprString())) {
//                    bindingToTypeInfos0.put(nativeField.getExprString(), t);
//                }else{
//                    System.out.println("why");
//                }
            }
            f.field = nativeField.getField();
            if (loadManyToOneRelations) {
                if (f.field != null) {
                    if (f.field.getDataType() instanceof ManyToOneType) {
                        Entity r = ((ManyToOneType) f.field.getDataType()).getTargetEntity();
                        f.referencedEntity = r;
                    }
                    for (Relationship relationship : f.field.getManyToOneRelationships()) {
                        if (relationship.getSourceRole().getEntityField() != null) {
                            t.manyToOneRelations.add(relationship);
                        }
                    }
                }
            }
            f.typeInfo = t;
            t.allFields.add(f);
            if (t.leadPrimaryField == null && f.nativeField.getField() != null && f.nativeField.getField().isId()) {
                t.leadPrimaryField = f;
            }
            if (t.entity != null && t.leadField == null) {
                t.leadField = f;
            }
            f.setterMethodName = PlatformUtils.setterName(nativeField.getName());
            t.fields.put(f.setterMethodName, f);
        }
        bindingToTypeInfos = bindingToTypeInfos0;
        typeInfos = bindingToTypeInfos0.values().toArray(new TypeInfo[bindingToTypeInfos0.size()]);

        // all indexes to fill with values from the query
        Set<Integer> allIndexes = new HashSet<Integer>();
        for (int i = 0; i < metaData.getResultFields().size(); i++) {
            allIndexes.add(i);
        }
        // map expression to relative TypeInfo/FieldInfo
        Map<String, Object> visitedIndexes = new HashMap<String, Object>();
        for (int i = 0; i < typeInfos.length; i++) {
            TypeInfo typeInfo = typeInfos[i];
//            if (aliasName.equals(typeInfo.binding)) {
//                entityIndex = i;
//            }

            typeInfo.infosArray = typeInfo.allFields.toArray(new FieldInfo[typeInfo.allFields.size()]);
            typeInfo.update = false;
            for (FieldInfo field : typeInfo.infosArray) {
                if (!field.nativeField.isExpanded() && field.nativeField.getIndex() >= 0) {
                    field.update = true;
                    field.indexesToUpdate.add(field.nativeField.getIndex());

                    allIndexes.remove(field.nativeField.getIndex());
                    visitedIndexes.put(field.nativeField.getExprString(), field);
                }
            }
            if (typeInfo.entity == null) {
                typeInfo.update = true;
            } else {
                List<ResultField> fields1 = metaData.getResultFields();
                for (int i1 = 0; i1 < fields1.size(); i1++) {
                    ResultField resultField = fields1.get(i1);
                    if (resultField.getExpression().toString().equals(typeInfo.binding)) {
                        typeInfo.update = true;
                        typeInfo.indexesToUpdate.add(i1);

                        allIndexes.remove(i1);
                        visitedIndexes.put(typeInfo.binding, typeInfo);

                        break;
                    }
                }
            }

        }
        //when an expression is to be expanded twice, implementation ignores second expansion
        // so we must find the equivalent expression index to handle
        for (Integer remaining : allIndexes) {
            String k = metaData.getResultFields().get(remaining).getExpression().toString();
            Object o = visitedIndexes.get(k);
            if (o instanceof TypeInfo) {
                ((TypeInfo) o).indexesToUpdate.add(remaining);
            } else if (o instanceof FieldInfo) {
                ((FieldInfo) o).indexesToUpdate.add(remaining);
            } else {
                throw new UPAException("Unsupported");
            }
        }

        this.updatable = updatable;
//        List<Command> commands = parseCommandBuilder();
//        parseCommands= commands.toArray(new Command[commands.size()]);
    }

//    @Override
//    public T parse(final QueryResult result) throws UPAException {
//        long a1 = System.currentTimeMillis();
//        int max = 300000;
//        for (int i = 0; i < max; i++) {
//            parseCommand(result);
//        }
//        long a2 = System.currentTimeMillis();
//        for (int i = 0; i < max; i++) {
//            parseSimple(result);
//        }
//        long a3 = System.currentTimeMillis();
//
//        System.out.println((a2-a1)+" ;; "+(a3-a2));
//        return parseCommand(result);
//    }

//    public T parseCommand(final QueryResult result) throws UPAException {
//        CommandEnv env = new CommandEnv(
//                result,new HashMap<String, Object>(),new HashMap<String, Object>()
//        );
//        for (Command c : parseCommands) {
//            c.process(env);
//        }
//        return (T) this.resultBuilder.createResult(env.groupValues, metaData);
//    }

//    public T parseSimple(final QueryResult result) throws UPAException {

    private void updateRow(ResultColumn[] columns, FieldInfo fi, String label, Object value) {
        if (fi.update) {
            for (Integer index : fi.indexesToUpdate) {
                ResultColumn c = columns[index];
                c.setLabel(label);
                c.setValue(value);
//                System.out.println("update row "+index+" with "+label+" ; "+value);
            }
        }
    }

    private void updateRow(ResultColumn[] columns, TypeInfo fi, String label, Object value) {
        if (fi.update) {
            for (Integer index : fi.indexesToUpdate) {
                ResultColumn c = columns[index];
                c.setLabel(label);
                c.setValue(value);
            }
        }
    }

    public T parse(final QueryResult result) throws UPAException {
        Map<String, Object> groupValues = new HashMap<String, Object>();
        ResultColumn[] values = new ResultColumn[metaData.getResultFields().size()];
        for (int i = 0; i < values.length; i++) {
            values[i] = new ResultColumn();
        }
        for (TypeInfo typeInfo : typeInfos) {
            typeInfo.entityObject = null;
            typeInfo.entityDocument = null;
            typeInfo.entityResult = null;
        }
        for (TypeInfo typeInfo : typeInfos) {
            if (typeInfo.entity == null) {
                for (FieldInfo f : typeInfo.allFields) {
                    Object fieldValue = result.read(f.dbIndex);
                    groupValues.put(f.nativeField.getFullBinding(), fieldValue);
                    groupValues.put(f.nativeField.getExprString(), fieldValue);
                    updateRow(values, f, f.nativeField.getExprString(), fieldValue);
                }
            } else if (typeInfo.leadPrimaryField == null) {
                if (typeInfo.document) {
                    Object entityObject = null;
                    Document entityDocument = typeInfo.entityFactory == null ? ofactory.createObject(Document.class) : typeInfo.entityFactory.createDocument();
                    typeInfo.entityObject = entityObject;
                    typeInfo.entityDocument = entityDocument;
                    typeInfo.entityResult = entityDocument;
                } else {
                    Object entityObject = typeInfo.entityFactory.createObject();
                    Document entityDocument = typeInfo.entityConverter.objectToDocument(entityObject, true);
                    typeInfo.entityObject = entityObject;
                    typeInfo.entityDocument = entityDocument;
                    typeInfo.entityResult = entityObject;
                }
                groupValues.put(typeInfo.binding, typeInfo.entityResult);
                updateRow(values, typeInfo, typeInfo.binding, typeInfo.entityResult);
                for (FieldInfo f : typeInfo.allFields) {
                    Object fieldValue = result.read(f.dbIndex);
                    groupValues.put(f.nativeField.getFullBinding(), fieldValue);
                    typeInfo.entityDocument.setObject(f.name, fieldValue);
                    updateRow(values, f, f.nativeField.getExprString(), fieldValue);
                }
            } else {
                Object leadPK = result.read(typeInfo.leadPrimaryField.dbIndex);
                if (leadPK != null) {
                    //create new instances
                    if (typeInfo.document) {
                        typeInfo.entityDocument = typeInfo.entityFactory == null ? ofactory.createObject(Document.class) : typeInfo.entityFactory.createDocument();
                        typeInfo.entityResult = typeInfo.entityDocument;
                    } else {
                        Object entityObject = typeInfo.entityFactory.createObject();
                        Document entityDocument = typeInfo.entityConverter.objectToDocument(entityObject, true);
                        typeInfo.entityObject = entityObject;
                        typeInfo.entityDocument = entityDocument;
                        typeInfo.entityResult = entityObject;
                    }
                    groupValues.put(typeInfo.binding, typeInfo.entityResult);
                    updateRow(values, typeInfo, typeInfo.binding, typeInfo.entityResult);
                    for (FieldInfo f : typeInfo.allFields) {
                        Object fieldValue = result.read(f.dbIndex);
                        groupValues.put(f.nativeField.getFullBinding(), fieldValue);
                        updateRow(values, f, f.nativeField.getExprString(), fieldValue);
                        typeInfo.entityDocument.setObject(f.name, fieldValue);
                    }
                    if (loadManyToOneRelations) {
                        for (Relationship relationship : typeInfo.manyToOneRelations) {
                            Object extractedId = relationship.extractIdByForeignFields(typeInfo.entityDocument);
                            if (extractedId != null) {
                                Object value = loader.loadObject(relationship.getTargetEntity(), extractedId, relationAsDocument, loaderContext);
                                typeInfo.entityDocument.setObject(relationship.getSourceRole().getEntityField().getName(), value);
                                groupValues.put(typeInfo.binding + "." + relationship.getSourceRole().getEntityField().getName(), value);
                            }
                        }
                    }
                } else {
                    typeInfo.entityObject = null;
                    typeInfo.entityDocument = null;
                }
            }
        }
        for (TypeInfo typeInfo : typeInfos) {
            if (typeInfo.parentBinding != null) {
                TypeInfo pp = bindingToTypeInfos.get(typeInfo.parentBinding);
                if (pp == null) {
                    //no parent loaded actually!!
                    //throw new IllegalArgumentException("Invalid binding " + typeInfo.binding);
                } else if (pp.entityDocument != null) {
                    pp.entityDocument.setObject(typeInfo.bindingName, typeInfo.entityResult);
                }
            }
        }
        if (updatable) {
            for (TypeInfo typeInfo : typeInfos) {
                if (typeInfo.document) {
                    QueryResultUpdaterPropertyChangeListener li = new QueryResultUpdaterPropertyChangeListener(typeInfo, result);
                    typeInfo.entityDocument.addPropertyChangeListener(li);
                } else {
                    typeInfo.entityUpdatable = PlatformUtils.createObjectInterceptor(
                            typeInfo.entityType,
                            new UpdatableObjectInterceptor(typeInfo, typeInfo.entityObject, result));
                    groupValues.put(typeInfo.binding, typeInfo.entityUpdatable);
                    int index = typeInfo.allFields.get(0).nativeField.getIndex();
                    if (values[index].getValue() == typeInfo.entityType) {
                        values[index].setValue(typeInfo.entityUpdatable);
                    }
                }
            }
        }
        return (T) this.resultBuilder.createResult(values, metaData);
    }

//    public List<Command> parseCommandBuilder() throws UPAException {
//        List<Command> commands=new ArrayList<Command>();
//        for (final TypeInfo typeInfo : typeInfos) {
//            if (typeInfo.entity==null) {
//                commands.add(new Command() {
//                    @Override
//                    public void process(CommandEnv env) {
//                        for (FieldInfo f : typeInfo.allFields) {
//                            Object fieldValue = env.result.read(f.index);
//                            env.groupValues.put(f.nativeField.getFullBinding(), fieldValue);
//                            env.groupValues.put(f.nativeField.getExprString(), fieldValue);
//                        }
//                    }
//                });
//            }else if (typeInfo.leadPrimaryField == null) {
//                if(typeInfo.document){
//                    if(typeInfo.entityFactory == null) {
//                       commands.add(new Command() {
//                           @Override
//                           public void process(CommandEnv env) {
//                               Object entityObject = null;
//                               Document entityDocument = ofactory.createObject(Document.class);
//                               typeInfo.entityObject = entityObject;
//                               typeInfo.entityDocument = entityDocument;
//                               typeInfo.entityResult = entityDocument;                           }
//                       });
//                    }else{
//                        commands.add(new Command() {
//                            @Override
//                            public void process(CommandEnv env) {
//                                Object entityObject = null;
//                                Document entityDocument = typeInfo.entityFactory.createDocument();
//                                typeInfo.entityObject = entityObject;
//                                typeInfo.entityDocument = entityDocument;
//                                typeInfo.entityResult = entityDocument;
//                            }
//                        });
//                    }
//                }else{
//                    commands.add(new Command() {
//                        @Override
//                        public void process(CommandEnv env) {
//                            Object entityObject = typeInfo.entityFactory.createObject();
//                            Document entityDocument = typeInfo.entityConverter.objectToDocument(entityObject, true);
//                            typeInfo.entityObject = entityObject;
//                            typeInfo.entityDocument = entityDocument;
//                            typeInfo.entityResult = entityObject;
//                        }
//                    });
//                }
//                commands.add(new Command() {
//                    @Override
//                    public void process(CommandEnv env) {
//                        env.groupValues.put(typeInfo.binding, typeInfo.entityResult);
//                        for (FieldInfo f : typeInfo.allFields) {
//                            Object fieldValue = env.result.read(f.index);
//                            env.groupValues.put(f.nativeField.getFullBinding(), fieldValue);
//                            typeInfo.entityDocument.setObject(f.name, fieldValue);
//                        }
//                    }
//                });
//            } else {
//                ConditionCommand leadPK1 = new ConditionCommand(new Condition() {
//                    @Override
//                    public boolean eval(CommandEnv env) {
//                        Object leadPK = env.result.read(typeInfo.leadPrimaryField.index);
//                        env.vars.put("leadPK", leadPK);
//                        return leadPK != null;
//                    }
//                });
//                commands.add(leadPK1);
//                leadPK1.whenFalse(new Command() {
//                    @Override
//                    public void process(CommandEnv env) {
//                        typeInfo.entityObject = null;
//                        typeInfo.entityDocument = null;
//                    }
//                });
//                if(typeInfo.document) {
//                    leadPK1.whenTrue(new Command() {
//                        @Override
//                        public void process(CommandEnv env) {
//                            typeInfo.entityDocument = typeInfo.entityFactory == null ? ofactory.createObject(Document.class) : typeInfo.entityFactory.createDocument();
//                            typeInfo.entityResult = typeInfo.entityDocument;
//                        }
//                    });
//                }else{
//                    leadPK1.whenTrue(new Command() {
//                        @Override
//                        public void process(CommandEnv env) {
//                            Object entityObject = typeInfo.entityFactory.createObject();
//                            Document entityDocument = typeInfo.entityConverter.objectToDocument(entityObject, true);
//                            typeInfo.entityObject = entityObject;
//                            typeInfo.entityDocument = entityDocument;
//                            typeInfo.entityResult = entityObject;
//                        }
//                    });
//                }
//                leadPK1.whenTrue.add(new Command() {
//                    @Override
//                    public void process(CommandEnv env) {
//                        env.groupValues.put(typeInfo.binding,typeInfo.entityResult);
//                        for (FieldInfo f : typeInfo.allFields) {
//                            Object fieldValue = env.result.read(f.index);
//                            env.groupValues.put(f.nativeField.getFullBinding(),fieldValue);
//                            typeInfo.entityDocument.setObject(f.name, fieldValue);
//                        }
//                    }
//                });
//                if(loadManyToOneRelations) {
//                    leadPK1.whenTrue.add(new Command() {
//                        @Override
//                        public void process(CommandEnv env) {
//                            for (Relationship relationship : typeInfo.manyToOneRelations) {
//                                Object extractedId = relationship.extractIdByForeignFields(typeInfo.entityDocument);
//                                if(extractedId!=null) {
//                                    Object value = loader.loadObject(relationship.getTargetEntity(),extractedId, relationAsDocument,loaderContext);
//                                    typeInfo.entityDocument.setObject(relationship.getSourceRole().getEntityField().getName(), value);
//                                    env.groupValues.put(typeInfo.binding+"."+relationship.getSourceRole().getEntityField().getName(),value);
//                                }
//                            }
//                        }
//                    });
//                }
//            }
//        }
//
//        for (final TypeInfo typeInfo : typeInfos) {
//            if (typeInfo.parentBinding != null) {
//                final TypeInfo pp = bindingToTypeInfos.get(typeInfo.parentBinding);
//                if (pp == null) {
//                    //no parent loaded actually!!
//                    //throw new IllegalArgumentException("Invalid binding " + typeInfo.binding);
//                }else {
//                    commands.add(new Command() {
//                        @Override
//                        public void process(CommandEnv env) {
//                            if (pp.entityDocument != null) {
//                                pp.entityDocument.setObject(typeInfo.bindingName, typeInfo.entityResult);
//                            }
//                        }
//                    });
//                }
//            }
//        }
//        if (updatable) {
//            for (final TypeInfo typeInfo : typeInfos) {
//                if(typeInfo.document) {
//                    commands.add(new Command() {
//                        @Override
//                        public void process(CommandEnv env) {
//                            QueryResultUpdaterPropertyChangeListener li = new QueryResultUpdaterPropertyChangeListener(typeInfo, env.result);
//                            typeInfo.entityDocument.addPropertyChangeListener(li);
//                        }
//                    });
//                }else{
//                    commands.add(new Command() {
//                        @Override
//                        public void process(CommandEnv env) {
//                            typeInfo.entityUpdatable = PlatformUtils.createObjectInterceptor(
//                                    typeInfo.entityType,
//                                    new UpdatableObjectInterceptor(typeInfo, typeInfo.entityObject, env.result));
//                            env.groupValues.put(typeInfo.binding, typeInfo.entityUpdatable);
//                        }
//                    });
//                }
//            }
//        }
//        return commands;
//    }
//
//
//
//
//    private static class CommandEnv {
//        QueryResult result;
//        Map<String,Object> vars;
//        Map<String,Object> groupValues;
//
//        public CommandEnv(QueryResult result, Map<String, Object> vars, Map<String, Object> groupValues) {
//            this.result = result;
//            this.vars = vars;
//            this.groupValues = groupValues;
//        }
//    }
//    private static interface Command {
//        void process(CommandEnv env);
//    }
//    private static interface Condition{
//        boolean eval(CommandEnv env);
//    }
//    private static class ConditionCommand implements Command{
//        List<Command> whenTrue=new ArrayList<Command>();
//        List<Command> whenFalse=new ArrayList<Command>();
//        Condition condition;
//
//        public ConditionCommand(Condition condition) {
//            this.condition = condition;
//        }
//
//        public ConditionCommand whenTrue(Command c){
//            whenTrue.add(c);
//            return this;
//        }
//        public ConditionCommand whenFalse(Command c){
//            whenFalse.add(c);
//            return this;
//        }
//
//        public void process(CommandEnv env){
//            if(condition.eval(env)){
//                for (Command command : whenTrue) {
//                    command.process(env);
//                }
//            }else{
//                for (Command command : whenFalse) {
//                    command.process(env);
//                }
//            }
//        }
//    }
}
