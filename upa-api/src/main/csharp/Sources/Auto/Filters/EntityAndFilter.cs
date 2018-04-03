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
    public class EntityAndFilter : Net.Vpc.Upa.Filters.AbstractRichEntityFilter {

        private System.Collections.Generic.IList<Net.Vpc.Upa.Filters.EntityFilter> list = new System.Collections.Generic.List<Net.Vpc.Upa.Filters.EntityFilter>(2);

        public EntityAndFilter() {
        }

        public EntityAndFilter(System.Collections.Generic.IList<Net.Vpc.Upa.Filters.EntityFilter> list) {
            this.list = new System.Collections.Generic.List<Net.Vpc.Upa.Filters.EntityFilter>(list);
        }

        public override Net.Vpc.Upa.Filters.RichEntityFilter And(Net.Vpc.Upa.Filters.EntityFilter filter) {
            if (filter == null) {
                throw new System.NullReferenceException();
            }
            list.Add(filter);
            return this;
        }

        public override bool Accept(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            for (int i = (list).Count - 1; i >= 0; i--) {
                Net.Vpc.Upa.Filters.EntityFilter entityFilter = list[i];
                if (!entityFilter.Accept(entity)) {
                    return false;
                }
            }
            return true;
        }
    }
}
