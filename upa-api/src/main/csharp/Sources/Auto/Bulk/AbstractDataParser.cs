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
    public abstract class AbstractDataParser : Net.TheVpc.Upa.Bulk.DataParser {

        private Net.TheVpc.Upa.ObjectFactory factory;

        private Net.TheVpc.Upa.Bulk.DataDeserializer dataDeserializer;

        public virtual Net.TheVpc.Upa.Bulk.DataDeserializer GetDataDeserializer() {
            return dataDeserializer;
        }

        public virtual void SetDataDeserializer(Net.TheVpc.Upa.Bulk.DataDeserializer dataDeserializer) {
            this.dataDeserializer = dataDeserializer;
        }

        public virtual Net.TheVpc.Upa.ObjectFactory GetFactory() {
            return factory;
        }

        public virtual void SetFactory(Net.TheVpc.Upa.ObjectFactory factory) {
            this.factory = factory;
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract Net.TheVpc.Upa.Bulk.DataReader Parse();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract void Configure(object arg1);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract void Close();
    }
}
