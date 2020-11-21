/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl;

import java.net.URL;
import java.util.*;

import net.thevpc.upa.impl.config.ClassesScanSource;
import net.thevpc.upa.impl.config.ContextScanSource;
import net.thevpc.upa.impl.config.URLScanSource;
import net.thevpc.upa.AbstractObjectFactory;
import net.thevpc.upa.ObjectFactory;
import net.thevpc.upa.UPAContextFactory;
import net.thevpc.upa.config.ScanFilter;
import net.thevpc.upa.config.ScanSource;

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
    public ScanSource createURLScanSource(URL[] urls, ScanFilter[] filters) {
        return new URLScanSource(urls, filters);
    }

    /**
     * @return
     */
    @Override
    public ScanSource createContextScanSource() {
        return new ContextScanSource();
    }

    @Override
    public ScanSource createClassScanSource(Class[] classes) {
        return new ClassesScanSource(classes);
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
