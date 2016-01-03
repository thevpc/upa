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
     * Persistence Unit is this template use File | Settings | File Templates.
     */
    public interface PersistenceUnit : Net.Vpc.Upa.Closeable {

         bool IsAutoStart();

         void SetAutoStart(bool @value);

        /**
             * if true, when no scan filter is specified will scan all class-path
             *
             * @return true if auto scan is enabled
             */
         bool IsAutoScan();

         void SetAutoScan(bool autoScan);

         Net.Vpc.Upa.Session OpenSession() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.ObjectFactory GetFactory() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.PersistenceGroup GetPersistenceGroup() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Types.I18NString GetTitle() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Package AddPackage(string name, string parentPath) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Package AddPackage(string name, string parentPath, int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Package AddPackage(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Package AddPackage(string name, int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

        /**
             * add all modules
             *
             * @param path
             * @param missingStrategy
             * @return
             */
         Net.Vpc.Upa.Package GetPackage(string path, Net.Vpc.Upa.MissingStrategy missingStrategy);

         Net.Vpc.Upa.Package GetPackage(string path);

         Net.Vpc.Upa.Package GetDefaulPackage();

         bool IsReadOnly() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void SetReadOnly(bool enable) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         string GetName() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsLastStartSucceeded() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void SetLastStartSucceeded(bool success) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsRecurseDelete() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsLockablePersistenceUnit() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsCaseSensitive() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void SetCaseSensitive(bool enable) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.NamingStrategy GetNamingStrategy() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Persistence.PersistenceStore GetPersistenceStore();

        /**
             * descriptor may be
             * <ul>
             * <li> an instance of EntityDescriptor </li>
             * <li> an instance of Class in which case it is considered as an annotated
             * class </li>
             * <li> Any other instance in which case it is considered as an annotated
             * class also</li>
             * </ul>
             *
             * @param descriptor
             * @return
             * @throws UPAException
             */
         Net.Vpc.Upa.Entity AddEntity(object descriptor) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.Index> GetIndexes() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.Index> GetIndexes(string entityName) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool ContainsEntity(string entityName) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

        /**
             * @param source    source to be parsed
             * @param listener  listener to track scanned items or null
             * @param configure if true process configuration (add entities,
             *                  functions...)
             * @throws UPAException
             */
         void Scan(Net.Vpc.Upa.Config.ScanSource source, Net.Vpc.Upa.ScanListener listener, bool configure) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool ContainsField(string entityName, string fieldName) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Entity GetEntity(string entityName) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool ContainsEntity(System.Type entityType) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Entity FindEntity(System.Type entityType) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.Entity> FindEntities(System.Type entityType) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Entity FindEntity(string entityName) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Entity GetEntity(System.Type entityType) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void AddRelationship(Net.Vpc.Upa.RelationshipDescriptor relationDescriptor) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void Reset() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.Entity> GetEntities() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.Package> GetPackages() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.Entity> GetEntities(Net.Vpc.Upa.Filters.EntityFilter entityFilter) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.Relationship> GetRelationships() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Relationship GetRelationship(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool ContainsRelationship(string relationName) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.Relationship> GetRelationshipsForTarget(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.Relationship> GetRelationshipsForSource(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void InstallDemoData() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void Start() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsSystemSession(Net.Vpc.Upa.Session s);

         string GetPersistenceName() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void SetPersistenceName(string persistenceName) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsValidPersistenceUnit() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Persistence.DBConfigModel GetDBConfigModel() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void SetDBConfigModel(Net.Vpc.Upa.Persistence.DBConfigModel dbConfigModel) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void Clear() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;


         void AddPropertyChangeListener(string propertyName, Net.Vpc.Upa.PropertyChangeListener listener);


         void AddPropertyChangeListener(Net.Vpc.Upa.PropertyChangeListener listener);


         void RemovePropertyChangeListener(string propertyName, Net.Vpc.Upa.PropertyChangeListener listener);


         void RemovePropertyChangeListener(Net.Vpc.Upa.PropertyChangeListener listener);

         Net.Vpc.Upa.PropertyChangeListener[] GetPropertyChangeListeners();

         Net.Vpc.Upa.PropertyChangeListener[] GetPropertyChangeListeners(string propertyName);

         int GetStatus() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void SetStatus(int status) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Properties GetProperties() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsAskOnCheckCreatedPersistenceUnit() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void SetAskOnCheckCreatedPersistenceUnit(bool askOnCheckCreatedPersistenceUnit) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Type GetEntityExtensionSupportType(System.Type entityExtensionType) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.UPASecurityManager GetSecurityManager() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

        /**
             * @param definitionListener
             * @param trackSystem        when true system entities are also tracked
             */
         void AddDefinitionListener(Net.Vpc.Upa.Callbacks.DefinitionListener definitionListener, bool trackSystem);

        /**
             * @param entityName
             * @param definitionListener
             * @param trackSystem        when true system entities are also tracked
             */
         void AddDefinitionListener(string entityName, Net.Vpc.Upa.Callbacks.DefinitionListener definitionListener, bool trackSystem);

         void AddDefinitionListener(System.Type entityType, Net.Vpc.Upa.Callbacks.DefinitionListener definitionListener, bool trackSystem);

        /**
             * system entities are not tracked
             *
             * @param definitionListener
             */
         void AddDefinitionListener(Net.Vpc.Upa.Callbacks.DefinitionListener definitionListener);

        /**
             * system entities are not tracked
             *
             * @param entityName
             * @param definitionListener
             */
         void AddDefinitionListener(string entityName, Net.Vpc.Upa.Callbacks.DefinitionListener definitionListener);

         void RemoveDefinitionListener(Net.Vpc.Upa.Callbacks.DefinitionListener definitionListener);

         void RemoveDefinitionListener(string entityName, Net.Vpc.Upa.Callbacks.DefinitionListener definitionListener);

         void RemoveDefinitionListener(System.Type entityType, Net.Vpc.Upa.Callbacks.DefinitionListener definitionListener);

         void AddPersistenceUnitListener(Net.Vpc.Upa.Callbacks.PersistenceUnitListener listener) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void RemovePersistenceUnitListener(Net.Vpc.Upa.Callbacks.PersistenceUnitListener listener) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.Callbacks.PersistenceUnitListener> GetPersistenceUnitListeners() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Persistence.PersistenceStoreFactory GetPersistenceStoreFactory() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void AddSQLParameterProcessor(Net.Vpc.Upa.Expressions.QLParameterProcessor p) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void RemoveSQLParameterProcessor(Net.Vpc.Upa.Expressions.QLParameterProcessor p) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.I18NStringStrategy GetI18NStringStrategy() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.LockInfo GetPersistenceUnitLockingInfo() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void LockPersistenceUnit(string id) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void UnlockPersistenceUnit(string id) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.LockInfo GetLockingInfo(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void LockEntityManager(Net.Vpc.Upa.Entity entity, string id) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void UnlockEntityManager(Net.Vpc.Upa.Entity entity, string id) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.LockInfo> GetLockingInfo(Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.Expressions.Expression expression) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void LockEntities(Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.Expressions.Expression expression, string id) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void UnlockEntities(Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.Expressions.Expression expression, string id) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

        /**
             * if entityNamePattern is a simple Entity name of an existing name call
             * entity.addTrigger if not postpone creation for all entities verifying
             * triggerName with are (or are not) system entities
             *
             * @param triggerName
             * @param interceptor
             * @param entityNamePattern
             * @param system            if true include system entities
             * @throws UPAException
             */
         void AddTrigger(string triggerName, Net.Vpc.Upa.Callbacks.EntityInterceptor interceptor, string entityNamePattern, bool system) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void DropTrigger(string entityName, string triggerName) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.Callbacks.Trigger> GetTriggers(string entityName) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsTriggersEnabled() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void SetTriggersEnabled(bool triggersEnabled) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Persistence.ConnectionProfile GetConnectionProfile() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void Persist(object objectOrRecord) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void Remove(object objectOrRecord) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void Merge(object objectOrRecord) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool Save(object objectOrRecord) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool Save(string entityName, object objectOrRecord) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void Update(object objectOrRecord) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void Persist(string entityName, object objectOrRecord) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void Update(string entityName, object objectOrRecord) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void UpdatePartial(object objectOrRecord) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void UpdatePartial(string entityName, object objectOrRecord) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void UpdateFormulas() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void UpdateFormulas(Net.Vpc.Upa.Entity[] entities) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         int UpdateRecords(string entityName, Net.Vpc.Upa.Record record, Net.Vpc.Upa.Expressions.Expression condition) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void UpdateFormulas(string entityName, Net.Vpc.Upa.Filters.FieldFilter filter, Net.Vpc.Upa.Expressions.Expression expr) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void UpdateFormulasById(string entityName, Net.Vpc.Upa.Filters.FieldFilter filter, object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         int UpdateRecords(System.Type entityType, Net.Vpc.Upa.Record record, Net.Vpc.Upa.Expressions.Expression condition) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void UpdateFormulas(System.Type entityType, Net.Vpc.Upa.Filters.FieldFilter filter, Net.Vpc.Upa.Expressions.Expression expr) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void UpdateFormulasById(System.Type entityType, Net.Vpc.Upa.Filters.FieldFilter filter, object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.RemoveTrace Remove(System.Type entityType, object @object) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.RemoveTrace Remove(string entityName, object @object) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.RemoveTrace Remove(System.Type entityType, Net.Vpc.Upa.RemoveOptions options) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.RemoveTrace Remove(string entityName, Net.Vpc.Upa.RemoveOptions options) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

          System.Collections.Generic.IList<T> FindAll<T>(System.Type entityType) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

          System.Collections.Generic.IList<T> FindAll<T>(string entityName) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

          T FindByMainField<T>(System.Type entityType, object mainFieldValue) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

          T FindByMainField<T>(string entityName, object mainFieldValue) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

          T FindByField<T>(System.Type entityType, string fieldName, object mainFieldValue) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

          T FindByField<T>(string entityName, string fieldName, object mainFieldValue) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

          T FindById<T>(System.Type entityType, object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

          T FindById<T>(string entityName, object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.Record> FindAllRecords(System.Type entityType) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.Record> FindAllRecords(string entityName) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Record FindRecordById(System.Type entityType, object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.QueryBuilder CreateQueryBuilder(System.Type entityType) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.QueryBuilder CreateQueryBuilder(string entityName) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Query CreateQuery(Net.Vpc.Upa.Expressions.EntityStatement query) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Query CreateQuery(string query) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void BeginTransaction(Net.Vpc.Upa.TransactionType transactionType) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void CommitTransaction() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void RollbackTransaction() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsStarted() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsValidStructureModificationContext() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsStructureModification() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void BeginStructureModification() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void CommitStructureModification() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void Close() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsClosed() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.ExpressionManager GetExpressionManager();

         Net.Vpc.Upa.Bulk.ImportExportManager GetImportExportManager();

         void Init(string name, Net.Vpc.Upa.PersistenceGroup persistenceGroup);

         Net.Vpc.Upa.Types.DataTypeTransformFactory GetTypeTransformFactory();

         void SetTypeTransformFactory(Net.Vpc.Upa.Types.DataTypeTransformFactory typeTransformFactory);

         Net.Vpc.Upa.Persistence.ConnectionConfig[] GetConnectionConfigs();

         Net.Vpc.Upa.Persistence.ConnectionConfig[] GetRootConnectionConfigs();

         void AddConnectionConfig(Net.Vpc.Upa.Persistence.ConnectionConfig connectionConfig);

         void RemoveConnectionConfig(int index);

         void AddRootConnectionConfig(Net.Vpc.Upa.Persistence.ConnectionConfig connectionConfig);

         void RemoveRootConnectionConfig(int index);

         void SetPersistenceNameConfig(Net.Vpc.Upa.Persistence.PersistenceNameConfig nameStrategyModel);

         Net.Vpc.Upa.Persistence.PersistenceNameConfig GetPersistenceNameConfig();

         void AddContextAnnotationStrategyFilter(Net.Vpc.Upa.Config.ScanFilter filter);

         void RemoveContextAnnotationStrategyFilter(Net.Vpc.Upa.Config.ScanFilter filter);

         Net.Vpc.Upa.Config.ScanFilter[] GetContextAnnotationStrategyFilters();

         Net.Vpc.Upa.UserPrincipal GetUserPrincipal();

        /**
             * push new user context if login and credentials are valid
             *
             * @param login
             * @param credentials
             */
         void Login(string login, string credentials);

         void LoginPrivileged(string login);

        /**
             * logout from previous login. should be valid only if login succeeded
             */
         void Logout();

         bool CurrentSessionExists();

         Net.Vpc.Upa.Session GetCurrentSession() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Key CreateKey(params object [] keyValues) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void AddCallback(Net.Vpc.Upa.Callback callback);

         void RemoveCallback(Net.Vpc.Upa.Callback callback);

         Net.Vpc.Upa.Callback[] GetCallbacks(Net.Vpc.Upa.CallbackType callbackType, Net.Vpc.Upa.ObjectType objectType, string name, bool system, Net.Vpc.Upa.EventPhase phase);
    }
}
