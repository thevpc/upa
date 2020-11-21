/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.util.cglib;

import java.lang.reflect.Method;

import net.thevpc.upa.impl.util.PlatformMethodProxy;

/**
 *
 * @author vpc
 */
class ProxyMethodInterceptorCGLib implements net.sf.cglib.proxy.MethodInterceptor {
    
    private final PlatformMethodProxy pmethodProxy;

    public ProxyMethodInterceptorCGLib(PlatformMethodProxy pmethodProxy) {
        this.pmethodProxy = pmethodProxy;
    }

    @Override
    public Object intercept(Object object, Method method, Object[] args, net.sf.cglib.proxy.MethodProxy methodProxy) throws Throwable {
        return pmethodProxy.intercept(new PlatformMethodProxyEventCGLib(object, args, method, methodProxy));
    }
    
}
