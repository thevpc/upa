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
    public interface RichFieldFilter : Net.TheVpc.Upa.Filters.FieldFilter {

         Net.TheVpc.Upa.Filters.RichFieldFilter And(Net.TheVpc.Upa.Filters.FieldFilter filter);

         Net.TheVpc.Upa.Filters.RichFieldFilter AndNot(Net.TheVpc.Upa.Filters.FieldFilter filter);

         Net.TheVpc.Upa.Filters.RichFieldFilter Or(Net.TheVpc.Upa.Filters.FieldFilter filter);

         Net.TheVpc.Upa.Filters.RichFieldFilter OrNot(Net.TheVpc.Upa.Filters.FieldFilter filter);

         Net.TheVpc.Upa.Filters.RichFieldFilter Negate();
    }
}
