package net.thevpc.upa.impl;

import net.thevpc.upa.Document;
import net.thevpc.upa.Entity;
import net.thevpc.upa.ObjectFactory;
import net.thevpc.upa.exceptions.UPAException;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/27/12 1:51 AM
 */
public class EntitySubclassUnstructuredFactory extends AbstractEntityFactory {

    private Entity entity;
    private Class documentType;
    private ObjectFactory objectFactory;

    public EntitySubclassUnstructuredFactory(Class documentType, ObjectFactory objectFactory, Entity entity) {
        this.documentType = documentType;
        this.objectFactory = objectFactory;
        this.entity = entity;
    }

    public Document createDocument() {
        return (Document) objectFactory.createObject(documentType);
    }

    public <R> R createObject() {
        return (R) createDocument();
    }

    public Document objectToDocument(Object object, boolean ignoreUnspecified) {
        return (Document) object;
    }

    @Override
    public <R> R documentToObject(Document fromDocument, Object toObject) {
        Document d=(Document) toObject;
        d.setAll(fromDocument);
        return (R) d;
    }

    @Override
    public <R> R documentToObject(Document document) {
        if (documentType.isInstance(document)) {
            return (R) document;
        } else {
            Object ur = createDocument();
            ((Document) ur).setAll(document);
            return (R) ur;
        }
    }

    public void setProperty(Object object, String property, Object value) throws UPAException {
        ((Document) object).setObject(property, value);
    }

    public Object getProperty(Object object, String property) throws UPAException {
        return ((Document) object).getObject(property);
    }

    @Override
    protected Entity getEntity() {
        return entity;
    }
}
