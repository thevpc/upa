package net.thevpc.upa.impl;

import net.thevpc.upa.PersistenceUnit;
import net.thevpc.upa.PersistenceGroup;
import net.thevpc.upa.Session;
import net.thevpc.upa.SessionContext;
import net.thevpc.upa.events.SessionListener;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/8/13 2:11 AM
 */
class StackedSession implements Session {

    private final Session session;

    public StackedSession(Session session) {
        this.session = session;
    }

    @Override
    public void init(PersistenceGroup manager) {
        session.init(manager);
    }

    @Override
    public void pushContext() {
        session.pushContext();
    }

    @Override
    public void popContext() {
        session.popContext();
    }

    public SessionContext getCurrentContext() {
        return session.getCurrentContext();
    }

    @Override
    public void setParam(PersistenceUnit persistenceUnit, String name, Object value) {
        session.setParam(persistenceUnit, name, value);
    }

    @Override
    public <T> T getParam(PersistenceUnit persistenceUnit, Class<T> type, String name, T defaultValue) {
        return session.getParam(persistenceUnit, type, name, defaultValue);
    }

    public <T> T getImmediateParam(PersistenceUnit persistenceUnit, Class<T> type, String name, T defaultValue) {
        return session.getImmediateParam(persistenceUnit, type, name, defaultValue);
    }

    @Override
    public void addSessionListener(SessionListener sessionListener) {
        session.addSessionListener(sessionListener);
    }

    @Override
    public void removeSessionListener(SessionListener sessionListener) {
        session.removeSessionListener(sessionListener);
    }

    @Override
    public void close() {
        session.popContext();
    }

    @Override
    public int getDepth() {
        return session.getDepth();
    }

    @Override
    public String dump() {
        return session.dump();
    }

    @Override
    public void setParamAt(PersistenceUnit persistenceUnit, String name, Object value, int depth) {
        session.setParamAt(persistenceUnit, name, value, depth);
    }

    @Override
    public <T> T getParamAt(PersistenceUnit persistenceUnit, Class<T> type, String name, T defaultValue, int depth) {
        return session.getParamAt(persistenceUnit, type, name, defaultValue, depth);
    }

}
