package net.vpc.upa.impl.util;

import net.vpc.upa.PlatformBeanType;
import net.vpc.upa.Entity;
import net.vpc.upa.Record;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.filters.ObjectFilter;
import net.vpc.upa.impl.DefaultRecord;

import java.lang.reflect.Field;
import java.lang.reflect.Method;
import java.util.*;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/27/12 12:16 AM
 */
public class RecordPlatformBeanType implements PlatformBeanType {

    private Set<String> propertyNames;
    private Entity entity;

    public RecordPlatformBeanType(Entity entity) {
        this.entity = entity;
//        try {
//            entity.getEntityType().getConstructor().setAccessible(true);
//        } catch (NoSuchMethodException e) {
//            throw new IllegalArgumentException("Unable to resolve default constructor for type " + entity.getEntityType() + " (entity " + entity.getName() + ")", e);
//        }
    }

    @Override
    public Class getPlatformType() {
        return Record.class;
    }

    public Entity getEntity() {
        return entity;
    }

    public Object newInstance() {
        return new DefaultRecord();
    }

    public boolean resetToDefaultValue(Object instance, String field) throws UPAException {
        Record r = (Record) instance;
        if(r.isSet(field)) {
            r.remove(field);
            return true;
        }
        return false;
    }

    public boolean isDefaultValue(Object o, String field) throws UPAException {
        Record r = (Record) o;
        return !r.isSet(field);
    }

    public Set<String> getPropertyNames() {
        if(propertyNames==null) {
            LinkedHashSet<String> t = new LinkedHashSet<String>();
            for (net.vpc.upa.Field f : entity.getFields()) {
                    t.add(f.getName());
            }
            propertyNames=t;
        }
        return Collections.unmodifiableSet(propertyNames);
    }

    public Set<String> keySet(Object o, Boolean includeDefaults) throws UPAException {
        LinkedHashSet<String> set = new LinkedHashSet<String>();
        if (includeDefaults == null) {
            set.addAll(getPropertyNames());
        } else {
            for (String k : getPropertyNames()) {
                if (includeDefaults == isDefaultValue(o, k)) {
                    set.add(k);
                }
            }
        }
        return set;
    }

    public Map<String, Object> toMap(Object o, Boolean includeDefaults) throws UPAException {
        Record r = (Record) o;
        LinkedHashMap<String, Object> map = new LinkedHashMap<String, Object>();
        if (includeDefaults == null) {
            for (String k : getPropertyNames()) {
                map.put(k, r.getObject(k));
            }
        } else {
            for (String k : getPropertyNames()) {
                if (includeDefaults == isDefaultValue(o, k)) {
                    map.put(k, r.getObject(k));
                }
            }
        }
        return map;
    }

    public Object getProperty(Object o, String field) {
        Record r = (Record) o;
        return r.getObject(field);
    }

    public boolean setProperty(Object o, String property, Object value) {
        Record r = (Record) o;
        r.setObject(property, o);
        return true;
    }

    @Override
    public boolean containsProperty(String property) {
        return entity.containsField(property);
    }

    @Override
    public void inject(Object instance, String property, Object value) {
        Record r = (Record) instance;
        if(entity.contains(property)) {
            r.setObject(property,value);
        }
    }

    @Override
    public Method getMethod(Class type, String name, Class ret, Class... args) {
        return null;
    }

    public Field findField(String name, ObjectFilter<Field> filter) {
        return null;
    }


    public Set<String> getPropertyNames(Object o, Boolean includeDefaults) throws UPAException {
        LinkedHashSet<String> set = new LinkedHashSet<String>();
        if (includeDefaults == null) {
            set.addAll(getPropertyNames());
        } else {
            for (String k : getPropertyNames()) {
                if (includeDefaults == isDefaultValue(o, k)) {
                    set.add(k);
                }
            }
        }
        return set;
    }


}
