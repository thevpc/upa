package net.thevpc.upa.impl.persistence.connection;

import net.thevpc.upa.CloseListener;
import net.thevpc.upa.Closeable;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/24/12 8:40 AM
 */
public interface ManagedCloseable extends Closeable {
    void addCloseListener(CloseListener closeListener);
    void removeCloseListener(CloseListener closeListener);
}
