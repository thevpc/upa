/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.util;

import java.util.Map;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class DefaultConverter<K, V> implements Converter<K, V> {

    private Map<K, V> map;

    public DefaultConverter(Map<K, V> map) {
        this.map = map;
    }

    @Override
    public V convert(K k) {
        return map.get(k);
    }
}
