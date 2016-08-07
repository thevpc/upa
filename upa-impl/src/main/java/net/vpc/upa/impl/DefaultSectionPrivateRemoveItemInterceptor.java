/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl;

import net.vpc.upa.EntityPart;
import net.vpc.upa.impl.util.DefaultBeanAdapter;
import net.vpc.upa.impl.util.ItemInterceptor;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
class DefaultSectionPrivateRemoveItemInterceptor implements ItemInterceptor<EntityPart> {

    public DefaultSectionPrivateRemoveItemInterceptor() {
    }

    @Override
    public void before(EntityPart child, int index) {
        DefaultBeanAdapter adapter = new DefaultBeanAdapter(child);
        adapter.injectNull("parent");
    }

    @Override
    public void after(EntityPart entityItem, int index) {
    }
    
}
