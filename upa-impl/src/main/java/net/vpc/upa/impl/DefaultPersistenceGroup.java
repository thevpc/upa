package net.vpc.upa.impl;

import net.vpc.upa.*;
import net.vpc.upa.callbacks.PersistenceUnitDefinitionListener;
import net.vpc.upa.callbacks.PersistenceUnitEvent;
import net.vpc.upa.config.ScanFilter;
import net.vpc.upa.config.ScanSource;
import net.vpc.upa.exceptions.*;
import net.vpc.upa.impl.config.ConfigureScanListener;
import net.vpc.upa.impl.config.URLAnnotationStrategySupport;
import net.vpc.upa.impl.config.decorations.DecorationRepository;
import net.vpc.upa.impl.config.decorations.DefaultDecorationRepository;
import net.vpc.upa.impl.event.PersistenceGroupListenerManager;

import java.util.*;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/11/12 9:47 PM
 */
public class DefaultPersistenceGroup implements PersistenceGroup {

    protected static final Logger log = Logger.getLogger(DefaultPersistenceGroup.class.getName());
    private UPAContext context;
    private ObjectFactory factory;
    private final LinkedHashMap<String, PersistenceUnit> persistenceUnits = new LinkedHashMap<String, PersistenceUnit>();
    private final List<Session> sessions = new ArrayList<Session>();
    private SessionContextProvider sessionContextProvider;
    private PersistenceUnitProvider persistenceUnitProvider;
    private String name;
    private boolean closed;
    private boolean autoScan = true;
//    private List<PersistenceUnitDefinitionListener> persistenceUnitDefinitionListeners;
    private final List<ScanFilter> filters = new ArrayList<ScanFilter>();
    private DecorationRepository decorationRepository;
    private UPASecurityManager securityManager;
    private PersistenceGroupSecurityManager persistenceGroupSecurityManager;
    private PersistenceGroupListenerManager listeners;

    public DefaultPersistenceGroup() {
        listeners = new PersistenceGroupListenerManager(this);
    }

    @Override
    public void scan(ScanSource strategy, ScanListener listener, boolean configure) throws UPAException {
        decorationRepository = new DefaultDecorationRepository(getName() + "-PGRepo", true);
        log.log(Level.FINE, "{0} : Configuring PersistenceGroup with strategy {1}", new Object[]{getName(), strategy});
        URLAnnotationStrategySupport s = new URLAnnotationStrategySupport();
        s.scan(this, strategy, decorationRepository, configure ? new ConfigureScanListener(listener) : listener);
        if (securityManager == null) {
            securityManager = getFactory().createObject(UPASecurityManager.class);
        }
    }

    public boolean isAutoScan() {
        return autoScan;
    }

    public void setAutoScan(boolean autoScan) {
        this.autoScan = autoScan;
    }

    public String getName() {
        return name;
    }

    public void setContext(UPAContext context) {
        this.context = context;
    }

    public void setFactory(ObjectFactory factory) {
        this.factory = factory;
    }

    public void setName(String name) {
        this.name = name;
    }

    public UPAContext getContext() {
        return context;
    }

    protected SessionContextProvider getSessionContextProvider() {
        if (sessionContextProvider == null) {
            sessionContextProvider = getFactory().createObject(SessionContextProvider.class);
        }
        return sessionContextProvider;
    }

    protected PersistenceUnitProvider getPersistenceUnitProvider() {
        if (persistenceUnitProvider == null) {
            persistenceUnitProvider = getFactory().createObject(PersistenceUnitProvider.class);
        }
        return persistenceUnitProvider;
    }

    @Override
    public PersistenceUnit getPersistenceUnit() throws UPAException {
        PersistenceUnit persistenceUnit = getPersistenceUnitProvider().getPersistenceUnit(this);
        if (persistenceUnit == null) {
            List<PersistenceUnit> persistenceUnitsCurr = getPersistenceUnits();
            if (persistenceUnitsCurr.size() > 0) {
                for (PersistenceUnit s : persistenceUnitsCurr) {
                    persistenceUnit = s;
                    break;
                }
                getPersistenceUnitProvider().setPersistenceUnit(this, persistenceUnit);
            } else {
                throw new MissingDefaultPersistenceUnitException();
            }
        }
        return persistenceUnit;
    }

    @Override
    public void setPersistenceUnit(String name) throws UPAException {
        PersistenceUnit newPU = getPersistenceUnit(name);
        PersistenceUnit oldPU = getPersistenceUnitProvider().getPersistenceUnit(this);
        if (oldPU != newPU) {
            getPersistenceUnitProvider().setPersistenceUnit(this, getPersistenceUnit(name));
            //TODO fire event
        }
    }

    @Override
    public List<PersistenceUnit> getPersistenceUnits() throws UPAException {
        synchronized (persistenceUnits) {
            return new ArrayList<PersistenceUnit>(persistenceUnits.values());
        }
    }

    @Override
    public PersistenceUnit getPersistenceUnit(String name) throws UPAException {
        synchronized (persistenceUnits) {
            PersistenceUnit persistenceUnit = persistenceUnits.get(name);
            if (persistenceUnit == null) {
                throw new NoSuchPersistenceUnitException(name);
            }
            return persistenceUnit;
        }
    }

    @Override
    public ObjectFactory getFactory() {
        return factory;
    }

    @Override
    public boolean containsPersistenceUnit(String name) throws UPAException {
        if (name == null) {
            name = "";
        }
        synchronized (persistenceUnits) {
            return persistenceUnits.containsKey(name);
        }
    }

