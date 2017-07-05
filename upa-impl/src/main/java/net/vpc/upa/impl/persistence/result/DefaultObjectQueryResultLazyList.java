package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.persistence.NativeField;
import net.vpc.upa.impl.persistence.QueryExecutor;
import net.vpc.upa.impl.persistence.QueryResultLazyList;
import net.vpc.upa.impl.uql.BindingId;
import net.vpc.upa.impl.util.CacheMap;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.persistence.QueryResult;
import net.vpc.upa.persistence.ResultField;
import net.vpc.upa.persistence.ResultMetaData;

import java.sql.SQLException;
import java.util.*;

/**
 * Created by vpc on 6/18/16.
 */
public class DefaultObjectQueryResultLazyList<T> extends QueryResultLazyList<T> {
    private boolean updatable;
    private ResultMetaData metaData;
    private CacheMap<NamedId, Object> referencesCache;
    private Map<String, Object> hints;
    private ObjectFactory ofactory;
    private boolean defaultsToDocument;
    private boolean relationAsDocument;
    private TypeInfo[] typeInfos;
    private LinkedHashMap<BindingId, TypeInfo> bindingToTypeInfos;
    private QueryResultItemBuilder resultBuilder;
    private QueryResultRelationLoader loader;
    private LoaderContext loaderContext;

    public DefaultObjectQueryResultLazyList(
            PersistenceUnit pu,
            QueryExecutor queryExecutor,
            boolean loadManyToOneRelations,
            boolean defaultsToDocument,
            boolean relationAsDocument,
            int supportCacheSize,
            boolean updatable,
            QueryResultRelationLoader loader,
            QueryResultItemBuilder resultBuilder
    ) throws SQLException {
        super(queryExecutor);
        this.resultBuilder = resultBuilder;
        this.loader = loader;
        this.defaultsToDocument = defaultsToDocument;
        this.relationAsDocument = relationAsDocument;
        metaData = queryExecutor.getMetaData();
        hints = queryExecutor.getHints();
        if (hints == null) {
            hints = new HashMap<String, Object>();
        } else {
            hints = new HashMap<String, Object>(hints);
        }
        if (supportCacheSize>0) {
            CacheMap<NamedId, Object> sharedCache = (CacheMap<NamedId, Object>) hints.get("queryCache");
            if (sharedCache == null) {
                sharedCache = new CacheMap<NamedId, Object>(supportCacheSize);
                hints.put("queryCache", sharedCache);
            }
            referencesCache = sharedCache;
        }
        loaderContext = new LoaderContext(referencesCache, hints);
        LinkedHashMap<BindingId, TypeInfo> bindingToTypeInfos0 = new LinkedHashMap<BindingId, TypeInfo>();
        ofactory = pu.getFactory();
        NativeField[] fields = queryExecutor.getFields();
        for (int i = 0; i < fields.length; i++) {
            NativeField nativeField = fields[i];
            FieldInfo f = new FieldInfo();
            f.dbIndex = i;
            f.nativeField = nativeField;
            f.name = nativeField.getName();
            BindingId gn = nativeField.getGroupName();
            f.binding = gn;
            BindingId pgn = gn.getParent();
            TypeInfo typeInfo = bindingToTypeInfos0.get(pgn);
            if (typeInfo == null) {
                if (nativeField.getField() != null) {
                    typeInfo = new TypeInfo(pgn, nativeField.getField().getEntity());
                    typeInfo.document = pgn != null ? relationAsDocument : defaultsToDocument;
                    bindingToTypeInfos0.put(pgn, typeInfo);
                } else {
                    typeInfo = new TypeInfo(pgn);
                    typeInfo.document = false;//n.contains(".") ? relationAsDocument : defaultsToDocument;
                    bindingToTypeInfos0.put(pgn, typeInfo);
                }
            }
            f.field = nativeField.getField();
            if (loadManyToOneRelations) {
                if (f.field != null) {
                    for (Relationship relationship : f.field.getManyToOneRelationships()) {
                        if (relationship.getSourceRole().getEntityField() != null) {
                            typeInfo.manyToOneRelations.add(relationship);
                        }
                    }
                }
            }
            f.typeInfo = typeInfo;
            if(f.field!=null && f.field.isId()){
                typeInfo.idFields.add(f);
            }else {
                typeInfo.nonIdFields.add(f);
            }
            if (typeInfo.leadPrimaryField == null && f.nativeField.getField() != null && f.nativeField.getField().isId()) {
                typeInfo.leadPrimaryField = f;
            }
            if (typeInfo.entity != null && typeInfo.leadField == null) {
                typeInfo.leadField = f;
            }
            typeInfo.fieldsMap.put(f.binding.getName(), f);
        }
        bindingToTypeInfos = bindingToTypeInfos0;
        typeInfos = bindingToTypeInfos0.values().toArray(new TypeInfo[bindingToTypeInfos0.size()]);
        for (TypeInfo typeInfo : typeInfos) {
            if(typeInfo.entity!=null){
                Set<String> visitedIds=new HashSet<>();
                Set<String> expectedIds=new HashSet<>();
                List<Field> idFields = typeInfo.entity.getIdFields();
                for (Field field : idFields) {
                    expectedIds.add(field.getName());
                }
                for (Iterator<FieldInfo> iterator = typeInfo.idFields.iterator(); iterator.hasNext(); ) {
                    FieldInfo field = iterator.next();
                    //id field defined twice, not so reasonable, but may happen
                    //if user defines by him self columns
                    String fieldName = field.field.getName();
                    if(visitedIds.contains(fieldName)){
                       iterator.remove();
                       typeInfo.nonIdFields.add(field);
                    }else if(expectedIds.contains(fieldName)){
                        visitedIds.add(fieldName);
                        expectedIds.remove(fieldName);
                    }else{
                        //should never happen
                        throw new IllegalArgumentException("Should never Happen");
                    }
                }
                FieldInfo[] nonOrderedIdFields = typeInfo.idFields.toArray(new FieldInfo[typeInfo.idFields.size()]);

                //now re-order id fields
                for (int i = 0; i < idFields.size(); i++) {
                    for (int j = 0; j < nonOrderedIdFields.length; j++) {
                        if(typeInfo.idFields.get(j).field.getName().equals(idFields.get(i).getName())){
                            nonOrderedIdFields[i]=typeInfo.idFields.get(j);
                            break;
                        }
                    }
                }

                if(expectedIds.isEmpty() && !typeInfo.idFields.isEmpty()){
                    typeInfo.identifiable=true;
                }
            }
            if(typeInfo.binding==null){
                typeInfo.parser= SupParserNoBinding.INSTANCE;
            }else if(typeInfo.entity!=null && typeInfo.identifiable) {
                if(typeInfo.idFields.size()==1) {
                    typeInfo.parser = new SupParserSingleIdEntity(ofactory);
                }else {
                    typeInfo.parser = new SupParserMultiIdEntity(ofactory);
                }
            }else if(typeInfo.entity!=null && !typeInfo.identifiable){
                typeInfo.parser= new SupParserNoIdEntity(ofactory);
            }else {
                throw new IllegalArgumentException("Unsupported binding "+typeInfo.binding);
            }
        }
        for (TypeInfo typeInfo : typeInfos) {
            typeInfo.fieldsArray = typeInfo.nonIdFields.toArray(new FieldInfo[typeInfo.nonIdFields.size()]);
        }

        this.updatable = updatable;
    }

