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

         Net.Vpc.Upa.Record CreateInitializedRecord();

          R CreateInitializedObject<R>();

          R CreateObject<R>();

          R CopyObject<R>(R r);

         Net.Vpc.Upa.Record CopyRecord(Net.Vpc.Upa.Record rec);

         Net.Vpc.Upa.Record ObjectToRecord(object entity, System.Collections.Generic.ISet<string> fields, bool ignoreUnspecified, bool ensureIncludeIds);

         void SetProperty(object entityObject, string property, object @value);

         object GetProperty(object entityObject, string property);

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
         Net.Vpc.Upa.Key IdToKey(object entityId);

        /**
             * transforms record key to a entity id representation of the given record
             * key. Updates to the record are NOT recorded to the provided value and
             * vice versa
             *
             * @param recordKey record key
             * @return key representation
             */
         object KeyToId(Net.Vpc.Upa.Key recordKey);

        /**
             * transforms entity value to a Record value representation of the given
             * entity value. Updates to the record are recorded to the provided value
             * and vice versa
             *
             * @param objectValue entity value
             * @return entityToRecord(r, false)
             * @
             */
         Net.Vpc.Upa.Record ObjectToRecord(object objectValue);

        /**
             * Record value representation of the given entity. updates to the record
             * are recorded to the provided value
             *
             * @param objectValue entity value
             * @param ignoreUnspecified when true primitive number type zeros and
             * boolean type false values are reported as null (not included in record)
             * @return objectToRecord(r, false)
             */
         Net.Vpc.Upa.Record ObjectToRecord(object objectValue, bool ignoreUnspecified);

         object GetMainValue(object objectValue);

          R RecordToObject<R>(Net.Vpc.Upa.Record record);

          R IdToObject<R>(object objectId);

         Net.Vpc.Upa.Record IdToRecord(object objectId);

         object ObjectToId(object objectValue);

         Net.Vpc.Upa.Key ObjectToKey(object objectValue);

         object RecordToId(Net.Vpc.Upa.Record record);

         Net.Vpc.Upa.Key RecordToKey(Net.Vpc.Upa.Record record);

         object KeyToObject(Net.Vpc.Upa.Key key);

         Net.Vpc.Upa.Record KeyToRecord(Net.Vpc.Upa.Key key);

         void SetRecordId(Net.Vpc.Upa.Record record, object id);

         void SetObjectId(object @object, object id);

         Net.Vpc.Upa.Expressions.Expression RecordToExpression(Net.Vpc.Upa.Record record, string alias);

         Net.Vpc.Upa.Expressions.Expression ObjectToExpression(object @object, bool ignoreUnspecified, string alias);

         Net.Vpc.Upa.Expressions.Expression ObjectToIdExpression(object objectOrRecord, string alias);

         Net.Vpc.Upa.Expressions.Expression IdToExpression(object id, string alias);

         Net.Vpc.Upa.Expressions.Expression KeyToExpression(Net.Vpc.Upa.Key recordKey, string alias);

          Net.Vpc.Upa.Expressions.Expression IdListToExpression<K>(System.Collections.Generic.IList<K> idList, string alias);

         Net.Vpc.Upa.Expressions.Expression KeyListToExpression(System.Collections.Generic.IList<Net.Vpc.Upa.Key> keyList, string alias);

         Net.Vpc.Upa.QualifiedRecord CreateQualifiedRecord();

         Net.Vpc.Upa.QualifiedRecord CreateQualifiedRecord(Net.Vpc.Upa.Record record);
    }
}
