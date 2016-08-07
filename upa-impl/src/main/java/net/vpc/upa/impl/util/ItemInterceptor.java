package net.vpc.upa.impl.util;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/4/13 12:15 AM
*/
public interface ItemInterceptor<T> {
    public void before(T t, int index);
    public void after(T t, int index);
}
