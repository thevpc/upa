package net.vpc.upa.impl;

import net.vpc.upa.*;

import java.util.List;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.types.ManyToOneType;
import net.vpc.upa.types.DataType;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/27/12 1:51 AM
 */
public class EntityBeanFactory extends AbstractEntityFactory {

    private final BeanType nfo;
    private final Entity entity;
    private final ObjectFactory objectFactory;
//    private final Map<String, String> setterToProp = new HashMap<String, String>();

    public EntityBeanFactory(Entity entity, ObjectFactory objectFactory) {
        this.entity = entity;
        this.nfo = entity.getBeanType();
        this.objectFactory = objectFactory;
        List<Field> fields = entity.getFields();
//        for (Field field : fields) {
//            setterToProp.put(PlatformUtils.setterName(field.getName()), field.getName());
//        }
    }

    @Override
    public Record createRecord() {
        return objectFactory.createObject(Record.class);
    }

    @Override
    public <R> R createObject() {
        try {
            return (R) entity.getBeanType().newInstance();
        } catch (Exception e) {
            throw new IllegalArgumentException(e);
        }
    }

    @Override
    public Record objectToRecord(Object object, boolean ignoreUnspecified) {
        if(object instanceof Record){
            return (Record) object;
        }
        return new BeanAdapterRecord(entity.getBeanType().getPlatformType().cast(object),entity.getName(), nfo, ignoreUnspecified);
    }


    @Override
    public Object recordToObject(Record record) {
        if (record instanceof BeanAdapterRecord) {
            BeanAdapterRecord g = (BeanAdapterRecord) record;
            return g.userObject();
        }
        Object obj = createObject();
        Record ur = objectToRecord(obj, true);
        for (String k : record.keySet()) {
            Object o= record.getObject(k);
            if(o instanceof Record){
                Field f = entity.findField(k);
                DataType dt = f.getDataType();
                if(dt instanceof ManyToOneType){
                    Entity oe = ((ManyToOneType)dt).getRelationship().getTargetEntity();
                    o = oe.getBuilder().recordToObject((Record)o);
                }
            }
            ur.setObject(k, o);
        }
//        ur.setAll(unstructuredRecord);
        return obj;
    }

    @Override
    public void setProperty(Object object, String property, Object value) throws UPAException {
        if(object instanceof Record){
            ((Record) object).setObject(property,value);
        }else {
            nfo.setProperty(object, property, value);
        }
    }

    @Override
    public Object getProperty(Object object, String property) throws UPAException {
        if(object instanceof Record){
            return ((Record) object).getObject(property);
        }
        return nfo.getProperty(object, property);
    }

    @Override
    protected Entity getEntity() {
        return entity;
    }
}
