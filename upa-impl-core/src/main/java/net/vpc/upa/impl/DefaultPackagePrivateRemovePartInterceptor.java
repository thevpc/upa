/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl;

import net.vpc.upa.impl.util.DefaultBeanAdapter;
import net.vpc.upa.impl.util.ItemInterceptor;
import net.vpc.upa.PersistenceUnitItem;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
class DefaultPackagePrivateRemovePartInterceptor implements ItemInterceptor<PersistenceUnitItem> {

    public DefaultPackagePrivateRemovePartInterceptor() {
    }

    @Override
    public void before(PersistenceUnitItem persistenceUnitItem, int index) {
    }

    @Override
    public void after(PersistenceUnitItem persistenceUnitItem, int index) {
        DefaultBeanAdapter a = new DefaultBeanAdapter(persistenceUnitItem);
        a.injectNull("parent");
    }
    
}
