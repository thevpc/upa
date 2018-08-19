/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl;

import net.vpc.upa.impl.util.DefaultBeanAdapter;
import net.vpc.upa.impl.util.ItemInterceptor;
import net.vpc.upa.EntityItem;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
class DefaultSectionPrivateRemoveItemInterceptor implements ItemInterceptor<EntityItem> {

    public DefaultSectionPrivateRemoveItemInterceptor() {
    }

    @Override
    public void before(EntityItem child, int index) {
        DefaultBeanAdapter adapter = new DefaultBeanAdapter(child);
        adapter.injectNull("parent");
    }

    @Override
    public void after(EntityItem entityItem, int index) {
    }
    
}
