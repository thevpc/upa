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
     * @author vpc
     */
    public class DefaultEntityBuilder : Net.Vpc.Upa.EntityBuilder {

        private Net.Vpc.Upa.Impl.EntityFactory entityFactory;

        private Net.Vpc.Upa.Impl.KeyFactory keyFactory;

        private Net.Vpc.Upa.Impl.EntityConverter entityConverter;

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

        public virtual Net.Vpc.Upa.Impl.EntityConverter GetEntityConverter() {
            return entityConverter;
        }

        public virtual void SetEntityConverter(Net.Vpc.Upa.Impl.EntityConverter entityConverter) {
            this.entityConverter = entityConverter;
        }


        public virtual Net.Vpc.Upa.Record CreateRecord() {
            return entityFactory.CreateRecord();
        }


        public virtual  R CreateObject<R>() {
            return entityFactory.CreateObject<R>();
        }


        public virtual  Net.Vpc.Upa.Record GetRecord<R>(R entity, bool ignoreUnspecified) {
            return entityFactory.GetRecord<R>(entity, ignoreUnspecified);
        }


        public virtual  Net.Vpc.Upa.Record GetRecord<R>(R entity) {
            return entityFactory.GetRecord<R>(entity);
        }


        public virtual  R GetEntity<R>(Net.Vpc.Upa.Record unstructuredRecord) {
            return entityFactory.GetEntity<R>(unstructuredRecord);
        }


        public virtual void SetProperty(object entityObject, string property, object @value) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            entityFactory.SetProperty(entityObject, property, @value);
        }


        public virtual object GetProperty(object entityObject, string property) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
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
            return entityConverter.IdToKey(entityId);
        }


        public virtual object KeyToId(Net.Vpc.Upa.Key recordKey) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityConverter.KeyToId(recordKey);
        }


        public virtual Net.Vpc.Upa.Record EntityToRecord(object entityValue) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityConverter.EntityToRecord(entityValue);
        }


        public virtual Net.Vpc.Upa.Record EntityToRecord(object entityValue, bool ignoreUnspecified) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityConverter.EntityToRecord(entityValue);
        }


        public virtual object GetMainValue(object entityValue) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityConverter.GetMainProperty(entityValue);
        }


        public virtual  R RecordToEntity<R>(Net.Vpc.Upa.Record entityRecord) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityConverter.RecordToEntity<R>(entityRecord);
        }


        public virtual  R IdToEntity<R>(object entityId) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityConverter.IdToEntity<R>(entityId);
        }


        public virtual Net.Vpc.Upa.Record IdToRecord(object entityId) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityConverter.IdToEntity<Net.Vpc.Upa.Record>(entityId);
        }


        public virtual object EntityToId(object entityValue) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityConverter.EntityToId(entityValue);
        }


        public virtual Net.Vpc.Upa.Key EntityToKey(object entityValue) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityConverter.EntityToKey(entityValue);
        }


        public virtual object RecordToId(Net.Vpc.Upa.Record entityRecord) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityConverter.RecordToId(entityRecord);
        }


        public virtual Net.Vpc.Upa.Key RecordToKey(Net.Vpc.Upa.Record entityRecord) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityConverter.RecordToKey(entityRecord);
        }


        public virtual object KeyToEntity(Net.Vpc.Upa.Key recordKey) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityConverter.KeyToEntity(recordKey);
        }


        public virtual Net.Vpc.Upa.Record KeyToRecord(Net.Vpc.Upa.Key recordKey) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityConverter.KeyToRecord(recordKey);
        }


        public virtual void SetRecordId(Net.Vpc.Upa.Record entityRecord, object entityId) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            entityConverter.SetRecordId(entityRecord, entityId);
        }


        public virtual void SetEntityId(object entityObject, object entityId) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            entityConverter.SetEntityId(entityObject, entityId);
        }


        public virtual Net.Vpc.Upa.Expressions.Expression RecordToExpression(Net.Vpc.Upa.Record entityRecord, string entityAlias) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityConverter.RecordToExpression(entityRecord, entityAlias);
        }


        public virtual Net.Vpc.Upa.Expressions.Expression EntityToExpression(object entityValue, bool ignoreUnspecified, string entityAlias) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityConverter.EntityToExpression(entityValue, ignoreUnspecified, entityAlias);
        }


        public virtual Net.Vpc.Upa.Expressions.Expression IdToExpression(object entityId, string alias) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityConverter.IdToExpression(entityId, alias);
        }


        public virtual Net.Vpc.Upa.Expressions.Expression KeyToExpression(Net.Vpc.Upa.Key recordKey, string alias) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityConverter.KeyToExpression(recordKey, alias);
        }


        public virtual  Net.Vpc.Upa.Expressions.Expression IdListToExpression<K>(System.Collections.Generic.IList<K> idList, string alias) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityConverter.IdListToExpression<K>(idList, alias);
        }


        public virtual Net.Vpc.Upa.Expressions.Expression KeyListToExpression(System.Collections.Generic.IList<Net.Vpc.Upa.Key> idList, string alias) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityConverter.KeyListToExpression(idList, alias);
        }


        public virtual Net.Vpc.Upa.QualifiedRecord CreateQualifiedRecord() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return new Net.Vpc.Upa.Impl.DefaultQualifiedRecord(entity);
        }


        public virtual Net.Vpc.Upa.QualifiedRecord CreateQualifiedRecord(Net.Vpc.Upa.Record record) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return new Net.Vpc.Upa.Impl.DefaultQualifiedRecord(entity, record);
        }
    }
}
