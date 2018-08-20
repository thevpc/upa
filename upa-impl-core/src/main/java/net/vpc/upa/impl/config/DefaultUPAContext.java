/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.config;

import net.vpc.upa.*;
import net.vpc.upa.Properties;
import net.vpc.upa.callbacks.*;
import net.vpc.upa.config.ScanFilter;
import net.vpc.upa.config.ScanSource;
import net.vpc.upa.exceptions.InvocationException;
import net.vpc.upa.exceptions.NoSuchPersistenceGroupException;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.exceptions.UPAIllegalArgumentException;
import net.vpc.upa.impl.DefaultUPAContextFactory;
import net.vpc.upa.impl.config.callback.DefaultCallback;
import net.vpc.upa.impl.config.callback.DefaultMethodArgumentsConverter;
import net.vpc.upa.impl.config.callback.InvokeArgument;
import net.vpc.upa.impl.config.callback.PosInvokeArgument;
import net.vpc.upa.impl.config.decorations.DecorationRepository;
import net.vpc.upa.impl.config.decorations.DefaultDecorationRepository;
import net.vpc.upa.impl.event.RemoveObjectEventCallback;
import net.vpc.upa.impl.event.UPAContextListenerManager;
import net.vpc.upa.impl.event.UpdateFormulaObjectEventCallback;
import net.vpc.upa.impl.event.UpdateObjectEventCallback;
import net.vpc.upa.impl.ext.PersistenceGroupExt;
import net.vpc.upa.impl.util.DefaultVarContext;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.impl.util.StringUtils;
import net.vpc.upa.persistence.UPAContextConfig;
import net.vpc.upa.types.DataType;
import net.vpc.upa.types.TypesFactory;

import java.lang.annotation.Annotation;
import java.lang.reflect.Method;
import java.util.*;
import java.util.logging.Level;
import java.util.logging.Logger;

