package net.vpc.upa.impl.persistence;

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
public abstract class StructureCommit {

    protected UPAObject object;
    protected ObjectAndType typedObject;
    private DefaultPersistenceUnitCommitManager persistenceUnitCommitManager;

    public StructureCommit(DefaultPersistenceUnitCommitManager defaultPersistenceUnitCommitManager, UPAObject object, Class cls, PersistenceNameType spec) {
        this.persistenceUnitCommitManager = defaultPersistenceUnitCommitManager;
        this.object = object;
        this.typedObject = new ObjectAndType(cls, spec);
    }

    protected PersistenceState getObjectStatus(net.vpc.upa.persistence.EntityExecutionContext entityExecutionContext) {
        return persistenceUnitCommitManager.persistenceStore.getPersistenceState(object, typedObject.getSpec(), entityExecutionContext);
    }

    public boolean commit(EntityExecutionContext executionContext) throws UPAException {
        StructureStrategy option = persistenceUnitCommitManager.persistenceStore.getConnectionProfile().getStructureStrategy();
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
                    case DEFAULT: {
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

    public ObjectAndType getTypedObject() {
        return typedObject;
    }

    public DefaultPersistenceUnitCommitManager getPersistenceUnitCommitManager() {
        return persistenceUnitCommitManager;
    }

    public abstract void persist(EntityExecutionContext executionContext, PersistenceState status) throws Exception;

    @Override
    public String toString() {
        return getClass().getSimpleName()+"[" + object + ", " + typedObject + ']';
    }
    
}
