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
    public abstract class AbstractDataFormatter : Net.Vpc.Upa.Bulk.DataFormatter {

        private Net.Vpc.Upa.ObjectFactory factory;

        private Net.Vpc.Upa.Bulk.DataRowConverter dataRowConverter;

        public virtual Net.Vpc.Upa.Bulk.DataRowConverter GetDataRowConverter() {
            return dataRowConverter;
        }

        public virtual Net.Vpc.Upa.Bulk.DataFormatter SetDataRowConverter(Net.Vpc.Upa.Bulk.DataRowConverter dataRowConverter) {
            this.dataRowConverter = dataRowConverter;
            return this;
        }


        public virtual Net.Vpc.Upa.ObjectFactory GetFactory() {
            return factory;
        }


        public virtual void SetFactory(Net.Vpc.Upa.ObjectFactory factory) {
            this.factory = factory;
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract void Configure(object arg1);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract Net.Vpc.Upa.Bulk.DataWriter CreateWriter();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract void Close();
    }
}
