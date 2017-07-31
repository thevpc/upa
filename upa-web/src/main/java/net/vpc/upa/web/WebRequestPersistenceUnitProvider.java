/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.web;

import java.util.HashMap;
import java.util.Map;
import net.vpc.upa.PersistenceGroup;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.PersistenceUnitProvider;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class WebRequestPersistenceUnitProvider implements PersistenceUnitProvider {

    public String getPersistenceUnitName(PersistenceGroup persistenceGroup) {
        return getRequestMap().get(persistenceGroup.getName());
    }

    public void setPersistenceUnitName(PersistenceGroup persistenceGroup, String persistenceUnit) {
        String k = String.valueOf(persistenceGroup.getName());
        if (persistenceUnit == null) {
            getRequestMap().remove(k);
        } else {
            getRequestMap().put(k, persistenceUnit);
        }
    }

    private static Map<String, String> getRequestMap() {
        Map<String, String> v = (Map<String, String>) WebUPAContext.getRequestAttribute(WebRequestPersistenceUnitProvider.class.getName());
        if (v == null) {
            v = new HashMap<String, String>(3);
            WebUPAContext.setRequestAttribute(WebRequestPersistenceUnitProvider.class.getName(), v);
        }
        return v;
    }

}
