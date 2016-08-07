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


    public interface Entity : Net.Vpc.Upa.PersistenceUnitPart {

         void SetEntitySecurityManager(Net.Vpc.Upa.EntitySecurityManager securityManager);

         Net.Vpc.Upa.EntitySecurityManager GetEntitySecurityManager();

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

         Net.Vpc.Upa.Section AddSection(string name, string parentPath);

         Net.Vpc.Upa.Section AddSection(string name, string parentPath, int index);

         Net.Vpc.Upa.Section AddSection(string name, int index);

         Net.Vpc.Upa.Section AddSection(string name);

         System.Type GetEntityType();

         System.Type GetIdType();

         bool NeedsView();

         Net.Vpc.Upa.Types.DataType GetDataType();

         void SetDataType(Net.Vpc.Upa.Types.DataType newDataType);

         bool IsDependentOnEntity(string entityName);

         System.Collections.Generic.ISet<string> GetDependencyEntities();

         Net.Vpc.Upa.Field AddField(Net.Vpc.Upa.FieldDescriptor fieldDescriptor);

         Net.Vpc.Upa.Field AddField(string name, string sectionPath, Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> modifiers, object defaultValue, Net.Vpc.Upa.Types.DataType type);

         Net.Vpc.Upa.Field AddField(string name, string sectionPath, Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> modifiers, Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> excludeModifiers, object defaultValue, Net.Vpc.Upa.Types.DataType type, int index);

         Net.Vpc.Upa.Field GetMainField();

         string GetMainFieldValue(object o);

         Net.Vpc.Upa.EntityNavigator GetNavigator();

         void SetNavigator(Net.Vpc.Upa.EntityNavigator newNavigator);

         int GetFieldsCount();

         bool ContainsField(string key);

         System.Collections.Generic.IList<Net.Vpc.Upa.DynamicField> GetDynamicFields();

         Net.Vpc.Upa.Field GetField(int position);

         Net.Vpc.Upa.Field GetField(string fieldName);

         Net.Vpc.Upa.Field FindField(string fieldName);

         System.Collections.Generic.IList<Net.Vpc.Upa.Field> GetPrimaryFields();

         System.Collections.Generic.IList<string> GetFieldNames(Net.Vpc.Upa.Filters.FieldFilter fieldFilter);

         object CloneRecord(object oldId, object newId);

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

         void Persist(object objectOrRecord);

         bool Save(object objectOrRecord);

         void Persist(object objectOrRecord, System.Collections.Generic.IDictionary<string , object> hints);

         bool Save(object objectOrRecord, System.Collections.Generic.IDictionary<string , object> hints);

         void Clear();

         void Clear(System.Collections.Generic.IDictionary<string , object> hints);

         Net.Vpc.Upa.Expressions.Expression GetUnicityExpressionForPersist(object entity);

         Net.Vpc.Upa.RemoveTrace Remove(object entity);

         Net.Vpc.Upa.RemoveTrace Remove(Net.Vpc.Upa.RemoveOptions options);

         Net.Vpc.Upa.Field[] ToFieldArray(string[] s);

         bool Contains(object id);

         Net.Vpc.Upa.UpdateQuery CreateUpdateQuery();

         void Update(object objectOrRecord);

         void Merge(object objectOrRecord);

         void UpdateFormulas();

         Net.Vpc.Upa.Expressions.Order GetUpdateFormulasOrder();

         string GetIdName(object id);

         System.Collections.Generic.IList<Net.Vpc.Upa.Field> GetValidFields(params string [] fieldNames);

         System.Collections.Generic.IList<Net.Vpc.Upa.Field> GetFields();

         System.Collections.Generic.IList<Net.Vpc.Upa.Field> GetFields(params string [] fieldNames);

         System.Collections.Generic.IList<Net.Vpc.Upa.Field> GetFields(Net.Vpc.Upa.Filters.FieldFilter filter);

         Net.Vpc.Upa.Expressions.Order GetArchivingOrder();

         Net.Vpc.Upa.Field GetLeadingPrimaryField();

         System.Collections.Generic.IList<string> GetOrderedFields(string[] fields);

         Net.Vpc.Upa.Expressions.Expression ToIdListExpression(Net.Vpc.Upa.Expressions.Expression e);

         string GetShortName();

         void SetShortName(string shortName);

         string GetShortNameOrName();

         Net.Vpc.Upa.Expressions.Order GetListOrder();

         void SetListOrder(Net.Vpc.Upa.Expressions.Order listOrder);

         void SetArchivingOrder(Net.Vpc.Upa.Expressions.Order archivingOrder);

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

         Net.Vpc.Upa.Expressions.Expression ChildToParentExpression(Net.Vpc.Upa.Record child);

         Net.Vpc.Upa.Expressions.Expression ChildToParentExpression(Net.Vpc.Upa.Expressions.Expression childExpression);

         Net.Vpc.Upa.Expressions.Expression ParentToChildExpression(Net.Vpc.Upa.Expressions.Expression parentExpression);

         Net.Vpc.Upa.Key CreateKey(params object [] keyValues);

         object CreateId(params object [] keyValues);

         Net.Vpc.Upa.Record CreateRecord();

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

         int UpdateCore(Net.Vpc.Upa.Record updates, Net.Vpc.Upa.Expressions.Expression condition, Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext);

         void PersistCore(Net.Vpc.Upa.Record values, Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext);

         int RemoveCore(Net.Vpc.Upa.Expressions.Expression condition, bool recurse, Net.Vpc.Upa.RemoveTrace deleteInfo, Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext);

         int ClearCore(Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext);

         int InitializeCore(Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext);

         object Compile(Net.Vpc.Upa.Expressions.Expression expression);

         void AddFilter(string name, string expression);

         void AddFilter(string name, Net.Vpc.Upa.Expressions.Expression expression);

         Net.Vpc.Upa.Expressions.Expression GetFilter(string name);

         void RemoveFilter(string name);

         System.Collections.Generic.ISet<string> GetFilterNames();

         bool IsSystem();

         void SetModifiers(Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> modifiers);

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

         System.Collections.Generic.IList<Net.Vpc.Upa.Record> FindAllRecords();

         Net.Vpc.Upa.BeanType GetBeanType();
    }
}
