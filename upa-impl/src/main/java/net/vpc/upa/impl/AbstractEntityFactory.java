package net.vpc.upa.impl;

import net.vpc.upa.Entity;
import net.vpc.upa.Field;
import net.vpc.upa.Record;

import java.util.Set;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/28/12 12:45 AM
 */
public abstract class AbstractEntityFactory implements EntityFactory {
    @Override
    public Record getRecord(Object object) {
        return getRecord(object,false);
    }

    @Override
    public Record getRecord(Object object, Set<String> fields, boolean ignoreUnspecified, boolean ensureIncludeIds) {
        Record r = createRecord();
        Record allFieldsRecord = getRecord(object,ignoreUnspecified);
        if(fields==null || fields.isEmpty()){
            r.setAll(r);
            return r;
        }else {
            for (String k : fields) {
                r.setObject(k, allFieldsRecord.getObject(k));
            }
            if(ensureIncludeIds) {
                for (Field o : getEntity().getPrimaryFields()) {
                    String idname = o.getName();
                    if (!r.isSet(idname)) {
                        r.setObject(idname, allFieldsRecord.getObject(idname));
                    }
                }
            }
            return r;
        }
    }
    protected abstract Entity getEntity();
}
