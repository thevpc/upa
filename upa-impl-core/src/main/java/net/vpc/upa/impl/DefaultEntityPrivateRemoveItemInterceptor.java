/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl;

import net.vpc.upa.impl.util.DefaultBeanAdapter;
import net.vpc.upa.impl.util.ItemInterceptor;
import net.vpc.upa.EntityItem;

/**
 *
 * @author taha.bensalah@gmail.com
 */
class DefaultEntityPrivateRemoveItemInterceptor implements ItemInterceptor<EntityItem> {

    public DefaultEntityPrivateRemoveItemInterceptor() {
    }

    @Override
    public void before(EntityItem entityItem, int index) {
        DefaultBeanAdapter a = new DefaultBeanAdapter(entityItem);
        a.injectNull("parent");
    }

    @Override
    public void after(EntityItem entityItem, int index) {
    }
    
}
