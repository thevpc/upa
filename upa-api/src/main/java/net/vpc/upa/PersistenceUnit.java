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
    boolean isAutoScan();

    void setAutoScan(boolean autoScan);

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
    Package getPackage(String path, MissingStrategy missingStrategy);

    Package getPackage(String path);

    Package getDefaulPackage();

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

    PersistenceStore getPersistenceStore();

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

    //    Index addIndex(String indexName, String entityName, boolean unique, List<String> fieldNames) ;
    List<Index> getIndexes() ;

    List<Index> getIndexes(String entityName) ;

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
    boolean containsEntity(Class entityType) ;

    Entity findEntity(Class entityType) ;

    List<Entity> findEntities(Class entityType) ;

    Entity findEntity(String entityName) ;

    Entity getEntity(Class entityType) ;

    //    int getExplicitEntitiesCount() ;
    void addRelationship(RelationshipDescriptor relationDescriptor) ;

    //    Relationship addRelation(String name, RelationType type, String detailEntityName, String masterEntityName, String detailFieldName, String masterfieldName, RelationUpdateType detailUpdateType, RelationUpdateType masterUpdateType, String[] detailFieldNames, boolean nullable, Expression filter) ;
    void reset() ;

    void reset(Map<String,Object> hints);

    List<Entity> getEntities() ;

    List<Package> getPackages() ;

    List<Entity> getEntities(EntityFilter entityFilter) ;

    List<Relationship> getRelationships() ;

    Relationship getRelationship(String name) ;

    boolean containsRelationship(String relationName) ;

    List<Relationship> getRelationshipsByTarget(Entity entity) ;

    List<Relationship> getRelationshipsBySource(Entity entity) ;

    //    List<Field> findField(String name) ;
    //    Script getDisableIdentityConstraintsScript() {
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

    boolean isSystemSession(Session s);

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

    void clear(EntityFilter entityFilter,Map<String,Object> hints)  ;
    
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

    Class getEntityExtensionSupportType(Class entityExtensionType) ;

    UPASecurityManager getSecurityManager() ;

    /**
     * @param definitionListener
     * @param trackSystem when true system entities are also tracked
     */
    void addDefinitionListener(DefinitionListener definitionListener, boolean trackSystem);

    /**
     * @param entityName
     * @param definitionListener
     * @param trackSystem when true system entities are also tracked
     */
    void addDefinitionListener(String entityName, DefinitionListener definitionListener, boolean trackSystem);

    void addDefinitionListener(Class entityType, DefinitionListener definitionListener, boolean trackSystem);

    /**
     * system entities are not tracked
     *
     * @param definitionListener
     */
    void addDefinitionListener(DefinitionListener definitionListener);

    /**
     * system entities are not tracked
     *
     * @param entityName
     * @param definitionListener
     */
    void addDefinitionListener(String entityName, DefinitionListener definitionListener);

    void removeDefinitionListener(DefinitionListener definitionListener);

    void removeDefinitionListener(String entityName, DefinitionListener definitionListener);

    void removeDefinitionListener(Class entityType, DefinitionListener definitionListener);

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
    //    void storeConfigModel(DBConfigModel configModel) {
    //        application.getConfigurationManager().getStartupConfiguration().setStringArray("used_adapters", configModel.getAdaptersStringArray(), '\n');
    //        application.getAppInfos().setString(REG_PERSISTENCE_MANAGER, configModel.getAdapterString());
    //    }
    //
    //    DBConfigModel loadConfigModel(DBConfigModel configModel) {
    //        configModel.setAdapterString(application.getAppInfos().getString(REG_PERSISTENCE_MANAGER, null));
    //        configModel.setAdaptersStringArray(application.getConfigurationManager().getStartupConfiguration().getStringArray("used_adapters", new String[]{configModel.getAdapterString()}));
    //        return configModel;
    //    }
