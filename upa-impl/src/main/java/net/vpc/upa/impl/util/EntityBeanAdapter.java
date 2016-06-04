package net.vpc.upa.impl.util;

import net.vpc.upa.Entity;
import net.vpc.upa.exceptions.UPAException;

import java.lang.reflect.Field;
import java.lang.reflect.Method;
import java.util.*;
import net.vpc.upa.PropertyAccessType;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/27/12 12:16 AM
 */
public class EntityBeanAdapter {

    private Class cls;
    private Map<String, EntityBeanAttribute> fields = new LinkedHashMap<String, EntityBeanAttribute>();
    private Entity entity;

    public EntityBeanAdapter(Class cls, Entity entity) {
        this.cls = cls;
        this.entity = entity;
        try {
            cls.getConstructor().setAccessible(true);
        } catch (NoSuchMethodException e) {
            throw new IllegalArgumentException("Unable to resolve default constructor for type " + cls + " (entity " + entity.getName() + ")", e);
        }
    }

    public Entity getEntity() {
        return entity;
    }

    public Object newInstance() {
        try {
            return cls.newInstance();
        } catch (Exception e) {
            Throwable c = e.getCause();
            if (c instanceof RuntimeException) {
                throw (RuntimeException) c;
            }
            throw new RuntimeException(c);
        }
    }

    public EntityBeanAttribute getAttrAdapter(String field) {
        EntityBeanAttribute r = fields.get(field);
        if (r != null) {
            return r;
        }
        net.vpc.upa.Field f = entity.getField(field);
        PropertyAccessType propertyAccessType = f.getPropertyAccessType();
        if (propertyAccessType == null) {
            propertyAccessType = PropertyAccessType.PROPERTY;
        }
        if (propertyAccessType == PropertyAccessType.FIELD) {
            Field ff = PlatformUtils.findField(cls, f.getName(), BeanFieldFilter.INSTANCE);
            if (ff != null) {
                r = new EntityBeanFieldAttribute(this, ff, cls);
                fields.put(field, r);
            }
        } else {
            EntityBeanGetterSetterAttribute a = new EntityBeanGetterSetterAttribute(this, field, f.getDataType().getPlatformType(), cls);
            if (a.isValid()) {
                r = a;
                fields.put(field, r);
            }
        }
        return r;
    }

    public boolean resetToDefaultValue(Object o, String field) throws UPAException {
        EntityBeanAttribute attrAdapter = getAttrAdapter(field);
        if (attrAdapter != null) {
            attrAdapter.setValue(o, attrAdapter.getDefaultValue());
            return true;
        } else {
            return false;
        }
    }

    public boolean isDefaultValue(Object o, String field) throws UPAException {
        EntityBeanAttribute attrAdapter = getAttrAdapter(field);
        return attrAdapter.isDefaultValue(o);
    }

    public Method getMethod(Class type, String name, Class ret, Class... args) {
        try {
            Method method = type.getMethod(name, args);
            if (ret == null || method.getReturnType().equals(ret)) {
                return method;
            }
        } catch (NoSuchMethodException ignored) {
        }
        Class s = type.getSuperclass();
        if (s != null) {
            return getMethod(s, name, ret, args);
        }
        return null;
    }

    public List<String> getFieldNames() {
        List<String> t = new ArrayList<String>();
        for (net.vpc.upa.Field f : entity.getFields()) {
            if (getAttrAdapter(f.getName()) != null) {
                t.add(f.getName());
            }
        }
        return t;
    }

    public Set<String> keySet(Object o, Boolean includeDefaults) throws UPAException {
        LinkedHashSet<String> set = new LinkedHashSet<String>();
        if (includeDefaults == null) {
            set.addAll(getFieldNames());
        } else {
            for (String k : getFieldNames()) {
                EntityBeanAttribute e = getAttrAdapter(k);
                if (includeDefaults == e.isDefaultValue(o)) {
                    set.add(k);
                }
            }
        }
        return set;
    }

    public Map<String, Object> toMap(Object o, Boolean includeDefaults) throws UPAException {
        LinkedHashMap<String, Object> map = new LinkedHashMap<String, Object>();
        if (includeDefaults == null) {
            for (String k : getFieldNames()) {
                EntityBeanAttribute e = getAttrAdapter(k);
                map.put(k, e.getValue(o));
            }
        } else {
            for (String k : getFieldNames()) {
                EntityBeanAttribute e = getAttrAdapter(k);
                if (includeDefaults == e.isDefaultValue(o)) {
                    map.put(k, e.getValue(o));
                }
            }
        }
        return map;
    }

    public <R> R getProperty(Object o, String field) {
        EntityBeanAttribute attrAdapter = getAttrAdapter(field);
        if (attrAdapter != null) {
            return (R) attrAdapter.getValue(o);
        }
        return null;
    }

    public <R> boolean setProperty(Object o, String field, R value) {
        EntityBeanAttribute attrAdapter = getAttrAdapter(field);
        if (attrAdapter != null) {
            attrAdapter.setValue(o, value);
            return true;
        }
        return false;
    }

    public <R> R getPropertyDefaultValue(String field) throws UPAException {
        EntityBeanAttribute attrAdapter = getAttrAdapter(field);
        return (R) attrAdapter.getDefaultValue();
    }

    public static boolean isTypeDefaultValue(Class c, Object v) {
        Object t = PlatformUtils.DEFAULT_VALUES_BY_TYPE.get(c);
        if (t == null) {
            return v == null;
        }
        return t.equals(v);
    }

    public static String getterName(Field field) {
        return PlatformUtils.getterName(field.getName(), field.getType());
    }

    public static String setterName(Field field) {
        return PlatformUtils.setterName(field.getName());
    }

    Class getCls() {
        return cls;
    }

    Map<String, EntityBeanAttribute> getFields() {
        return fields;
    }
}
