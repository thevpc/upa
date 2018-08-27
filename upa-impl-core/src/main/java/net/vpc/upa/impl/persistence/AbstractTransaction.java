package net.vpc.upa.impl.persistence;

import net.vpc.upa.types.I18NString;
import net.vpc.upa.exceptions.TransactionException;
import net.vpc.upa.Transaction;
import net.vpc.upa.TransactionListener;
import net.vpc.upa.TransactionStatus;

import java.util.ArrayList;
import java.util.List;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 5:02 PM
 */
public abstract class AbstractTransaction implements Transaction {
    private TransactionStatus status = TransactionStatus.NOT_ACTIVE;
    protected List<TransactionListener> listeners = new ArrayList<TransactionListener>();

    public TransactionStatus getStatus() {
        return status;
    }

    public void setStatus(TransactionStatus status) {
        this.status = status;
    }

    @Override
    public void begin() throws TransactionException {
        try {
            beginImpl();
            setStatus(TransactionStatus.ACTIVE);
        } catch (Exception e) {
            throw new TransactionException(e, new I18NString("TransactionCommitFailed"));
        }
    }

    @Override
    public void commit() throws TransactionException {
        try {
            commitImpl();
            setStatus(TransactionStatus.COMMITTED);
        } catch (Exception e) {
            throw new TransactionException(e, new I18NString("TransactionCommitFailed"));
        }
    }

    @Override
    public void rollback() throws TransactionException {
        try {
            rollbackImpl();
            setStatus(TransactionStatus.ROLLED_BACK);
        } catch (Exception e) {
            throw new TransactionException(e, new I18NString("TransactionCommitFailed"));
        }
    }


    @Override
    public void close() {
        setStatus(TransactionStatus.CLOSED);
    }

    @Override
    public void addTransactionListener(TransactionListener transactionListener) {
        listeners.add(transactionListener);
    }

    @Override
    public void removeTransactionListener(TransactionListener transactionListener) {
        listeners.remove(transactionListener);
    }

    protected abstract void beginImpl() throws Exception;

    public abstract void commitImpl() throws Exception;

    public abstract void rollbackImpl() throws Exception;
}
