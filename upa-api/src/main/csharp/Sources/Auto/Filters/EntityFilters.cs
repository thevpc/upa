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
     * @author taha.bensalah@gmail.com on 7/31/16.
     */
    public class EntityFilters {

        private static Net.TheVpc.Upa.Filters.RichEntityFilter ALL = new Net.TheVpc.Upa.Filters.EntityAnyFilter();

        private static readonly Net.TheVpc.Upa.Filters.RichEntityFilter NONE = ALL.Negate();

        public static Net.TheVpc.Upa.Filters.RichEntityFilter ByName(params string [] names) {
            return new Net.TheVpc.Upa.Filters.EntityNameFilter(new System.Collections.Generic.List<string>(names));
        }

        public static Net.TheVpc.Upa.Filters.RichEntityFilter Not(Net.TheVpc.Upa.Filters.EntityFilter filter) {
            return Of(filter).Negate();
        }

        public static Net.TheVpc.Upa.Filters.RichEntityFilter All() {
            return ALL;
        }

        public static Net.TheVpc.Upa.Filters.RichEntityFilter Of(Net.TheVpc.Upa.Filters.EntityFilter filter) {
            if (filter is Net.TheVpc.Upa.Filters.RichEntityFilter) {
                return (Net.TheVpc.Upa.Filters.RichEntityFilter) filter;
            }
            return new Net.TheVpc.Upa.Filters.RichEntityFilterAdapter(filter);
        }
    }
}
