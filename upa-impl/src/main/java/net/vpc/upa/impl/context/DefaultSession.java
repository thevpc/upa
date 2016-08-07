package net.vpc.upa.impl.context;

import net.vpc.upa.PersistenceGroup;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.Session;
import net.vpc.upa.SessionContext;
import net.vpc.upa.callbacks.SessionListener;

import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.impl.SessionParams;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/12/12 1:21 AM
 */
public class DefaultSession implements Session {

    protected static final Logger log = Logger.getLogger(DefaultSession.class.getName());
    private List<SessionContext> stack = new ArrayList<SessionContext>();
    private List<SessionListener> sessionListeners = new ArrayList<SessionListener>();

    public DefaultSession() {
        pushContext();
    }

    public SessionContext getCurrentContext() {
        return stack.get(stack.size() - 1);
    }

    @Override
    public void pushContext() {
        stack.add(new DefaultSessionContext());
        if (sessionListeners.size() > 0) {
            for (SessionListener sessionListener : new ArrayList<SessionListener>(sessionListeners)) {
                sessionListener.pushContext(this);
            }
        }
//        log.log(Level.FINE,"Session {} : Context Pushed", new Object[]{this});
    }

    @Override
    public void popContext() {
        if (sessionListeners.size() > 0) {
            for (SessionListener sessionListener : new ArrayList<SessionListener>(sessionListeners)) {
                sessionListener.popContext(this);
            }
        }
        stack.remove(stack.size() - 1);
//        log.log(Level.FINE,"Session {} : Context Popped", new Object[]{this});
    }

    @Override
    public void setParam(PersistenceUnit persistenceUnit, String name, Object value) {
        getCurrentContext().setParam(persistenceUnit, name, value);
    }

    public <T> T getImmediateParam(PersistenceUnit persistenceUnit, Class<T> type, String name, T defaultValue) {
        List<SessionContext> v = stack;
        SessionContext m = v.get(v.size() - 1);
        if (m.containsParam(persistenceUnit, name)) {
            return m.getParam(persistenceUnit, type, name, defaultValue);
        }
        return defaultValue;
    }

    @Override
    public <T> T getParam(PersistenceUnit persistenceUnit, Class<T> type, String name, T defaultValue) {
        List<SessionContext> v = stack;
        for (int i = v.size() - 1; i >= 0; i--) {
            SessionContext m = v.get(i);
            if (m.containsParam(persistenceUnit, name)) {
                return m.getParam(persistenceUnit, type, name, defaultValue);
            }
        }
        return defaultValue;
    }

    @Override
    public void close() {
        while (stack.size() > 0) {
            popContext();
        }
        if (sessionListeners.size() > 0) {
            for (SessionListener sessionListener : new ArrayList<SessionListener>(sessionListeners)) {
                sessionListener.closeSession(this);
            }
        }
        log.log(Level.FINE, "Session '{'{0}'}' : Closed", this);
    }

    @Override
    public void init(PersistenceGroup manager) {
    }

    @Override
    public void addSessionListener(SessionListener sessionListener) {
        sessionListeners.add(sessionListener);
    }

    @Override
    public void removeSessionListener(SessionListener sessionListener) {
        sessionListeners.remove(sessionListener);
    }

    @Override
    public String toString() {
        return "Session" + Integer.toHexString(System.identityHashCode(this)).toUpperCase();
    }
}
