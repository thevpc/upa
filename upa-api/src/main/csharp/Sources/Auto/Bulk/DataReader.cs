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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public interface DataReader {

         bool HasNext();

         Net.TheVpc.Upa.Bulk.DataRow ReadRow();

         object ReadObject();

         Net.TheVpc.Upa.Bulk.DataColumn[] GetColumns();
    }
}
