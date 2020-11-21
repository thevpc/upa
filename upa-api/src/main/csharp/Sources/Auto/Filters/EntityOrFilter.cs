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
    public class EntityOrFilter : Net.TheVpc.Upa.Filters.AbstractRichEntityFilter {

        private System.Collections.Generic.IList<Net.TheVpc.Upa.Entity> v = new System.Collections.Generic.List<Net.TheVpc.Upa.Entity>(2);

        public EntityOrFilter() {
        }

        public virtual Net.TheVpc.Upa.Filters.RichEntityFilter Or(Net.TheVpc.Upa.Entity filter) {
            if (filter == null) {
                throw new System.NullReferenceException();
            }
            v.Add(filter);
            return this;
        }

        public override bool Accept(Net.TheVpc.Upa.Entity entity) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            for (int i = (v).Count - 1; i >= 0; i--) {
                Net.TheVpc.Upa.Filters.EntityFilter entityFilter = (Net.TheVpc.Upa.Filters.EntityFilter) v[i];
                if (entityFilter.Accept(entity)) {
                    return true;
                }
            }
            return false;
        }
    }
}
