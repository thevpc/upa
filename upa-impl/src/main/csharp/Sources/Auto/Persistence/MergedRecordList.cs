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



namespace Net.Vpc.Upa.Impl.Persistence
{


    /**
     * Created with IntelliJ IDEA. User: vpc Date: 8/16/12 Time: 6:41 AM To change
     * this template use File | Settings | File Templates.
     */
    public class MergedRecordList : Net.Vpc.Upa.Impl.Persistence.QueryResultIteratorList<Net.Vpc.Upa.Record> {

        private int columns;

        private Net.Vpc.Upa.ObjectFactory factory;

        private string[] names;

        internal System.Collections.Generic.IDictionary<string , int?> nameToIndex = new System.Collections.Generic.Dictionary<string , int?>();

        private Net.Vpc.Upa.PropertyChangeListener currentPropertyChangeListener = null;

        private Net.Vpc.Upa.Record currentRecord = null;

        public MergedRecordList(Net.Vpc.Upa.Impl.Persistence.NativeSQL nativeSQL, Net.Vpc.Upa.PersistenceUnit persistenceUnit)  : base(nativeSQL){

            factory = persistenceUnit.GetFactory();
            Net.Vpc.Upa.Impl.Persistence.NativeField[] fields = GetNativeSQL().GetFields();
            names = new string[fields.Length];
            for (int i = 0; i < fields.Length; i++) {
                names[i] = fields[i].GetName();
                nameToIndex[fields[i].GetName()]=i;
            }
            columns = names.Length;
        }

        private void ResetListeners() {
            if (currentRecord != null) {
                currentRecord.RemovePropertyChangeListener(currentPropertyChangeListener);
                currentRecord = null;
                currentPropertyChangeListener = null;
            }
        }


        public override Net.Vpc.Upa.Record Parse(Net.Vpc.Upa.Persistence.QueryResult result) {
            if (GetNativeSQL().IsUpdatable()) {
                ResetListeners();
                Net.Vpc.Upa.Record record = factory.CreateObject<Net.Vpc.Upa.Record>(typeof(Net.Vpc.Upa.Record));
                for (int i = 0; i < columns; i++) {
                    record.SetObject(names[i], result.Read<object>(i));
                }
                record.AddPropertyChangeListener(currentPropertyChangeListener = new Net.Vpc.Upa.Impl.Persistence.QueryResultUpdaterPropertyChangeListener(this, result));
                currentRecord = record;
                return record;
            } else {
                Net.Vpc.Upa.Record record = factory.CreateObject<Net.Vpc.Upa.Record>(typeof(Net.Vpc.Upa.Record));
                for (int i = 0; i < columns; i++) {
                    record.SetObject(names[i], result.Read<object>(i));
                }
                return record;
            }
        }


    }
}
