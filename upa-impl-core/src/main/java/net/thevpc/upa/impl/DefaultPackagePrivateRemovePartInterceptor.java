/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl;

import net.thevpc.upa.impl.util.DefaultBeanAdapter;
import net.thevpc.upa.impl.util.ItemInterceptor;
import net.thevpc.upa.PersistenceUnitItem;

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
