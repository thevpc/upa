/**
 * ==================================================================== UPA
 * (Unstructured Persistence API) Yet another ORM Framework
 * ++++++++++++++++++++++++++++++++++ Unstructured Persistence API, referred to
 * as UPA, is a genuine effort to raise programming language frameworks managing
 * relational data in applications using Java Platform, Standard Edition and
 * Java Platform, Enterprise Edition and Dot Net Framework equally to the next
 * level of handling ORM for mutable data structures. UPA is intended to provide
 * a solid reflection mechanisms to the mapped data structures while affording
 * to make changes at runtime of those data structures. Besides, UPA has learned
 * considerably of the leading ORM (JPA, Hibernate/NHibernate, MyBatis and
 * Entity Framework to name a few) failures to satisfy very common even known to
 * be trivial requirement in enterprise applications.
 * <p>
 * Copyright (C) 2014-2015 Taha BEN SALAH
 * <p>
 * This program is free software; you can redistribute it and/or modify it under
 * the terms of the GNU General Public License as published by the Free Software
 * Foundation; either version 2 of the License, or (at your option) any later
 * version.
 * <p>
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE. See the GNU General Public License for more
 * details.
 * <p>
 * You should have received a copy of the GNU General Public License along with
 * this program; if not, write to the Free Software Foundation, Inc., 51
 * Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 * ====================================================================
 */
package net.vpc.upa;

import net.vpc.upa.bulk.ImportExportManager;
import net.vpc.upa.callbacks.DefinitionListener;
import net.vpc.upa.callbacks.EntityInterceptor;
import net.vpc.upa.callbacks.PersistenceUnitListener;
import net.vpc.upa.callbacks.Trigger;
import net.vpc.upa.config.ScanFilter;
import net.vpc.upa.config.ScanSource;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.EntityStatement;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.QLParameterProcessor;
import net.vpc.upa.filters.EntityFilter;
import net.vpc.upa.persistence.*;
import net.vpc.upa.types.DataTypeTransformFactory;
import net.vpc.upa.types.I18NString;

import java.beans.PropertyChangeListener;
import java.util.Comparator;
import java.util.List;
import java.util.Map;

/**
 * Persistence Unit is this template use File | Settings | File Templates.
 */
public interface PersistenceUnit extends Closeable {

    boolean isAutoStart();

    void setAutoStart(boolean value);

    /**
     * if true, when no scan filter is specified will scan all class-path
     *
     * @return true if auto scan is enabled
     */
    public boolean isAutoScan();

    public void setAutoScan(boolean autoScan);

    Session openSession() ;

    ObjectFactory getFactory() ;

    PersistenceGroup getPersistenceGroup() ;

    //    void setPersistenceGroup(PersistenceGroup persistenceGroup) ;
    I18NString getTitle() ;

    //    void add(PersistenceUnitItem part);
//    void remove(int index) ;
//    void move(int index, int newIndex) ;
//    void move(int index, int newIndex, int count) ;
//    void invalidate() ;
//    List<PersistenceUnitItem> getChildren() ;
//    int indexOf(PersistenceUnitItem child) ;
//    int indexOf(String childName) ;
    Package addPackage(String name, String parentPath) ;

    Package addPackage(String name, String parentPath, int index) ;

    Package addPackage(String name) ;

    Package addPackage(String name, int index) ;

    /**
     * add all modules
     *
     * @param path
     * @param missingStrategy
     * @return
     */
    public Package getPackage(String path, MissingStrategy missingStrategy);

    public Package getPackage(String path);

    public Package getDefaulPackage();

    //    DatabaseResources getResources();
    boolean isReadOnly() ;

    void setReadOnly(boolean enable) ;

    //    void declareInternEntities();
//    void declareEntities();
//    String getDefaultAdapterString();
//
//    void setDefaultConnectionString(String defaultAdapterString);
    String getName() ;

    //    void setName(String name) ;
    boolean isLastStartSucceeded() ;

    void setLastStartSucceeded(boolean success) ;

    boolean isRecurseDelete() ;

    boolean isLockablePersistenceUnit() ;

    boolean isCaseSensitive() ;

    void setCaseSensitive(boolean enable) ;

