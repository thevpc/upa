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


    public interface Entity : Net.TheVpc.Upa.PersistenceUnitPart {

         Net.TheVpc.Upa.EntitySecurityManager GetEntitySecurityManager();

         void SetEntitySecurityManager(Net.TheVpc.Upa.EntitySecurityManager securityManager);

         Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.EntityModifier> GetUserModifiers();

         void SetUserModifiers(Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.EntityModifier> modifiers);

         Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.EntityModifier> GetUserExcludeModifiers();

         void SetUserExcludeModifiers(Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.EntityModifier> modifiers);

         Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.EntityModifier> GetModifiers();

         bool Exists();

         Net.TheVpc.Upa.Entity GetParentEntity();

         Net.TheVpc.Upa.EntityDescriptor GetEntityDescriptor();

         Net.TheVpc.Upa.Relationship GetCompositionRelation();

         System.Collections.Generic.IList<Net.TheVpc.Upa.Relationship> GetRelationships();

         System.Collections.Generic.IList<Net.TheVpc.Upa.Relationship> GetRelationshipsBySource();

         System.Collections.Generic.IList<Net.TheVpc.Upa.Relationship> GetRelationshipsByTarget();

        /**
             * @return true if this entity is its own parent
             */
         bool IsHierarchical();

         string GetParentSecurityAction();

         void SetParentSecurityAction(string parentSecurityAction);

         Net.TheVpc.Upa.Index AddIndex(string name, bool unique, params string [] fields);

         System.Collections.Generic.IList<Net.TheVpc.Upa.Index> GetIndexes(bool? unique);

         void RemovePart(int index);

         void MovePart(int index, int newIndex);

         void MovePart(string partName, int newIndex);

         System.Collections.Generic.IList<Net.TheVpc.Upa.EntityPart> GetParts();

         int IndexOfField(string field);

         int IndexOfPart(Net.TheVpc.Upa.EntityPart part);

         int IndexOfPart(string partName);

         int IndexOfPart(string partName, bool countSections, bool countCompoundFields, bool countFieldsInCompoundFields, bool countFieldsInSections);

         System.Collections.Generic.IList<Net.TheVpc.Upa.Section> GetSections();

         Net.TheVpc.Upa.Section GetSection(string sectionPath);

         Net.TheVpc.Upa.Section FindSection(string path);

         Net.TheVpc.Upa.Section GetSection(string path, Net.TheVpc.Upa.MissingStrategy missingStrategy);

         Net.TheVpc.Upa.Section AddSection(string path, int index);

         Net.TheVpc.Upa.Section AddSection(string path);

         bool IsInstance(object @object);

         bool IsIdInstance(object @object);

         System.Type GetEntityType();

         System.Type GetIdType();

         bool HasAssociatedView();

         Net.TheVpc.Upa.Types.DataType GetDataType();

         bool IsDependentOnEntity(string entityName);

         System.Collections.Generic.ISet<string> GetDependencyEntities();

         Net.TheVpc.Upa.Field AddField(Net.TheVpc.Upa.FieldDescriptor fieldDescriptor);

         Net.TheVpc.Upa.Field AddField(Net.TheVpc.Upa.FieldBuilder fieldBuilder);

         Net.TheVpc.Upa.Field GetMainField();

         string GetMainFieldValue(object o);

         Net.TheVpc.Upa.EntityNavigator GetNavigator();

         void SetNavigator(Net.TheVpc.Upa.EntityNavigator navigator);

         int GetFieldsCount();

         bool ContainsField(string fieldName);

         System.Collections.Generic.IList<Net.TheVpc.Upa.DynamicField> GetDynamicFields();

         Net.TheVpc.Upa.Field GetField(int position);

         Net.TheVpc.Upa.Field GetField(string fieldName);

         Net.TheVpc.Upa.Field FindField(string fieldName);

         System.Collections.Generic.IList<Net.TheVpc.Upa.Field> GetIdFields();

        /**
             * When and id field is ManyToOne Field, it will be flattened
             *
             * @return
             */
         System.Collections.Generic.IList<Net.TheVpc.Upa.PrimitiveField> GetIdPrimitiveFields();

         System.Collections.Generic.IList<string> GetFieldNames(Net.TheVpc.Upa.Filters.FieldFilter fieldFilter);

         object CloneDocument(object oldId, object newId);

         object Rename(object oldId, object newId);

         object Rename(object oldId, object newId, System.Collections.Generic.IDictionary<string , object> hints);

         object GetNextId(object id);

         object GetFirstId();

         object GetLastId();

         object GetPreviousId(object id);

         bool HasNext(object id);

         bool HasPrevious(object id);

         bool IsEmpty();

         long GetEntityCount();

         long GetEntityCount(Net.TheVpc.Upa.Expressions.Expression booleanExpression);

          K NextId<K>();

         void Persist(object objectOrDocument);

         bool Save(object objectOrDocument);

         void Persist(object objectOrDocument, System.Collections.Generic.IDictionary<string , object> hints);

         bool Save(object objectOrDocument, System.Collections.Generic.IDictionary<string , object> hints);

         void Clear();

         void Clear(System.Collections.Generic.IDictionary<string , object> hints);

         Net.TheVpc.Upa.Expressions.Expression GetUnicityExpressionForPersist(object entity);

         Net.TheVpc.Upa.RemoveTrace Remove(object entity);

         Net.TheVpc.Upa.RemoveTrace Remove(Net.TheVpc.Upa.RemoveOptions options);

         Net.TheVpc.Upa.Field[] ToFieldArray(string[] s);

         bool Contains(object id);

         Net.TheVpc.Upa.UpdateQuery CreateUpdateQuery();

         void Update(object objectOrDocument);

         void Merge(object objectOrDocument);

         void UpdateFormulas();

         Net.TheVpc.Upa.Expressions.Order GetUpdateFormulasOrder();

         string GetIdName(object id);

         System.Collections.Generic.IList<Net.TheVpc.Upa.Field> GetValidFields(params string [] fieldNames);

         System.Collections.Generic.IList<Net.TheVpc.Upa.Field> GetFields();

         System.Collections.Generic.IList<Net.TheVpc.Upa.Field> GetFields(params string [] fieldNames);

         System.Collections.Generic.IList<Net.TheVpc.Upa.Field> GetFields(Net.TheVpc.Upa.Filters.FieldFilter filter);

         System.Collections.Generic.IList<Net.TheVpc.Upa.Field> GetImmediateFields();

         System.Collections.Generic.IList<Net.TheVpc.Upa.Field> GetImmediateFields(Net.TheVpc.Upa.Filters.FieldFilter filter);

         Net.TheVpc.Upa.Expressions.Order GetArchivingOrder();

         void SetArchivingOrder(Net.TheVpc.Upa.Expressions.Order archivingOrder);

         Net.TheVpc.Upa.Field GetLeadingIdField();

         System.Collections.Generic.IList<string> GetOrderedFields(string[] fields);

         Net.TheVpc.Upa.Expressions.Expression ToIdListExpression(Net.TheVpc.Upa.Expressions.Expression e);

         string GetShortName();

         void SetShortName(string shortName);

         string GetShortNameOrName();

         Net.TheVpc.Upa.Expressions.Order GetListOrder();

         void SetListOrder(Net.TheVpc.Upa.Expressions.Order listOrder);

         System.Collections.Generic.IList<Net.TheVpc.Upa.PrimitiveField> GetPrimitiveFields(Net.TheVpc.Upa.Filters.FieldFilter fieldFilter);

         Net.TheVpc.Upa.PrimitiveField GetPrimitiveField(string fieldName);

         Net.TheVpc.Upa.PrimitiveField FindPrimitiveField(string fieldName);

          System.Collections.Generic.IList<Net.TheVpc.Upa.PrimitiveField> ToPrimitiveFields<T>(System.Collections.Generic.IList<T> parts) where  T : Net.TheVpc.Upa.EntityPart;

         System.Collections.Generic.IList<Net.TheVpc.Upa.Field> GetFields(System.Collections.Generic.IList<Net.TheVpc.Upa.EntityPart> parts);

         System.Collections.Generic.IList<Net.TheVpc.Upa.PrimitiveField> GetPrimitiveFields(params string [] fieldNames);

         Net.TheVpc.Upa.EntityBuilder GetBuilder();

         Net.TheVpc.Upa.QueryBuilder CreateQueryBuilder();

         Net.TheVpc.Upa.Query CreateQuery(Net.TheVpc.Upa.Expressions.EntityStatement query);

         Net.TheVpc.Upa.Query CreateQuery(string query);

         System.Collections.Generic.IList<Net.TheVpc.Upa.Callbacks.Trigger> GetTriggers();

        /**
             * Triggers with VM support (having listener!=null)
             *
             * @return
             * @
             */
         System.Collections.Generic.IList<Net.TheVpc.Upa.Callbacks.Trigger> GetSoftTriggers();

         void AddExtensionDefinition(System.Type extensionType, Net.TheVpc.Upa.Extensions.EntityExtensionDefinition extensionObject);

         void RemoveExtensionDefinition(System.Type extensionType, Net.TheVpc.Upa.Extensions.EntityExtensionDefinition extensionObject);

         System.Collections.Generic.IList<Net.TheVpc.Upa.Extensions.EntityExtensionDefinition> GetExtensionDefinitions();

          System.Collections.Generic.IList<S> GetExtensionDefinitions<S>(System.Type type) where  S : Net.TheVpc.Upa.Extensions.EntityExtensionDefinition;

         System.Collections.Generic.IList<Net.TheVpc.Upa.Persistence.EntityExtension> GetExtensions();

          System.Collections.Generic.IList<S> GetExtensions<S>(System.Type type) where  S : Net.TheVpc.Upa.Persistence.EntityExtension;

          S GetExtension<S>(System.Type type) where  S : Net.TheVpc.Upa.Persistence.EntityExtension;

         Net.TheVpc.Upa.Persistence.EntityOperationManager GetEntityOperationManager();

         Net.TheVpc.Upa.EntityShield GetShield();

         void SetShield(Net.TheVpc.Upa.EntityShield shield);

         Net.TheVpc.Upa.Expressions.Expression ChildToParentExpression(Net.TheVpc.Upa.Document child);

         Net.TheVpc.Upa.Expressions.Expression ChildToParentExpression(Net.TheVpc.Upa.Expressions.Expression childExpression);

         Net.TheVpc.Upa.Expressions.Expression ParentToChildExpression(Net.TheVpc.Upa.Expressions.Expression parentExpression);

         Net.TheVpc.Upa.Key CreateKey(params object [] keyValues);

         object CreateId(params object [] keyValues);

         Net.TheVpc.Upa.Document CreateDocument();

          R CreateObject<R>();

        /**
             * adds anonymous trigger
             *
             * @param trigger
             * @return
             * @
             */
         Net.TheVpc.Upa.Callbacks.Trigger AddTrigger(Net.TheVpc.Upa.Callbacks.EntityInterceptor trigger);

         Net.TheVpc.Upa.Callbacks.Trigger AddTrigger(string name, Net.TheVpc.Upa.Callbacks.EntityInterceptor trigger);

         void RemoveTrigger(string triggerName);

         void AddDefinitionListener(Net.TheVpc.Upa.Callbacks.DefinitionListener definitionListener);

         void RemoveDefinitionListener(Net.TheVpc.Upa.Callbacks.DefinitionListener definitionListener);

         object Compile(Net.TheVpc.Upa.Expressions.Expression expression, string alias);

         void AddFilter(string name, string expression);

         void AddFilter(string name, Net.TheVpc.Upa.Expressions.Expression expression);

         Net.TheVpc.Upa.Expressions.Expression GetFilter(string name);

         void RemoveFilter(string name);

         System.Collections.Generic.ISet<string> GetFilterNames();

         bool IsSystem();

         void Initialize();

         void Initialize(System.Collections.Generic.IDictionary<string , object> hints);

         void CommitModelChanges();

         void CommitStructureModification(Net.TheVpc.Upa.Persistence.PersistenceStore persistenceUnitManager);

         void AddDependencyOnEntity(string entityName);

          T FindById<T>(object id);

         bool ExistsById(object id);

          T FindByMainField<T>(object mainFieldValue);

          T FindByField<T>(string fieldName, object mainFieldValue);

          System.Collections.Generic.IList<T> FindAll<T>();

          System.Collections.Generic.IList<T> FindAllIds<T>();

         System.Collections.Generic.IList<Net.TheVpc.Upa.Document> FindAllDocuments();

         Net.TheVpc.Upa.PlatformBeanType GetPlatformBeanType();

         Net.TheVpc.Upa.EntityInfo GetInfo();
    }
}
