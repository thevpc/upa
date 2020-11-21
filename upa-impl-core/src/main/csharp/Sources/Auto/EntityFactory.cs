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
     * @creationdate 8/27/12 1:51 AM
     */
    public interface EntityFactory {

         Net.TheVpc.Upa.Record CreateRecord();

          R CreateObject<R>();

         Net.TheVpc.Upa.Record ObjectToRecord(object @object, System.Collections.Generic.ISet<string> fields, bool ignoreUnspecified, bool ensureIncludeIds);

         void SetProperty(object @object, string property, object @value) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         object GetProperty(object @object, string property) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

        /**
             * transforms object id to a Record key representation of the given object
             * id. Updates to the record are NOT recorded to the provided value and vice
             * versa
             *
             * @param id entity id
             * @return key representation
             */
         Net.TheVpc.Upa.Key IdToKey(object id) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

        /**
             * transforms record key to a object id representation of the given record
             * key. Updates to the record are NOT recorded to the provided value and
             * vice versa
             *
             * @param recordKey record key
             * @return key representation
             */
         object KeyToId(Net.TheVpc.Upa.Key recordKey) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

        /**
             * transforms object value to a Record value representation of the given
             * object value. Updates to the record are recorded to the provided value
             * and vice versa
             *
             * @param object object value
             * @return objectToRecord(r, false)
             * @throws UPAException
             */
         Net.TheVpc.Upa.Record ObjectToRecord(object @object) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

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
         Net.TheVpc.Upa.Record ObjectToRecord(object @object, bool ignoreUnspecified) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         object GetMainProperty(object @object) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

          R RecordToObject<R>(Net.TheVpc.Upa.Record record) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

          R IdToObject<R>(object id) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Record IdToRecord(object id) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         object ObjectToId(object @object) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Key ObjectToKey(object @object) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         object RecordToId(Net.TheVpc.Upa.Record record) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Key RecordToKey(Net.TheVpc.Upa.Record record) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         object KeyToObject(Net.TheVpc.Upa.Key key) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Record KeyToRecord(Net.TheVpc.Upa.Key key) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void SetRecordId(Net.TheVpc.Upa.Record record, object id) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void SetObjectId(object @object, object id) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Expressions.Expression RecordToExpression(Net.TheVpc.Upa.Record record, string alias) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Expressions.Expression ObjectToExpression(object @object, bool ignoreUnspecified, string alias) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Expressions.Expression IdToExpression(object id, string alias) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Expressions.Expression ObjectToIdExpression(object objectOrRecord, string alias) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Expressions.Expression KeyToExpression(Net.TheVpc.Upa.Key recordKey, string alias) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

          Net.TheVpc.Upa.Expressions.Expression IdListToExpression<K>(System.Collections.Generic.IList<K> idList, string alias) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Expressions.Expression KeyListToExpression(System.Collections.Generic.IList<Net.TheVpc.Upa.Key> keyList, string alias) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;
    }
}
