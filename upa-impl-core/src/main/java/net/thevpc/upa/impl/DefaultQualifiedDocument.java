package net.thevpc.upa.impl;

import net.thevpc.upa.Document;
import net.thevpc.upa.Entity;
import net.thevpc.upa.Key;
import net.thevpc.upa.QualifiedDocument;

import net.thevpc.upa.exceptions.UPAException;

import java.beans.PropertyChangeListener;
import java.util.Map;
import java.util.Set;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/3/12 1:19 AM
 */
public class DefaultQualifiedDocument extends AbstractDocument implements QualifiedDocument {
    private Entity entity;
    private Document document;

    public DefaultQualifiedDocument(Entity entity) throws UPAException {
        this(entity, entity.getBuilder().createDocument());
    }

    public DefaultQualifiedDocument(Entity entity, Document document) {
        this.entity = entity;
        this.document = document;
    }

    public Entity getEntity() {
        return entity;
    }

    public Document getDocument() {
        return document;
    }

    public String getDocumentName() {
        return getDocument().getObject(getEntity().getMainField().getName());
    }

    public Key getKey() throws UPAException {
        return getEntity().getBuilder().documentToKey(getDocument());
    }

    public void setRawId(Object... ids) throws UPAException {
        Document kr = getEntity().getBuilder().keyToDocument(getEntity().getBuilder().createKey(ids));
        getDocument().setAll(kr);
    }

    public void setIdentifier(Object value) throws UPAException {
        Document kr = getEntity().getBuilder().idToDocument(value);
        getDocument().setAll(kr);
    }

    public void setKey(Key key) throws UPAException {
        Document kr = getEntity().getBuilder().keyToDocument(key);
        getDocument().setAll(kr);
    }

    public Object getId() throws UPAException {
        return getEntity().getBuilder().documentToId(getDocument());
    }

    public Object[] getRawId() throws UPAException {
        return getKey().getValue();
    }

    @Override
    public void setObject(String key, Object value) {
        setUpdated(key);
        getDocument().setObject(key, value);
    }

    @Override
    public <T> T getSingleResult() {
        return getDocument().getSingleResult();
    }

    @Override
    public Set<String> keySet() {
        return getDocument().keySet();
    }

    @Override
    public int size() {
        return getDocument().size();
    }

    @Override
    public Map<String, Object> toMap() {
        return getDocument().toMap();
    }

    @Override
    public Set<Map.Entry<String, Object>> entrySet() {
        return getDocument().entrySet();
    }

    @Override
    public boolean isSet(String key) {
        return getDocument().isSet(key);
    }

    @Override
    public void remove(String key) {
        getDocument().remove(key);
    }

    @Override
    public void addPropertyChangeListener(String key, PropertyChangeListener listener) {
        getDocument().addPropertyChangeListener(key, listener);
    }

    @Override
    public void removePropertyChangeListener(String key, PropertyChangeListener listener) {
        getDocument().removePropertyChangeListener(key, listener);
    }

    @Override
    public void addPropertyChangeListener(PropertyChangeListener listener) {
        getDocument().addPropertyChangeListener(listener);
    }

    @Override
    public void removePropertyChangeListener(PropertyChangeListener listener) {
        getDocument().removePropertyChangeListener(listener);
    }

    @Override
    public <T> T getObject(String key) {
        return getDocument().getObject(key);
    }
}
