package net.vpc.upa.impl.persistence;

import net.vpc.upa.Entity;
import net.vpc.upa.NamedId;
import net.vpc.upa.Record;
import net.vpc.upa.Relationship;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.util.CacheMap;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.persistence.QueryResult;
import net.vpc.upa.types.ManyToOneType;

import java.sql.SQLException;
import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.Map;

/**
 * User: vpc Date: 8/16/12 Time: 6:41 AM To change this template use File |
 * Settings | File Templates.
 */
public abstract class SingleEntityQueryResultNonJoinFetchStrategy<R> extends AbstractObjectQueryResultLazyList<R> {

    public SingleEntityQueryResultNonJoinFetchStrategy(NativeSQL nativeSQL, String aliasName) throws SQLException {
        super(nativeSQL,aliasName,true,true);
    }

    @Override
    public R parse(final QueryResult result) throws UPAException {

        for (TypeInfo typeInfo : typeInfos) {
            if (typeInfo.leadPrimaryField == null) {
                Object entityObject = typeInfo.entityFactory.createObject();
                Record entityRecord = typeInfo.entityConverter.objectToRecord(entityObject, true);
                typeInfo.entityObject = entityObject;
                typeInfo.entityRecord = entityRecord;
                for (FieldInfo f : typeInfo.allFields) {
                    entityRecord.setObject(f.name, result.read(f.index));
                }
            } else {
                Object leadPK = result.read(typeInfo.leadPrimaryField.index);
                if (leadPK != null) {
                    //create new instances
                    Object entityObject = typeInfo.entityFactory.createObject();
                    Record entityRecord = typeInfo.entityConverter.objectToRecord(entityObject, true);
                    typeInfo.entityObject = entityObject;
                    typeInfo.entityRecord = entityRecord;
                    for (FieldInfo f : typeInfo.allFields) {
                        entityRecord.setObject(f.name, result.read(f.index));
                    }
                    for (Relationship relationship : typeInfo.manyToOneRelations) {
                        Object extractedId = relationship.extractIdByForeignFields(entityRecord);
                        if(extractedId!=null) {
                            entityRecord.setObject(relationship.getSourceRole().getEntityField().getName(), loadObject(relationship.getTargetEntity(), extractedId));
                        }
                    }
                } else {
                    typeInfo.entityObject = null;
                    typeInfo.entityRecord = null;
                }
            }
        }
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

    }

    protected abstract Object loadObject(Entity e, Object id);

}
