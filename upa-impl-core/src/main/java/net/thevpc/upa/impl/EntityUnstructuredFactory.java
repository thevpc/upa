package net.thevpc.upa.impl;

import net.thevpc.upa.Document;
import net.thevpc.upa.Entity;
import net.thevpc.upa.exceptions.UPAException;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/27/12 1:51 AM
 */
public class EntityUnstructuredFactory extends AbstractEntityFactory {
    private Entity entity;
    public EntityUnstructuredFactory(Entity entity) {
        this.entity=entity;
    }

    public Document createDocument() {
        return new DefaultDocument();
    }

    public <R> R createObject() {
        //double cast is needed in c#
        return (R) (Object)new DefaultDocument();
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
        return (R) document;
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
