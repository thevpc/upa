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
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class NativeIdentityGenerator : Net.Vpc.Upa.Persistence.FieldPersister {

        private Net.Vpc.Upa.Field field;

        public NativeIdentityGenerator(Net.Vpc.Upa.Field field) {
            this.field = field;
        }

        public virtual void BeforePersist(Net.Vpc.Upa.Record record, Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            context.AddGeneratedValue(field.GetName(), field.GetDataType());
            //manual id values are ignored
            record.Remove(field.GetName());
        }

        public virtual void AfterPersist(Net.Vpc.Upa.Record record, Net.Vpc.Upa.Persistence.EntityExecutionContext context) {
            record.SetObject(field.GetName(), context.GetGeneratedValue(field.GetName()).GetValue());
        }


        public override bool Equals(object o) {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            Net.Vpc.Upa.Impl.Persistence.NativeIdentityGenerator that = (Net.Vpc.Upa.Impl.Persistence.NativeIdentityGenerator) o;
            if (!field.Equals(that.field)) return false;
            return true;
        }


        public override int GetHashCode() {
            return field.GetHashCode();
        }
    }
}
