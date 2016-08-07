/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl;

import java.net.URL;
import java.util.HashMap;
import java.util.List;
import net.vpc.upa.ObjectFactory;
import net.vpc.upa.UPAContextFactory;
import net.vpc.upa.config.ScanFilter;
import net.vpc.upa.config.ScanSource;
import net.vpc.upa.impl.config.ClassesScanSource;
import net.vpc.upa.impl.config.ContextScanSource;
import net.vpc.upa.impl.config.URLScanSource;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class DefaultUPAContextFactory implements UPAContextFactory {

    private ObjectFactory baseFactory;
    private final HashMap<String, Object> singletons = new HashMap<String, Object>();

    public DefaultUPAContextFactory(ObjectFactory baseFactory) {
        this.baseFactory = baseFactory;
    }

    public int getContextSupportLevel() {
        return baseFactory.getContextSupportLevel();
    }

    public void setParentFactory(ObjectFactory factory) {
        baseFactory.setParentFactory(factory);
    }

    public <T> T createObject(Class<T> type, String name) {
        return baseFactory.createObject(type, name);
    }

    public <T> T createObject(String typeName, String name) {
        return baseFactory.createObject(typeName, name);
    }

    public <T> T createObject(Class<T> type) {
        return baseFactory.createObject(type);
    }

    public <T> T createObject(String typeName) {
        return baseFactory.createObject(typeName);
    }

    public ScanSource createURLScanSource(URL[] urls, ScanFilter[] filters, boolean noIgnore) {
        return new URLScanSource(urls, filters, noIgnore);
    }

    /**
     *
     * @param noIgnore
     * @return
     */
    public ScanSource createContextScanSource(boolean noIgnore) {
        return new ContextScanSource(noIgnore);
    }
    
    @Override
    public ScanSource createClassScanSource(Class[] classes, boolean noIgnore) {
        return new ClassesScanSource(classes, noIgnore);
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
