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
    public class TableSequenceIdentityPersisterString : Net.Vpc.Upa.Impl.Persistence.TableSequenceIdentityPersister {

        public TableSequenceIdentityPersisterString(Net.Vpc.Upa.Field field, Net.Vpc.Upa.Sequence generatedId)  : base(field, generatedId){

        }

        protected internal override object GetNewValue(Net.Vpc.Upa.Impl.SequenceManager sm, string group, Net.Vpc.Upa.Record record) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
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
