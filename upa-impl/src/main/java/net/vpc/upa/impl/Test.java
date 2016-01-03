/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl;

import net.vpc.upa.MethodFilter;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.config.MakeSessionAwareMethodInterceptor;
import net.vpc.upa.impl.util.PlatformUtils;

import java.util.List;

/**
 *
 * @author vpc
 */
public class Test {
    public <T> T makeSessionAware(final T instance, final MethodFilter methodFilter) throws UPAException {
        return (T) PlatformUtils.createObjectInterceptor(
                (Class<T>) instance.getClass(),
                new MakeSessionAwareMethodInterceptor(null, methodFilter, instance));
    }
}
