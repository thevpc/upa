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
     * @creationdate 9/20/12 9:54 PM
     */
    public class DefaultOnHoldCommitAction : Net.Vpc.Upa.Impl.OnHoldCommitAction {

        private Net.Vpc.Upa.UPAObject @object;

        private Net.Vpc.Upa.Impl.OnHoldCommitActionType type;

        private Net.Vpc.Upa.UPAObject old;

        private int order;

        private System.Collections.Generic.ISet<string> updates;

        public DefaultOnHoldCommitAction(Net.Vpc.Upa.UPAObject @object, Net.Vpc.Upa.Impl.OnHoldCommitActionType type, int order, Net.Vpc.Upa.UPAObject old, System.Collections.Generic.ISet<string> updates)  : this(@object, type, order){

            this.old = old;
            this.updates = updates;
        }

        public DefaultOnHoldCommitAction(Net.Vpc.Upa.UPAObject @object, Net.Vpc.Upa.Impl.OnHoldCommitActionType type, int order) {
            this.@object = @object;
            this.type = type;
            this.order = order;
        }


        public virtual int GetOrder() {
            return order;
        }


        public virtual void CommitModel() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            new Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter(@object).SetProperty("persistenceState", Net.Vpc.Upa.PersistenceState.TRANSIENT);
        }


        public virtual void CommitStorage(Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Persistence.PersistenceStore persistenceStore = context.GetPersistenceStore();
            //should verify if not yet stored
            switch(@object.GetPersistenceState()) {
                case Net.Vpc.Upa.PersistenceState.VALID:
                    {
                        //do nothing
                        break;
                    }
                case Net.Vpc.Upa.PersistenceState.TRANSIENT:
                    {
                        switch(type) {
                            case Net.Vpc.Upa.Impl.OnHoldCommitActionType.CREATE:
                                {
                                    persistenceStore.AlterPersistenceUnitAddObject(@object);
                                    break;
                                }
                            case Net.Vpc.Upa.Impl.OnHoldCommitActionType.REMOVE:
                                {
                                    persistenceStore.AlterPersistenceUnitRemoveObject(@object);
                                    break;
                                }
                            case Net.Vpc.Upa.Impl.OnHoldCommitActionType.UPDATE:
                                {
                                    persistenceStore.AlterPersistenceUnitUpdateObject(old, @object, updates);
                                    break;
                                }
                        }
                        new Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter(@object).SetProperty("persistenceState", Net.Vpc.Upa.PersistenceState.VALID);
                        break;
                    }
                default:
                    {
                        throw new Net.Vpc.Upa.Exceptions.UPAException(new Net.Vpc.Upa.Types.I18NString("Unexpected"));
                    }
            }
        }


        public override string ToString() {
            switch(type) {
                case Net.Vpc.Upa.Impl.OnHoldCommitActionType.CREATE:
                    {
                        return "Create(" + @object + ", order=" + order + ")";
                    }
            }
            return "CommitAction{" + "object=" + @object + ", type=" + type + ", old=" + old + ", order=" + order + ", updates=" + updates + '}';
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
    }
}
