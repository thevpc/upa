/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl;

import net.thevpc.upa.impl.util.DefaultBeanAdapter;
import net.thevpc.upa.BeanAdapter;
import net.thevpc.upa.BeanAdapterFactory;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class DefaultBeanAdapterFactory implements BeanAdapterFactory {

    public BeanAdapter createBeanAdapter(Object instance) {
        return new DefaultBeanAdapter(instance);
    }

    public BeanAdapter createBeanAdapter(Class type) {
        return new DefaultBeanAdapter(type);
    }

}
