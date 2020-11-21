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
     */
    public class CustomFieldFilter : Net.TheVpc.Upa.Filters.AbstractFieldFilter {

        private Net.TheVpc.Upa.Filters.FieldFilter @base;

        internal CustomFieldFilter(Net.TheVpc.Upa.Filters.FieldFilter @base) {
            this.@base = @base;
        }

        public static Net.TheVpc.Upa.Filters.RichFieldFilter As(Net.TheVpc.Upa.Filters.FieldFilter @base) {
            if (@base == null) {
                return Net.TheVpc.Upa.Filters.FieldFilters.All();
            }
            if (@base is Net.TheVpc.Upa.Filters.CustomFieldFilter) {
                return (Net.TheVpc.Upa.Filters.CustomFieldFilter) @base;
            }
            return new Net.TheVpc.Upa.Filters.CustomFieldFilter(@base);
        }

        public virtual Net.TheVpc.Upa.Filters.RichFieldFilter ByPrimitive() {
            return As(new Net.TheVpc.Upa.Filters.FieldPrimitiveFilter(@base));
        }

        public override Net.TheVpc.Upa.Filters.RichFieldFilter And(Net.TheVpc.Upa.Filters.FieldFilter other) {
            return As(Net.TheVpc.Upa.Filters.FieldAndFilter.And(@base, other));
        }

        public override Net.TheVpc.Upa.Filters.RichFieldFilter AndNot(Net.TheVpc.Upa.Filters.FieldFilter other) {
            return And(new Net.TheVpc.Upa.Filters.FieldReverseFilter(other));
        }

        public override Net.TheVpc.Upa.Filters.RichFieldFilter Or(Net.TheVpc.Upa.Filters.FieldFilter other) {
            return new Net.TheVpc.Upa.Filters.CustomFieldFilter(Net.TheVpc.Upa.Filters.FieldOrFilter.Or(@base, other));
        }

        public override Net.TheVpc.Upa.Filters.RichFieldFilter OrNot(Net.TheVpc.Upa.Filters.FieldFilter other) {
            return Or(new Net.TheVpc.Upa.Filters.FieldReverseFilter(other));
        }

        public override Net.TheVpc.Upa.Filters.RichFieldFilter Negate() {
            return new Net.TheVpc.Upa.Filters.CustomFieldFilter(new Net.TheVpc.Upa.Filters.FieldReverseFilter(@base));
        }


        public override bool AcceptDynamic() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return @base.AcceptDynamic();
        }


        public override bool Accept(Net.TheVpc.Upa.Field f) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
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
            Net.TheVpc.Upa.Filters.CustomFieldFilter other = (Net.TheVpc.Upa.Filters.CustomFieldFilter) obj;
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
