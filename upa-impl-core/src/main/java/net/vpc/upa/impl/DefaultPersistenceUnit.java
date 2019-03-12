package net.vpc.upa.impl;

import net.vpc.upa.events.EntityInterceptor;
import net.vpc.upa.events.Trigger;
import net.vpc.upa.events.DefinitionListener;
import net.vpc.upa.events.TriggerDefinitionListener;
import net.vpc.upa.events.PersistenceUnitEvent;
import net.vpc.upa.events.PersistenceUnitListener;
import net.vpc.upa.DataTypeTransformFactory;
import net.vpc.upa.EntityExtensionDefinition;
import net.vpc.upa.FilterEntityExtensionDefinition;
import net.vpc.upa.ViewEntityExtensionDefinition;
import net.vpc.upa.UnionEntityExtensionDefinition;
import net.vpc.upa.SingletonExtensionDefinition;
import net.vpc.upa.SingletonExtension;
import net.vpc.upa.FilterEntityExtension;
import net.vpc.upa.ViewEntityExtension;
import net.vpc.upa.UnionEntityExtension;
import net.vpc.upa.HierarchyExtension;
import net.vpc.upa.impl.cache.EntityCollectionCache;
import net.vpc.upa.impl.sysentities.LockInfoDesc;
import net.vpc.upa.*;
import net.vpc.upa.Package;
import net.vpc.upa.Properties;
import net.vpc.upa.bulk.ImportExportManager;
import net.vpc.upa.config.ScanFilter;
import net.vpc.upa.config.ScanSource;
import net.vpc.upa.exceptions.*;
import net.vpc.upa.exceptions.IllegalUPAArgumentException;
import net.vpc.upa.expressions.*;
import net.vpc.upa.filters.DefaultEntityFilter;
import net.vpc.upa.filters.EntityFilter;
import net.vpc.upa.filters.FieldFilter;
import net.vpc.upa.filters.FieldFilters;
import net.vpc.upa.impl.config.*;
import net.vpc.upa.impl.config.annotationparser.RelationshipDescriptorProcessor;
import net.vpc.upa.impl.config.decorations.DecorationRepository;
import net.vpc.upa.impl.config.decorations.DefaultDecorationRepository;
import net.vpc.upa.impl.eval.CustomFormulaCallback;
import net.vpc.upa.impl.eval.CustomMultiFormulaCallback;
import net.vpc.upa.impl.eval.functions.FunctionCallback;
import net.vpc.upa.impl.eval.functions.PasswordQLFunction;
import net.vpc.upa.impl.event.PersistenceUnitListenerManager;
import net.vpc.upa.impl.ext.EntityExt;
import net.vpc.upa.impl.ext.PersistenceUnitExt;
import net.vpc.upa.impl.ext.persistence.EntityExecutionContextExt;
import net.vpc.upa.impl.ext.persistence.PersistenceStoreExt;
import net.vpc.upa.impl.extension.HierarchicalRelationshipDataInterceptor;
import net.vpc.upa.impl.extension.HierarchicalRelationshipSupport;
import net.vpc.upa.impl.persistence.CloseOnContextPopSessionListener;
import net.vpc.upa.impl.persistence.connection.ConnectionProfileParser;
import net.vpc.upa.impl.transform.DefaultPasswordStrategy;
import net.vpc.upa.impl.upql.DefaultExpressionManager;
import net.vpc.upa.impl.upql.util.UPQLUtils;
import net.vpc.upa.impl.util.*;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.persistence.*;
import net.vpc.upa.types.*;

import java.beans.PropertyChangeEvent;
import java.beans.PropertyChangeListener;
import java.beans.PropertyChangeSupport;
import java.sql.Timestamp;
import java.util.*;
import java.util.Date;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.impl.cache.EntityCollectionCacheDisabled;

//import net.vpc.upa.impl.util.ListUtils;
public class DefaultPersistenceUnit implements PersistenceUnitExt {

    public static final int STATUS_INITIALIZING = 0;
    private static final Logger log = Logger.getLogger(DefaultPersistenceUnit.class.getName());
    //    public static final NamingStrategy CASE_SENSITIVE_COMPARATOR = new CaseSensitiveNamingStrategy();
//    public static final NamingStrategy CASE_INSENSITIVE_COMPARATOR = new CaseInsensitiveNamingStrategy();
    public static final int COMMIT_ORDER_ENTITY = 10;
    public static final int COMMIT_ORDER_FIELD = 20;
    public static final int COMMIT_ORDER_TRIGGER = 20;
    public static final int COMMIT_ORDER_RELATION = 20;
    public static final int COMMIT_ORDER_INDEX = 20;
    public static final int COMMIT_ORDER_VIEW = 30;

    private net.vpc.upa.Properties properties;
    //    private net.vpc.upa.Properties systemParameters;
    private ConnectionProfile connectionProfile;
    private final UUID privateUUID = UUID.randomUUID();
    private EntityDescriptorResolver entityDescriptorResolver;
    private boolean triggersEnabled = true;
    private I18NString title = new I18NString("PersistenceUnitFilter.title");
    //    private NamingStrategy namingStrategy;
    //    private LinkedHashMap<String, Entity> allEntities;
//    private HashSet<String> entityShortNames = new HashSet<String>();
//    private List<Relationship> relations;
//    private List<Entity> initializableEntities = new ArrayList<Entity>();
    private PersistenceStoreExt persistenceStore;
    private boolean lastStartSucceeded;
    private boolean readOnly;
    private String name;
    private boolean initCalled;
    private String persistenceName;
    private PersistenceGroup persistenceGroup;
    private boolean structureModification;
    private boolean autoStart;
    private boolean started;
    private boolean starting;
    private boolean closed;
    private boolean autoScan = true;
    private boolean inheritScanFilters = true;
    private PropertyChangeSupport propertyChangeSupport;
    private PersistenceUnitListenerManager persistenceUnitListenerManager;
    private ObjectRegistrationModel registrationModel;
    private int status = STATUS_INITIALIZING;
    private boolean askOnCheckCreatedPersistenceUnit = true;
    private I18NStringStrategy i18NStringStrategy;
    private PersistenceStoreFactory persistenceStoreFactory;
    private List<QLParameterProcessor> parameterProcessors = new ArrayList<QLParameterProcessor>();
    //    private Map<String, Trigger> allTriggers = new HashMap<String, Trigger>();
    public List<OnHoldCommitAction> commitModelActions = new ArrayList<OnHoldCommitAction>();
    public List<OnHoldCommitAction> commitStorageActions = new ArrayList<OnHoldCommitAction>();
    private TransactionManagerFactory transactionManagerFactory;
    private DataTypeTransformFactory typeTransformFactory;
    private TransactionManager transactionManager;
    private ImportExportManager importExportManager;
    private List<ScanFilter> filters = new ArrayList<ScanFilter>();
    private List<ConnectionConfig> connectionConfigs = new ArrayList<ConnectionConfig>();
    private List<ConnectionConfig> rootConnectionConfigs = new ArrayList<ConnectionConfig>();
    private DefaultExpressionManager expressionManager;
    private Package defaultPackage;

    private PersistenceUnitExt sessionAwarePU;
    private DecorationRepository decorationRepository;
    private int triggerAnonymousNameIndex = 1;
    private Map<String, Object> defaultHints;
    private HashMap<String, NamedFormulaDefinition> namedFormulas = new HashMap<String, NamedFormulaDefinition>();
    private PersistenceNameStrategy persistenceNameStrategy;
    private boolean caseSensitiveIdentifiers = false;
    private EntityCollectionCache persistenceUnitCache;

    public DefaultPersistenceUnit() {
//        this.allEntities = new LinkedHashMap<String, Entity>();
//        this.relations = new ArrayList<Relationship>();
    }

    public boolean isAutoScan() {
        return autoScan;
    }

    public void setAutoScan(boolean autoScan) {
        this.autoScan = autoScan;
    }

    public boolean isInheritScanFilters() {
        return inheritScanFilters;
    }

    public void setInheritScanFilters(boolean inheritScanFilters) {
        this.inheritScanFilters = inheritScanFilters;
    }

    public void init(String name, PersistenceGroup persistenceGroup) {
        properties = new DefaultProperties(persistenceGroup.getProperties());
        if (initCalled) {
            throw new UPAException("PersistenceUnitAlreadyInitialized");
        } else {
            initCalled = true;
        }
        this.name = name;
        this.decorationRepository = new DefaultDecorationRepository("DecoRepo[pu=" + getAbsoluteName() + "]", true);
        this.persistenceGroup = persistenceGroup;
        this.persistenceStore = null;
//        this.namingStrategy = CASE_INSENSITIVE_COMPARATOR;
        this.propertyChangeSupport = new PropertyChangeSupport(this);
        this.entityDescriptorResolver = new EntityDescriptorResolver(this, decorationRepository);
        this.expressionManager = new DefaultExpressionManager(this);
        this.registrationModel = new DefaultPersistenceUnitRegistrationModel(this);
        this.persistenceUnitListenerManager = new PersistenceUnitListenerManager(this, registrationModel, decorationRepository);
        this.typeTransformFactory = getFactory().createObject(DataTypeTransformFactory.class);
        postponeCommit(new CreateStorageOnHoldCommitAction());
        addDefinitionListener(new PostponeCommitHandler(), true);
        addPersistenceUnitListener(new UPASystemEntitiesTrigger(this));
        //add default MD5 function
        getExpressionManager().addFunction("MD5", StringType.UNLIMITED, new PasswordQLFunction(DefaultPasswordStrategy.MD5));
        getExpressionManager().addFunction("SHA1", StringType.UNLIMITED, new PasswordQLFunction(DefaultPasswordStrategy.SHA1));
        getExpressionManager().addFunction("SHA256", StringType.UNLIMITED, new PasswordQLFunction(DefaultPasswordStrategy.SHA256));
        getExpressionManager().addFunction("HASH", StringType.UNLIMITED, new PasswordQLFunction(DefaultPasswordStrategy.MD5));
        this.persistenceNameStrategy = getFactory().createObject(PersistenceNameStrategy.class);

        //there is an issue with global cache : how to manage an object retrived with distinct fields filters ?
        //will disable it for now!!
        //persistenceUnitCache = new PersistenceUnitCache(1024, this);
        persistenceUnitCache = new EntityCollectionCacheDisabled();
    }

    private void invalidate() {
        //needsRevalidateCache=true;
        persistenceUnitCache.invalidate();
    }

    public EntityCollectionCache getPersistenceUnitCache() {
        return persistenceUnitCache;
    }

    //    @Override
//    public List<PersistenceUnitItem> getChildren() {
//        return persistenceUnitItems;
//    }
//
//    @Override
//    public int indexOf(PersistenceUnitItem child) {
//        return persistenceUnitItems.indexOf(child);
//    }
//
//    @Override
//    public int indexOf(String childName) {
//        for (int i = 0; i < persistenceUnitItems.size(); i++) {
//            if (childName.equals(persistenceUnitItems.get(i).getName())) {
//                return i;
//            }
//        }
//        return -1;
//    }
    @Override
    public Package addPackage(String name, String parentPath) {
        return addPackage(name, parentPath, -1);
    }

    @Override
    public Package addPackage(String name, String parentPath, int index) {
        if (name == null) {
            throw new NullPointerException();
        }
        if (name.contains("/")) {
            throw new IllegalUPAArgumentException("Name cannot contain '/'");
        }
        String[] canonicalPathArray = UPAUtils.getCanonicalPathArray(parentPath);
        Package parentModule = null;
        for (String n : canonicalPathArray) {
            Package next = null;
            if (parentModule == null) {
                next = getPackage(n);
            } else {
                next = parentModule.getItem(n);
            }
            parentModule = next;
        }

        Package currentModule = getFactory().createObject(Package.class);
        currentModule.setPreferredPosition(index);
        UPAUtils.preparePreAdd(this, null, currentModule, name);
        if (parentModule == null) {
            getPackage(null).addItem(currentModule);
        } else {
            parentModule.addItem(currentModule);
        }
        invalidate();
        return currentModule;
    }

    @Override
    public Package addPackage(String name) {
        return addPackage(name, null, -1);
    }

    @Override
    public Package addPackage(String name, int index) {
        return addPackage(name, null, index);
    }

    public Package getPackage(String path) {
        return getPackage(path, MissingStrategy.ERROR);
    }

    public Package getDefaultPackage() {
        if (defaultPackage == null) {
            //should return default package
            Package currentModule = getFactory().createObject(Package.class);
            UPAUtils.prepare(this, currentModule, "");
            persistenceUnitListenerManager.addHandlers(currentModule);
            defaultPackage = currentModule;
        }
        return defaultPackage;
    }

