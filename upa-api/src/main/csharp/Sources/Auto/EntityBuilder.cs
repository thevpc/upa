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



namespace Net.Vpc.Upa
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/27/12 1:51 AM
     */
    public interface EntityBuilder {

         Net.Vpc.Upa.Document CreateDocument();

         Net.Vpc.Upa.Document CreateInitializedDocument();

          R CreateInitializedObject<R>();

          R CreateObject<R>();

          R CopyObject<R>(R r);

         Net.Vpc.Upa.Document CopyDocument(Net.Vpc.Upa.Document rec);

         Net.Vpc.Upa.Document ObjectToDocument(object entity, System.Collections.Generic.ISet<string> fields, bool ignoreUnspecified, bool ensureIncludeIds);

         void SetProperty(object entityObject, string property, object @value);

         object GetProperty(object entityObject, string property);

         Net.Vpc.Upa.Key CreateKey(params object [] keyValues);

         object CreateId(params object [] idValues);

         object GetId(Net.Vpc.Upa.Key unstructuredKey);

         object GetObject(object objectOrDocument);

         Net.Vpc.Upa.Document GetDocument(object objectOrDocument);

         Net.Vpc.Upa.Key GetKey(object key);

        /**
             * transforms entity id to a Document key representation of the given entity
             * id. Updates to the Document are NOT reflected in the provided value and vice
             * versa
             *
             * @param entityId entity id
             * @return key representation
             */
         Net.Vpc.Upa.Key IdToKey(object entityId);

        /**
             * transforms Document key to a entity id representation of the given Document
             * key. Updates to the Document are NOT reflected in the provided value and
             * vice versa
             *
             * @param documentKey Document key
             * @return key representation
             */
         object KeyToId(Net.Vpc.Upa.Key documentKey);

        /**
             * transforms entity value to a Document value representation of the given
             * entity value. Updates to the Document are reflected in the provided value
             * and vice versa
             *
             * @param objectValue entity value
             * @return entityToDocument(r, false)
             * @
             */
         Net.Vpc.Upa.Document ObjectToDocument(object objectValue);

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
         Net.Vpc.Upa.PrimitiveId IdToPrimitiveId(object id);

         object PrimitiveIdToId(object id);

         Net.Vpc.Upa.PrimitiveId ObjectToPrimitiveId(object @object);

        /**
             * Document value representation of the given entity. updates to the Document
             * are reflected in the provided value
             *
             * @param objectValue       entity value
             * @param ignoreUnspecified when true primitive number type zeros and
             *                          boolean type false values are reported as null (not included in Document)
             * @return objectToDocument(r, false)
             */
         Net.Vpc.Upa.Document ObjectToDocument(object objectValue, bool ignoreUnspecified);

         string ObjectToName(object objectValue);

         Net.Vpc.Upa.NamedId ObjectToNamedId(object objectValue);

         object GetMainValue(object objectValue);

          R DocumentToObject<R>(Net.Vpc.Upa.Document document);

          R IdToObject<R>(object objectId);

         Net.Vpc.Upa.Document IdToDocument(object objectId);

         object ObjectToId(object objectValue);

         Net.Vpc.Upa.Key ObjectToKey(object objectValue);

         object DocumentToId(Net.Vpc.Upa.Document document);

         Net.Vpc.Upa.Key DocumentToKey(Net.Vpc.Upa.Document document);

         object KeyToObject(Net.Vpc.Upa.Key key);

         Net.Vpc.Upa.Document KeyToDocument(Net.Vpc.Upa.Key key);

         void SetDocumentId(Net.Vpc.Upa.Document document, object id);

         void SetObjectId(object @object, object id);

         Net.Vpc.Upa.Expressions.Expression DocumentToExpression(Net.Vpc.Upa.Document document, string alias);

         Net.Vpc.Upa.Expressions.Expression ObjectToExpression(object @object, bool ignoreUnspecified, string alias);

         Net.Vpc.Upa.Expressions.Expression ObjectToIdExpression(object objectOrDocument, string alias);

         Net.Vpc.Upa.Expressions.Expression IdToExpression(object id, string alias);

         Net.Vpc.Upa.Expressions.Expression KeyToExpression(Net.Vpc.Upa.Key documentKey, string alias);

          Net.Vpc.Upa.Expressions.Expression IdListToExpression<K>(System.Collections.Generic.IList<K> idList, string alias);

         Net.Vpc.Upa.Expressions.Expression KeyListToExpression(System.Collections.Generic.IList<Net.Vpc.Upa.Key> keyList, string alias);

         Net.Vpc.Upa.QualifiedDocument CreateQualifiedDocument();

         Net.Vpc.Upa.QualifiedDocument CreateQualifiedDocument(Net.Vpc.Upa.Document document);
    }
}
