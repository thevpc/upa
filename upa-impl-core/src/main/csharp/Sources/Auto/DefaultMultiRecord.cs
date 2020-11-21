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



namespace Net.TheVpc.Upa.Impl
{


    public class DefaultMultiRecord : Net.TheVpc.Upa.MultiRecord {

        public const string NO_ENTITY = "*";

        private System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.Record> records = new System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Record>();

        private Net.TheVpc.Upa.Record plainRecord;

        public virtual int EntitySize() {
            int size = 0;
            if (IsValidRecord(plainRecord)) {
                size++;
            }
            foreach (Net.TheVpc.Upa.Record record in (records).Values) {
                if (IsValidRecord(record)) {
                    size++;
                }
            }
            return size;
        }

        private bool IsValidRecord(Net.TheVpc.Upa.Record r) {
            return r != null && r.Size() > 0;
        }

        public virtual int FieldSize() {
            int s = 0;
            foreach (Net.TheVpc.Upa.Record record in (records).Values) {
                s += record.Size();
            }
            return s;
        }

        public virtual Net.TheVpc.Upa.Record GetPlainRecord() {
            return GetPlainRecord(false);
        }

        public virtual Net.TheVpc.Upa.Record GetPlainRecord(bool create) {
            if (plainRecord == null && create) {
                plainRecord = new Net.TheVpc.Upa.Impl.DefaultRecord();
            }
            return plainRecord;
        }

        public virtual Net.TheVpc.Upa.Record GetRecord(string entityName) {
            return Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.TheVpc.Upa.Record>(records,entityName);
        }

        public virtual void SetRecord(string entityName, Net.TheVpc.Upa.Record record) {
            if (record == null) {
                records.Remove(entityName);
            } else {
                records[entityName]=record;
            }
        }

        public virtual Net.TheVpc.Upa.Record GetSingleRecord() {
            if (EntitySize() == 1) {
                if (IsValidRecord(plainRecord)) {
                    return plainRecord;
                }
                foreach (Net.TheVpc.Upa.Record record in (records).Values) {
                    if (IsValidRecord(record)) {
                        return record;
                    }
                }
            }
            throw new System.IndexOutOfRangeException();
        }

        public virtual Net.TheVpc.Upa.Record Merge() {
            Net.TheVpc.Upa.Record r = new Net.TheVpc.Upa.Impl.DefaultRecord();
            if (plainRecord != null) {
                r.SetAll(plainRecord);
            }
            foreach (Net.TheVpc.Upa.Record record in (records).Values) {
                r.SetAll(record);
            }
            return r;
        }
    }
}
