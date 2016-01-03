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



namespace Net.Vpc.Upa.Impl.Bulk
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class ImportDataConfigHelper {

        private Net.Vpc.Upa.Bulk.ImportDataConfig config;

        private System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.Bulk.ImportEntityMapper> mappers = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Bulk.ImportEntityMapper>();

        private System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.Bulk.ImportEntityFinder> finders = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Bulk.ImportEntityFinder>();

        private Net.Vpc.Upa.Bulk.ImportEntityFinder defaultFinder;

        private Net.Vpc.Upa.Bulk.ImportEntityMapper defaultMapper;

        public ImportDataConfigHelper(Net.Vpc.Upa.Bulk.ImportDataConfig config, Net.Vpc.Upa.PersistenceUnit pu) {
            this.config = config;
            defaultFinder = pu.GetFactory().CreateObject<Net.Vpc.Upa.Bulk.ImportEntityFinder>(typeof(Net.Vpc.Upa.Bulk.ImportEntityFinder));
            defaultMapper = pu.GetFactory().CreateObject<Net.Vpc.Upa.Bulk.ImportEntityMapper>(typeof(Net.Vpc.Upa.Bulk.ImportEntityMapper));
        }

        public virtual Net.Vpc.Upa.Bulk.ImportEntityMapper GetImportEntityMapper(Net.Vpc.Upa.Entity e) {
            Net.Vpc.Upa.Bulk.ImportEntityMapper p = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.Bulk.ImportEntityMapper>(mappers,e.GetName());
            if (p != null) {
                return p;
            }
            foreach (Net.Vpc.Upa.Bulk.ImportEntityMapper v in config.GetEntityMappers()) {
                if (v.Accept(e)) {
                    p = v;
                    break;
                }
            }
            if (p == null) {
                p = defaultMapper;
            }
            mappers[e.GetName()]=p;
            return p;
        }

        public virtual Net.Vpc.Upa.Bulk.ImportEntityFinder GetImportEntityFinder(Net.Vpc.Upa.Entity e) {
            Net.Vpc.Upa.Bulk.ImportEntityFinder p = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.Bulk.ImportEntityFinder>(finders,e.GetName());
            if (p != null) {
                return p;
            }
            foreach (Net.Vpc.Upa.Bulk.ImportEntityFinder v in config.GetEntityFinders()) {
                if (v.Accept(e)) {
                    p = v;
                    break;
                }
            }
            if (p == null) {
                p = defaultFinder;
            }
            finders[e.GetName()]=p;
            return p;
        }
    }
}
