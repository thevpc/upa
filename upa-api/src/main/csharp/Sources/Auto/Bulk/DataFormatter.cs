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
    public interface DataFormatter : Net.TheVpc.Upa.Closeable {

         void Configure(object target) /* throws System.IO.IOException */ ;

         Net.TheVpc.Upa.Bulk.DataFormatter SetDataRowConverter(Net.TheVpc.Upa.Bulk.DataRowConverter dataRowConverter);

         Net.TheVpc.Upa.Bulk.DataRowConverter GetDataRowConverter();

         Net.TheVpc.Upa.Bulk.DataWriter CreateWriter() /* throws System.IO.IOException */ ;

         Net.TheVpc.Upa.ObjectFactory GetFactory();

         void SetFactory(Net.TheVpc.Upa.ObjectFactory factory);
    }
}
