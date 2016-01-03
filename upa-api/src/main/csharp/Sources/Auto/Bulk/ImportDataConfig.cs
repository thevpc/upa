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
    public class ImportDataConfig {

        private Net.Vpc.Upa.Bulk.ImportDataMode mode = Net.Vpc.Upa.Bulk.ImportDataMode.ADD_UPDATE;

        private System.Collections.Generic.IList<Net.Vpc.Upa.Bulk.ImportEntityFinder> entityFinders = new System.Collections.Generic.List<Net.Vpc.Upa.Bulk.ImportEntityFinder>();

        private System.Collections.Generic.IList<Net.Vpc.Upa.Bulk.ImportEntityMapper> entityMappers = new System.Collections.Generic.List<Net.Vpc.Upa.Bulk.ImportEntityMapper>();

        public virtual Net.Vpc.Upa.Bulk.ImportDataMode GetMode() {
            return mode;
        }

        public virtual void SetMode(Net.Vpc.Upa.Bulk.ImportDataMode mode) {
            this.mode = mode;
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Bulk.ImportEntityFinder> GetEntityFinders() {
            return entityFinders;
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Bulk.ImportEntityMapper> GetEntityMappers() {
            return entityMappers;
        }

        public virtual Net.Vpc.Upa.Bulk.ImportDataConfig Copy() {
            Net.Vpc.Upa.Bulk.ImportDataConfig other = new Net.Vpc.Upa.Bulk.ImportDataConfig();
            other.SetMode(mode);
            Net.Vpc.Upa.FwkConvertUtils.ListAddRange(other.GetEntityFinders(), GetEntityFinders());
            Net.Vpc.Upa.FwkConvertUtils.ListAddRange(other.GetEntityMappers(), GetEntityMappers());
            return other;
        }
    }
}