    NamingStrategy getNamingStrategy() ;

    public PersistenceStore getPersistenceStore();

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
    Entity addEntity(Object descriptor) ;

    //    public Index addIndex(String indexName, String entityName, boolean unique, List<String> fieldNames) ;
    public List<Index> getIndexes() ;

    public List<Index> getIndexes(String entityName) ;

    boolean containsEntity(String entityName) ;

    /**
     * @param source source to be parsed
     * @param listener listener to track scanned items or null
     * @param configure if true process configuration (add entities,
     * functions...)
     * @
     */
    void scan(ScanSource source, ScanListener listener, boolean configure) ;

    boolean containsField(String entityName, String fieldName) ;

    Entity getEntity(String entityName) ;

    //    <K, R> Entity<K, R> getEntity(String entityName, boolean check);
    public boolean containsEntity(Class entityType) ;

    public Entity findEntity(Class entityType) ;

    public List<Entity> findEntities(Class entityType) ;

    public Entity findEntity(String entityName) ;

    public Entity getEntity(Class entityType) ;

    //    int getExplicitEntitiesCount() ;
    public void addRelationship(RelationshipDescriptor relationDescriptor) ;

    //    public Relationship addRelation(String name, RelationType type, String detailEntityName, String masterEntityName, String detailFieldName, String masterfieldName, RelationUpdateType detailUpdateType, RelationUpdateType masterUpdateType, String[] detailFieldNames, boolean nullable, Expression filter) ;
    void reset() ;

    public void reset(Map<String,Object> hints);

    List<Entity> getEntities() ;

    List<Package> getPackages() ;

    List<Entity> getEntities(EntityFilter entityFilter) ;

    List<Relationship> getRelationships() ;

    Relationship getRelationship(String name) ;

    boolean containsRelationship(String relationName) ;

    List<Relationship> getRelationshipsByTarget(Entity entity) ;

    List<Relationship> getRelationshipsBySource(Entity entity) ;

    //    List<Field> findField(String name) ;
    //    public Script getDisableIdentityConstraintsScript() {
    //        Script script = new Script();
    //        for (Iterator iterator = entities.values().iterator(); iterator.hasNext();) {
    //            Entity entity = (Entity) iterator.next();
    //            if (entity.isAutoIncrement()) {
    //                script.addStatement(getAdapterName().getDisableIdentityConstraintsStatement(entity));
    //            }
    //        }
    //        return script;
    //    }
    void installDemoData() ;

    void start() ;

    public boolean isSystemSession(Session s);

    String getPersistenceName() ;

    void setPersistenceName(String persistenceName) ;

    //    List<Entity> getAllPersistentEntities() ;
//
//    List<Entity> getAllViewEntities() ;
    //    boolean checkCreatedSilently() ;
//    boolean checkCreatedPersistenceUnit(boolean ask) ;
    boolean isValidPersistenceUnit() ;

//    DBConfigModel getDBConfigModel() ;

//    void setDBConfigModel(DBConfigModel dbConfigModel) ;

    public void clear(EntityFilter entityFilter,Map<String,Object> hints)  ;
    
    void clear() ;

    @Deprecated
    void addPropertyChangeListener(String propertyName, PropertyChangeListener listener);

    @Deprecated
    void addPropertyChangeListener(PropertyChangeListener listener);

    @Deprecated
    void removePropertyChangeListener(String propertyName, PropertyChangeListener listener);

    @Deprecated
    void removePropertyChangeListener(PropertyChangeListener listener);

    PropertyChangeListener[] getPropertyChangeListeners();

    PropertyChangeListener[] getPropertyChangeListeners(String propertyName);

    //    DefaultDatabase.LocalizedDatabase getLocalizedDatabase();
    int getStatus() ;

    void setStatus(int status) ;

    //--------------------------- PROPERTIES SUPPORT
    Properties getProperties() ;

    boolean isAskOnCheckCreatedPersistenceUnit() ;

    void setAskOnCheckCreatedPersistenceUnit(boolean askOnCheckCreatedPersistenceUnit) ;

    public Class getEntityExtensionSupportType(Class entityExtensionType) ;

