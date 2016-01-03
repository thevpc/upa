package net.vpc.upa.impl.util;

import java.lang.reflect.Method;
import java.util.*;
import net.vpc.upa.BeanAdapter;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/27/12 12:16 AM
 */
public class DefaultBeanAdapter implements BeanAdapter {

    private Class cls;
    private Object instance;
    private Map<String, BeanAdapterAttribute> fields = new LinkedHashMap<String, BeanAdapterAttribute>();
    private boolean fieldsLoaded = false;

    public DefaultBeanAdapter(Object obj) {
        this(obj.getClass());
        this.instance = obj;
    }

    public DefaultBeanAdapter(Class cls) {
        this.cls = cls;
    }

    public Object newInstance() {
        try {
            cls.getConstructor().setAccessible(true);
        } catch (NoSuchMethodException e) {
            throw new IllegalArgumentException(e);
        }
        try {
            return instance = cls.newInstance();
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
        Class<?> x = cls;
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
        BeanAdapterAttribute f = fields.get(field);
        if (f == null) {
            f = createAttrAdapter(field);
            if (f != null) {
                if (((BeanAdapterGetterSetterAttribute) f).getSetter() == null) {
                    f = createAttrAdapter(field);
                }
            }
            if (f != null) {
                fields.put(field, f);
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
        loadFields();
        return new ArrayList<String>(fields.keySet());
    }

    private void loadFields() {
        if (!fieldsLoaded) {
            fieldsLoaded = true;
            for (Method method : cls.getMethods()) {
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
    //            for (Map.Entry<String, BeanAdapterAttribute> e : fields.entrySet()) {
    //                set.add(e.getKey());
    //            }
    //        } else {
    //            for (Map.Entry<String, BeanAdapterAttribute> e : fields.entrySet()) {
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
    //            for (Map.Entry<String, BeanAdapterAttribute> e : fields.entrySet()) {
    //                set.put(e.getKey(), e.getValue().getValue(o));
    //            }
    //        } else {
    //            for (Map.Entry<String, BeanAdapterAttribute> e : fields.entrySet()) {
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

    public Object getProperty(String field) {
        return getProperty(instance, field);
    }

    public Object getProperty(Object o, String field) {
        BeanAdapterAttribute attrAdapter = getAttrAdapter(field);
        if (attrAdapter != null) {
            return attrAdapter.getValue(o);
        }
        return null;
    }

    public void injectNull(String property) {
        inject(instance, property, (Object) null);
    }

    public void setProperty(String property, Object value) {
        inject(instance, property, value);
    }

    public void inject(Object o, String property, Object value) {
        BeanAdapterAttribute attrAdapter = getAttrAdapter(property);
        if (attrAdapter != null) {
            attrAdapter.setValue(o, value);
        } else {
            System.err.println("inject " + property + " into " + o.getClass() + " failed.");
        }
    }

    public <R> void setProperty(Object o, String property, R value) {
        BeanAdapterAttribute attrAdapter = getAttrAdapter(property);
        if (attrAdapter != null) {
            attrAdapter.setValue(o, value);
        } else {
            throw new NoSuchElementException("Property not found " + property);
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
}
