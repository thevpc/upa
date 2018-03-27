/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.config;

import net.vpc.upa.Action;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.util.PlatformMethodProxyEvent;
import net.vpc.upa.types.I18NString;

/**
 * @author taha.bensalah@gmail.com
 */
class MakeSessionAwareMethodInterceptor2Action<T> implements Action<Object> {

    private final PlatformMethodProxyEvent<T> methodProxy;

    public MakeSessionAwareMethodInterceptor2Action(PlatformMethodProxyEvent<T> methodProxy) {
        this.methodProxy = methodProxy;
    }

    public Object run() {
        try {
            return methodProxy.invokeBase(methodProxy.getObject(), methodProxy.getArguments());
        } catch (Throwable ex) {
            throw new UPAException(ex, new I18NString("InvokeError"));
        }
    }

}