    public Package getPackage(String path, MissingStrategy missingStrategy) {
        if (path == null) {
            return getDefaultPackage();
        }

        String[] canonicalPathArray = UPAUtils.getCanonicalPathArray(path);
        if (canonicalPathArray.length == 0) {
            return getDefaultPackage();
        }
        Package module = null;
        for (String n : canonicalPathArray) {
            Package next = null;
            if (module == null) {
                for (PersistenceUnitItem persistenceUnitItem : getDefaultPackage().getItems()) {
                    if (persistenceUnitItem instanceof Package) {
                        if (persistenceUnitItem.getName().equals(n)) {
                            next = (Package) persistenceUnitItem;
                            break;
                        }
                    }
                }
                if (next == null) {
                    switch (missingStrategy) {
                        case ERROR: {
                            throw new NoSuchPackageException(path, null);
                        }
                        case CREATE: {
                            next = addPackage(n, null);
                            break;
                        }
                        case NULL: {
                            return null;
                        }
                        default: {
                            throw new UnsupportedUPAFeatureException();
                        }
                    }
                }
            } else {
                try {
                    next = module.getItem(n);
                } catch (NoSuchPackageException e) {
                    switch (missingStrategy) {
                        case ERROR: {
                            throw new NoSuchPackageException(path, e);
                        }
                        case CREATE: {
                            next = addPackage(n, module.getPath());
                            break;
                        }
                        case NULL: {
                            return null;
                        }
                        default: {
                            throw new UnsupportedUPAFeatureException();
                        }
                    }
                }
            }
            module = next;
        }
        return module;
    }

    //    @Override
//    public Resources getResources() {
//        return getApplication().getResources();
//    }
    @Override
    public boolean isReadOnly() {
        return readOnly;
    }

    @Override
    public void setReadOnly(boolean enable) {
        readOnly = enable;
        if (persistenceStore != null) {
            persistenceStore.setReadOnly(enable);
        }
    }

    //    @Override
//    public String getDefaultAdapterString() {
//        String s = defaultAdapterString;
//        return s.replace("${persistenceName}", getPersistenceName());
//    }
//
//    @Override
//    public void setDefaultConnectionString(String defaultAdapterString) {
//        this.defaultAdapterString = defaultAdapterString;
//    }
//
    @Override
    public String getName() {
        return name;
    }

    @Override
    public String getAbsoluteName() {
        PersistenceGroup g = getPersistenceGroup();
        return StringUtils.trim(g == null ? "" : g.getName()) + "." + StringUtils.trim(name);
    }

    //    public boolean isSynchroneMode() {
//        return synchMode;
//    }
//
//    public void setSynchroneMode(boolean synchMode) {
//        this.synchMode = synchMode;
//    }
    @Override
    public boolean isLastStartSucceeded() {
        return lastStartSucceeded;
    }

    @Override
    public void setLastStartSucceeded(boolean success) {
        this.lastStartSucceeded = success;
    }

    protected void commitModelChanges() {
        persistenceUnitListenerManager.fireOnModelChanged(new PersistenceUnitEvent(this, persistenceGroup, EventPhase.BEFORE));
        for (Entity entity : getEntities()) {
            entity.commitModelChanges();
            List<EntityExtension> extensionList = entity.getExtensions();
            for (EntityExtension entityExtension : extensionList) {
                entityExtension.commitModelChanges();
            }
        }
        for (Index index : getIndexes()) {
            index.commitModelChanges();
        }
//        cache_relationsByName.clear();
        for (Relationship r : getRelationships()) {
            r.commitModelChanged();
//            cache_relationsByName.put(r.getName(), r);
        }
        for (Entity entity : getEntities()) {
            for (Field field : entity.getFields()) {
                if (field.getDataType() instanceof SerializableOrManyToOneType) {
                    Class entityType = ((SerializableOrManyToOneType) field.getDataType()).getEntityType();
//                    if(findEntity(entityType)!=null){
                    throw new UnexpectedException("Field " + field.toString() + " could not be resolved to an Entity type : " + entityType + " is not actually an entity... is it?");
//                    }
                }
            }
        }
        for (Entity entity : getEntities()) {
            ((EntityExt) entity).commitExpressionModelChanges();
        }

        List<OnHoldCommitAction> model = commitModelActions;
        if (model.size() > 0) {

            Collections.sort(model);
            for (OnHoldCommitAction next : model) {
                next.commitModel();
                commitStorageActions.add(next);
            }
            model.clear();

            persistenceUnitListenerManager.fireOnModelChanged(new PersistenceUnitEvent(this, persistenceGroup, EventPhase.AFTER));
        }
    }

    //    protected void prepareDatabase(DatabaseAdapter persistenceStore) {
//        if (this.persistenceStore != null){
//            throw new RuntimeException("Adapter is already set");
//        }
//        if (database != null){
//            throw new RuntimeException("Another database is already registred !");
//        }
//        if (persistenceStore == null) {
//            throw new RuntimeException("Cannot declare NULL persistenceStore !");
//        } else {
//            this.persistenceStore = persistenceStore;
//            this.persistenceStore.setDatabase(this);
//            return;
//        }
//    }
//    public Object dynamicDefaultValue(String tableKey) {
//        return null;
//    }
    @Override
    public boolean isRecurseRemove() {
        return true;
    }

    @Override
    public boolean isLockablePersistenceUnit() {
        return false;
    }

    public PersistenceStore getPersistenceStore() {
        return persistenceStore;
    }

    /**
     * @param triggerName
     * @param interceptor
     * @return created Trigger or null if creation is postponed
     * @
     */
    @Override
    public void addTrigger(String triggerName, EntityInterceptor interceptor, String entityNamePattern, boolean system) {
        EntityConfiguratorProcessor.configureTracker(this, new SimpleEntityFilter(
                StringUtils.isNullOrEmpty(entityNamePattern) ? null : new EqualsStringFilter(entityNamePattern, true, false),
                system
        ), new EntityInterceptorEntityConfigurator(interceptor, triggerName));
    }

    @Override
    public void dropTrigger(String entityName, String triggerName) {
        Entity e = findEntity(entityName);
        if (e != null) {
            e.removeTrigger(triggerName);
        } else {
            //should remove definition listener if found?
            for (TriggerDefinitionListener li : new ArrayList<TriggerDefinitionListener>(persistenceUnitListenerManager.entityTriggers.getAllListeners(true, entityName))) {
                persistenceUnitListenerManager.entityTriggers.remove(entityName, li);
            }
        }
    }

    @Override
    public List<Trigger> getTriggers(String entityName) {
        return getEntity(entityName).getTriggers();
    }

    //    public Map<String, Trigger> getAllTriggers() {
//        return allTriggers;
//    }
    //    protected void checkEntityNames(String name, String shortName) {
//        if (name == null) {
//            throw new NullPointerException("Name could not be null");
//        }
//        if (!name.equals(name.trim())) {
//            throw new NullPointerException("Name contains illegal white characters");
//        }
//        if (shortName == null) {
//            shortName = name;
//        }
//        if (!shortName.equals(shortName.trim())) {
//            throw new NullPointerException("Name contains illegal white characters");
//        }
//        String n = namingStrategy.getUniformValue(name);
//        String sn = namingStrategy.getUniformValue(shortName);
//        if (registrationModel.containsKey(n)) {
//            throw new RuntimeException("Already declared Entity " + n);
//        }
//    }
    @Override
    public void scan(ScanSource source, ScanListener listener, boolean configure) {
        log.log(Level.FINE, "[{0}] : Configuring PersistenceUnit from {1}", new Object[]{getAbsoluteName(), source});
        URLAnnotationStrategySupport s = new URLAnnotationStrategySupport();
        s.scan(source, configure ? new ConfigureScanListener(listener) : listener, this, decorationRepository);
    }

    @Override
    public Entity addEntity(Object source) {
        if (log.isLoggable(Level.FINE)) {
            String sourceLog = null;
            if (source == null) {
                sourceLog = "null";
            } else if (source instanceof Class[]) {
                sourceLog = PlatformUtils.arrayToString((Class[]) source);
            } else {
                sourceLog = source.toString();
            }
            log.log(Level.FINE, "[{0}] : Define Entity {1}", new Object[]{getAbsoluteName(), sourceLog});
        }
        EntityDescriptor desc = entityDescriptorResolver.resolve(source);

        Entity t = getFactory().createObject(Entity.class);
        List<EntityExtensionDefinition> entitySpecs = desc.getEntityExtensions();
        //look for incompatible specs
        if (entitySpecs != null) {
            for (EntityExtensionDefinition extension : entitySpecs) {
            }
        }
        t.setName(desc.getName());
        t.setPreferredPosition(desc.getPosition());
        t.setShortName(desc.getShortName());
        if (desc.getProperties() != null) {
            for (Map.Entry<String, Object> e : desc.getProperties().entrySet()) {
                t.getProperties().setObject(e.getKey(), e.getValue());
            }
        }
//        t.setPersistenceState(PersistenceState.DIRTY);
//        t.setEntityType((Class<R>) desc.getEntityType());

        DefaultBeanAdapter adapter = UPAUtils.prepare(this, t, desc.getName());
        adapter.setProperty("idType", desc.getIdType());
        adapter.setProperty("entityType", desc.getEntityType());
        adapter.setProperty("entityDescriptor", desc);

        FlagSet<EntityModifier> currentModifiers = t.getUserModifiers();
        FlagSet<EntityModifier> tempModifiers = desc.getModifiers();
        if (tempModifiers != null) {
            currentModifiers = currentModifiers.addAll(tempModifiers);
        }
        t.setUserModifiers(currentModifiers);

        currentModifiers = t.getUserExcludeModifiers();
        tempModifiers = desc.getExcludeModifiers();
        if (tempModifiers != null) {
            currentModifiers = currentModifiers.addAll(tempModifiers);
        }
        t.setUserExcludeModifiers(currentModifiers);

        Package parent = (desc.getPackagePath() == null || desc.getPackagePath().length() == 0) ? null : getPackage(desc.getPackagePath(), MissingStrategy.CREATE);
        int pos = desc.getPosition();
//        if (desc.getPosition() != 0) {
//            pos = desc.getPosition();
//        }
        t.setPreferredPosition(pos);
        if (parent != null) {
            parent.addItem(t);
        } else {
            getDefaultPackage().addItem(t);
        }
        t.addPropertyChangeListener("name", EventPhase.BEFORE, new PropertyChangeListener() {
            @Override
            public void propertyChange(PropertyChangeEvent evt) {
                String newName = (String) evt.getNewValue();
                if (containsEntity(newName)) {
                    throw new ObjectAlreadyExistsException("ObjectAlreadyExistsException", getEntity(newName));
                }
            }
        });
        t.addPropertyChangeListener("name", EventPhase.AFTER, new PropertyChangeListener() {
            @Override
            public void propertyChange(PropertyChangeEvent evt) {
                String oldName = (String) evt.getOldValue();
                String newName = (String) evt.getNewValue();
                persistenceUnitListenerManager.itemRenamed((UPAObject) evt.getSource(), oldName, newName, EventPhase.AFTER);
            }
        });

        if (entitySpecs != null) {
            for (EntityExtensionDefinition s : entitySpecs) {
                boolean ok = false;
                for (Class ext : new Class[]{
                    ViewEntityExtensionDefinition.class,
                    SingletonExtensionDefinition.class,
                    FilterEntityExtensionDefinition.class,
                    UnionEntityExtensionDefinition.class
                }) {
                    if (ext.isInstance(s)) {
                        ok = true;
                        t.addExtensionDefinition(ext, s);
                    }
                }
                if (!ok) {
                    throw new UnsupportedUPAFeatureException("UnsupportedEntityExtension", s);
                }
            }
        }

        //        t.revalidateStructure();
        //t.commitModelChanges();
        return t;
    }

    @Override
    public boolean containsEntity(String entityName) {
        return findEntity(entityName) != null;
    }

    @Override
    public boolean containsField(String entityName, String keyName) {
        Entity t = getEntity(entityName, false);
        if (t == null) {
            return false;
        } else {
            return t.containsField(keyName);
        }
    }

    @Override
    public Entity getEntity(String entityName) {
        return getEntity(entityName, true);
    }

    public Entity findEntity(Class entityType) {
        return registrationModel.findEntity(entityType);
    }

    public Entity findEntity(String entityName) {
        return registrationModel.findEntity(entityName);
    }

    public List<Entity> findEntities(Class entityType) {
        return registrationModel.findEntities(entityType);
    }

    public Entity getEntity(String entityName, boolean check) {
        if (entityName == null) {
            if (check) {
                throw new IllegalUPAArgumentException("NullEntityName");
            }
            return null;
        }
        Entity e = registrationModel.findEntity(entityName);
        if (e == null && check) {
            throw new NoSuchEntityException(entityName);
        }
        return e;
    }

    public void addRelationship(RelationshipDescriptor relationDescriptor) {
        RelationshipDescriptorProcessor p = new RelationshipDescriptorProcessor(this, relationDescriptor);
        p.process();
    }

