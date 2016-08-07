package net.vpc.upa.impl.util;

import net.vpc.upa.PlatformBeanType;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.filters.ObjectFilter;

import java.lang.reflect.Field;
import java.lang.reflect.Method;
import java.util.*;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/27/12 12:16 AM
 */
public class DefaultPlatformBeanType implements PlatformBeanType {
    private static final Logger log = Logger.getLogger(DefaultPlatformBeanType.class.getName());

    private Class platformType;
    private Map<String, PlatformBeanProperty> properties = new LinkedHashMap<String, PlatformBeanProperty>();
    private Set<String> propertyNames;
    private Map<MethodSignature,Method> methods=new HashMap<MethodSignature, Method>();
    private Map<String,List<Field>> fields=new HashMap<String, List<Field>>();
    private boolean propertiesLoaded = false;
//    private Constructor constructor;

    public DefaultPlatformBeanType(Class platformType) {
        this.platformType = platformType;
    }

    @Override
    public Class getPlatformType() {
        return platformType;
    }

    public Object newInstance() {
//        try {
//            if(constructor==null) {
//                constructor = platformType.getConstructor();
//                constructor.setAccessible(true);
//            }
//        } catch (NoSuchMethodException e) {
//            throw new IllegalArgumentException(e);
//        }
        try {
            return platformType.newInstance();
        } catch (Exception e) {
            Throwable c = e.getCause();
            if (c instanceof RuntimeException) {
                throw (RuntimeException) c;
            }
            throw new RuntimeException(c);
        }
    }



    /**
     * @param field
     * @return
     */
    public PlatformBeanProperty getAttrAdapter(String field) {
        PlatformBeanProperty f = properties.get(field);
        if (f == null) {
            f = PlatformUtils.findPlatformBeanProperty(field, platformType);
            if (f != null) {
                properties.put(field, f);
            }
        }
        return f;
    }

    //    public <R> void resetToDefaultValue(T o, String field) throws UPAException{
//        BeanAdapterAttribute<R> attrAdapter = getAttrAdapter(field);
//        attrAdapter.setValue(o, attrAdapter.getDefaultValue());
//    }
//
//    public <R> boolean isDefaultValue(T o, String field) throws UPAException{
//        BeanAdapterAttribute<R> attrAdapter = getAttrAdapter(field);
//        return attrAdapter.isDefaultValue(o);
//    }
    public Method getMethod(Class type, String name, Class ret, Class... args) {
        MethodSignature key = new MethodSignature(name, args);
        Method method = methods.get(key);
        if(method==null){
            if(!methods.containsKey(key)) {
                method = PlatformUtils.findPlatformMethod(type, name, ret, args);
                methods.put(key, method);
            }
        }
        return method;
    }


    public Set<String> getPropertyNames() {
        if(propertyNames==null) {
            loadProperties();
            propertyNames=Collections.unmodifiableSet(properties.keySet());
        }
        return propertyNames;
    }

    public Set<String> getPropertyNames(Object o, Boolean includeDefaults) throws UPAException {
        LinkedHashSet<String> set = new LinkedHashSet<String>();
        if (includeDefaults == null) {
            set.addAll(getPropertyNames());
        } else {
            for (String k : getPropertyNames()) {
                PlatformBeanProperty e = getAttrAdapter(k);
                if (includeDefaults == e.isDefaultValue(o)) {
                    set.add(k);
                }
            }
        }
        return set;
    }


    private void loadProperties() {
        if (!propertiesLoaded) {
            propertiesLoaded = true;
            for (Method method : platformType.getMethods()) {
                if (!method.getDeclaringClass().equals(Object.class)) {
                    String n = method.getName();
                    if (n.length() > 2) {
                        if (n.startsWith("is") && Character.isUpperCase(n.charAt(2))) {
                            String fieldName = Character.toLowerCase(n.charAt(2)) + n.substring(3);
                            getAttrAdapter(fieldName);
                        } else if (n.length() > 3) {
                            if ((n.startsWith("get") || n.startsWith("set")) && Character.isUpperCase(n.charAt(3))) {
                                String fieldName = Character.toLowerCase(n.charAt(3)) + n.substring(4);
                                getAttrAdapter(fieldName);
                            }

                        }
                    }
                }
            }
        }
    }