import net.vpc.upa.config.UPAContextConfigAnnotationParser;
import net.vpc.upa.exceptions.PersistenceGroupAlreadyExistsException;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class DefaultUPAContext implements UPAContext {

    private final static Logger log = Logger.getLogger(DefaultUPAContext.class.getName());
    private final LinkedHashMap<String, PersistenceGroup> persistenceGroups = new LinkedHashMap<String, PersistenceGroup>();
    private final List<ScanFilter> filters = new ArrayList<ScanFilter>();
    private final List<CloseListener> closeListeners = new ArrayList<CloseListener>();
    private final DecorationRepository decorationRepository = new DefaultDecorationRepository("DecoRepo[boot]", true);
    private ObjectFactory bootstrapObjectFactory;
    private UPAContextFactory objectFactory;
    private PersistenceGroupProvider persistenceGroupProvider;
    private Map<String, Object> properties = new HashMap<String, Object>();
    private UPAContextConfig bootstrapContextConfig;
    private InvokeContext emptyInvokeContext = new InvokeContext();
    private UPAContextListenerManager listeners;
    private ThreadLocal<Properties> threadProperties = new ThreadLocal<Properties>();

    public DefaultUPAContext() {
        listeners = new UPAContextListenerManager(this);
    }

    /**
     * @InheritDoc
     */
    @Override
    public <T> T makeSessionAware(final T instance, final MethodFilter methodFilter) throws UPAException {
        return (T) PlatformUtils.createObjectInterceptor(
                instance.getClass(),
                new MakeSessionAwareMethodInterceptor(this, methodFilter, instance));
    }

    /**
     * @InheritDoc
     */
    @Override
    public <T> T makeSessionAware(final T instance) throws UPAException {
        return makeSessionAware(instance, (MethodFilter) null);
    }

    /**
     * @InheritDoc
     */
    @Override
    public UPAContextConfig getBootstrapContextConfig() {
        if (bootstrapContextConfig == null) {
            DefaultVarContext context = new DefaultVarContext(System.getProperties());
            DefaultUPAContextLoader object = new DefaultUPAContextLoader(context);
            UPAContextConfig contextConfig = object.parse();
            bootstrapContextConfig = contextConfig;
        }
        return bootstrapContextConfig;
    }

    /**
     * @InheritDoc
     */
    @Override
    public void start(ObjectFactory factory, UPAContextConfig[] contextConfig, Class[] configClasses) throws UPAException {
        log.log(Level.FINE, "Starting UPAContext");
        bootstrapObjectFactory = factory;
        objectFactory = new DefaultUPAContextFactory(bootstrapObjectFactory.createObject(ObjectFactory.class));
        objectFactory.setParentFactory(bootstrapObjectFactory);
        UPAContextConfigAnnotationParser s = objectFactory.getSingleton(UPAContextConfigAnnotationParser.class);
        List<UPAContextConfig> all = new ArrayList<>();
        if (contextConfig != null) {
            for (UPAContextConfig cc : contextConfig) {
                if (cc != null) {
                    all.add(cc);
                }
            }
        }
        if (configClasses != null) {
            for (Class configClass : configClasses) {
                if (configClass != null) {
                    all.add(s.parse(configClass));
                }
            }
        }
        UPAContextConfig bootstrapContextConfig = getBootstrapContextConfig();
        for (UPAContextConfig cc : all) {
            if (cc != null) {
                if (cc.getAutoScan() != null) {
                    if (bootstrapContextConfig.getAutoScan() == null) {
                        bootstrapContextConfig.setAutoScan(cc.getAutoScan());
                    }
                }
                bootstrapContextConfig.getFilters().addAll(cc.getFilters());
                bootstrapContextConfig.getPersistenceGroups().addAll(cc.getPersistenceGroups());
            }
        }

        loadConfig(bootstrapContextConfig);
    }

    public void loadConfig(UPAContextConfig contextConfig) throws UPAException {
        if (contextConfig.getFilters() != null) {
            int count = 0;
            for (ScanFilter filter : contextConfig.getFilters()) {
                if (filter != null) {
                    count++;
                    addScanFilter(filter);
                }
            }
            if (count == 0 && (contextConfig.getAutoScan() == null || contextConfig.getAutoScan().booleanValue())) {
                addScanFilter(new ScanFilter(null, null, false, UPAContextConfig.XML_ORDER));
            }
        }
        scan(getFactory().createContextScanSource().setName("UPAContext").setNoIgnore(false), contextConfig, null, true);
        for (PersistenceGroup g : getPersistenceGroups()) {
            for (PersistenceUnit u : g.getPersistenceUnits()) {
                if (!u.isStarted() && u.isAutoStart()) {
                    u.start();
                }
            }
        }
    }

    /**
     * @InheritDoc
     */
    @Override
    public void scan(ScanSource scanSource, UPAContextConfig contextConfig, ScanListener listener, boolean configure) {
        URLAnnotationStrategySupport support = new URLAnnotationStrategySupport();
        support.scan(scanSource, contextConfig, configure ? new ConfigureScanListener(listener) : listener, this, decorationRepository);
    }

    public boolean isContextProviderSet() {
        return persistenceGroupProvider != null;
    }

    public PersistenceUnit getPersistenceUnit() throws UPAException {
        return getPersistenceGroup().getPersistenceUnit();
    }

    public List<PersistenceGroup> getPersistenceGroups() throws UPAException {
        return new ArrayList<PersistenceGroup>(persistenceGroups.values());
    }

    public PersistenceGroup getPersistenceGroup() throws UPAException {
        return getPersistenceGroup(getPersistenceGroupProvider().getPersistenceGroup());
    }

    public void setPersistenceGroup(String name) throws UPAException {
        getPersistenceGroupProvider().setPersistenceGroup(name);
    }

    private PersistenceGroupProvider getPersistenceGroupProvider() {
        if (persistenceGroupProvider == null) {
            throw new UPAIllegalArgumentException("PersistenceGroupProvider not found");
        }
        return persistenceGroupProvider;
    }

    public void setPersistenceGroupProvider(PersistenceGroupProvider contextProvider) {
        this.persistenceGroupProvider = contextProvider;
    }

    public final UPAContextFactory getFactory() {
        return objectFactory;
    }

    public PersistenceGroup getPersistenceGroup(String name) throws UPAException {
        if (StringUtils.isNullOrEmpty(name)) {
            name = "";
        }
        if (!persistenceGroups.containsKey(name)) {
            throw new NoSuchPersistenceGroupException(name);
        }
        return persistenceGroups.get(name);
    }

    public boolean containsPersistenceGroup(String name) {
        if (StringUtils.isNullOrEmpty(name)) {
            name = "";
        }
        return persistenceGroups.containsKey(name);
    }

    public PersistenceGroup addPersistenceGroup(String name) throws UPAException {
        if (StringUtils.isNullOrEmpty(name)) {
            name = "";
        }
        if (persistenceGroups.containsKey(name)) {
            throw new PersistenceGroupAlreadyExistsException(name);
        }
        ObjectFactory factory = getFactory();
        if (!isContextProviderSet()) {
            setPersistenceGroupProvider(factory.createObject(PersistenceGroupProvider.class));
        }
        PersistenceGroupExt persistenceGroup = (PersistenceGroupExt) factory.createObject(PersistenceGroup.class);
        persistenceGroup.init(name, this, factory);
        PersistenceGroupEvent evt = new PersistenceGroupEvent(persistenceGroup, this);

        listeners.fireOnCreatePersistenceGroup(evt, EventPhase.BEFORE);

        persistenceGroups.put(name, persistenceGroup);

        if (getPersistenceGroupProvider().getPersistenceGroup() == null) {
            getPersistenceGroupProvider().setPersistenceGroup(name);
        }

        listeners.fireOnCreatePersistenceGroup(evt, EventPhase.AFTER);

        return persistenceGroup;
    }

    /**
     * @InheritDoc
     */
    @Override
    public void removePersistenceGroup(String name) throws UPAException {
        if (name == null) {
            name = "";
        }
        PersistenceGroup persistenceGroup = getPersistenceGroup(name);
        String oldName = getPersistenceGroupProvider().getPersistenceGroup();

        PersistenceGroupEvent event = new PersistenceGroupEvent(persistenceGroup, this);
        listeners.fireOnDropPersistenceGroup(event, EventPhase.BEFORE);
        if (!persistenceGroup.isClosed()) {
            persistenceGroup.close();
        }
        persistenceGroups.remove(name);
        if(oldName!=null && oldName.equals(name)){
            getPersistenceGroupProvider().setPersistenceGroup(null);
        }
        listeners.fireOnDropPersistenceGroup(event, EventPhase.AFTER);
    }

    /**
     * @InheritDoc
     */
    @Override
    public void addPersistenceGroupDefinitionListener(PersistenceGroupDefinitionListener persistenceGroupDefinitionListener) throws UPAException {
        listeners.addPersistenceGroupDefinitionListener(persistenceGroupDefinitionListener);
    }

    /**
     * @InheritDoc
     */
    @Override
    public void removePersistenceGroupDefinitionListener(PersistenceGroupDefinitionListener persistenceGroupDefinitionListener) throws UPAException {
        listeners.removePersistenceGroupDefinitionListener(persistenceGroupDefinitionListener);
    }

    public PersistenceGroupDefinitionListener[] getPersistenceGroupDefinitionListeners() {
        return listeners.getPersistenceGroupDefinitionListeners();
    }

    /**
     * @InheritDoc
     */
    @Override
    public <T> T makeSessionAware(final T instance, final Class<Annotation> sessionAwareMethodAnnotation) throws UPAException {
        return makeSessionAware(instance, sessionAwareMethodAnnotation == null ? null : new AnnotationMethodFilter(sessionAwareMethodAnnotation, decorationRepository));
    }

    /**
     * @InheritDoc
     */
    @Override
    public <T> T makeSessionAware(final Class<T> type, final MethodFilter methodFilter) throws UPAException {
        return (T) PlatformUtils.createObjectInterceptor(
                type,
                new MakeSessionAwareMethodInterceptor2<T>(methodFilter));
    }

    /**
     * @InheritDoc
     */
    @Override
    public <T> T invokePrivileged(Action<T> action, InvokeContext invokeContext) throws UPAException {
        return invoke(action, invokeContext, true);
    }

    /**
     * @InheritDoc
     */
    @Override
    public <T> T invoke(Action<T> action, InvokeContext invokeContext) throws UPAException {
        return invoke(action, invokeContext, false);
    }

    protected <T> T invoke(Action<T> action, InvokeContext invokeContext, boolean privileged) throws UPAException {
        if (invokeContext == null) {
            invokeContext = emptyInvokeContext;
        }
        PersistenceGroup persistenceGroup = null;
        T ret = null;
        boolean customPersistenceGroup = false;
        boolean customPersistenceUnit = false;
        PersistenceUnit initialPersistenceUnit = UPA.getPersistenceUnit();
        PersistenceGroup initialPersistenceGroup = UPA.getPersistenceGroup();
        PersistenceGroup _persistenceGroup = invokeContext.getPersistenceGroup();
        try {
            if (_persistenceGroup != null) {
                persistenceGroup = _persistenceGroup;
            } else if (invokeContext.getPersistenceUnit() != null) {
                persistenceGroup = invokeContext.getPersistenceUnit().getPersistenceGroup();
            }
            if (persistenceGroup == null) {
                persistenceGroup = UPA.getPersistenceGroup();
            }
            Session s = persistenceGroup.findCurrentSession();
            boolean sessionCreated = false;
            boolean loginCreated = false;
            if (s == null) {
                s = persistenceGroup.openSession();
                sessionCreated = true;
            }
            PersistenceUnit pu = null;
            if (invokeContext.getPersistenceUnit() != null) {
                pu = invokeContext.getPersistenceUnit();
            }
            if (pu == null) {
                pu = persistenceGroup.getPersistenceUnit();
            }

            if (privileged) {
                pu.loginPrivileged(invokeContext.getLogin());
                loginCreated = true;
            } else {
                if (invokeContext.getLogin() != null) {
                    pu.login(invokeContext.getLogin(), invokeContext.getCredentials());
                    loginCreated = true;
                }
            }
            boolean transactionCreated = false;
            if (invokeContext.getTransactionType() != null) {
                if (pu.beginTransaction(invokeContext.getTransactionType())) {
                    transactionCreated = true;
                }
            }
            customPersistenceGroup = pu.getPersistenceGroup() != initialPersistenceGroup;
            customPersistenceUnit = pu != initialPersistenceUnit;
            if (customPersistenceGroup) {
                UPA.getContext().setPersistenceGroup(pu.getPersistenceGroup().getName());
            }
            if (customPersistenceUnit) {
                pu.getPersistenceGroup().setPersistenceUnit(pu.getName());
            }
            Throwable anyErr = null;
            try {
                ret = action.run();
                if (transactionCreated) {
                    pu.commitTransaction();
                }
            } catch (Throwable e) {
                anyErr = e;
                e.printStackTrace();
                if (transactionCreated) {
                    pu.rollbackTransaction();
                }
                if (e instanceof UPAException || e instanceof RuntimeException) {
                    throw e;
                }
                throw new InvocationException(e);
            } finally {
                if (loginCreated) {
                    pu.logout();
                }
                if (sessionCreated) {
                    s.close();
                }
            }
        } finally {
            if (customPersistenceGroup) {
                UPA.getContext().setPersistenceGroup(initialPersistenceGroup.getName());
            }
            if (customPersistenceUnit) {
                initialPersistenceGroup.setPersistenceUnit(initialPersistenceUnit.getName());
            }
        }
        return ret;
    }

    /**
     * @InheritDoc
     */
    @Override
    public <T> T invoke(Action<T> action) throws UPAException {
        return invoke(action, null);
    }

    /**
     * @InheritDoc
     */
    @Override
    public <T> T invokePrivileged(Action<T> action) throws UPAException {
        return invokePrivileged(action, null);
    }

    /**
     * @InheritDoc
     */
    @Override
    public void invoke(VoidAction action, InvokeContext invokeContext) throws UPAException {
        invoke(new VoidActionAdapter(action), invokeContext);
    }

    /**
     * @InheritDoc
     */
    @Override
    public void invoke(VoidAction action) throws UPAException {
        invoke(new VoidActionAdapter(action));
    }

    /**
     * @InheritDoc
     */
    @Override
    public void invokePrivileged(VoidAction action, InvokeContext invokeContext) throws UPAException {
        invokePrivileged(new VoidActionAdapter(action), invokeContext);
    }

    /**
     * @InheritDoc
     */
    @Override
    public void invokePrivileged(VoidAction action) throws UPAException {
        invokePrivileged(new VoidActionAdapter(action));
    }

    /**
     * @InheritDoc
     */
    @Override
    public void close() {
        CloseListener[] li = getCloseListeners();
        for (CloseListener listener : li) {
            listener.beforeClose(this);
        }
        synchronized (persistenceGroups) {
            for (String name : new HashSet<String>(persistenceGroups.keySet())) {
                removePersistenceGroup(name);
            }
        }
        for (CloseListener listener : li) {
            listener.afterClose(this);
        }
        setPersistenceGroup(null);
    }

    /**
     * @InheritDoc
     */
    @Override
    public void addCloseListener(CloseListener listener) {
        synchronized (closeListeners) {
            closeListeners.add(listener);
        }
    }

    /**
     * @InheritDoc
     */
    @Override
    public void removeCloseListener(CloseListener listener) {
        synchronized (closeListeners) {
            closeListeners.remove(listener);
        }
    }

    /**
     * @InheritDoc
     */
    @Override
    public CloseListener[] getCloseListeners() {
        return closeListeners.toArray(new CloseListener[closeListeners.size()]);
    }


    /**
     * @InheritDoc
     */
    @Override
    public void addScanFilter(ScanFilter filter) {
        filters.add(filter);
    }

    /**
     * @InheritDoc
     */
    @Override
    public void removeScanFilter(ScanFilter filter) {
        filters.remove(filter);
    }

    /**
     * @InheritDoc
     */
    @Override
    public ScanFilter[] getScanFilters() {
        return filters.toArray(new ScanFilter[filters.size()]);
    }

    /**
     * @InheritDoc
     */
    @Override
    public Map<String, Object> getProperties() {
        return properties;
    }

    /**
     * @InheritDoc
     */
    @Override
    public void setProperties(Map<String, Object> properties) {
        this.properties = properties;
    }

    private InvokeArgument[] createArguments(Method m) {
        Class<?>[] parameterTypes = m.getParameterTypes();
        InvokeArgument[] aa = new InvokeArgument[parameterTypes.length];
        for (int i = 0; i < aa.length; i++) {
            aa[i] = new PosInvokeArgument(null, parameterTypes[i], i, false);
        }
        return aa;
    }

    /**
     * @InheritDoc
     */
    @Override
    public Callback createCallback(MethodCallback methodCallback) {
        Object instance = methodCallback.getInstance();
        Method method = methodCallback.getMethod();
        CallbackType callbackType = methodCallback.getCallbackType();
        Map<String, Object> configuration = methodCallback.getConfiguration();
//        if (configuration == null) {
//            configuration = new HashMap<String, Object>();
//        }
        ObjectType objectType = PlatformUtils.getUndefinedValue(ObjectType.class);
        ObjectType requestedObjectType = methodCallback.getObjectType();
        EventPhase phase = methodCallback.getPhase();
        if (!PlatformUtils.isUndefinedEnumValue(ObjectType.class, requestedObjectType)) {
            objectType = requestedObjectType;
        } else {
            for (Class<?> parameterType : method.getParameterTypes()) {
                if (parameterType.equals(ContextEvent.class)) {
                    objectType = ObjectType.CONTEXT;
                    break;
                }
                if (parameterType.equals(PersistenceGroupEvent.class)) {
                    objectType = ObjectType.PERSISTENCE_GROUP;
                    break;
                }
                if (parameterType.equals(PersistenceUnitEvent.class)) {
                    objectType = ObjectType.PERSISTENCE_UNIT;
                    break;
                }
                if (parameterType.equals(PackageEvent.class)) {
                    objectType = ObjectType.PACKAGE;
                    break;
                }

                if (parameterType.equals(FieldEvent.class)) {
                    objectType = ObjectType.FIELD;
                    break;
                }
                if (parameterType.equals(IndexEvent.class)) {
                    objectType = ObjectType.INDEX;
                    break;
                }
                if (parameterType.equals(RelationshipEvent.class)) {
                    objectType = ObjectType.RELATIONSHIP;
                    break;
                }
                if (parameterType.equals(TriggerEvent.class)) {
                    objectType = ObjectType.TRIGGER;
                    break;
                }
                if (parameterType.equals(FunctionEvent.class)) {
                    objectType = ObjectType.FUNCTION;
                    break;
                }
                if (parameterType.equals(FunctionEvalContext.class)) {
                    objectType = ObjectType.FUNCTION;
                    break;
                }
                if (EntityEvent.class.isAssignableFrom(parameterType)) {
                    objectType = ObjectType.ENTITY;
                    break;
                }
            }
        }

        if (PlatformUtils.isUndefinedEnumValue(ObjectType.class, objectType)) {
            if (PlatformUtils.isUndefinedEnumValue(ObjectType.class, objectType)) {
                throw new UPAException("UnableToResoleObjectType for "+methodCallback);
            }
        }
        switch (objectType) {
            case ENTITY: {
                InvokeArgument[] methodArguments = createArguments(method);
                switch (callbackType) {
                    case ON_PERSIST: {
                        InvokeArgument[] apiArguments = new InvokeArgument[]{
                                new PosInvokeArgument("event", PersistEvent.class, 0, false)
                        };
                        InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                        return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                method,
                                methodArguments,
                                apiArguments,
                                implicitArguments
                        ), configuration);
                    }
                    case ON_UPDATE: {
                        boolean obj = false;
                        boolean formula = false;
                        boolean found = false;
                        for (Class<?> parameterType : method.getParameterTypes()) {
                            if (parameterType.equals(UpdateObjectEvent.class)) {
                                if (found) {
                                    throw new UPAIllegalArgumentException("Ambiguous");
                                }
                                found = true;
                                obj = true;
                                formula = false;
                            }
                            if (parameterType.equals(UpdateFormulaObjectEvent.class)) {
                                if (found) {
                                    throw new UPAIllegalArgumentException("Ambiguous");
                                }
                                found = true;
                                obj = true;
                                formula = true;
                            }
                            if (parameterType.equals(UpdateEvent.class)) {
                                if (found) {
                                    throw new UPAIllegalArgumentException("Ambiguous");
                                }
                                found = true;
                                obj = false;
                                formula = false;
                            }
                            if (parameterType.equals(UpdateFormulaEvent.class)) {
                                if (found) {
                                    throw new UPAIllegalArgumentException("Ambiguous");
                                }
                                found = true;
                                obj = false;
                                formula = true;
                            }
                        }
                        if (obj) {
                            if (formula) {
                                InvokeArgument[] apiArguments = new InvokeArgument[]{
                                        new PosInvokeArgument("event", UpdateFormulaObjectEvent.class, 0, false)
                                };
                                InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                                return new UpdateFormulaObjectEventCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                        method,
                                        methodArguments,
                                        apiArguments,
                                        implicitArguments
                                ), configuration);
                            } else {
                                InvokeArgument[] apiArguments = new InvokeArgument[]{
                                        new PosInvokeArgument("event", UpdateObjectEvent.class, 0, false)
                                };
                                InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                                return new UpdateObjectEventCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                        method,
                                        methodArguments,
                                        apiArguments,
                                        implicitArguments
                                ), configuration);
                            }
                        } else if (formula) {
                            InvokeArgument[] apiArguments = new InvokeArgument[]{
                                    new PosInvokeArgument("event", UpdateFormulaEvent.class, 0, false)
                            };
                            InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                            return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                    method,
                                    methodArguments,
                                    apiArguments,
                                    implicitArguments
                            ), configuration);
                        } else {
                            InvokeArgument[] apiArguments = new InvokeArgument[]{
                                    new PosInvokeArgument("event", UpdateEvent.class, 0, false)
                            };
                            InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                            return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                    method,
                                    methodArguments,
                                    apiArguments,
                                    implicitArguments
                            ), configuration);
                        }
                    }
                    case ON_REMOVE: {
                        boolean obj = false;
                        boolean found = false;
                        for (Class<?> parameterType : method.getParameterTypes()) {
                            if (parameterType.equals(RemoveObjectEvent.class)) {
                                if (found) {
                                    throw new UPAIllegalArgumentException("Ambiguous");
                                }
                                found = true;
                                obj = true;
                            }
                            if (parameterType.equals(RemoveEvent.class)) {
                                if (found) {
                                    throw new UPAIllegalArgumentException("Ambiguous");
                                }
                                found = true;
                                obj = false;
                            }
                        }
                        if (obj) {
                            InvokeArgument[] apiArguments = new InvokeArgument[]{
                                    new PosInvokeArgument("event", RemoveObjectEvent.class, 0, false)
                            };
                            InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                            return new RemoveObjectEventCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                    method,
                                    methodArguments,
                                    apiArguments,
                                    implicitArguments
                            ), configuration);
                        } else {
                            InvokeArgument[] apiArguments = new InvokeArgument[]{
                                    new PosInvokeArgument("event", RemoveEvent.class, 0, false)
                            };
                            InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                            return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                    method,
                                    methodArguments,
                                    apiArguments,
                                    implicitArguments
                            ), configuration);
                        }
                    }
                    case ON_RESET:
                    case ON_CLEAR:
                    case ON_INIT:
                    case ON_PREPARE: {
                        InvokeArgument[] apiArguments = new InvokeArgument[]{
                                new PosInvokeArgument("event", EntityEvent.class, 0, false)
                        };
                        InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                        return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                method,
                                methodArguments,
                                apiArguments,
                                implicitArguments
                        ), configuration);
                    }
                    case ON_CREATE: {
                        InvokeArgument[] apiArguments = new InvokeArgument[]{
                                new PosInvokeArgument("event", EntityEvent.class, 0, false)
                        };
                        InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                        return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                method,
                                methodArguments,
                                apiArguments,
                                implicitArguments
                        ), configuration);
                    }
                    case ON_DROP: {
                        InvokeArgument[] apiArguments = new InvokeArgument[]{
                                new PosInvokeArgument("event", EntityEvent.class, 0, false)
                        };
                        InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                        return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                method,
                                methodArguments,
                                apiArguments,
                                implicitArguments
                        ), configuration);
                    }
                    case ON_ALTER: {
                        InvokeArgument[] apiArguments = new InvokeArgument[]{
                                new PosInvokeArgument("event", EntityEvent.class, 0, false)
                        };
                        InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                        return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                method,
                                methodArguments,
                                apiArguments,
                                implicitArguments
                        ), configuration);
                    }
                    case ON_MOVE: {
                        InvokeArgument[] apiArguments = new InvokeArgument[]{
                                new PosInvokeArgument("event", EntityEvent.class, 0, false)
                        };
                        InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                        return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                method,
                                methodArguments,
                                apiArguments,
                                implicitArguments
                        ), configuration);
                    }
                    case ON_UPDATE_FORMULAS: {
                        InvokeArgument[] apiArguments = new InvokeArgument[]{
                                new PosInvokeArgument("event", UpdateFormulaEvent.class, 0, false)
                        };
                        InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                        return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                method,
                                methodArguments,
                                apiArguments,
                                implicitArguments
                        ), configuration);
                    }
                    default: {
                        throw new UPAException("Unsupported", "EntityCallback", callbackType);
                    }
                }
            }
            case FIELD: {
                InvokeArgument[] methodArguments = createArguments(method);
                switch (callbackType) {
                    case ON_CREATE: {
                        InvokeArgument[] apiArguments = new InvokeArgument[]{
                                new PosInvokeArgument("event", FieldEvent.class, 0, false)
                        };
                        InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                        return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                method,
                                methodArguments,
                                apiArguments,
                                implicitArguments
                        ), configuration);
                    }
                    case ON_DROP: {
                        InvokeArgument[] apiArguments = new InvokeArgument[]{
                                new PosInvokeArgument("event", FieldEvent.class, 0, false)
                        };
                        InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                        return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                method,
                                methodArguments,
                                apiArguments,
                                implicitArguments
                        ), configuration);
                    }
                    case ON_MOVE: {
                        InvokeArgument[] apiArguments = new InvokeArgument[]{
                                new PosInvokeArgument("event", FieldEvent.class, 0, false)
                        };
                        InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                        return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                method,
                                methodArguments,
                                apiArguments,
                                implicitArguments
                        ), configuration);
                    }
                    case ON_ALTER: {
                        InvokeArgument[] apiArguments = new InvokeArgument[]{
                                new PosInvokeArgument("event", FieldEvent.class, 0, false)
                        };
                        InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                        return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                method,
                                methodArguments,
                                apiArguments,
                                implicitArguments
                        ), configuration);
                    }
                    default: {
                        throw new UPAException("Unsupported", "EntityCallback", callbackType);
                    }
                }
            }
            case SECTION: {
                InvokeArgument[] methodArguments = createArguments(method);
                switch (callbackType) {
                    case ON_CREATE: {
                        InvokeArgument[] apiArguments = new InvokeArgument[]{
                                new PosInvokeArgument("event", SectionEvent.class, 0, false)
                        };
                        InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                        return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                method,
                                methodArguments,
                                apiArguments,
                                implicitArguments
                        ), configuration);
                    }
                    case ON_DROP: {
                        InvokeArgument[] apiArguments = new InvokeArgument[]{
                                new PosInvokeArgument("event", SectionEvent.class, 0, false)
                        };
                        InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                        return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                method,
                                methodArguments,
                                apiArguments,
                                implicitArguments
                        ), configuration);
                    }
                    case ON_MOVE: {
                        InvokeArgument[] apiArguments = new InvokeArgument[]{
                                new PosInvokeArgument("event", SectionEvent.class, 0, false)
                        };
                        InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                        return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                method,
                                methodArguments,
                                apiArguments,
                                implicitArguments
                        ), configuration);
                    }
                    case ON_ALTER: {
                        InvokeArgument[] apiArguments = new InvokeArgument[]{
                                new PosInvokeArgument("event", SectionEvent.class, 0, false)
                        };
                        InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                        return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                method,
                                methodArguments,
                                apiArguments,
                                implicitArguments
                        ), configuration);
                    }
                    default: {
                        throw new UPAException("Unsupported", "FieldCallback", callbackType);
                    }
                }
            }
            case PACKAGE: {
                InvokeArgument[] methodArguments = createArguments(method);
                switch (callbackType) {
                    case ON_CREATE: {
                        InvokeArgument[] apiArguments = new InvokeArgument[]{
                                new PosInvokeArgument("event", PackageEvent.class, 0, false)
                        };
                        InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                        return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                method,
                                methodArguments,
                                apiArguments,
                                implicitArguments
                        ), configuration);
                    }
                    case ON_DROP: {
                        InvokeArgument[] apiArguments = new InvokeArgument[]{
                                new PosInvokeArgument("event", PackageEvent.class, 0, false)
                        };
                        InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                        return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                method,
                                methodArguments,
                                apiArguments,
                                implicitArguments
                        ), configuration);
                    }
                    case ON_MOVE: {
                        InvokeArgument[] apiArguments = new InvokeArgument[]{
                                new PosInvokeArgument("event", PackageEvent.class, 0, false)
                        };
                        InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                        return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                method,
                                methodArguments,
                                apiArguments,
                                implicitArguments
                        ), configuration);
                    }
                    case ON_ALTER: {
                        InvokeArgument[] apiArguments = new InvokeArgument[]{
                                new PosInvokeArgument("event", PackageEvent.class, 0, false)
                        };
                        InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                        return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                method,
                                methodArguments,
                                apiArguments,
                                implicitArguments
                        ), configuration);
                    }
                    default: {
                        throw new UPAException("Unsupported", "PackageCallback", callbackType);
                    }
                }
            }
            case PERSISTENCE_GROUP: {
                InvokeArgument[] methodArguments = createArguments(method);
                switch (callbackType) {
                    case ON_CREATE: {
                        InvokeArgument[] apiArguments = new InvokeArgument[]{
                                new PosInvokeArgument("event", PersistenceGroupEvent.class, 0, false)
                        };
                        InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                        return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                method,
                                methodArguments,
                                apiArguments,
                                implicitArguments
                        ), configuration);
                    }
                    case ON_DROP: {
                        InvokeArgument[] apiArguments = new InvokeArgument[]{
                                new PosInvokeArgument("event", PersistenceGroupEvent.class, 0, false)
                        };
                        InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                        return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                method,
                                methodArguments,
                                apiArguments,
                                implicitArguments
                        ), configuration);
                    }
                    case ON_MOVE: {
                        InvokeArgument[] apiArguments = new InvokeArgument[]{
                                new PosInvokeArgument("event", PersistenceGroupEvent.class, 0, false)
                        };
                        InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                        return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                method,
                                methodArguments,
                                apiArguments,
                                implicitArguments
                        ), configuration);
                    }
                    case ON_ALTER: {
                        InvokeArgument[] apiArguments = new InvokeArgument[]{
                                new PosInvokeArgument("event", PersistenceGroupEvent.class, 0, false)
                        };
                        InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                        return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                method,
                                methodArguments,
                                apiArguments,
                                implicitArguments
                        ), configuration);
                    }
                    default: {
                        throw new UPAException("Unsupported", "PErsistenceGroupCallback", callbackType);
                    }
                }
            }
            case PERSISTENCE_UNIT: {
                InvokeArgument[] methodArguments = createArguments(method);
                switch (callbackType) {
                    case ON_CREATE: {
                        InvokeArgument[] apiArguments = new InvokeArgument[]{
                                new PosInvokeArgument("event", PersistenceUnitEvent.class, 0, false)
                        };
                        InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                        return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                method,
                                methodArguments,
                                apiArguments,
                                implicitArguments
                        ), configuration);
                    }
                    case ON_DROP: {
                        InvokeArgument[] apiArguments = new InvokeArgument[]{
                                new PosInvokeArgument("event", PersistenceUnitEvent.class, 0, false)
                        };
                        InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                        return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                method,
                                methodArguments,
                                apiArguments,
                                implicitArguments
                        ), configuration);
                    }
                    case ON_ALTER: {
                        InvokeArgument[] apiArguments = new InvokeArgument[]{
                                new PosInvokeArgument("event", PersistenceUnitEvent.class, 0, false)
                        };
                        InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                        return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                method,
                                methodArguments,
                                apiArguments,
                                implicitArguments
                        ), configuration);
                    }
                    case ON_START: {
                        InvokeArgument[] apiArguments = new InvokeArgument[]{
                                new PosInvokeArgument("event", PersistenceUnitEvent.class, 0, false)
                        };
                        InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                        return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                method,
                                methodArguments,
                                apiArguments,
                                implicitArguments
                        ), configuration);
                    }
                    case ON_UPDATE_FORMULAS: {
                        InvokeArgument[] apiArguments = new InvokeArgument[]{
                                new PosInvokeArgument("event", PersistenceUnitEvent.class, 0, false)
                        };
                        InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                        return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                method,
                                methodArguments,
                                apiArguments,
                                implicitArguments
                        ), configuration);
                    }
                    default: {
                        throw new UPAException("Unsupported", "PersistenceUnitCallback", callbackType);
                    }
                }
            }
            case TRIGGER: {
                InvokeArgument[] methodArguments = createArguments(method);
                switch (callbackType) {
                    case ON_CREATE: {
                        InvokeArgument[] apiArguments = new InvokeArgument[]{
                                new PosInvokeArgument("event", TriggerEvent.class, 0, false)
                        };
                        InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                        return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                method,
                                methodArguments,
                                apiArguments,
                                implicitArguments
                        ), configuration);
                    }
                    case ON_DROP: {
                        InvokeArgument[] apiArguments = new InvokeArgument[]{
                                new PosInvokeArgument("event", TriggerEvent.class, 0, false)
                        };
                        InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                        return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                method,
                                methodArguments,
                                apiArguments,
                                implicitArguments
                        ), configuration);
                    }
                    default: {
                        throw new UPAException("Unsupported", "TriggerCallback", callbackType);
                    }
                }
            }
            case FUNCTION: {
                InvokeArgument[] methodArguments = createArguments(method);
                switch (callbackType) {
                    case ON_CREATE: {
                        InvokeArgument[] apiArguments = new InvokeArgument[]{
                                new PosInvokeArgument("event", FunctionEvent.class, 0, false)
                        };
                        InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                        return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                method,
                                methodArguments,
                                apiArguments,
                                implicitArguments
                        ), configuration);
                    }
                    case ON_DROP: {
                        InvokeArgument[] apiArguments = new InvokeArgument[]{
                                new PosInvokeArgument("event", FunctionEvent.class, 0, false)
                        };
                        InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                        return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                method,
                                methodArguments,
                                apiArguments,
                                implicitArguments
                        ), configuration);
                    }
                    case ON_EVAL_FUNCTION: {
                        InvokeArgument[] apiArguments = new InvokeArgument[]{
                                new PosInvokeArgument("evalContext", FunctionEvalContext.class, 0, false)
                        };
                        InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                        Map<String, Object> configuration2 = new HashMap<String, Object>();
                        if (configuration != null) {
                            configuration2.putAll(configuration);
                        }
                        if (!configuration2.containsKey("functionName")) {
                            configuration2.put("functionName", method.getName());
                        }
                        if (!configuration2.containsKey("returnType")) {
                            DataType forNativeType = TypesFactory.forPlatformType(method.getReturnType());
                            configuration2.put("returnType", forNativeType);
                        }
                        return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                method,
                                methodArguments,
                                apiArguments,
                                implicitArguments
                        ), configuration2);
                    }
                    default: {
                        throw new UPAException("Unsupported", "FunctionCallback", callbackType);
                    }
                }
            }
            case FORMULA: {
                InvokeArgument[] methodArguments = createArguments(method);
                switch (callbackType) {
                    case ON_CREATE: {
                        InvokeArgument[] apiArguments = new InvokeArgument[]{
                                new PosInvokeArgument("event", NamedFormulaEvent.class, 0, false)
                        };
                        InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                        return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                method,
                                methodArguments,
                                apiArguments,
                                implicitArguments
                        ), configuration);
                    }
                    case ON_DROP: {
                        InvokeArgument[] apiArguments = new InvokeArgument[]{
                                new PosInvokeArgument("event", NamedFormulaEvent.class, 0, false)
                        };
                        InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                        return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                method,
                                methodArguments,
                                apiArguments,
                                implicitArguments
                        ), configuration);
                    }
                    case ON_EVAL_FORMULA: {
                        if (method.getParameterTypes().length != 1) {
                            throw new UPAException("InvalidNamedFormulaMethod", method);
                        }
                        Class type = null;
                        if (method.getParameterTypes()[0].equals(CustomFormulaContext.class) || method.getParameterTypes()[0].equals(CustomMultiFormulaContext.class)) {
                            type = method.getParameterTypes()[0];
                        } else {
                            throw new UPAException("InvalidNamedFormulaMethod", method, "ExpectedTypes{" + CustomFormulaContext.class.getName() + "," + CustomMultiFormulaContext.class.getName() + "}");
                        }
                        InvokeArgument[] apiArguments = new InvokeArgument[]{
                                new PosInvokeArgument("evalContext", type, 0, false)
                        };
                        InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                        Map<String, Object> configuration2 = new HashMap<String, Object>();
                        if (configuration != null) {
                            configuration2.putAll(configuration);
                        }
                        if (!configuration2.containsKey("formulaName")) {
                            configuration2.put("formulaName", method.getName());
                        }
                        if(type.equals(CustomFormulaContext.class)) {
                            configuration2.put("formulaType", CustomFormula.class);
                        }else if(type.equals(CustomMultiFormulaContext.class)){
                            configuration2.put("formulaType", CustomMultiFormula.class);
                        }else{
                            throw new UPAException("InvalidFormulaType",type,"<>{"+CustomFormulaContext.class.getSimpleName()+","+CustomMultiFormulaContext.class.getSimpleName()+"}");
                        }
                        return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                method,
                                methodArguments,
                                apiArguments,
                                implicitArguments
                        ), configuration2);
                    }
                    default: {
                        throw new UPAException("Unsupported", "FunctionCallback", callbackType);
                    }
                }
            }
            case CONTEXT: {
                InvokeArgument[] methodArguments = createArguments(method);
                switch (callbackType) {
                    case ON_CLOSE: {
                        InvokeArgument[] apiArguments = new InvokeArgument[]{
                                new PosInvokeArgument("event", ContextEvent.class, 0, false)
                        };
                        InvokeArgument[] implicitArguments = new InvokeArgument[]{};
                        return new DefaultCallback(instance, method, callbackType, phase, objectType, DefaultMethodArgumentsConverter.create(
                                method,
                                methodArguments,
                                apiArguments,
                                implicitArguments
                        ), configuration);
                    }
                    default: {
                        throw new UPAException("Unsupported", "ContextCallback", callbackType);
                    }
                }
            }

        }
        throw new UPAException("UnsupportedCallback", objectType, callbackType);
    }

    /**
     * @InheritDoc
     */
    @Override
    public Callback addCallback(MethodCallback methodCallback) {
        Callback c = createCallback(methodCallback);
        addCallback(c);
        return c;
    }

    /**
     * @InheritDoc
     */
    @Override
    public void addCallback(Callback callback) {
        if (callback.getCallbackType() == CallbackType.ON_EVAL_FUNCTION) {
            throw new UPAException("Unsupported", callback.getCallbackType());
        }
        listeners.addCallback(callback);
    }

    /**
     * @InheritDoc
     */
    @Override
    public void removeCallback(Callback callback) {
        listeners.removeCallback(callback);
    }

    /**
     * @InheritDoc
     */
    @Override
    public Callback[] getCallbacks(CallbackType callbackType, ObjectType objectType, String nameFilter, boolean system, boolean preparedOnly, EventPhase phase) {
        List<Callback> callbacks = listeners.getCallbacks(callbackType, objectType, nameFilter, system, preparedOnly, phase);
        return callbacks.toArray(new Callback[callbacks.size()]);
    }

    /**
     * @InheritDoc
     */
    @Override
    public Properties getThreadProperties() {
        Properties properties = threadProperties.get();
        if (properties == null) {
            properties = getFactory().createObject(Properties.class);
            threadProperties.set(properties);
        }
        return properties;
    }

    /**
     * @InheritDoc
     */
    @Override
    public PersistenceContextInfo getInfo() {
        PersistenceContextInfo i = new PersistenceContextInfo();
        List<PersistenceGroupInfo> list = new ArrayList<>();
        for (PersistenceGroup persistenceGroup : getPersistenceGroups()) {
            list.add(persistenceGroup.getInfo());
        }
        i.setGroups(list);
        return i;
    }
}
