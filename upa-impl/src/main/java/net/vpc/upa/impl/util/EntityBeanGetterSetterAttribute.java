package net.vpc.upa.impl.util;

import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;
import java.util.logging.Logger;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.types.I18NString;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/5/13 11:28 PM
 */
class EntityBeanGetterSetterAttribute extends AbstractEntityBeanAttribute {
    private static final Logger log=Logger.getLogger(EntityBeanGetterSetterAttribute.class.getName());
    private Method getter;
    private Method setter;
    private String fieldName;
    private Class fieldType;
    private boolean nullableType;
    private Object nullValue;
    private EntityPlatformBeanType entityBeanAdapter;

    EntityBeanGetterSetterAttribute(EntityPlatformBeanType entityBeanAdapter, String fieldName, Class fieldType,Class type) {
        super(entityBeanAdapter, fieldName, fieldType);
        this.entityBeanAdapter = entityBeanAdapter;
        this.fieldName = fieldName;
        this.fieldType = fieldType;
        this.nullableType = PlatformUtils.isNullableType(fieldType);
        this.nullValue = PlatformUtils.DEFAULT_VALUES_BY_TYPE.get(fieldType);
        getter = entityBeanAdapter.getMethod(type, PlatformUtils.getterName(fieldName, fieldType), fieldType);
        if (getter == null) {
            getter = entityBeanAdapter.getMethod(type, PlatformUtils.getterName(fieldName, fieldType), fieldType);
//            System.out.println("why");
        }
        if (getter != null) {
            getter.setAccessible(true);
        }
        setter = entityBeanAdapter.getMethod(type, PlatformUtils.setterName(fieldName), Void.TYPE, fieldType);
        if(setter==null){
            //check if this is a builder setter (that returns non void value)
            setter = entityBeanAdapter.getMethod(type, PlatformUtils.setterName(fieldName), null, fieldType);
            if(setter!=null){
                log.severe(fieldName+" has a non standard setter "+setter);
            }
        }
        if (setter != null) {
            setter.setAccessible(true);
        }
//        if (setter == null) {
//            System.out.println("why");
//        }
    }

    public boolean isValid(){
        return getter!=null || setter!=null;
    }
    
    @Override
    public Object getValue(Object o) {
        if (getter == null) {
            throw new RuntimeException("Field inaccessible : no getter found for field " + fieldName);
        }
        try {
            return getter.invoke(o,new Object[0]);
        } catch (Exception e) {
            if (e instanceof InvocationTargetException) {
                e = (Exception) ((InvocationTargetException) e).getTargetException();
            }
            if (e instanceof RuntimeException) {
                throw (RuntimeException) e;
            }
            throw new RuntimeException(e);
        }
    }

    @Override
    public void setValue(Object o, Object value) {
        if (setter == null) {
            throw new RuntimeException("Field " + fieldName + " is readonly : no setter found in "+entityBeanAdapter.getEntity().getName());
        }
        if(value==null && !nullableType){
            value=nullValue;
        }
        try {
            setter.invoke(o, value);
        } catch (Exception e) {
            if (e instanceof InvocationTargetException) {
                e = (Exception) ((InvocationTargetException) e).getTargetException();
            }
            throw new UPAException(e, new I18NString("UnableToSetFieldValue"), fieldName, entityBeanAdapter.getEntity(), setter);
//            if (e instanceof RuntimeException) {
//                throw (RuntimeException) e;
//            }
//            throw new RuntimeException(e);
//        } catch (IllegalArgumentException e) {
//            throw new IllegalArgumentException("Unable to set value for field " + field + ". Value was " + (value == null ? "null" : ("of type " + value.getClass())), e);
//        } catch (IllegalAccessException e) {
//            throw new RuntimeException("Unable to set value for field " + field + ". Value was " + (value == null ? "null" : ("of type " + value.getClass())), e);
//        } catch (InvocationTargetException e) {
//            Throwable targetException = e.getTargetException();
//            if (targetException instanceof RuntimeException) {
//                throw (RuntimeException) targetException;
//            }
//            throw new RuntimeException("Unable to set value for field " + field + ". Value was " + (value == null ? "null" : ("of type " + value.getClass())), targetException);
        }
    }
}