    public Relationship addRelationshipImmediate(RelationshipDescriptor relationDescriptor) {
        String name = relationDescriptor.getName();
        RelationshipType type = relationDescriptor.getRelationshipType();
        String detailEntityName = relationDescriptor.getSourceEntity();
        String masterEntityName = relationDescriptor.getTargetEntity();
        if (detailEntityName == null || masterEntityName == null) {
            throw new NullPointerException("Illegal Null values for Entities " + detailEntityName + " / " + masterEntityName);
        }
        Field manyToOneField = null;
        String detailEntityFieldName = null;//relationDescriptor.getBaseField() ==null == null ? null : manyToOneField.getName();
        RelationshipUpdateType detailUpdateType = RelationshipUpdateType.FLAT;

        if (relationDescriptor.getBaseField() != null) {
            Field baseField = getEntity(detailEntityName).getField(relationDescriptor.getBaseField());
            if (baseField.isManyToOne()) {
                detailEntityFieldName = baseField.getName();
                manyToOneField = baseField;
                detailUpdateType = RelationshipUpdateType.COMPOSED;
            } else if (relationDescriptor.getMappedTo() != null && relationDescriptor.getMappedTo().length > 0) {
                if (relationDescriptor.getMappedTo().length > 1) {
                    throw new IllegalUPAArgumentException("mappedTo cannot only apply to single Entity Field");
                }
                detailEntityFieldName = getEntity(detailEntityName).getField(relationDescriptor.getMappedTo()[0]).getName();
            }
        } else {
            detailUpdateType = RelationshipUpdateType.FLAT;
            manyToOneField = null;
            detailEntityFieldName = relationDescriptor.getSourceFields()[0];
        }

        String masterEntityFieldName = null;
        RelationshipUpdateType masterUpdateType = PlatformUtils.getUndefinedValue(RelationshipUpdateType.class);
        String[] detailFieldNames = relationDescriptor.getSourceFields();
        boolean nullable = true;
        for (String f : detailFieldNames) {
            if (!getEntity(detailEntityName).getField(f).getDataType().isNullable()) {
                nullable = false;
                break;
            }
        }

        if (name == null) {
            if (detailEntityFieldName != null) {
                name = detailEntityName + "_" + detailEntityFieldName;
            } else {
                name = detailEntityName;
                for (String fn : detailFieldNames) {
                    name = name + "_" + fn;
                }
            }
        }
        if (!PlatformUtils.isUndefinedEnumValue(RelationshipUpdateType.class, masterUpdateType)) {
            throw new UnsupportedUPAFeatureException("UnsupportedFeature", "MasterUpdateType");
        }
        if (masterEntityFieldName != null) {
            throw new UnsupportedUPAFeatureException("UnsupportedFeature", "MasterEntityFieldName");
        }

        if (detailEntityFieldName == null) {
            if (PlatformUtils.isUndefinedEnumValue(RelationshipUpdateType.class, detailUpdateType) && detailUpdateType != RelationshipUpdateType.FLAT) {
                throw new IllegalUPAArgumentException("MissingDetailEntityFieldName");
            }
            if (PlatformUtils.isUndefinedEnumValue(RelationshipUpdateType.class, detailUpdateType)) {
                detailUpdateType = RelationshipUpdateType.FLAT;
            }
        } else if (PlatformUtils.isUndefinedEnumValue(RelationshipUpdateType.class, detailUpdateType)) {
            detailUpdateType = RelationshipUpdateType.COMPOSED;
        }

        Relationship r = null;
        if (relationDescriptor.isOneToOne()) {
            r = new DefaultOneToOneRelationship();
        } else if (relationDescriptor.isHierarchy()) {
            r = new DefaultManyToOneRelationship();
        } else if (relationDescriptor.isManyToOne()) {
            r = new DefaultManyToOneRelationship();
        } else {
            throw new IllegalUPAArgumentException("Invalid Relationship descriptor. Expected ManyToOne, OneToOne or Hierarchy");
        }
        DefaultBeanAdapter adapter = UPAUtils.preparePreAdd(this, null, r, name);
        Entity detailEntity = getEntity(detailEntityName);
        Entity masterEntity = getEntity(masterEntityName);

        r.getTargetRole().setRelationshipUpdateType(masterUpdateType);
        r.getTargetRole().setEntity(masterEntity);

        r.getSourceRole().setRelationshipUpdateType(detailUpdateType);
        r.getSourceRole().setEntity(detailEntity);

        Field[] detailFields = new Field[detailFieldNames.length];
        for (int i = 0; i < detailFields.length; i++) {
            detailFields[i] = detailEntity.getField(detailFieldNames[i]);
        }
        r.getSourceRole().setFields(detailFields);
        r.setRelationshipType(type == null ? RelationshipType.DEFAULT : type);

        if (r instanceof ManyToOneRelationship) {
            Expression filter = relationDescriptor.getFilter();
            if (filter != null && filter instanceof UserExpression) {
                UserExpression ff = (UserExpression) filter;
                String expression = ff.getExpression();
                if (StringUtils.isNullOrEmpty(expression)) {
                    filter = null;
                } else if (ff.getParameters().isEmpty()) {
                    filter = getExpressionManager().parseExpression(expression);
                }
            }
            ((ManyToOneRelationship) r).setFilter(filter);
        }
        r.setNullable(nullable);
        if (detailEntityFieldName != null) {
            Field detailEntityField = detailEntity.getField(detailEntityFieldName);
            r.getSourceRole().setEntityField(detailEntityField);
            DataType dt = detailEntityField.getDataType();
            if (dt instanceof RelationDataType) {
                RelationDataType edt = (RelationDataType) dt;
                edt.setRelationship(r);
            }
        }
        if (masterEntityFieldName != null) {
            Field masterEntityField = getEntity(masterEntityName).getField(masterEntityFieldName);
            r.getTargetRole().setEntityField(masterEntityField);
            DataType dt = masterEntityField.getDataType();
            if (dt instanceof RelationDataType) {
                RelationDataType edt = (RelationDataType) dt;
                edt.setRelationship(r);
            }
        }
        if (relationDescriptor.isHierarchy()) {
            HierarchicalRelationshipSupport s = new HierarchicalRelationshipSupport(r);
            ((ManyToOneRelationship) r).setHierarchyExtension(s);
            String hierarchyPathField = relationDescriptor.getHierarchyPathField();
            if (StringUtils.isNullOrEmpty(hierarchyPathField)) {
                if (relationDescriptor.getBaseField() == null) {
                    StringBuilder n = new StringBuilder();
                    for (Field detailField : detailFields) {
                        if (n.length() > 0) {
                            n.append("_");
                        }
                        n.append(detailField.getName());
                    }
                    hierarchyPathField = n.toString();
                } else {
                    hierarchyPathField = relationDescriptor.getBaseField() + "IdPath";
                }
            }
            s.setHierarchyPathField(hierarchyPathField);

            String hierarchySeparator = relationDescriptor.getHierarchyPathSeparator();
            if (StringUtils.isNullOrEmpty(hierarchySeparator)) {
                hierarchySeparator = "/";
            }
            s.setHierarchyPathSeparator(hierarchySeparator);
        }

        UPAUtils.preparePostAdd(this, r);
        persistenceUnitListenerManager.itemAdded(r, -1, null, EventPhase.BEFORE);

//        if (relationDescriptor.isHierarchy()) {
//            detailEntity.addExtensionDefinition(
//                    TreeEntityExtensionDefinition.class,
//                    new DefaultTreeEntityExtensionDefinition(
//                            manyToOneField != null ? manyToOneField.getName() : detailFieldNames[0],
//                            name,
//                            relationDescriptor.getHierarchyPathField(),
//                            hierarchySeparator
//                    ));
//        }
        if (relationDescriptor.isHierarchy()) {
            HierarchyExtension s = ((ManyToOneRelationship) r).getHierarchyExtension();

            detailEntity.addField(new DefaultFieldBuilder()
                    .setName(s.getHierarchyPathField())
                    .addModifier(UserFieldModifier.SYSTEM)
                    .setDataType(new StringType("PathFieldName", 0, 2048, true))
                    .setPosition(Integer.MIN_VALUE)
                    .setPath("system")
            );
            detailEntity.addTrigger(detailEntity.getName() + "_" + s.getHierarchyPathField() + "_TRIGGER", new HierarchicalRelationshipDataInterceptor(r));
        }
        persistenceUnitListenerManager.itemAdded(r, -1, null, EventPhase.AFTER);
        return r;
    }
    //    @Override
    //    public int getExplicitEntitiesCount() {
    //        return allEntities.size();
    //    }

    public void addDefinitionListener(DefinitionListener definitionListener, boolean trackSystem) {
        persistenceUnitListenerManager.addDefinitionListener((String) null, definitionListener, trackSystem);
    }

    public void addDefinitionListener(Class entityType, DefinitionListener definitionListener, boolean trackSystem) {
        persistenceUnitListenerManager.addDefinitionListener(entityType, definitionListener, trackSystem);
    }

    public void addDefinitionListener(String entityName, DefinitionListener definitionListener, boolean trackSystem) {
        persistenceUnitListenerManager.addDefinitionListener(entityName, definitionListener, trackSystem);
    }

    public void addDefinitionListener(DefinitionListener definitionListener) {
        addDefinitionListener(definitionListener, false);
    }

    public void addDefinitionListener(String entityName, DefinitionListener definitionListener) {
        addDefinitionListener(entityName, definitionListener, false);
    }

    public void removeDefinitionListener(DefinitionListener definitionListener) {
        persistenceUnitListenerManager.removeDefinitionListener((String) null, definitionListener);
    }

    public void removeDefinitionListener(Class entityType, DefinitionListener definitionListener) {
        persistenceUnitListenerManager.removeDefinitionListener(entityType, definitionListener);
    }

    public void removeDefinitionListener(String entityName, DefinitionListener definitionListener) {
        persistenceUnitListenerManager.removeDefinitionListener(entityName, definitionListener);
    }

    public void postponeCommit(OnHoldCommitAction modelCommit) {
        commitModelActions.add(modelCommit);
        ///should fire event here
    }

    @Override
    public void reset() {
        reset(defaultHints);
    }

    @Override
    public void reset(Map<String, Object> hints) {
        persistenceUnitListenerManager.fireOnReset(new PersistenceUnitEvent(this, getPersistenceGroup(), EventPhase.BEFORE));

        List<Entity> ops = getEntities(new DefaultEntityFilter().setAcceptClear(true));
        clear();
        for (Entity entity : ops) {
            entity.initialize(hints);
        }
        updateAllFormulas(null, hints);

        persistenceUnitListenerManager.fireOnReset(new PersistenceUnitEvent(this, getPersistenceGroup(), EventPhase.AFTER));
    }

    @Override
    public void flush() {
        UConnection c = getConnection(false);
        if (c != null) {
            // flush to that connection ...;
        }
    }

    public void clear() {
        clear((EntityFilter) null, defaultHints);
    }

    @Override
    public void clear(String entity, Map<String, Object> hints) {
        clear(new DefaultEntityFilter().setAcceptName(getEntity(entity).getName()), hints);
    }

    @Override
    public void clear(Class type, Map<String, Object> hints) {
        clear(getEntity(type).getName(), hints);
    }

    @Override
    public void clear(EntityFilter entityFilter, Map<String, Object> hints) {
        if (entityFilter == null) {
            entityFilter = new DefaultEntityFilter().setAcceptClear(true);
        }
        List<Entity> ops = getEntities(entityFilter);
        getPersistenceStore().setNativeConstraintsEnabled(false);
        EntityExecutionContext context = createContext(ContextOperation.CLEAR, hints);

        persistenceUnitListenerManager.fireOnClear(new PersistenceUnitEvent(this, getPersistenceGroup(), EventPhase.BEFORE));

        for (Entity entity : ops) {
            ((EntityExt) entity).clearCore(context);
        }
        getPersistenceStore().setNativeConstraintsEnabled(true);
        persistenceUnitListenerManager.fireOnClear(new PersistenceUnitEvent(this, getPersistenceGroup(), EventPhase.AFTER));
    }

    @Override
    public List<Entity> getEntities() {
        return getEntities(true);
    }

    @Override
    public List<Entity> getEntities(boolean includeAll) {
        if (true) {
            return registrationModel.getEntities();
        }
        return getDefaultPackage().getEntities(false);
    }

    public List<Package> getPackages() {
        return getPackages(true);
    }

    @Override
    public List<Package> getPackages(boolean includeAll) {
        if (includeAll) {
            List<Package> all = new ArrayList<>();
            all.add(getDefaultPackage());
            all.addAll(getDefaultPackage().getPackages(includeAll));
            return all;
        } else {
            return getDefaultPackage().getPackages(false);
        }
    }

    @Override
    public List<Entity> getEntities(EntityFilter entityFilter) {
        List<Entity> all = getEntities();
        if (entityFilter == null) {
            return all;
        } else {
            int max = all.size();
            ArrayList<Entity> v = new ArrayList<Entity>(max);
            for (Entity tab : all) {
                if (entityFilter.accept(tab)) {
                    v.add(tab);
                }
            }
            return v;
        }
    }

    @Override
    public List<Relationship> getRelationships() {
        return registrationModel.getRelationships();
    }

    @Override
    public Relationship getRelationship(String name) {
        return registrationModel.getRelationship(name);
    }

    @Override
    public boolean containsRelationship(String relationName) {
        try {
            return registrationModel.getRelationship(name) != null;
        } catch (NoSuchRelationshipException e) {
            return false;
        }
    }

    @Override
    public List<Relationship> getRelationshipsByTarget(Entity entity) {
        List<Relationship> v = new ArrayList<Relationship>();
        for (Relationship r : getRelationships()) {
            if (r.getTargetRole().getEntity().equals(entity)) {
                v.add(r);
            }
        }

        return v;
    }

