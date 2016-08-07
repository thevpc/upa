package net.vpc.upa.impl.persistence;

import net.vpc.upa.PersistenceState;
import net.vpc.upa.UPAObject;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/8/13 1:54 AM
*/
public class PersistentObjectInfo {
    private UPAObject object;
    private String type;
    private PersistenceState persistenceState = PersistenceState.UNKNOWN;
    private String persistentName;

    PersistentObjectInfo(UPAObject object, String type) {
        this.object = object;
        this.type = type;
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