    //    public Set<String> keySet(T o, Boolean includeDefaults) throws UPAException{
    //        LinkedHashSet<String> set = new LinkedHashSet<String>();
    //        if (includeDefaults == null) {
    //            for (Map.Entry<String, BeanAdapterAttribute> e : properties.entrySet()) {
    //                set.add(e.getKey());
    //            }
    //        } else {
    //            for (Map.Entry<String, BeanAdapterAttribute> e : properties.entrySet()) {
    //                if (includeDefaults == e.getValue().isDefaultValue(o)) {
    //                    set.add(e.getKey());
    //                }
    //            }
    //        }
    //        return set;
    //    }
    //
    //    public Map<String, Object> toMap(T o, Boolean includeDefaults) throws UPAException{
    //        LinkedHashMap<String, Object> set = new LinkedHashMap<String, Object>();
    //        if (includeDefaults == null) {
    //            for (Map.Entry<String, BeanAdapterAttribute> e : properties.entrySet()) {
    //                set.put(e.getKey(), e.getValue().getValue(o));
    //            }
    //        } else {
    //            for (Map.Entry<String, BeanAdapterAttribute> e : properties.entrySet()) {
    //                if (includeDefaults == e.getValue().isDefaultValue(o)) {
    //                    set.put(e.getKey(), e.getValue().getValue(o));
    //                }
    //            }
    //        }
    //        return set;
    //    }
    public boolean containsProperty(String property) {
        PlatformBeanProperty attrAdapter = getAttrAdapter(property);
        return attrAdapter != null;

    }

    public Object getProperty(Object o, String field) {
        PlatformBeanProperty attrAdapter = getAttrAdapter(field);
        if (attrAdapter != null) {
            return attrAdapter.getValue(o);
        }
        return null;
    }

    public void injectNull(Object instance,String property) {
        inject(instance, property, (Object) null);
    }

    public void inject(Object instance, String property, Object value) {
        PlatformBeanProperty attrAdapter = getAttrAdapter(property);
        if (attrAdapter != null) {
            attrAdapter.setValue(instance, value);
        } else {
            log.log(Level.WARNING, "inject " + property + " into " + instance.getClass() + " failed.");
        }
    }

    public boolean setProperty(Object instance, String property, Object value) {
        PlatformBeanProperty attrAdapter = getAttrAdapter(property);
        if (attrAdapter != null) {
            attrAdapter.setValue(instance, value);
            return true;
        } else {
            return false;
        }
    }

    public static boolean isTypeDefaultValue(Class c, Object v) {
        Object t = PlatformUtils.DEFAULT_VALUES_BY_TYPE.get(c);
        if (t == null) {
            return v == null;
        }
        return t.equals(v);
    }



    public static String suffix(String s) {
        char[] chars = s.toCharArray();
        chars[0] = Character.toUpperCase(chars[0]);
        return new String(chars);
    }

    public Field findField(String name, ObjectFilter<Field> filter) {
        List<Field> fieldsList = fields.get(name);
        if(fieldsList==null){
            if(!fields.containsKey(name)) {
                fieldsList = PlatformUtils.findFields(platformType, name);
                if(fieldsList.size()>0) {
                    fields.put(name, fieldsList);
                }else{
                    fields.put(name, null);
                }
            }
        }
        if(filter==null){
            return fieldsList.get(0);
        }
        for (Field field : fieldsList) {
            if(filter.accept(field)){
                return field;
            }
        }
        return null;
    }

    public boolean resetToDefaultValue(Object instance, String field) throws UPAException {
        PlatformBeanProperty attrAdapter = getAttrAdapter(field);
        if (attrAdapter != null) {
            attrAdapter.setValue(instance, attrAdapter.getDefaultValue());
            return true;
        } else {
            return false;
        }
    }

    @Override
    public boolean isDefaultValue(Object instance, String field) {
        PlatformBeanProperty attrAdapter = getAttrAdapter(field);
        if(attrAdapter!=null){
            return attrAdapter.isDefaultValue(instance);
        }
        return false;
    }

    public Map<String, Object> toMap(Object o, Boolean includeDefaults) throws UPAException {
        LinkedHashMap<String, Object> map = new LinkedHashMap<String, Object>();
        if (includeDefaults == null) {
            for (String k : getPropertyNames()) {
                PlatformBeanProperty e = getAttrAdapter(k);
                map.put(k, e.getValue(o));
            }
        } else {
            for (String k : getPropertyNames()) {
                PlatformBeanProperty e = getAttrAdapter(k);
                if (includeDefaults == e.isDefaultValue(o)) {
                    map.put(k, e.getValue(o));
                }
            }
        }
        return map;
    }
}