    @Override
    public List<Relationship> getRelationshipsBySource(Entity entity) {
        List<Relationship> v = new ArrayList<Relationship>();
        for (Relationship r : getRelationships()) {
            if (r.getSourceRole().getEntity().equals(entity)) {
                v.add(r);
            }
        }
        return v;
    }

    //    @Override
//    public int executeScript(QueryScript script, boolean exitOnError)
//             {
//        return getPersistenceStore().executeScript(script, exitOnError);
//    }
//    @Override
//    public void executeScript(File file, char separator, PropertyChangeListener listener)
//            , IOException {
//        getPersistenceStore().executeNativeQuery(file, separator, listener);
//    }
    @Override
    public void updateAllFormulas() {
        updateAllFormulas(new DefaultEntityFilter().setAcceptValidatable(true), defaultHints);
    }

    @Override
    public void updateAllFormulas(EntityFilter entityFilter, Map<String, Object> hints) {
        if (entityFilter == null) {
            entityFilter = new DefaultEntityFilter().setAcceptValidatable(true);
        }
        persistenceUnitListenerManager.fireOnUpdateFormulas(new PersistenceUnitEvent(this, persistenceGroup, EventPhase.BEFORE));
//        Log.method();
//        if (monitor != null) {
//            monitor.setMax(entities.length);
//            TaskMonitor child = monitor.getChild();
//            for (int i = 0; i < entities.length; i++) {
//                if (monitor.isStopped()) {
//                    return;
//                }
//                Entity tab = entities[i];
//                monitor.progress(tab.getName(), tab.getTitle(), i, null);
//                tab.updateFormulas(child);
//            }
//        } else {
        for (Entity tab : getEntities(entityFilter)) {
            tab.createUpdateQuery().updateAllFormulas().setHints(hints).execute();
        }
//        }
        persistenceUnitListenerManager.fireOnUpdateFormulas(new PersistenceUnitEvent(this, persistenceGroup, EventPhase.AFTER));
    }

    //    public int updateDocuments(String entityName, Document document, Expression condition)  {
//        return getEntity(entityName).updateDocuments(document, condition);
//    }
//    public void updateFormulas(String entityName, FieldFilter filter, Expression expr)  {
//        getEntity(entityName).updateFormulas(filter, expr);
//    }
//
//    public void updateFormulasById(String entityName, FieldFilter filter, Object key)  {
//        getEntity(entityName).updateFormulasById(filter, key);
//    }
//    public int updateDocuments(Class entityType, Document document, Expression condition)  {
//        return getEntity(entityType).updateDocuments(document, condition);
//    }
//    public void updateFormulas(Class entityType, FieldFilter filter, Expression expr)  {
//        getEntity(entityType).updateFormulas(filter, expr);
//    }
//
//    public void updateFormulasById(Class entityType, FieldFilter filter, Object id)  {
//        getEntity(entityType).updateFormulasById(filter, id);
//    }
    //    @Override
//    public List<Field> findField(String name)  {
//        ArrayList<Field> v = new ArrayList<Field>();
//        for (Entity entity : getEntities()) {
//            Field f = entity.getField(name, false);
//            if (f != null) {
//                v.add(f);
//            }
//        }
//        return v;
//    }
    @Override
    public void installDemoData() {
        // do nothing;
    }

    protected Session openSystemSession() {
        Session currentSession = null;
        if (getPersistenceGroup().currentSessionExists()) {
            try {
                currentSession = getCurrentSession();
            } catch (CurrentSessionNotFoundException ignore) {
                //
            }
        }
        if (currentSession != null) {
            final Session session = currentSession;
            currentSession = new StackedSession(session);
        } else {
            currentSession = getPersistenceGroup().openSession();
        }
        currentSession.setParam(this, SessionParams.SYSTEM, privateUUID.toString());
        return currentSession;
    }

    public boolean isSystemSession(Session s) {
        return privateUUID.toString().equals(s.getParam(this, String.class, SessionParams.SYSTEM, null));
    }

    @Override
    public void start() {
        if (started || starting) {
            throw new PersistenceUnitException(new I18NString("PersistenceUnitAlreadyStartedException"), getAbsoluteName());
        }
        starting = true;
        log.log(Level.FINE, "[{0}] : Start Persistence Unit", new Object[]{getAbsoluteName()});
        setLastStartSucceeded(false);
        Session session = null;
        session = openSystemSession();

        persistenceStoreFactory = getPersistenceGroup().getFactory().createObject(PersistenceStoreFactory.class);
        persistenceStoreFactory.configure(getPersistenceGroup().getFactory());
        PersistenceStoreExt validPersistenceStore = null;
        List<ConnectionProfile> validConnectionProfiles = getConnectionProfiles(false, true);
        List<Object[]> errors = new ArrayList<Object[]>();
        for (ConnectionProfile p : validConnectionProfiles) {
            PersistenceStoreExt pm0 = (PersistenceStoreExt) persistenceStoreFactory.createPersistenceStore(p, getPersistenceGroup().getFactory(), getProperties());
            try {
                pm0.checkAccessible(p);
                connectionProfile = p;
                validPersistenceStore = pm0;
                break;
            } catch (Throwable t) {
                log.log(Level.FINE, "Ignore Profile {0}", new Object[]{p});
                errors.add(new Object[]{p, t});
            }
        }

        if (getConnectionProfile() == null || validPersistenceStore == null) {
            Throwable cause = null;
            if (validConnectionProfiles.isEmpty()) {
                List<ConnectionProfile> anyConnectionProfiles = getConnectionProfiles(false, false);
                if (anyConnectionProfiles.isEmpty()) {
                    log.log(Level.SEVERE, "[" + getName() + "] Unable to create Store because no valid ConnectionProfile was found. Actually no ConnectionProfile found at all.");
                } else {
                    StringBuilder sb = new StringBuilder("[" + getName() + "] Unable to create Store because no valid ConnectionProfile was found. " + anyConnectionProfiles.size() + " ConnectionProfile(s) found : ");
                    for (int i = 0; i < anyConnectionProfiles.size(); i++) {
                        if (i > 0) {
                            sb.append(" ; ");
                        }
                        ConnectionProfile anyConnectionProfile = anyConnectionProfiles.get(i);
                        sb.append(anyConnectionProfile);
                    }
                    log.log(Level.SEVERE, sb.toString());
                }
            } else {
                log.log(Level.SEVERE, "Unable to create Store because all ConnectionProfiles failed to be accessible");
                for (Object[] objects : errors) {
                    cause = ((Throwable) objects[1]);
                    log.log(Level.SEVERE, "Profile " + objects[0] + " failed because of " + cause.toString(), cause);
                }
            }
            if (cause == null) {
                throw new UPAException("UnableToCreatePersistenceStore", this);
            } else {
                throw new UPAException(cause, new I18NString("UnableToCreatePersistenceStore"), this);
            }
        }

        this.persistenceStore = validPersistenceStore;
        PlatformBeanType b = PlatformUtils.getBeanType(persistenceNameStrategy.getClass());
        b.inject(persistenceNameStrategy, "persistenceStore", this.persistenceStore);
        b.inject(persistenceNameStrategy, "properties", getProperties());

        this.persistenceStore.init(this, isReadOnly(), connectionProfile);
//        this.persistenceStore.setResources(getResources());
//        for (PersistenceUnitListener schemaDataListener : getPersistenceUnitListeners()) {
//            schemaDataListener.persistenceStoreChanged(this, old, persistenceStore);
//        }

//            Map<String, String> m = new HashMap<String, String>();
//            for (Map.Entry<String, Object> ee : getParameters().toMap().entrySet()) {
//                String k = ee.getKey();
//                String v = ee.getValue() == null ? "" : ee.getValue().toString();
//                m.put(k, v);
//            }
        commitModelChanges();

        if (getTransactionManagerFactory() == null) {
            setTransactionManagerFactory(getFactory().createObject(TransactionManagerFactory.class));
        }
        if (getTransactionManager() == null) {
            setTransactionManager(getTransactionManagerFactory().createTransactionManager(getConnectionProfile(), getPersistenceGroup().getFactory(), getProperties()));
        }

        boolean transactionCreated = beginTransaction(TransactionType.REQUIRED);
        try {
            persistenceUnitListenerManager.fireOnStart(new PersistenceUnitEvent(this, persistenceGroup, EventPhase.BEFORE));
            commitStructureModification();

            persistenceUnitListenerManager.fireOnStart(new PersistenceUnitEvent(this, persistenceGroup, EventPhase.AFTER));
            if (transactionCreated) {
                commitTransaction();
            }
            setLastStartSucceeded(true);
        } catch (Exception ex) {
            setLastStartSucceeded(false);
            rollbackTransaction();
            throw ex;
        } finally {
            if (session != null) {
                session.close();
            }
        }
        started = true;
        starting = false;

    }

    private List<ConnectionProfile> getConnectionProfiles(boolean root, boolean enabledOnly) {
        ConnectionProfileParser connectionProfileParser = new ConnectionProfileParser();
        Properties p2 = new DefaultProperties(getProperties());
        return connectionProfileParser.parse(p2, getConnectionConfigs(), (root ? UPA.ROOT_CONNECTION_STRING : UPA.CONNECTION_STRING), enabledOnly);
    }

    @Override
    public String getPersistenceName() {
        return persistenceName;
    }

    @Override
    public void setPersistenceName(String persistenceName) {
        this.persistenceName = persistenceName;
    }

    public void dropStorage(EntityExecutionContext context) {
    }

    @Override
    public boolean isValidPersistenceUnit() {
        //TODO
        for (Entity t : getEntities()) {
            try {
//                ConnectionProfile p = getPersistenceStore().getConnectionProfile();
//                StructureStrategy oldOption = p.getStructureStrategy();
//                p.setStructureStrategy(StructureStrategy.MANDATORY);
//                try {
//                    openDefaultConnection();
//                } finally {
//                    p.setStructureStrategy(oldOption);
//                }
                return t.getEntityCount() >= 0;
            } catch (UPAException e) {
                return false;
            }
        }
        return true;
    }

    /**
     * use PersistenceUnitListener
     *
     * @param propertyName
     * @param listener
     * @deprecated
     */
    @Override
    @Deprecated
    public void addPropertyChangeListener(String propertyName, PropertyChangeListener listener) {
        propertyChangeSupport.addPropertyChangeListener(propertyName, listener);
    }

    @Override
    @Deprecated
    public void addPropertyChangeListener(PropertyChangeListener listener) {
        propertyChangeSupport.addPropertyChangeListener(listener);
    }

    @Override
    @Deprecated
    public void removePropertyChangeListener(String propertyName, PropertyChangeListener listener) {
        propertyChangeSupport.removePropertyChangeListener(propertyName, listener);
    }

    @Override
    @Deprecated
    public void removePropertyChangeListener(PropertyChangeListener listener) {
        propertyChangeSupport.removePropertyChangeListener(listener);
    }

    @Override
    public PropertyChangeListener[] getPropertyChangeListeners() {
        return propertyChangeSupport.getPropertyChangeListeners();
    }

    @Override
    public PropertyChangeListener[] getPropertyChangeListeners(String propertyName) {
        return propertyChangeSupport.getPropertyChangeListeners(propertyName);
    }

    //    @Override
//    public LocalizedDatabase getLocalizedDatabase() {
//        return localizedDatabase;
//    }
    @Override
    public int getStatus() {
        return status;
    }

    @Override
    public void setStatus(int status) {
        this.status = status;
    }

    public ExpressionManager getExpressionManager() {
        return expressionManager;
    }

    //    public class LocalizedDatabase {
//
//        public PersistenceUnitFilter getPersistenceUnit() {
//            return DefaultPersistenceUnit.this;
//        }
//
//        public Entity getEntity(String entityName, boolean check) {
//            for (Entity t : entities.values()) {
//                if (t.getName().equalsIgnoreCase(entityName) || t.getTitle().equalsIgnoreCase(entityName)) {
//                    return t;
//                }
//            }
//            if (check) {
//                throw new RuntimeException("Entity " + entityName + " unknown....");
//            } else {
//                return null;
//            }
//        }
//
//        public Relationship getRelationForDetails(Entity detailsEntity, String relationName, boolean check) {
//            Field tp = detailsEntity.getLocalizedEntity().getExtendedField(relationName, false);
//            if (tp instanceof PrimitiveField) {
//                PrimitiveField f = (PrimitiveField) tp;
//                if (f != null && f.getRelations() != null) {
//                    return f.getRelations();
//                }
//            }
//            for (Iterator i = relations.entrySet().iterator(); i.hasNext(); ) {
//                Map.Entry e = (Map.Entry) i.next();
//                Relationship r = (Relationship) e.getValue();
//                if ((detailsEntity == null || r.getSourceEntity().equals(detailsEntity))
//                        && (r.getName().equalsIgnoreCase(relationName)
//                        || r.getTargetRole().getTitle().equalsIgnoreCase(relationName))) {
//                    return r;
//                }
//            }
//
//            if (check) {
//                throw new RuntimeException("RelationForDetails " + relationName + " not found for Entity " + detailsEntity + " ....");
//            } else {
//                return null;
//            }
//        }
//
//        public Relationship getRelationForMaster(Entity masterEntity, String relationName, boolean check) {
//            for (Map.Entry<String, Relationship> stringRelationEntry : relations.entrySet()) {
//                Map.Entry e = (Map.Entry) stringRelationEntry;
//                Relationship r = (Relationship) e.getValue();
//                if ((masterEntity == null || r.getTargetRole().getEntity().equals(masterEntity))
//                        && (r.getName().equalsIgnoreCase(relationName)
//                        || r.getSourceRole().getTitle().equalsIgnoreCase(relationName))) {
//                    return r;
//                }
//            }
//
//            if (check) {
//                throw new RuntimeException("RelationForMaster " + relationName + " not found for Entity " + masterEntity + " ....");
//            } else {
//                return null;
//            }
//        }
//    }
//
    //--------------------------- PROPERTIES SUPPORT
    @Override
    public net.vpc.upa.Properties getProperties() {
        return properties;
    }

