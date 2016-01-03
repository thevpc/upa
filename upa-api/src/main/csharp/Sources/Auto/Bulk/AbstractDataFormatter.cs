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
    public abstract class AbstractDataFormatter : Net.Vpc.Upa.Bulk.DataFormatter {

        private Net.Vpc.Upa.Bulk.DataSerializer dataSerializer;

        public virtual Net.Vpc.Upa.Bulk.DataSerializer GetDataSerializer() {
            return dataSerializer;
        }

        public virtual void SetDataSerializer(Net.Vpc.Upa.Bulk.DataSerializer dataSerializer) {
            this.dataSerializer = dataSerializer;
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract void Configure(object arg1);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract Net.Vpc.Upa.Bulk.DataWriter CreateWriter();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract void Close();
    }
}
