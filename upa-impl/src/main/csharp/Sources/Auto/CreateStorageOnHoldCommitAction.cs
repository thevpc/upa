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



namespace Net.Vpc.Upa.Impl
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    internal class CreateStorageOnHoldCommitAction : Net.Vpc.Upa.Impl.OnHoldCommitAction {

        public CreateStorageOnHoldCommitAction() {
        }


        public virtual void CommitModel() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
        }


        public virtual void CommitStorage(Net.Vpc.Upa.Persistence.PersistenceStore persistenceStore) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Persistence.StructureStrategy option = persistenceStore.GetConnectionProfile().GetStructureStrategy();
            switch(option) {
                case Net.Vpc.Upa.Persistence.StructureStrategy.DROP:
                    {
                        if (!persistenceStore.IsCreatedStorage()) {
                            persistenceStore.CreateStorage();
                        } else {
                            persistenceStore.DropStorage();
                            persistenceStore.DropStorage();
                            persistenceStore.CreateStorage();
                        }
                        break;
                    }
                case Net.Vpc.Upa.Persistence.StructureStrategy.CREATE:
                case Net.Vpc.Upa.Persistence.StructureStrategy.SYNCHRONIZE:
                    {
                        if (!persistenceStore.IsCreatedStorage()) {
                            persistenceStore.CreateStorage();
                        }
                        break;
                    }
                case Net.Vpc.Upa.Persistence.StructureStrategy.MANDATORY:
                    {
                        if (!persistenceStore.IsCreatedStorage()) {
                            throw new Net.Vpc.Upa.Exceptions.NoSuchPersistenceUnitException(persistenceStore.GetPersistenceUnit().GetName());
                        }
                        //                        if (!isValidPersistenceUnit()) {
                        //                            throw new NoSuchPersistenceUnitException(getName(), null);
                        //                        }
                        break;
                    }
                case Net.Vpc.Upa.Persistence.StructureStrategy.IGNORE:
                    {
                        //do nothing
                        break;
                    }
            }
        }


        public virtual int GetOrder() {
            return 0;
        }


        public virtual int CompareTo(Net.Vpc.Upa.Impl.OnHoldCommitAction o) {
            int i1 = GetOrder();
            int i2 = o.GetOrder();
            int i = i1 - i2;
            if (i != 0) {
                return i;
            }
            if (this == o) {
                return 0;
            }
            return i;
        }


        public override string ToString() {
            return "CreateStorage(order=" + GetOrder() + ")";
        }
    }
}
