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
     * Persistence Unit is this template use File | Settings | File Templates.
     */
    public interface PersistenceUnit : Net.TheVpc.Upa.Closeable {

         bool IsAutoStart();

         void SetAutoStart(bool @value);

        /**
             * if true, when no scan filter is specified will scan all class-path
             *
             * @return true if auto scan is enabled
             */
         bool IsAutoScan();

         void SetAutoScan(bool autoScan);

         Net.TheVpc.Upa.Session OpenSession();

         Net.TheVpc.Upa.ObjectFactory GetFactory();

         Net.TheVpc.Upa.PersistenceGroup GetPersistenceGroup();

         Net.TheVpc.Upa.Types.I18NString GetTitle();

         Net.TheVpc.Upa.Package AddPackage(string name, string parentPath);

         Net.TheVpc.Upa.Package AddPackage(string name, string parentPath, int index);

         Net.TheVpc.Upa.Package AddPackage(string name);

         Net.TheVpc.Upa.Package AddPackage(string name, int index);

        /**
             * add all modules
             *
             * @param path
             * @param missingStrategy
             * @return
             */
         Net.TheVpc.Upa.Package GetPackage(string path, Net.TheVpc.Upa.MissingStrategy missingStrategy);

         Net.TheVpc.Upa.Package GetPackage(string path);

         Net.TheVpc.Upa.Package GetDefaultPackage();

         bool IsReadOnly();

         void SetReadOnly(bool enable);

         string GetName();

         string GetAbsoluteName();

         bool IsLastStartSucceeded();

         void SetLastStartSucceeded(bool success);

         bool IsRecurseDelete();

         bool IsLockablePersistenceUnit();

         bool IsCaseSensitive();

         void SetCaseSensitive(bool enable);

         Net.TheVpc.Upa.NamingStrategy GetNamingStrategy();

         Net.TheVpc.Upa.Persistence.PersistenceStore GetPersistenceStore();

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
         Net.TheVpc.Upa.Entity AddEntity(object descriptor);

         System.Collections.Generic.IList<Net.TheVpc.Upa.Index> GetIndexes();

         System.Collections.Generic.IList<Net.TheVpc.Upa.Index> GetIndexes(string entityName);

         bool ContainsEntity(string entityName);

        /**
             * @param source    source to be parsed
             * @param listener  listener to track scanned items or null
             * @param configure if true process configuration (add entities,
             *                  functions...)
             * @
             */
         void Scan(Net.TheVpc.Upa.Config.ScanSource source, Net.TheVpc.Upa.ScanListener listener, bool configure);

         bool ContainsField(string entityName, string fieldName);

         Net.TheVpc.Upa.Entity GetEntity(string entityName);

         bool ContainsEntity(System.Type entityType);

         Net.TheVpc.Upa.Entity FindEntity(System.Type entityType);

         System.Collections.Generic.IList<Net.TheVpc.Upa.Entity> FindEntities(System.Type entityType);

         Net.TheVpc.Upa.Entity FindEntity(string entityName);

         Net.TheVpc.Upa.Entity GetEntity(System.Type entityType);

         void AddRelationship(Net.TheVpc.Upa.RelationshipDescriptor relationDescriptor);

         void Reset();

         void Reset(System.Collections.Generic.IDictionary<string , object> hints);

         System.Collections.Generic.IList<Net.TheVpc.Upa.Entity> GetEntities();

         System.Collections.Generic.IList<Net.TheVpc.Upa.Package> GetPackages();

         System.Collections.Generic.IList<Net.TheVpc.Upa.Entity> GetEntities(Net.TheVpc.Upa.Filters.EntityFilter entityFilter);

         System.Collections.Generic.IList<Net.TheVpc.Upa.Relationship> GetRelationships();

         Net.TheVpc.Upa.Relationship GetRelationship(string name);

         bool ContainsRelationship(string relationName);

         System.Collections.Generic.IList<Net.TheVpc.Upa.Relationship> GetRelationshipsByTarget(Net.TheVpc.Upa.Entity entity);

         System.Collections.Generic.IList<Net.TheVpc.Upa.Relationship> GetRelationshipsBySource(Net.TheVpc.Upa.Entity entity);

         void InstallDemoData();

         void Start();

         bool IsSystemSession(Net.TheVpc.Upa.Session s);

         string GetPersistenceName();

         void SetPersistenceName(string persistenceNameFormat);

         bool IsValidPersistenceUnit();

         void Clear(string name, System.Collections.Generic.IDictionary<string , object> hints);

         void Clear(System.Type entity, System.Collections.Generic.IDictionary<string , object> hints);

         void Clear(Net.TheVpc.Upa.Filters.EntityFilter entityFilter, System.Collections.Generic.IDictionary<string , object> hints);

         void Clear();


         void AddPropertyChangeListener(string propertyName, Net.TheVpc.Upa.PropertyChangeListener listener);


         void AddPropertyChangeListener(Net.TheVpc.Upa.PropertyChangeListener listener);


         void RemovePropertyChangeListener(string propertyName, Net.TheVpc.Upa.PropertyChangeListener listener);


         void RemovePropertyChangeListener(Net.TheVpc.Upa.PropertyChangeListener listener);

         Net.TheVpc.Upa.PropertyChangeListener[] GetPropertyChangeListeners();

         Net.TheVpc.Upa.PropertyChangeListener[] GetPropertyChangeListeners(string propertyName);

         int GetStatus();

         void SetStatus(int status);

         Net.TheVpc.Upa.Properties GetProperties();

         bool IsAskOnCheckCreatedPersistenceUnit();

         void SetAskOnCheckCreatedPersistenceUnit(bool askOnCheckCreatedPersistenceUnit);

         System.Type GetEntityExtensionSupportType(System.Type entityExtensionType);

         Net.TheVpc.Upa.UPASecurityManager GetSecurityManager();

        /**
             * @param definitionListener
             * @param trackSystem        when true system entities are also tracked
             */
         void AddDefinitionListener(Net.TheVpc.Upa.Callbacks.DefinitionListener definitionListener, bool trackSystem);

        /**
             * @param entityName
             * @param definitionListener
             * @param trackSystem        when true system entities are also tracked
             */
         void AddDefinitionListener(string entityName, Net.TheVpc.Upa.Callbacks.DefinitionListener definitionListener, bool trackSystem);

         void AddDefinitionListener(System.Type entityType, Net.TheVpc.Upa.Callbacks.DefinitionListener definitionListener, bool trackSystem);

        /**
             * system entities are not tracked
             *
             * @param definitionListener
             */
         void AddDefinitionListener(Net.TheVpc.Upa.Callbacks.DefinitionListener definitionListener);

        /**
             * system entities are not tracked
             *
             * @param entityName
             * @param definitionListener
             */
         void AddDefinitionListener(string entityName, Net.TheVpc.Upa.Callbacks.DefinitionListener definitionListener);

         void RemoveDefinitionListener(Net.TheVpc.Upa.Callbacks.DefinitionListener definitionListener);

         void RemoveDefinitionListener(string entityName, Net.TheVpc.Upa.Callbacks.DefinitionListener definitionListener);

         void RemoveDefinitionListener(System.Type entityType, Net.TheVpc.Upa.Callbacks.DefinitionListener definitionListener);

         void AddPersistenceUnitListener(Net.TheVpc.Upa.Callbacks.PersistenceUnitListener listener);

         void RemovePersistenceUnitListener(Net.TheVpc.Upa.Callbacks.PersistenceUnitListener listener);

         System.Collections.Generic.IList<Net.TheVpc.Upa.Callbacks.PersistenceUnitListener> GetPersistenceUnitListeners();

         Net.TheVpc.Upa.Persistence.PersistenceStoreFactory GetPersistenceStoreFactory();

         void AddSQLParameterProcessor(Net.TheVpc.Upa.Expressions.QLParameterProcessor p);

         void RemoveSQLParameterProcessor(Net.TheVpc.Upa.Expressions.QLParameterProcessor p);

         Net.TheVpc.Upa.I18NStringStrategy GetI18NStringStrategy();

         Net.TheVpc.Upa.LockInfo GetPersistenceUnitLockingInfo();

         void LockPersistenceUnit(string id);

         void UnlockPersistenceUnit(string id);

         Net.TheVpc.Upa.LockInfo GetLockingInfo(Net.TheVpc.Upa.Entity entity);

         void LockEntityManager(Net.TheVpc.Upa.Entity entity, string id);

         void UnlockEntityManager(Net.TheVpc.Upa.Entity entity, string id);

         System.Collections.Generic.IList<Net.TheVpc.Upa.LockInfo> GetLockingInfo(Net.TheVpc.Upa.Entity entity, Net.TheVpc.Upa.Expressions.Expression expression);

         void LockEntities(Net.TheVpc.Upa.Entity entity, Net.TheVpc.Upa.Expressions.Expression expression, string id);

         void UnlockEntities(Net.TheVpc.Upa.Entity entity, Net.TheVpc.Upa.Expressions.Expression expression, string id);

        /**
             * if entityNamePattern is a simple Entity name of an existing name call
             * entity.addTrigger if not postpone creation for all entities verifying
             * triggerName with are (or are not) system entities
             *
             * @param triggerName
             * @param interceptor
             * @param entityNamePattern
             * @param system            if true include system entities
             * @
             */
         void AddTrigger(string triggerName, Net.TheVpc.Upa.Callbacks.EntityInterceptor interceptor, string entityNamePattern, bool system);

         void DropTrigger(string entityName, string triggerName);

         System.Collections.Generic.IList<Net.TheVpc.Upa.Callbacks.Trigger> GetTriggers(string entityName);

         bool IsTriggersEnabled();

         void SetTriggersEnabled(bool triggersEnabled);

         Net.TheVpc.Upa.Persistence.ConnectionProfile GetConnectionProfile();

         void Persist(string entityName, object objectOrDocument);

         void Persist(string entity, object objectOrDocument, System.Collections.Generic.IDictionary<string , object> hints);

         void Persist(object objectOrDocument);

         Net.TheVpc.Upa.RemoveTrace Remove(string entityName, object objectOrDocument);

         Net.TheVpc.Upa.RemoveTrace Remove(object objectOrDocument);

         Net.TheVpc.Upa.UpdateQuery CreateUpdateQuery(string entityName);

         Net.TheVpc.Upa.UpdateQuery CreateUpdateQuery(System.Type type);

         Net.TheVpc.Upa.UpdateQuery CreateUpdateQuery(object @object);

         void Merge(string entityName, object objectOrDocument);

         void Merge(object objectOrDocument);

         void Update(object objectOrDocument);

         bool Save(object objectOrDocument);

         bool Save(System.Type entityType, object objectOrDocument);

         bool Save(string entityName, object objectOrDocument);

         void Update(System.Type entityType, object objectOrDocument);

         void Update(string entityName, object objectOrDocument);

         void UpdateFormulas();

         void UpdateFormulas(Net.TheVpc.Upa.Filters.EntityFilter entityFilter, System.Collections.Generic.IDictionary<string , object> hints) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.RemoveTrace Remove(System.Type entityType, object @object);

         Net.TheVpc.Upa.RemoveTrace Remove(System.Type entityType, Net.TheVpc.Upa.RemoveOptions options);

         Net.TheVpc.Upa.RemoveTrace Remove(string entityName, Net.TheVpc.Upa.RemoveOptions options);

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

         System.Collections.Generic.IList<Net.TheVpc.Upa.Document> FindAllDocuments(System.Type entityType);

         System.Collections.Generic.IList<Net.TheVpc.Upa.Document> FindAllDocuments(string entityName);

         Net.TheVpc.Upa.Document FindDocumentById(System.Type entityType, object id);

         Net.TheVpc.Upa.Document FindDocumentById(string entityName, object id);

         Net.TheVpc.Upa.QueryBuilder CreateQueryBuilder(System.Type entityType);

         Net.TheVpc.Upa.QueryBuilder CreateQueryBuilder(string entityName);

         Net.TheVpc.Upa.Query CreateQuery(Net.TheVpc.Upa.Expressions.EntityStatement query);

         Net.TheVpc.Upa.Query CreateQuery(string query);

        /**
             * @param transactionType transactionType
             * @return true if a transaction has been created
             * @
             */
         bool BeginTransaction(Net.TheVpc.Upa.TransactionType transactionType);

         void CommitTransaction();

         void RollbackTransaction();

         bool IsStarted();

         bool IsValidStructureModificationContext();

         bool IsStructureModification();

         void BeginStructureModification();

         void CommitStructureModification();

         bool IsClosed();

         Net.TheVpc.Upa.ExpressionManager GetExpressionManager();

         Net.TheVpc.Upa.Bulk.ImportExportManager GetImportExportManager();

         Net.TheVpc.Upa.Types.DataTypeTransformFactory GetTypeTransformFactory();

         void SetTypeTransformFactory(Net.TheVpc.Upa.Types.DataTypeTransformFactory typeTransformFactory);

         Net.TheVpc.Upa.Persistence.ConnectionConfig[] GetConnectionConfigs();

         Net.TheVpc.Upa.Persistence.ConnectionConfig[] GetRootConnectionConfigs();

         void AddConnectionConfig(Net.TheVpc.Upa.Persistence.ConnectionConfig connectionConfig);

         void RemoveConnectionConfig(int index);

         void AddRootConnectionConfig(Net.TheVpc.Upa.Persistence.ConnectionConfig connectionConfig);

         void RemoveRootConnectionConfig(int index);

         Net.TheVpc.Upa.Persistence.PersistenceNameConfig GetPersistenceNameConfig();

         void SetPersistenceNameConfig(Net.TheVpc.Upa.Persistence.PersistenceNameConfig nameStrategyModel);

         void AddContextAnnotationStrategyFilter(Net.TheVpc.Upa.Config.ScanFilter filter);

         void RemoveContextAnnotationStrategyFilter(Net.TheVpc.Upa.Config.ScanFilter filter);

         Net.TheVpc.Upa.Config.ScanFilter[] GetContextAnnotationStrategyFilters();

         Net.TheVpc.Upa.UserPrincipal GetUserPrincipal();

        /**
             * push new user context if login and credentials are valid
             *
             * @param login       login
             * @param credentials credentials
             */
         void Login(string login, string credentials);

         void LoginPrivileged(string login);

        /**
             * logout from previous login. should be valid only if login succeeded
             */
         void Logout();

         bool CurrentSessionExists();

         Net.TheVpc.Upa.Session GetCurrentSession();

         Net.TheVpc.Upa.Key CreateKey(params object [] keyValues);

         Net.TheVpc.Upa.Callback AddCallback(Net.TheVpc.Upa.MethodCallback methodCallback);

         void AddCallback(Net.TheVpc.Upa.Callback callback);

         void RemoveCallback(Net.TheVpc.Upa.Callback callback);

         Net.TheVpc.Upa.Callback[] GetCallbacks(Net.TheVpc.Upa.CallbackType callbackType, Net.TheVpc.Upa.ObjectType objectType, string name, bool system, bool preparedOnly, Net.TheVpc.Upa.EventPhase phase);

         Net.TheVpc.Upa.Persistence.UConnection GetConnection();

         void SetIdentityConstraintsEnabled(Net.TheVpc.Upa.Entity entity, bool enable);

          T Invoke<T>(Net.TheVpc.Upa.Action<T> action, Net.TheVpc.Upa.InvokeContext invokeContext);

          T Invoke<T>(Net.TheVpc.Upa.Action<T> action);

          T InvokePrivileged<T>(Net.TheVpc.Upa.Action<T> action, Net.TheVpc.Upa.InvokeContext invokeContext);

          T InvokePrivileged<T>(Net.TheVpc.Upa.Action<T> action);

         void Invoke(Net.TheVpc.Upa.VoidAction action, Net.TheVpc.Upa.InvokeContext invokeContext);

         void Invoke(Net.TheVpc.Upa.VoidAction action);

         void InvokePrivileged(Net.TheVpc.Upa.VoidAction action, Net.TheVpc.Upa.InvokeContext invokeContext);

         void InvokePrivileged(Net.TheVpc.Upa.VoidAction action);

         System.Collections.Generic.IComparer<Net.TheVpc.Upa.Entity> GetDependencyComparator();

          T CopyObject<T>(T r);

          T CopyObject<T>(string entityName, T r);

          T CopyObject<T>(System.Type entityType, T r);

         bool IsEmpty(string entityName);

         bool IsEmpty(System.Type entityType);

         long GetEntityCount(string entityName);

         long GetEntityCount(System.Type entityType);

         Net.TheVpc.Upa.PersistenceUnitInfo GetInfo();

         Net.TheVpc.Upa.NamedFormulaDefinition[] GetNamedFormulas();

         Net.TheVpc.Upa.NamedFormulaDefinition GetNamedFormula(string name);

         void AddNamedFormula(string name, Net.TheVpc.Upa.Formula formula);

         void RemoveNamedFormula(string name);
    }
}
