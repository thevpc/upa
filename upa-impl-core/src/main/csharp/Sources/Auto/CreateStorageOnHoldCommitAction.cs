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



namespace Net.TheVpc.Upa.Impl
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    internal class CreateStorageOnHoldCommitAction : Net.TheVpc.Upa.Impl.OnHoldCommitAction {

        public CreateStorageOnHoldCommitAction() {
        }


        public virtual void CommitModel() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
        }


        public virtual void CommitStorage(Net.TheVpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Persistence.PersistenceStore persistenceStore = context.GetPersistenceStore();
            Net.TheVpc.Upa.Persistence.StructureStrategy option = persistenceStore.GetConnectionProfile().GetStructureStrategy();
            switch(option) {
                case Net.TheVpc.Upa.Persistence.StructureStrategy.DROP:
                    {
                        if (!persistenceStore.IsCreatedStorage()) {
                            persistenceStore.CreateStorage(context);
                        } else {
                            persistenceStore.DropStorage(context);
                            persistenceStore.DropStorage(context);
                            persistenceStore.CreateStorage(context);
                        }
                        break;
                    }
                case Net.TheVpc.Upa.Persistence.StructureStrategy.CREATE:
                case Net.TheVpc.Upa.Persistence.StructureStrategy.SYNCHRONIZE:
                    {
                        if (!persistenceStore.IsCreatedStorage()) {
                            persistenceStore.CreateStorage(context);
                        }
                        break;
                    }
                case Net.TheVpc.Upa.Persistence.StructureStrategy.MANDATORY:
                    {
                        if (!persistenceStore.IsCreatedStorage()) {
                            throw new Net.TheVpc.Upa.Exceptions.NoSuchPersistenceUnitException(context.GetPersistenceUnit().GetName());
                        }
                        //                        if (!isValidPersistenceUnit()) {
                        //                            throw new NoSuchPersistenceUnitException(getName(), null);
                        //                        }
                        break;
                    }
                case Net.TheVpc.Upa.Persistence.StructureStrategy.IGNORE:
                    {
                        //do nothing
                        break;
                    }
            }
        }


        public virtual int GetOrder() {
            return 0;
        }


        public virtual int CompareTo(Net.TheVpc.Upa.Impl.OnHoldCommitAction o) {
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
