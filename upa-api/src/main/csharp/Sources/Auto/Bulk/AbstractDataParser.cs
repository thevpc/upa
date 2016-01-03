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
     *
     * @author vpc
     */
    public abstract class AbstractDataParser : Net.Vpc.Upa.Bulk.DataParser {

        private Net.Vpc.Upa.Bulk.DataDeserializer dataDeserializer;

        public virtual Net.Vpc.Upa.Bulk.DataDeserializer GetDataDeserializer() {
            return dataDeserializer;
        }

        public virtual void SetDataDeserializer(Net.Vpc.Upa.Bulk.DataDeserializer dataDeserializer) {
            this.dataDeserializer = dataDeserializer;
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract Net.Vpc.Upa.Bulk.DataReader Parse();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract void Configure(object arg1);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract void Close();
    }
}
