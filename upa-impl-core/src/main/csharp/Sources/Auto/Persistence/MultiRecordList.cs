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



namespace Net.TheVpc.Upa.Impl.Persistence
{


    /**
     * Created with IntelliJ IDEA.
     * User: vpc
     * Date: 8/16/12
     * Time: 6:41 AM
     * To change this template use File | Settings | File Templates.
     */
    public class MultiRecordList : Net.TheVpc.Upa.Impl.Persistence.QueryResultLazyList<Net.TheVpc.Upa.MultiRecord> {

        private string[] recordName;

        private Net.TheVpc.Upa.Entity[] entities;

        internal System.Collections.Generic.IDictionary<string , System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.Impl.Persistence.FieldTracking>> setterToProp;

        private System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.Impl.Persistence.MultiRecordListTracker> currentRecords;

        private int columns;

        private Net.TheVpc.Upa.Impl.Persistence.NativeField[] fields;

        private bool forUpdate;

        public MultiRecordList(Net.TheVpc.Upa.Impl.Persistence.QueryExecutor queryExecutor, bool forUpdate)  : base(queryExecutor){

            this.forUpdate = forUpdate;
            this.fields = queryExecutor.GetFields();
            this.entities = new Net.TheVpc.Upa.Entity[this.fields.Length];
            this.recordName = new string[this.fields.Length];
            this.currentRecords = new System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Impl.Persistence.MultiRecordListTracker>();
            this.setterToProp = new System.Collections.Generic.Dictionary<string , System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.Impl.Persistence.FieldTracking>>();
            int fieldsCount = fields.Length;
            for (int i = 0; i < fieldsCount; i++) {
                Net.TheVpc.Upa.Impl.Persistence.NativeField namedExpression = fields[i];
                Net.TheVpc.Upa.Field field = namedExpression.GetField();
                entities[i] = field == null ? null : field.GetEntity();
                if (namedExpression.GetGroupName() != null) {
                    recordName[i] = namedExpression.GetGroupName();
                } else if (entities[i] != null) {
                    recordName[i] = entities[i].GetName();
                }
                System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.Impl.Persistence.FieldTracking> stringFieldTrackingMap = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.Impl.Persistence.FieldTracking>>(setterToProp,recordName[i]);
                if (stringFieldTrackingMap == null) {
                    stringFieldTrackingMap = new System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Impl.Persistence.FieldTracking>();
                    setterToProp[recordName[i]]=stringFieldTrackingMap;
                }
                if (field != null) {
                    Net.TheVpc.Upa.Impl.Persistence.FieldTracking t = new Net.TheVpc.Upa.Impl.Persistence.FieldTracking(field.GetName(), Net.TheVpc.Upa.Impl.Util.PlatformUtils.SetterName(field.GetName()), i);
                    stringFieldTrackingMap[t.GetSetterMethodName()]=t;
                }
            }
            columns = this.fields.Length;
        }

        protected internal virtual void ResetListeners() {
            foreach (Net.TheVpc.Upa.Impl.Persistence.MultiRecordListTracker tracker in (currentRecords).Values) {
                tracker.record.RemovePropertyChangeListener(tracker.changeListener);
            }
            currentRecords.Clear();
        }




        public override Net.TheVpc.Upa.MultiRecord Parse(Net.TheVpc.Upa.Persistence.QueryResult result) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (forUpdate) {
                ResetListeners();
                Net.TheVpc.Upa.MultiRecord multiRecord = new Net.TheVpc.Upa.Impl.DefaultMultiRecord();
                for (int i = 0; i < columns; i++) {
                    string r = recordName[i];
                    Net.TheVpc.Upa.Record current;
                    if (r == null) {
                        current = multiRecord.GetPlainRecord(true);
                    } else {
                        current = multiRecord.GetRecord(r);
                        if (current == null) {
                            current = entities[i].GetBuilder().CreateRecord();
                            multiRecord.SetRecord(r, current);
                        }
                    }
                    current.SetObject(fields[i].GetName(), result.Read<T>(i));
                    Net.TheVpc.Upa.Impl.Persistence.MultiRecordListTracker tr = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.TheVpc.Upa.Impl.Persistence.MultiRecordListTracker>(currentRecords,recordName[i]);
                    if (tr == null) {
                        Net.TheVpc.Upa.PropertyChangeListener li = new Net.TheVpc.Upa.Impl.Persistence.MultiRecordListTrackPropertyChangeListener(this, r, result);
                        currentRecords[recordName[i]]=new Net.TheVpc.Upa.Impl.Persistence.MultiRecordListTracker(recordName[i], current, li);
                        current.AddPropertyChangeListener(li);
                    }
                }
                return multiRecord;
            } else {
                ResetListeners();
                Net.TheVpc.Upa.MultiRecord multiRecord = new Net.TheVpc.Upa.Impl.DefaultMultiRecord();
                for (int i = 0; i < columns; i++) {
                    string r = recordName[i];
                    Net.TheVpc.Upa.Record current;
                    if (r == null) {
                        current = multiRecord.GetPlainRecord(true);
                    } else {
                        current = multiRecord.GetRecord(r);
                        if (current == null) {
                            current = entities[i].GetBuilder().CreateRecord();
                            multiRecord.SetRecord(r, current);
                        }
                    }
                    current.SetObject(fields[i].GetName(), result.Read<T>(i));
                }
                return multiRecord;
            }
        }
    }
}
