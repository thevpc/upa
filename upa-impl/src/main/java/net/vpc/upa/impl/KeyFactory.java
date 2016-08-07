package net.vpc.upa.impl;

import net.vpc.upa.Key;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/27/12 1:51 AM
 */
public interface KeyFactory {

    public Key createKey(Object... idValues);

    public Object createId(Object... idValues);

    public Object getId(Key unstructuredKey);

    public Key getKey(Object id);


}
