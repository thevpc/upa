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
     *
     * @author taha.bensalah@gmail.com
     */
    public abstract class AbstractDataParser : Net.Vpc.Upa.Bulk.DataParser {

        private Net.Vpc.Upa.ObjectFactory factory;

        private Net.Vpc.Upa.Bulk.DataDeserializer dataDeserializer;

        public virtual Net.Vpc.Upa.Bulk.DataDeserializer GetDataDeserializer() {
            return dataDeserializer;
        }

        public virtual void SetDataDeserializer(Net.Vpc.Upa.Bulk.DataDeserializer dataDeserializer) {
            this.dataDeserializer = dataDeserializer;
        }

        public virtual Net.Vpc.Upa.ObjectFactory GetFactory() {
            return factory;
        }

        public virtual void SetFactory(Net.Vpc.Upa.ObjectFactory factory) {
            this.factory = factory;
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract Net.Vpc.Upa.Bulk.DataReader Parse();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract void Configure(object arg1);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract void Close();
    }
}
