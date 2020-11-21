/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.TheVpc.Upa
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/27/12 1:51 AM
     */
    public interface EntityBuilder {

         Net.TheVpc.Upa.Document CreateDocument();

         Net.TheVpc.Upa.Document CreateInitializedDocument();

          R CreateInitializedObject<R>();

          R CreateObject<R>();

          R CopyObject<R>(R r);

         Net.TheVpc.Upa.Document CopyDocument(Net.TheVpc.Upa.Document rec);

         Net.TheVpc.Upa.Document ObjectToDocument(object entity, System.Collections.Generic.ISet<string> fields, bool ignoreUnspecified, bool ensureIncludeIds);

         void SetProperty(object entityObject, string property, object @value);

         object GetProperty(object entityObject, string property);

         Net.TheVpc.Upa.Key CreateKey(params object [] keyValues);

         object CreateId(params object [] idValues);

         object GetId(Net.TheVpc.Upa.Key unstructuredKey);

         object GetObject(object objectOrDocument);

         Net.TheVpc.Upa.Document GetDocument(object objectOrDocument);

         Net.TheVpc.Upa.Key GetKey(object key);

        /**
             * transforms entity id to a Document key representation of the given entity
             * id. Updates to the Document are NOT reflected in the provided value and vice
             * versa
             *
             * @param entityId entity id
             * @return key representation
             */
         Net.TheVpc.Upa.Key IdToKey(object entityId);

        /**
             * transforms Document key to a entity id representation of the given Document
             * key. Updates to the Document are NOT reflected in the provided value and
             * vice versa
             *
             * @param documentKey Document key
             * @return key representation
             */
         object KeyToId(Net.TheVpc.Upa.Key documentKey);

        /**
             * transforms entity value to a Document value representation of the given
             * entity value. Updates to the Document are reflected in the provided value
             * and vice versa
             *
             * @param objectValue entity value
             * @return entityToDocument(r, false)
             * @
             */
         Net.TheVpc.Upa.Document ObjectToDocument(object objectValue);

        /**
             * transforms id to PrimitiveId
             * PrimitiveId is a representation of the Entity's Id where
             * all Relationships composing the Id/Primary key are flattened
             * to primitive fields and values
             *
             * @param id entity value
             * @return entityToDocument(r, false)
             * @
             */
         Net.TheVpc.Upa.PrimitiveId IdToPrimitiveId(object id);

         object PrimitiveIdToId(object id);

         Net.TheVpc.Upa.PrimitiveId ObjectToPrimitiveId(object @object);

        /**
             * Document value representation of the given entity. updates to the Document
             * are reflected in the provided value
             *
             * @param objectValue       entity value
             * @param ignoreUnspecified when true primitive number type zeros and
             *                          boolean type false values are reported as null (not included in Document)
             * @return objectToDocument(r, false)
             */
         Net.TheVpc.Upa.Document ObjectToDocument(object objectValue, bool ignoreUnspecified);

         string ObjectToName(object objectValue);

         Net.TheVpc.Upa.NamedId ObjectToNamedId(object objectValue);

         object GetMainValue(object objectValue);

          R DocumentToObject<R>(Net.TheVpc.Upa.Document document);

          R IdToObject<R>(object objectId);

         Net.TheVpc.Upa.Document IdToDocument(object objectId);

         object ObjectToId(object objectValue);

         Net.TheVpc.Upa.Key ObjectToKey(object objectValue);

         object DocumentToId(Net.TheVpc.Upa.Document document);

         Net.TheVpc.Upa.Key DocumentToKey(Net.TheVpc.Upa.Document document);

         object KeyToObject(Net.TheVpc.Upa.Key key);

         Net.TheVpc.Upa.Document KeyToDocument(Net.TheVpc.Upa.Key key);

         void SetDocumentId(Net.TheVpc.Upa.Document document, object id);

         void SetObjectId(object @object, object id);

         Net.TheVpc.Upa.Expressions.Expression DocumentToExpression(Net.TheVpc.Upa.Document document, string alias);

         Net.TheVpc.Upa.Expressions.Expression ObjectToExpression(object @object, bool ignoreUnspecified, string alias);

         Net.TheVpc.Upa.Expressions.Expression ObjectToIdExpression(object objectOrDocument, string alias);

         Net.TheVpc.Upa.Expressions.Expression IdToExpression(object id, string alias);

         Net.TheVpc.Upa.Expressions.Expression KeyToExpression(Net.TheVpc.Upa.Key documentKey, string alias);

          Net.TheVpc.Upa.Expressions.Expression IdListToExpression<K>(System.Collections.Generic.IList<K> idList, string alias);

         Net.TheVpc.Upa.Expressions.Expression KeyListToExpression(System.Collections.Generic.IList<Net.TheVpc.Upa.Key> keyList, string alias);

         Net.TheVpc.Upa.QualifiedDocument CreateQualifiedDocument();

         Net.TheVpc.Upa.QualifiedDocument CreateQualifiedDocument(Net.TheVpc.Upa.Document document);
    }
}
