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


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/3/12 1:19 AM
     */
    public class DefaultQualifiedRecord : Net.TheVpc.Upa.Impl.AbstractRecord, Net.TheVpc.Upa.QualifiedRecord {

        private Net.TheVpc.Upa.Entity entity;

        private Net.TheVpc.Upa.Record record;

        public DefaultQualifiedRecord(Net.TheVpc.Upa.Entity entity)  : this(entity, entity.GetBuilder().CreateRecord()){

        }

        public DefaultQualifiedRecord(Net.TheVpc.Upa.Entity entity, Net.TheVpc.Upa.Record record) {
            this.entity = entity;
            this.record = record;
        }

        public virtual Net.TheVpc.Upa.Entity GetEntity() {
            return entity;
        }

        public virtual Net.TheVpc.Upa.Record GetRecord() {
            return record;
        }

        public virtual string GetRecordName() {
            return GetRecord().GetObject<T>(GetEntity().GetMainField().GetName());
        }

        public virtual Net.TheVpc.Upa.Key GetKey() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetEntity().GetBuilder().RecordToKey(GetRecord());
        }

        public virtual void SetRawId(params object [] ids) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Record kr = GetEntity().GetBuilder().KeyToRecord(GetEntity().GetBuilder().CreateKey(ids));
            GetRecord().SetAll(kr);
        }

        public virtual void SetIdentifier(object @value) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Record kr = GetEntity().GetBuilder().IdToRecord(@value);
            GetRecord().SetAll(kr);
        }

        public virtual void SetKey(Net.TheVpc.Upa.Key key) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Record kr = GetEntity().GetBuilder().KeyToRecord(key);
            GetRecord().SetAll(kr);
        }

        public virtual object GetId() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetEntity().GetBuilder().RecordToId(GetRecord());
        }

        public virtual object[] GetRawId() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetKey().GetValue();
        }


        public override void SetObject(string key, object @value) {
            SetUpdated(key);
            GetRecord().SetObject(key, @value);
        }


        public override  T GetSingleResult<T>() {
            return GetRecord().GetSingleResult<T>();
        }


        public override System.Collections.Generic.ISet<string> KeySet() {
            return GetRecord().KeySet();
        }


        public override int Size() {
            return GetRecord().Size();
        }


        public override System.Collections.Generic.IDictionary<string , object> ToMap() {
            return GetRecord().ToMap();
        }


        public override bool IsSet(string key) {
            return GetRecord().IsSet(key);
        }


        public override void Remove(string key) {
            GetRecord().Remove(key);
        }


        public override void AddPropertyChangeListener(string key, Net.TheVpc.Upa.PropertyChangeListener listener) {
            GetRecord().AddPropertyChangeListener(key, listener);
        }


        public override void RemovePropertyChangeListener(string key, Net.TheVpc.Upa.PropertyChangeListener listener) {
            GetRecord().RemovePropertyChangeListener(key, listener);
        }


        public override void AddPropertyChangeListener(Net.TheVpc.Upa.PropertyChangeListener listener) {
            GetRecord().AddPropertyChangeListener(listener);
        }


        public override void RemovePropertyChangeListener(Net.TheVpc.Upa.PropertyChangeListener listener) {
            GetRecord().RemovePropertyChangeListener(listener);
        }


        public override  T GetObject<T>(string key) {
            return GetRecord().GetObject<T>(key);
        }
    }
}