    public UPASecurityManager getSecurityManager() ;

    /**
     * @param definitionListener
     * @param trackSystem when true system entities are also tracked
     */
    public void addDefinitionListener(DefinitionListener definitionListener, boolean trackSystem);

    /**
     * @param entityName
     * @param definitionListener
     * @param trackSystem when true system entities are also tracked
     */
    public void addDefinitionListener(String entityName, DefinitionListener definitionListener, boolean trackSystem);

    public void addDefinitionListener(Class entityType, DefinitionListener definitionListener, boolean trackSystem);

    /**
     * system entities are not tracked
     *
     * @param definitionListener
     */
    public void addDefinitionListener(DefinitionListener definitionListener);

    /**
     * system entities are not tracked
     *
     * @param entityName
     * @param definitionListener
     */
    public void addDefinitionListener(String entityName, DefinitionListener definitionListener);

    public void removeDefinitionListener(DefinitionListener definitionListener);

    public void removeDefinitionListener(String entityName, DefinitionListener definitionListener);

    public void removeDefinitionListener(Class entityType, DefinitionListener definitionListener);

    //    Application getApplication();
//
//    void setApplication(Application application);
    void addPersistenceUnitListener(PersistenceUnitListener listener) ;

    void removePersistenceUnitListener(PersistenceUnitListener listener) ;

    //    List<StructureInterceptor> getRelationListeners(String entityName1, String entityName2);
    List<PersistenceUnitListener> getPersistenceUnitListeners() ;

    //    void saveConfig(Configuration configuration);
//
//    void loadConfig(Configuration configuration);
    //    public void storeConfigModel(DBConfigModel configModel) {
    //        application.getConfigurationManager().getStartupConfiguration().setStringArray("used_adapters", configModel.getAdaptersStringArray(), '\n');
    //        application.getAppInfos().setString(REG_PERSISTENCE_MANAGER, configModel.getAdapterString());
    //    }
    //
    //    public DBConfigModel loadConfigModel(DBConfigModel configModel) {
    //        configModel.setAdapterString(application.getAppInfos().getString(REG_PERSISTENCE_MANAGER, null));
    //        configModel.setAdaptersStringArray(application.getConfigurationManager().getStartupConfiguration().getStringArray("used_adapters", new String[]{configModel.getAdapterString()}));
    //        return configModel;
    //    }
//    DBMacroHelper getDbMacroHelper();
    PersistenceStoreFactory getPersistenceStoreFactory() ;

    void addSQLParameterProcessor(QLParameterProcessor p) ;

    void removeSQLParameterProcessor(QLParameterProcessor p) ;

    I18NStringStrategy getI18NStringStrategy() ;

    public LockInfo getPersistenceUnitLockingInfo() ;

    public void lockPersistenceUnit(String id) ;

    public void unlockPersistenceUnit(String id) ;

    public LockInfo getLockingInfo(Entity entity) ;

    public void lockEntityManager(Entity entity, String id) ;

    public void unlockEntityManager(Entity entity, String id) ;

    public List<LockInfo> getLockingInfo(Entity entity, Expression expression) ;

    public void lockEntities(Entity entity, Expression expression, String id) ;

    public void unlockEntities(Entity entity, Expression expression, String id) ;

    ////////////////////////////////////////
    // LISTENERS
    //////////////////////////////////////////////////////////////////
    //
    // Triggers
    //
    //////////////////////////////////////////////////////////////////
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
    void addTrigger(String triggerName, EntityInterceptor interceptor, String entityNamePattern, boolean system) ;

    void dropTrigger(String entityName, String triggerName) ;

    List<Trigger> getTriggers(String entityName) ;

//    PersistenceUnitTrigger addPersistenceUnitTrigger(String name, PersistenceUnitInterceptor interceptor) ;
//    void removePersistenceUnitTrigger(String triggerName) ;
//    List<PersistenceUnitTrigger> getPersistenceUnitTriggers() ;
    boolean isTriggersEnabled() ;

    void setTriggersEnabled(boolean triggersEnabled) ;

    //////////////////////////////////////////////////////////////////////
    public ConnectionProfile getConnectionProfile() ;

