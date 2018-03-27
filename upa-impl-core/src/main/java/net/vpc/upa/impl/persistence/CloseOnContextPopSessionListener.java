package net.vpc.upa.impl.persistence;

import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.Session;
import net.vpc.upa.SessionContext;
import net.vpc.upa.callbacks.SessionListenerAdapter;
import net.vpc.upa.impl.SessionParams;
import net.vpc.upa.persistence.UConnection;

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
