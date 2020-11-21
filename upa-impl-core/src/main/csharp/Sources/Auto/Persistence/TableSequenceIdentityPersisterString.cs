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
    public class TableSequenceIdentityPersisterString : Net.TheVpc.Upa.Impl.Persistence.TableSequenceIdentityPersister {

        public TableSequenceIdentityPersisterString(Net.TheVpc.Upa.Field field, Net.TheVpc.Upa.Sequence generatedId)  : base(field, generatedId){

        }

        protected internal override object GetNewValue(Net.TheVpc.Upa.Impl.SequenceManager sm, string group, Net.TheVpc.Upa.Record record) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return Eval(GetFormat(), sm.NextValue(GetName(), group, GetInitialValue(), GetAllocationSize()), record);
        }


        public override bool Equals(object o) {
            return base.Equals(o) && o.GetType().Equals(GetType());
        }


        public override int GetHashCode() {
            int hash = 3;
            return hash;
        }
    }
}
