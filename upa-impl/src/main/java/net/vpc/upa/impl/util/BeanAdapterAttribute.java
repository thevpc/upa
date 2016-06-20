package net.vpc.upa.impl.util;

import net.vpc.upa.exceptions.UPAException;

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
public interface BeanAdapterAttribute {

        public String getName();

        public Object getValue(Object o);

        public Object getDefaultValue();

        public void setValue(Object o, Object value);

        public boolean isDefaultValue(Object o) ;
    }
