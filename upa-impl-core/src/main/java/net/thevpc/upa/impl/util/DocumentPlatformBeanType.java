package net.thevpc.upa.impl.util;

import net.thevpc.upa.Document;
import net.thevpc.upa.PlatformBeanType;
import net.thevpc.upa.Entity;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.filters.ObjectFilter;
import net.thevpc.upa.impl.DefaultDocument;

import java.lang.reflect.Field;
import java.lang.reflect.Method;
import java.util.*;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/27/12 12:16 AM
 */
public class DocumentPlatformBeanType implements PlatformBeanType {

    private Set<String> propertyNames;
    private Entity entity;

    public DocumentPlatformBeanType(Entity entity) {
        this.entity = entity;
//        try {
//            entity.getEntityType().getConstructor().setAccessible(true);
//        } catch (NoSuchMethodException e) {
//            throw new UPAIllegalArgumentException("Unable to resolve default constructor for type " + entity.getEntityType() + " (entity " + entity.getName() + ")", e);
//        }
    }

    @Override
    public Class getPlatformType() {
        return Document.class;
    }

    public Entity getEntity() {
        return entity;
    }

    public Object newInstance() {
        return new DefaultDocument();
    }

    public boolean resetToDefaultValue(Object instance, String field) throws UPAException {
        Document r = (Document) instance;
        if(r.isSet(field)) {
            r.remove(field);
            return true;
        }
        return false;
    }

    public boolean isDefaultValue(Object o, String field) throws UPAException {
        Document r = (Document) o;
        return !r.isSet(field);
    }

    public Set<String> getPropertyNames() {
        if(propertyNames==null) {
            LinkedHashSet<String> t = new LinkedHashSet<String>();
            for (net.thevpc.upa.Field f : entity.getFields()) {
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
        Document r = (Document) o;
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

    public Object getPropertyValue(Object o, String field) {
        Document r = (Document) o;
        return r.getObject(field);
    }

    public boolean setPropertyValue(Object o, String property, Object value) {
        Document r = (Document) o;
        r.setObject(property, value);
        return true;
    }

    @Override
    public boolean containsProperty(String property) {
        return entity.containsField(property);
    }

    @Override
    public void inject(Object instance, String property, Object value) {
        Document r = (Document) instance;
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

    @Override
    public Class getPropertyType(String property) {
        return entity.getField(property).getDataType().getPlatformType();
    }
}
