package net.vpc.upa.impl.persistence;

import net.vpc.upa.*;
import net.vpc.upa.impl.util.CacheMap;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.types.ManyToOneType;

import java.sql.SQLException;
import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.Map;

/**
 * Created by vpc on 6/18/16.
 */
public abstract class AbstractObjectQueryResultLazyList<T> extends QueryResultLazyList<T>{
    protected boolean updatable;
    protected TypeInfo[] typeInfos;
    protected int entityIndex = 0;
    protected LinkedHashMap<String, TypeInfo> bindingToTypeInfos;
    protected CacheMap<NamedId,Object> referencesCache;
    protected Map<String, Object> hints;
    protected ObjectFactory ofactory;

    public AbstractObjectQueryResultLazyList(NativeSQL nativeSQL, String aliasName,boolean loadManyToOneRelations,boolean  supportCache) throws SQLException {
        super(nativeSQL);
        hints = nativeSQL.getHints();
        if(hints==null){
            hints=new HashMap<String, Object>();
        }else{
            hints=new HashMap<String, Object>(hints);
        }
        if(supportCache) {
            CacheMap<NamedId, Object> sharedCache = (CacheMap<NamedId, Object>) hints.get("queryCache");
            if (sharedCache == null) {
                sharedCache = new CacheMap<NamedId, Object>(1000);
                hints.put("queryCache", sharedCache);
            }
            referencesCache = sharedCache;
        }
        LinkedHashMap<String, TypeInfo> bindingToTypeInfos0 = new LinkedHashMap<String, TypeInfo>();
        ofactory = UPA.getPersistenceUnit().getFactory();
        int index = 0;
        for (NativeField nativeField : nativeSQL.getFields()) {
            FieldInfo f = new FieldInfo();
            f.index = index;
            f.nativeField = nativeField;
            f.name = nativeField.getName();
            String gn = nativeField.getGroupName();
            TypeInfo t = bindingToTypeInfos0.get(gn);
            if (t == null) {
                t = new TypeInfo(gn, nativeField.getField() == null ? null : nativeField.getField().getEntity());
                bindingToTypeInfos0.put(gn, t);
            }
            f.field = nativeField.getField();
                if(loadManyToOneRelations) {
            if(f.field!=null){
                if(f.field.getDataType() instanceof ManyToOneType) {
                    Entity r = ((ManyToOneType) f.field.getDataType()).getReferencedType();
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
            if (t.leadPrimaryField == null && f.nativeField.getField()!=null && f.nativeField.getField().isId()) {
                t.leadPrimaryField = f;
            }
            if (t.leadField == null) {
                t.leadField = f;
            }
            f.setterMethodName = PlatformUtils.setterName(nativeField.getName());
            t.fields.put(f.setterMethodName, f);
            index++;
        }
        bindingToTypeInfos = bindingToTypeInfos0;
        typeInfos = bindingToTypeInfos0.values().toArray(new TypeInfo[bindingToTypeInfos0.size()]);
        for (int i = 0; i < typeInfos.length; i++) {
            TypeInfo typeInfo = typeInfos[i];
            if (aliasName.equals(typeInfo.binding)) {
                entityIndex = i;
            }
            typeInfo.infosArray = typeInfo.allFields.toArray(new FieldInfo[typeInfo.allFields.size()]);
        }
        updatable = nativeSQL.isUpdatable();
    }
}