//    DBMacroHelper getDbMacroHelper();
    PersistenceStoreFactory getPersistenceStoreFactory() ;

    void addSQLParameterProcessor(QLParameterProcessor p) ;

    void removeSQLParameterProcessor(QLParameterProcessor p) ;

    I18NStringStrategy getI18NStringStrategy() ;

    LockInfo getPersistenceUnitLockingInfo() ;

    void lockPersistenceUnit(String id) ;

    void unlockPersistenceUnit(String id) ;

    LockInfo getLockingInfo(Entity entity) ;

    void lockEntityManager(Entity entity, String id) ;

    void unlockEntityManager(Entity entity, String id) ;

    List<LockInfo> getLockingInfo(Entity entity, Expression expression) ;

    void lockEntities(Entity entity, Expression expression, String id) ;

    void unlockEntities(Entity entity, Expression expression, String id) ;

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
    ConnectionProfile getConnectionProfile() ;

    void persist(String entityName, Object objectOrDocument) ;
    void persist(String entity, Object objectOrDocument,Map<String,Object> hints) ;

    void persist(Object objectOrDocument) ;

    RemoveTrace remove(String entityName, Object objectOrDocument) ;

    RemoveTrace remove(Object objectOrDocument) ;

    UpdateQuery createUpdateQuery(String entityName) ;

    UpdateQuery createUpdateQuery(Class type) ;

    UpdateQuery createUpdateQuery(Object object) ;

    void merge(String entityName,Object objectOrDocument);

    void merge(Object objectOrDocument) ;

    void update(Object objectOrDocument) ;

    boolean save(Object objectOrDocument) ;


//    void merge(String entityName, Object objectOrDocument,Map<String,Object> hints) ;
//    void merge(String entityName, Object objectOrDocument) ;
//
    boolean save(String entityName, Object objectOrDocument) ;
//    boolean save(String entityName, Object objectOrDocument,Map<String,Object> hints) ;
//
//
    void update(String entityName, Object objectOrDocument) ;
//    void update(String entityName, Object objectOrDocument,Map<String,Object> hints) ;
//
//
//    void updatePartial(String entityName, Object objectOrDocument,String... fields)  ;
//
//    void updatePartial(String entityName, Object objectOrDocument,Set<String> fields, boolean ignoreUnspecified)  ;
//
//    void updatePartial(String entityName, Object objectOrDocument,Map<String,Object> hints,String... fields)  ;
//
//    void updatePartial(String entityName, Object objectOrDocument,Set<String> fields, boolean ignoreUnspecified,Map<String,Object> hints)  ;
//
//    void updatePartial(Object objectOrDocument,String... fields)  ;
//
//    void updatePartial(Object objectOrDocument,Set<String> fields,boolean ignoreUnspecified)  ;
//
//    void updatePartial(Object objectOrDocument) ;
//
//    void updatePartial(String entityName, Object objectOrDocument) ;
//    void updatePartial(String entityName, Object objectOrDocument,Map<String,Object> hints) ;

    void updateFormulas() ;

    void updateFormulas(EntityFilter entityFilter,Map<String,Object> hints) throws UPAException ;

    //////////
//    int updateDocuments(String entityName, Document document, Expression condition) ;
//    int updateDocuments(String entityName, Document document, Expression condition,Map<String,Object> hints) ;

//    void updateFormulas(String entityName, FieldFilter filter, Expression expr) ;
//    void updateFormulas(String entityName, FieldFilter filter, Expression expr,Map<String,Object> hints) ;

//    void updateFormulasById(String entityName, FieldFilter filter, Object id) ;
//    void updateFormulasById(String entityName, FieldFilter filter, Object id,Map<String,Object> hints) ;

//    int updateDocuments(Class entityType, Document document, Expression condition) ;

//    void updateFormulas(Class entityType, FieldFilter filter, Expression expr) ;

