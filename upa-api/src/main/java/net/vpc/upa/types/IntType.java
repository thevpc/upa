/**
 * ====================================================================
 * UPA (Unstructured Persistence API)
 * Yet another ORM Framework
 * ++++++++++++++++++++++++++++++++++
 * Unstructured Persistence API, referred to as UPA, is a genuine effort
 * to raise programming language frameworks managing relational data in
 * applications using Java Platform, Standard Edition and Java Platform,
 * Enterprise Edition and Dot Net Framework equally to the next level of
 * handling ORM for mutable data structures. UPA is intended to provide
 * a solid reflection mechanisms to the mapped data structures while
 * affording to make changes at runtime of those data structures.
 * Besides, UPA has learned considerably of the leading ORM
 * (JPA, Hibernate/NHibernate, MyBatis and Entity Framework to name a few)
 * failures to satisfy very common even known to be trivial requirement in
 * enterprise applications.
 * <p>
 * Copyright (C) 2014-2015 Taha BEN SALAH
 * <p>
 * This program is free software; you can redistribute it and/or modify it under
 * the terms of the GNU General Public License as published by the Free Software
 * Foundation; either version 2 of the License, or (at your option) any later
 * version.
 * <p>
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE. See the GNU General Public License for more
 * details.
 * <p>
 * You should have received a copy of the GNU General Public License along with
 * this program; if not, write to the Free Software Foundation, Inc., 51
 * Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 * ====================================================================
 */
package net.vpc.upa.types;

import net.vpc.upa.DataTypeInfo;

public class IntType extends NumberType implements Cloneable {

    public static final IntType DEFAULT = new IntType(null, null, null, true, false);
    protected Integer min;
    protected Integer max;

    public IntType(Integer min, Integer max, boolean nullable, boolean primitiveType) {
        this(null, min, max, nullable, primitiveType);
    }

    /**
     * @param min minimum value (compared to value * multiplier). if null, no
     * constraints
     * @param max maximum value (compared to value * multiplier). if null, no
     * constraints
     * @param nullable null accept if true
     */
    public IntType(String name, Integer min, Integer max, boolean nullable, boolean primitiveType) {
        super(name == null ? "INT" : name, primitiveType ? Integer.TYPE : Integer.class, (Math.max((min == null ? Integer.MAX_VALUE : String.valueOf(min).length()), (max == null ? Integer.MAX_VALUE : String.valueOf(max).length()))), 0, nullable);
        this.min = min;
        this.max = max;
    }

    @Override
    protected void reevaluateCachedValues() {
        super.reevaluateCachedValues();
        if(!defaultValueUserDefined && !isNullable()) {
            defaultValue=(0);
        }
    }

    public Integer getMin() {
        return min;
    }

    public Integer getMax() {
        return max;
    }

    public void setMin(Integer min) {
        this.min = min;
    }

    public void setMax(Integer max) {
        this.max = max;
    }

    @Override
    public void check(Object value, String name, String description)
            throws ConstraintsException {
        super.check(value, name, description);
        if (value == null) {
            return;
        }
        if (!(value instanceof Integer)) {
            throw new ConstraintsException("InvalidCast", name, description, value);
        }
        Integer castedValue = (Integer) value;
        if (getMin() != null && castedValue < getMin()) {
            throw new ConstraintsException("NumberTooLow", name, description, value, getMin());
        }
        if (getMax() != null && castedValue > getMax()) {
            throw new ConstraintsException("NumberTooHigh", name, description, value, getMax());
        }
    }

    @Override
    public String toString() {
        StringBuilder s = new StringBuilder("Int");
        if (min != null || max != null) {
            s.append("[");
            if (min != null) {
                s.append(min);
            }
            s.append("...");
            if (max != null) {
                s.append(max);
            }
            s.append("]");
        }
        if(isNullable()){
            s.append("?");
        }
        return s.toString();
    }

    @Override
    public Number parse(String value) {
        if (value == null || value.trim().isEmpty()) {
            return null;
        }
        return Integer.parseInt(value);
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        if (!super.equals(o)) return false;

        IntType intType = (IntType) o;

        if (min != null ? !min.equals(intType.min) : intType.min != null) return false;
        return max != null ? max.equals(intType.max) : intType.max == null;
    }

    @Override
    public int hashCode() {
        int result = super.hashCode();
        result = 31 * result + (min != null ? min.hashCode() : 0);
        result = 31 * result + (max != null ? max.hashCode() : 0);
        return result;
    }

    @Override
    public DataTypeInfo getInfo() {
        DataTypeInfo d = super.getInfo();
        if(min!=null) {
            d.getProperties().put("min", String.valueOf(min));
        }
        if(max!=null) {
            d.getProperties().put("max", String.valueOf(max));
        }
        return d;
    }

}
