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

import net.thevpc.upa.exceptions.IllegalUPAArgumentException;
import net.thevpc.upa.DataTypeInfo;

import java.math.BigDecimal;
import java.util.Calendar;
import java.util.LinkedHashMap;
import java.util.Map;

public class YearType extends TemporalType implements Cloneable {
    public static final YearType DEFAULT = new YearType("YEAR", null, true);
    protected Year min = null;
    protected Year max = null;

    public YearType(String name, Class<? extends java.util.Date> type, boolean nullable) {
        this(name, type, null, null, nullable);
    }

    public YearType(String name, Class<? extends java.util.Date> type, Year min, Year max, boolean nullable) {
        super(name, type == null ? Year.class : type, 0, 0, nullable);
        if (type != null && !type.equals(Year.class) && !type.equals(java.util.Date.class)) {
            throw new IllegalUPAArgumentException("Invalid Temporal Type " + type);
        }
        this.min = min;
        this.max = max;
        if(!isNullable()) {
            setDefaultValue(convert(new DateTime(0)));
        }
    }

    @Override
    protected void reevaluateCachedValues() {
        super.reevaluateCachedValues();
        if(!defaultValueUserDefined && !isNullable()) {
            defaultValue=(BigDecimal.ZERO);
        }
    }

    public Year getMin() {
        return min;
    }

    public void setMin(Year newMin) {
        min = newMin;
    }

    public Year getMax() {
        return max;
    }

    public void setMax(Year newMax) {
        max = newMax;
    }

    @Override
    public void check(Object value, String name, String description) throws ConstraintsException {
        super.check(value, name, description);
        if (value == null) {
            return;
        }
        if (!(value instanceof Date)) {
            throw new ConstraintsException("InvalidCast", name, description, value);
        }
        if (getMin() != null && getMin().compareTo((java.util.Date) value) > 0) {
            throw new ConstraintsException("DateTooEarly", name, description, value, min);
        }
        if (getMax() != null && getMax().compareTo((java.util.Date) value) < 0) {
            throw new ConstraintsException("DateTooLate", name, description, value, max);
        }
    }

    @Override
    public Object convert(Object value) {
        if (value == null) {
            return null;
        }
        if (value instanceof java.util.Date) {
            return validateDate((java.util.Date) value);
        }
        return super.convert(value);
    }

    public java.util.Date validateDate(java.util.Date date) {
        if (date == null) {
            return null;
        }

        Class type = getPlatformType();

        if(date.getClass().equals(type)){
            return date;
        }
        Calendar c = Calendar.getInstance();
        c.setTime(date);
        long time = date.getTime();
        if (Year.class.isAssignableFrom(type)) {
            return new Year(time);
        } else if (java.util.Date.class.isAssignableFrom(type)) {
            return new java.util.Date(time);
        } else {
            throw new IllegalUPAArgumentException();
        }
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        if (!super.equals(o)) return false;

        YearType yearType = (YearType) o;

        if (min != null ? !min.equals(yearType.min) : yearType.min != null) return false;
        return max != null ? max.equals(yearType.max) : yearType.max == null;
    }

    @Override
    public int hashCode() {
        int result = super.hashCode();
        result = 31 * result + (min != null ? min.hashCode() : 0);
        result = 31 * result + (max != null ? max.hashCode() : 0);
        return result;
    }

    @Override
    public TemporalOption getTemporalOption() {
        return TemporalOption.YEAR;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder("YearType[" + getPlatformType().getName() + "]");
        Map<String, Object> v = new LinkedHashMap<String, Object>();
//        if(name!=null){
//            v.put("name",name);
//        }
        if (min != null) {
            v.put("min", min);
        }
        if (min != null) {
            v.put("max", max);
        }
        if (v.size() > 0) {
            sb.append(v);
        }
        return sb.toString();
    }

    @Override
    public DataTypeInfo getInfo() {
        DataTypeInfo d = super.getInfo();
        if(min!=null) {
            d.getProperties().put("min", String.valueOf(PlatformUtils.formatUniversalYear(min)));
        }
        if(max!=null) {
            d.getProperties().put("max", String.valueOf(PlatformUtils.formatUniversalYear(max)));
        }
        return d;
    }

    @Override
    public java.util.Date parse(String value) {
        if(value==null || value.trim().isEmpty()){
            return null;
        }
        return validateDate(new Year(Integer.parseInt(value)));
    }
}
