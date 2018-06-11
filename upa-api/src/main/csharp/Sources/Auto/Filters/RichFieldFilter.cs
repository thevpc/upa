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
    public interface RichFieldFilter : Net.Vpc.Upa.Filters.FieldFilter {

         Net.Vpc.Upa.Filters.RichFieldFilter And(Net.Vpc.Upa.Filters.FieldFilter filter);

         Net.Vpc.Upa.Filters.RichFieldFilter AndNot(Net.Vpc.Upa.Filters.FieldFilter filter);

         Net.Vpc.Upa.Filters.RichFieldFilter Or(Net.Vpc.Upa.Filters.FieldFilter filter);

         Net.Vpc.Upa.Filters.RichFieldFilter OrNot(Net.Vpc.Upa.Filters.FieldFilter filter);

         Net.Vpc.Upa.Filters.RichFieldFilter Negate();
    }
}
