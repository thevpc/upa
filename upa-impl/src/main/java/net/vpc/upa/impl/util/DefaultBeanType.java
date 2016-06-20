package net.vpc.upa.impl.util;

import net.vpc.upa.BeanType;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.filters.ObjectFilter;

import java.lang.reflect.Field;
import java.lang.reflect.Method;
import java.util.*;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/27/12 12:16 AM
 */
public class DefaultBeanType implements BeanType {

    private Class platformType;
    private Map<String, BeanAdapterAttribute> properties = new LinkedHashMap<String, BeanAdapterAttribute>();
    private Set<String> propertyNames;
    private Map<MethodSignature,Method> methods=new HashMap<MethodSignature, Method>();
    private Map<String,List<Field>> fields=new HashMap<String, List<Field>>();
    private boolean propertiesLoaded = false;
//    private Constructor constructor;

    public DefaultBeanType(Class platformType) {
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

    private BeanAdapterAttribute createAttrAdapter(String field) {
        String g1 = getterName(field, Object.class);
        String g2 = getterName(field, Boolean.TYPE);
        String s = setterName(field);
        Class<?> x = platformType;
        Method getter = null;
        Method setter = null;
        Class propertyType = null;
        LinkedHashMap<Class, Method> setters = new LinkedHashMap<Class, Method>();
        while (x != null) {
            for (Method m : x.getDeclaredMethods()) {
                if (!PlatformUtils.isStatic(m)) {
                    String mn = m.getName();
                    if (getter == null) {
                        if (g1.equals(mn) || g2.equals(mn)) {
                            if (m.getParameterTypes().length == 0 && !Void.TYPE.equals(m.getReturnType())) {
                                getter = m;
                                Class<?> ftype = getter.getReturnType();
                                for (Class key : new HashSet<Class>(setters.keySet())) {
                                    if (!key.equals(ftype)) {
                                        setters.remove(key);
                                    }
                                }
                                if (setter == null) {
                                    setter = setters.get(ftype);
                                }
                            }
                        }
                    }
                    if (setter == null) {
                        if (s.equals(mn)) {
                            if (m.getParameterTypes().length == 1) {
                                Class<?> stype = m.getParameterTypes()[0];
                                if (getter != null) {
                                    Class<?> gtype = getter.getReturnType();
                                    if (gtype.equals(stype)) {
                                        if (!setters.containsKey(stype)) {
                                            setters.put(stype, m);
                                        }
                                        if (setter == null) {
                                            setter = m;
                                        }
                                    }
                                } else {
                                    if (!setters.containsKey(stype)) {
                                        setters.put(stype, m);
                                    }
                                }
                            }
                        }
                    }
                    if (getter != null && setter != null) {
                        break;
                    }
                }
            }
            if (getter != null && setter != null) {
                break;
            }
            x = x.getSuperclass();
        }
        if (getter != null) {
            propertyType = getter.getReturnType();
        }
        if (getter == null && setter == null && setters.size() > 0) {
            Method[] settersArray = setters.values().toArray(new Method[setters.size()]);
            setter = settersArray[0];
            if (settersArray.length > 1) {
                //TODO log?
            }
        }
        if (getter == null && setter != null && propertyType == null) {
            propertyType = setter.getParameterTypes()[0];
        }
        if (getter != null || setter != null) {
            return new BeanAdapterGetterSetterAttribute(field, propertyType, getter, setter);
        }
        return null;
    }

    /**
     * @param field
     * @return
     */
    public BeanAdapterAttribute getAttrAdapter(String field) {
        BeanAdapterAttribute f = properties.get(field);
        if (f == null) {
            f = createAttrAdapter(field);
            if (f != null) {
                if (((BeanAdapterGetterSetterAttribute) f).getSetter() == null) {
                    f = createAttrAdapter(field);
                }
            }
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
                method = getMethod00(type, name, ret, args);
                methods.put(key, method);
            }
        }
        return method;
    }
    public Method getMethod00(Class type, String name, Class ret, Class... args) {
        try {
            Method method = type.getMethod(name, args);
            if (ret == null || method.getReturnType().equals(ret)) {
                return method;
            }
        } catch (NoSuchMethodException ignored) {
        }
        Class s = type.getSuperclass();
        if (s != null) {
            return getMethod00(s, name, ret, args);
        }
        return null;
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
                BeanAdapterAttribute e = getAttrAdapter(k);
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
        BeanAdapterAttribute attrAdapter = getAttrAdapter(property);
        return attrAdapter != null;

    }

    public Object getProperty(Object o, String field) {
        BeanAdapterAttribute attrAdapter = getAttrAdapter(field);
        if (attrAdapter != null) {
            return attrAdapter.getValue(o);
        }
        return null;
    }

    public void injectNull(Object instance,String property) {
        inject(instance, property, (Object) null);
    }

    public void inject(Object instance, String property, Object value) {
        BeanAdapterAttribute attrAdapter = getAttrAdapter(property);
        if (attrAdapter != null) {
            attrAdapter.setValue(instance, value);
        } else {
            System.err.println("inject " + property + " into " + instance.getClass() + " failed.");
        }
    }

    public boolean setProperty(Object instance, String property, Object value) {
        BeanAdapterAttribute attrAdapter = getAttrAdapter(property);
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

    public static String getterName(String field, Class type) {
        if (Boolean.TYPE.equals(type)) {
            return "is" + suffix(field);
        }
        return "get" + suffix(field);
    }

    public static String setterName(String field) {
        return "set" + suffix(field);
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
        BeanAdapterAttribute attrAdapter = getAttrAdapter(field);
        if (attrAdapter != null) {
            attrAdapter.setValue(instance, attrAdapter.getDefaultValue());
            return true;
        } else {
            return false;
        }
    }

    @Override
    public boolean isDefaultValue(Object instance, String field) {
        BeanAdapterAttribute attrAdapter = getAttrAdapter(field);
        if(attrAdapter!=null){
            return attrAdapter.isDefaultValue(instance);
        }
        return false;
    }

    public Map<String, Object> toMap(Object o, Boolean includeDefaults) throws UPAException {
        LinkedHashMap<String, Object> map = new LinkedHashMap<String, Object>();
        if (includeDefaults == null) {
            for (String k : getPropertyNames()) {
                BeanAdapterAttribute e = getAttrAdapter(k);
                map.put(k, e.getValue(o));
            }
        } else {
            for (String k : getPropertyNames()) {
                BeanAdapterAttribute e = getAttrAdapter(k);
                if (includeDefaults == e.isDefaultValue(o)) {
                    map.put(k, e.getValue(o));
                }
            }
        }
        return map;
    }
}
