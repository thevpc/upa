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



namespace Net.TheVpc.Upa.Impl.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 1/8/13 1:53 AM
     */
    public abstract class StructureCommit {

        protected internal Net.TheVpc.Upa.UPAObject @object;

        protected internal Net.TheVpc.Upa.Impl.Persistence.ObjectAndType typedObject;

        private Net.TheVpc.Upa.Impl.Persistence.DefaultPersistenceUnitCommitManager persistenceUnitCommitManager;

        public StructureCommit(Net.TheVpc.Upa.Impl.Persistence.DefaultPersistenceUnitCommitManager defaultPersistenceUnitCommitManager, Net.TheVpc.Upa.UPAObject @object, System.Type cls, Net.TheVpc.Upa.Persistence.PersistenceNameType spec) {
            this.persistenceUnitCommitManager = defaultPersistenceUnitCommitManager;
            this.@object = @object;
            this.typedObject = new Net.TheVpc.Upa.Impl.Persistence.ObjectAndType(cls, spec);
        }

        protected internal virtual Net.TheVpc.Upa.PersistenceState GetObjectStatus(Net.TheVpc.Upa.Persistence.EntityExecutionContext entityExecutionContext) {
            return persistenceUnitCommitManager.persistenceStore.GetPersistenceState(@object, typedObject.GetSpec(), entityExecutionContext);
        }

        public virtual bool Commit(Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Persistence.StructureStrategy option = persistenceUnitCommitManager.persistenceStore.GetConnectionProfile().GetStructureStrategy();
            Net.TheVpc.Upa.PersistenceState status = GetObjectStatus(executionContext);
            switch(option) {
                case Net.TheVpc.Upa.Persistence.StructureStrategy.DROP:
                case Net.TheVpc.Upa.Persistence.StructureStrategy.CREATE:
                case Net.TheVpc.Upa.Persistence.StructureStrategy.SYNCHRONIZE:
                    {
                        switch(status) {
                            case Net.TheVpc.Upa.PersistenceState.VALID:
                                {
                                    //do nothing
                                    break;
                                }
                            case Net.TheVpc.Upa.PersistenceState.UNKNOWN:
                            case Net.TheVpc.Upa.PersistenceState.DIRTY:
                                {
                                    //throw new UPAException(new I18NString("DirtyObject"),object);
                                    try {
                                        Persist(executionContext, status);
                                    } catch (System.Exception e) {
                                        throw new Net.TheVpc.Upa.Exceptions.UPAException(e, new Net.TheVpc.Upa.Types.I18NString("CommitFailed"));
                                    }
                                    @object.GetProperties().SetString("persistence.PersistenceAction", "ADD");
                                    //info.setPersistenceState(PersistenceState.VALID);
                                    return true;
                                }
                            case Net.TheVpc.Upa.PersistenceState.TRANSIENT:
                                {
                                    // do nothing
                                    break;
                                }
                        }
                        break;
                    }
                case Net.TheVpc.Upa.Persistence.StructureStrategy.MANDATORY:
                    {
                        switch(status) {
                            case Net.TheVpc.Upa.PersistenceState.UNKNOWN:
                                {
                                    throw new Net.TheVpc.Upa.Exceptions.UPAException(new Net.TheVpc.Upa.Types.I18NString("MandatoryObject"), @object);
                                }
                            case Net.TheVpc.Upa.PersistenceState.VALID:
                                {
                                    //do nothing
                                    break;
                                }
                            case Net.TheVpc.Upa.PersistenceState.DIRTY:
                                {
                                    throw new Net.TheVpc.Upa.Exceptions.UPAException(new Net.TheVpc.Upa.Types.I18NString("DirtyObject"), @object);
                                }
                            case Net.TheVpc.Upa.PersistenceState.TRANSIENT:
                                {
                                    // do nothing
                                    break;
                                }
                        }
                        break;
                    }
                case Net.TheVpc.Upa.Persistence.StructureStrategy.IGNORE:
                    {
                        //do nothing
                        break;
                    }
            }
            return false;
        }

        public virtual Net.TheVpc.Upa.UPAObject GetObject() {
            return @object;
        }

        public virtual Net.TheVpc.Upa.Impl.Persistence.ObjectAndType GetTypedObject() {
            return typedObject;
        }

        public virtual Net.TheVpc.Upa.Impl.Persistence.DefaultPersistenceUnitCommitManager GetPersistenceUnitCommitManager() {
            return persistenceUnitCommitManager;
        }

        public abstract void Persist(Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext, Net.TheVpc.Upa.PersistenceState status) /* throws System.Exception */ ;


        public override string ToString() {
            return (GetType()).Name + "[" + @object + ", " + typedObject + ']';
        }
    }
}