    @Override
    public boolean isTriggersEnabled() {
        return triggersEnabled;
    }

    @Override
    public void setTriggersEnabled(boolean triggersEnabled) {
        this.triggersEnabled = triggersEnabled;
    }

    @Override
    public boolean isAskOnCheckCreatedPersistenceUnit() {
        return askOnCheckCreatedPersistenceUnit;
    }

    @Override
    public void setAskOnCheckCreatedPersistenceUnit(boolean askOnCheckCreatedPersistenceUnit) {
        this.askOnCheckCreatedPersistenceUnit = askOnCheckCreatedPersistenceUnit;
    }

    //    @Override
//    public void setApplication(Application application) {
//        this.application = application;
//        MacroManager macroManager = application.getMacroManager();
//        macroManager.registerMacro(new DBMacro(this));
//        dbMacroHelper = new DBMacroHelper(macroManager);
//        getResources().loadBundle("net.vpc.database.resources.PersistenceUnitFilter");
//    }
    @Override
    public void addPersistenceUnitListener(PersistenceUnitListener listener) {
        persistenceUnitListenerManager.persistenceUnitListeners.add(listener);
    }

    @Override
    public void removePersistenceUnitListener(PersistenceUnitListener listener) {
        persistenceUnitListenerManager.persistenceUnitListeners.remove(listener);
    }

    @Override
    public List<PersistenceUnitListener> getPersistenceUnitListeners() {
        return new ArrayList<PersistenceUnitListener>(persistenceUnitListenerManager.persistenceUnitListeners);
    }

    @Override
    public PersistenceStoreFactory getPersistenceStoreFactory() {
        return persistenceStoreFactory;
    }

    @Override
    public void addSQLParameterProcessor(QLParameterProcessor p) {
        parameterProcessors.add(p);
    }

    @Override
    public void removeSQLParameterProcessor(QLParameterProcessor p) {
        parameterProcessors.remove(p);
    }

    //    @Override
    public Map<String, Expression> processQLParameters(List<QLParameter> parameters, String message) {
        Map<String, Expression> output = new HashMap<String, Expression>();
        for (QLParameterProcessor parameterProcessor : parameterProcessors) {
            parameterProcessor.processSQLParameters(parameters, output, message);
        }
        return output;
    }

    @Override
    public I18NStringStrategy getI18NStringStrategy() {
        if (i18NStringStrategy == null) {
            i18NStringStrategy = getFactory().createObject(I18NStringStrategy.class);
        }
        return i18NStringStrategy;
    }

    public Entity getLockInfoEntity() {
        Entity entity = getEntity(LockInfoDesc.LOCK_INFO_ENTITY_NAME);
        return entity;
    }

    public void addLockingSupport(Entity entity) {
        entity.addField(
                new DefaultFieldDescriptor()
                        .setName("lockId")
                        .setPath("Lock")
                        .setModifiers(FlagSets.of(UserFieldModifier.SYSTEM))
                        .setExcludeModifiers(FlagSets.of(UserFieldModifier.UPDATE))
                        .setDataType(new StringType("lockId", 0, 64, true))
                        .setProtectionLevel(ProtectionLevel.PRIVATE));

        entity.addField(
                new DefaultFieldDescriptor()
                        .setName("lockTime")
                        .setPath("Lock")
                        .setModifiers(FlagSets.of(UserFieldModifier.SYSTEM))
                        .setExcludeModifiers(FlagSets.of(UserFieldModifier.UPDATE))
                        .setDataType(new DateType("lockTime", Timestamp.class, true))
                        .setProtectionLevel(ProtectionLevel.PRIVATE)
        );
    }

    public void lockEntities(Entity entity, Expression expression, String id) {
        if (entity.getEntityCount(new And(expression, new Different(new Var("lockId"), null))) > 0) {
            throw new AlreadyLockedPersistenceUnitException("Some Documents already locked");
        }
        List<Object> keys = entity.createQueryBuilder().byExpression(expression).getIdList();
        for (Object key : keys) {
            Document r = entity.getBuilder().createDocument();
            r.setObject("lockId", id);
            long i = entity.createUpdateQuery().setValues(r)
                    .byExpression(new And(entity.getBuilder().idToExpression(key, null), new Equals(new Var("lockId"), UPQLUtils.THIS)))
                    .execute();
            if (i != 1) {
                throw new AlreadyLockedPersistenceUnitException("Already Locked Document");
            }
        }
    }

    public void unlockEntities(Entity entity, Expression expression, String lockId) {
        if (entity.getEntityCount(new And(expression, new Or(new Equals(new Var("lockId"), null), new Different(new Var("lockId"), lockId)))) > 0) {
            throw new AlreadyLockedPersistenceUnitException("Some Documents are not locked or are locked by another user");
        }
        List<Object> keys = entity.createQueryBuilder().byExpression(expression).getIdList();
        for (Object key : keys) {
            Document r = entity.getBuilder().createDocument();
            r.setObject("lockId", null);
            r.setObject("lockTime", null);
            long i = entity.createUpdateQuery().setValues(r)
                    .byExpression(new And(entity.getBuilder().idToExpression(key, null), new Equals(new Var("lockId"), lockId)))
                    .execute();
            if (i != 1) {
                throw new AlreadyLockedPersistenceUnitException("Document no Locked or is locked by another person");
            }
        }
    }

    public List<LockInfo> getLockingInfo(Entity entity, Expression expression) {
        ArrayList<LockInfo> vector = new ArrayList<LockInfo>();
        FieldFilter filter = FieldFilters.id().or(FieldFilters.byName("lockId", "lockTime"));
        List<Document> list = entity.createQueryBuilder().byExpression(
                new And(new Different(new Var("lockId"), null), expression)).setFieldFilter(filter).getDocumentList();
        for (Document document : list) {
            String id = document.getString("lockId");
            Date date = document.getDate("lockTime");
            document.remove("lockId");
            document.remove("lockTime");
            vector.add(new LockInfo(document, date, id));
        }
        return vector;
    }

    public void lockPersistenceUnit(String id) {
        _lockEntity("*", id);
    }

    public void unlockPersistenceUnit(String id) {
        _unlock("*", id);
    }

    public LockInfo getPersistenceUnitLockingInfo() {
        LockInfo info = _getLockInfo("*");
        if (info == null) {
            return null;
        }
        return new LockInfo(this, info.getDate(), info.getUser());
    }

    public void lockEntity(Entity entity, String id) {
        _lockEntity(entity.getName(), id);
    }

    public void unlockEntity(Entity entity, String id) {
        _unlock(entity.getName(), id);
    }

    public LockInfo getLockingInfo(Entity entity) {
        LockInfo info = _getLockInfo(entity.getName());
        if (info == null) {
            return null;
        }
        return new LockInfo(entity, info.getDate(), info.getUser());
    }

    public boolean isLockedDatabase(String id) {
        return _isLocked("*", id);
    }

    public boolean isLockedDatabase() {
        return _isLocked("*");
    }

    public boolean isLockedEntity(Entity entity, String id) {
        return _isLocked(entity.getName(), id);
    }

    public boolean isLockedEntity(Entity entity) {
        return _isLocked(entity.getName());
    }

    private void ensureLockDef(String entityName) {
        Entity lockInfoEntity = getLockInfoEntity();
        if (lockInfoEntity.getEntityCount(lockInfoEntity.getBuilder().idToExpression(lockInfoEntity.createId(entityName), UPQLUtils.THIS)) == 0) {
            Document r = lockInfoEntity.getBuilder().createDocument();
            r.setString("lockedEntity", entityName);
            lockInfoEntity.persist(r);
        }
    }

    private void _lockEntity(String entityName, String lockId) {
        Entity lockInfoEntity = getLockInfoEntity();
        Document r = lockInfoEntity.getBuilder().createDocument();
        r.setObject("lockId", lockId);
        r.setObject("lockTime", new Date());
        long ret = 0;
        try {
            ensureLockDef(entityName);
            And notLocked = new And(
                    new Equals(new Var("lockedEntity"), new Literal(entityName)),
                    new Equals(new Var("lockId"), null));
            //getEntity(entityName)
            ret = lockInfoEntity.createUpdateQuery()
                    .setValues(r).byExpression(notLocked)
                    .execute();
        } catch (UPAException e) {
            throw new AlreadyLockedPersistenceUnitException("entity.lockingException", getEntity(entityName).getI18NTitle());
        }
        if (ret == 1) {
            // oll is Ok
        } else {
            Document locked = null;
            try {
                locked = lockInfoEntity.createQueryBuilder()
                        .byExpression(new Equals(new Var("lockedEntity"), new Literal(entityName)))
                        .setFieldFilter(FieldFilters.byName("lockId", "lockTime")).getDocument();
            } catch (UPAException e) {
                throw new AlreadyLockedPersistenceUnitException("entity.lockingException", getEntity(entityName).getI18NTitle());
            }
            throw new AlreadyLockedPersistenceUnitException("entity.alreadyLocked", getEntity(entityName).getI18NTitle(), locked.getString("lockId"), locked.getDate("lockTime"));
        }
    }

    private boolean _isLocked(String entityName) {
        Entity entity = getLockInfoEntity();
        return entity.getEntityCount(
                new And(
                        new Equals(new Var("lockedEntity"), new Literal(entityName)),
                        new Different(new Var("lockId"), null))) > 0;
    }

    private boolean _isLocked(String entityName, String id) {
        Entity entity = getLockInfoEntity();
        return entity.getEntityCount(
                new And(
                        new Equals(new Var("lockedEntity"), new Literal(entityName)),
                        new Equals(new Var("lockId"), id))) > 0;
    }

    private LockInfo _getLockInfo(String entityName) {
        Document rec = getEntity(entityName).createQueryBuilder().byExpression(
                new Equals(new Var("lockedEntity"), new Literal(entityName)))
                .setFieldFilter(FieldFilters.byName("lockId", "lockTime")).getDocument();
        if (rec == null) {
            return null;
        }
        return new LockInfo(entityName, rec.getDate("lockTime"), rec.getString("lockId"));
    }

    private void _unlock(String entityName, String id) {
        Entity entity = getLockInfoEntity();
        Document r = entity.getBuilder().createDocument();
        r.setObject("lockId", null);
        r.setObject("lockTime", null);
        And locked = new And(
                new Equals(new Var("lockedEntity"), new Literal(entityName)),
                new Equals(new Var("lockId"), new Param(id)));
        long ret = entity.createUpdateQuery().setValues(r).byExpression(locked).execute();
        if (ret == 1) {
            // oll is Ok
        } else {
            Document rlocked = entity.createQueryBuilder().byExpression(new Equals(new Var("lockedEntity"), new Literal(entityName)))
                    .setFieldFilter(FieldFilters.byName("lockId", "lockTime")).getDocument();
            if (rlocked == null) {
                rlocked = entity.getBuilder().createDocument();
            }
            throw new AlreadyLockedPersistenceUnitException("entity.neverLocked", getEntity(entityName).getI18NTitle(), rlocked.getString("lockId"), rlocked.getDate("lockTime"));
        }
    }

    @Override
    public I18NString getTitle() {
        return title;
    }

    public void setTitle(I18NString title) {
        this.title = title;
    }

    @Override
    public UPASecurityManager getSecurityManager() {
        return getPersistenceGroup().getSecurityManager();
    }

