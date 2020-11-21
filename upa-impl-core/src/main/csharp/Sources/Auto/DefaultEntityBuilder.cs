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
     * @author taha.bensalah@gmail.com
     */
    public class DefaultEntityBuilder : Net.TheVpc.Upa.EntityBuilder {

        private Net.TheVpc.Upa.Impl.EntityFactory entityFactory;

        private Net.TheVpc.Upa.Impl.KeyFactory keyFactory;

        private Net.TheVpc.Upa.Entity entity;

        public DefaultEntityBuilder(Net.TheVpc.Upa.Entity entity) {
            this.entity = entity;
        }

        public virtual Net.TheVpc.Upa.Impl.EntityFactory GetBuilder() {
            return entityFactory;
        }

        public virtual void SetEntityFactory(Net.TheVpc.Upa.Impl.EntityFactory entityFactory) {
            this.entityFactory = entityFactory;
        }

        public virtual Net.TheVpc.Upa.Impl.KeyFactory GetKeyFactory() {
            return keyFactory;
        }

        public virtual void SetKeyFactory(Net.TheVpc.Upa.Impl.KeyFactory keyFactory) {
            this.keyFactory = keyFactory;
        }


        public virtual Net.TheVpc.Upa.Record CreateRecord() {
            return entityFactory.CreateRecord();
        }


        public virtual  R CopyObject<R>(R r) {
            return RecordToObject<R>(CopyRecord(ObjectToRecord(r)));
        }


        public virtual Net.TheVpc.Upa.Record CopyRecord(Net.TheVpc.Upa.Record rec) {
            Net.TheVpc.Upa.Record r = CreateRecord();
            r.SetAll(rec);
            return r;
        }


        public virtual  R CreateObject<R>() {
            return entityFactory.CreateObject<R>();
        }


        public virtual Net.TheVpc.Upa.Record ObjectToRecord(object entity, bool ignoreUnspecified) {
            return entityFactory.ObjectToRecord(entity, ignoreUnspecified);
        }


        public virtual Net.TheVpc.Upa.Record ObjectToRecord(object entity, System.Collections.Generic.ISet<string> fields, bool ignoreUnspecified, bool ensureIncludeIds) {
            return entityFactory.ObjectToRecord(entity, fields, ignoreUnspecified, ensureIncludeIds);
        }


        public virtual Net.TheVpc.Upa.Record ObjectToRecord(object entity) {
            return entityFactory.ObjectToRecord(entity);
        }


        public virtual  R RecordToObject<R>(Net.TheVpc.Upa.Record record) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return entityFactory.RecordToObject<R>(record);
        }


        public virtual void SetProperty(object entityObject, string property, object @value) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (entityObject is Net.TheVpc.Upa.Record) {
                ((Net.TheVpc.Upa.Record) entityObject).SetObject(property, @value);
                return;
            }
            entityFactory.SetProperty(entityObject, property, @value);
        }


        public virtual object GetProperty(object entityObject, string property) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (entityObject is Net.TheVpc.Upa.Record) {
                return ((Net.TheVpc.Upa.Record) entityObject).GetObject<T>(property);
            }
            return entityFactory.GetProperty(entityObject, property);
        }


        public virtual Net.TheVpc.Upa.Key CreateKey(params object [] keyValues) {
            return keyFactory.CreateKey(keyValues);
        }


        public virtual object CreateId(params object [] idValues) {
            return keyFactory.CreateId(idValues);
        }


        public virtual object GetId(Net.TheVpc.Upa.Key unstructuredKey) {
            return keyFactory.GetId(unstructuredKey);
        }


        public virtual Net.TheVpc.Upa.Key GetKey(object key) {
            return keyFactory.GetKey(key);
        }


        public virtual Net.TheVpc.Upa.Key IdToKey(object entityId) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return entityFactory.IdToKey(entityId);
        }


        public virtual object KeyToId(Net.TheVpc.Upa.Key recordKey) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return entityFactory.KeyToId(recordKey);
        }


        public virtual object GetMainValue(object objectValue) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return entityFactory.GetMainProperty(objectValue);
        }


        public virtual  R IdToObject<R>(object objectId) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return entityFactory.IdToObject<R>(objectId);
        }


        public virtual Net.TheVpc.Upa.Record IdToRecord(object objectId) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return entityFactory.IdToObject<R>(objectId);
        }


        public virtual object ObjectToId(object objectValue) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return entityFactory.ObjectToId(objectValue);
        }


        public virtual Net.TheVpc.Upa.Key ObjectToKey(object objectValue) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return entityFactory.ObjectToKey(objectValue);
        }


        public virtual object RecordToId(Net.TheVpc.Upa.Record record) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return entityFactory.RecordToId(record);
        }


        public virtual Net.TheVpc.Upa.Key RecordToKey(Net.TheVpc.Upa.Record record) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return entityFactory.RecordToKey(record);
        }


        public virtual object KeyToObject(Net.TheVpc.Upa.Key key) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return entityFactory.KeyToObject(key);
        }


        public virtual Net.TheVpc.Upa.Record KeyToRecord(Net.TheVpc.Upa.Key key) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return entityFactory.KeyToRecord(key);
        }


        public virtual void SetRecordId(Net.TheVpc.Upa.Record record, object id) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            entityFactory.SetRecordId(record, id);
        }


        public virtual void SetObjectId(object @object, object id) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            entityFactory.SetObjectId(@object, id);
        }


        public virtual Net.TheVpc.Upa.Expressions.Expression RecordToExpression(Net.TheVpc.Upa.Record record, string alias) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return entityFactory.RecordToExpression(record, alias);
        }


        public virtual Net.TheVpc.Upa.Expressions.Expression ObjectToExpression(object @object, bool ignoreUnspecified, string alias) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return entityFactory.ObjectToExpression(@object, ignoreUnspecified, alias);
        }


        public virtual Net.TheVpc.Upa.Expressions.Expression ObjectToIdExpression(object objectOrRecord, string alias) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return entityFactory.ObjectToIdExpression(objectOrRecord, alias);
        }


        public virtual Net.TheVpc.Upa.Expressions.Expression IdToExpression(object id, string alias) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return entityFactory.IdToExpression(id, alias);
        }


        public virtual Net.TheVpc.Upa.Expressions.Expression KeyToExpression(Net.TheVpc.Upa.Key recordKey, string alias) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return entityFactory.KeyToExpression(recordKey, alias);
        }


        public virtual  Net.TheVpc.Upa.Expressions.Expression IdListToExpression<K>(System.Collections.Generic.IList<K> idList, string alias) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return entityFactory.IdListToExpression<K>(idList, alias);
        }


        public virtual Net.TheVpc.Upa.Expressions.Expression KeyListToExpression(System.Collections.Generic.IList<Net.TheVpc.Upa.Key> keyList, string alias) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return entityFactory.KeyListToExpression(keyList, alias);
        }


        public virtual Net.TheVpc.Upa.QualifiedRecord CreateQualifiedRecord() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return new Net.TheVpc.Upa.Impl.DefaultQualifiedRecord(entity);
        }


        public virtual Net.TheVpc.Upa.QualifiedRecord CreateQualifiedRecord(Net.TheVpc.Upa.Record record) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return new Net.TheVpc.Upa.Impl.DefaultQualifiedRecord(entity, record);
        }


        public virtual Net.TheVpc.Upa.Record CreateInitializedRecord() {
            object o = CreateObject<R>();
            Net.TheVpc.Upa.Record r = CreateRecord();
            r.SetAll(ObjectToRecord(o, false));
            foreach (Net.TheVpc.Upa.Field field in entity.GetFields()) {
                if (field.IsId() && (field.GetModifiers().Contains(Net.TheVpc.Upa.FieldModifier.PERSIST_FORMULA) || field.GetModifiers().Contains(Net.TheVpc.Upa.FieldModifier.PERSIST_SEQUENCE))) {
                    r.Remove(field.GetName());
                } else {
                    object df = field.GetDefaultValue();
                    if (df != null) {
                        r.SetObject(field.GetName(), df);
                    }
                }
            }
            return r;
        }


        public virtual  R CreateInitializedObject<R>() {
            object o = CreateObject<R>();
            Net.TheVpc.Upa.Record r = ObjectToRecord(o, false);
            foreach (Net.TheVpc.Upa.Field field in entity.GetFields()) {
                object df = field.GetDefaultValue();
                if (field.IsId() && (field.GetModifiers().Contains(Net.TheVpc.Upa.FieldModifier.PERSIST_FORMULA) || field.GetModifiers().Contains(Net.TheVpc.Upa.FieldModifier.PERSIST_SEQUENCE))) {
                } else if (df != null) {
                    r.SetObject(field.GetName(), df);
                }
            }
            return RecordToObject<R>(r);
        }
    }
}
