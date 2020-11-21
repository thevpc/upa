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
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class DatabaseIdentityPersister : Net.TheVpc.Upa.Persistence.FieldPersister {

        private Net.TheVpc.Upa.Field field;

        internal string identityConstraintsEnabledProperty;

        public DatabaseIdentityPersister(Net.TheVpc.Upa.Field field) {
            this.field = field;
            identityConstraintsEnabledProperty = "IdentityConstraintsEnabled." + field.GetEntity().GetName();
        }

        public virtual void BeforePersist(Net.TheVpc.Upa.Record record, Net.TheVpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (new System.Nullable<bool>(false).Equals(context.GetConnection().GetProperty(identityConstraintsEnabledProperty))) {
                return;
            }
            context.AddGeneratedValue(field.GetName(), field.GetDataType());
            //manual id values are ignored
            record.Remove(field.GetName());
        }

        public virtual void AfterPersist(Net.TheVpc.Upa.Record record, Net.TheVpc.Upa.Persistence.EntityExecutionContext context) {
            if (new System.Nullable<bool>(false).Equals(context.GetConnection().GetProperty(identityConstraintsEnabledProperty))) {
                return;
            }
            record.SetObject(field.GetName(), context.GetGeneratedValue(field.GetName()).GetValue());
        }


        public override bool Equals(object o) {
            if (this == o) {
                return true;
            }
            if (o == null || GetType() != o.GetType()) {
                return false;
            }
            Net.TheVpc.Upa.Impl.Persistence.DatabaseIdentityPersister that = (Net.TheVpc.Upa.Impl.Persistence.DatabaseIdentityPersister) o;
            if (!field.Equals(that.field)) {
                return false;
            }
            return true;
        }


        public override int GetHashCode() {
            return field.GetHashCode();
        }
    }
}
