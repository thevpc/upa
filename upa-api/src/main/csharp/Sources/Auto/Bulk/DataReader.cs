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



namespace Net.Vpc.Upa.Bulk
{

    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public interface DataReader {

         bool HasNext();

         Net.Vpc.Upa.Bulk.DataRow ReadRow();

         object ReadObject();

         Net.Vpc.Upa.Bulk.DataColumn[] GetColumns();
    }
}
