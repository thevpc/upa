package net.vpc.upa.impl.persistence;

import net.vpc.upa.Record;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.persistence.QueryResult;

import java.sql.SQLException;
import java.util.LinkedHashMap;
import net.vpc.upa.ObjectFactory;
import net.vpc.upa.UPA;
import net.vpc.upa.impl.util.PlatformUtils;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/16/12 Time: 6:41 AM To change
 * this template use File | Settings | File Templates.
 */
public class RecordQueryResultJoinFetchStrategy extends AbstractObjectQueryResultLazyList<Record> {

    public RecordQueryResultJoinFetchStrategy(NativeSQL nativeSQL, String aliasName) throws SQLException {
        super(nativeSQL,aliasName,false,false);
    }

    @Override
    public Record parse(final QueryResult result) throws UPAException {

        for (TypeInfo typeInfo : typeInfos) {
            if (typeInfo.leadPrimaryField == null) {
                typeInfo.entityRecord = typeInfo.entityFactory == null ? ofactory.createObject(Record.class) : typeInfo.entityFactory.createRecord();
                for (FieldInfo f : typeInfo.allFields) {
                    typeInfo.entityRecord.setObject(f.name, result.read(f.index));
                }
            } else {
                Object leadPK = result.read(typeInfo.leadPrimaryField.index);
                if (leadPK != null) {
                    typeInfo.entityRecord = typeInfo.entityFactory == null ? ofactory.createObject(Record.class) : typeInfo.entityFactory.createRecord();
                    for (FieldInfo f : typeInfo.allFields) {
                        typeInfo.entityRecord.setObject(f.name, result.read(f.index));
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
                    pp.entityRecord.setObject(typeInfo.bindingName, typeInfo.entityRecord);
                }
            }
        }
        if (updatable) {
            for (TypeInfo typeInfo : typeInfos) {
                QueryResultUpdaterPropertyChangeListener li = new QueryResultUpdaterPropertyChangeListener(typeInfo, result);
                typeInfo.entityRecord.addPropertyChangeListener(li);
            }
            return typeInfos[entityIndex].entityRecord;
        } else {
            return typeInfos[entityIndex].entityRecord;
        }

    }

}
