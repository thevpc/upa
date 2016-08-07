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
    public class EntityOrFilter : Net.Vpc.Upa.Filters.EntityFilter {

        private System.Collections.Generic.IList<Net.Vpc.Upa.Entity> v = new System.Collections.Generic.List<Net.Vpc.Upa.Entity>(2);

        public EntityOrFilter() {
        }

        public virtual Net.Vpc.Upa.Filters.EntityOrFilter Or(Net.Vpc.Upa.Entity filter) {
            v.Add(filter);
            return this;
        }

        public virtual bool Accept(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            for (int i = (v).Count - 1; i >= 0; i--) {
                Net.Vpc.Upa.Filters.EntityFilter entityFilter = (Net.Vpc.Upa.Filters.EntityFilter) v[i];
                if (entityFilter.Accept(entity)) {
                    return true;
                }
            }
            return false;
        }
    }
}
