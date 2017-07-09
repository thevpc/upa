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
    protected PropertyChangeSupport beforePropertyChangeSupport;
    protected PropertyChangeSupport afterPropertyChangeSupport;
    protected List<UPAObjectListener> objectListeners;

    protected AbstractUPAObject() {
        beforePropertyChangeSupport = new PropertyChangeSupport(this);
        afterPropertyChangeSupport = new PropertyChangeSupport(this);
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        checkValidIdentifier(name);
        String old = this.name;
        String recent = name;
        beforePropertyChangeSupport.firePropertyChange("name", old, recent);
        this.name = name;
        afterPropertyChangeSupport.firePropertyChange("name", old, recent);
    }

    public String getPersistenceName() {
        return persistenceName;
    }

    public void setPersistenceName(String persistenceName) {
        String old = this.persistenceName;
        String recent = persistenceName;
        beforePropertyChangeSupport.firePropertyChange("persistenceName", old, recent);
        this.persistenceName = persistenceName;
        afterPropertyChangeSupport.firePropertyChange("persistenceName", old, recent);
    }

    public I18NString getTitle() {
        return title;
    }

    public void setTitle(I18NString title) {
        I18NString old = this.title;
        I18NString recent = title;
        beforePropertyChangeSupport.firePropertyChange("title", old, recent);
        this.title = title;
        afterPropertyChangeSupport.firePropertyChange("title", old, recent);
    }

    public I18NString getDescription() {
        return description;
    }

    public void setDescription(I18NString description) {
        I18NString old = this.description;
        I18NString recent = description;
        beforePropertyChangeSupport.firePropertyChange("description", old, recent);
        this.description = description;
        afterPropertyChangeSupport.firePropertyChange("description", old, recent);
    }

    public I18NString getI18NString() {
        return i18NString;
    }

    public void setI18NString(I18NString i18NString) {
        I18NString old = this.i18NString;
        I18NString recent = i18NString;
        beforePropertyChangeSupport.firePropertyChange("i18NString", old, recent);
        this.i18NString = i18NString;
        afterPropertyChangeSupport.firePropertyChange("i18NString", old, recent);
    }

    public PersistenceUnit getPersistenceUnit() {
        return persistenceUnit;
    }

    public void setPersistenceUnit(PersistenceUnit persistenceUnit) {
        PersistenceUnit old = this.persistenceUnit;
        PersistenceUnit recent = persistenceUnit;
        beforePropertyChangeSupport.firePropertyChange("persistenceUnit", old, recent);
        this.persistenceUnit = persistenceUnit;
        afterPropertyChangeSupport.firePropertyChange("persistenceUnit", old, recent);
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
        persistenceState = PlatformUtils.isUndefinedValue(PersistenceState.class,persistenceState) ? PersistenceState.UNKNOWN : persistenceState;
        PersistenceState recent = persistenceState;

        beforePropertyChangeSupport.firePropertyChange("persistenceState", old, recent);
        this.persistenceState = persistenceState;
        afterPropertyChangeSupport.firePropertyChange("persistenceState", old, recent);
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

    public void addPropertyChangeListener(String property, EventPhase phase,PropertyChangeListener listener) {
        switch (phase){
            case DEFAULT:{
                beforePropertyChangeSupport.addPropertyChangeListener(property, listener);
                afterPropertyChangeSupport.addPropertyChangeListener(property, listener);
                break;
            }
            case BEFORE:{
                beforePropertyChangeSupport.addPropertyChangeListener(property, listener);
                break;
            }
            case AFTER:{
                afterPropertyChangeSupport.addPropertyChangeListener(property, listener);
                break;
            }
        }
    }

    public void removePropertyChangeListener(String property, EventPhase phase, PropertyChangeListener listener) {
        switch (phase){
            case DEFAULT:{
                beforePropertyChangeSupport.removePropertyChangeListener(property, listener);
                afterPropertyChangeSupport.removePropertyChangeListener(property, listener);
                break;
            }
            case BEFORE:{
                beforePropertyChangeSupport.removePropertyChangeListener(property, listener);
                break;
            }
            case AFTER:{
                afterPropertyChangeSupport.removePropertyChangeListener(property, listener);
                break;
            }
        }
    }

    public void addPropertyChangeListener(EventPhase phase,PropertyChangeListener listener) {
        switch (phase){
            case DEFAULT:{
                beforePropertyChangeSupport.addPropertyChangeListener(listener);
                afterPropertyChangeSupport.addPropertyChangeListener(listener);
                break;
            }
            case BEFORE:{
                beforePropertyChangeSupport.addPropertyChangeListener(listener);
                break;
            }
            case AFTER:{
                afterPropertyChangeSupport.addPropertyChangeListener(listener);
                break;
            }
        }
    }

    public void removePropertyChangeListener(EventPhase phase,PropertyChangeListener listener) {
        switch (phase){
            case DEFAULT:{
                beforePropertyChangeSupport.removePropertyChangeListener(listener);
                afterPropertyChangeSupport.removePropertyChangeListener(listener);
                break;
            }
            case BEFORE:{
                beforePropertyChangeSupport.removePropertyChangeListener(listener);
                break;
            }
            case AFTER:{
                afterPropertyChangeSupport.removePropertyChangeListener(listener);
                break;
            }
        }
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
