package net.thevpc.upa.impl.util;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/4/13 12:15 AM
*/
public interface ItemInterceptor<T> {
    void before(T t, int index);
    void after(T t, int index);
}
