/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl;

import net.thevpc.upa.impl.util.DefaultBeanAdapter;
import net.thevpc.upa.impl.util.ItemInterceptor;
import net.thevpc.upa.EntityItem;

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
