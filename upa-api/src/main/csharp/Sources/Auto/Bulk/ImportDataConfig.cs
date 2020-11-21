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
    public class ImportDataConfig {

        private Net.TheVpc.Upa.Bulk.ImportDataMode mode = Net.TheVpc.Upa.Bulk.ImportDataMode.ADD_UPDATE;

        private System.Collections.Generic.IList<Net.TheVpc.Upa.Bulk.ImportEntityFinder> entityFinders = new System.Collections.Generic.List<Net.TheVpc.Upa.Bulk.ImportEntityFinder>();

        private System.Collections.Generic.IList<Net.TheVpc.Upa.Bulk.ImportEntityMapper> entityMappers = new System.Collections.Generic.List<Net.TheVpc.Upa.Bulk.ImportEntityMapper>();

        public virtual Net.TheVpc.Upa.Bulk.ImportDataMode GetMode() {
            return mode;
        }

        public virtual void SetMode(Net.TheVpc.Upa.Bulk.ImportDataMode mode) {
            this.mode = mode;
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Bulk.ImportEntityFinder> GetEntityFinders() {
            return entityFinders;
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Bulk.ImportEntityMapper> GetEntityMappers() {
            return entityMappers;
        }

        public virtual Net.TheVpc.Upa.Bulk.ImportDataConfig Copy() {
            Net.TheVpc.Upa.Bulk.ImportDataConfig other = new Net.TheVpc.Upa.Bulk.ImportDataConfig();
            other.SetMode(mode);
            Net.TheVpc.Upa.FwkConvertUtils.ListAddRange(other.GetEntityFinders(), GetEntityFinders());
            Net.TheVpc.Upa.FwkConvertUtils.ListAddRange(other.GetEntityMappers(), GetEntityMappers());
            return other;
        }
    }
}
