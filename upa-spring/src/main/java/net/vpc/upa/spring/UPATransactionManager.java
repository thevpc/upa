package net.vpc.upa.spring;

import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.TransactionType;
import org.springframework.beans.factory.InitializingBean;
import org.springframework.transaction.TransactionDefinition;
import org.springframework.transaction.TransactionException;
import org.springframework.transaction.support.AbstractPlatformTransactionManager;
import org.springframework.transaction.support.DefaultTransactionStatus;
import org.springframework.transaction.support.SmartTransactionObject;
import org.springframework.transaction.support.TransactionSynchronizationManager;

public class UPATransactionManager extends AbstractPlatformTransactionManager implements InitializingBean {

    private PersistenceUnit persistenceUnit;
    private boolean nestedTx;

    public UPATransactionManager(PersistenceUnit persistenceUnit) {
        this.persistenceUnit = persistenceUnit;
    }

    public void setPersistenceUnit(PersistenceUnit persistenceUnit) {
        this.persistenceUnit = persistenceUnit;
    }

    public PersistenceUnit getPersistenceUnit() {
        return persistenceUnit;
    }

    public boolean isNestedTx() {
        return nestedTx;
    }

    public void setNestedTx(boolean nestedTx) {
        this.nestedTx = nestedTx;
    }

    @Override
    protected Object doGetTransaction() throws TransactionException {

        UPATxObject txObject = new UPATxObject();
        UPAHolder resource = (UPAHolder) TransactionSynchronizationManager.getResource(getPersistenceUnit());
        if (resource != null) {
            txObject.setUpaHolder(resource, false);
        }
        return txObject;
    }

    private TransactionType getTransactionType(TransactionDefinition def) {
        int propagationBehavior = def.getPropagationBehavior();
        switch (propagationBehavior) {
            case 0:
                return TransactionType.REQUIRED;
            case 1:
                return TransactionType.SUPPORTS;
            case 2:
                return TransactionType.MANDATORY;
            default:
                return TransactionType.REQUIRED;
        }
    }

    @Override
    protected void doBegin(Object transaction, TransactionDefinition definition) throws TransactionException {
        UPATxObject upaTxObject = (UPATxObject) transaction;

        if (upaTxObject.getUpaHolder() == null) {
            persistenceUnit.openSession();
            upaTxObject.setUpaHolder(new UPAHolder(persistenceUnit), true);


        }
        PersistenceUnit persistenceUnit = upaTxObject.getUpaHolder().getPersistenceUnit();
        persistenceUnit.beginTransaction(getTransactionType(definition));
        if (upaTxObject.isNewUPA()) {
            TransactionSynchronizationManager.bindResource(
                    getPersistenceUnit(), upaTxObject.getUpaHolder());

        }
        upaTxObject.getUpaHolder().setSynchronizedWithTransaction(true);



    }

    @Override
    protected void doCommit(DefaultTransactionStatus status) throws TransactionException {
        UPATxObject upaTxObject = (UPATxObject) status.getTransaction();
        upaTxObject.getUpaHolder().getPersistenceUnit().commitTransaction();

    }

    @Override
    protected void doRollback(DefaultTransactionStatus status) throws TransactionException {
        UPATxObject upaTxObject = (UPATxObject) status.getTransaction();
        upaTxObject.getUpaHolder().getPersistenceUnit().rollbackTransaction();
    }

    @Override
    public void afterPropertiesSet() throws Exception {
        //persistenceUnit.openSession();
    }


    private class UPATxObject implements SmartTransactionObject {
        private UPAHolder upaHolder;
        private boolean newUPA;

        public UPATxObject() {

        }

        public UPATxObject(UPAHolder upaHolder, boolean newUPA) {
            this.upaHolder = upaHolder;
            this.newUPA = newUPA;
        }

        public void setUpaHolder(UPAHolder upaHolder) {
            this.upaHolder = upaHolder;
        }

        public void setUpaHolder(UPAHolder upaHolder, boolean isNew) {
            this.upaHolder = upaHolder;
            this.newUPA = isNew;

        }

        public UPAHolder getUpaHolder() {
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

