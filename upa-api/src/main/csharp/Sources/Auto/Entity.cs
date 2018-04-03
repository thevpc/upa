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


    public interface Entity : Net.Vpc.Upa.PersistenceUnitPart {

         Net.Vpc.Upa.EntitySecurityManager GetEntitySecurityManager();

         void SetEntitySecurityManager(Net.Vpc.Upa.EntitySecurityManager securityManager);

         Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> GetUserModifiers();

         void SetUserModifiers(Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> modifiers);

         Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> GetUserExcludeModifiers();

         void SetUserExcludeModifiers(Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> modifiers);

         Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> GetModifiers();

         bool Exists();

         Net.Vpc.Upa.Entity GetParentEntity();

         Net.Vpc.Upa.EntityDescriptor GetEntityDescriptor();

         Net.Vpc.Upa.Relationship GetCompositionRelation();

         System.Collections.Generic.IList<Net.Vpc.Upa.Relationship> GetRelationships();

         System.Collections.Generic.IList<Net.Vpc.Upa.Relationship> GetRelationshipsBySource();

         System.Collections.Generic.IList<Net.Vpc.Upa.Relationship> GetRelationshipsByTarget();

        /**
             * @return true if this entity is its own parent
             */
         bool IsHierarchical();

         string GetParentSecurityAction();

         void SetParentSecurityAction(string parentSecurityAction);

         Net.Vpc.Upa.Index AddIndex(string name, bool unique, params string [] fields);

         System.Collections.Generic.IList<Net.Vpc.Upa.Index> GetIndexes(bool? unique);

         void RemovePart(int index);

         void MovePart(int index, int newIndex);

         void MovePart(string partName, int newIndex);

         System.Collections.Generic.IList<Net.Vpc.Upa.EntityPart> GetParts();

         int IndexOfField(string field);

         int IndexOfPart(Net.Vpc.Upa.EntityPart part);

         int IndexOfPart(string partName);

         int IndexOfPart(string partName, bool countSections, bool countCompoundFields, bool countFieldsInCompoundFields, bool countFieldsInSections);

         System.Collections.Generic.IList<Net.Vpc.Upa.Section> GetSections();

         Net.Vpc.Upa.Section GetSection(string sectionPath);

         Net.Vpc.Upa.Section FindSection(string path);

         Net.Vpc.Upa.Section GetSection(string path, Net.Vpc.Upa.MissingStrategy missingStrategy);

         Net.Vpc.Upa.Section AddSection(string path, int index);

         Net.Vpc.Upa.Section AddSection(string path);

         bool IsInstance(object @object);

         bool IsIdInstance(object @object);

         System.Type GetEntityType();

         System.Type GetIdType();

         bool HasAssociatedView();

         Net.Vpc.Upa.Types.DataType GetDataType();

         bool IsDependentOnEntity(string entityName);

         System.Collections.Generic.ISet<string> GetDependencyEntities();

         Net.Vpc.Upa.Field AddField(Net.Vpc.Upa.FieldDescriptor fieldDescriptor);

         Net.Vpc.Upa.Field AddField(Net.Vpc.Upa.FieldBuilder fieldBuilder);

         Net.Vpc.Upa.Field GetMainField();

         string GetMainFieldValue(object o);

         Net.Vpc.Upa.EntityNavigator GetNavigator();

         void SetNavigator(Net.Vpc.Upa.EntityNavigator navigator);

         int GetFieldsCount();

         bool ContainsField(string fieldName);

         System.Collections.Generic.IList<Net.Vpc.Upa.DynamicField> GetDynamicFields();

         Net.Vpc.Upa.Field GetField(int position);

         Net.Vpc.Upa.Field GetField(string fieldName);

         Net.Vpc.Upa.Field FindField(string fieldName);

         System.Collections.Generic.IList<Net.Vpc.Upa.Field> GetIdFields();

        /**
             * When and id field is ManyToOne Field, it will be flattened
             *
             * @return
             */
         System.Collections.Generic.IList<Net.Vpc.Upa.PrimitiveField> GetIdPrimitiveFields();

         System.Collections.Generic.IList<string> GetFieldNames(Net.Vpc.Upa.Filters.FieldFilter fieldFilter);

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

         long GetEntityCount(Net.Vpc.Upa.Expressions.Expression booleanExpression);

          K NextId<K>();

         void Persist(object objectOrDocument);

         bool Save(object objectOrDocument);

         void Persist(object objectOrDocument, System.Collections.Generic.IDictionary<string , object> hints);

         bool Save(object objectOrDocument, System.Collections.Generic.IDictionary<string , object> hints);

         void Clear();

         void Clear(System.Collections.Generic.IDictionary<string , object> hints);

         Net.Vpc.Upa.Expressions.Expression GetUnicityExpressionForPersist(object entity);

         Net.Vpc.Upa.RemoveTrace Remove(object entity);

         Net.Vpc.Upa.RemoveTrace Remove(Net.Vpc.Upa.RemoveOptions options);

         Net.Vpc.Upa.Field[] ToFieldArray(string[] s);

         bool Contains(object id);

         Net.Vpc.Upa.UpdateQuery CreateUpdateQuery();

         void Update(object objectOrDocument);

         void Merge(object objectOrDocument);

         void UpdateFormulas();

         Net.Vpc.Upa.Expressions.Order GetUpdateFormulasOrder();

         string GetIdName(object id);

         System.Collections.Generic.IList<Net.Vpc.Upa.Field> GetValidFields(params string [] fieldNames);

         System.Collections.Generic.IList<Net.Vpc.Upa.Field> GetFields();

         System.Collections.Generic.IList<Net.Vpc.Upa.Field> GetFields(params string [] fieldNames);

         System.Collections.Generic.IList<Net.Vpc.Upa.Field> GetFields(Net.Vpc.Upa.Filters.FieldFilter filter);

         System.Collections.Generic.IList<Net.Vpc.Upa.Field> GetImmediateFields();

         System.Collections.Generic.IList<Net.Vpc.Upa.Field> GetImmediateFields(Net.Vpc.Upa.Filters.FieldFilter filter);

         Net.Vpc.Upa.Expressions.Order GetArchivingOrder();

         void SetArchivingOrder(Net.Vpc.Upa.Expressions.Order archivingOrder);

         Net.Vpc.Upa.Field GetLeadingIdField();

         System.Collections.Generic.IList<string> GetOrderedFields(string[] fields);

         Net.Vpc.Upa.Expressions.Expression ToIdListExpression(Net.Vpc.Upa.Expressions.Expression e);

         string GetShortName();

         void SetShortName(string shortName);

         string GetShortNameOrName();

         Net.Vpc.Upa.Expressions.Order GetListOrder();

         void SetListOrder(Net.Vpc.Upa.Expressions.Order listOrder);

         System.Collections.Generic.IList<Net.Vpc.Upa.PrimitiveField> GetPrimitiveFields(Net.Vpc.Upa.Filters.FieldFilter fieldFilter);

         Net.Vpc.Upa.PrimitiveField GetPrimitiveField(string fieldName);

         Net.Vpc.Upa.PrimitiveField FindPrimitiveField(string fieldName);

          System.Collections.Generic.IList<Net.Vpc.Upa.PrimitiveField> ToPrimitiveFields<T>(System.Collections.Generic.IList<T> parts) where  T : Net.Vpc.Upa.EntityPart;

         System.Collections.Generic.IList<Net.Vpc.Upa.Field> GetFields(System.Collections.Generic.IList<Net.Vpc.Upa.EntityPart> parts);

         System.Collections.Generic.IList<Net.Vpc.Upa.PrimitiveField> GetPrimitiveFields(params string [] fieldNames);

         Net.Vpc.Upa.EntityBuilder GetBuilder();

         Net.Vpc.Upa.QueryBuilder CreateQueryBuilder();

         Net.Vpc.Upa.Query CreateQuery(Net.Vpc.Upa.Expressions.EntityStatement query);

         Net.Vpc.Upa.Query CreateQuery(string query);

         System.Collections.Generic.IList<Net.Vpc.Upa.Callbacks.Trigger> GetTriggers();

        /**
             * Triggers with VM support (having listener!=null)
             *
             * @return
             * @
             */
         System.Collections.Generic.IList<Net.Vpc.Upa.Callbacks.Trigger> GetSoftTriggers();

         void AddExtensionDefinition(System.Type extensionType, Net.Vpc.Upa.Extensions.EntityExtensionDefinition extensionObject);

         void RemoveExtensionDefinition(System.Type extensionType, Net.Vpc.Upa.Extensions.EntityExtensionDefinition extensionObject);

         System.Collections.Generic.IList<Net.Vpc.Upa.Extensions.EntityExtensionDefinition> GetExtensionDefinitions();

          System.Collections.Generic.IList<S> GetExtensionDefinitions<S>(System.Type type) where  S : Net.Vpc.Upa.Extensions.EntityExtensionDefinition;

         System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.EntityExtension> GetExtensions();

          System.Collections.Generic.IList<S> GetExtensions<S>(System.Type type) where  S : Net.Vpc.Upa.Persistence.EntityExtension;

          S GetExtension<S>(System.Type type) where  S : Net.Vpc.Upa.Persistence.EntityExtension;

         Net.Vpc.Upa.Persistence.EntityOperationManager GetEntityOperationManager();

         Net.Vpc.Upa.EntityShield GetShield();

         void SetShield(Net.Vpc.Upa.EntityShield shield);

         Net.Vpc.Upa.Expressions.Expression ChildToParentExpression(Net.Vpc.Upa.Document child);

         Net.Vpc.Upa.Expressions.Expression ChildToParentExpression(Net.Vpc.Upa.Expressions.Expression childExpression);

         Net.Vpc.Upa.Expressions.Expression ParentToChildExpression(Net.Vpc.Upa.Expressions.Expression parentExpression);

         Net.Vpc.Upa.Key CreateKey(params object [] keyValues);

         object CreateId(params object [] keyValues);

         Net.Vpc.Upa.Document CreateDocument();

          R CreateObject<R>();

        /**
             * adds anonymous trigger
             *
             * @param trigger
             * @return
             * @
             */
         Net.Vpc.Upa.Callbacks.Trigger AddTrigger(Net.Vpc.Upa.Callbacks.EntityInterceptor trigger);

         Net.Vpc.Upa.Callbacks.Trigger AddTrigger(string name, Net.Vpc.Upa.Callbacks.EntityInterceptor trigger);

         void RemoveTrigger(string triggerName);

         void AddDefinitionListener(Net.Vpc.Upa.Callbacks.DefinitionListener definitionListener);

         void RemoveDefinitionListener(Net.Vpc.Upa.Callbacks.DefinitionListener definitionListener);

         object Compile(Net.Vpc.Upa.Expressions.Expression expression, string alias);

         void AddFilter(string name, string expression);

         void AddFilter(string name, Net.Vpc.Upa.Expressions.Expression expression);

         Net.Vpc.Upa.Expressions.Expression GetFilter(string name);

         void RemoveFilter(string name);

         System.Collections.Generic.ISet<string> GetFilterNames();

         bool IsSystem();

         void Initialize();

         void Initialize(System.Collections.Generic.IDictionary<string , object> hints);

         void CommitModelChanges();

         void CommitStructureModification(Net.Vpc.Upa.Persistence.PersistenceStore persistenceUnitManager);

         void AddDependencyOnEntity(string entityName);

          T FindById<T>(object id);

         bool ExistsById(object id);

          T FindByMainField<T>(object mainFieldValue);

          T FindByField<T>(string fieldName, object mainFieldValue);

          System.Collections.Generic.IList<T> FindAll<T>();

          System.Collections.Generic.IList<T> FindAllIds<T>();

         System.Collections.Generic.IList<Net.Vpc.Upa.Document> FindAllDocuments();

         Net.Vpc.Upa.PlatformBeanType GetPlatformBeanType();

         Net.Vpc.Upa.EntityInfo GetInfo();
    }
}
