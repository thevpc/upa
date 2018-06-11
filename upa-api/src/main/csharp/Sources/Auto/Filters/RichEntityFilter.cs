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
    public interface RichEntityFilter : Net.Vpc.Upa.Filters.EntityFilter {

         Net.Vpc.Upa.Filters.RichEntityFilter And(Net.Vpc.Upa.Filters.EntityFilter filter);

         Net.Vpc.Upa.Filters.RichEntityFilter Or(Net.Vpc.Upa.Filters.EntityFilter filter);

         Net.Vpc.Upa.Filters.RichEntityFilter Negate();
    }
}
