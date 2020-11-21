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
     * @creationdate 9/20/12 9:54 PM
     */
    public class DefaultOnHoldCommitAction : Net.TheVpc.Upa.Impl.OnHoldCommitAction {

        private Net.TheVpc.Upa.UPAObject @object;

        private Net.TheVpc.Upa.Impl.OnHoldCommitActionType type;

        private Net.TheVpc.Upa.UPAObject old;

        private int order;

        private System.Collections.Generic.ISet<string> updates;

        public DefaultOnHoldCommitAction(Net.TheVpc.Upa.UPAObject @object, Net.TheVpc.Upa.Impl.OnHoldCommitActionType type, int order, Net.TheVpc.Upa.UPAObject old, System.Collections.Generic.ISet<string> updates)  : this(@object, type, order){

            this.old = old;
            this.updates = updates;
        }

        public DefaultOnHoldCommitAction(Net.TheVpc.Upa.UPAObject @object, Net.TheVpc.Upa.Impl.OnHoldCommitActionType type, int order) {
            this.@object = @object;
            this.type = type;
            this.order = order;
        }


        public virtual int GetOrder() {
            return order;
        }


        public virtual void CommitModel() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            new Net.TheVpc.Upa.Impl.Util.DefaultBeanAdapter(@object).SetProperty("persistenceState", Net.TheVpc.Upa.PersistenceState.TRANSIENT);
        }


        public virtual void CommitStorage(Net.TheVpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Persistence.PersistenceStore persistenceStore = context.GetPersistenceStore();
            //should verify if not yet stored
            switch(@object.GetPersistenceState()) {
                case Net.TheVpc.Upa.PersistenceState.VALID:
                    {
                        //do nothing
                        break;
                    }
                case Net.TheVpc.Upa.PersistenceState.TRANSIENT:
                    {
                        switch(type) {
                            case Net.TheVpc.Upa.Impl.OnHoldCommitActionType.CREATE:
                                {
                                    persistenceStore.AlterPersistenceUnitAddObject(@object);
                                    break;
                                }
                            case Net.TheVpc.Upa.Impl.OnHoldCommitActionType.REMOVE:
                                {
                                    persistenceStore.AlterPersistenceUnitRemoveObject(@object);
                                    break;
                                }
                            case Net.TheVpc.Upa.Impl.OnHoldCommitActionType.UPDATE:
                                {
                                    persistenceStore.AlterPersistenceUnitUpdateObject(old, @object, updates);
                                    break;
                                }
                        }
                        new Net.TheVpc.Upa.Impl.Util.DefaultBeanAdapter(@object).SetProperty("persistenceState", Net.TheVpc.Upa.PersistenceState.VALID);
                        break;
                    }
                default:
                    {
                        throw new Net.TheVpc.Upa.Exceptions.UPAException(new Net.TheVpc.Upa.Types.I18NString("Unexpected"));
                    }
            }
        }


        public override string ToString() {
            switch(type) {
                case Net.TheVpc.Upa.Impl.OnHoldCommitActionType.CREATE:
                    {
                        return "Create(" + @object + ", order=" + order + ")";
                    }
            }
            return "CommitAction{" + "object=" + @object + ", type=" + type + ", old=" + old + ", order=" + order + ", updates=" + updates + '}';
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
    }
}
