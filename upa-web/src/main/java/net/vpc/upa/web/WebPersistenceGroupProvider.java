/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.web;

import net.vpc.upa.PersistenceGroupProvider;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class WebPersistenceGroupProvider implements PersistenceGroupProvider {
    public String getPersistenceGroup() {
        return (String) WebUPAContext.getRequestAttribute(WebPersistenceGroupProvider.class.getName());
    }

    @Override
    public void setPersistenceGroup(String persistenceGroup) {
        WebUPAContext.setRequestAttribute(WebPersistenceGroupProvider.class.getName(), persistenceGroup);
    }
}
