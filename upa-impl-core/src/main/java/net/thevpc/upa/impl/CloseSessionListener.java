package net.thevpc.upa.impl;

import net.thevpc.upa.Session;
import net.thevpc.upa.events.SessionListenerAdapter;

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
