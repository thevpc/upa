package net.vpc.upa.impl.persistence;

import java.util.Objects;
import net.vpc.upa.PersistenceState;
import net.vpc.upa.config.PersistenceNameType;
import net.vpc.upa.types.I18NString;
import net.vpc.upa.UPAObject;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.persistence.StructureStrategy;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/8/13 1:53 AM
 */
public abstract class StructureCommitAction {

    protected final UPAObject object;
    protected final PersistenceNameType persistenceNameType;
    private final DefaultPersistenceUnitCommitManager persistenceUnitCommitManager;

    public StructureCommitAction(DefaultPersistenceUnitCommitManager defaultPersistenceUnitCommitManager, UPAObject object, PersistenceNameType spec) {
        this.persistenceUnitCommitManager = defaultPersistenceUnitCommitManager;
        this.object = object;
        this.persistenceNameType = spec;
    }

    protected PersistenceState getObjectStatus(net.vpc.upa.persistence.EntityExecutionContext entityExecutionContext) {
        return persistenceUnitCommitManager.getPersistenceStore().getPersistenceState(object, persistenceNameType, entityExecutionContext);
    }

    public boolean commit(EntityExecutionContext executionContext) throws UPAException {
        StructureStrategy option = persistenceUnitCommitManager.getPersistenceStore().getConnectionProfile().getStructureStrategy();
        PersistenceState status = getObjectStatus(executionContext);
        switch (option) {
            case DROP:
            case CREATE:
            case SYNCHRONIZE: {
                switch (status) {
                    case VALID: {
                        //do nothing
                        break;
                    }
                    case DEFAULT:
                    case MISSING:
                    case DIRTY: {
                        //throw new UPAException(new I18NString("DirtyObject"),object);
                        try {
                            persist(executionContext, status);
                        } catch (Exception e) {
                            throw new UPAException(e, new I18NString("CommitFailed"),object);
                        }
                        object.getProperties().setString("persistence.PersistenceAction", "ADD");
                        //info.setPersistenceState(PersistenceState.VALID);
                        return true;

                    }
                    case TRANSIENT: {
                        // do nothing
                        break;
                    }
                }
                break;
            }
            case MANDATORY: {
                switch (status) {
                    case DEFAULT: 
                    case MISSING: 
                    {
                        throw new UPAException(new I18NString("MandatoryObject"), object);
                    }
                    case VALID: {
                        //do nothing
                        break;
                    }
                    case DIRTY: {
                        throw new UPAException(new I18NString("DirtyObject"), object);
                    }
                    case TRANSIENT: {
                        // do nothing
                        break;
                    }
                }
                break;
            }
            case IGNORE: {
                //do nothing
                break;
            }
        }
        return false;
    }

    public UPAObject getObject() {
        return object;
    }

    public PersistenceNameType getPersistenceNameType() {
        return persistenceNameType;
    }

    public DefaultPersistenceUnitCommitManager getPersistenceUnitCommitManager() {
        return persistenceUnitCommitManager;
    }

    public abstract void persist(EntityExecutionContext executionContext, PersistenceState status) throws Exception;

    @Override
    public String toString() {
        return getClass().getSimpleName()+"[" + object + ", " + persistenceNameType + ']';
    }

    @Override
    public int hashCode() {
        int hash = 7;
        hash = 79 * hash + Objects.hashCode(this.object);
        hash = 79 * hash + Objects.hashCode(this.persistenceNameType);
        hash = 79 * hash + Objects.hashCode(this.persistenceUnitCommitManager);
        return hash;
    }

    @Override
    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (obj == null) {
            return false;
        }
        if (getClass() != obj.getClass()) {
            return false;
        }
        final StructureCommitAction other = (StructureCommitAction) obj;
        if (!Objects.equals(this.object, other.object)) {
            return false;
        }
        if (!Objects.equals(this.persistenceNameType, other.persistenceNameType)) {
            return false;
        }
        if (!Objects.equals(this.persistenceUnitCommitManager, other.persistenceUnitCommitManager)) {
            return false;
        }
        return true;
    }
    
    
}
