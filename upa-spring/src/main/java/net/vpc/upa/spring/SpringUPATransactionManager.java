package net.vpc.upa.spring;

import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.TransactionType;
import net.vpc.upa.UPA;
import org.springframework.beans.factory.InitializingBean;
import org.springframework.transaction.TransactionDefinition;
import org.springframework.transaction.TransactionException;
import org.springframework.transaction.support.AbstractPlatformTransactionManager;
import org.springframework.transaction.support.DefaultTransactionStatus;
import org.springframework.transaction.support.SmartTransactionObject;
import org.springframework.transaction.support.TransactionSynchronizationManager;

public class SpringUPATransactionManager extends AbstractPlatformTransactionManager implements InitializingBean {

    //private PersistenceUnit persistenceUnit;
    private boolean nestedTx;

    public SpringUPATransactionManager() {
    }

//    public void setPersistenceUnit(PersistenceUnit persistenceUnit) {
//        this.persistenceUnit = persistenceUnit;
//    }
//
//    public PersistenceUnit getPersistenceUnit() {
//        return persistenceUnit;
//    }

    public boolean isNestedTx() {
        return nestedTx;
    }

    public void setNestedTx(boolean nestedTx) {
        this.nestedTx = nestedTx;
    }

    @Override
    protected Object doGetTransaction() throws TransactionException {

        UPATxObject txObject = new UPATxObject();
        PersistenceUnit persistenceUnit = UPA.getPersistenceUnit();
        SpringUPAHolder resource = (SpringUPAHolder) TransactionSynchronizationManager.getResource(persistenceUnit);
        if (resource != null) {
            txObject.setUpaHolder(resource, false);
        }
        return txObject;
    }

    private TransactionType getTransactionType(TransactionDefinition def) {
        int propagationBehavior = def.getPropagationBehavior();
        switch (propagationBehavior) {
            case TransactionDefinition.PROPAGATION_REQUIRED:
                return TransactionType.REQUIRED;
            case TransactionDefinition.PROPAGATION_SUPPORTS:
                return TransactionType.SUPPORTS;
            case TransactionDefinition.PROPAGATION_MANDATORY:
                return TransactionType.MANDATORY;
            case TransactionDefinition.PROPAGATION_NEVER:
                return TransactionType.NEVER;
            case TransactionDefinition.PROPAGATION_NOT_SUPPORTED:
                return TransactionType.NOT_SUPPORTED;
            case TransactionDefinition.PROPAGATION_REQUIRES_NEW:
                return TransactionType.REQUIRES_NEW;
            case TransactionDefinition.PROPAGATION_NESTED:
                return TransactionType.REQUIRED;
            default:
                return TransactionType.REQUIRED;
        }
    }

    @Override
    protected void doBegin(Object transaction, TransactionDefinition definition) throws TransactionException {
        UPATxObject upaTxObject = (UPATxObject) transaction;
        PersistenceUnit persistenceUnit = null;
        if (upaTxObject.getUpaHolder() == null) {
            boolean sessionCreated=false;
            persistenceUnit=UPA.getPersistenceUnit();
            if(!persistenceUnit.currentSessionExists()) {
                persistenceUnit.openSession();
            }
            SpringUPAHolder upaHolder = new SpringUPAHolder(persistenceUnit);
            upaHolder.setSessionCreated(sessionCreated);
            upaTxObject.setUpaHolder(upaHolder, true);
        }
        persistenceUnit = upaTxObject.getUpaHolder().getPersistenceUnit();
        persistenceUnit.beginTransaction(getTransactionType(definition));
        if (upaTxObject.isNewUPA()) {
            TransactionSynchronizationManager.bindResource(persistenceUnit, upaTxObject.getUpaHolder());

        }
        upaTxObject.getUpaHolder().setSynchronizedWithTransaction(true);
    }

    @Override
    protected void doCommit(DefaultTransactionStatus status) throws TransactionException {
        UPATxObject upaTxObject = (UPATxObject) status.getTransaction();
        PersistenceUnit persistenceUnit = upaTxObject.getUpaHolder().getPersistenceUnit();
        persistenceUnit.commitTransaction();
        if(upaTxObject.getUpaHolder().isSessionCreated()){
            upaTxObject.getUpaHolder().setSessionCreated(false);
            persistenceUnit.getCurrentSession().close();
        }
    }

    @Override
    protected void doRollback(DefaultTransactionStatus status) throws TransactionException {
        UPATxObject upaTxObject = (UPATxObject) status.getTransaction();
        PersistenceUnit persistenceUnit = upaTxObject.getUpaHolder().getPersistenceUnit();
        persistenceUnit.rollbackTransaction();
        if(upaTxObject.getUpaHolder().isSessionCreated()){
            upaTxObject.getUpaHolder().setSessionCreated(false);
            persistenceUnit.getCurrentSession().close();
        }
    }

    @Override
    public void afterPropertiesSet() throws Exception {
        //persistenceUnit.openSession();
    }


    private class UPATxObject implements SmartTransactionObject {
        private SpringUPAHolder upaHolder;
        private boolean newUPA;

        public UPATxObject() {

        }

        public UPATxObject(SpringUPAHolder upaHolder, boolean newUPA) {
            this.upaHolder = upaHolder;
            this.newUPA = newUPA;
        }

        public void setUpaHolder(SpringUPAHolder upaHolder) {
            this.upaHolder = upaHolder;
        }

        public void setUpaHolder(SpringUPAHolder upaHolder, boolean isNew) {
            this.upaHolder = upaHolder;
            this.newUPA = isNew;

        }

        public SpringUPAHolder getUpaHolder() {
            return upaHolder;
        }

        public boolean isNewUPA() {
            return newUPA;
        }

        public void setNewUPA(boolean newUPA) {
            this.newUPA = newUPA;
        }

        @Override
        public boolean isRollbackOnly() {
            return upaHolder.isRollbackOnly();
        }

        @Override
        public void flush() {
            upaHolder.getPersistenceUnit().clear();
        }
    }
}
