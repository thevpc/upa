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
     */
    public class Fields : Net.Vpc.Upa.Filters.AbstractFieldFilter {

        private static Net.Vpc.Upa.Filters.Fields DYNAMIC = As(new Net.Vpc.Upa.Filters.FieldDynamicFilter());

        private static Net.Vpc.Upa.Filters.Fields REGULAR = As(new Net.Vpc.Upa.Filters.FieldRegularFilter());

        private static Net.Vpc.Upa.Filters.Fields ANY = As(new Net.Vpc.Upa.Filters.FieldAnyFilter());

        private static Net.Vpc.Upa.Filters.Fields NONE = As(new Net.Vpc.Upa.Filters.FieldAnyFilter()).Negate();

        private static Net.Vpc.Upa.Filters.Fields PRIMITIVE = As(new Net.Vpc.Upa.Filters.FieldPrimitiveFilter(null));

        private Net.Vpc.Upa.Filters.FieldFilter @base;

        private Fields(Net.Vpc.Upa.Filters.FieldFilter @base) {
            this.@base = @base;
        }

        public static Net.Vpc.Upa.Filters.Fields As(Net.Vpc.Upa.Filters.FieldFilter @base) {
            if (@base == null) {
                return Any();
            }
            if (@base is Net.Vpc.Upa.Filters.Fields) {
                return (Net.Vpc.Upa.Filters.Fields) @base;
            }
            return new Net.Vpc.Upa.Filters.Fields(@base);
        }

        public static Net.Vpc.Upa.Filters.Fields Any() {
            return ANY;
        }

        public static Net.Vpc.Upa.Filters.Fields Regular() {
            return REGULAR;
        }

        public static Net.Vpc.Upa.Filters.Fields Dynamic() {
            return DYNAMIC;
        }

        public static Net.Vpc.Upa.Filters.Fields None() {
            return NONE;
        }

        public static Net.Vpc.Upa.Filters.Fields Primitive() {
            return PRIMITIVE;
        }

        public static Net.Vpc.Upa.Filters.Fields ByInsertAccessLevel(params Net.Vpc.Upa.AccessLevel [] accepted) {
            return new Net.Vpc.Upa.Filters.Fields(Net.Vpc.Upa.Filters.FieldAccessLevelFilter.ForInsert(accepted));
        }

        public static Net.Vpc.Upa.Filters.Fields ByUpdateAccessLevel(params Net.Vpc.Upa.AccessLevel [] accepted) {
            return new Net.Vpc.Upa.Filters.Fields(Net.Vpc.Upa.Filters.FieldAccessLevelFilter.ForUpdate(accepted));
        }

        public static Net.Vpc.Upa.Filters.Fields BySelectAccessLevel(params Net.Vpc.Upa.AccessLevel [] accepted) {
            return new Net.Vpc.Upa.Filters.Fields(Net.Vpc.Upa.Filters.FieldAccessLevelFilter.ForSelect(accepted));
        }

        public static Net.Vpc.Upa.Filters.Fields ByAllAccessLevel(params Net.Vpc.Upa.AccessLevel [] accepted) {
            return new Net.Vpc.Upa.Filters.Fields(Net.Vpc.Upa.Filters.FieldAccessLevelFilter.ForAll(accepted));
        }

        public static Net.Vpc.Upa.Filters.Fields ByModifiersAllOf(params Net.Vpc.Upa.FieldModifier [] accepted) {
            Net.Vpc.Upa.Filters.FieldModifierFilter fieldModifierFilter = new Net.Vpc.Upa.Filters.FieldModifierFilter();
            fieldModifierFilter = fieldModifierFilter.IsAllOf(accepted);
            return new Net.Vpc.Upa.Filters.Fields(fieldModifierFilter);
        }

        public static Net.Vpc.Upa.Filters.Fields ByModifiersNotAllOf(params Net.Vpc.Upa.FieldModifier [] accepted) {
            Net.Vpc.Upa.Filters.FieldModifierFilter fieldModifierFilter = new Net.Vpc.Upa.Filters.FieldModifierFilter();
            fieldModifierFilter = fieldModifierFilter.IsNotAllOf(accepted);
            return new Net.Vpc.Upa.Filters.Fields(fieldModifierFilter);
        }

        public static Net.Vpc.Upa.Filters.Fields ByModifiersNoneOf(params Net.Vpc.Upa.FieldModifier [] accepted) {
            Net.Vpc.Upa.Filters.FieldModifierFilter fieldModifierFilter = new Net.Vpc.Upa.Filters.FieldModifierFilter();
            fieldModifierFilter = fieldModifierFilter.IsNoneOf(accepted);
            return new Net.Vpc.Upa.Filters.Fields(fieldModifierFilter);
        }

        public static Net.Vpc.Upa.Filters.Fields ByModifiersAnyOf(params Net.Vpc.Upa.FieldModifier [] accepted) {
            Net.Vpc.Upa.Filters.FieldModifierFilter fieldModifierFilter = new Net.Vpc.Upa.Filters.FieldModifierFilter();
            fieldModifierFilter = fieldModifierFilter.IsAnyOf(accepted);
            return new Net.Vpc.Upa.Filters.Fields(fieldModifierFilter);
        }

        public static Net.Vpc.Upa.Filters.Fields ByName(params string [] acceptedFields) {
            return As(new Net.Vpc.Upa.Filters.FieldNameFilter(acceptedFields));
        }

        public static Net.Vpc.Upa.Filters.Fields ByName(System.Collections.Generic.IList<string> acceptedFields) {
            return As(new Net.Vpc.Upa.Filters.FieldNameFilter(acceptedFields));
        }

        public static Net.Vpc.Upa.Filters.Fields ByList(params Net.Vpc.Upa.Field [] acceptedFields) {
            return As(new Net.Vpc.Upa.Filters.FieldListFilter(acceptedFields));
        }

        public static Net.Vpc.Upa.Filters.Fields ByList(System.Collections.Generic.IList<Net.Vpc.Upa.Field> acceptedFields) {
            return As(new Net.Vpc.Upa.Filters.FieldListFilter(acceptedFields));
        }

        public static Net.Vpc.Upa.Filters.Fields ByType(System.Type type) {
            return As(new Net.Vpc.Upa.Filters.FieldTypeFilter(type));
        }

        public virtual Net.Vpc.Upa.Filters.Fields ByPrimitive() {
            return As(new Net.Vpc.Upa.Filters.FieldPrimitiveFilter(@base));
        }

        public virtual Net.Vpc.Upa.Filters.Fields And(Net.Vpc.Upa.Filters.FieldFilter other) {
            return As(Net.Vpc.Upa.Filters.FieldAndFilter.And(@base, other));
        }

        public virtual Net.Vpc.Upa.Filters.Fields AndNot(Net.Vpc.Upa.Filters.FieldFilter other) {
            return And(new Net.Vpc.Upa.Filters.FieldReverseFilter(other));
        }

        public virtual Net.Vpc.Upa.Filters.Fields Or(Net.Vpc.Upa.Filters.FieldFilter other) {
            return new Net.Vpc.Upa.Filters.Fields(Net.Vpc.Upa.Filters.FieldOrFilter.Or(@base, other));
        }

        public virtual Net.Vpc.Upa.Filters.Fields OrNot(Net.Vpc.Upa.Filters.FieldFilter other) {
            return Or(new Net.Vpc.Upa.Filters.FieldReverseFilter(other));
        }

        public virtual Net.Vpc.Upa.Filters.Fields Negate() {
            return new Net.Vpc.Upa.Filters.Fields(new Net.Vpc.Upa.Filters.FieldReverseFilter(@base));
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
            Net.Vpc.Upa.Filters.Fields other = (Net.Vpc.Upa.Filters.Fields) obj;
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
