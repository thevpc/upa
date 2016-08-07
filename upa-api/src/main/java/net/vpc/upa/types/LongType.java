/**
 * ==================================================================== 
 * UPA (Unstructured Persistence API)
 *    Yet another ORM Framework
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
 *
 * Copyright (C) 2014-2015 Taha BEN SALAH
 *
 * This program is free software; you can redistribute it and/or modify it under
 * the terms of the GNU General Public License as published by the Free Software
 * Foundation; either version 2 of the License, or (at your option) any later
 * version.
 *
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE. See the GNU General Public License for more
 * details.
 *
 * You should have received a copy of the GNU General Public License along with
 * this program; if not, write to the Free Software Foundation, Inc., 51
 * Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 * ====================================================================
 */
package net.vpc.upa.types;

public class LongType extends NumberType implements Cloneable {

    public static final LongType DEFAULT = new LongType(null, null, true, false);
    protected Long min;
    protected Long max;

    public LongType(Long min, Long max, boolean nullable, boolean primitiveType) {
        this("LONG", min, max, nullable, primitiveType);
    }

    /**
     * @param min minimum value (compared to value * multiplier). if null, no
     * constraints
     * @param max maximum value (compared to value * multiplier). if null, no
     * constraints
     * @param nullable null accept if true
     */
    public LongType(String name, Long min, Long max, boolean nullable, boolean primitiveType) {
        super(name, primitiveType ? Long.TYPE : Long.class, (Math.max((min == null ? Integer.MAX_VALUE : String.valueOf(min).length()), (max == null ? Integer.MAX_VALUE : String.valueOf(max).length()))), 0, nullable);
        this.min = min;
        this.max = max;
        setDefaultNonNullValue(0L);
    }

    public Long getMin() {
        return min;
    }

    public Long getMax() {
        return max;
    }

    public void setMin(Long min) {
        this.min = min;
    }

    public void setMax(Long max) {
        this.max = max;
    }

    @Override
    public void check(Object value, String name, String description)
            throws ConstraintsException {
        super.check(value, name, description);
        if (value == null) {
            return;
        }
        if(!(value instanceof Long)) {
            throw new ConstraintsException("InvalidCast", name, description, value);
        }
        if (getMin() != null && ((Long) value) < getMin()) {
            throw new ConstraintsException("NumberTooLow", name, description, value, getMin());
        }
        if (getMax() != null && ((Long) value) > getMax()) {
            throw new ConstraintsException("NumberTooHigh", name, description, value, getMax());
        }
    }

    @Override
    public String toString() {
        StringBuilder s = new StringBuilder("Long");
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
        return s.toString();
    }

    @Override
    public Number parse(String value) {
        if (value == null || value.trim().isEmpty()) {
            return null;
        }
        return Long.parseLong(value);
    }

}
