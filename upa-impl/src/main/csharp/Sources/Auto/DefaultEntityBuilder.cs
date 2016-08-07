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


    /**
     * @author taha.bensalah@gmail.com
     */
    public class DefaultEntityBuilder : Net.Vpc.Upa.EntityBuilder {

        private Net.Vpc.Upa.Impl.EntityFactory entityFactory;

        private Net.Vpc.Upa.Impl.KeyFactory keyFactory;

        private Net.Vpc.Upa.Entity entity;

        public DefaultEntityBuilder(Net.Vpc.Upa.Entity entity) {
            this.entity = entity;
        }

        public virtual Net.Vpc.Upa.Impl.EntityFactory GetBuilder() {
            return entityFactory;
        }

        public virtual void SetEntityFactory(Net.Vpc.Upa.Impl.EntityFactory entityFactory) {
            this.entityFactory = entityFactory;
        }

        public virtual Net.Vpc.Upa.Impl.KeyFactory GetKeyFactory() {
            return keyFactory;
        }

        public virtual void SetKeyFactory(Net.Vpc.Upa.Impl.KeyFactory keyFactory) {
            this.keyFactory = keyFactory;
        }


        public virtual Net.Vpc.Upa.Record CreateRecord() {
            return entityFactory.CreateRecord();
        }


        public virtual  R CopyObject<R>(R r) {
            return RecordToObject<R>(CopyRecord(ObjectToRecord(r)));
        }


        public virtual Net.Vpc.Upa.Record CopyRecord(Net.Vpc.Upa.Record rec) {
            Net.Vpc.Upa.Record r = CreateRecord();
            r.SetAll(rec);
            return r;
        }


        public virtual  R CreateObject<R>() {
            return entityFactory.CreateObject<R>();
        }


        public virtual Net.Vpc.Upa.Record ObjectToRecord(object entity, bool ignoreUnspecified) {
            return entityFactory.ObjectToRecord(entity, ignoreUnspecified);
        }


        public virtual Net.Vpc.Upa.Record ObjectToRecord(object entity, System.Collections.Generic.ISet<string> fields, bool ignoreUnspecified, bool ensureIncludeIds) {
            return entityFactory.ObjectToRecord(entity, fields, ignoreUnspecified, ensureIncludeIds);
        }


        public virtual Net.Vpc.Upa.Record ObjectToRecord(object entity) {
            return entityFactory.ObjectToRecord(entity);
        }


        public virtual  R RecordToObject<R>(Net.Vpc.Upa.Record record) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityFactory.RecordToObject<R>(record);
        }


        public virtual void SetProperty(object entityObject, string property, object @value) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (entityObject is Net.Vpc.Upa.Record) {
                ((Net.Vpc.Upa.Record) entityObject).SetObject(property, @value);
                return;
            }
            entityFactory.SetProperty(entityObject, property, @value);
        }


        public virtual object GetProperty(object entityObject, string property) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (entityObject is Net.Vpc.Upa.Record) {
                return ((Net.Vpc.Upa.Record) entityObject).GetObject<T>(property);
            }
            return entityFactory.GetProperty(entityObject, property);
        }


        public virtual Net.Vpc.Upa.Key CreateKey(params object [] keyValues) {
            return keyFactory.CreateKey(keyValues);
        }


        public virtual object CreateId(params object [] idValues) {
            return keyFactory.CreateId(idValues);
        }


        public virtual object GetId(Net.Vpc.Upa.Key unstructuredKey) {
            return keyFactory.GetId(unstructuredKey);
        }


        public virtual Net.Vpc.Upa.Key GetKey(object key) {
            return keyFactory.GetKey(key);
        }


        public virtual Net.Vpc.Upa.Key IdToKey(object entityId) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityFactory.IdToKey(entityId);
        }


        public virtual object KeyToId(Net.Vpc.Upa.Key recordKey) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityFactory.KeyToId(recordKey);
        }


        public virtual object GetMainValue(object objectValue) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityFactory.GetMainProperty(objectValue);
        }


        public virtual  R IdToObject<R>(object objectId) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityFactory.IdToObject<R>(objectId);
        }


        public virtual Net.Vpc.Upa.Record IdToRecord(object objectId) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityFactory.IdToObject<R>(objectId);
        }


        public virtual object ObjectToId(object objectValue) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityFactory.ObjectToId(objectValue);
        }


        public virtual Net.Vpc.Upa.Key ObjectToKey(object objectValue) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityFactory.ObjectToKey(objectValue);
        }


        public virtual object RecordToId(Net.Vpc.Upa.Record record) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityFactory.RecordToId(record);
        }


        public virtual Net.Vpc.Upa.Key RecordToKey(Net.Vpc.Upa.Record record) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityFactory.RecordToKey(record);
        }


        public virtual object KeyToObject(Net.Vpc.Upa.Key key) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityFactory.KeyToObject(key);
        }


        public virtual Net.Vpc.Upa.Record KeyToRecord(Net.Vpc.Upa.Key key) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityFactory.KeyToRecord(key);
        }


        public virtual void SetRecordId(Net.Vpc.Upa.Record record, object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            entityFactory.SetRecordId(record, id);
        }


        public virtual void SetObjectId(object @object, object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            entityFactory.SetObjectId(@object, id);
        }


        public virtual Net.Vpc.Upa.Expressions.Expression RecordToExpression(Net.Vpc.Upa.Record record, string alias) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityFactory.RecordToExpression(record, alias);
        }


        public virtual Net.Vpc.Upa.Expressions.Expression ObjectToExpression(object @object, bool ignoreUnspecified, string alias) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityFactory.ObjectToExpression(@object, ignoreUnspecified, alias);
        }


        public virtual Net.Vpc.Upa.Expressions.Expression ObjectToIdExpression(object objectOrRecord, string alias) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityFactory.ObjectToIdExpression(objectOrRecord, alias);
        }


        public virtual Net.Vpc.Upa.Expressions.Expression IdToExpression(object id, string alias) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityFactory.IdToExpression(id, alias);
        }


        public virtual Net.Vpc.Upa.Expressions.Expression KeyToExpression(Net.Vpc.Upa.Key recordKey, string alias) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityFactory.KeyToExpression(recordKey, alias);
        }


        public virtual  Net.Vpc.Upa.Expressions.Expression IdListToExpression<K>(System.Collections.Generic.IList<K> idList, string alias) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityFactory.IdListToExpression<K>(idList, alias);
        }


        public virtual Net.Vpc.Upa.Expressions.Expression KeyListToExpression(System.Collections.Generic.IList<Net.Vpc.Upa.Key> keyList, string alias) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityFactory.KeyListToExpression(keyList, alias);
        }


        public virtual Net.Vpc.Upa.QualifiedRecord CreateQualifiedRecord() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return new Net.Vpc.Upa.Impl.DefaultQualifiedRecord(entity);
        }


        public virtual Net.Vpc.Upa.QualifiedRecord CreateQualifiedRecord(Net.Vpc.Upa.Record record) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return new Net.Vpc.Upa.Impl.DefaultQualifiedRecord(entity, record);
        }


        public virtual Net.Vpc.Upa.Record CreateInitializedRecord() {
            object o = CreateObject<R>();
            Net.Vpc.Upa.Record r = CreateRecord();
            r.SetAll(ObjectToRecord(o, false));
            foreach (Net.Vpc.Upa.Field field in entity.GetFields()) {
                if (field.IsId() && (field.GetModifiers().Contains(Net.Vpc.Upa.FieldModifier.PERSIST_FORMULA) || field.GetModifiers().Contains(Net.Vpc.Upa.FieldModifier.PERSIST_SEQUENCE))) {
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
            Net.Vpc.Upa.Record r = ObjectToRecord(o, false);
            foreach (Net.Vpc.Upa.Field field in entity.GetFields()) {
                object df = field.GetDefaultValue();
                if (field.IsId() && (field.GetModifiers().Contains(Net.Vpc.Upa.FieldModifier.PERSIST_FORMULA) || field.GetModifiers().Contains(Net.Vpc.Upa.FieldModifier.PERSIST_SEQUENCE))) {
                } else if (df != null) {
                    r.SetObject(field.GetName(), df);
                }
            }
            return RecordToObject<R>(r);
        }
    }
}
