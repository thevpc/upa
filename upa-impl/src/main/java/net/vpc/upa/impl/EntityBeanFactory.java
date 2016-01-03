package net.vpc.upa.impl;

import net.vpc.upa.Field;
import net.vpc.upa.ObjectFactory;
import net.vpc.upa.Record;
import net.vpc.upa.impl.util.EntityBeanAdapter;

import java.util.HashMap;
import java.util.List;
import java.util.Map;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.util.PlatformUtils;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/27/12 1:51 AM
 */
public class EntityBeanFactory extends AbstractEntityFactory {

    private final EntityBeanAdapter nfo;
    private final Class type;
    private final ObjectFactory objectFactory;
    private final Map<String, String> setterToProp = new HashMap<String, String>();

    public EntityBeanFactory(EntityBeanAdapter nfo, Class type, ObjectFactory objectFactory) {
        this.nfo = nfo;
        this.type = type;
        this.objectFactory = objectFactory;
        List<Field> fields = nfo.getEntity().getFields();
        for (Field field : fields) {
            setterToProp.put(PlatformUtils.setterName(field.getName()), field.getName());
        }
    }

    @Override
    public Record createRecord() {
        return objectFactory.createObject(Record.class);
    }

    @Override
    public <R> R createObject() {
        try {
            return (R) type.newInstance();
        } catch (Exception e) {
            throw new IllegalArgumentException(e);
        }
    }

    @Override
    public <R> Record getRecord(R entity, boolean ignoreUnspecified) {
        if(entity instanceof Record){
            return (Record)entity;
        }
        return new BeanAdapterRecord(type.cast(entity), nfo, ignoreUnspecified);
    }

    @Override
    public <R> R getEntity(Record unstructuredRecord) {
        if (unstructuredRecord instanceof BeanAdapterRecord) {
            BeanAdapterRecord g = (BeanAdapterRecord) unstructuredRecord;
            return (R) g.userObject();
        }
        R obj = createObject();
        Record ur = getRecord(obj, true);
        ur.setAll(unstructuredRecord);
        return obj;
    }

    @Override
    public void setProperty(Object entityObject, String property, Object value) throws UPAException {
        nfo.setProperty(entityObject, property, value);
    }

    @Override
    public Object getProperty(Object entityObject, String property) throws UPAException {
        return nfo.getProperty(entityObject, property);
    }
}
