package net.vpc.upa.impl.util;

import java.lang.reflect.Method;

public class PlatformMethodInfo {
    private Method method;
    private PlatformMethodType methodType;
    private String propertyName;
    private Class propertyType;

    public PlatformMethodInfo(Method method, PlatformMethodType methodType, String propertyName,Class propertyType) {
        this.method = method;
        this.methodType = methodType;
        this.propertyName = propertyName;
        this.propertyType = propertyType;
    }

    public Class getPropertyType() {
        return propertyType;
    }

    public Method getMethod() {
        return method;
    }

    public PlatformMethodType getMethodType() {
        return methodType;
    }

    public String getPropertyName() {
        return propertyName;
    }
}
