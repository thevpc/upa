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
import net.vpc.upa.filters.FieldFilter;
import net.vpc.upa.persistence.*;
import net.vpc.upa.types.DataTypeTransformFactory;
import net.vpc.upa.types.I18NString;

import java.beans.PropertyChangeListener;
import java.util.List;
import java.util.Set;

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

    Session openSession() throws UPAException;

    ObjectFactory getFactory() throws UPAException;

    PersistenceGroup getPersistenceGroup() throws UPAException;

    //    void setPersistenceGroup(PersistenceGroup persistenceGroup) throws UPAException;
    I18NString getTitle() throws UPAException;

    //    void add(PersistenceUnitItem part);
//    void remove(int index) throws UPAException;
//    void move(int index, int newIndex) throws UPAException;
//    void move(int index, int newIndex, int count) throws UPAException;
//    void invalidate() throws UPAException;
//    List<PersistenceUnitItem> getChildren() throws UPAException;
//    int indexOf(PersistenceUnitItem child) throws UPAException;
//    int indexOf(String childName) throws UPAException;
    Package addPackage(String name, String parentPath) throws UPAException;

    Package addPackage(String name, String parentPath, int index) throws UPAException;

    Package addPackage(String name) throws UPAException;

    Package addPackage(String name, int index) throws UPAException;

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
    boolean isReadOnly() throws UPAException;

    void setReadOnly(boolean enable) throws UPAException;

    //    void declareInternEntities();
//    void declareEntities();
//    String getDefaultAdapterString();
//
//    void setDefaultConnectionString(String defaultAdapterString);
    String getName() throws UPAException;

    //    void setName(String name) throws UPAException;
    boolean isLastStartSucceeded() throws UPAException;

    void setLastStartSucceeded(boolean success) throws UPAException;

    boolean isRecurseDelete() throws UPAException;

    boolean isLockablePersistenceUnit() throws UPAException;

    boolean isCaseSensitive() throws UPAException;

    void setCaseSensitive(boolean enable) throws UPAException;

    NamingStrategy getNamingStrategy() throws UPAException;

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
     * @throws UPAException
     */
    Entity addEntity(Object descriptor) throws UPAException;

    //    public Index addIndex(String indexName, String entityName, boolean unique, List<String> fieldNames) throws UPAException;
    public List<Index> getIndexes() throws UPAException;

    public List<Index> getIndexes(String entityName) throws UPAException;

    boolean containsEntity(String entityName) throws UPAException;

    /**
     * @param source source to be parsed
     * @param listener listener to track scanned items or null
     * @param configure if true process configuration (add entities,
     * functions...)
     * @throws UPAException
     */
    void scan(ScanSource source, ScanListener listener, boolean configure) throws UPAException;

    boolean containsField(String entityName, String fieldName) throws UPAException;

    Entity getEntity(String entityName) throws UPAException;

    //    <K, R> Entity<K, R> getEntity(String entityName, boolean check);
    public boolean containsEntity(Class entityType) throws UPAException;

    public Entity findEntity(Class entityType) throws UPAException;

    public List<Entity> findEntities(Class entityType) throws UPAException;

    public Entity findEntity(String entityName) throws UPAException;

    public Entity getEntity(Class entityType) throws UPAException;

    //    int getExplicitEntitiesCount() throws UPAException;
    public void addRelationship(RelationshipDescriptor relationDescriptor) throws UPAException;

    //    public Relationship addRelation(String name, RelationType type, String detailEntityName, String masterEntityName, String detailFieldName, String masterfieldName, RelationUpdateType detailUpdateType, RelationUpdateType masterUpdateType, String[] detailFieldNames, boolean nullable, Expression filter) throws UPAException;
    void reset() throws UPAException;

    List<Entity> getEntities() throws UPAException;

    List<Package> getPackages() throws UPAException;

    List<Entity> getEntities(EntityFilter entityFilter) throws UPAException;

    List<Relationship> getRelationships() throws UPAException;

    Relationship getRelationship(String name) throws UPAException;

    boolean containsRelationship(String relationName) throws UPAException;

    List<Relationship> getRelationshipsForTarget(Entity entity) throws UPAException;

    List<Relationship> getRelationshipsForSource(Entity entity) throws UPAException;

    //    List<Field> findField(String name) throws UPAException;
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
    void installDemoData() throws UPAException;

    void start() throws UPAException;

    public boolean isSystemSession(Session s);

    String getPersistenceName() throws UPAException;

    void setPersistenceName(String persistenceName) throws UPAException;

    //    List<Entity> getAllPersistentEntities() throws UPAException;
