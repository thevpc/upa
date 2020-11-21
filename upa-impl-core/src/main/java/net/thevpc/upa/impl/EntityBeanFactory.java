package net.thevpc.upa.impl;

import net.thevpc.upa.*;
import net.thevpc.upa.impl.util.DocumentHolder;
import net.thevpc.upa.impl.util.PlatformUtils;


import java.util.List;

import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.exceptions.IllegalUPAArgumentException;

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
            throw new IllegalUPAArgumentException(e);
        }
    }

    @Override
    public Document objectToDocument(Object object, boolean ignoreUnspecified) {
        if(object instanceof Document){
            return (Document) object;
        }
        if(object instanceof DocumentHolder){
            return ((DocumentHolder) object).$document();
        }
        return new BeanAdapterDocument(entity.getPlatformBeanType().getPlatformType().cast(object),entity, nfo, ignoreUnspecified);
    }


    @Override
    public <R> R documentToObject(Document fromDocument,Object toObject) {
        Document ur = objectToDocument(toObject, true);
        for (String k : fromDocument.keySet()) {
            Object o= fromDocument.getObject(k);
            if(o instanceof Document){
                if(o == fromDocument){
                    //do nothing
                    o=toObject;
                }else {
                    Field f = entity.findField(k);
                    Relationship manyToOneRelationship = f.getManyToOneRelationship();
                    if (manyToOneRelationship != null) {
                        Entity oe = manyToOneRelationship.getTargetEntity();
                        o = oe.getBuilder().documentToObject((Document) o);
                    }
                }
            }
            ur.setObject(k, o);
        }
//        ur.setAll(unstructuredDocument);
        return (R) toObject;
    }

    @Override
    public <R> R documentToObject(Document document) {
        if (document instanceof BeanAdapterDocument) {
            BeanAdapterDocument g = (BeanAdapterDocument) document;
            return (R) g.userObject();
        }
        Class platformType = entity.getPlatformBeanType().getPlatformType();
        if(platformType.equals(Document.class)){
            return (R) document;
        }
        return (R) PlatformUtils.createEntityBeanForDocument(platformType,document,entity);
//        Object obj = createObject();
//        Document ur = objectToDocument(obj, true);
//        for (String k : document.keySet()) {
//            Object o= document.getObject(k);
//            if(o instanceof Document){
//                if(o == document){
//                    //do nothing
//                    o=obj;
//                }else {
//                    Field f = entity.findField(k);
//                    Relationship manyToOneRelationship = f.getManyToOneRelationship();
//                    if (manyToOneRelationship != null) {
//                        Entity oe = manyToOneRelationship.getTargetEntity();
//                        o = oe.getBuilder().documentToObject((Document) o);
//                    }
//                }
//            }
//            ur.setObject(k, o);
//        }
//        ur.setAll(unstructuredDocument);
//        return (R) obj;
    }

    @Override
    public void setProperty(Object object, String property, Object value) throws UPAException {
        if(object instanceof Document){
            ((Document) object).setObject(property,value);
        }else {
            nfo.setPropertyValue(object, property, value);
        }
    }

    @Override
    public Object getProperty(Object object, String property) throws UPAException {
        if(object instanceof Document){
            return ((Document) object).getObject(property);
        }
        return nfo.getPropertyValue(object, property);
    }

    @Override
    protected Entity getEntity() {
        return entity;
    }
}
