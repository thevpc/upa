package net.vpc.upa.impl.util;

import net.vpc.upa.PlatformBeanProperty;
import net.vpc.upa.PlatformBeanType;
import net.vpc.upa.Entity;
import net.vpc.upa.PropertyAccessType;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.exceptions.UPAIllegalArgumentException;
import net.vpc.upa.filters.ObjectFilter;

import java.lang.reflect.Field;
import java.lang.reflect.Method;
import java.util.*;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/27/12 12:16 AM
 */
public class EntityPlatformBeanType implements PlatformBeanType {

    private PlatformBeanTypeCache platformPlatformBeanType;
    private Map<String, EntityBeanAttribute> fields = new LinkedHashMap<String, EntityBeanAttribute>();
    private Set<String> propertyNames;
    private Entity entity;

    public EntityPlatformBeanType(Entity entity) {
        this.platformPlatformBeanType = PlatformUtils.getBeanType(entity.getEntityType());
        this.entity = entity;
        try {
            entity.getEntityType().getConstructor().setAccessible(true);
        } catch (NoSuchMethodException e) {
            throw new UPAIllegalArgumentException("Unable to resolve default constructor for type " + entity.getEntityType() + " (entity " + entity.getName() + ")", e);
        }
        for (net.vpc.upa.Field field : entity.getFields()) {
            getAttrAdapter(field.getName());
        }
    }

    @Override
    public Class getPropertyType(String property) {
        return entity.getField(property).getDataType().getPlatformType();
    }

    @Override
    public Class getPlatformType() {
        return entity.getEntityType();
    }

    public Entity getEntity() {
        return entity;
    }

    public Object newInstance() {
        return platformPlatformBeanType.newInstance();
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
            Field ff = PlatformUtils.findField(entity.getEntityType(), f.getName(), BeanFieldFilter.INSTANCE);
            if (ff != null) {
                r = new EntityBeanFieldAttribute(this, ff, entity.getEntityType());
                fields.put(field, r);
            }
        } else {
            EntityBeanGetterSetterAttribute a = new EntityBeanGetterSetterAttribute(this, field, f.getDataType().getPlatformType(), entity.getEntityType());
            if (a.isValid()) {
                r = a;
                fields.put(field, r);
            }
        }
        return r;
    }

    public boolean resetToDefaultValue(Object instance, String field) throws UPAException {
        EntityBeanAttribute attrAdapter = getAttrAdapter(field);
        if (attrAdapter != null) {
            attrAdapter.setValue(instance, attrAdapter.getDefaultValue());
            return true;
        } else {
            return false;
        }
    }

    public boolean isDefaultValue(Object o, String field) throws UPAException {
        EntityBeanAttribute attrAdapter = getAttrAdapter(field);
        if (attrAdapter != null) {
            return attrAdapter.isDefaultValue(o);
        }
        return false;
    }

    public Set<String> getPropertyNames() {
        if (propertyNames == null) {
            LinkedHashSet<String> t = new LinkedHashSet<String>();
            for (net.vpc.upa.Field f : entity.getFields()) {
                if (getAttrAdapter(f.getName()) != null) {
                    t.add(f.getName());
                }
            }
            propertyNames = t;
        }
        return Collections.unmodifiableSet(propertyNames);
    }

    public Set<String> getPropertyNames(Object o, Boolean includeDefaults) throws UPAException {
        LinkedHashSet<String> set = new LinkedHashSet<String>();
        if (includeDefaults == null) {
            set.addAll(getPropertyNames());
        } else {
            for (String k : getPropertyNames()) {
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
            for (String k : getPropertyNames()) {
                EntityBeanAttribute e = getAttrAdapter(k);
                map.put(k, e.getValue(o));
            }
        } else {
            for (String k : getPropertyNames()) {
                EntityBeanAttribute e = getAttrAdapter(k);
                if (includeDefaults == e.isDefaultValue(o)) {
                    map.put(k, e.getValue(o));
                }
            }
        }
        return map;
    }

    public Object getPropertyValue(Object o, String field) {
        EntityBeanAttribute attrAdapter = getAttrAdapter(field);
        if (attrAdapter != null) {
            return attrAdapter.getValue(o);
        }
        return null;
    }

    public boolean setPropertyValue(Object o, String field, Object value) {
        EntityBeanAttribute attrAdapter = getAttrAdapter(field);
        if (attrAdapter != null) {
            attrAdapter.setValue(o, value);
            return true;
        }
        return false;
    }

    @Override
    public boolean containsProperty(String property) {
        return getPropertyNames().contains(property);
    }

    @Override
    public void inject(Object instance, String property, Object value) {
        EntityBeanAttribute a = getAttrAdapter(property);
        if (a != null) {
            a.setValue(instance, value);
        }
    }

    @Override
    public Method getMethod(Class type, String name, Class ret, Class... args) {
        return platformPlatformBeanType.getMethod(type, name, ret, args);
    }

//    public Field findField(String name, ObjectFilter<Field> filter) {
//        return platformPlatformBeanType.findField(name, filter);
//    }
}