    public void persist(String entityName, Object objectOrDocument) ;
    public void persist(String entity, Object objectOrDocument,Map<String,Object> hints) ;

    public void persist(Object objectOrDocument) ;

    public RemoveTrace remove(String entityName, Object objectOrDocument) ;

    public RemoveTrace remove(Object objectOrDocument) ;

    public UpdateQuery createUpdateQuery(String entityName) ;

    public UpdateQuery createUpdateQuery(Class type) ;

    public UpdateQuery createUpdateQuery(Object object) ;

    public void merge(String entityName,Object objectOrDocument);

    public void merge(Object objectOrDocument) ;

    public void update(Object objectOrDocument) ;

    public boolean save(Object objectOrDocument) ;


//    public void merge(String entityName, Object objectOrDocument,Map<String,Object> hints) ;
//    public void merge(String entityName, Object objectOrDocument) ;
//
    public boolean save(String entityName, Object objectOrDocument) ;
//    public boolean save(String entityName, Object objectOrDocument,Map<String,Object> hints) ;
//
//
    public void update(String entityName, Object objectOrDocument) ;
//    public void update(String entityName, Object objectOrDocument,Map<String,Object> hints) ;
//
//
//    public void updatePartial(String entityName, Object objectOrDocument,String... fields)  ;
//
//    public void updatePartial(String entityName, Object objectOrDocument,Set<String> fields, boolean ignoreUnspecified)  ;
//
//    public void updatePartial(String entityName, Object objectOrDocument,Map<String,Object> hints,String... fields)  ;
//
//    public void updatePartial(String entityName, Object objectOrDocument,Set<String> fields, boolean ignoreUnspecified,Map<String,Object> hints)  ;
//
//    public void updatePartial(Object objectOrDocument,String... fields)  ;
//
//    public void updatePartial(Object objectOrDocument,Set<String> fields,boolean ignoreUnspecified)  ;
//
//    public void updatePartial(Object objectOrDocument) ;
//
//    public void updatePartial(String entityName, Object objectOrDocument) ;
//    public void updatePartial(String entityName, Object objectOrDocument,Map<String,Object> hints) ;

    void updateFormulas() ;

    public void updateFormulas(EntityFilter entityFilter,Map<String,Object> hints) throws UPAException ;

    //////////
//    public int updateDocuments(String entityName, Document document, Expression condition) ;
//    public int updateDocuments(String entityName, Document document, Expression condition,Map<String,Object> hints) ;

//    public void updateFormulas(String entityName, FieldFilter filter, Expression expr) ;
//    public void updateFormulas(String entityName, FieldFilter filter, Expression expr,Map<String,Object> hints) ;

//    public void updateFormulasById(String entityName, FieldFilter filter, Object id) ;
//    public void updateFormulasById(String entityName, FieldFilter filter, Object id,Map<String,Object> hints) ;

//    public int updateDocuments(Class entityType, Document document, Expression condition) ;

//    public void updateFormulas(Class entityType, FieldFilter filter, Expression expr) ;

//    public void updateFormulasById(Class entityType, FieldFilter filter, Object id) ;

    //////// REMOVE
    public RemoveTrace remove(Class entityType, Object object) ;

    public RemoveTrace remove(Class entityType, RemoveOptions options) ;

    public RemoveTrace remove(String entityName, RemoveOptions options) ;

    public <T> List<T> findAll(Class entityType) ;

    public <T> List<T> findAll(String entityName) ;

    public <T> List<T> findAllIds(String entityName) ;

    public <T> T findByMainField(Class entityType, Object mainFieldValue) ;

    public <T> T findByMainField(String entityName, Object mainFieldValue) ;

    public <T> T findByField(Class entityType, String fieldName, Object mainFieldValue) ;

    public <T> T findByField(String entityName, String fieldName, Object mainFieldValue) ;

    public <T> T findById(Class entityType, Object id) ;

    public <T> T findById(String entityName, Object id) ;

    public boolean existsById(String entityName, Object id) ;

    public List<Document> findAllDocuments(Class entityType) ;

    public List<Document> findAllDocuments(String entityName) ;

    public Document findDocumentById(Class entityType, Object id) ;

    public Document findDocumentById(String entityName, Object id) ;

