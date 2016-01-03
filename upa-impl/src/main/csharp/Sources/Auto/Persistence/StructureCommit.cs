/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE AS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.Vpc.Upa.Impl.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 1/8/13 1:53 AM
     */
    public abstract class StructureCommit {

        protected internal Net.Vpc.Upa.UPAObject @object;

        protected internal Net.Vpc.Upa.Impl.Persistence.ObjectAndType typedObject;

        private Net.Vpc.Upa.Impl.Persistence.DefaultPersistenceUnitCommitManager persistenceUnitCommitManager;

        public StructureCommit(Net.Vpc.Upa.Impl.Persistence.DefaultPersistenceUnitCommitManager defaultPersistenceUnitCommitManager, Net.Vpc.Upa.UPAObject @object, System.Type cls, Net.Vpc.Upa.Persistence.PersistenceNameType spec) {
            this.persistenceUnitCommitManager = defaultPersistenceUnitCommitManager;
            this.@object = @object;
            this.typedObject = new Net.Vpc.Upa.Impl.Persistence.ObjectAndType(cls, spec);
        }

        protected internal virtual Net.Vpc.Upa.PersistenceState GetObjectStatus() {
            return persistenceUnitCommitManager.persistenceStore.GetPersistenceState(@object, typedObject.GetSpec());
        }

        public virtual bool Commit(Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Persistence.StructureStrategy option = persistenceUnitCommitManager.persistenceStore.GetConnectionProfile().GetStructureStrategy();
            Net.Vpc.Upa.PersistenceState status = GetObjectStatus();
            switch(option) {
                case Net.Vpc.Upa.Persistence.StructureStrategy.DROP:
                case Net.Vpc.Upa.Persistence.StructureStrategy.CREATE:
                case Net.Vpc.Upa.Persistence.StructureStrategy.SYNCHRONIZE:
                    {
                        switch(status) {
                            case Net.Vpc.Upa.PersistenceState.VALID:
                                {
                                    //do nothing
                                    break;
                                }
                            case Net.Vpc.Upa.PersistenceState.UNKNOWN:
                            case Net.Vpc.Upa.PersistenceState.DIRTY:
                                {
                                    //throw new UPAException(new I18NString("DirtyObject"),object);
                                    try {
                                        Persist(executionContext, status);
                                    } catch (System.Exception e) {
                                        Net.Vpc.Upa.PersistenceState s2 = GetObjectStatus();
                                        try {
                                            Persist(executionContext, status);
                                        } catch (System.Exception e2) {
                                        }
                                        //
                                        throw new Net.Vpc.Upa.Exceptions.UPAException(e, new Net.Vpc.Upa.Types.I18NString("CommitFailed"));
                                    }
                                    @object.GetProperties().SetString("persistence.PersistenceAction", "ADD");
                                    //info.setPersistenceState(PersistenceState.VALID);
                                    return true;
                                }
                            case Net.Vpc.Upa.PersistenceState.TRANSIENT:
                                {
                                    // do nothing
                                    break;
                                }
                        }
                        break;
                    }
                case Net.Vpc.Upa.Persistence.StructureStrategy.MANDATORY:
                    {
                        switch(status) {
                            case Net.Vpc.Upa.PersistenceState.UNKNOWN:
                                {
                                    throw new Net.Vpc.Upa.Exceptions.UPAException(new Net.Vpc.Upa.Types.I18NString("MandatoryObject"), @object);
                                }
                            case Net.Vpc.Upa.PersistenceState.VALID:
                                {
                                    //do nothing
                                    break;
                                }
                            case Net.Vpc.Upa.PersistenceState.DIRTY:
                                {
                                    throw new Net.Vpc.Upa.Exceptions.UPAException(new Net.Vpc.Upa.Types.I18NString("DirtyObject"), @object);
                                }
                            case Net.Vpc.Upa.PersistenceState.TRANSIENT:
                                {
                                    // do nothing
                                    break;
                                }
                        }
                        break;
                    }
                case Net.Vpc.Upa.Persistence.StructureStrategy.IGNORE:
                    {
                        //do nothing
                        break;
                    }
            }
            return false;
        }

        public virtual Net.Vpc.Upa.UPAObject GetObject() {
            return @object;
        }

        public virtual Net.Vpc.Upa.Impl.Persistence.ObjectAndType GetTypedObject() {
            return typedObject;
        }

        public virtual Net.Vpc.Upa.Impl.Persistence.DefaultPersistenceUnitCommitManager GetPersistenceUnitCommitManager() {
            return persistenceUnitCommitManager;
        }

        public abstract void Persist(Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext, Net.Vpc.Upa.PersistenceState status) /* throws System.Exception */ ;


        public override string ToString() {
            return (GetType()).Name + "[" + @object + ", " + typedObject + ']';
        }
    }
}
