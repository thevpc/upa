package net.vpc.upa.impl;

import net.vpc.upa.PersistenceGroup;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.Session;
import net.vpc.upa.SessionContext;
import net.vpc.upa.callbacks.SessionListener;

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
}
