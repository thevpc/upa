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

         void SetEntitySecurityManager(Net.Vpc.Upa.EntitySecurityManager securityManager) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.EntitySecurityManager GetEntitySecurityManager() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> GetUserModifiers() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void SetUserModifiers(Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> modifiers) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> GetUserExcludeModifiers() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void SetUserExcludeModifiers(Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> modifiers) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> GetModifiers() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool Exists() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Entity GetParentEntity() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.EntityDescriptor GetEntityDescriptor() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Relationship GetCompositionRelation() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.Relationship> GetRelationships() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         string GetParentSecurityAction() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void SetParentSecurityAction(string parentSecurityAction) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Index AddIndex(string name, bool unique, params string [] fields) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.Index> GetIndexes(bool? unique) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void RemovePart(int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void MovePart(int index, int newIndex) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void MovePart(string partName, int newIndex) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.EntityPart> GetParts() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         int IndexOfField(string field) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         int IndexOfPart(Net.Vpc.Upa.EntityPart part) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         int IndexOfPart(string partName) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         int IndexOfPart(string partName, bool countSections, bool countCompoundFields, bool countFieldsInCompoundFields, bool countFieldsInSections) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.Section> GetSections() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Section GetSection(string sectionPath) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Section FindSection(string path) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Section GetSection(string path, Net.Vpc.Upa.MissingStrategy missingStrategy) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Section AddSection(string name, string parentPath) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Section AddSection(string name, string parentPath, int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Section AddSection(string name, int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Section AddSection(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Type GetEntityType() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Type GetIdType() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool NeedsView() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Types.DataType GetDataType() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void SetDataType(Net.Vpc.Upa.Types.DataType newDataType) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsDependentOnEntity(string entityName);

         System.Collections.Generic.ISet<string> GetDependencyEntities() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Field AddField(Net.Vpc.Upa.FieldDescriptor fieldDescriptor) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Field AddField(string name, string sectionPath, Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> modifiers, object defaultValue, Net.Vpc.Upa.Types.DataType type) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Field AddField(string name, string sectionPath, Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> modifiers, Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> excludeModifiers, object defaultValue, Net.Vpc.Upa.Types.DataType type, int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Field GetMainField() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         string GetMainFieldValue(object o) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.EntityNavigator GetNavigator() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void SetNavigator(Net.Vpc.Upa.EntityNavigator newNavigator);

         int GetFieldsCount() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool ContainsField(string key) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.DynamicField> GetDynamicFields() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Field GetField(int position) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Field GetField(string fieldName) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Field FindField(string fieldName) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.Field> GetPrimaryFields() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<string> GetFieldNames(Net.Vpc.Upa.Filters.FieldFilter fieldFilter) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         object CloneRecord(object oldId, object newId) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         object Rename(object oldId, object newId) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         object GetNextId(object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         object GetFirstId() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         object GetLastId() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         object GetPreviousId(object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool HasNext(object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool HasPrevious(object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsEmpty() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         long GetEntityCount() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         long GetEntityCount(Net.Vpc.Upa.Expressions.Expression booleanExpression) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

          K NextId<K>() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void Persist(object objectOrRecord) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool Save(object objectOrRecord) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void Clear() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Expressions.Expression GetUnicityExpressionForPersist(object entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.RemoveTrace Remove(object entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.RemoveTrace Remove(Net.Vpc.Upa.RemoveOptions options) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Field[] ToFieldArray(string[] s) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool Contains(object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void Update(object objectOrRecord) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void Merge(object objectOrRecord) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void UpdatePartial(object objectOrRecord) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void UpdatePartial(object objectOrRecord, object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void UpdateRecord(Net.Vpc.Upa.Record record, Net.Vpc.Upa.Key key) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         int UpdateRecords(Net.Vpc.Upa.Record record, Net.Vpc.Upa.Expressions.Expression condition) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void UpdateFormulas(Net.Vpc.Upa.Filters.FieldFilter filter, Net.Vpc.Upa.Expressions.Expression expr) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void UpdateFormulasById(Net.Vpc.Upa.Filters.FieldFilter filter, object key) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void UpdateFormulas() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void UpdateFormulasById(object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void UpdateFormulas(Net.Vpc.Upa.Expressions.Expression condition) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Expressions.Order GetUpdateFormulasOrder();

         string GetIdName(object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.Field> GetValidFields(params string [] fieldNames) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.Field> GetFields(params string [] fieldNames) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.Field> GetFields(Net.Vpc.Upa.Filters.FieldFilter filter) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Expressions.Order GetArchivingOrder();

         Net.Vpc.Upa.Field GetLeadingPrimaryField() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<string> GetOrderedFields(string[] fields) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Expressions.Expression SimplifyExpression(Net.Vpc.Upa.Expressions.Expression e) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         string GetShortName() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void SetShortName(string shortName) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         string GetShortNameOrName() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Expressions.Order GetListDefaultOrder() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void SetListDefaultOrder(Net.Vpc.Upa.Expressions.Order listDefaultOrder) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.PrimitiveField> GetPrimitiveFields(Net.Vpc.Upa.Filters.FieldFilter fieldFilter) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.PrimitiveField GetPrimitiveField(string fieldName) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.PrimitiveField FindPrimitiveField(string fieldName) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

          System.Collections.Generic.IList<Net.Vpc.Upa.PrimitiveField> ToPrimitiveFields<T>(System.Collections.Generic.IList<T> parts) /* throws Net.Vpc.Upa.Exceptions.UPAException */  where  T : Net.Vpc.Upa.EntityPart;

         System.Collections.Generic.IList<Net.Vpc.Upa.Field> GetFields(System.Collections.Generic.IList<Net.Vpc.Upa.EntityPart> parts) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.PrimitiveField> GetPrimitiveFields(params string [] fieldNames) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.EntityBuilder GetBuilder() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.QueryBuilder CreateQueryBuilder() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Query CreateQuery(Net.Vpc.Upa.Expressions.EntityStatement query) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Query CreateQuery(string query) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.Callbacks.Trigger> GetTriggers() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

        /**
             * Triggers with VM support (having listener!=null)
             *
             * @return
             * @throws UPAException
             */
         System.Collections.Generic.IList<Net.Vpc.Upa.Callbacks.Trigger> GetSoftTriggers() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void AddExtensionDefinition(System.Type extensionType, Net.Vpc.Upa.Extensions.EntityExtensionDefinition extensionObject) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void RemoveExtensionDefinition(System.Type extensionType, Net.Vpc.Upa.Extensions.EntityExtensionDefinition extensionObject);

         System.Collections.Generic.IList<Net.Vpc.Upa.Extensions.EntityExtensionDefinition> GetExtensionDefinitions();

          System.Collections.Generic.IList<S> GetExtensionDefinitions<S>(System.Type type) where  S : Net.Vpc.Upa.Extensions.EntityExtensionDefinition;

         System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.EntityExtension> GetExtensions();

          System.Collections.Generic.IList<S> GetExtensions<S>(System.Type type) where  S : Net.Vpc.Upa.Persistence.EntityExtension;

          S GetExtension<S>(System.Type type) /* throws Net.Vpc.Upa.Exceptions.UPAException */  where  S : Net.Vpc.Upa.Persistence.EntityExtension;

         Net.Vpc.Upa.Persistence.EntityOperationManager GetEntityOperationManager();

         Net.Vpc.Upa.EntityShield GetShield();

         void SetShield(Net.Vpc.Upa.EntityShield shield) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Expressions.Expression ChildToParentExpression(Net.Vpc.Upa.Record child) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Expressions.Expression ChildToParentExpression(Net.Vpc.Upa.Expressions.Expression childExpression) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Expressions.Expression ParentToChildExpression(Net.Vpc.Upa.Expressions.Expression parentExpression) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Key CreateKey(params object [] keyValues) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         object CreateId(params object [] keyValues) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Record CreateRecord() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

          R CreateEntity<R>() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

        /**
             * adds anonymous trigger
             *
             * @param trigger
             * @return
             * @throws UPAException
             */
         Net.Vpc.Upa.Callbacks.Trigger AddTrigger(Net.Vpc.Upa.Callbacks.EntityInterceptor trigger) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Callbacks.Trigger AddTrigger(string name, Net.Vpc.Upa.Callbacks.EntityInterceptor trigger) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void RemoveTrigger(string triggerName) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void AddDefinitionListener(Net.Vpc.Upa.Callbacks.DefinitionListener definitionListener) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void RemoveDefinitionListener(Net.Vpc.Upa.Callbacks.DefinitionListener definitionListener) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         int UpdateCore(Net.Vpc.Upa.Record updates, Net.Vpc.Upa.Expressions.Expression condition, Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void PersistCore(Net.Vpc.Upa.Record values, Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         int RemoveCore(Net.Vpc.Upa.Expressions.Expression condition, bool recurse, Net.Vpc.Upa.RemoveTrace deleteInfo, Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         int ClearCore(Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         int InitializeCore(Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void UpdateFormulasCore(Net.Vpc.Upa.Filters.FieldFilter filter, Net.Vpc.Upa.Expressions.Expression expr, Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         object Compile(Net.Vpc.Upa.Expressions.Expression expression) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void AddFilter(string name, string expression) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void AddFilter(string name, Net.Vpc.Upa.Expressions.Expression expression) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Expressions.Expression GetFilter(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void RemoveFilter(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.ISet<string> GetFilterNames() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsSystem() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void SetModifiers(Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> modifiers) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void Initialize() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void CommitModelChanges() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void CommitStructureModification(Net.Vpc.Upa.Persistence.PersistenceStore persistenceUnitManager) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void AddDependencyOnEntity(string entityName);

          T FindById<T>(object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

          T FindByMainField<T>(object mainFieldValue) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

          T FindByField<T>(string fieldName, object mainFieldValue) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

          System.Collections.Generic.IList<T> FindAll<T>() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.Record> FindAllRecords() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;
    }
}
