/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl;

import java.net.URL;
import java.util.*;

import net.vpc.upa.AbstractObjectFactory;
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
public class DefaultUPAContextFactory extends AbstractObjectFactory implements UPAContextFactory {

    private ObjectFactory baseFactory;

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

    @Override
    public void register(Class contract, Class impl) {
        baseFactory.register(contract, impl);
    }

    @Override
    public ScanSource createURLScanSource(String sourceName,URL[] urls, ScanFilter[] filters, boolean noIgnore) {
        return new URLScanSource(sourceName,urls, filters, noIgnore);
    }

    /**
     *
     * @param noIgnore
     * @return
     */
    @Override
    public ScanSource createContextScanSource(String sourceName,boolean noIgnore) {
        return new ContextScanSource(sourceName,noIgnore);
    }

    @Override
    public ScanSource createClassScanSource(String sourceName,Class[] classes, boolean noIgnore) {
        return new ClassesScanSource(sourceName,classes, noIgnore);
    }

    @Override
    public <T> Class[] getAlternatives(Class<T> type) {
        Set<Class> found = new LinkedHashSet<Class>(Arrays.asList(super.getAlternatives(type)));
        if (baseFactory != null) {
            found.addAll(Arrays.asList(baseFactory.getAlternatives(type)));
        }
        return found.toArray(new Class[found.size()]);
    }
}
