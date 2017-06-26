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

import net.vpc.upa.PortabilityHint;

import java.math.BigDecimal;

@PortabilityHint(target = "C#", name = "suppress") //no supported
public class BigDecimalType extends NumberType implements Cloneable {

    public static final BigDecimalType DEFAULT = new BigDecimalType(null, null, Integer.MAX_VALUE, Integer.MAX_VALUE, true);
    protected BigDecimal min;
    protected BigDecimal max;
    private boolean fixedDigits;

    public BigDecimalType(BigDecimal min, BigDecimal max, int before, int after, boolean nullable) {
        this("DEFAULT", min, max, before, after, nullable);
    }

    /**
     * @param min      minimum value (compared to value * multiplier). if null, no
     *                 constraints
     * @param max      maximum value (compared to value * multiplier). if null, no
     *                 constraints
     * @param before   number of digits before dot
     * @param after    number of digits after dot
     * @param nullable null accept if true
     */
    public BigDecimalType(String name, BigDecimal min, BigDecimal max, int before, int after, boolean nullable) {
        super(name, BigDecimal.class, before + after, after, nullable);
        this.min = min;
        this.max = max;
        setDefaultNonNullValue(BigDecimal.ZERO);
    }

    public BigDecimal getMin() {
        return min;
    }

    public void setMin(BigDecimal min) {
        this.min = min;
    }

    public BigDecimal getMax() {
        return max;
    }

    public void setMax(BigDecimal max) {
        this.max = max;
    }

    public int getMaximumIntegerDigits() {
        if (getScale() <= 0 || getPrecision() <= 0) {
            return -1;
        }
        return getScale() - getPrecision();
    }

    public int getMaximumFractionDigits() {
        return getPrecision();
    }

    @Override
    public void check(Object value, String name, String description)
            throws ConstraintsException {
        super.check(value, name, description);
        if (value == null) {
            return;
        }
        if (!(value instanceof BigDecimal)) {
            throw new ConstraintsException("InvalidCast", name, description, value);
        }
        if (getMin() != null && ((BigDecimal) value).compareTo(getMin()) < 0) {
            BigDecimal limit = getMin();
            throw new ConstraintsException("NumberTooLow", name, description, value, limit);
        }
        if (getMax() != null && ((BigDecimal) value).compareTo(getMax()) > 0) {
            BigDecimal limit = getMax();
            throw new ConstraintsException("NumberTooHigh", name, description, value, limit);
        }
    }

    public boolean isFixedDigits() {
        return fixedDigits;
    }

    public void setFixedDigits(boolean fixedDigits) {
        this.fixedDigits = fixedDigits;
    }

    @Override
    public String toString() {
        return "BigDecimalType{" + "min=" + min + ", max=" + max + ", fixedDigits=" + fixedDigits + '}';
    }

    @Override
    public Number parse(String value) {
        if (value == null || value.trim().isEmpty()) {
            return null;
        }
        return new BigDecimal(value);
    }


}
