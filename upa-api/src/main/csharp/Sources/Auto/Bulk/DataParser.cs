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
    public interface DataParser : Net.TheVpc.Upa.Closeable {

        /**
             *
             * @param source File or InputStream or URL Reader
             * @throws IOException
             */
         void Configure(object source) /* throws System.IO.IOException */ ;

         void SetDataDeserializer(Net.TheVpc.Upa.Bulk.DataDeserializer dataDeserializer);

         Net.TheVpc.Upa.Bulk.DataDeserializer GetDataDeserializer();

         Net.TheVpc.Upa.Bulk.DataReader Parse() /* throws System.IO.IOException */ ;

         Net.TheVpc.Upa.ObjectFactory GetFactory();

         void SetFactory(Net.TheVpc.Upa.ObjectFactory factory);
    }
}
