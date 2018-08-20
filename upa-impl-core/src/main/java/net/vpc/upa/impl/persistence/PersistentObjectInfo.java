package net.vpc.upa.impl.persistence;

import net.vpc.upa.PersistenceState;
import net.vpc.upa.UPAObject;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/8/13 1:54 AM
 */
public class PersistentObjectInfo {

    private final UPAObject object;
    private final String objectType;
    private PersistenceState persistenceState = PersistenceState.DEFAULT;
    private String persistentName;

    PersistentObjectInfo(UPAObject object, String type) {
        this.object = object;
        this.objectType = type;
    }

    public UPAObject getObject() {
        return object;
    }

    public String getObjectType() {
        return objectType;
    }

    public PersistenceState getPersistenceState() {
        return persistenceState;
    }

    public void setPersistenceState(PersistenceState persistenceState) {
        this.persistenceState = persistenceState;
    }

    public String getPersistentName() {
        return persistentName;
    }

    public void setPersistentName(String persistentName) {
        this.persistentName = persistentName;
    }
}
