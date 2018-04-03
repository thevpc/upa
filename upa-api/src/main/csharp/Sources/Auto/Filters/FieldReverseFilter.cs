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



namespace Net.Vpc.Upa.Filters
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class FieldReverseFilter : Net.Vpc.Upa.Filters.AbstractFieldFilter {

        private Net.Vpc.Upa.Filters.FieldFilter @base;

        public FieldReverseFilter(Net.Vpc.Upa.Filters.FieldFilter @base) {
            this.@base = @base;
        }

        public override bool Accept(Net.Vpc.Upa.Field field) {
            return !@base.Accept(field);
        }


        public override bool AcceptDynamic() {
            return @base.AcceptDynamic();
        }


        public override string ToString() {
            return "not (" + @base + ")";
        }
    }
}