//    void updateFormulasById(Class entityType, FieldFilter filter, Object id) ;

    //////// REMOVE
    RemoveTrace remove(Class entityType, Object object) ;

    RemoveTrace remove(Class entityType, RemoveOptions options) ;

    RemoveTrace remove(String entityName, RemoveOptions options) ;

    <T> List<T> findAll(Class entityType) ;

    <T> List<T> findAll(String entityName) ;

    <T> List<T> findAllIds(String entityName) ;

    <T> T findByMainField(Class entityType, Object mainFieldValue) ;

    <T> T findByMainField(String entityName, Object mainFieldValue) ;

    <T> T findByField(Class entityType, String fieldName, Object mainFieldValue) ;

    <T> T findByField(String entityName, String fieldName, Object mainFieldValue) ;

    <T> T findById(Class entityType, Object id) ;

    <T> T findById(String entityName, Object id) ;

    boolean existsById(String entityName, Object id) ;

    List<Document> findAllDocuments(Class entityType) ;

    List<Document> findAllDocuments(String entityName) ;

    Document findDocumentById(Class entityType, Object id) ;

    Document findDocumentById(String entityName, Object id) ;

    QueryBuilder createQueryBuilder(Class entityType) ;

    QueryBuilder createQueryBuilder(String entityName) ;

    Query createQuery(EntityStatement query) ;

    Query createQuery(String query) ;

    /**
     *
     * @param transactionType
     * @return true if a transaction has been created
     * @
     */
    boolean beginTransaction(TransactionType transactionType) ;

    void commitTransaction() ;

    void rollbackTransaction() ;

    boolean isStarted() ;

    boolean isValidStructureModificationContext() ;

    boolean isStructureModification() ;

    void beginStructureModification() ;

    void commitStructureModification() ;

    boolean isClosed() ;

    //    Expression parse(String query) ;
//
//    net.vpc.upa.expressions.CompiledExpression compile(Expression expression, ExpressionCompilerConfig compilerConfig) ;
//
//    net.vpc.upa.expressions.CompiledExpression compile(net.vpc.upa.expressions.CompiledExpression expression, ExpressionCompilerConfig compilerConfig) ;
//
//    QLFunction addQLFunction(String name, DataType type, QLFunctionHandler function);
//
//    void removeQLFunction(String name);
//
//    boolean containsQLFunction(String name);
//
//    Set<String> getQLFunctionNames();
//
//    QLFunction getQLFunction(String name);
    ExpressionManager getExpressionManager();

    ImportExportManager getImportExportManager();

    void init(String name, PersistenceGroup persistenceGroup);

    DataTypeTransformFactory getTypeTransformFactory();

    void setTypeTransformFactory(DataTypeTransformFactory typeTransformFactory);

    ConnectionConfig[] getConnectionConfigs();

    ConnectionConfig[] getRootConnectionConfigs();

    void addConnectionConfig(ConnectionConfig connectionConfig);

    void removeConnectionConfig(int index);

    void addRootConnectionConfig(ConnectionConfig connectionConfig);

    void removeRootConnectionConfig(int index);

    void setPersistenceNameConfig(PersistenceNameConfig nameStrategyModel);

    PersistenceNameConfig getPersistenceNameConfig();

    void addContextAnnotationStrategyFilter(ScanFilter filter);

    void removeContextAnnotationStrategyFilter(ScanFilter filter);

    ScanFilter[] getContextAnnotationStrategyFilters();

    UserPrincipal getUserPrincipal();

    /**
     * push new user context if login and credentials are valid
     *
     * @param login
     * @param credentials
     */
    void login(String login, String credentials);

    void loginPrivileged(String login);

    /**
     * logout from previous login. should be valid only if login succeeded
     */
    void logout();

    boolean currentSessionExists();

    Session getCurrentSession() ;

    Key createKey(Object... keyValues) ;

    Callback addCallback(CallbackConfig callbackConfig);

    void addCallback(Callback callback);

    void removeCallback(Callback callback);

    Callback[] getCallbacks(CallbackType callbackType, ObjectType objectType, String name, boolean system,boolean preparedOnly, EventPhase phase);

    UConnection getConnection() ;

    void setIdentityConstraintsEnabled(Entity entity, boolean enable);


    <T> T invoke(Action<T> action, InvokeContext invokeContext) ;

    <T> T invoke(Action<T> action) ;

    <T> T invokePrivileged(Action<T> action, InvokeContext invokeContext) ;

    <T> T invokePrivileged(Action<T> action) ;

    void invoke(VoidAction action, InvokeContext invokeContext) ;

    void invoke(VoidAction action) ;

    void invokePrivileged(VoidAction action, InvokeContext invokeContext) ;

    void invokePrivileged(VoidAction action) ;
    
    Comparator<Entity> getDependencyComparator() ;

    <T> T copyObject(T r);
    <T> T copyObject(String entityName,T r);
    <T> T copyObject(Class entityType,T r);

    boolean isEmpty(String entityName) ;

    boolean isEmpty(Class entityType) ;

    long getEntityCount(String entityName) ;

    long getEntityCount(Class entityType) ;

}
