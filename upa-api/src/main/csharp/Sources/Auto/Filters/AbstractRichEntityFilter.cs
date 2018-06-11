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
    public abstract class AbstractRichEntityFilter : Net.Vpc.Upa.Filters.RichEntityFilter {

        public virtual Net.Vpc.Upa.Filters.RichEntityFilter And(Net.Vpc.Upa.Filters.EntityFilter filter) {
            Net.Vpc.Upa.Filters.EntityAndFilter a = new Net.Vpc.Upa.Filters.EntityAndFilter();
            a.And(this);
            a.And(filter);
            return a;
        }

        public virtual Net.Vpc.Upa.Filters.RichEntityFilter Or(Net.Vpc.Upa.Filters.EntityFilter filter) {
            Net.Vpc.Upa.Filters.EntityOrFilter a = new Net.Vpc.Upa.Filters.EntityOrFilter();
            a.And(this);
            a.And(filter);
            return a;
        }


        public virtual Net.Vpc.Upa.Filters.RichEntityFilter Negate() {
            return new Net.Vpc.Upa.Filters.EntityReverseFilter(this);
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract bool Accept(Net.Vpc.Upa.Entity arg1);
    }
}
