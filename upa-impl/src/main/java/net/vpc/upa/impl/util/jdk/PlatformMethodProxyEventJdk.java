package net.vpc.upa.impl.util.jdk;

import net.vpc.upa.PortabilityHint;

import java.lang.reflect.Method;
import net.vpc.upa.impl.util.PlatformMethodProxyEvent;

/**
 * Created by vpc on 8/6/15.
 */
@PortabilityHint(target = "C#", name = "suppress")
public class PlatformMethodProxyEventJdk<T> implements PlatformMethodProxyEvent<T> {

    private final T object;
    private final Object[] arguments;
    private final Method method;

    public PlatformMethodProxyEventJdk(T object, Object[] arguments, Method method) {
        this.object = object;
        this.arguments = arguments;
        this.method = method;
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
        return method.invoke(obj, args);
    }

    @Override
    public Object invokeSuper(T obj, Object[] args) throws Throwable {
        throw new IllegalArgumentException("Unsupported invokeSuper in PlatformMethodProxyEventJdk");
    }
}
