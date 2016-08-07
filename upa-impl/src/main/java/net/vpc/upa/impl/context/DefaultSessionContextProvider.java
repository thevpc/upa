package net.vpc.upa.impl.context;

import net.vpc.upa.PersistenceGroup;
import net.vpc.upa.Session;
import net.vpc.upa.SessionContextProvider;

import java.util.HashMap;
import java.util.Map;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/12/12 12:14 AM
 */
public class DefaultSessionContextProvider implements SessionContextProvider {

    private static ThreadLocal<Map<PersistenceGroup, Session>> current = new ThreadLocal<Map<PersistenceGroup, Session>>();

    @Override
    public Session getSession(PersistenceGroup persistenceGroup) {
        return getMap().get(persistenceGroup);
    }

    @Override
    public void setSession(PersistenceGroup persistenceGroup, Session session) {
        if (session == null) {
            getMap().remove(persistenceGroup);
        } else {
            getMap().put(persistenceGroup, session);
        }
    }

    private static Map<PersistenceGroup, Session> getMap() {
        Map<PersistenceGroup, Session> v = current.get();
        if (v == null) {
            v = new HashMap<PersistenceGroup, Session>(3);
            current.set(v);
        }
        return v;
    }
}
