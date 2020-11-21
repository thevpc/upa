/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.web;

import net.thevpc.upa.PersistenceGroup;
import net.thevpc.upa.PersistenceUnitProvider;

import java.io.Serializable;
import java.util.HashMap;
import java.util.Map;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class WebSessionPersistenceUnitProvider implements PersistenceUnitProvider, Serializable {

    private static Map<String, String> getSessionMap() {
        Map<String, String> v = (Map<String, String>) WebUPAContext.getSessionAttribute(WebSessionPersistenceUnitProvider.class.getName());
        if (v == null) {
            v = new HashMap<String, String>(3);
            WebUPAContext.setSessionAttribute(WebSessionPersistenceUnitProvider.class.getName(), v);
        }
        return v;
    }

    public String getPersistenceUnitName(PersistenceGroup persistenceGroup) {
        try {
            return getSessionMap().get(persistenceGroup.getName());
        } catch (Exception ex) {
            //Session May be inaccessible
            return null;
        }
    }

    public void setPersistenceUnitName(PersistenceGroup persistenceGroup, String persistenceUnit) {
        try {
            String k = persistenceGroup.getName();

            if (persistenceUnit == null) {
                getSessionMap().remove(k);
            } else {
                getSessionMap().put(k, persistenceUnit);
            }
        } catch (Exception ex) {
            //Session May be inaccessible
        }
    }
}
