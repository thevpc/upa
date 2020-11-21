/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.cache;

import net.thevpc.upa.Key;

/**
 *
 * @author vpc
 */
public class EntityCollectionCacheDisabled implements EntityCollectionCache {

    @Override
    public void add(String entityName, Key id, Object value) {
    }

    @Override
    public Object findById(String entityName, Key id) {
        return null;
    }

    @Override
    public void invalidate() {
    }

    @Override
    public void invalidate(String entityName) {
    }

    @Override
    public void invalidateByKey(String entityName, Key id) {
    }

}
