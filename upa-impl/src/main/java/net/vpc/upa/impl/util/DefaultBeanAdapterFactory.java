/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.util;

import net.vpc.upa.BeanAdapter;
import net.vpc.upa.BeanAdapterFactory;

/**
 *
 * @author vpc
 */
public class DefaultBeanAdapterFactory implements BeanAdapterFactory {

    public BeanAdapter createBeanAdapter(Object instance) {
        return new DefaultBeanAdapter(instance);
    }

    public BeanAdapter createBeanAdapter(Class type) {
        return new DefaultBeanAdapter(type);
    }

}
