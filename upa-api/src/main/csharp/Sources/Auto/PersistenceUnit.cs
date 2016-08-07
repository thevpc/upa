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

         Net.Vpc.Upa.Session OpenSession();

         Net.Vpc.Upa.ObjectFactory GetFactory();

         Net.Vpc.Upa.PersistenceGroup GetPersistenceGroup();

         Net.Vpc.Upa.Types.I18NString GetTitle();

         Net.Vpc.Upa.Package AddPackage(string name, string parentPath);

         Net.Vpc.Upa.Package AddPackage(string name, string parentPath, int index);

         Net.Vpc.Upa.Package AddPackage(string name);

         Net.Vpc.Upa.Package AddPackage(string name, int index);

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

         bool IsReadOnly();

         void SetReadOnly(bool enable);

         string GetName();

         bool IsLastStartSucceeded();

         void SetLastStartSucceeded(bool success);

         bool IsRecurseDelete();

         bool IsLockablePersistenceUnit();

         bool IsCaseSensitive();

         void SetCaseSensitive(bool enable);

         Net.Vpc.Upa.NamingStrategy GetNamingStrategy();

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
             * @
             */
         Net.Vpc.Upa.Entity AddEntity(object descriptor);

         System.Collections.Generic.IList<Net.Vpc.Upa.Index> GetIndexes();

         System.Collections.Generic.IList<Net.Vpc.Upa.Index> GetIndexes(string entityName);

         bool ContainsEntity(string entityName);

        /**
             * @param source source to be parsed
             * @param listener listener to track scanned items or null
             * @param configure if true process configuration (add entities,
             * functions...)
             * @
             */
         void Scan(Net.Vpc.Upa.Config.ScanSource source, Net.Vpc.Upa.ScanListener listener, bool configure);

         bool ContainsField(string entityName, string fieldName);

         Net.Vpc.Upa.Entity GetEntity(string entityName);

         bool ContainsEntity(System.Type entityType);

         Net.Vpc.Upa.Entity FindEntity(System.Type entityType);

         System.Collections.Generic.IList<Net.Vpc.Upa.Entity> FindEntities(System.Type entityType);

         Net.Vpc.Upa.Entity FindEntity(string entityName);

         Net.Vpc.Upa.Entity GetEntity(System.Type entityType);

         void AddRelationship(Net.Vpc.Upa.RelationshipDescriptor relationDescriptor);

         void Reset();

         void Reset(System.Collections.Generic.IDictionary<string , object> hints);

         System.Collections.Generic.IList<Net.Vpc.Upa.Entity> GetEntities();

         System.Collections.Generic.IList<Net.Vpc.Upa.Package> GetPackages();

         System.Collections.Generic.IList<Net.Vpc.Upa.Entity> GetEntities(Net.Vpc.Upa.Filters.EntityFilter entityFilter);

         System.Collections.Generic.IList<Net.Vpc.Upa.Relationship> GetRelationships();

         Net.Vpc.Upa.Relationship GetRelationship(string name);

         bool ContainsRelationship(string relationName);

         System.Collections.Generic.IList<Net.Vpc.Upa.Relationship> GetRelationshipsByTarget(Net.Vpc.Upa.Entity entity);

         System.Collections.Generic.IList<Net.Vpc.Upa.Relationship> GetRelationshipsBySource(Net.Vpc.Upa.Entity entity);

         void InstallDemoData();

         void Start();

         bool IsSystemSession(Net.Vpc.Upa.Session s);

         string GetPersistenceName();

         void SetPersistenceName(string persistenceName);

         bool IsValidPersistenceUnit();

         Net.Vpc.Upa.Persistence.DBConfigModel GetDBConfigModel();

         void SetDBConfigModel(Net.Vpc.Upa.Persistence.DBConfigModel dbConfigModel);

         void Clear(Net.Vpc.Upa.Filters.EntityFilter entityFilter, System.Collections.Generic.IDictionary<string , object> hints);

         void Clear();


         void AddPropertyChangeListener(string propertyName, Net.Vpc.Upa.PropertyChangeListener listener);


         void AddPropertyChangeListener(Net.Vpc.Upa.PropertyChangeListener listener);


         void RemovePropertyChangeListener(string propertyName, Net.Vpc.Upa.PropertyChangeListener listener);


         void RemovePropertyChangeListener(Net.Vpc.Upa.PropertyChangeListener listener);

         Net.Vpc.Upa.PropertyChangeListener[] GetPropertyChangeListeners();

         Net.Vpc.Upa.PropertyChangeListener[] GetPropertyChangeListeners(string propertyName);

         int GetStatus();

         void SetStatus(int status);

         Net.Vpc.Upa.Properties GetProperties();

         bool IsAskOnCheckCreatedPersistenceUnit();

         void SetAskOnCheckCreatedPersistenceUnit(bool askOnCheckCreatedPersistenceUnit);

         System.Type GetEntityExtensionSupportType(System.Type entityExtensionType);

         Net.Vpc.Upa.UPASecurityManager GetSecurityManager();

        /**
             * @param definitionListener
             * @param trackSystem when true system entities are also tracked
             */
         void AddDefinitionListener(Net.Vpc.Upa.Callbacks.DefinitionListener definitionListener, bool trackSystem);

        /**
             * @param entityName
             * @param definitionListener
             * @param trackSystem when true system entities are also tracked
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

         void AddPersistenceUnitListener(Net.Vpc.Upa.Callbacks.PersistenceUnitListener listener);

         void RemovePersistenceUnitListener(Net.Vpc.Upa.Callbacks.PersistenceUnitListener listener);

         System.Collections.Generic.IList<Net.Vpc.Upa.Callbacks.PersistenceUnitListener> GetPersistenceUnitListeners();

         Net.Vpc.Upa.Persistence.PersistenceStoreFactory GetPersistenceStoreFactory();

         void AddSQLParameterProcessor(Net.Vpc.Upa.Expressions.QLParameterProcessor p);

         void RemoveSQLParameterProcessor(Net.Vpc.Upa.Expressions.QLParameterProcessor p);

         Net.Vpc.Upa.I18NStringStrategy GetI18NStringStrategy();

         Net.Vpc.Upa.LockInfo GetPersistenceUnitLockingInfo();

         void LockPersistenceUnit(string id);

         void UnlockPersistenceUnit(string id);

         Net.Vpc.Upa.LockInfo GetLockingInfo(Net.Vpc.Upa.Entity entity);

         void LockEntityManager(Net.Vpc.Upa.Entity entity, string id);

         void UnlockEntityManager(Net.Vpc.Upa.Entity entity, string id);

         System.Collections.Generic.IList<Net.Vpc.Upa.LockInfo> GetLockingInfo(Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.Expressions.Expression expression);

         void LockEntities(Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.Expressions.Expression expression, string id);

         void UnlockEntities(Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.Expressions.Expression expression, string id);

        /**
             * if entityNamePattern is a simple Entity name of an existing name call
             * entity.addTrigger if not postpone creation for all entities verifying
             * triggerName with are (or are not) system entities
             *
             * @param triggerName
             * @param interceptor
             * @param entityNamePattern
             * @param system if true include system entities
             * @
             */
         void AddTrigger(string triggerName, Net.Vpc.Upa.Callbacks.EntityInterceptor interceptor, string entityNamePattern, bool system);

         void DropTrigger(string entityName, string triggerName);

         System.Collections.Generic.IList<Net.Vpc.Upa.Callbacks.Trigger> GetTriggers(string entityName);

         bool IsTriggersEnabled();

         void SetTriggersEnabled(bool triggersEnabled);

         Net.Vpc.Upa.Persistence.ConnectionProfile GetConnectionProfile();

         void Persist(string entityName, object objectOrRecord);

         void Persist(string entity, object objectOrRecord, System.Collections.Generic.IDictionary<string , object> hints);

         void Persist(object objectOrRecord);

         Net.Vpc.Upa.RemoveTrace Remove(string entityName, object objectOrRecord);

         Net.Vpc.Upa.RemoveTrace Remove(object objectOrRecord);

         Net.Vpc.Upa.UpdateQuery CreateUpdateQuery(string entityName);

         Net.Vpc.Upa.UpdateQuery CreateUpdateQuery(System.Type type);

         Net.Vpc.Upa.UpdateQuery CreateUpdateQuery(object @object);

         void Merge(string entityName, object objectOrRecord);

         void Merge(object objectOrRecord);

         void Update(object objectOrRecord);

         bool Save(object objectOrRecord);

         bool Save(string entityName, object objectOrRecord);

         void Update(string entityName, object objectOrRecord);

         void UpdateFormulas();

         void UpdateFormulas(Net.Vpc.Upa.Filters.EntityFilter entityFilter, System.Collections.Generic.IDictionary<string , object> hints) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.RemoveTrace Remove(System.Type entityType, object @object);

         Net.Vpc.Upa.RemoveTrace Remove(System.Type entityType, Net.Vpc.Upa.RemoveOptions options);

         Net.Vpc.Upa.RemoveTrace Remove(string entityName, Net.Vpc.Upa.RemoveOptions options);

          System.Collections.Generic.IList<T> FindAll<T>(System.Type entityType);

          System.Collections.Generic.IList<T> FindAll<T>(string entityName);

          System.Collections.Generic.IList<T> FindAllIds<T>(string entityName);

          T FindByMainField<T>(System.Type entityType, object mainFieldValue);

          T FindByMainField<T>(string entityName, object mainFieldValue);

          T FindByField<T>(System.Type entityType, string fieldName, object mainFieldValue);

          T FindByField<T>(string entityName, string fieldName, object mainFieldValue);

          T FindById<T>(System.Type entityType, object id);

          T FindById<T>(string entityName, object id);

         bool ExistsById(string entityName, object id);

         System.Collections.Generic.IList<Net.Vpc.Upa.Record> FindAllRecords(System.Type entityType);

         System.Collections.Generic.IList<Net.Vpc.Upa.Record> FindAllRecords(string entityName);

         Net.Vpc.Upa.Record FindRecordById(System.Type entityType, object id);

         Net.Vpc.Upa.Record FindRecordById(string entityName, object id);

         Net.Vpc.Upa.QueryBuilder CreateQueryBuilder(System.Type entityType);

         Net.Vpc.Upa.QueryBuilder CreateQueryBuilder(string entityName);

         Net.Vpc.Upa.Query CreateQuery(Net.Vpc.Upa.Expressions.EntityStatement query);

         Net.Vpc.Upa.Query CreateQuery(string query);

        /**
             *
             * @param transactionType
             * @return true if a transaction has been created
             * @
             */
         bool BeginTransaction(Net.Vpc.Upa.TransactionType transactionType);

         void CommitTransaction();

         void RollbackTransaction();

         bool IsStarted();

         bool IsValidStructureModificationContext();

         bool IsStructureModification();

         void BeginStructureModification();

         void CommitStructureModification();

         bool IsClosed();

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

         Net.Vpc.Upa.Session GetCurrentSession();

         Net.Vpc.Upa.Key CreateKey(params object [] keyValues);

         Net.Vpc.Upa.Callback AddCallback(Net.Vpc.Upa.CallbackConfig callbackConfig);

         void AddCallback(Net.Vpc.Upa.Callback callback);

         void RemoveCallback(Net.Vpc.Upa.Callback callback);

         Net.Vpc.Upa.Callback[] GetCallbacks(Net.Vpc.Upa.CallbackType callbackType, Net.Vpc.Upa.ObjectType objectType, string name, bool system, bool preparedOnly, Net.Vpc.Upa.EventPhase phase);

         Net.Vpc.Upa.Persistence.UConnection GetConnection();

         void SetIdentityConstraintsEnabled(Net.Vpc.Upa.Entity entity, bool enable);

          T Invoke<T>(Net.Vpc.Upa.Action<T> action, Net.Vpc.Upa.InvokeContext invokeContext);

          T Invoke<T>(Net.Vpc.Upa.Action<T> action);

          T InvokePrivileged<T>(Net.Vpc.Upa.Action<T> action, Net.Vpc.Upa.InvokeContext invokeContext);

          T InvokePrivileged<T>(Net.Vpc.Upa.Action<T> action);

         void Invoke(Net.Vpc.Upa.VoidAction action, Net.Vpc.Upa.InvokeContext invokeContext);

         void Invoke(Net.Vpc.Upa.VoidAction action);

         void InvokePrivileged(Net.Vpc.Upa.VoidAction action, Net.Vpc.Upa.InvokeContext invokeContext);

         void InvokePrivileged(Net.Vpc.Upa.VoidAction action);

         System.Collections.Generic.IComparer<Net.Vpc.Upa.Entity> GetDependencyComparator();

          T CopyObject<T>(T r);

          T CopyObject<T>(string entityName, T r);

          T CopyObject<T>(System.Type entityType, T r);

         bool IsEmpty(string entityName);

         bool IsEmpty(System.Type entityType);

         long GetEntityCount(string entityName);

         long GetEntityCount(System.Type entityType);
    }
}
