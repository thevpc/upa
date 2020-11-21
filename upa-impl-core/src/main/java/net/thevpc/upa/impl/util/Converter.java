/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.util;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public interface Converter<K,V> {
    V convert(K k);
}
