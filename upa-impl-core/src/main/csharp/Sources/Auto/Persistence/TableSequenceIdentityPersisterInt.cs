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
    public class TableSequenceIdentityPersisterInt : Net.TheVpc.Upa.Impl.Persistence.TableSequenceIdentityPersister {

        public TableSequenceIdentityPersisterInt(Net.TheVpc.Upa.Field field, Net.TheVpc.Upa.Sequence generatedId)  : base(field, generatedId){

        }


        protected internal override object GetNewValue(Net.TheVpc.Upa.Impl.SequenceManager sm, string group, Net.TheVpc.Upa.Record record) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return sm.NextValue(GetName(), group, GetInitialValue(), GetAllocationSize());
        }


        public override bool Equals(object o) {
            return base.Equals(o) && o is Net.TheVpc.Upa.Impl.Persistence.TableSequenceIdentityPersisterInt;
        }


        public override int GetHashCode() {
            int hash = 5;
            return hash;
        }
    }
}
