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

public class DoubleType extends NumberType implements Cloneable {

    public static final DoubleType DEFAULT = new DoubleType(null, null, Integer.MAX_VALUE, Integer.MAX_VALUE, true, false);
    protected Double min;
    protected Double max;
    private boolean fixedDigits;
    private String userFormatName;

    public DoubleType(Double min, Double max, int before, int after, boolean nullable, boolean primitiveType) {
        this("DOUBLE", min, max, before, after, nullable, primitiveType);
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
    public DoubleType(String name, Double min, Double max, int before, int after, boolean nullable, boolean primitiveType) {
        super(name, primitiveType ? Double.TYPE : Double.class, before + after, after, nullable);
        this.min = min;
        this.max = max;
    }

    @Override
    protected void reevaluateCachedValues() {
        super.reevaluateCachedValues();
        if(!defaultValueUserDefined && !isNullable()) {
            defaultValue=(0.0);
        }
    }

    public Double getMin() {
        return min;
    }

    public void setMin(Double min) {
        this.min = min;
    }

    public Double getMax() {
        return max;
    }

    public void setMax(Double max) {
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
        if (!(value instanceof Double)) {
            throw new ConstraintsException("InvalidCast", name, description, value);
        }
        if (getMin() != null && (Double) value < getMin()) {
            throw new ConstraintsException("NumberTooLow", name, description, value, getMin());
        }
        if (getMax() != null && (Double) value > getMax()) {
            throw new ConstraintsException("NumberTooHigh", name, description, value, getMax());
        }
    }

    public boolean isFixedDigits() {
        return fixedDigits;
    }

    public void setFixedDigits(boolean fixedDigits) {
        this.fixedDigits = fixedDigits;
    }

    public String getUserFormatName() {
        return userFormatName;
    }

    public void setUserFormatName(String userFormatName) {
        this.userFormatName = userFormatName;
    }

    @Override
    public String toString() {
        StringBuilder s = new StringBuilder("DoubleType");
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
        return Double.parseDouble(value);
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        if (!super.equals(o)) return false;

        DoubleType that = (DoubleType) o;

        if (fixedDigits != that.fixedDigits) return false;
        if (min != null ? !min.equals(that.min) : that.min != null) return false;
        if (max != null ? !max.equals(that.max) : that.max != null) return false;
        return userFormatName != null ? userFormatName.equals(that.userFormatName) : that.userFormatName == null;
    }

    @Override
    public int hashCode() {
        int result = super.hashCode();
        result = 31 * result + (min != null ? min.hashCode() : 0);
        result = 31 * result + (max != null ? max.hashCode() : 0);
        result = 31 * result + (fixedDigits ? 1 : 0);
        result = 31 * result + (userFormatName != null ? userFormatName.hashCode() : 0);
        return result;
    }

    @Override
    public DataTypeInfo getInfo() {
        DataTypeInfo d = super.getInfo();
        d.getProperties().put("userFormatName", String.valueOf(userFormatName));
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
