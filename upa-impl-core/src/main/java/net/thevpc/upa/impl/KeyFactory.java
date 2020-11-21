package net.thevpc.upa.impl;

import net.thevpc.upa.Key;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/27/12 1:51 AM
 */
public interface KeyFactory {

    Key createKey(Object... idValues);

    Object createId(Object... idValues);

    Object getId(Key unstructuredKey);

    Key getKey(Object id);


}
