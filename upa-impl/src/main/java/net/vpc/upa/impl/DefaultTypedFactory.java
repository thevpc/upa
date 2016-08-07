package net.vpc.upa.impl;

import java.util.HashMap;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.ObjectFactory;
import net.vpc.upa.impl.util.PlatformUtils;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/11/12 9:21 PM
 */
public class DefaultTypedFactory implements ObjectFactory {

    private static final Logger log = Logger.getLogger(DefaultTypedFactory.class.getName());

    private ObjectFactory parentFactory;
    private final HashMap<String, Object> singletons = new HashMap<String, Object>();

    public DefaultTypedFactory() {
    }

    public void setParentFactory(ObjectFactory factory) {
        this.parentFactory = factory;
    }

    @Override
    public <T> T createObject(Class<T> type, String name) {
        return parentFactory.createObject(type, name);
    }

    public <T> T createObject(String typeName, String name) {
        return parentFactory.createObject(typeName, name);
    }

    public <T> T createObject(Class<T> type) {
        return parentFactory.createObject(type);
    }

    public <T> T createObject(String typeName) {
        try {
            Class<T> type = (Class<T>) PlatformUtils.forName(typeName);
            return (T) createObject(type);
        } catch (ClassNotFoundException ex) {
            log.log(Level.SEVERE, null, ex);
            throw new RuntimeException(ex);
        }
    }

    public int getContextSupportLevel() {
        return 0;
    }

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

}
