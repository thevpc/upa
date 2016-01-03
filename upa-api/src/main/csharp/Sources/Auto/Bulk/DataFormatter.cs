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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public interface DataFormatter : Net.Vpc.Upa.Closeable {

         void Configure(object target) /* throws System.IO.IOException */ ;

         void SetDataSerializer(Net.Vpc.Upa.Bulk.DataSerializer dataSerializer);

         Net.Vpc.Upa.Bulk.DataSerializer GetDataSerializer();

         Net.Vpc.Upa.Bulk.DataWriter CreateWriter() /* throws System.IO.IOException */ ;
    }
}
