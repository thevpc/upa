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
    public interface DataFormatter : Net.Vpc.Upa.Closeable {

         void Configure(object target) /* throws System.IO.IOException */ ;

         Net.Vpc.Upa.Bulk.DataFormatter SetDataRowConverter(Net.Vpc.Upa.Bulk.DataRowConverter dataRowConverter);

         Net.Vpc.Upa.Bulk.DataRowConverter GetDataRowConverter();

         Net.Vpc.Upa.Bulk.DataWriter CreateWriter() /* throws System.IO.IOException */ ;

         Net.Vpc.Upa.ObjectFactory GetFactory();

         void SetFactory(Net.Vpc.Upa.ObjectFactory factory);
    }
}
