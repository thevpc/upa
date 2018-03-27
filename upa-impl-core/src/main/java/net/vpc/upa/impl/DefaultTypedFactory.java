package net.vpc.upa.impl;

import java.util.Arrays;
import java.util.LinkedHashSet;
import java.util.Set;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.ObjectFactory;
import net.vpc.upa.AbstractObjectFactory;
import net.vpc.upa.impl.util.PlatformUtils;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/11/12 9:21 PM
 */
public class DefaultTypedFactory extends AbstractObjectFactory {

    private static final Logger log = Logger.getLogger(DefaultTypedFactory.class.getName());

    private ObjectFactory parentFactory;

    public DefaultTypedFactory() {
    }

    @Override
    public void setParentFactory(ObjectFactory factory) {
        this.parentFactory = factory;
    }

    @Override
    public <T> T createObject(Class<T> type, String name) {
        return parentFactory.createObject(type, name);
    }

    @Override
    public <T> T createObject(String typeName, String name) {
        return parentFactory.createObject(typeName, name);
    }

    @Override
    public <T> T createObject(Class<T> type) {
        return parentFactory.createObject(type);
    }

    @Override
    public void register(Class contract, Class impl) {
        parentFactory.register(contract, impl);
    }

    @Override
    public <T> T createObject(String typeName) {
        T s = (T)singletons.get(typeName);
        if(s!=null){
            return s;
        }
        try {
            Class<T> type = (Class<T>) PlatformUtils.forName(typeName);
            return (T) createObject(type);
        } catch (ClassNotFoundException ex) {
            log.log(Level.SEVERE, null, ex);
            throw new RuntimeException(ex);
        }
    }

    @Override
    public int getContextSupportLevel() {
        return 0;
    }

    @Override
    public <T> Class[] getAlternatives(Class<T> type) {
        Set<Class> found = new LinkedHashSet<Class>(Arrays.asList(super.getAlternatives(type)));
        if (parentFactory != null) {
            found.addAll(Arrays.asList(parentFactory.getAlternatives(type)));
        }
        return found.toArray(new Class[found.size()]);
    }

}
