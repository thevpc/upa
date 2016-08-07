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



namespace Net.Vpc.Upa.Filters
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/25/12 11:56 AM
     */
    public class FieldFilterAdapter : Net.Vpc.Upa.Filters.AbstractFieldFilter {

        private Net.Vpc.Upa.Filters.FieldFilter @base;

        public FieldFilterAdapter(Net.Vpc.Upa.Filters.FieldFilter @base) {
            this.@base = @base;
        }


        public override bool AcceptDynamic() {
            return @base.AcceptDynamic();
        }


        public override bool Accept(Net.Vpc.Upa.Field f) {
            return @base.Accept(f);
        }
    }
}
