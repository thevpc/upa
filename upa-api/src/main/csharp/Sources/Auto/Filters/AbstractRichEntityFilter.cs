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
    public abstract class AbstractRichEntityFilter : Net.TheVpc.Upa.Filters.RichEntityFilter {

        public virtual Net.TheVpc.Upa.Filters.RichEntityFilter And(Net.TheVpc.Upa.Filters.EntityFilter filter) {
            Net.TheVpc.Upa.Filters.EntityAndFilter a = new Net.TheVpc.Upa.Filters.EntityAndFilter();
            a.And(this);
            a.And(filter);
            return a;
        }

        public virtual Net.TheVpc.Upa.Filters.RichEntityFilter Or(Net.TheVpc.Upa.Filters.EntityFilter filter) {
            Net.TheVpc.Upa.Filters.EntityOrFilter a = new Net.TheVpc.Upa.Filters.EntityOrFilter();
            a.And(this);
            a.And(filter);
            return a;
        }


        public virtual Net.TheVpc.Upa.Filters.RichEntityFilter Negate() {
            return new Net.TheVpc.Upa.Filters.EntityReverseFilter(this);
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract bool Accept(Net.TheVpc.Upa.Entity arg1);
    }
}
