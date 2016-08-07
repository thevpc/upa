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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/27/12 1:51 AM
     */
    public interface EntityFactory {

         Net.Vpc.Upa.Record CreateRecord();

          R CreateObject<R>();

         Net.Vpc.Upa.Record ObjectToRecord(object @object, System.Collections.Generic.ISet<string> fields, bool ignoreUnspecified, bool ensureIncludeIds);

         void SetProperty(object @object, string property, object @value) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         object GetProperty(object @object, string property) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

        /**
             * transforms object id to a Record key representation of the given object
             * id. Updates to the record are NOT recorded to the provided value and vice
             * versa
             *
             * @param id entity id
             * @return key representation
             */
         Net.Vpc.Upa.Key IdToKey(object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

        /**
             * transforms record key to a object id representation of the given record
             * key. Updates to the record are NOT recorded to the provided value and
             * vice versa
             *
             * @param recordKey record key
             * @return key representation
             */
         object KeyToId(Net.Vpc.Upa.Key recordKey) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

        /**
             * transforms object value to a Record value representation of the given
             * object value. Updates to the record are recorded to the provided value
             * and vice versa
             *
             * @param object object value
             * @return objectToRecord(r, false)
             * @throws UPAException
             */
         Net.Vpc.Upa.Record ObjectToRecord(object @object) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

        /**
             * Record value representation of the given entity. updates to the record
             * are recorded to the provided value
             *
             * @param object entity value
             * @param ignoreUnspecified when true primitive number type zeros and
             * boolean type false values are reported as null (not included in record)
             * @return objectToRecord(r, false)
             * @throws UPAException
             */
         Net.Vpc.Upa.Record ObjectToRecord(object @object, bool ignoreUnspecified) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         object GetMainProperty(object @object) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

          R RecordToObject<R>(Net.Vpc.Upa.Record record) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

          R IdToObject<R>(object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Record IdToRecord(object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         object ObjectToId(object @object) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Key ObjectToKey(object @object) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         object RecordToId(Net.Vpc.Upa.Record record) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Key RecordToKey(Net.Vpc.Upa.Record record) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         object KeyToObject(Net.Vpc.Upa.Key key) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Record KeyToRecord(Net.Vpc.Upa.Key key) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void SetRecordId(Net.Vpc.Upa.Record record, object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void SetObjectId(object @object, object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Expressions.Expression RecordToExpression(Net.Vpc.Upa.Record record, string alias) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Expressions.Expression ObjectToExpression(object @object, bool ignoreUnspecified, string alias) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Expressions.Expression IdToExpression(object id, string alias) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Expressions.Expression ObjectToIdExpression(object objectOrRecord, string alias) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Expressions.Expression KeyToExpression(Net.Vpc.Upa.Key recordKey, string alias) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

          Net.Vpc.Upa.Expressions.Expression IdListToExpression<K>(System.Collections.Generic.IList<K> idList, string alias) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Expressions.Expression KeyListToExpression(System.Collections.Generic.IList<Net.Vpc.Upa.Key> keyList, string alias) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;
    }
}
