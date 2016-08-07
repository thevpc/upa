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



namespace Net.Vpc.Upa.Bulk
{

    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public interface DataRowConverter {

         Net.Vpc.Upa.Bulk.DataColumn[] GetColumns();

         object[] ObjectToRow(object o);
    }
}
