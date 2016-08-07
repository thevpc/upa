/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl;

import net.vpc.upa.PersistenceUnitPart;
import net.vpc.upa.impl.util.DefaultBeanAdapter;
import net.vpc.upa.impl.util.ItemInterceptor;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
class DefaultPackagePrivateRemovePartInterceptor implements ItemInterceptor<PersistenceUnitPart> {

    public DefaultPackagePrivateRemovePartInterceptor() {
    }

    @Override
    public void before(PersistenceUnitPart persistenceUnitItem, int index) {
    }

    @Override
    public void after(PersistenceUnitPart persistenceUnitItem, int index) {
        DefaultBeanAdapter a = new DefaultBeanAdapter(persistenceUnitItem);
        a.injectNull("parent");
    }
    
}
