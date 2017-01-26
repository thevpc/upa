package net.vpc.upa.impl;

import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.types.I18NString;
import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;

import java.beans.PropertyChangeListener;
import java.beans.PropertyChangeSupport;
import java.util.ArrayList;
import java.util.List;
import net.vpc.upa.expressions.ExpressionHelper;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/25/12 12:01 AM
 */
public abstract class AbstractUPAObject implements UPAObject {

    private String name;
    private String persistenceName;
    private I18NString title;
    private I18NString description;
    private I18NString i18NString;
    private PersistenceUnit persistenceUnit;
    private final Properties parameters = new DefaultProperties();
    private PersistenceState persistenceState = PersistenceState.UNKNOWN;
    protected PropertyChangeSupport propertyChangeSupport;
    protected List<UPAObjectListener> objectListeners;

    protected AbstractUPAObject() {
        propertyChangeSupport = new PropertyChangeSupport(this);
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        checkValidIdentifier(name);
        String old = this.name;
        this.name = name;
        propertyChangeSupport.firePropertyChange("name", old, name);
    }

    public String getPersistenceName() {
        return persistenceName;
    }

    public void setPersistenceName(String persistenceName) {
        String old = this.persistenceName;
        this.persistenceName = persistenceName;
        propertyChangeSupport.firePropertyChange("persistenceName", old, persistenceName);
    }

    public I18NString getTitle() {
        return title;
    }

    public void setTitle(I18NString title) {
        I18NString old = this.title;
        this.title = title;
        propertyChangeSupport.firePropertyChange("title", old, title);
    }

    public I18NString getDescription() {
        return description;
    }

    public void setDescription(I18NString description) {
        I18NString old = this.description;
        this.description = description;
        propertyChangeSupport.firePropertyChange("description", old, description);
    }

    public I18NString getI18NString() {
        return i18NString;
    }

    public void setI18NString(I18NString i18NString) {
        I18NString old = this.i18NString;
        this.i18NString = i18NString;
        propertyChangeSupport.firePropertyChange("i18NString", old, i18NString);
    }

    public PersistenceUnit getPersistenceUnit() {
        return persistenceUnit;
    }

    public void setPersistenceUnit(PersistenceUnit persistenceUnit) {
        PersistenceUnit old = this.persistenceUnit;
        this.persistenceUnit = persistenceUnit;
        propertyChangeSupport.firePropertyChange("persistenceUnit", old, persistenceUnit);
    }

    @Override
    public PersistenceGroup getPersistenceGroup() {
        return persistenceUnit==null?null:persistenceUnit.getPersistenceGroup();
    }

    //--------------------------- PROPERTIES SUPPORT
    public Properties getProperties() {
        return parameters;
    }

//    @Override
    public void setPersistenceState(PersistenceState persistenceState) {
        PersistenceState old = this.persistenceState;
        this.persistenceState = PlatformUtils.isUndefinedValue(PersistenceState.class,persistenceState) ? PersistenceState.UNKNOWN : persistenceState;
        propertyChangeSupport.firePropertyChange("persistenceState", old, this.persistenceState);
    }

    @Override
    public PersistenceState getPersistenceState() {
        return persistenceState;
    }

    @Override
    public int hashCode() {
        String n = getAbsoluteName();
        int result = n != null ? n.hashCode() : 0;
        result = 31 * result + getClass().hashCode();
        return result;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) {
            return true;
        }
        if (o == null || getClass() != o.getClass()) {
            return false;
        }

        AbstractUPAObject that = (AbstractUPAObject) o;

        String thatAbsoluteName = that.getAbsoluteName();
        String absoluteName = getAbsoluteName();
        if (absoluteName != null ? !absoluteName.equals(thatAbsoluteName) : thatAbsoluteName != null) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return getClass().getSimpleName() + " " + getAbsoluteName();
    }

    public void addObjectListener(UPAObjectListener listener) {
        if (listener != null) {
            if (objectListeners == null) {
                objectListeners = new ArrayList<UPAObjectListener>(2);
            }
            objectListeners.add(listener);
        }
    }

    public void removeObjectListener(UPAObjectListener listener) {
        if (listener != null) {
            if (objectListeners != null) {
                objectListeners.remove(listener);
            }
        }
    }

    public UPAObjectListener[] getObjectListeners() {
        return objectListeners==null?new UPAObjectListener[0]:objectListeners.toArray(new UPAObjectListener[objectListeners.size()]);
    }

    public void addPropertyChangeListener(String property, PropertyChangeListener listener) {
        propertyChangeSupport.addPropertyChangeListener(property, listener);
    }

    public void removePropertyChangeListener(String property, PropertyChangeListener listener) {
        propertyChangeSupport.removePropertyChangeListener(property, listener);
    }

    public void addPropertyChangeListener(PropertyChangeListener listener) {
        propertyChangeSupport.addPropertyChangeListener(listener);
    }

    public void removePropertyChangeListener(PropertyChangeListener listener) {
        propertyChangeSupport.removePropertyChangeListener(listener);
    }

    @Override
    public void close() throws UPAException {
    }

    public void checkValidIdentifier(String s) {
        // an empty or null string cannot be a valid identifier
        if (s == null || s.length() == 0) {
            throw new IllegalArgumentException("Empty name");
        }
        if (!s.trim().equals(s)) {
            throw new IllegalArgumentException(s);
        }

        char[] c = s.toCharArray();
        if (!ExpressionHelper.isIdentifierStart(c[0])) {
            throw new IllegalArgumentException("Invalid name start " + s);
        }

        for (int i = 1; i < c.length; i++) {
            if (!ExpressionHelper.isIdentifierPart(c[i])) {
                throw new IllegalArgumentException("Invalid name char '" + c[i] + "' in name " + s);
            }
        }
    }
}
