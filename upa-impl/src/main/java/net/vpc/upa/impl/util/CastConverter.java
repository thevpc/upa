package net.vpc.upa.impl.util;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/20/13 6:50 PM
 */
public class CastConverter<K,V> implements Converter<K,V>{
    @Override
    public V convert(K k) {
        //Double casting is mandatory in dotNet :(
        return (V)(Object)k;
    }
}
