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



namespace Net.Vpc.Upa.Impl
{


    public class DefaultMultiRecord : Net.Vpc.Upa.MultiRecord {

        public const string NO_ENTITY = "*";

        private System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.Record> records = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Record>();

        private Net.Vpc.Upa.Record plainRecord;

        public virtual int EntitySize() {
            int size = 0;
            if (IsValidRecord(plainRecord)) {
                size++;
            }
            foreach (Net.Vpc.Upa.Record record in (records).Values) {
                if (IsValidRecord(record)) {
                    size++;
                }
            }
            return size;
        }

        private bool IsValidRecord(Net.Vpc.Upa.Record r) {
            return r != null && r.Size() > 0;
        }

        public virtual int FieldSize() {
            int s = 0;
            foreach (Net.Vpc.Upa.Record record in (records).Values) {
                s += record.Size();
            }
            return s;
        }

        public virtual Net.Vpc.Upa.Record GetPlainRecord() {
            return GetPlainRecord(false);
        }

        public virtual Net.Vpc.Upa.Record GetPlainRecord(bool create) {
            if (plainRecord == null && create) {
                plainRecord = new Net.Vpc.Upa.Impl.DefaultRecord();
            }
            return plainRecord;
        }

        public virtual Net.Vpc.Upa.Record GetRecord(string entityName) {
            return Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.Record>(records,entityName);
        }

        public virtual void SetRecord(string entityName, Net.Vpc.Upa.Record record) {
            if (record == null) {
                records.Remove(entityName);
            } else {
                records[entityName]=record;
            }
        }

        public virtual Net.Vpc.Upa.Record GetSingleRecord() {
            if (EntitySize() == 1) {
                if (IsValidRecord(plainRecord)) {
                    return plainRecord;
                }
                foreach (Net.Vpc.Upa.Record record in (records).Values) {
                    if (IsValidRecord(record)) {
                        return record;
                    }
                }
            }
            throw new System.IndexOutOfRangeException();
        }

        public virtual Net.Vpc.Upa.Record Merge() {
            Net.Vpc.Upa.Record r = new Net.Vpc.Upa.Impl.DefaultRecord();
            if (plainRecord != null) {
                r.SetAll(plainRecord);
            }
            foreach (Net.Vpc.Upa.Record record in (records).Values) {
                r.SetAll(record);
            }
            return r;
        }
    }
}
