/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl;

import net.vpc.upa.Package;
import net.vpc.upa.PersistenceUnitPart;
import net.vpc.upa.PrimitiveField;
import net.vpc.upa.impl.util.DefaultBeanAdapter;
import net.vpc.upa.impl.util.ItemInterceptor;
import net.vpc.upa.impl.util.UPAUtils;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
class DefaultPackagePrivateAddPartInterceptor implements ItemInterceptor<PersistenceUnitPart> {

    private Package p;

    public DefaultPackagePrivateAddPartInterceptor(Package p) {
        this.p = p;
    }

    public void before(PersistenceUnitPart t, int index) {
        PersistenceUnitPart oldParent = t.getParent();
        if (oldParent != null && oldParent != p) {
            if (oldParent instanceof Package) {
                Package x = (Package) oldParent;
                x.removePartAt(x.indexOfPart(t));
            } else if (oldParent instanceof PrimitiveField) {
                //
            }
        }
    }

    public void after(PersistenceUnitPart t, int index) {
        PersistenceUnitPart oldParent = t.getParent();
        if (oldParent != p) {
            DefaultBeanAdapter a = new DefaultBeanAdapter(t);
            a.setProperty("parent", p);
        }
        //in case of move => same parent!
        UPAUtils.preparePostAdd(p.getPersistenceUnit(), t);
    }

}
