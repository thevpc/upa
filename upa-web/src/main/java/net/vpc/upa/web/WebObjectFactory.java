/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.web;

import java.lang.reflect.Modifier;
import java.util.HashMap;
import java.util.Map;
import java.util.NoSuchElementException;
import java.util.logging.Level;
import java.util.logging.Logger;

import net.vpc.upa.*;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class WebObjectFactory implements ObjectFactory {

    final Logger log = Logger.getLogger(WebObjectFactory.class.getName());
    private ObjectFactory parentFactory;
    private Map<Class, Class> map = new HashMap<Class, Class>();
    private final HashMap<String, Object> singletons = new HashMap<String, Object>();

    public WebObjectFactory() {
        register(UPAContextProvider.class, WebUPAContextProvider.class);
        register(PersistenceUnitProvider.class, WebSessionPersistenceUnitProvider.class);
        register(PersistenceGroupProvider.class, WebPersistenceGroupProvider.class);
    }

    public int getContextSupportLevel() {
        return 10;
    }

    public void setParentFactory(ObjectFactory parentFactory) {
        this.parentFactory = parentFactory;
    }

    public final void register(Class contract, Class impl) {
        map.put(contract, impl);
    }

    public <T> T createObject(Class<T> type, String name) {
        Class best = map.get(type);
        if (best == null) {
            if (parentFactory != null) {
                return parentFactory.createObject(type, name);
            }
            if (Modifier.isAbstract(type.getModifiers()) || type.isInterface()) {
                throw new NoSuchElementException(type.getSimpleName());
            }
            best = type;
        }
        try {
            return (T) best.newInstance();
        } catch (InstantiationException e) {
            throw new RuntimeException(e);
        } catch (IllegalAccessException e) {
            throw new RuntimeException(e);
        }
    }

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

    public <T> T createObject(Class<T> type) {
        return createObject(type, null);
    }

    public <T> T createObject(String typeName) {
        try {
            return (T) createObject(Class.forName(typeName));
        } catch (ClassNotFoundException ex) {
            Logger.getLogger(WebObjectFactory.class.getName()).log(Level.SEVERE, null, ex);
            throw new RuntimeException(ex);
        }
    }

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
}
