package net.vpc.upa.impl;

import net.vpc.upa.callbacks.EntityInterceptor;

import java.util.*;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/9/12 2:48 PM
 */
public class PersistenceUnitOnHoldInfo {
    public Set<String> names = new HashSet<String>();

    public Map<String, Map<String, EntityInterceptor>> triggers = new HashMap<String, Map<String, EntityInterceptor>>();

    public Map<String, EntityInterceptor> getTriggersMap(String entityName) {
        Map<String, EntityInterceptor> tt = triggers.get(entityName);
        if (tt == null) {
            tt = new LinkedHashMap<String, EntityInterceptor>();
            triggers.put(entityName, tt);
        }
        return tt;
    }

    public boolean isDeclared(String type,String name){
          return names.contains(type+"."+name);
    }
}
