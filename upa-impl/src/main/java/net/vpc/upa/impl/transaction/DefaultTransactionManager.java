package net.vpc.upa.impl.transaction;

import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.persistence.UConnection;
import net.vpc.upa.persistence.PersistenceStore;
import net.vpc.upa.Transaction;
import net.vpc.upa.TransactionManager;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 4:58 PM
 */
public class DefaultTransactionManager implements TransactionManager {

    @Override
    public Transaction createTransaction(PersistenceUnit persistenceUnit, PersistenceStore persistenceStore) throws UPAException {
        UConnection connection = persistenceStore.getConnection();
        if (connection == null) {
            throw new IllegalStateException("No Active Connection Found");
        }
        DefaultTransaction t = new DefaultTransaction();
        t.init(connection);
        return t;
    }
}
