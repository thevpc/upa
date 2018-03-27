package net.vpc.upa.impl.util;

import net.vpc.upa.PlatformBeanProperty;
import net.vpc.upa.PlatformBeanType;
import net.vpc.upa.PropertyAccessType;

import java.util.logging.Level;
import java.util.logging.Logger;

/**
 * Created by vpc on 5/17/16.
 */
public class PlatformLenientType implements LenientType {
    private String typeName;
    private Class type;
    private static final Logger log = Logger.getLogger(PlatformLenientType.class.getName());

    public PlatformLenientType(String typeName) {
        this.typeName = typeName;
    }

    public String getTypeName() {
        return typeName;
    }

    public boolean isValid() {
        return getValidType() != null;
    }

    public Class getValidTypeOrError() {
        Class c = getValidType();
        if (c == null) {
            throw new RuntimeException("Invalid Type");
        }
        return c;
    }

    public Class getValidType() {
        if (type == null) {
            try {
                type = Class.forName(typeName);
                log.log(Level.INFO, "Lenient Type " + typeName + " loaded successfully");
            } catch (ClassNotFoundException e) {
//                e.printStackTrace();
                type = Void.TYPE;
                log.log(Level.SEVERE, "Lenient Type " + typeName + " was unable to load : " + e);
            }
        }
        if (Void.TYPE.equals(type)) {
            return null;
        }
        return type;
    }

    public Object newInstance() {
        try {
            return PlatformUtils.newInstance(getValidTypeOrError());
        } catch (Exception e) {
            throw PlatformUtils.createRuntimeException(e);
        }
    }

    public void setPropertyAsString(Object instance, String propertyName, String value) {
        getValidTypeOrError();
        Object ovalue = value;
        PlatformBeanType beanType = PlatformUtils.getBeanType(instance.getClass());
        if (value != null) {
            ovalue = UPAUtils.createValue(value, beanType.getPropertyType(propertyName), null);
        }
        beanType.setPropertyValue(instance, propertyName, ovalue);
    }

    public void setProperty(Object instance, String propertyName, Object value) {
        getValidTypeOrError();
        PlatformUtils.getBeanType(instance.getClass()).setPropertyValue(instance, propertyName, value);
    }

    public Object invokeInstance(Object instance, String method, Class[] types, Object[] args) {
        try {
            return getValidTypeOrError().getMethod(method, types).invoke(instance, args);
        } catch (Exception e) {
            throw PlatformUtils.createRuntimeException(e);
        }
    }

    public Object invokeStatic(String method, Class[] types, Object[] args) {
        try {
            return getValidTypeOrError().getMethod(method, types).invoke(null, args);
        } catch (Exception e) {
            throw PlatformUtils.createRuntimeException(e);
        }
    }
}
