package net.vpc.upa.impl.util;

import net.vpc.upa.BeanAdapter;
import net.vpc.upa.BeanType;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/27/12 12:16 AM
 */
public class DefaultBeanAdapter implements BeanAdapter {

    private BeanType beanType;
    private Object instance;

    public DefaultBeanAdapter(Object obj) {
        this(obj.getClass());
        this.instance = obj;
    }

    public DefaultBeanAdapter(Class cls) {
        this.beanType = PlatformBeanTypeRepository.getInstance().getBeanType(cls);
    }

    public Object newInstance() {
        return beanType.newInstance();
    }

    @Override
    public BeanType getBeanType() {
        return beanType;
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
        return beanType.containsProperty(property);

    }

    public Object getProperty(String field) {
        return beanType.getProperty(instance, field);
    }

//    public Object getProperty(Object instance, String field) {
//        return beanType.getProperty(instance,field);
//    }

    public void injectNull(String property) {
        beanType.inject(instance, property, (Object) null);
    }

    public void setProperty(String property, Object value) {
        beanType.inject(instance, property, value);
    }

    public void inject(String property, Object value) {
        beanType.inject(instance, property, value);
    }
}
