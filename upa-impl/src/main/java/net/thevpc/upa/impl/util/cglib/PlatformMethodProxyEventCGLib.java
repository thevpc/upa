package net.thevpc.upa.impl.util.cglib;

import net.thevpc.upa.impl.util.PlatformMethodProxyEvent;
import net.thevpc.upa.PortabilityHint;

import java.lang.reflect.Method;

/**
 * Created by vpc on 8/6/15.
 */
@PortabilityHint(target = "C#", name = "suppress")
public class PlatformMethodProxyEventCGLib<T> implements PlatformMethodProxyEvent<T> {
    private final T object;
    private final Object[] arguments;
    private final Method method;
    net.sf.cglib.proxy.MethodProxy methodProxy;

    public PlatformMethodProxyEventCGLib(T object, Object[] arguments, Method method, net.sf.cglib.proxy.MethodProxy methodProxy) {
        this.object = object;
        this.arguments = arguments;
        this.method = method;
        this.methodProxy = methodProxy;
    }

    @Override
    public String getMethodName() {
        return method.getName();
    }

    @Override
    public Method getMethod() {
        return method;
    }

    @Override
    public T getObject() {
        return object;
    }

    @Override
    public Object[] getArguments() {
        return arguments;
    }

    @Override
    public Object invokeBase(T obj, Object[] args) throws Throwable {
        return methodProxy.invoke(obj,args);
    }

    @Override
    public Object invokeSuper(T obj, Object[] args) throws Throwable {
        return methodProxy.invokeSuper(obj,args);
    }
}