//
//    List<Entity> getAllViewEntities() throws UPAException;
    //    boolean checkCreatedSilently() throws UPAException;
//    boolean checkCreatedPersistenceUnit(boolean ask) throws UPAException;
    boolean isValidPersistenceUnit() throws UPAException;

    DBConfigModel getDBConfigModel() throws UPAException;

    void setDBConfigModel(DBConfigModel dbConfigModel) throws UPAException;

    public void clear(EntityFilter entityFilter) throws UPAException ;
    
    void clear() throws UPAException;

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
    int getStatus() throws UPAException;

    void setStatus(int status) throws UPAException;

    //--------------------------- PROPERTIES SUPPORT
    Properties getProperties() throws UPAException;

    boolean isAskOnCheckCreatedPersistenceUnit() throws UPAException;

    void setAskOnCheckCreatedPersistenceUnit(boolean askOnCheckCreatedPersistenceUnit) throws UPAException;

    public Class getEntityExtensionSupportType(Class entityExtensionType) throws UPAException;

    public UPASecurityManager getSecurityManager() throws UPAException;

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
    void addPersistenceUnitListener(PersistenceUnitListener listener) throws UPAException;

    void removePersistenceUnitListener(PersistenceUnitListener listener) throws UPAException;

    //    List<StructureInterceptor> getRelationListeners(String entityName1, String entityName2);
    List<PersistenceUnitListener> getPersistenceUnitListeners() throws UPAException;

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
    PersistenceStoreFactory getPersistenceStoreFactory() throws UPAException;

    void addSQLParameterProcessor(QLParameterProcessor p) throws UPAException;

    void removeSQLParameterProcessor(QLParameterProcessor p) throws UPAException;

    I18NStringStrategy getI18NStringStrategy() throws UPAException;

    public LockInfo getPersistenceUnitLockingInfo() throws UPAException;

    public void lockPersistenceUnit(String id) throws UPAException;

    public void unlockPersistenceUnit(String id) throws UPAException;

    public LockInfo getLockingInfo(Entity entity) throws UPAException;

    public void lockEntityManager(Entity entity, String id) throws UPAException;

    public void unlockEntityManager(Entity entity, String id) throws UPAException;

    public List<LockInfo> getLockingInfo(Entity entity, Expression expression) throws UPAException;

    public void lockEntities(Entity entity, Expression expression, String id) throws UPAException;

    public void unlockEntities(Entity entity, Expression expression, String id) throws UPAException;

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
     * @throws UPAException
     */
    void addTrigger(String triggerName, EntityInterceptor interceptor, String entityNamePattern, boolean system) throws UPAException;

    void dropTrigger(String entityName, String triggerName) throws UPAException;

    List<Trigger> getTriggers(String entityName) throws UPAException;

