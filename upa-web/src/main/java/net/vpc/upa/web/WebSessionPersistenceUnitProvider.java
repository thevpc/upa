/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.web;

import java.io.Serializable;
import java.util.HashMap;
import java.util.Map;
import net.vpc.upa.PersistenceGroup;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.PersistenceUnitProvider;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class WebSessionPersistenceUnitProvider implements PersistenceUnitProvider, Serializable {

    public PersistenceUnit getPersistenceUnit(PersistenceGroup persistenceGroup) {
        String r = getSessionMap().get(String.valueOf(System.identityHashCode(persistenceGroup)));
        return r == null ? null : persistenceGroup.getPersistenceUnit(r);
    }

    public void setPersistenceUnit(PersistenceGroup persistenceGroup, PersistenceUnit persistenceUnit) {
        String k = String.valueOf(System.identityHashCode(persistenceGroup));
        if (persistenceUnit == null) {
            getSessionMap().remove(k);
        } else {
            getSessionMap().put(k, persistenceUnit.getName());
        }
    }

    private static Map<String, String> getSessionMap() {
        Map<String, String> v = (Map<String, String>) WebUPAContext.getSessionAttribute(WebSessionPersistenceUnitProvider.class.getName());
        if (v == null) {
            v = new HashMap<String, String>(3);
            WebUPAContext.setSessionAttribute(WebSessionPersistenceUnitProvider.class.getName(), v);
        }
        return v;
    }
}
