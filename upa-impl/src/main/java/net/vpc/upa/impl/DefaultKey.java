package net.vpc.upa.impl;

import net.vpc.upa.Entity;
import net.vpc.upa.Field;
import net.vpc.upa.Key;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.exceptions.UPAIllegalArgumentException;

import java.util.Arrays;
import java.util.List;

public class DefaultKey extends AbstractKey {

    private static final long serialVersionUID = 1L;
    private Object[] value;

    public DefaultKey() {

    }

    public DefaultKey(Object... values) {
        setValue(values);
    }

    public void setValue(Object... values) {
        this.value = values;
        for (Object aValue : this.value) {
            if (aValue == null) {
                throw new RuntimeException("key cannot contain a null value");
            }
            if (aValue instanceof Key) {
                throw new RuntimeException("bad key : Key");
            }
            if (aValue.getClass().isArray()) {
                throw new RuntimeException("bad key");
            }
        }
        if (value.getClass().isArray() && !value.getClass().getComponentType().isPrimitive()) {
        } else {
            this.value = (new Object[]{
                    value
            });
        }
    }


    //    public boolean isNull() {
//        return value == null || value.length == 0;
//    }
//
    @Override
    public Object getValue(Entity entity, String fieldName) throws UPAException {
        List<Field> f = entity.getIdFields();
        for (int i = 0; i < f.size(); i++) {
            if (f.get(i).getName().equals(fieldName)) {
                return value[i];
            }
        }
        throw new UPAIllegalArgumentException("Either key " + toString() + " or fieldName " + fieldName + " does not refer to entity " + entity.getName());
    }

    public Object[] getValue() {
        return value;
    }

    @Override
    public boolean equals(Object object) {
        if (!(object instanceof DefaultKey)) {
            return false;
        }
        return super.equals(object);
    }

    @Override
    public int hashCode() {
        int hash = 3;
        hash = 59 * hash;
        if (this.value != null) {
            for (Object o : value) {
                hash = hash * 31 + ((o == null) ? 0 : o.hashCode());
            }
        }
        return hash;
    }

    @Override
    public String toString() {
        return "ID" + (value == null ? "null" : (String.valueOf(Arrays.asList(value))));
    }


}
