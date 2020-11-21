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
    public class FieldFilters {

        private static readonly Net.TheVpc.Upa.Filters.RichFieldFilter DYNAMIC = As(new Net.TheVpc.Upa.Filters.FieldDynamicFilter());

        private static readonly Net.TheVpc.Upa.Filters.RichFieldFilter REGULAR = As(new Net.TheVpc.Upa.Filters.FieldRegularFilter());

        private static readonly Net.TheVpc.Upa.Filters.RichFieldFilter ALL = As(new Net.TheVpc.Upa.Filters.FieldAnyFilter());

        private static readonly Net.TheVpc.Upa.Filters.RichFieldFilter NONE = As(new Net.TheVpc.Upa.Filters.FieldAnyFilter()).Negate();

        private static readonly Net.TheVpc.Upa.Filters.RichFieldFilter PRIMITIVE = As(new Net.TheVpc.Upa.Filters.FieldPrimitiveFilter(null));

        private static readonly Net.TheVpc.Upa.Filters.RichFieldFilter ID = Net.TheVpc.Upa.Filters.FieldFilters.Regular().And(Net.TheVpc.Upa.Filters.FieldFilters.ByModifiersAnyOf(Net.TheVpc.Upa.FieldModifier.ID));

        public static Net.TheVpc.Upa.Filters.RichFieldFilter As(Net.TheVpc.Upa.Filters.FieldFilter @base) {
            if (@base == null) {
                return All();
            }
            if (@base is Net.TheVpc.Upa.Filters.FieldFilters) {
                return (Net.TheVpc.Upa.Filters.RichFieldFilter) @base;
            }
            return new Net.TheVpc.Upa.Filters.CustomFieldFilter(@base);
        }

        public static Net.TheVpc.Upa.Filters.RichFieldFilter All() {
            return ALL;
        }

        public static Net.TheVpc.Upa.Filters.RichFieldFilter Id() {
            return ID;
        }

        public static Net.TheVpc.Upa.Filters.RichFieldFilter Regular() {
            return REGULAR;
        }

        public static Net.TheVpc.Upa.Filters.RichFieldFilter Dynamic() {
            return DYNAMIC;
        }

        public static Net.TheVpc.Upa.Filters.RichFieldFilter None() {
            return NONE;
        }

        public static Net.TheVpc.Upa.Filters.RichFieldFilter Primitive() {
            return PRIMITIVE;
        }

        public static Net.TheVpc.Upa.Filters.RichFieldFilter ByInsertAccessLevel(params Net.TheVpc.Upa.AccessLevel [] accepted) {
            return new Net.TheVpc.Upa.Filters.CustomFieldFilter(Net.TheVpc.Upa.Filters.FieldAccessLevelFilter.ForPersist(accepted));
        }

        public static Net.TheVpc.Upa.Filters.RichFieldFilter ByUpdateAccessLevel(params Net.TheVpc.Upa.AccessLevel [] accepted) {
            return new Net.TheVpc.Upa.Filters.CustomFieldFilter(Net.TheVpc.Upa.Filters.FieldAccessLevelFilter.ForUpdate(accepted));
        }

        public static Net.TheVpc.Upa.Filters.RichFieldFilter ByReadAccessLevel(params Net.TheVpc.Upa.AccessLevel [] accepted) {
            return new Net.TheVpc.Upa.Filters.CustomFieldFilter(Net.TheVpc.Upa.Filters.FieldAccessLevelFilter.ForFind(accepted));
        }

        public static Net.TheVpc.Upa.Filters.RichFieldFilter ByAllAccessLevel(params Net.TheVpc.Upa.AccessLevel [] accepted) {
            return new Net.TheVpc.Upa.Filters.CustomFieldFilter(Net.TheVpc.Upa.Filters.FieldAccessLevelFilter.ForAll(accepted));
        }

        public static Net.TheVpc.Upa.Filters.RichFieldFilter ByAllProtectionLevel(params Net.TheVpc.Upa.ProtectionLevel [] accepted) {
            return new Net.TheVpc.Upa.Filters.CustomFieldFilter(Net.TheVpc.Upa.Filters.FieldProtectionLevelFilter.ForAll(accepted));
        }

        public static Net.TheVpc.Upa.Filters.RichFieldFilter ByModifiersAllOf(params Net.TheVpc.Upa.FieldModifier [] accepted) {
            Net.TheVpc.Upa.Filters.FieldModifierFilter fieldModifierFilter = new Net.TheVpc.Upa.Filters.FieldModifierFilter();
            fieldModifierFilter = fieldModifierFilter.IsAllOf(accepted);
            return new Net.TheVpc.Upa.Filters.CustomFieldFilter(fieldModifierFilter);
        }

        public static Net.TheVpc.Upa.Filters.RichFieldFilter ByModifiersNotAllOf(params Net.TheVpc.Upa.FieldModifier [] accepted) {
            Net.TheVpc.Upa.Filters.FieldModifierFilter fieldModifierFilter = new Net.TheVpc.Upa.Filters.FieldModifierFilter();
            fieldModifierFilter = fieldModifierFilter.IsNotAllOf(accepted);
            return new Net.TheVpc.Upa.Filters.CustomFieldFilter(fieldModifierFilter);
        }

        public static Net.TheVpc.Upa.Filters.RichFieldFilter ByModifiersNoneOf(params Net.TheVpc.Upa.FieldModifier [] accepted) {
            Net.TheVpc.Upa.Filters.FieldModifierFilter fieldModifierFilter = new Net.TheVpc.Upa.Filters.FieldModifierFilter();
            fieldModifierFilter = fieldModifierFilter.IsNoneOf(accepted);
            return new Net.TheVpc.Upa.Filters.CustomFieldFilter(fieldModifierFilter);
        }

        public static Net.TheVpc.Upa.Filters.RichFieldFilter ByModifiersAnyOf(params Net.TheVpc.Upa.FieldModifier [] accepted) {
            Net.TheVpc.Upa.Filters.FieldModifierFilter fieldModifierFilter = new Net.TheVpc.Upa.Filters.FieldModifierFilter();
            fieldModifierFilter = fieldModifierFilter.IsAnyOf(accepted);
            return new Net.TheVpc.Upa.Filters.CustomFieldFilter(fieldModifierFilter);
        }

        public static Net.TheVpc.Upa.Filters.RichFieldFilter ByName(params string [] acceptedFields) {
            return As(new Net.TheVpc.Upa.Filters.FieldNameFilter(acceptedFields));
        }

        public static Net.TheVpc.Upa.Filters.RichFieldFilter ByName(System.Collections.Generic.ICollection<string> acceptedFields) {
            return As(new Net.TheVpc.Upa.Filters.FieldNameFilter(acceptedFields));
        }

        public static Net.TheVpc.Upa.Filters.RichFieldFilter ByList(params Net.TheVpc.Upa.Field [] acceptedFields) {
            return As(new Net.TheVpc.Upa.Filters.FieldListFilter(acceptedFields));
        }

        public static Net.TheVpc.Upa.Filters.RichFieldFilter ByList(System.Collections.Generic.IList<Net.TheVpc.Upa.Field> acceptedFields) {
            return As(new Net.TheVpc.Upa.Filters.FieldListFilter(acceptedFields));
        }

        public static Net.TheVpc.Upa.Filters.RichFieldFilter ByImplType(System.Type type) {
            return As(new Net.TheVpc.Upa.Filters.FieldImplTypeFilter(type));
        }

        public static Net.TheVpc.Upa.Filters.RichFieldFilter ByDataType(System.Type type) {
            return As(new Net.TheVpc.Upa.Filters.FieldDataTypeFilter(type, true));
        }

        public static Net.TheVpc.Upa.Filters.RichFieldFilter ByEntityType() {
            return ByDataType(typeof(Net.TheVpc.Upa.Types.ManyToOneType));
        }
    }
}