    public T parse(final QueryResult result) throws UPAException {
        Map<BindingId, Object> groupValues = new HashMap<BindingId, Object>();
        Map<BindingId, TypeInfo> groupTypes = new HashMap<BindingId, TypeInfo>();
        List<ResultField> resultFields = metaData.getResultFields();
        ResultColumn[] values = new ResultColumn[resultFields.size()];
        for (TypeInfo typeInfo : typeInfos) {
            groupTypes.put(typeInfo.binding,typeInfo);
            typeInfo.parser.parse(result,typeInfo,groupValues,referencesCache);
            if (updatable) {
                ResultObject currentResult = typeInfo.currentResult;
                if (typeInfo.document) {
                    QueryResultUpdaterPropertyChangeListener li = new QueryResultUpdaterPropertyChangeListener(typeInfo, result);
                    currentResult.entityDocument.addPropertyChangeListener(li);
                } else {
                    currentResult.entityUpdatable = PlatformUtils.createObjectInterceptor(
                            typeInfo.resultType,
                            new UpdatableObjectInterceptor(typeInfo, currentResult.entityObject, result));
                    groupValues.put(typeInfo.binding, currentResult.entityUpdatable);
                    int index = typeInfo.nonIdFields.get(0).nativeField.getIndex();
                    if (values[index].getValue() == typeInfo.resultType) {
                        values[index].setValue(currentResult.entityUpdatable);
                    }
                }
            }
        }
        for (Map.Entry<BindingId, Object> e : groupValues.entrySet()) {
            BindingId currBinding = e.getKey();
            Object currValue = e.getValue();
            BindingId parentBinding = currBinding.getParent();
            if(parentBinding !=null){
                TypeInfo parentType=groupTypes.get(parentBinding);
                Object parent = groupValues.get(parentBinding);
                if(parent!=null){
                    parentType.setterFor(currBinding.getName()).set(parent,currValue);
                }
            }
        }
        for (int i = 0; i < values.length; i++) {
            ResultColumn c=values[i] = new ResultColumn();
            c.setLabel(resultFields.get(i).getAlias());
            c.setValue(groupValues.get(BindingId.create(String.valueOf(i))));
        }
        return (T) this.resultBuilder.createResult(values, metaData);
    }

}
