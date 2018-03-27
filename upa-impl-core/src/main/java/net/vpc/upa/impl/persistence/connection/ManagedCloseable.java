package net.vpc.upa.impl.persistence.connection;

import net.vpc.upa.Closeable;
import net.vpc.upa.CloseListener;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/24/12 8:40 AM
 */
public interface ManagedCloseable extends Closeable {
    void addCloseListener(CloseListener closeListener);
    void removeCloseListener(CloseListener closeListener);
}
