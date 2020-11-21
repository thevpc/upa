/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.util.jdk;

import java.lang.reflect.InvocationHandler;
import java.lang.reflect.Method;

import net.thevpc.upa.impl.util.PlatformMethodProxy;

/**
 *
 * @author vpc
 */
class PlatformTypeProxyJavaJdkInvocationHandler implements InvocationHandler {
    
    private final PlatformMethodProxy pmethodProxy;

    public PlatformTypeProxyJavaJdkInvocationHandler(PlatformMethodProxy pmethodProxy) {
        this.pmethodProxy = pmethodProxy;
    }

    @Override
    public Object invoke(Object proxy, Method method, Object[] args) throws Throwable {
        return pmethodProxy.intercept(new PlatformMethodProxyEventJdk(proxy, args, method));
    }
    
}
