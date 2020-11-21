package net.thevpc.upa.impl.util;

import net.thevpc.upa.PlatformBeanType;

import java.util.logging.Level;
import java.util.logging.Logger;

/**
 * Created by vpc on 5/17/16.
 */
public class PlatformLenientType implements LenientType {
    private final String typeName;
    private Class platformType;
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
        if (platformType == null) {
            try {
                platformType = Class.forName(typeName);
                log.log(Level.INFO, "Lenient Type {0} loaded successfully", typeName);
            } catch (ClassNotFoundException e) {
//                e.printStackTrace();
                platformType = Void.TYPE;
                log.log(Level.SEVERE, "Lenient Type {0} was unable to load : {1}", new Object[]{typeName, e});
            }
        }
        if (Void.TYPE.equals(platformType)) {
            return null;
        }
        return platformType;
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