//    PersistenceUnitTrigger addPersistenceUnitTrigger(String name, PersistenceUnitInterceptor interceptor) throws UPAException;
//    void removePersistenceUnitTrigger(String triggerName) throws UPAException;
//    List<PersistenceUnitTrigger> getPersistenceUnitTriggers() throws UPAException;
    boolean isTriggersEnabled() throws UPAException;

    void setTriggersEnabled(boolean triggersEnabled) throws UPAException;

    //////////////////////////////////////////////////////////////////////
    public ConnectionProfile getConnectionProfile() throws UPAException;

    public void persist(String entityName, Object objectOrRecord) throws UPAException;

    public void persist(Object objectOrRecord) throws UPAException;

    public RemoveTrace remove(String entityName, Object objectOrRecord) throws UPAException;

    public RemoveTrace remove(Object objectOrRecord) throws UPAException;

    public void merge(Object objectOrRecord) throws UPAException;

    public void merge(String entityName, Object objectOrRecord) throws UPAException;

    public boolean save(Object objectOrRecord) throws UPAException;

    public boolean save(String entityName, Object objectOrRecord) throws UPAException;

    public void update(Object objectOrRecord) throws UPAException;

    public void update(String entityName, Object objectOrRecord) throws UPAException;


    public void updatePartial(String entityName, Object objectOrRecord,String... fields) throws UPAException ;

    public void updatePartial(String entityName, Object objectOrRecord,Set<String> fields, boolean ignoreUnspecified) throws UPAException ;

    public void updatePartial(Object objectOrRecord,String... fields) throws UPAException ;

    public void updatePartial(Object objectOrRecord,Set<String> fields,boolean ignoreUnspecified) throws UPAException ;

    public void updatePartial(Object objectOrRecord) throws UPAException;

    public void updatePartial(String entityName, Object objectOrRecord) throws UPAException;

    void updateFormulas() throws UPAException;

    void updateFormulas(Entity[] entities) throws UPAException;

    //////////
    public int updateRecords(String entityName, Record record, Expression condition) throws UPAException;

    public void updateFormulas(String entityName, FieldFilter filter, Expression expr) throws UPAException;

    public void updateFormulasById(String entityName, FieldFilter filter, Object id) throws UPAException;

    public int updateRecords(Class entityType, Record record, Expression condition) throws UPAException;

    public void updateFormulas(Class entityType, FieldFilter filter, Expression expr) throws UPAException;

    public void updateFormulasById(Class entityType, FieldFilter filter, Object id) throws UPAException;

    //////// REMOVE
    public RemoveTrace remove(Class entityType, Object object) throws UPAException;

    public RemoveTrace remove(Class entityType, RemoveOptions options) throws UPAException;

    public RemoveTrace remove(String entityName, RemoveOptions options) throws UPAException;

    public <T> List<T> findAll(Class entityType) throws UPAException;

    public <T> List<T> findAll(String entityName) throws UPAException;

    public <T> List<T> findAllIds(String entityName) throws UPAException;

    public <T> T findByMainField(Class entityType, Object mainFieldValue) throws UPAException;

    public <T> T findByMainField(String entityName, Object mainFieldValue) throws UPAException;

    public <T> T findByField(Class entityType, String fieldName, Object mainFieldValue) throws UPAException;

    public <T> T findByField(String entityName, String fieldName, Object mainFieldValue) throws UPAException;

    public <T> T findById(Class entityType, Object id) throws UPAException;

    public <T> T findById(String entityName, Object id) throws UPAException;

    public boolean existsById(String entityName, Object id) throws UPAException;

    public List<Record> findAllRecords(Class entityType) throws UPAException;

    public List<Record> findAllRecords(String entityName) throws UPAException;

    public Record findRecordById(Class entityType, Object id) throws UPAException;

    public Record findRecordById(String entityName, Object id) throws UPAException;

    public QueryBuilder createQueryBuilder(Class entityType) throws UPAException;

    public QueryBuilder createQueryBuilder(String entityName) throws UPAException;

    public Query createQuery(EntityStatement query) throws UPAException;

    public Query createQuery(String query) throws UPAException;

    /**
     *
     * @param transactionType
     * @return true if a transaction has been created
     * @throws UPAException
     */
    public boolean beginTransaction(TransactionType transactionType) throws UPAException;

    public void commitTransaction() throws UPAException;

    public void rollbackTransaction() throws UPAException;

    public boolean isStarted() throws UPAException;

    public boolean isValidStructureModificationContext() throws UPAException;

    public boolean isStructureModification() throws UPAException;

    public void beginStructureModification() throws UPAException;

    public void commitStructureModification() throws UPAException;

    public void close() throws UPAException;

    public boolean isClosed() throws UPAException;

    //    public Expression parse(String query) throws UPAException;
//
//    public net.vpc.upa.expressions.CompiledExpression compile(Expression expression, ExpressionCompilerConfig compilerConfig) throws UPAException;
//
//    public net.vpc.upa.expressions.CompiledExpression compile(net.vpc.upa.expressions.CompiledExpression expression, ExpressionCompilerConfig compilerConfig) throws UPAException;
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

    public Session getCurrentSession() throws UPAException;

    public Key createKey(Object... keyValues) throws UPAException;

    public Callback addCallback(CallbackConfig callbackConfig);

    public void addCallback(Callback callback);

    public void removeCallback(Callback callback);

    public Callback[] getCallbacks(CallbackType callbackType, ObjectType objectType, String name, boolean system, EventPhase phase);

    public UConnection getConnection() throws UPAException;

    public void setIdentityConstraintsEnabled(Entity entity, boolean enable);


    public <T> T invoke(Action<T> action, InvokeContext invokeContext) throws UPAException;

    public <T> T invoke(Action<T> action) throws UPAException;

    public <T> T invokePrivileged(Action<T> action, InvokeContext invokeContext) throws UPAException;

    public <T> T invokePrivileged(Action<T> action) throws UPAException;

    public void invoke(VoidAction action, InvokeContext invokeContext) throws UPAException;

    public void invoke(VoidAction action) throws UPAException;

    public void invokePrivileged(VoidAction action, InvokeContext invokeContext) throws UPAException;

    public void invokePrivileged(VoidAction action) throws UPAException;
}
