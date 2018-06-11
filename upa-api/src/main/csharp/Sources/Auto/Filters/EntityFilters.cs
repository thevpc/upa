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
     * @author taha.bensalah@gmail.com on 7/31/16.
     */
    public class EntityFilters {

        private static Net.Vpc.Upa.Filters.RichEntityFilter ALL = new Net.Vpc.Upa.Filters.EntityAnyFilter();

        private static readonly Net.Vpc.Upa.Filters.RichEntityFilter NONE = ALL.Negate();

        public static Net.Vpc.Upa.Filters.RichEntityFilter ByName(params string [] names) {
            return new Net.Vpc.Upa.Filters.EntityNameFilter(new System.Collections.Generic.List<string>(names));
        }

        public static Net.Vpc.Upa.Filters.RichEntityFilter Not(Net.Vpc.Upa.Filters.EntityFilter filter) {
            return Of(filter).Negate();
        }

        public static Net.Vpc.Upa.Filters.RichEntityFilter All() {
            return ALL;
        }

        public static Net.Vpc.Upa.Filters.RichEntityFilter Of(Net.Vpc.Upa.Filters.EntityFilter filter) {
            if (filter is Net.Vpc.Upa.Filters.RichEntityFilter) {
                return (Net.Vpc.Upa.Filters.RichEntityFilter) filter;
            }
            return new Net.Vpc.Upa.Filters.RichEntityFilterAdapter(filter);
        }
    }
}