    @Override
    public Class getEntityExtensionSupportType(Class entityExtensionDefinitionType) {
        if (UnionEntityExtensionDefinition.class.equals(entityExtensionDefinitionType)) {
            return UnionEntityExtension.class;
        }
        if (ViewEntityExtensionDefinition.class.equals(entityExtensionDefinitionType)) {
            return ViewEntityExtension.class;
        }
        if (FilterEntityExtensionDefinition.class.equals(entityExtensionDefinitionType)) {
            return FilterEntityExtension.class;
        }
        if (SingletonExtensionDefinition.class.equals(entityExtensionDefinitionType)) {
            return SingletonExtension.class;
        }
        throw new UnsupportedUPAFeatureException("Unsupported extension definition " + entityExtensionDefinitionType);
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setPersistenceGroup(PersistenceGroup persistenceGroup) {
        this.persistenceGroup = persistenceGroup;
    }

    @Override
    public PersistenceGroup getPersistenceGroup() {
        return persistenceGroup;
    }

    public ConnectionProfile getConnectionProfile() {
        return connectionProfile;
    }

    @Override
    public ObjectFactory getFactory() {
        return getPersistenceGroup().getFactory();
    }

    public TransactionManagerFactory getTransactionManagerFactory() {
        return transactionManagerFactory;
    }

    public void setTransactionManagerFactory(TransactionManagerFactory transactionManagerFactory) {
        this.transactionManagerFactory = transactionManagerFactory;
    }

    public TransactionManager getTransactionManager() {
        return transactionManager;
    }

    public void setTransactionManager(TransactionManager transactionManager) {
        this.transactionManager = transactionManager;
    }

    public Entity getEntityByIdType(Class idType) {
        return registrationModel.getEntityByIdType(idType);
    }

    public boolean containsEntity(Class entityType) {
        return registrationModel.containsEntity(entityType);
    }

    public Entity getEntity(Object entityType) {
        if (entityType instanceof String) {
            return getEntity((String) entityType);
        }
        if (entityType instanceof QualifiedDocument) {
            return ((QualifiedDocument) entityType).getEntity();
        }
        if (entityType instanceof Class) {
            return getEntity((Class) entityType);
        }
        if (entityType instanceof Document) {
            throw new UPAException("UnableToResolveEntityFromDocument");
        }
        return getEntity(entityType.getClass());
    }

    public Entity getEntity(Class entityType) {
        return registrationModel.getEntity(entityType);
    }

    @Override
    public Session openSession() {
        Session s = getPersistenceGroup().openSession();
        s.setParam(this, SessionParams.USER_PRINCIPAL, getSecurityManager().getUserPrincipal());
        return s;
    }

    private boolean checkSession() {
        if (!getPersistenceGroup().currentSessionExists()) {
            if (sessionAwarePU == null) {
                sessionAwarePU = getPersistenceGroup().getContext().makeSessionAware(this);
            }
            return false;
        }
        return true;
    }

    @Override
    public void persist(String entityName, Object objectOrDocument, Map<String, Object> hints) {
        if (!checkSession()) {
            sessionAwarePU.persist(entityName, objectOrDocument, hints);
            return;
        }
        Entity entity = getEntity(entityName);
        entity.persist(objectOrDocument, hints);
    }

    @Override
    public void persist(String entityName, Object objectOrDocument) {
        if (!checkSession()) {
            sessionAwarePU.persist(objectOrDocument);
            return;
        }
        Entity entity = getEntity(entityName);
        entity.persist(objectOrDocument);
    }

    @Override
    public void persist(Object objectOrDocument) {
        if (!checkSession()) {
            sessionAwarePU.persist(objectOrDocument);
            return;
        }
        Entity entity = getEntity(objectOrDocument);
        entity.persist(objectOrDocument);
    }

    /**
     * @param objectOrDocument
     * @
     */
    @Override
    public void merge(Object objectOrDocument) {
        if (!checkSession()) {
            sessionAwarePU.merge(objectOrDocument);
            return;
        }
        Entity entity = getEntity(objectOrDocument);
        entity.merge(objectOrDocument);
    }

    @Override
    public void merge(String entityName, Object objectOrDocument) {
        if (!checkSession()) {
            sessionAwarePU.merge(entityName, objectOrDocument);
            return;
        }
        Entity entity = getEntity(entityName);
        entity.merge(objectOrDocument);
    }

    @Override
    public void merge(Class entityType, Object objectOrDocument) {
        if (!checkSession()) {
            sessionAwarePU.merge(entityType, objectOrDocument);
            return;
        }
        Entity entity = getEntity(entityType);
        entity.merge(objectOrDocument);
    }

    @Override
    public UpdateQuery createUpdateQuery(String entityName) {
        Entity entity = getEntity(entityName);
        return entity.createUpdateQuery();
    }

    @Override
    public UpdateQuery createUpdateQuery(Class entityType) {
        Entity entity = getEntity(entityType);
        return entity.createUpdateQuery();
    }

    @Override
    public UpdateQuery createUpdateQuery(Object object) {
        Entity entity = getEntity(object);
        return entity.createUpdateQuery().setValues(object);
    }

    //    @Override
//    public void merge(String entityName, Object objectOrDocument)  {
//        if (!checkSession()) {
//            sessionAwarePU.merge(objectOrDocument);
//            return;
//        }
//        Entity entity = getEntity(entityName);
//        entity.merge(objectOrDocument);
//    }
    @Override
    public RemoveTrace remove(Object objectOrDocument) {
        if (!checkSession()) {
            return sessionAwarePU.remove(objectOrDocument);
        }
        Entity entity = getEntity(objectOrDocument);
        return entity.remove(objectOrDocument);
    }

    @Override
    public boolean save(Object objectOrDocument) {
        if (!checkSession()) {
            return sessionAwarePU.save(objectOrDocument);
        }
        Entity entity = getEntity(objectOrDocument);
        return entity.save(objectOrDocument);
    }

    @Override
    public boolean save(Class entityType, Object objectOrDocument) {
        if (!checkSession()) {
            return sessionAwarePU.save(entityType, objectOrDocument);
        }
        return getEntity(entityType).save(objectOrDocument);
    }

    @Override
    public boolean save(String entityName, Object objectOrDocument) {
        if (!checkSession()) {
            return sessionAwarePU.save(entityName, objectOrDocument);
        }
        return getEntity(entityName).save(objectOrDocument);
    }

    @Override
    public void update(Object objectOrDocument) {
        if (!checkSession()) {
            sessionAwarePU.update(objectOrDocument);
            return;
        }
        getEntity(objectOrDocument).update(objectOrDocument);
    }

    @Override
    public void update(Class entityType, Object objectOrDocument) {
        getEntity(entityType).update(objectOrDocument);
    }

    @Override
    public void update(String entityName, Object objectOrDocument) {
        getEntity(entityName).update(objectOrDocument);
    }

    //    @Override
//    public void updatePartial(String entityName, Object objectOrDocument, String... fields)  {
//        updatePartial(entityName, objectOrDocument,defaultHints, fields);
//    }
//    @Override
//    public void updatePartial(String entityName, Object objectOrDocument,Map<String,Object> hints, String... fields)  {
//        //
//        if (!checkSession()) {
//            sessionAwarePU.updatePartial(entityName,objectOrDocument,hints,fields);
//            return;
//        }
//        getEntity(entityName).updatePartial(objectOrDocument,hints,fields);
//    }
//
//    @Override
//    public void updatePartial(String entityName, Object objectOrDocument, Set<String> fields,boolean ignoreUnspecified)  {
//        updatePartial(entityName, objectOrDocument, fields,ignoreUnspecified,defaultHints);
//    }
//
//    @Override
//    public void updatePartial(String entityName, Object objectOrDocument, Set<String> fields,boolean ignoreUnspecified,Map<String,Object> hints)  {
//        //
//        if (!checkSession()) {
//            sessionAwarePU.updatePartial(entityName, objectOrDocument, fields, ignoreUnspecified,hints);
//            return;
//        }
//        getEntity(entityName).updatePartial(objectOrDocument, fields, ignoreUnspecified,hints);
//    }
//    @Override
//    public void updatePartial(Object objectOrDocument, String... fields)  {
//        //
//        if (!checkSession()) {
//            sessionAwarePU.updatePartial(objectOrDocument);
//            return;
//        }
//        getEntity(objectOrDocument).updatePartial(objectOrDocument, fields);
//    }
//
//    @Override
//    public void updatePartial(Object objectOrDocument, Set<String> fields,boolean ignoreUnspecified)  {
//        //
//        if (!checkSession()) {
//            sessionAwarePU.updatePartial(objectOrDocument,fields,ignoreUnspecified);
//            return;
//        }
//        getEntity(objectOrDocument).updatePartial(objectOrDocument,fields,ignoreUnspecified);
//    }
//    @Override
//    public void updatePartial(Object objectOrDocument)  {
//        if (!checkSession()) {
//            sessionAwarePU.updatePartial(objectOrDocument);
//            return;
//        }
//        getEntity(objectOrDocument).updatePartial(objectOrDocument);
//    }
//
//    @Override
//    public void updatePartial(String entityName, Object objectOrDocument)  {
//        if (!checkSession()) {
//            sessionAwarePU.updatePartial(entityName, objectOrDocument);
//            return;
//        }
//        getEntity(entityName).updatePartial(objectOrDocument);
//    }
    @Override
    public RemoveTrace remove(Class entityType, Object object) {
        if (!checkSession()) {
            return sessionAwarePU.remove(entityType, object);
        }
        return getEntity(entityType).remove(object);
    }

    @Override
    public RemoveTrace remove(String entityName, Object object) {
        if (!checkSession()) {
            return sessionAwarePU.remove(entityName, object);
        }
        return getEntity(entityName).remove(object);
    }

    @Override
    public RemoveTrace remove(Class entityType, RemoveOptions object) {
        if (!checkSession()) {
            return sessionAwarePU.remove(entityType, object);
        }
        return getEntity(entityType).remove(object);
    }

    @Override
    public RemoveTrace remove(String entityName, RemoveOptions object) {
        if (!checkSession()) {
            return sessionAwarePU.remove(entityName, object);
        }
        return getEntity(entityName).remove(object);
    }

    @Override
    public Query createQuery(String query) {
        return createQuery((EntityStatement) getExpressionManager().parseExpression(query));
    }

    @Override
    public Query createQuery(EntityStatement query) {
        String entityName = query.getEntityName();
        if (entityName != null) {
            return getEntity(entityName).createQuery(query);
        }
        return getPersistenceStore().createQuery(query, createContext(ContextOperation.FIND, defaultHints));
    }

    @Override
    public QueryBuilder createQueryBuilder(Class entityType) {
        Entity entity = getEntity(entityType);
        return entity.createQueryBuilder();
    }

    @Override
    public QueryBuilder createQueryBuilder(String entityName) {
        Entity entity = getEntity(entityName);
        return entity.createQueryBuilder();
    }

    public <T> T findByMainField(Class entityType, Object mainFieldValue) {
        return findByMainField(getEntity(entityType).getName(), mainFieldValue);
    }

    public <T> T findByMainField(String entityName, Object mainFieldValue) {
        Entity e = getEntity(entityName);
        Field mainField = e.getMainField();
        mainField.check(mainFieldValue);
        return createQueryBuilder(entityName).byExpression(new Equals(new Var(new Var(e.getName()), mainField.getName()), new Param("main", mainFieldValue)))
                .getSingleResultOrNull();
    }

    public <T> T findByField(Class entityType, String fieldName, Object mainFieldValue) {
        Entity e = getEntity(entityType);
        return createQueryBuilder(entityType)
                .byExpression(new Equals(new Var(new Var(e.getName()), fieldName), new Param("main", mainFieldValue)))
                .getSingleResultOrNull();
    }

    public <T> T findByField(String entityName, String fieldName, Object mainFieldValue) {
        Entity e = getEntity(entityName);
        return createQueryBuilder(entityName)
                .byExpression(new Equals(new Var(new Var(e.getName()), fieldName), new Param("main", mainFieldValue)))
                .getSingleResultOrNull();
    }

    public <T> List<T> findAll(Class entityType) {
        return createQueryBuilder(entityType)
                .orderBy(getEntity(entityType).getListOrder())
                .getResultList();
    }

    public <T> List<T> findAll(String entityName) {
        return createQueryBuilder(entityName)
                .orderBy(getEntity(entityName).getListOrder())
                .getResultList();
    }

    @Override
    public <T> List<T> findAllIds(String entityName) {
        return createQueryBuilder(entityName)
                //                .orderBy(getEntity(entityName).getListOrder())
                .getIdList();
    }

    public List<Document> findAllDocuments(Class entityType) {
        return createQueryBuilder(entityType)
                .orderBy(getEntity(entityType).getListOrder())
                .getDocumentList();
    }

    public List<Document> findAllDocuments(String entityName) {
        return createQueryBuilder(entityName)
                .orderBy(getEntity(entityName).getListOrder())
                .getDocumentList();
    }

    @Override
    public <T> T findById(Class entityType, Object id) {
        return findById(getEntity(entityType).getName(), id);
    }

    @Override
    public <T> T findById(String entityType, Object id) {
        if (id == null) {
            return null;
        }
        EntityCollectionCache c = getPersistenceUnitCache();
        T o = (T) c.findById(entityType, createKey(id));
        if (o != null) {
            return o;
        }
        return createQueryBuilder(entityType).byId(id).getFirstResultOrNull();
    }

    @Override
    public <T> T reloadObject(T object) {
        if (object == null) {
            throw new IllegalUPAArgumentException("NullObject");
        }
        Entity entity = getEntity(object.getClass());
        return (T) findById(entity.getName(), entity.getBuilder().objectToId(object));
    }

    @Override
    public <T> T reloadObject(String entityName, Object object) {
        if (object == null) {
            throw new IllegalUPAArgumentException("NullObject");
        }
        Entity entity = getEntity(entityName);
        return (T) findById(entity.getName(), entity.getBuilder().objectToId(object));
    }

    @Override
    public Document reloadDocument(String entityName, Object object) {
        if (object == null) {
            throw new IllegalUPAArgumentException("NullObject");
        }
        Entity entity = getEntity(entityName);
        return findDocumentById(entityName, entity.getBuilder().objectToId(object));
    }

    @Override
    public Document reloadDocument(Class entityType, Object object) {
        Entity entity = getEntity(entityType);
        return findDocumentById(entityType, entity.getBuilder().objectToId(object));
    }

    @Override
    public boolean existsById(String entityName, Object id) {
        if (getPersistenceUnitCache().findById(entityName, createKey(id)) != null) {
            return true;
        }
        return createQueryBuilder(entityName).byId(id).getIdList().size() > 0;
    }

    @Override
    public Document findDocumentById(Class entityType, Object id) {
        return createQueryBuilder(entityType).byId(id).getDocument();
    }

    @Override
    public Document findDocumentById(String entityName, Object id) {
        return createQueryBuilder(entityName).byId(id).getDocument();
    }

    //////////////////////////////////////
    // TRANSACTIONS
    //////////////////////////////////////
    @Override
    public boolean beginTransaction(TransactionType transactionType) {
        checkStart();
        Session currentSession = getCurrentSession();
        if (transactionType == null) {
            transactionType = TransactionType.SUPPORTS;
        }
        Transaction currentTransaction = currentSession.getParam(this, Transaction.class, SessionParams.TRANSACTION, null);
        switch (transactionType) {
            case MANDATORY: {
                if (currentTransaction == null) {
                    throw new TransactionException(new I18NString("TransactionMandatoryException"));
                }
                return false;
            }
            case SUPPORTS: {
                return false;
            }
            case NOT_SUPPORTED: {
                //should suspend transaction here
                if (currentTransaction != null) {
                    //TODO suspend transaction
                }
                return false;
            }
            case NEVER: {
                //should throw exception if transaction found
                if (currentTransaction == null) {
                    throw new TransactionException(new I18NString("TransactionNeverException"));
                }
                return false;
            }
            case REQUIRED: {
                if (currentTransaction == null) {
                    Transaction transaction = transactionManager.createTransaction(getConnection(), this, persistenceStore);
                    transaction.begin();
                    currentSession.pushContext();
                    currentSession.setParam(this, SessionParams.TRANSACTION_TYPE, transactionType);
                    currentSession.setParam(this, SessionParams.TRANSACTION, transaction);
                    return true;
                }
                return false;
            }
        }
        throw new UPAException(new I18NString("Unexpected"));
    }

    @Override
    public Session getCurrentSession() {
        return getPersistenceGroup().getCurrentSession();
    }

    @Override
    public void commitTransaction() {
        Session currentSession = getCurrentSession();
        Transaction it = currentSession.getImmediateParam(this, Transaction.class, SessionParams.TRANSACTION, null);
        if (it != null) {
            it.commit();
            currentSession.popContext();
        } else {
            throw new UPAException(new I18NString("TransactionContextMissing"));
        }

//        TransactionType tt = currentSession.getParam(this, TransactionType.class, SessionParams.TRANSACTION_TYPE, PlatformUtils.getUndefinedValue(TransactionType.class));
//        if(PlatformUtils.isUndefinedEnumValue(TransactionType.class,tt)){
//            tt=TransactionType.REQUIRED;
//        }
//        Transaction it = currentSession.getImmediateParam(this, Transaction.class, SessionParams.TRANSACTION, null);
//        Transaction t = currentSession.getParam(this, Transaction.class, SessionParams.TRANSACTION, null);
//        switch (tt) {
//            case SUPPORTS: {
//                //do nothing
//                break;
//            }
//            case REQUIRED:
//            case MANDATORY: {
//                if (it == null) {
//                    if (t == null) {
//                        throw new UPAException(new I18NString("TransactionContextMissing"));
//                    } else {
//                        //
//                        throw new UPAException(new I18NString("TransactionContextMissing"));
//                        //t.commit();
//                    }
//                } else {
//                    it.commit();
//                }
//                break;
//            }
//        }
//        if (it != null) {
//            it.close();
//        }
//        currentSession.popContext();
    }

    @Override
    public void rollbackTransaction() {
        Session currentSession = getCurrentSession();
        Transaction it = currentSession.getImmediateParam(this, Transaction.class, SessionParams.TRANSACTION, null);
        if (it != null) {
            it.rollback();
            currentSession.popContext();
        } else {
            throw new UPAException(new I18NString("TransactionContextMissing"));
        }

//        TransactionType tt = currentSession.getParam(this, TransactionType.class, SessionParams.TRANSACTION_TYPE, PlatformUtils.getUndefinedValue(TransactionType.class));
//        Transaction it = currentSession.getImmediateParam(this, Transaction.class, SessionParams.TRANSACTION, null);
//        Transaction t = currentSession.getParam(this, Transaction.class, SessionParams.TRANSACTION, null);
//        switch (tt) {
//            case SUPPORTS: {
//                //do nothing
//                break;
//            }
//            case REQUIRED:
//            case MANDATORY: {
//                if (it == null) {
//                    if (t == null) {
//                        throw new UPAException(new I18NString("TransactionContextMissing"));
//                    } else {
//                        //
//                        t.rollback();
//                    }
//                } else {
//                    it.rollback();
//                }
//                break;
//            }
//        }
//        if (it != null) {
//            it.close();
//        }
//        currentSession.popContext();
    }

    private void checkStart() {
        if (!started && !starting) {
            throw new UPAException("PersistenceUnitNotStartedException");
        }
    }

    public boolean isStarted() {
        return started;
    }

    //@Override
    public boolean isValidStructureModificationContext() {
        return !isStarted() || isStructureModification();
    }

    @Override
    public boolean isStructureModification() {
        return structureModification;
    }

    @Override
    public void beginStructureModification() {
        if (structureModification) {
            throw new UPAException(new I18NString("StructureEditionPending"));
        }
        this.structureModification = true;
    }

    @Override
    public void commitStructureModification() {
        commitModelChanges();
        getPersistenceStore().revalidateModel();
        boolean someCommit = false;
        EntityExecutionContext context = createContext(ContextOperation.CREATE_PERSISTENCE_NAME, defaultHints);
        persistenceUnitListenerManager.fireOnStorageChanged(new PersistenceUnitEvent(this, persistenceGroup, EventPhase.BEFORE));

        List<OnHoldCommitAction> model = commitStorageActions;
        Collections.sort(model, OnHoldCommitActionComparator.INSTANCE);
        for (OnHoldCommitAction next : model) {
            next.commitStorage(context);
            someCommit = true;
        }
        model.clear();

        if (persistenceStore.commitStorage()) {
            someCommit = true;
        }
        List<Entity> initializables = new ArrayList<Entity>();
        for (Entity entity : getEntities()) {
            String persistenceAction = entity.getProperties().getString("persistence.PersistenceAction");
            entity.getProperties().remove("persistence.PersistenceAction");
            if ("ADD".equals(persistenceAction) //&& entity.getShield().isInitializeSupported()
                    ) {
                initializables.add(entity);
            }
            entity.commitStructureModification(persistenceStore);
        }
        for (Entity entity : initializables) {
            entity.initialize();
        }

        persistenceUnitListenerManager.fireOnStorageChanged(new PersistenceUnitEvent(this, persistenceGroup, EventPhase.AFTER));
        this.structureModification = false;
    }

    @Override
    public void close() {
//        EntityExecutionContext context = createContext(ContextOperation.CLOSE, defaultHints);

        persistenceUnitListenerManager.fireOnClose(new PersistenceUnitEvent(this, persistenceGroup, EventPhase.BEFORE));
        getDefaultPackage().close();
        closed = true;

        persistenceUnitListenerManager.fireOnClose(new PersistenceUnitEvent(this, persistenceGroup, EventPhase.AFTER));
        persistenceUnitListenerManager.close();
    }

    @Override
    public String toString() {
        return getAbsoluteName();
    }

    public boolean isClosed() {
        return closed;
    }

    @Override
    public List<Index> getIndexes() {
        return registrationModel.getIndexes();
    }

    @Override
    public List<Index> getIndexes(String entityName) {
        return registrationModel.getIndexes(entityName);
    }

    @Override
    public ImportExportManager getImportExportManager() {
        if (importExportManager == null) {
            ImportExportManager m = getFactory().createObject(ImportExportManager.class);
            DefaultBeanAdapter a = new DefaultBeanAdapter(m);
            a.setProperty("persistenceUnit", this);
            importExportManager = m;
        }
        return importExportManager;
    }

    //    public PasswordStrategy createPasswordStrategy(CipherStrategyType cipherStrategyType, String cipherStrategy, String cipherValue) {
//        if (cipherStrategyType == null) {
//            return new DefaultPasswordStrategy(DefaultCipherStrategy.MD5, cipherValue);
//        } else {
//            switch (cipherStrategyType) {
//                case DEFAULT:
//                case MD5: {
//                    return new DefaultPasswordStrategy(DefaultCipherStrategy.MD5, cipherValue);
//                }
//                case SHA1: {
//                    return new DefaultPasswordStrategy(DefaultCipherStrategy.SHA1, cipherValue);
//                }
//                case SHA256: {
//                    return new DefaultPasswordStrategy(DefaultCipherStrategy.SHA256, cipherValue);
//                }
//                default: {
//                    if (StringUtils.isNullOrEmpty(cipherStrategy)) {
//                        throw new UPAException("MissingCipherStrategy", cipherStrategy, this);
//                    }
//                    CipherStrategy o;
//                    try {
//                        o = (CipherStrategy) getFactory().createObject(cipherStrategy,null);
//                        return new DefaultPasswordStrategy(o, cipherValue);
//                    } catch (Exception ex) {
//                        throw new UPAException(ex,new I18NString("InvalidCipherStrategy"), cipherStrategy, this);
//                    }
//                }
//            }
//        }
//    }
//
//    public void setPasswordStrategy(PasswordStrategy passwordStrategy) {
//        PasswordStrategy old = this.passwordStrategy;
//        this.passwordStrategy = passwordStrategy;
//        propertyChangeSupport.firePropertyChange("passwordStrategy", old, passwordStrategy);
//    }
//
//    public PasswordStrategy getPasswordStrategy() {
//        return passwordStrategy;
//    }
    public DataTypeTransformFactory getTypeTransformFactory() {
        return typeTransformFactory;
    }

    @Override
    public void setTypeTransformFactory(DataTypeTransformFactory typeTransformFactory) {
        this.typeTransformFactory = typeTransformFactory;
    }

    @Override
    public boolean isAutoStart() {
        return autoStart;
    }

    @Override
    public void setAutoStart(boolean value) {
        if (isStarted()) {
            throw new UPAException("AlreadyStarted");
        }
        this.autoStart = value;
    }

    @Override
    public void addScanFilter(ScanFilter filter) {
        filters.add(filter);
    }

    @Override
    public void removeScanFilter(ScanFilter filter) {
        filters.remove(filter);
    }

    @Override
    public ScanFilter[] getScanFilters() {
        return filters.toArray(new ScanFilter[filters.size()]);
    }

    @Override
    public ConnectionConfig[] getConnectionConfigs() {
        return connectionConfigs.toArray(new ConnectionConfig[connectionConfigs.size()]);
    }

    @Override
    public ConnectionConfig[] getRootConnectionConfigs() {
        return rootConnectionConfigs.toArray(new ConnectionConfig[rootConnectionConfigs.size()]);
    }

    @Override
    public void addConnectionConfig(ConnectionConfig connectionConfig) {
        if (connectionConfig != null && !connectionConfigs.contains(connectionConfig)) {
            connectionConfigs.add(connectionConfig);
        }
    }

    @Override
    public void removeConnectionConfig(int index) {
        connectionConfigs.remove(index);
    }

    @Override
    public void addRootConnectionConfig(ConnectionConfig connectionConfig) {
        rootConnectionConfigs.add(connectionConfig);
    }

    @Override
    public void removeRootConnectionConfig(int index) {
        rootConnectionConfigs.remove(index);
    }

    public DecorationRepository getDecorationRepository() {
        return decorationRepository;
    }

    public EntityDescriptorResolver getEntityDescriptorResolver() {
        return entityDescriptorResolver;
    }

    public PersistenceUnitListenerManager getPersistenceUnitListenerManager() {
        return persistenceUnitListenerManager;
    }

    @Override
    public UserPrincipal getUserPrincipal() {
        return getUserPrincipal(getCurrentSession());
    }

    public UserPrincipal getUserPrincipal(Session currentSession) {
        if (currentSession == null) {
            return null;
        }
        UserPrincipal p = currentSession.getParam(this, UserPrincipal.class, SessionParams.USER_PRINCIPAL, null);
        if (p == null) {
            //inherit global context
            p = getSecurityManager().getUserPrincipal();
        }
        return p;
    }

    @Override
    public void login(String login, String credentials) {
        Session currentSession = getCurrentSession();
        UserPrincipal p = getSecurityManager().login(login, credentials);
        currentSession.pushContext();
        currentSession.setParam(this, SessionParams.USER_PRINCIPAL, p);
    }

    @Override
    public void loginPrivileged(String login) {
        Session currentSession = getCurrentSession();
        UserPrincipal p = getSecurityManager().loginPrivileged(login);
        currentSession.pushContext();
        currentSession.setParam(this, SessionParams.USER_PRINCIPAL, p);
        if (login == null || login.equals("")) {
            currentSession.setParam(this, SessionParams.SYSTEM, privateUUID.toString());
        }
    }

    @Override
    public void logout() {
        Session currentSession = getCurrentSession();
        UserPrincipal user = currentSession.getImmediateParam(this, UserPrincipal.class, SessionParams.USER_PRINCIPAL, null);
        if (user != null) {
            currentSession.popContext();
        } else {
//            user = currentSession.getParam(this, UserPrincipal.class, SessionParams.USER_PRINCIPAL, null);
//            if (user != null) {
//                while (true) {
//                    currentSession.popContext();
//                    user = currentSession.getImmediateParam(this, UserPrincipal.class, SessionParams.USER_PRINCIPAL, null);
//                    if (user != null) {
//                        break;
//                    }
//                }
//                return;
//            }
            throw new UnexpectedException("Invalid Logout");
        }
    }

    @Override
    public boolean currentSessionExists() {
        return getPersistenceGroup().currentSessionExists();
    }

    @Override
    public Key createKey(Object... keyValues) {
        return keyValues == null ? null : new DefaultKey(keyValues);
    }

    @Override
    public Callback addCallback(MethodCallback methodCallback) {
        Callback c = getPersistenceGroup().getContext().createCallback(methodCallback);
        addCallback(c);
        return c;
    }

    @Override
    public void addCallback(Callback callback) {
        Map<String, Object> c = callback.getConfiguration();
        if (callback.getEventType() == EventType.ON_EVAL_FUNCTION) {
            String functionName = c == null ? null : (String) c.get("functionName");
            if (StringUtils.isNullOrEmpty(functionName)) {
                throw new UPAException("MissingCallbackFunctionName");
            }
            DataType returnType = (DataType) c.get("returnType");
            if (returnType == null) {
                throw new UPAException("MissingCallbackReturnType");
            }
            getExpressionManager().addFunction(functionName, returnType, new FunctionCallback(callback));
        } else if (callback.getEventType() == EventType.ON_EVAL_FORMULA) {
            String formulaName = c == null ? null : (String) c.get("formulaName");
            if (StringUtils.isNullOrEmpty(formulaName)) {
                throw new UPAException("MissingCallbackFormulaName");
            }
            Class formulaType = c == null ? null : (Class) c.get("formulaType");
            if (formulaType == null) {
                throw new UPAException("MissingCallbackFormulaName");
            }
            if (formulaType.equals(CustomFormula.class)) {
                addNamedFormula(formulaName, new CustomFormulaCallback(callback));
            } else if (formulaType.equals(CustomMultiFormula.class)) {
                addNamedFormula(formulaName, new CustomMultiFormulaCallback(callback));
            } else {
                throw new UPAException("InvalidFormulaType", formulaType, "<>{" + CustomFormula.class.getSimpleName() + "," + CustomMultiFormula.class.getSimpleName() + "}");
            }
        } else {
            persistenceUnitListenerManager.addCallback(callback);
        }
    }

    @Override
    public void removeCallback(Callback callback) {
        Map<String, Object> c = callback.getConfiguration();
        if (callback.getEventType() == EventType.ON_EVAL_FUNCTION) {
            String functionName = c == null ? null : (String) c.get("functionName");
            if (StringUtils.isNullOrEmpty(functionName)) {
                throw new UPAException("MissingCallbackFunctionName");
            }
            getExpressionManager().removeFunction(functionName);
        }
        persistenceUnitListenerManager.removeCallback(callback);
    }

    @Override
    public Callback[] getCallbacks(EventType eventType, ObjectType objectType, String name, boolean system, boolean preparedOnly, EventPhase phase) {

        if (eventType == EventType.ON_EVAL_FUNCTION) {
            ArrayList<Callback> all = new ArrayList<Callback>();
            for (FunctionDefinition function : getExpressionManager().getFunctions()) {
                if (function.getFunction() instanceof FunctionCallback) {
                    all.add(((FunctionCallback) function.getFunction()).getCallback());
                }
            }
            return all.toArray(new Callback[all.size()]);
        }
        return persistenceUnitListenerManager.getCurrentCallbacks(eventType, objectType, name, system, preparedOnly, phase);
    }

    @Override
    public UConnection getConnection() {
        return getConnection(true);
    }

    //@Override
    public UConnection getConnection(boolean create) {
        Session session = getCurrentSession();
        UConnection connection = session.getParam(this, UConnection.class, SessionParams.CONNECTION, null);
        if (connection == null && create) {
            connection = getPersistenceStore().createConnection();
            session.setParam(this, SessionParams.CONNECTION, connection);
            session.addSessionListener(new CloseOnContextPopSessionListener(this, connection));
        }
        return connection;
    }

    @Override
    public void setIdentityConstraintsEnabled(Entity entity, boolean enable) {
        EntityExecutionContext context = createContext(ContextOperation.COMMIT_STORAGE, defaultHints);
        getPersistenceStore().setIdentityConstraintsEnabled(entity, enable, context);
    }

    //    public UConnection getMetadataConnection()  {
//        Session session = getCurrentSession();
//        UConnection connection = session.getParam(this, UConnection.class, SessionParams.METADATA_CONNECTION, null);
//        if (connection == null) {
//            connection = session.getParam(this, UConnection.class, SessionParams.CONNECTION, null);
//        }
//        if (connection == null) {
//            connection = getPersistenceStore().createConnection();
//            session.setParam(this, SessionParams.CONNECTION, connection);
//            session.addSessionListener(new CloseOnContextPopSessionListener(this, connection));
//        }
//        return connection;
//    }
    public EntityExecutionContext createContext(ContextOperation operation, Map<String, Object> hints) {
//        Session currentSession = persistenceUnit.getPersistenceGroup().getCurrentSession();
        EntityExecutionContextExt context = null;
//        if (currentSession != null) {
//            context = currentSession.getParam(persistenceUnit, ExecutionContext.class, SessionParams.EXECUTION_CONTEXT, null);
//            if (context
//                    == null) {
//                context = persistenceUnit.getFactory().createObject(ExecutionContext.class, null);
//                currentSession.setParam(persistenceUnit, SessionParams.EXECUTION_CONTEXT, context);
//            }
//        } else {
//            context = persistenceUnit.getFactory().createObject(ExecutionContext.class, null);
//        }
        context = (EntityExecutionContextExt) getFactory().createObject(EntityExecutionContext.class);
        context.initPersistenceUnit(this, getPersistenceStore(), operation);
        context.setHints(hints);
        return context;
    }

    protected InvokeContext prepareInvokeContext(InvokeContext c) {
        if (c == null) {
            c = new InvokeContext();
        } else {
            c = c.copy();
        }
        c.setPersistenceGroup(getPersistenceGroup());
        c.setPersistenceUnit(this);
        return c;
    }

    @Override
    public <T> T invoke(Action<T> action, InvokeContext invokeContext) {
        return getPersistenceGroup().getContext().invoke(action, prepareInvokeContext(invokeContext));
    }

    @Override
    public <T> T invokePrivileged(Action<T> action, InvokeContext invokeContext) {
        return getPersistenceGroup().getContext().invoke(action, prepareInvokeContext(invokeContext));
    }

    @Override
    public void invoke(VoidAction action, InvokeContext invokeContext) {
        getPersistenceGroup().getContext().invoke(action, prepareInvokeContext(invokeContext));
    }

    @Override
    public void invokePrivileged(VoidAction action, InvokeContext invokeContext) {
        getPersistenceGroup().getContext().invokePrivileged(action, prepareInvokeContext(invokeContext));
    }

    @Override
    public <T> T invoke(Action<T> action) {
        return getPersistenceGroup().getContext().invoke(action, prepareInvokeContext(null));
    }

    @Override
    public <T> T invokePrivileged(Action<T> action) {
        return getPersistenceGroup().getContext().invokePrivileged(action, prepareInvokeContext(null));
    }

    @Override
    public void invoke(VoidAction action) {
        getPersistenceGroup().getContext().invoke(action, prepareInvokeContext(null));
    }

    @Override
    public void invokePrivileged(VoidAction action) {
        getPersistenceGroup().getContext().invokePrivileged(action, prepareInvokeContext(null));
    }

    @Override
    public Comparator<Entity> getDependencyComparator() {
        return DefaultEntityDependencyComparator.INSTANCE;

    }

    @Override
    public <T> T copyObject(T r) {
        if (r == null) {
            return null;
        }
        return getEntity(r).getBuilder().copyObject(r);
    }

    @Override
    public <T> T copyObject(String entityName, T r) {
        if (r == null) {
            return null;
        }
        return getEntity(r).getBuilder().copyObject(r);
    }

    @Override
    public <T> T copyObject(Class entityType, T r) {
        if (r == null) {
            return null;
        }
        return getEntity(r).getBuilder().copyObject(r);
    }

    @Override
    public boolean isEmpty(String entityName) {
        return getEntity(entityName).isEmpty();
    }

    @Override
    public boolean isEmpty(Class entityType) {
        return getEntity(entityType).isEmpty();
    }

    @Override
    public long getEntityCount(String entityName) {
        return getEntity(entityName).getEntityCount();
    }

    @Override
    public long getEntityCount(Class entityType) {
        return getEntity(entityType).getEntityCount();
    }

    @Override
    public PersistenceUnitInfo getInfo() {
        PersistenceUnitInfo i = new PersistenceUnitInfo();
        i.setName(getName());
        i.setRoot(getDefaultPackage().getInfo());
        List<RelationshipInfo> r = new ArrayList<>();
        for (Relationship relationship : getRelationships()) {
            r.add(relationship.getInfo());
        }
        i.setRelationships(r);
        return i;
    }

    public NamedFormulaDefinition[] getNamedFormulas() {
        return namedFormulas.values().toArray(new NamedFormulaDefinition[namedFormulas.size()]);
    }

    public NamedFormulaDefinition getNamedFormula(String name) {
        String uname = NamingStrategyHelper.getUniformValue(isCaseSensitiveIdentifiers(), name);
        NamedFormulaDefinition f = namedFormulas.get(uname);
        if (f == null) {
            throw new IllegalUPAArgumentException("Formula Not Found " + name);
        }
        return f;
    }

    public void addNamedFormula(String name, Formula formula) {
        name = NamingStrategyHelper.getUniformValue(isCaseSensitiveIdentifiers(), name);
        if (formula == null) {
            throw new UPAException("InvalidCustomFormula", formula);
        }
        if (formula instanceof ExpressionFormula) {
            throw new UPAException("InvalidCustomFormula", formula);
        }
        if (formula instanceof Sequence) {
            throw new UPAException("InvalidCustomFormula", formula);
        }
        if (namedFormulas.containsKey(name)) {
            throw new IllegalUPAArgumentException("Formula Already defined " + name);
        }
        if (formula instanceof CustomFormula) {
            namedFormulas.put(name, new DefaultNamedFormulaDefinition(name, formula));
        }
        if (formula instanceof CustomMultiFormula) {
            namedFormulas.put(name, new DefaultNamedFormulaDefinition(name, formula));
        }
    }

    public void removeNamedFormula(String name) {
        name = NamingStrategyHelper.getUniformValue(isCaseSensitiveIdentifiers(), name);
        if (namedFormulas.containsKey(name)) {
            throw new IllegalUPAArgumentException("No Such Function " + name);
        }
    }

    @Override
    public PersistenceNameStrategy getPersistenceNameStrategy() {
        return persistenceNameStrategy;
    }

    @Override
    public boolean isCaseSensitiveIdentifiers() {
        return caseSensitiveIdentifiers;
    }

    @Override
    public void setCaseSensitiveIdentifiers(boolean caseSensitiveIdentifiers) {
        this.caseSensitiveIdentifiers = caseSensitiveIdentifiers;
    }

    @Override
    public void invalidateCache() {
        getPersistenceUnitCache().invalidate();
    }

    @Override
    public void invalidateCache(String entityName) {
        getPersistenceUnitCache().invalidate(entityName);
    }

    @Override
    public void invalidateCacheById(String entityName, Object id) {
        if (id == null) {
            getPersistenceUnitCache().invalidate(entityName);
        } else {
            Entity e = getEntity(entityName);
            getPersistenceUnitCache().invalidateByKey(entityName, e.getBuilder().idToKey(id));
        }
    }

    @Override
    public void invalidateCacheByKey(String entityName, Key id) {
        if (id == null) {
            getPersistenceUnitCache().invalidate(entityName);
        } else {
            getPersistenceUnitCache().invalidateByKey(entityName, id);
        }
    }

    @Override
    public boolean updateFormulas(String entityName, Object id) {
        Entity entity = getEntity(entityName);
        return entity.createUpdateQuery().byId(id).updateAllFormulas().execute() > 0;
    }

    @Override
    public boolean updateFormulas(Class entityType, Object id) {
        Entity entity = getEntity(entityType);
        return updateFormulas(entity.getName(), id);
    }

    @Override
    public <T> List<T> findAllByField(String entityName, String field, Object value) {
        Entity entity = getEntity(entityName);
        DataType dt = entity.getField(field).getDataType();
        return entity.createQueryBuilder().setEntityAlias("o")
                .byExpression(new And(new Var(new Var("o"), field), new Literal(value, dt)))
                .orderBy(entity.getListOrder())
                .getResultList();
    }

    @Override
    public <T> List<T> findAllByField(Class type, String field, Object value) {
        Entity entity = getEntity(type);
        return findAllByField(entity.getName(), field, value);
    }

}
