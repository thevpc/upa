package net.vpc.upa.impl.util;

import java.lang.reflect.Method;

/**
 * Created by vpc on 8/6/15.
 */
public interface PlatformMethodProxyEvent<T> {
    public T getObject();
    public Object[] getArguments();
    public Method getMethod();
    public String getMethodName();
    public Object invokeBase(T obj,Object[] args) throws Throwable;
}
