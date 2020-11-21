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



namespace Net.TheVpc.Upa.Bulk
{

    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public interface DataRowConverter {

         Net.TheVpc.Upa.Bulk.DataColumn[] GetColumns();

         object[] ObjectToRow(object o);
    }
}
