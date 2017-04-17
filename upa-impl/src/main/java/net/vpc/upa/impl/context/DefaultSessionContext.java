/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.context;

import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.SessionContext;

import java.util.HashMap;
import java.util.Map;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class DefaultSessionContext implements SessionContext {

    private Map<PersistenceUnitKey, Object> map=new HashMap<PersistenceUnitKey, Object>();

    public boolean containsParam(PersistenceUnit persistenceUnit, String name) {
        return map.containsKey(new PersistenceUnitKey(persistenceUnit, name));
    }

    
    @Override
    public void setParam(PersistenceUnit persistenceUnit, String name, Object value) {
        map.put(new PersistenceUnitKey(persistenceUnit, name), value);
    }

    @Override
    public <T> T getParam(PersistenceUnit persistenceUnit, Class<T> type, String name, T defaultValue) {
        Object o = map.get(new PersistenceUnitKey(persistenceUnit, name));
        if (o != null) {
            return (T) o;
        }
        return defaultValue;
    }

    @Override
    public String toString() {
        return "SessionContext{" +
                map +
                '}';
    }
}
