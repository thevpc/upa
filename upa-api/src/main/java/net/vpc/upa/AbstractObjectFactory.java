/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.LinkedHashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author vpc
 */
public abstract class AbstractObjectFactory implements ObjectFactory {

    private static Logger log = Logger.getLogger(AbstractObjectFactory.class.getName());

    private final HashMap<String, Object> singletons = new HashMap<String, Object>();
    private final Map<Class, Set> alternatives = new HashMap<Class, Set>();

    @Override
    public <T> T getSingleton(Class<T> type) {
        String typeName = type.getName();
        if (singletons.containsKey(typeName)) {
            return (T) singletons.get(typeName);
        }
        synchronized (singletons) {
            if (singletons.containsKey(typeName)) {
                return (T) singletons.get(typeName);
            }
            T o = createObject(type);
            singletons.put(typeName, o);
            return o;
        }
    }

    @Override
    public <T> T getSingleton(String typeName) {
        if (singletons.containsKey(typeName)) {
            return (T) singletons.get(typeName);
        }
        synchronized (singletons) {
            if (singletons.containsKey(typeName)) {
                return (T) singletons.get(typeName);
            }
            T o = createObject(typeName);
            singletons.put(typeName, o);
            return o;
        }
    }

    @Override
    public <T> T createObject(String typeName, String name) {
        Class<?> c;
        try {
            c = Class.forName(typeName);
        } catch (ClassNotFoundException ex) {
            log.log(Level.SEVERE, null, ex);
            throw new RuntimeException(typeName);
        }
        return (T) createObject(c, name);
    }

    @Override
    public <T> T createObject(Class<T> type) {
        return createObject(type, null);
    }

    @Override
    public <T> T createObject(String typeName) {
        try {
            return (T) createObject(Class.forName(typeName));
        } catch (ClassNotFoundException ex) {
            log.log(Level.SEVERE, null, ex);
            throw new RuntimeException(ex);
        }
    }

    @Override
    public <T> Class[] getAlternatives(Class<T> type) {
        List<Class> all = new ArrayList<Class>();
        Set found = alternatives.get(type);
        if (found != null) {
            all.addAll(found);
        }
        return all.toArray(new Class[all.size()]);
    }

    @Override
    public <T> void addAlternative(Class<T> type, Class<? extends T> impl) {
        Set found = alternatives.get(type);
        if (found == null) {
            found=new LinkedHashSet();
            alternatives.put(type,found);
        }
        found.add(impl);
    }

}