    public QueryBuilder createQueryBuilder(Class entityType) ;

    public QueryBuilder createQueryBuilder(String entityName) ;

    public Query createQuery(EntityStatement query) ;

    public Query createQuery(String query) ;

    /**
     *
     * @param transactionType
     * @return true if a transaction has been created
     * @
     */
    public boolean beginTransaction(TransactionType transactionType) ;

    public void commitTransaction() ;

    public void rollbackTransaction() ;

    public boolean isStarted() ;

    public boolean isValidStructureModificationContext() ;

    public boolean isStructureModification() ;

    public void beginStructureModification() ;

    public void commitStructureModification() ;

    public boolean isClosed() ;

    //    public Expression parse(String query) ;
//
//    public net.vpc.upa.expressions.CompiledExpression compile(Expression expression, ExpressionCompilerConfig compilerConfig) ;
//
//    public net.vpc.upa.expressions.CompiledExpression compile(net.vpc.upa.expressions.CompiledExpression expression, ExpressionCompilerConfig compilerConfig) ;
//
//    public QLFunction addQLFunction(String name, DataType type, QLFunctionHandler function);
//
//    public void removeQLFunction(String name);
//
//    public boolean containsQLFunction(String name);
//
//    public Set<String> getQLFunctionNames();
//
//    public QLFunction getQLFunction(String name);
    public ExpressionManager getExpressionManager();

    public ImportExportManager getImportExportManager();

    public void init(String name, PersistenceGroup persistenceGroup);

    public DataTypeTransformFactory getTypeTransformFactory();

    public void setTypeTransformFactory(DataTypeTransformFactory typeTransformFactory);

    public ConnectionConfig[] getConnectionConfigs();

    public ConnectionConfig[] getRootConnectionConfigs();

    public void addConnectionConfig(ConnectionConfig connectionConfig);

    public void removeConnectionConfig(int index);

    public void addRootConnectionConfig(ConnectionConfig connectionConfig);

    public void removeRootConnectionConfig(int index);

    public void setPersistenceNameConfig(PersistenceNameConfig nameStrategyModel);

    public PersistenceNameConfig getPersistenceNameConfig();

    public void addContextAnnotationStrategyFilter(ScanFilter filter);

    public void removeContextAnnotationStrategyFilter(ScanFilter filter);

    public ScanFilter[] getContextAnnotationStrategyFilters();

    public UserPrincipal getUserPrincipal();

    /**
     * push new user context if login and credentials are valid
     *
     * @param login
     * @param credentials
     */
    public void login(String login, String credentials);

    public void loginPrivileged(String login);

    /**
     * logout from previous login. should be valid only if login succeeded
     */
    public void logout();

    public boolean currentSessionExists();

    public Session getCurrentSession() ;

    public Key createKey(Object... keyValues) ;

    public Callback addCallback(CallbackConfig callbackConfig);

    public void addCallback(Callback callback);

    public void removeCallback(Callback callback);

    public Callback[] getCallbacks(CallbackType callbackType, ObjectType objectType, String name, boolean system,boolean preparedOnly, EventPhase phase);

    public UConnection getConnection() ;

    public void setIdentityConstraintsEnabled(Entity entity, boolean enable);


    public <T> T invoke(Action<T> action, InvokeContext invokeContext) ;

    public <T> T invoke(Action<T> action) ;

    public <T> T invokePrivileged(Action<T> action, InvokeContext invokeContext) ;

    public <T> T invokePrivileged(Action<T> action) ;

    public void invoke(VoidAction action, InvokeContext invokeContext) ;

    public void invoke(VoidAction action) ;

    public void invokePrivileged(VoidAction action, InvokeContext invokeContext) ;

    public void invokePrivileged(VoidAction action) ;
    
    public Comparator<Entity> getDependencyComparator() ;

    public <T> T copyObject(T r);
    public <T> T copyObject(String entityName,T r);
    public <T> T copyObject(Class entityType,T r);

    public boolean isEmpty(String entityName) ;

    public boolean isEmpty(Class entityType) ;

    public long getEntityCount(String entityName) ;

    public long getEntityCount(Class entityType) ;

}
