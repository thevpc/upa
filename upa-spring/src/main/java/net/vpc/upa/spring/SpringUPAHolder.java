package net.vpc.upa.spring;

import net.vpc.upa.PersistenceUnit;
import org.springframework.transaction.SavepointManager;
import org.springframework.transaction.support.ResourceHolderSupport;

public class SpringUPAHolder extends ResourceHolderSupport {
    private PersistenceUnit persistenceUnit;
    private boolean txActive;
    private boolean sessionCreated;
    private SavepointManager savepointManager;

    public SpringUPAHolder(PersistenceUnit persistenceUnit) {
        this.persistenceUnit = persistenceUnit;
    }

    public boolean isSessionCreated() {
        return sessionCreated;
    }

    public void setSessionCreated(boolean sessionCreated) {
        this.sessionCreated = sessionCreated;
    }

    public PersistenceUnit getPersistenceUnit() {
        return persistenceUnit;
    }

    public void setPersistenceUnit(PersistenceUnit persistenceUnit) {
        this.persistenceUnit = persistenceUnit;
    }

    public boolean isTxActive() {
        return txActive;
    }

    public void setTxActive(boolean txActive) {
        this.txActive = txActive;
    }

    public SavepointManager getSavepointManager() {
        return savepointManager;
    }

    public void setSavepointManager(SavepointManager savepointManager) {
        this.savepointManager = savepointManager;
    }

    @Override
    public void clear() {
        super.clear();
        this.savepointManager=null;
        this.txActive=false;
        this.sessionCreated=false;
    }
}
