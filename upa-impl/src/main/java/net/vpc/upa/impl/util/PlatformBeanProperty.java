package net.vpc.upa.impl.util;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/5/13 11:18 PM
 */ //    public <R> R getDefaultValue(String field) throws UPAException{
//        BeanAdapterAttribute<R> attrAdapter = getAttrAdapter(field);
//        return attrAdapter.getDefaultValue();
//    }
//    public <R> void setDefaultValue(String field, R value) {
//        BeanAdapterAttribute<R> attrAdapter = getAttrAdapter(field);
//        attrAdapter.setDefaultValue(value);
//    }
public interface PlatformBeanProperty {

    String getName();

    Class getPlatformType();

    Object getValue(Object o);

    Object getDefaultValue();

    void setValue(Object o, Object value);

    boolean isDefaultValue(Object o);

    boolean isWriteSupported();

    boolean isReadSupported();
}
