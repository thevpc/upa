/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.TheVpc.Upa.Filters
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/25/12 11:56 AM
     */
    public class FieldFilterAdapter : Net.TheVpc.Upa.Filters.AbstractFieldFilter {

        private Net.TheVpc.Upa.Filters.FieldFilter @base;

        public FieldFilterAdapter(Net.TheVpc.Upa.Filters.FieldFilter @base) {
            this.@base = @base;
        }


        public override bool AcceptDynamic() {
            return @base.AcceptDynamic();
        }


        public override bool Accept(Net.TheVpc.Upa.Field f) {
            return @base.Accept(f);
        }
    }
}
