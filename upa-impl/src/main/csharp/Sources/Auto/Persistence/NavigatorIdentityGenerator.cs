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
    public class NavigatorIdentityGenerator : Net.Vpc.Upa.Persistence.FieldPersister {

        public virtual void BeforePersist(Net.Vpc.Upa.Record record, Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            //K key = entity.getBuilder().recordToId(record);
            Net.Vpc.Upa.Entity entity = context.GetEntity();
            object key = entity.NextId<object>();
            entity.GetBuilder().SetRecordId(record, key);
        }

        public virtual void AfterPersist(Net.Vpc.Upa.Record record, Net.Vpc.Upa.Persistence.EntityExecutionContext context) {
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
