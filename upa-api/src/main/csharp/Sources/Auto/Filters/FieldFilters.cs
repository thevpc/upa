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
    public class FieldFilters {

        private static readonly Net.Vpc.Upa.Filters.RichFieldFilter DYNAMIC = As(new Net.Vpc.Upa.Filters.FieldDynamicFilter());

        private static readonly Net.Vpc.Upa.Filters.RichFieldFilter REGULAR = As(new Net.Vpc.Upa.Filters.FieldRegularFilter());

        private static readonly Net.Vpc.Upa.Filters.RichFieldFilter ALL = As(new Net.Vpc.Upa.Filters.FieldAnyFilter());

        private static readonly Net.Vpc.Upa.Filters.RichFieldFilter NONE = As(new Net.Vpc.Upa.Filters.FieldAnyFilter()).Negate();

        private static readonly Net.Vpc.Upa.Filters.RichFieldFilter PRIMITIVE = As(new Net.Vpc.Upa.Filters.FieldPrimitiveFilter(null));

        private static readonly Net.Vpc.Upa.Filters.RichFieldFilter ID = Net.Vpc.Upa.Filters.FieldFilters.Regular().And(Net.Vpc.Upa.Filters.FieldFilters.ByModifiersAnyOf(Net.Vpc.Upa.FieldModifier.ID));

        public static Net.Vpc.Upa.Filters.RichFieldFilter As(Net.Vpc.Upa.Filters.FieldFilter @base) {
            if (@base == null) {
                return All();
            }
            if (@base is Net.Vpc.Upa.Filters.FieldFilters) {
                return (Net.Vpc.Upa.Filters.RichFieldFilter) @base;
            }
            return new Net.Vpc.Upa.Filters.CustomFieldFilter(@base);
        }

        public static Net.Vpc.Upa.Filters.RichFieldFilter All() {
            return ALL;
        }

        public static Net.Vpc.Upa.Filters.RichFieldFilter Id() {
            return ID;
        }

        public static Net.Vpc.Upa.Filters.RichFieldFilter Regular() {
            return REGULAR;
        }

        public static Net.Vpc.Upa.Filters.RichFieldFilter Dynamic() {
            return DYNAMIC;
        }

        public static Net.Vpc.Upa.Filters.RichFieldFilter None() {
            return NONE;
        }

        public static Net.Vpc.Upa.Filters.RichFieldFilter Primitive() {
            return PRIMITIVE;
        }

        public static Net.Vpc.Upa.Filters.RichFieldFilter ByInsertAccessLevel(params Net.Vpc.Upa.AccessLevel [] accepted) {
            return new Net.Vpc.Upa.Filters.CustomFieldFilter(Net.Vpc.Upa.Filters.FieldAccessLevelFilter.ForPersist(accepted));
        }

        public static Net.Vpc.Upa.Filters.RichFieldFilter ByUpdateAccessLevel(params Net.Vpc.Upa.AccessLevel [] accepted) {
            return new Net.Vpc.Upa.Filters.CustomFieldFilter(Net.Vpc.Upa.Filters.FieldAccessLevelFilter.ForUpdate(accepted));
        }

        public static Net.Vpc.Upa.Filters.RichFieldFilter ByReadAccessLevel(params Net.Vpc.Upa.AccessLevel [] accepted) {
            return new Net.Vpc.Upa.Filters.CustomFieldFilter(Net.Vpc.Upa.Filters.FieldAccessLevelFilter.ForFind(accepted));
        }

        public static Net.Vpc.Upa.Filters.RichFieldFilter ByAllAccessLevel(params Net.Vpc.Upa.AccessLevel [] accepted) {
            return new Net.Vpc.Upa.Filters.CustomFieldFilter(Net.Vpc.Upa.Filters.FieldAccessLevelFilter.ForAll(accepted));
        }

        public static Net.Vpc.Upa.Filters.RichFieldFilter ByAllProtectionLevel(params Net.Vpc.Upa.ProtectionLevel [] accepted) {
            return new Net.Vpc.Upa.Filters.CustomFieldFilter(Net.Vpc.Upa.Filters.FieldProtectionLevelFilter.ForAll(accepted));
        }

        public static Net.Vpc.Upa.Filters.RichFieldFilter ByModifiersAllOf(params Net.Vpc.Upa.FieldModifier [] accepted) {
            Net.Vpc.Upa.Filters.FieldModifierFilter fieldModifierFilter = new Net.Vpc.Upa.Filters.FieldModifierFilter();
            fieldModifierFilter = fieldModifierFilter.IsAllOf(accepted);
            return new Net.Vpc.Upa.Filters.CustomFieldFilter(fieldModifierFilter);
        }

        public static Net.Vpc.Upa.Filters.RichFieldFilter ByModifiersNotAllOf(params Net.Vpc.Upa.FieldModifier [] accepted) {
            Net.Vpc.Upa.Filters.FieldModifierFilter fieldModifierFilter = new Net.Vpc.Upa.Filters.FieldModifierFilter();
            fieldModifierFilter = fieldModifierFilter.IsNotAllOf(accepted);
            return new Net.Vpc.Upa.Filters.CustomFieldFilter(fieldModifierFilter);
        }

        public static Net.Vpc.Upa.Filters.RichFieldFilter ByModifiersNoneOf(params Net.Vpc.Upa.FieldModifier [] accepted) {
            Net.Vpc.Upa.Filters.FieldModifierFilter fieldModifierFilter = new Net.Vpc.Upa.Filters.FieldModifierFilter();
            fieldModifierFilter = fieldModifierFilter.IsNoneOf(accepted);
            return new Net.Vpc.Upa.Filters.CustomFieldFilter(fieldModifierFilter);
        }

        public static Net.Vpc.Upa.Filters.RichFieldFilter ByModifiersAnyOf(params Net.Vpc.Upa.FieldModifier [] accepted) {
            Net.Vpc.Upa.Filters.FieldModifierFilter fieldModifierFilter = new Net.Vpc.Upa.Filters.FieldModifierFilter();
            fieldModifierFilter = fieldModifierFilter.IsAnyOf(accepted);
            return new Net.Vpc.Upa.Filters.CustomFieldFilter(fieldModifierFilter);
        }

        public static Net.Vpc.Upa.Filters.RichFieldFilter ByName(params string [] acceptedFields) {
            return As(new Net.Vpc.Upa.Filters.FieldNameFilter(acceptedFields));
        }

        public static Net.Vpc.Upa.Filters.RichFieldFilter ByName(System.Collections.Generic.ICollection<string> acceptedFields) {
            return As(new Net.Vpc.Upa.Filters.FieldNameFilter(acceptedFields));
        }

        public static Net.Vpc.Upa.Filters.RichFieldFilter ByList(params Net.Vpc.Upa.Field [] acceptedFields) {
            return As(new Net.Vpc.Upa.Filters.FieldListFilter(acceptedFields));
        }

        public static Net.Vpc.Upa.Filters.RichFieldFilter ByList(System.Collections.Generic.IList<Net.Vpc.Upa.Field> acceptedFields) {
            return As(new Net.Vpc.Upa.Filters.FieldListFilter(acceptedFields));
        }

        public static Net.Vpc.Upa.Filters.RichFieldFilter ByImplType(System.Type type) {
            return As(new Net.Vpc.Upa.Filters.FieldImplTypeFilter(type));
        }

        public static Net.Vpc.Upa.Filters.RichFieldFilter ByDataType(System.Type type) {
            return As(new Net.Vpc.Upa.Filters.FieldDataTypeFilter(type, true));
        }

        public static Net.Vpc.Upa.Filters.RichFieldFilter ByEntityType() {
            return ByDataType(typeof(Net.Vpc.Upa.Types.ManyToOneType));
        }
    }
}
