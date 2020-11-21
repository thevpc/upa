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
    public class NavigatorIdentityPersister : Net.TheVpc.Upa.Persistence.FieldPersister {

        public virtual void BeforePersist(Net.TheVpc.Upa.Record record, Net.TheVpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            //K key = entity.getBuilder().recordToId(record);
            Net.TheVpc.Upa.Entity entity = context.GetEntity();
            object key = entity.NextId<K>();
            entity.GetBuilder().SetRecordId(record, key);
        }

        public virtual void AfterPersist(Net.TheVpc.Upa.Record record, Net.TheVpc.Upa.Persistence.EntityExecutionContext context) {
        }


        public override bool Equals(object o) {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            return true;
        }


        public override int GetHashCode() {
            return 31;
        }
    }
}
