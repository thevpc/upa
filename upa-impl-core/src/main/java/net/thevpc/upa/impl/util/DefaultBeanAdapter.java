package net.thevpc.upa.impl.util;

import net.thevpc.upa.BeanAdapter;
import net.thevpc.upa.PlatformBeanType;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/27/12 12:16 AM
 */
public class DefaultBeanAdapter implements BeanAdapter {

    private PlatformBeanType platformBeanType;
    private Object instance;

    public DefaultBeanAdapter(Object obj) {
        this(obj.getClass());
        this.instance = obj;
    }

    public DefaultBeanAdapter(Class cls) {
        this.platformBeanType = PlatformUtils.getBeanType(cls);
    }

    public Object newInstance() {
        return platformBeanType.newInstance();
    }

    @Override
    public PlatformBeanType getPlatformBeanType() {
        return platformBeanType;
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
        return platformBeanType.containsProperty(property);

    }

    public Object getProperty(String field) {
        return platformBeanType.getPropertyValue(instance, field);
    }

//    public Object getProperty(Object instance, String field) {
//        return platformBeanType.getProperty(instance,field);
//    }

    public void injectNull(String property) {
        platformBeanType.inject(instance, property, (Object) null);
    }

    public void setProperty(String property, Object value) {
        platformBeanType.inject(instance, property, value);
    }

    public void inject(String property, Object value) {
        platformBeanType.inject(instance, property, value);
    }
}
