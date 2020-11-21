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
    public interface RichEntityFilter : Net.TheVpc.Upa.Filters.EntityFilter {

         Net.TheVpc.Upa.Filters.RichEntityFilter And(Net.TheVpc.Upa.Filters.EntityFilter filter);

         Net.TheVpc.Upa.Filters.RichEntityFilter Or(Net.TheVpc.Upa.Filters.EntityFilter filter);

         Net.TheVpc.Upa.Filters.RichEntityFilter Negate();
    }
}
