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
    public class TableSequenceIdentityGeneratorInt : Net.Vpc.Upa.Impl.Persistence.TableSequenceIdentityGenerator {

        public TableSequenceIdentityGeneratorInt(Net.Vpc.Upa.Field field, Net.Vpc.Upa.Sequence generatedId)  : base(field, generatedId){

        }


        protected internal override object GetNewValue(Net.Vpc.Upa.Impl.SequenceManager sm, string group, Net.Vpc.Upa.Record record) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return sm.NextValue(GetName(), group, GetInitialValue(), GetAllocationSize());
        }


        public override bool Equals(object o) {
            return base.Equals(o) && o is Net.Vpc.Upa.Impl.Persistence.TableSequenceIdentityGeneratorInt;
        }


        public override int GetHashCode() {
            int hash = 5;
            return hash;
        }
    }
}
