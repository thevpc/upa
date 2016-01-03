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



namespace Net.Vpc.Upa
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/27/12 1:51 AM
     */
    public interface EntityBuilder {

         Net.Vpc.Upa.Record CreateRecord();

          R CreateObject<R>();

          Net.Vpc.Upa.Record GetRecord<R>(R entity);

          Net.Vpc.Upa.Record GetRecord<R>(R entity, bool ignoreUnspecified);

          R GetEntity<R>(Net.Vpc.Upa.Record unstructuredRecord);

         void SetProperty(object entityObject, string property, object @value) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         object GetProperty(object entityObject, string property) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Key CreateKey(params object [] keyValues);

         object CreateId(params object [] idValues);

         object GetId(Net.Vpc.Upa.Key unstructuredKey);

         Net.Vpc.Upa.Key GetKey(object key);

        /**
             * transforms entity id to a Record key representation of the given entity
             * id. Updates to the record are NOT recorded to the provided value and vice
             * versa
             *
             * @param entityId entity id
             * @return key representation
             */
         Net.Vpc.Upa.Key IdToKey(object entityId) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

        /**
             * transforms record key to a entity id representation of the given record
             * key. Updates to the record are NOT recorded to the provided value and
             * vice versa
             *
             * @param recordKey record key
             * @return key representation
             */
         object KeyToId(Net.Vpc.Upa.Key recordKey) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

        /**
             * transforms entity value to a Record value representation of the given
             * entity value. Updates to the record are recorded to the provided value
             * and vice versa
             *
             * @param entityValue entity value
             * @return entityToRecord(r, false)
             * @throws UPAException
             */
         Net.Vpc.Upa.Record EntityToRecord(object entityValue) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

        /**
             * Record value representation of the given entity. updates to the record
             * are recorded to the provided value
             *
             * @param entityValue entity value
             * @param ignoreUnspecified when true primitive number type zeros and
             * boolean type false values are reported as null (not included in record)
             * @return entityToRecord(r, false)
             * @throws UPAException
             */
         Net.Vpc.Upa.Record EntityToRecord(object entityValue, bool ignoreUnspecified) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         object GetMainValue(object entityValue) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

          R RecordToEntity<R>(Net.Vpc.Upa.Record entityRecord) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

          R IdToEntity<R>(object entityId) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Record IdToRecord(object entityId) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         object EntityToId(object entityValue) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Key EntityToKey(object entityValue) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         object RecordToId(Net.Vpc.Upa.Record entityRecord) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Key RecordToKey(Net.Vpc.Upa.Record entityRecord) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         object KeyToEntity(Net.Vpc.Upa.Key recordKey) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Record KeyToRecord(Net.Vpc.Upa.Key recordKey) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void SetRecordId(Net.Vpc.Upa.Record entityRecord, object entityId) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void SetEntityId(object entityObject, object entityId) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Expressions.Expression RecordToExpression(Net.Vpc.Upa.Record entityRecord, string entityAlias) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Expressions.Expression EntityToExpression(object entityValue, bool ignoreUnspecified, string entityAlias) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Expressions.Expression IdToExpression(object entityId, string alias) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Expressions.Expression KeyToExpression(Net.Vpc.Upa.Key recordKey, string alias) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

          Net.Vpc.Upa.Expressions.Expression IdListToExpression<K>(System.Collections.Generic.IList<K> entityIdList, string alias) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Expressions.Expression KeyListToExpression(System.Collections.Generic.IList<Net.Vpc.Upa.Key> entityIdList, string alias) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.QualifiedRecord CreateQualifiedRecord() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.QualifiedRecord CreateQualifiedRecord(Net.Vpc.Upa.Record record) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;
    }
}
