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

import java.math.BigInteger;

public class BigIntType extends NumberType implements Cloneable {

    public static final BigIntType DEFAULT = new BigIntType(null, null, true);
    protected BigInteger min;
    protected BigInteger max;

    public BigIntType(BigInteger min, BigInteger max, boolean nullable) {
        this("BIGINT", min, max, nullable);
    }

    /**
     * @param min minimum value (compared to value * multiplier). if null, no
     * constraints
     * @param max maximum value (compared to value * multiplier). if null, no
     * constraints
     * @param nullable null accept if true
     */
    public BigIntType(String name, BigInteger min, BigInteger max, boolean nullable) {
        super(name, BigInteger.class, (Math.max((min == null ? Integer.MAX_VALUE : String.valueOf(min).length()), (max == null ? Integer.MAX_VALUE : String.valueOf(max).length()))), 0, nullable);
        this.min = min;
        this.max = max;
        setDefaultNonNullValue(BigInteger.ZERO);
    }

    public BigInteger getMin() {
        return min;
    }

    public void setMin(BigInteger min) {
        this.min = min;
    }

    public BigInteger getMax() {
        return max;
    }

    public void setMax(BigInteger max) {
        this.max = max;
    }

    @Override
    public void check(Object value, String name, String description)
            throws ConstraintsException {
        super.check(value, name, description);
        if (value == null) {
            return;
        }
        if(!(value instanceof BigInteger)) {
            throw new ConstraintsException("InvalidCast", name, description, value);
        }
        if (getMin() != null && ((BigInteger) value).compareTo(getMin()) < 0) {
            throw new ConstraintsException("NumberTooLow", name, description, value, getMin());
        }
        if (getMax() != null && ((BigInteger) value).compareTo(getMax()) > 0) {
            throw new ConstraintsException("NumberTooHigh", name, description, value, getMax());
        }
    }

    @Override
    public String toString() {
        return "BigIntType{" + "min=" + min + ", max=" + max + '}';
    }

    @Override
    public Number parse(String value) {
        if (value == null || value.trim().isEmpty()) {
            return null;
        }
        return new BigInteger(value);
    }

}
