package net.vpc.upa.impl.persistence;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.persistence.QueryResult;

import java.sql.SQLException;
import java.util.LinkedHashMap;

/**
 * User: vpc Date: 8/16/12 Time: 6:41 AM To change this template use File |
 * Settings | File Templates.
 */
public class SingleEntityQueryResult<R> extends QueryResultIteratorList<R> {

//    static private Fields MANY_TO_ONE_FILTER = Fields.regular().and(new DataTypeClassFieldFilter(EntityType.class));
    private boolean updatable;
//    private int columns;
    private TypeInfo[] typeInfos;
//    private FieldInfo[] fieldInfos;
    private int entityIndex = 0;
//    private String[] names;
//    private EntityFactory entityFactory;
//    private EntityBuilder converter;
//    private Class entityType;
    private LinkedHashMap<String, TypeInfo> bindingToTypeInfos;
//    private List<Field> manyToOneFields;

    public SingleEntityQueryResult(NativeSQL nativeSQL, String aliasName) throws SQLException {
        super(nativeSQL);
        LinkedHashMap<String, TypeInfo> bindingToTypeInfos0 = new LinkedHashMap<String, TypeInfo>();
//        List<FieldInfo> fieldInfos0 = new ArrayList<FieldInfo>();
        int index = 0;
        for (NativeField nativeField : nativeSQL.getFields()) {
            FieldInfo f = new FieldInfo();
            f.index = index;
            f.nativeField = nativeField;
            f.name = nativeField.getName();
            String gn = nativeField.getGroupName();
            TypeInfo t = bindingToTypeInfos0.get(gn);
            if (t == null) {
                t = new TypeInfo(gn, nativeField.getField().getEntity());
                bindingToTypeInfos0.put(gn, t);
            }
            f.typeInfo = t;
            t.infos.add(f);
            if (t.leadPrimaryField == null && f.nativeField.getField().isId()) {
                t.leadPrimaryField = f;
            }
            if (t.leadField == null) {
                t.leadField = f;
            }
            f.setterMethodName = PlatformUtils.setterName(nativeField.getName());
            t.fields.put(f.setterMethodName, f);
//            fieldInfos0.add(f);
            index++;
        }
        bindingToTypeInfos = bindingToTypeInfos0;
//        fieldInfos = fieldInfos0.toArray(new FieldInfo[fieldInfos0.size()]);
        typeInfos = bindingToTypeInfos0.values().toArray(new TypeInfo[bindingToTypeInfos0.size()]);
        for (int i = 0; i < typeInfos.length; i++) {
            TypeInfo typeInfo = typeInfos[i];
            if (aliasName.equals(typeInfo.binding)) {
                entityIndex = i;
            }
            typeInfo.infosArray = typeInfo.infos.toArray(new FieldInfo[typeInfo.infos.size()]);
            //typeInfo.infos=null;
        }
//        columns = fieldInfos.length;
        updatable = nativeSQL.isUpdatable();
    }

    @Override
    public R parse(final QueryResult result) throws UPAException {

        for (TypeInfo typeInfo : typeInfos) {
            if (typeInfo.leadPrimaryField == null) {
//                Object leadVal = result.read(typeInfo.leadField.index);
                Object entityObject = typeInfo.entityFactory.createObject();
                Record entityRecord = typeInfo.entityConverter.entityToRecord(entityObject, true);
                typeInfo.entityObject = entityObject;
                typeInfo.entityRecord = entityRecord;
                for (FieldInfo f : typeInfo.infos) {
                    entityRecord.setObject(f.name, result.read(f.index));
                }
            } else {
                Object leadPK = result.read(typeInfo.leadPrimaryField.index);
                if (leadPK != null) {
                    //create new instances
                    Object entityObject = typeInfo.entityFactory.createObject();
                    Record entityRecord = typeInfo.entityConverter.entityToRecord(entityObject, true);
                    typeInfo.entityObject = entityObject;
                    typeInfo.entityRecord = entityRecord;
                    for (FieldInfo f : typeInfo.infos) {
                        entityRecord.setObject(f.name, result.read(f.index));
                    }
                } else {
                    typeInfo.entityObject = null;
                    typeInfo.entityRecord = null;
                }
            }
        }
//        for (int i = 0; i < columns; i++) {
//            FieldInfo f = fieldInfos[i];
//            System.out.println(i + " : " + f.nativeField.getField());
//            f.typeInfo.entityRecord.setObject(f.name, result.read(i));
//        }
        for (TypeInfo typeInfo : typeInfos) {
            if (typeInfo.parentBinding != null) {
                TypeInfo pp = bindingToTypeInfos.get(typeInfo.parentBinding);
                if (pp == null) {
                    throw new IllegalArgumentException("Invalid binding " + typeInfo.binding);
                }
                if (pp.entityRecord != null) {
                    pp.entityRecord.setObject(typeInfo.bindingName, typeInfo.entityObject);
                }
            }
        }
        if (updatable) {
            for (TypeInfo typeInfo : typeInfos) {
                typeInfo.entityUpdatable = PlatformUtils.createObjectInterceptor(
                        typeInfo.entityType,
                        new SingleEntityQueryResultParseMethodInterceptor(typeInfo, typeInfo.entityObject, result));
            }
            return (R) typeInfos[entityIndex].entityUpdatable;
        } else {
            return (R) typeInfos[entityIndex].entityObject;
        }

//            for (Field field : manyToOneFields) {
//                //should be a single relation!
//                List<Relationship> relations = field.getRelations();
//                Relationship r = relations.get(0);
//                Key key = r.getKey(ur);
//                if(key!=null){
//                    Object ref=r.getTargetRole().getEntity().createQueryBuilder().setKey(key).getEntity();
//                    ur.setObject(field.getName(), ref);
//                }
//            }
    }

}
