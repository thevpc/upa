package net.thevpc.upa.impl;

import net.thevpc.upa.Entity;
import net.thevpc.upa.Field;
import net.thevpc.upa.Key;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.exceptions.IllegalUPAArgumentException;

import java.util.Arrays;
import java.util.Date;
import java.util.List;

/**
 * Abstract Key is an abstract implementation of the <code>net.thevpc.upa.Key</code> Interface.
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public abstract class AbstractKey
        implements Key {

    private static final long serialVersionUID = 1L;

    public AbstractKey() {
    }

    private static boolean __equals(Object o1, Object o2) {
        if (o1 == o2) {
            return true;
        }
        if (o1 == null || o2 == null) {
            return false;
        }
        if (!o1.getClass().isArray()) {
            return o1.equals(o2);
        }
        Class clz = o1.getClass().getComponentType();
        if (clz.isPrimitive()) {
            throw new IllegalUPAArgumentException("could not compare primitive arrays");
            //return false;
        }
        Object[] o1arr = (Object[]) o1;
        Object[] o2arr = (Object[]) o2;
        if (o1arr.length != o2arr.length) {
            return false;
        } else {
            List<Object> o1coll = Arrays.asList(o1arr);
            List<Object> o2coll = Arrays.asList(o2arr);
            boolean ret = o1coll.equals(o2coll);
            return ret;
        }
    }

    /**
     * @param entity    entity to apply to this key
     * @param fieldName field name to retrieve
     * @return value of the given <code>fieldName</code> if it is a valid identifier portion
     * @throws UPAException if <code>fieldName</code> is not a valid identifier portion of the given Entity
     */
    public Object getValue(Entity entity, String fieldName) throws UPAException {
        List<Field> f = entity.getIdFields();
        Object[] value = getValue();
        for (int i = 0; i < f.size(); i++) {
            if (f.get(i).getName().equals(fieldName)) {
                return value[i];
            }
        }
        throw new UPAException("Either key " + toString() + " or fieldName " + fieldName + " does not refer to entity " + entity.getName());
    }

    /**
     * Tests equality between the two instances (current and passed as param)
     *
     * @param object another AbstractKey instance to check
     * @return true if the two instances denote the same key portions
     */
    @Override
    public boolean equals(Object object) {
        if (!(object instanceof AbstractKey)) {
            return false;
        }
        Object[] value = getValue();
        AbstractKey other = (AbstractKey) object;
        Object[] value1 = other == null ? null : other.getValue();
        if (this == other || value == value1) {
            return true;
        }
        if (value == null || value1 == null) {
            return false;
        }
        if (value.length != value1.length) {
            return false;
        }
        for (int i = 0; i < value.length; i++) {
            if (!__equals(value[i], value1[i])) {
                return false;
            }
        }

        return true;
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public String toString() {
        return "ID:" + (getValue() == null ? "null" : (String.valueOf(Arrays.asList(getValue()))));
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public int hashCode() {
        return arrayHash(getValue());
    }

    /**
     * Arrays.deepHashCode not used because java specific (UPA should be ported to C#)
     *
     * @param arr array
     * @return int hash value
     */
    private int arrayHash(Object[] arr) {
        int x = 0;
        if (arr != null) {
            for (Object o : arr) {
                if (o != null) {
                    x += 31 * o.hashCode();
                }
            }
        }
        return x;
    }

    /**
     * {@inheritDoc}
     */
    public String getString() {
        Object[] value = getValue();
        if (value.length == 0) {
            throwMultiDimensionalValue();
        }
        return (String) value[0];
    }

    /**
     * {@inheritDoc}
     */
    public Object getObject() {
        Object[] value = getValue();
        if (value.length == 0) {
            throwMultiDimensionalValue();
        }
        return value[0];
    }

    /**
     * {@inheritDoc}
     */
    public int getInt() {
        Object[] value = getValue();
        if (value.length == 0) {
            throwMultiDimensionalValue();
        }
        return ((Number) value[0]).intValue();
    }

    /**
     * {@inheritDoc}
     */
    public long getLong() {
        Object[] value = getValue();
        if (value.length == 0) {
            throwMultiDimensionalValue();
        }
        return ((Number) value[0]).longValue();
    }

    /**
     * {@inheritDoc}
     */
    public Date getDate() {
        Object[] value = getValue();
        if (value.length == 0) {
            throwMultiDimensionalValue();
        }
        return ((Date) value[0]);
    }

    private void throwMultiDimensionalValue() throws UPAException {
        throw new UPAException("Not a single value key");
    }

    /**
     * {@inheritDoc}
     */
    public String getStringAt(int index) {
        Object[] value = getValue();
        return (String) value[index];
    }

    /**
     * {@inheritDoc}
     */
    public Object getObjectAt(int index) {
        Object[] value = getValue();
        return value[index];
    }

    /**
     * {@inheritDoc}
     */
    public int getIntAt(int index) {
        Object[] value = getValue();
        return ((Number) value[index]).intValue();
    }

    /**
     * {@inheritDoc}
     */
    public long getLongAt(int index) {
        Object[] value = getValue();
        return ((Number) value[index]).longValue();
    }

    /**
     * {@inheritDoc}
     */
    public Date getDateAt(int index) {
        Object[] value = getValue();
        return ((Date) value[index]);
    }

}
