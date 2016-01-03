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
    public interface DataParser : Net.Vpc.Upa.Closeable {

        /**
             *
             * @param source File or InputStream or URL Reader
             * @throws IOException
             */
         void Configure(object source) /* throws System.IO.IOException */ ;

         void SetDataDeserializer(Net.Vpc.Upa.Bulk.DataDeserializer dataDeserializer);

         Net.Vpc.Upa.Bulk.DataDeserializer GetDataDeserializer();

         Net.Vpc.Upa.Bulk.DataReader Parse() /* throws System.IO.IOException */ ;
    }
}
