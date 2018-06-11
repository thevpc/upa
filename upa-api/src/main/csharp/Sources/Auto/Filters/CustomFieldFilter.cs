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
    public class CustomFieldFilter : Net.Vpc.Upa.Filters.AbstractFieldFilter {

        private Net.Vpc.Upa.Filters.FieldFilter @base;

        internal CustomFieldFilter(Net.Vpc.Upa.Filters.FieldFilter @base) {
            this.@base = @base;
        }

        public static Net.Vpc.Upa.Filters.RichFieldFilter As(Net.Vpc.Upa.Filters.FieldFilter @base) {
            if (@base == null) {
                return Net.Vpc.Upa.Filters.FieldFilters.All();
            }
            if (@base is Net.Vpc.Upa.Filters.CustomFieldFilter) {
                return (Net.Vpc.Upa.Filters.CustomFieldFilter) @base;
            }
            return new Net.Vpc.Upa.Filters.CustomFieldFilter(@base);
        }

        public virtual Net.Vpc.Upa.Filters.RichFieldFilter ByPrimitive() {
            return As(new Net.Vpc.Upa.Filters.FieldPrimitiveFilter(@base));
        }

        public override Net.Vpc.Upa.Filters.RichFieldFilter And(Net.Vpc.Upa.Filters.FieldFilter other) {
            return As(Net.Vpc.Upa.Filters.FieldAndFilter.And(@base, other));
        }

        public override Net.Vpc.Upa.Filters.RichFieldFilter AndNot(Net.Vpc.Upa.Filters.FieldFilter other) {
            return And(new Net.Vpc.Upa.Filters.FieldReverseFilter(other));
        }

        public override Net.Vpc.Upa.Filters.RichFieldFilter Or(Net.Vpc.Upa.Filters.FieldFilter other) {
            return new Net.Vpc.Upa.Filters.CustomFieldFilter(Net.Vpc.Upa.Filters.FieldOrFilter.Or(@base, other));
        }

        public override Net.Vpc.Upa.Filters.RichFieldFilter OrNot(Net.Vpc.Upa.Filters.FieldFilter other) {
            return Or(new Net.Vpc.Upa.Filters.FieldReverseFilter(other));
        }

        public override Net.Vpc.Upa.Filters.RichFieldFilter Negate() {
            return new Net.Vpc.Upa.Filters.CustomFieldFilter(new Net.Vpc.Upa.Filters.FieldReverseFilter(@base));
        }


        public override bool AcceptDynamic() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return @base.AcceptDynamic();
        }


        public override bool Accept(Net.Vpc.Upa.Field f) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return @base.Accept(f);
        }


        public override int GetHashCode() {
            int hash = 3;
            hash = 97 * hash + (this.@base != null ? this.@base.GetHashCode() : 0);
            return hash;
        }


        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (GetType() != obj.GetType()) {
                return false;
            }
            Net.Vpc.Upa.Filters.CustomFieldFilter other = (Net.Vpc.Upa.Filters.CustomFieldFilter) obj;
            if (this.@base != other.@base && (this.@base == null || !this.@base.Equals(other.@base))) {
                return false;
            }
            return true;
        }


        public override string ToString() {
            return System.Convert.ToString(@base);
        }
    }
}
