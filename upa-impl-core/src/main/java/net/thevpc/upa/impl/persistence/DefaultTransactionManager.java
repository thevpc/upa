package net.thevpc.upa.impl.persistence;

import net.thevpc.upa.persistence.PersistenceStore;
import net.thevpc.upa.persistence.UConnection;
import net.thevpc.upa.PersistenceUnit;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.Transaction;
import net.thevpc.upa.TransactionManager;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 4:58 PM
 */
public class DefaultTransactionManager implements TransactionManager {

    @Override
    public Transaction createTransaction(UConnection connection, PersistenceUnit persistenceUnit, PersistenceStore persistenceStore) throws UPAException {
        if (connection == null) {
            throw new IllegalStateException("No Active Connection Found");
        }
        DefaultTransaction t = new DefaultTransaction();
        t.init(connection);
        return t;
    }
}