    @Override
    public PersistenceUnit addPersistenceUnit(String name) throws UPAException {
        if (name == null) {
            name = "";
        }
        PersistenceUnit persistenceUnit = getFactory().createObject(PersistenceUnit.class);
//        persistenceUnit.setName(name);
//        persistenceUnit.setPersistenceGroup(this);
        persistenceUnit.init(name, this);
        synchronized (persistenceUnits) {
            if (persistenceUnits.containsKey(name)) {
                throw new PersistenceUnitAlreadyExistsException(name);
            }
            listeners.fireOnCreatePersistenceUnit(new PersistenceUnitEvent(persistenceUnit, this,EventPhase.BEFORE));

            persistenceUnits.put(name, persistenceUnit);

            PersistenceUnit oldPersistenceUnit = getPersistenceUnitProvider().getPersistenceUnit(this);
            if (oldPersistenceUnit == null) {
                setPersistenceUnit(persistenceUnit.getName());
            }
            listeners.fireOnCreatePersistenceUnit(new PersistenceUnitEvent(persistenceUnit, this,EventPhase.AFTER));
        }
        log.log(Level.FINE, "Create PersistenceUnit {0}/{1}", new Object[]{getName(), persistenceUnit.getName()});
        return persistenceUnit;
    }

    @Override
    public void dropPersistenceUnit(String name) throws UPAException {
        if (name == null) {
            name = "";
        }
        synchronized (persistenceUnits) {
            if (!persistenceUnits.containsKey(name)) {
                throw new NoSuchPersistenceUnitException(name);
            }
            PersistenceUnit persistenceUnit = persistenceUnits.get(name);
            if (!persistenceUnit.isClosed()) {
                persistenceUnit.close();
            }
            listeners.fireOnDropPersistenceUnit(new PersistenceUnitEvent(persistenceUnit, this,EventPhase.BEFORE));

            persistenceUnits.remove(name);

            listeners.fireOnDropPersistenceUnit(new PersistenceUnitEvent(persistenceUnit, this,EventPhase.AFTER));
        }

    }

    private void checkManagedSession(Session session) {
        //
    }

    @Override
    public boolean currentSessionExists() {
        return getSessionContextProvider().getSession(this) != null;
    }

    @Override
    public Session getCurrentSession() throws UPAException {
        Session session = getSessionContextProvider().getSession(this);
        if (session == null) {
            throw new CurrentSessionNotFoundException();
        }
        return session;
    }

    public void setCurrentSession(Session session) throws UPAException {
        synchronized (sessions) {
            if (!sessions.contains(session)) {
                throw new NoSuchElementException("Session not found");
            }
        }
        checkManagedSession(session);
        log.log(Level.FINE, "Session Changed {0} for PersistenceGroup {1}", new Object[]{session, getName()});
        getSessionContextProvider().setSession(this, session);
    }

    @Override
    public Session openSession() throws UPAException {
        Session session = getFactory().createObject(Session.class, null);
        session.init(this);
        synchronized (sessions) {
            sessions.add(session);
            setCurrentSession(session);
            session.addSessionListener(new CloseSessionListener(this));
        }
        return session;
    }

    protected void onSessionClosed(Session session) {
        synchronized (sessions) {
            sessions.remove(session);
            getSessionContextProvider().setSession(this, null);
        }
    }

    @Override
    public String toString() {
        return String.valueOf(name);
    }

    @Override
    public void close() throws UPAException {
        log.log(Level.FINE, "PersistenceGroup {0} Closing", getName());
        synchronized (sessions) {
            for (Session next : sessions) {
                next.close();
            }
            sessions.clear();
        }
        synchronized (persistenceUnits) {
            for (PersistenceUnit persistenceUnit : persistenceUnits.values()) {
                persistenceUnit.close();
            }
            persistenceUnits.clear();
        }
        closed = true;
        log.log(Level.FINE, "PersistenceGroup {0} Closed", getName());
    }

    @Override
    public void addPersistenceUnitDefinitionListener(PersistenceUnitDefinitionListener definitionListener) {
        listeners.addPersistenceUnitDefinitionListener(definitionListener);
    }

    @Override
    public void removePersistenceUnitDefinitionListener(PersistenceUnitDefinitionListener definitionListener) {
        listeners.removePersistenceUnitDefinitionListener(definitionListener);
    }

    public void addContextAnnotationStrategyFilter(ScanFilter filter) {
        filters.add(filter);
    }

    public void removeContextAnnotationStrategyFilter(ScanFilter filter) {
        filters.remove(filter);
    }

    public ScanFilter[] getContextAnnotationStrategyFilters() {
        return filters.toArray(new ScanFilter[filters.size()]);
    }

    @Override
    public boolean isClosed() throws UPAException {
        return closed;
    }

    public UPASecurityManager getSecurityManager() {
        return securityManager;
    }

    public void setSecurityManager(UPASecurityManager securityManager) {
        this.securityManager = securityManager;
    }

    public PersistenceGroupSecurityManager getPersistenceGroupSecurityManager() {
        return persistenceGroupSecurityManager;
    }

    public void setPersistenceGroupSecurityManager(PersistenceGroupSecurityManager persistenceGroupSecurityManager) {
        this.persistenceGroupSecurityManager = persistenceGroupSecurityManager;
    }

    public void addCallback(Callback callback) {
        if (callback.getCallbackType() == CallbackType.ON_EVAL) {
            throw new UPAException("Unsupported", callback.getCallbackType());
        }
        listeners.addCallback(callback);
    }

    public void removeCallback(Callback callback) {
        listeners.removeCallback(callback);
    }

    public Callback[] getCallbacks(CallbackType nameFilter, ObjectType objectType, String name, boolean system, EventPhase phase) {
        List<Callback> callbackInvokers = listeners.getCallbacks(nameFilter, objectType, name, system, phase);
        return callbackInvokers.toArray(new Callback[callbackInvokers.size()]);
    }
}
