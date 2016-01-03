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
    public class DefaultImportDataManager : Net.Vpc.Upa.Bulk.ImportDataManager {

        public virtual void ImportEntity(Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.Bulk.DataReader dataIterator, Net.Vpc.Upa.Bulk.ImportDataConfig config) {
            Net.Vpc.Upa.PersistenceUnit pu = entity.GetPersistenceUnit();
            if (config == null) {
                config = new Net.Vpc.Upa.Bulk.ImportDataConfig();
            } else {
                config = config.Copy();
            }
            Net.Vpc.Upa.Impl.Bulk.ImportDataConfigHelper h = new Net.Vpc.Upa.Impl.Bulk.ImportDataConfigHelper(config, pu);
            while (dataIterator.HasNext()) {
                Net.Vpc.Upa.Bulk.DataRow r = dataIterator.ReadRow();
                System.Collections.Generic.IDictionary<string , object> rowMap = new System.Collections.Generic.Dictionary<string , object>();
                Net.Vpc.Upa.Bulk.DataColumn[] columns = r.GetColumns();
                for (int i = 0; i < columns.Length; i++) {
                    Net.Vpc.Upa.Bulk.DataColumn dataColumn = columns[i];
                    rowMap[dataColumn.GetName()]=r.GetValues()[i];
                }
                SyncObject(entity, rowMap, config, h);
            }
        }

        protected internal virtual object SyncObject(Net.Vpc.Upa.Entity entity, System.Collections.Generic.IDictionary<string , object> row, Net.Vpc.Upa.Bulk.ImportDataConfig config, Net.Vpc.Upa.Impl.Bulk.ImportDataConfigHelper defaultFinder) {
            Net.Vpc.Upa.Record rec = entity.GetBuilder().CreateRecord();
            //        ImportEntityFinder entityFinder = config.getEntityFinder();
            foreach (System.Collections.Generic.KeyValuePair<string , object> entry in row) {
                Net.Vpc.Upa.Field f = entity.FindField((entry).Key);
                if (f != null) {
                    if (f.GetDataType() is Net.Vpc.Upa.Types.EntityType) {
                        Net.Vpc.Upa.Types.EntityType et = (Net.Vpc.Upa.Types.EntityType) f.GetDataType();
                        Net.Vpc.Upa.Entity master = et.GetRelationship().GetTargetRole().GetEntity();
                        object @value = (entry).Value;
                        if (@value != null && (!(@value is string) || !Net.Vpc.Upa.Impl.Util.Strings.IsNullOrEmpty(System.Convert.ToString(@value)))) {
                            Net.Vpc.Upa.Bulk.ImportDataConfig config2 = config.Copy();
                            config2.SetMode(Net.Vpc.Upa.Bulk.ImportDataMode.ADD_UPDATE);
                            System.Collections.Generic.IDictionary<string , object> map = defaultFinder.GetImportEntityMapper(master).ValueToMap(master, @value);
                            object y = SyncObject(master, map, config2, defaultFinder);
                            rec.SetObject(f.GetName(), y);
                        }
                    } else {
                        rec.SetObject(f.GetName(), Net.Vpc.Upa.Impl.Bulk.ValueParser.Parse((entry).Value, f.GetDataType()));
                    }
                }
            }
            Net.Vpc.Upa.Record oldValue = null;
            if (config.GetMode() != Net.Vpc.Upa.Bulk.ImportDataMode.ADD) {
                object o = defaultFinder.GetImportEntityFinder(entity).FindEntity(entity, row);
                oldValue = entity.GetBuilder().EntityToRecord(o, false);
            }
            object entityValue = null;
            switch(config.GetMode()) {
                case Net.Vpc.Upa.Bulk.ImportDataMode.ADD_UPDATE:
                    {
                        if (oldValue != null) {
                            oldValue.SetAll(rec);
                            entity.Update(oldValue);
                            entityValue = entity.GetBuilder().RecordToEntity<object>(oldValue);
                        } else {
                            entity.Persist(rec);
                            entityValue = entity.GetBuilder().RecordToEntity<object>(rec);
                        }
                        break;
                    }
                case Net.Vpc.Upa.Bulk.ImportDataMode.UPDATE:
                    {
                        if (oldValue != null) {
                            oldValue.SetAll(rec);
                            entity.Update(oldValue);
                            entityValue = entity.GetBuilder().RecordToEntity<object>(oldValue);
                        }
                        break;
                    }
                case Net.Vpc.Upa.Bulk.ImportDataMode.ADD:
                    {
                        if (oldValue == null) {
                            entity.Persist(rec);
                            entityValue = entity.GetBuilder().RecordToEntity<object>(rec);
                        }
                        break;
                    }
                default:
                    {
                        throw new System.ArgumentException ("Unsupported");
                    }
            }
            return entityValue;
        }
    }
}
