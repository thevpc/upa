/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.persistence;

import net.thevpc.upa.PersistenceUnit;
import net.thevpc.upa.Session;
import net.thevpc.upa.Transaction;
import net.thevpc.upa.TransactionManager;
import net.thevpc.upa.TransactionType;
import net.thevpc.upa.impl.DefaultPersistenceUnit;
import net.thevpc.upa.impl.SessionParams;
import net.thevpc.upa.persistence.PersistenceStore;
import net.thevpc.upa.persistence.UConnection;

/**
 *
 * @author vpc
 */
public class UTransactionHelper {

    private PersistenceUnit pu;
    private TransactionManager tm;
    private PersistenceStore persistenceStore;
    private Transaction transaction;
    private TransactionType transactionType;

    public static UTransactionHelper get(Session currentSession, PersistenceUnit pu) {
        return (UTransactionHelper) currentSession.getParam(pu, UTransactionHelper.class, SessionParams.TRANSACTION, null);
    }

    public static UTransactionHelper getAt(Session currentSession, PersistenceUnit pu, int depth) {
        return (UTransactionHelper) currentSession.getParamAt(pu, UTransactionHelper.class, SessionParams.TRANSACTION, null, depth);
    }

    public static UTransactionHelper getImmediate(Session currentSession, PersistenceUnit pu) {
        return (UTransactionHelper) currentSession.getImmediateParam(pu, UTransactionHelper.class, SessionParams.TRANSACTION, null);
    }

    public static UTransactionHelper set(Session currentSession, PersistenceUnit pu, TransactionType transactionType) {
        DefaultPersistenceUnit dpu = (DefaultPersistenceUnit) pu;
        TransactionManager tm = dpu.getTransactionManager();
        PersistenceStore persistenceStore = dpu.getPersistenceStore();
        UTransactionHelper th = new UTransactionHelper(dpu, tm, persistenceStore, transactionType);
        currentSession.setParam(pu, SessionParams.TRANSACTION_TYPE, transactionType);
        currentSession.setParam(pu, SessionParams.TRANSACTION, th);

        return th;
    }

    public TransactionType getTransactionType() {
        return transactionType;
    }

    public UTransactionHelper(DefaultPersistenceUnit pu, TransactionManager tm, PersistenceStore persistenceStore, TransactionType transactionType) {
        this.pu = pu;
        this.tm = tm;
        this.persistenceStore = persistenceStore;
        this.transactionType = transactionType;
        UConnection c = pu.getConnection(false);
        if (c != null) {
            getTransactionOrCreate();
        }
    }

    public void commit() {
        if (transaction != null) {
            transaction.commit();
        }
    }

    public void rollback() {
        if (transaction != null) {
            transaction.rollback();
        }
    }

    public Transaction getTransactionOrNull() {
        return transaction;
    }

    public Transaction getTransactionOrCreate() {
        if (transaction == null) {
            transaction = tm.createTransaction(pu.getConnection(), pu, persistenceStore);
            transaction.begin();
        }
        return transaction;
    }

}
