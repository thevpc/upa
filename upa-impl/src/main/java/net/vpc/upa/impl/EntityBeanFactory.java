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

    private final PlatformBeanType nfo;
    private final Entity entity;
    private final ObjectFactory objectFactory;
//    private final Map<String, String> setterToProp = new HashMap<String, String>();

    public EntityBeanFactory(Entity entity, ObjectFactory objectFactory) {
        this.entity = entity;
        this.nfo = entity.getPlatformBeanType();
        this.objectFactory = objectFactory;
        List<Field> fields = entity.getFields();
//        for (Field field : fields) {
//            setterToProp.put(PlatformUtils.setterName(field.getName()), field.getName());
//        }
    }

    @Override
    public Document createDocument() {
        return objectFactory.createObject(Document.class);
    }

    @Override
    public <R> R createObject() {
        try {
            return (R) entity.getPlatformBeanType().newInstance();
        } catch (Exception e) {
            throw new IllegalArgumentException(e);
        }
    }

    @Override
    public Document objectToDocument(Object object, boolean ignoreUnspecified) {
        if(object instanceof Document){
            return (Document) object;
        }
        return new BeanAdapterDocument(entity.getPlatformBeanType().getPlatformType().cast(object),entity.getName(), nfo, ignoreUnspecified);
    }


    @Override
    public <R> R documentToObject(Document document) {
        if (document instanceof BeanAdapterDocument) {
            BeanAdapterDocument g = (BeanAdapterDocument) document;
            return (R) g.userObject();
        }
        Object obj = createObject();
        Document ur = objectToDocument(obj, true);
        for (String k : document.keySet()) {
            Object o= document.getObject(k);
            if(o instanceof Document){
                Field f = entity.findField(k);
                DataType dt = f.getDataType();
                if(dt instanceof ManyToOneType){
                    Entity oe = ((ManyToOneType)dt).getRelationship().getTargetEntity();
                    o = oe.getBuilder().documentToObject((Document)o);
                }
            }
            ur.setObject(k, o);
        }
//        ur.setAll(unstructuredDocument);
        return (R) obj;
    }

    @Override
    public void setProperty(Object object, String property, Object value) throws UPAException {
        if(object instanceof Document){
            ((Document) object).setObject(property,value);
        }else {
            nfo.setProperty(object, property, value);
        }
    }

    @Override
    public Object getProperty(Object object, String property) throws UPAException {
        if(object instanceof Document){
            return ((Document) object).getObject(property);
        }
        return nfo.getProperty(object, property);
    }

    @Override
    protected Entity getEntity() {
        return entity;
    }
}
