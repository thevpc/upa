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
    public abstract class AbstractDataFormatter : Net.TheVpc.Upa.Bulk.DataFormatter {

        private Net.TheVpc.Upa.ObjectFactory factory;

        private Net.TheVpc.Upa.Bulk.DataRowConverter dataRowConverter;

        public virtual Net.TheVpc.Upa.Bulk.DataRowConverter GetDataRowConverter() {
            return dataRowConverter;
        }

        public virtual Net.TheVpc.Upa.Bulk.DataFormatter SetDataRowConverter(Net.TheVpc.Upa.Bulk.DataRowConverter dataRowConverter) {
            this.dataRowConverter = dataRowConverter;
            return this;
        }


        public virtual Net.TheVpc.Upa.ObjectFactory GetFactory() {
            return factory;
        }


        public virtual void SetFactory(Net.TheVpc.Upa.ObjectFactory factory) {
            this.factory = factory;
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract void Configure(object arg1);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract Net.TheVpc.Upa.Bulk.DataWriter CreateWriter();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract void Close();
    }
}
