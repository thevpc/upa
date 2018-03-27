package net.vpc.upa.impl.util;

import net.vpc.upa.exceptions.UPAException;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/5/13 11:23 PM
 */ //    public <R> void setDefaultValue(String field, R value) {
//        EntityBeanAttribute<R> attrAdapter = getAttrAdapter(field);
//        attrAdapter.setDefaultValue(value);
//    }
public interface EntityBeanAttribute {

    String getName();

    Object getValue(Object o);

    void setValue(Object o, Object value);

    Object getDefaultValue() throws UPAException;

    boolean isDefaultValue(Object o) throws UPAException;
}
