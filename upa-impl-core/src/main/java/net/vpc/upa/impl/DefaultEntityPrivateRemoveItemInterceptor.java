/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl;

import net.vpc.upa.EntityPart;
import net.vpc.upa.impl.util.DefaultBeanAdapter;
import net.vpc.upa.impl.util.ItemInterceptor;

/**
 *
 * @author taha.bensalah@gmail.com
 */
class DefaultEntityPrivateRemoveItemInterceptor implements ItemInterceptor<EntityPart> {

    public DefaultEntityPrivateRemoveItemInterceptor() {
    }

    @Override
    public void before(EntityPart entityItem, int index) {
        DefaultBeanAdapter a = new DefaultBeanAdapter(entityItem);
        a.injectNull("parent");
    }

    @Override
    public void after(EntityPart entityItem, int index) {
    }
    
}
