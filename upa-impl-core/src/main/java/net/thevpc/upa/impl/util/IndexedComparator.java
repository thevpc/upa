package net.thevpc.upa.impl.util;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 12/17/12 7:24 PM
 */
public interface IndexedComparator<R> {
    int compare(R o1, R o2,int i1,int i2);
}
