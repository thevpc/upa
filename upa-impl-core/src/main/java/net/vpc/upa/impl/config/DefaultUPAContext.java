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

    @Override
    public <T> T makeSessionAware(final T instance, final MethodFilter methodFilter) throws UPAException {
        return (T) PlatformUtils.createObjectInterceptor(
                instance.getClass(),
                new MakeSessionAwareMethodInterceptor(this, methodFilter, instance));
    }

    @Override
    public <T> T makeSessionAware(final T instance) throws UPAException {
        return makeSessionAware(instance, (MethodFilter) null);
    }

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
        scan(contextConfig, getFactory().createContextScanSource("UPAContext", false), null, true);
        for (PersistenceGroup g : getPersistenceGroups()) {
            for (PersistenceUnit u : g.getPersistenceUnits()) {
                if (!u.isStarted() && u.isAutoStart()) {
                    u.start();
                }
            }
        }
    }

    @Override
    public void scan(UPAContextConfig contextConfig, ScanSource configurationStrategy, ScanListener listener, boolean configure) {
        URLAnnotationStrategySupport support = new URLAnnotationStrategySupport();
        support.scan(this, contextConfig, configurationStrategy, decorationRepository, configure ? new ConfigureScanListener(listener) : listener);
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
            throw new UPAIllegalArgumentException("PersistenceGroup " + name + " already exists");
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

    @Override
    public void removePersistenceGroup(String name) throws UPAException {
        PersistenceGroup persistenceGroup = getPersistenceGroup(name);

        PersistenceGroupEvent event = new PersistenceGroupEvent(persistenceGroup, this);
        listeners.fireOnDropPersistenceGroup(event, EventPhase.BEFORE);
        if (persistenceGroup.isClosed()) {
            persistenceGroup.close();
        }
        persistenceGroups.remove(name);
        listeners.fireOnDropPersistenceGroup(event, EventPhase.AFTER);
    }

    @Override
    public void addPersistenceGroupDefinitionListener(PersistenceGroupDefinitionListener persistenceGroupDefinitionListener) throws UPAException {
        listeners.addPersistenceGroupDefinitionListener(persistenceGroupDefinitionListener);
    }

    @Override
    public void removePersistenceGroupDefinitionListener(PersistenceGroupDefinitionListener persistenceGroupDefinitionListener) throws UPAException {
        listeners.removePersistenceGroupDefinitionListener(persistenceGroupDefinitionListener);
    }

    public PersistenceGroupDefinitionListener[] getPersistenceGroupDefinitionListeners() {
        return listeners.getPersistenceGroupDefinitionListeners();
    }

    //    @Override
//    public <T> T makeSessionAware(final T instance) throws UPAException {
//        return makeSessionAware(instance, (MethodFilter) null);
//    }
    @Override
    public <T> T makeSessionAware(final T instance, final Class<Annotation> sessionAwareMethodAnnotation) throws UPAException {
        return makeSessionAware(instance, sessionAwareMethodAnnotation == null ? null : new AnnotationMethodFilter(sessionAwareMethodAnnotation, decorationRepository));
    }

    //    @Override
//    public <T> T makeSessionAware(final T instance, final MethodFilter methodFilter) throws UPAException {
//        return (T) PlatformUtils.createObjectInterceptor(
//                instance.getClass(),
//                new MakeSessionAwareMethodInterceptor(this, methodFilter, instance));
//    }
    @Override
    public <T> T makeSessionAware(final Class<T> type, final MethodFilter methodFilter) throws UPAException {
        return (T) PlatformUtils.createObjectInterceptor(
                type,
                new MakeSessionAwareMethodInterceptor2<T>(methodFilter));
    }

    @Override
    public <T> T invokePrivileged(Action<T> action, InvokeContext invokeContext) throws UPAException {
        return invoke(action, invokeContext, true);
    }

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

    @Override
    public <T> T invoke(Action<T> action) throws UPAException {
        return invoke(action, null);
    }

    @Override
    public <T> T invokePrivileged(Action<T> action) throws UPAException {
        return invokePrivileged(action, null);
    }

    @Override
    public void invoke(VoidAction action, InvokeContext invokeContext) throws UPAException {
        invoke(new VoidActionAdapter(action), invokeContext);
    }

    @Override
    public void invoke(VoidAction action) throws UPAException {
        invoke(new VoidActionAdapter(action));
    }

    @Override
    public void invokePrivileged(VoidAction action, InvokeContext invokeContext) throws UPAException {
        invokePrivileged(new VoidActionAdapter(action), invokeContext);
    }

    @Override
    public void invokePrivileged(VoidAction action) throws UPAException {
        invokePrivileged(new VoidActionAdapter(action));
    }

    public void close() throws UPAException {
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
    }

    public void addCloseListener(CloseListener listener) {
        synchronized (closeListeners) {
            closeListeners.add(listener);
        }
    }

    public void removeCloseListener(CloseListener listener) {
        synchronized (closeListeners) {
            closeListeners.remove(listener);
        }
    }

    public CloseListener[] getCloseListeners() {
        return closeListeners.toArray(new CloseListener[closeListeners.size()]);
    }

    //    public void beginInvocation(Method method, Map<String, Object> properties) {
//        TransactionType transactionType = PlatformUtils.getUndefinedValue(TransactionType.class);
//        Decoration r = decorationRepository.getMethodDecoration(method, Transactional.class.getName());
//        if (r != null) {
//            transactionType = TransactionType.valueOf(r.getString("value"));
//        }
//        if (PlatformUtils.isUndefinedValue(TransactionType.class, transactionType)) {
//            r = decorationRepository.getMethodDecoration(method, "javax.ejb.TransactionAttribute");
//            if (r != null) {
//                try {
//                    transactionType = TransactionType.valueOf(r.getString("value"));
//                } catch (Exception e) {
//                    //not all types are supported, so ignore...
//                }
//            }
//        }
//
//        if (PlatformUtils.isUndefinedValue(TransactionType.class, transactionType)) {
//            r = decorationRepository.getTypeDecoration(method.getDeclaringClass(), Transactional.class);
//            if (r != null) {
//                transactionType = TransactionType.valueOf(r.getString("value"));
//            }
//        }
//        if (PlatformUtils.isUndefinedValue(TransactionType.class, transactionType)) {
//            r = decorationRepository.getTypeDecoration(method.getDeclaringClass(), "javax.ejb.TransactionAttribute");
//            if (r != null) {
//                try {
//                    transactionType = TransactionType.valueOf(r.getString("value"));
//                } catch (Exception e) {
//                    //not all types are supported, so ignore...
//                }
//            }
//        }
//        if (properties == null) {
//            properties = new HashMap<String, Object>();
//        }
//        properties.put(TransactionType.class.getName(),
//                PlatformUtils.isUndefinedValue(TransactionType.class, transactionType)
//                ? TransactionType.REQUIRED : transactionType
//        );
//        beginInvocation(properties);
//    }
//    public void beginInvocation(Map<String, Object> properties) {
//        Session s = null;
//        PersistenceGroup persistenceGroup = getPersistenceGroup();
//        try {
//            s = persistenceGroup.getCurrentSession();
//        } catch (CurrentSessionNotFoundException ignore) {
//            //ignore
//        }
//        boolean sessionCreated = false;
//        if (s == null) {
//            s = persistenceGroup.openSession();
//            sessionCreated = true;
//        }
//        TransactionType transactionType = (TransactionType) properties.get(TransactionType.class.getName());
//        if (PlatformUtils.isUndefinedValue(TransactionType.class, transactionType)) {
//            transactionType = TransactionType.REQUIRED;
//        }
//        boolean transactionCreated = false;
//        PersistenceUnit pu = persistenceGroup.getPersistenceUnit();
//        pu.beginTransaction(transactionType);
//        transactionCreated = true;
//
//        properties.put("sessionCreated", sessionCreated);
//        properties.put("transactionCreated", transactionCreated);
//    }
//    public void endInvocation(Throwable error, Map<String, Object> properties) {
//        PersistenceUnit persistenceUnit = getPersistenceUnit();
//        Boolean sessionCreated = (Boolean) properties.get("sessionCreated");
//        if (sessionCreated == null) {
//            sessionCreated = false;
//        }
//        Boolean transactionCreated = (Boolean) properties.get("transactionCreated");
//        if (transactionCreated == null) {
//            transactionCreated = false;
//        }
//        if (error == null) {
//            persistenceUnit.commitTransaction();
//        } else if (transactionCreated) {
//            try {
//                persistenceUnit.rollbackTransaction();
//            } catch (Throwable e2) {
//                //errors in rollback are ignored but traced
//                log.log(Level.SEVERE, "Invocation Error", error);
//                log.log(Level.SEVERE, "Rollback Error", e2);
//            }
//        }
//        if (sessionCreated) {
//            try {
//                if (sessionCreated) {
//                    getPersistenceGroup().getCurrentSession().close();
//                }
//            } catch (Throwable e) {
//                log.log(Level.SEVERE, "Failed to close session after error", e);
//            }
//        }
//    }
    public void addScanFilter(ScanFilter filter) {
        filters.add(filter);
    }

    public void removeScanFilter(ScanFilter filter) {
        filters.remove(filter);
    }

    public ScanFilter[] getContextAnnotationStrategyFilters() {
        return filters.toArray(new ScanFilter[filters.size()]);
    }

    public Map<String, Object> getProperties() {
        return properties;
    }

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
        if (!PlatformUtils.isUndefinedValue(ObjectType.class, requestedObjectType)) {
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

        if (PlatformUtils.isUndefinedValue(ObjectType.class, objectType)) {
            if (PlatformUtils.isUndefinedValue(ObjectType.class, objectType)) {
                throw new UPAException("UnableToResoleObjectType");
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

    @Override
    public Callback addCallback(MethodCallback methodCallback) {
        Callback c = createCallback(methodCallback);
        addCallback(c);
        return c;
    }

    @Override
    public void addCallback(Callback callback) {
        if (callback.getCallbackType() == CallbackType.ON_EVAL_FUNCTION) {
            throw new UPAException("Unsupported", callback.getCallbackType());
        }
        listeners.addCallback(callback);
    }

    @Override
    public void removeCallback(Callback callback) {
        listeners.removeCallback(callback);
    }

    public Callback[] getCallbacks(CallbackType callbackType, ObjectType objectType, String nameFilter, boolean system, boolean preparedOnly, EventPhase phase) {
        List<Callback> callbacks = listeners.getCallbacks(callbackType, objectType, nameFilter, system, preparedOnly, phase);
        return callbacks.toArray(new Callback[callbacks.size()]);
    }

    public Properties getThreadProperties() {
        Properties properties = threadProperties.get();
        if (properties == null) {
            properties = getFactory().createObject(Properties.class);
            threadProperties.set(properties);
        }
        return properties;
    }

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
