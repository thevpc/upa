package net.vpc.upa.impl.util;

import java.lang.reflect.Method;

/**
 * Created by vpc on 8/6/15.
 */
public interface PlatformMethodProxyEvent<T> {
    T getObject();
    Object[] getArguments();
    Method getMethod();
    String getMethodName();
    Object invokeBase(T obj, Object[] args) throws Throwable;
    Object invokeSuper(T obj, Object[] args) throws Throwable;
}
