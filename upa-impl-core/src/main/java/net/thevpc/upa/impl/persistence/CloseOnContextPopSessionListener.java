package net.thevpc.upa.impl.persistence;

import net.thevpc.upa.PersistenceUnit;
import net.thevpc.upa.persistence.UConnection;
import net.thevpc.upa.Session;
import net.thevpc.upa.SessionContext;
import net.thevpc.upa.events.SessionListenerAdapter;
import net.thevpc.upa.impl.SessionParams;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/10/13 11:30 PM
*/
public class CloseOnContextPopSessionListener extends SessionListenerAdapter {
    private final UConnection finalConnection;
    private PersistenceUnit pu;

    public CloseOnContextPopSessionListener(PersistenceUnit pu, UConnection finalConnection) {
        this.pu = pu;
        this.finalConnection = finalConnection;
    }

    @Override
    public void popContext(Session session) {
        SessionContext currentContext = session.getCurrentContext();
        UConnection sconnection = currentContext.getParam(pu, UConnection.class, SessionParams.CONNECTION, null);
        if (sconnection != null && sconnection == finalConnection) {
            sconnection.close();
            currentContext.setParam(pu, SessionParams.CONNECTION, null);
            session.removeSessionListener(this);
        }
    }
}
