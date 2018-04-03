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
     * Created with IntelliJ IDEA.
     * User: vpc
     * Date: 8/15/12
     * Time: 7:15 PM
     * To change this template use File | Settings | File Templates.
     */
    public class FieldPrimitiveFilter : Net.Vpc.Upa.Filters.AbstractFieldFilter {

        private Net.Vpc.Upa.Filters.FieldFilter @base;

        public FieldPrimitiveFilter(Net.Vpc.Upa.Filters.FieldFilter @base) {
            this.@base = @base;
        }


        public override bool AcceptDynamic() {
            return false;
        }


        public override bool Accept(Net.Vpc.Upa.Field f) {
            return (f is Net.Vpc.Upa.PrimitiveField) && (@base == null || @base.Accept(f));
        }


        public override Net.Vpc.Upa.PrimitiveField[] Filter(Net.Vpc.Upa.PrimitiveField[] fields) {
            if (fields == null || @base == null) {
                return fields;
            }
            return ToAbstractFieldFilter(@base).Filter(fields);
        }


        public override int GetHashCode() {
            int hash = 5;
            hash = 89 * hash + (this.@base != null ? this.@base.GetHashCode() : 0);
            return hash;
        }


        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (GetType() != obj.GetType()) {
                return false;
            }
            if (!base.Equals(obj)) {
                return false;
            }
            Net.Vpc.Upa.Filters.FieldPrimitiveFilter other = (Net.Vpc.Upa.Filters.FieldPrimitiveFilter) obj;
            if (this.@base != other.@base && (this.@base == null || !this.@base.Equals(other.@base))) {
                return false;
            }
            return true;
        }


        public override string ToString() {
            return "Primitive(" + (@base == null ? "" : @base.ToString()) + ")";
        }
    }
}
