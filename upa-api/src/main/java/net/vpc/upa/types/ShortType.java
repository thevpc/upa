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

public class ShortType extends NumberType implements Cloneable {

    public static final ShortType DEFAULT = new ShortType("DEFAULT", null, null, true, false);
    protected Short min;
    protected Short max;

    public Short getMin() {
        return min;
    }

    public Short getMax() {
        return max;
    }

    public void setMin(Short min) {
        this.min = min;
    }

    public void setMax(Short max) {
        this.max = max;
    }

    /**
     * @param min minimum value (compared to value * multiplier). if null, no
     * constraints
     * @param max maximum value (compared to value * multiplier). if null, no
     * constraints
     * @param nullable null accept if true
     */
    public ShortType(String name, Short min, Short max, boolean nullable, boolean primitiveType) {
        super(name, primitiveType ? Short.TYPE : Short.class, (Math.max((min == null ? Integer.MAX_VALUE : String.valueOf(min).length()), (max == null ? Integer.MAX_VALUE : String.valueOf(max).length()))), 0, nullable);
        this.min = min;
        this.max = max;
    }

    @Override
    protected void reevaluateCachedValues() {
        super.reevaluateCachedValues();
        if(!defaultValueUserDefined && !isNullable()) {
            defaultValue=((short) 0);
        }
    }

    @Override
    public void check(Object value, String name, String description)
            throws ConstraintsException {
        super.check(value, name, description);
        if (value == null) {
            return;
        }
        if (!(value instanceof Short)) {
            throw new ConstraintsException("InvalidCast", name, description, value);
        }
        if (getMin() != null && ((Short) value) < getMin()) {
            throw new ConstraintsException("NumberTooLow", name, description, value, getMin());
        }
        if (getMax() != null && ((Short) value) > getMax()) {
            throw new ConstraintsException("NumberTooHigh", name, description, value, getMax());
        }
    }

    @Override
    public String toString() {
        StringBuilder s = new StringBuilder("Short");
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
        return Short.parseShort(value);
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        if (!super.equals(o)) return false;

        ShortType shortType = (ShortType) o;

        if (min != null ? !min.equals(shortType.min) : shortType.min != null) return false;
        return max != null ? max.equals(shortType.max) : shortType.max == null;
    }

    @Override
    public int hashCode() {
        int result = super.hashCode();
        result = 31 * result + (min != null ? min.hashCode() : 0);
        result = 31 * result + (max != null ? max.hashCode() : 0);
        return result;
    }
}
