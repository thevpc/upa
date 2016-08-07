package net.vpc.upa.impl;

import net.vpc.upa.Session;
import net.vpc.upa.callbacks.SessionListenerAdapter;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/8/13 2:26 PM
*/
class CloseSessionListener extends SessionListenerAdapter {
    private DefaultPersistenceGroup defaultPersistenceGroup;

    public CloseSessionListener(DefaultPersistenceGroup defaultPersistenceGroup) {
        this.defaultPersistenceGroup = defaultPersistenceGroup;
    }

    @Override
    public void closeSession(Session session) {
        defaultPersistenceGroup.onSessionClosed(session);
    }
}
