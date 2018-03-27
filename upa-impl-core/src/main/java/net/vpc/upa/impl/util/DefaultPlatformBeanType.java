//package net.vpc.upa.impl.util;
//
//import net.vpc.upa.PlatformBeanProperty;
//import net.vpc.upa.PlatformBeanType;
//import net.vpc.upa.PropertyAccessType;
//import net.vpc.upa.exceptions.UPAException;
//import net.vpc.upa.filters.ObjectFilter;
//
//import java.lang.reflect.Field;
//import java.lang.reflect.Method;
//import java.util.*;
//import java.util.logging.Level;
//import java.util.logging.Logger;
//
//*
// * @author Taha BEN SALAH <taha.bensalah@gmail.com>
// * @creationdate 8/27/12 12:16 AM
//
//
//public class DefaultPlatformBeanType implements PlatformBeanType {
//    private static final Logger log = Logger.getLogger(DefaultPlatformBeanType.class.getName());
//
//    private Class platformType;
//    private Map<String, PlatformBeanPropertyResolver> properties = new LinkedHashMap<String, PlatformBeanPropertyResolver>();
//    //    private Set<String> propertyNames;
//    private Map<MethodSignature, PlatformMethodInfo> methods = new HashMap<MethodSignature, PlatformMethodInfo>();
//    private Map<String, List<Method>> methodsByName = new HashMap<String, List<Method>>();
//    //    private Map<String, List<Field>> fields = new HashMap<String, List<Field>>();
//    //private boolean propertiesLoaded = false;
//    private boolean built = false;
////    private Constructor constructor;
//
//    public DefaultPlatformBeanType(Class platformType) {
//        this.platformType = platformType;
//    }
//
//    @Override
//    public Class getPlatformType() {
//        return platformType;
//    }
//
//    public Object newInstance() {
////        try {
////            if(constructor==null) {
////                constructor = platformType.getConstructor();
////                constructor.setAccessible(true);
////            }
////        } catch (NoSuchMethodException e) {
////            throw new UPAIllegalArgumentException(e);
////        }
//        try {
//            return PlatformUtils.newInstance(platformType);
//        } catch (Exception e) {
//            Throwable c = e.getCause();
//            if (c instanceof RuntimeException) {
//                throw (RuntimeException) c;
//            }
//            throw new RuntimeException(c);
//        }
//    }
//
//
//    protected void build() {
//        if (!built) {
//            built = true;
//            Class<?> x = platformType;
//            Method getter = null;
//            Method setter = null;
//            Class propertyType = null;
//            methods = new HashMap<>();
//            while (x != null && x != Object.class) {
//                for (Method m : x.getDeclaredMethods()) {
//                    if (!PlatformUtils.isStatic(m)) {
//                        PlatformMethodInfo mi = PlatformUtils.getMethodInfo(m);
//                        MethodSignature sig = new MethodSignature(mi.getMethod().getName(), mi.getMethod().getParameterTypes());
//                        if (!methods.containsKey(sig)) {
//                            methods.put(sig, mi);
//                            switch (mi.getMethodType()) {
//                                case SETTER: {
//                                    PlatformBeanPropertyResolver ii = properties.get(mi.getPropertyName());
//                                    if (ii == null) {
//                                        ii = new PlatformBeanPropertyResolver(mi.getPropertyName());
//                                        properties.put(ii.property, ii);
//                                    }
//                                    ii.setter = mi.getMethod();
//                                    break;
//                                }
//                                case GETTER: {
//                                    PlatformBeanPropertyResolver ii = properties.get(mi.getPropertyName());
//                                    if (ii == null) {
//                                        ii = new PlatformBeanPropertyResolver(mi.getPropertyName());
//                                        properties.put(ii.property, ii);
//                                    }
//                                    ii.getter = mi.getMethod();
//                                    break;
//                                }
//                            }
//                        }
//                    }
//                }
//                for (Field f : x.getDeclaredFields()) {
//                    if (!PlatformUtils.isStatic(f)) {
//                        if (!properties.containsKey(f.getName())) {
//                            PlatformBeanPropertyResolver ii = properties.get(f.getName());
//                            if (ii == null) {
//                                ii = new PlatformBeanPropertyResolver(f.getName());
//                                properties.put(ii.property, ii);
//                            }
//                            ii.field = f;
//                        }
////                        if(!fields.containsKey(f.getName())) {
////                            fields.pu
////                        }
//                    }
//                }
//                x = x.getSuperclass();
//            }
//            for (PlatformBeanPropertyResolver ii : properties.values()) {
//                ii.propertyType = ii.getter != null ? getter.getReturnType() : setter != null ? setter.getParameterTypes()[0] : ii.field != null ? ii.field.getType() : null;
//            }
//        }
//    }
//
//    @Override
//    public Class getPropertyType(String propertyName) {
//        PlatformBeanPropertyResolver f = properties.get(propertyName);
//        if (f != null) {
//            return null;
//        }
//        return f.propertyType;
//    }
//
////    @Override
//    public PlatformBeanProperty getProperty(String propertyName) {
//        PropertyAccessType propertyAccessType
//        PlatformBeanPropertyResolver f = properties.get(propertyName);
//        if (f != null) {
//            return f.getPlatformBeanProperty(propertyAccessType);
//        }
//        return null;
////        throw new UPAException("PropertyNotFound",new Object[]{propertyName,getPlatformType()});
//    }
//
//
//    //    public <R> void resetToDefaultValue(T o, String field) throws UPAException{
////        BeanAdapterAttribute<R> attrAdapter = getAttrAdapter(field);
////        attrAdapter.setValue(o, attrAdapter.getDefaultValue());
////    }
////
////    public <R> boolean isDefaultValue(T o, String field) throws UPAException{
////        BeanAdapterAttribute<R> attrAdapter = getAttrAdapter(field);
////        return attrAdapter.isDefaultValue(o);
////    }
//    public Method getMethod(Class type, String name, Class ret, Class... args) {
//        build();
//        MethodSignature key = new MethodSignature(name, args);
//        PlatformMethodInfo method = methods.get(key);
//        if (method == null) {
////            if (!methods.containsKey(key)) {
////                method = PlatformUtils.findPlatformMethod(type, name, ret, args);
////                methods.put(key, method);
////            }
//            return null;
//        }
//        if (ret == null || method.getMethod().getReturnType().equals(ret)) {
//            return method.getMethod();
//        }
//
//        return null;
//    }
//
//
//    public Set<String> getPropertyNames() {
//        build();
//        return properties.keySet();
////        if(propertyNames==null) {
////            loaded();
////            propertyNames=Collections.unmodifiableSet(fields.keySet());
////        }
////        return propertyNames;
//    }
//
//    public Set<String> getPropertyNames(Object o, Boolean includeDefaults) throws UPAException {
//        LinkedHashSet<String> set = new LinkedHashSet<String>();
//        if (includeDefaults == null) {
//            set.addAll(getPropertyNames());
//        } else {
//            for (String k : getPropertyNames()) {
//                if (includeDefaults == isDefaultValue(o, k)) {
//                    set.add(k);
//                }
//            }
//        }
//        return set;
//    }
//
//
////    private void loadProperties() {
////        if (!propertiesLoaded) {
////            propertiesLoaded = true;
////            for (Method method : platformType.getMethods()) {
////                if (!method.getDeclaringClass().equals(Object.class)) {
////                    String n = method.getName();
////                    if (PlatformUtils.isCamelPrefixed(n,PlatformUtils.METHOD_IS_PREFIX)) {
////                        String fieldName = PlatformUtils.adjustVarFirstChar(n.substring(PlatformUtils.METHOD_IS_PREFIX.length()));
////                        getAttrAdapter(fieldName);
////                    }else if (PlatformUtils.isCamelPrefixed(n,PlatformUtils.METHOD_GET_PREFIX)) {
////                        String fieldName = PlatformUtils.adjustVarFirstChar(n.substring(PlatformUtils.METHOD_GET_PREFIX.length()));
////                        getAttrAdapter(fieldName);
////                    }else if (PlatformUtils.isCamelPrefixed(n,PlatformUtils.METHOD_SET_PREFIX)) {
////                        String fieldName = PlatformUtils.adjustVarFirstChar(n.substring(PlatformUtils.METHOD_SET_PREFIX.length()));
////                        getAttrAdapter(fieldName);
////                    }
////                }
////            }
////        }
////    }
//
//    //    public Set<String> keySet(T o, Boolean includeDefaults) throws UPAException{
//    //        LinkedHashSet<String> set = new LinkedHashSet<String>();
//    //        if (includeDefaults == null) {
//    //            for (Map.Entry<String, BeanAdapterAttribute> e : properties.entrySet()) {
//    //                set.add(e.getKey());
//    //            }
//    //        } else {
//    //            for (Map.Entry<String, BeanAdapterAttribute> e : properties.entrySet()) {
//    //                if (includeDefaults == e.getValue().isDefaultValue(o)) {
//    //                    set.add(e.getKey());
//    //                }
//    //            }
//    //        }
//    //        return set;
//    //    }
//    //
//    //    public Map<String, Object> toMap(T o, Boolean includeDefaults) throws UPAException{
//    //        LinkedHashMap<String, Object> set = new LinkedHashMap<String, Object>();
//    //        if (includeDefaults == null) {
//    //            for (Map.Entry<String, BeanAdapterAttribute> e : properties.entrySet()) {
//    //                set.put(e.getKey(), e.getValue().getValue(o));
//    //            }
//    //        } else {
//    //            for (Map.Entry<String, BeanAdapterAttribute> e : properties.entrySet()) {
//    //                if (includeDefaults == e.getValue().isDefaultValue(o)) {
//    //                    set.put(e.getKey(), e.getValue().getValue(o));
//    //                }
//    //            }
//    //        }
//    //        return set;
//    //    }
//    public boolean containsProperty(String property) {
//        return properties.containsKey(property);
//    }
//
//    public Object getPropertyValue(Object o, String field, PropertyAccessType accessType) {
//        PlatformBeanProperty attrAdapter = getProperty(field, accessType);
//        if (attrAdapter != null) {
//            return attrAdapter.getValue(o);
//        }
//        return null;
//    }
//
//    public void injectNull(Object instance, String property) {
//        inject(instance, property, (Object) null);
//    }
//
//    public void inject(Object instance, String property, Object value) {
//        PlatformBeanProperty attrAdapter = getProperty(property, PropertyAccessType.DEFAULT);
//        if (attrAdapter != null) {
//            attrAdapter.setValue(instance, value);
//        } else {
//            log.log(Level.WARNING, "inject " + property + " into " + instance.getClass() + " failed.");
//        }
//    }
//
//    public boolean setPropertyValue(Object instance, String property, Object value, PropertyAccessType accessType) {
//        PlatformBeanProperty attrAdapter = getProperty(property, PropertyAccessType.DEFAULT);
//        if (attrAdapter != null) {
//            attrAdapter.setValue(instance, value);
//            return true;
//        } else {
//            return false;
//        }
//    }
//
//    public static boolean isTypeDefaultValue(Class c, Object v) {
//        Object t = PlatformUtils.DEFAULT_VALUES_BY_TYPE.get(c);
//        if (t == null) {
//            return v == null;
//        }
//        return t.equals(v);
//    }
//
//
//    public static String suffix(String s) {
//        char[] chars = s.toCharArray();
//        chars[0] = Character.toUpperCase(chars[0]);
//        return new String(chars);
//    }
//
////    public Field findField(String name, ObjectFilter<Field> filter) {
////        List<Field> fieldsList = fields.get(name);
////        if (fieldsList == null) {
////            if (!fields.containsKey(name)) {
////                fieldsList = PlatformUtils.findFields(platformType, name);
////                if (fieldsList.size() > 0) {
////                    fields.put(name, fieldsList);
////                } else {
////                    fields.put(name, null);
////                }
////            }
////        }
////        if (filter == null) {
////            return fieldsList.get(0);
////        }
////        for (Field field : fieldsList) {
////            if (filter.accept(field)) {
////                return field;
////            }
////        }
////        return null;
////    }
//
//    public boolean resetToDefaultValue(Object instance, String field) throws UPAException {
//        PlatformBeanProperty attrAdapter = getProperty(field, PropertyAccessType.DEFAULT);
//        if (attrAdapter != null) {
//            attrAdapter.setValue(instance, attrAdapter.getDefaultValue());
//            return true;
//        } else {
//            return false;
//        }
//    }
//
//    @Override
//    public boolean isDefaultValue(Object instance, String field) {
//        PlatformBeanProperty attrAdapter = getProperty(field, PropertyAccessType.DEFAULT);
//        if (attrAdapter != null) {
//            return attrAdapter.isDefaultValue(instance);
//        }
//        return false;
//    }
//}
