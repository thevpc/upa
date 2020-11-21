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
package net.thevpc.upa.types;

import net.thevpc.upa.DataTypeInfo;
import net.thevpc.upa.PortabilityHint;

import java.math.BigDecimal;

/**
 * Decimal Type is very similar to big decimal type although it defines a 128
 * bit max big decimal
 */
@PortabilityHint(target = "C#", name = "suppress") //no supported
public class DecimalType extends NumberType implements Cloneable {

    public static final BigDecimal MAX_VALUE = new BigDecimal("79228162514264337593543950335");
    public static final BigDecimal MIN_VALUE = new BigDecimal("-79228162514264337593543950335");
    public static final DecimalType DEFAULT = new DecimalType(null, null, Integer.MAX_VALUE, Integer.MAX_VALUE, true);
    protected BigDecimal min;
    protected BigDecimal max;
    private boolean fixedDigits;

    public DecimalType(BigDecimal min, BigDecimal max, int before, int after, boolean nullable) {
        this("DECIMAL", min, max, before, after, nullable);
    }

    /**
     * @param min minimum value (compared to value * multiplier). if null, no
     * constraints
     * @param max maximum value (compared to value * multiplier). if null, no
     * constraints
     * @param before number of digits before dot
     * @param after number of digits after dot
     * @param nullable null accept if true
     */
    public DecimalType(String name, BigDecimal min, BigDecimal max, int before, int after, boolean nullable) {
        super(name, BigDecimal.class, before + after, after, nullable);
        setMin(min);
        setMax(max);
    }

    @Override
    protected void reevaluateCachedValues() {
        super.reevaluateCachedValues();
        if(!defaultValueUserDefined && !isNullable()) {
            defaultValue=(BigDecimal.ZERO);
        }
    }

    public BigDecimal getMin() {
        return min;
    }

    public void setMin(BigDecimal min) {
        if (min != null && min.compareTo(MIN_VALUE) < 0) {
            throw new ConstraintsException("NumberTooLow", getName(), null, min, MIN_VALUE);
        }
        this.min = min;
    }

    public BigDecimal getMax() {
        return max;
    }

    public void setMax(BigDecimal max) {
        if (max != null && max.compareTo(MAX_VALUE) < 0) {
            throw new ConstraintsException("NumberTooHigh", getName(), null, max, MAX_VALUE);
        }
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
    public Number parse(String value) {
        if (value == null || value.trim().isEmpty()) {
            return null;
        }
        return new BigDecimal(value);
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        if (!super.equals(o)) return false;

        DecimalType that = (DecimalType) o;

        if (fixedDigits != that.fixedDigits) return false;
        if (min != null ? !min.equals(that.min) : that.min != null) return false;
        return max != null ? max.equals(that.max) : that.max == null;
    }

    @Override
    public int hashCode() {
        int result = super.hashCode();
        result = 31 * result + (min != null ? min.hashCode() : 0);
        result = 31 * result + (max != null ? max.hashCode() : 0);
        result = 31 * result + (fixedDigits ? 1 : 0);
        return result;
    }

    @Override
    public DataTypeInfo getInfo() {
        DataTypeInfo d = super.getInfo();
        d.getProperties().put("fixedDigits", String.valueOf(fixedDigits));
        if(min!=null) {
            d.getProperties().put("min", String.valueOf(min));
        }
        if(max!=null) {
            d.getProperties().put("max", String.valueOf(max));
        }
        return d;
    }

}
