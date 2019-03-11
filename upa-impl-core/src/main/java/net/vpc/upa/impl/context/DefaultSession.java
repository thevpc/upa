package net.vpc.upa.impl.context;

import net.vpc.upa.PersistenceGroup;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.Session;
import net.vpc.upa.SessionContext;
import net.vpc.upa.events.SessionListener;

import java.util.ArrayList;
import java.util.List;
import java.util.Stack;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/12/12 1:21 AM
 */
public class DefaultSession implements Session {

    protected static final Logger log = Logger.getLogger(DefaultSession.class.getName());
    private Stack<SessionContext> stack = new Stack<SessionContext>();
    private List<SessionListener> sessionListeners = new ArrayList<SessionListener>();

    public DefaultSession() {
        pushContext();
    }

    public SessionContext getCurrentContext() {
        return stack.peek();
    }

    @Override
    public void pushContext() {
        stack.push(new DefaultSessionContext());
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
        stack.pop();
//        log.log(Level.FINE,"Session {} : Context Popped", new Object[]{this});
    }

    @Override
    public void setParam(PersistenceUnit persistenceUnit, String name, Object value) {
        getCurrentContext().setParam(persistenceUnit, name, value);
    }

    public <T> T getImmediateParam(PersistenceUnit persistenceUnit, Class<T> type, String name, T defaultValue) {
        SessionContext m = stack.peek();
        if (m.containsParam(persistenceUnit, name)) {
            return m.getParam(persistenceUnit, type, name, defaultValue);
        }
        return defaultValue;
    }

    @Override
    public <T> T getParam(PersistenceUnit persistenceUnit, Class<T> type, String name, T defaultValue) {
        SessionContext[] v = stack.toArray(new SessionContext[0]);
        for (int i = v.length - 1; i >= 0; i--) {
            SessionContext m = v[i];
            if (m.containsParam(persistenceUnit, name)) {
                return m.getParam(persistenceUnit, type, name, defaultValue);
            }
        }
        return defaultValue;
    }

    @Override
    public void close() {
        while (!stack.isEmpty()) {
            popContext();
        }
        if (!sessionListeners.isEmpty()) {
            for (SessionListener sessionListener : new ArrayList<SessionListener>(sessionListeners)) {
                sessionListener.closeSession(this);
            }
        }
        log.log(Level.FINE, "Session [{0}] : Closed", this);
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
