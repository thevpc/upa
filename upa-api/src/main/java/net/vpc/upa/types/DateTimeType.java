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

import java.util.Calendar;
import java.util.LinkedHashMap;
import java.util.Map;

public class DateTimeType extends TemporalType implements Cloneable {

    public static final DateTimeType DEFAULT = new DateTimeType("DATE", DateTime.class, null, null, true);

    @PortabilityHint(target = "C#", name = "suppress")
    public static final DateTimeType JAVA_UTIL = new DateTimeType("DATE", java.util.Date.class, null, null, true);

    protected DateTime min = null;
    protected DateTime max = null;

    public DateTimeType(String name, Class<? extends java.util.Date> type, boolean nullable) {
        this(name, type, null, null, nullable);
    }

    public DateTimeType(String name, Class<? extends java.util.Date> type, DateTime min, DateTime max, boolean nullable) {
        super(name, type == null ? DateTime.class : type, 0, 0, nullable);
        if (type != null && !type.equals(DateTime.class) && !type.equals(java.util.Date.class) && !type.equals(java.sql.Timestamp.class)) {
            throw new net.vpc.upa.exceptions.IllegalArgumentException("Invalid Temporal Type " + type);
        }
        this.min = min;
        this.max = max;
        setDefaultNonNullValue(convert(new DateTime(0)));
    }

    public DateTime getMin() {
        return min;
    }

    public DateTime getMax() {
        return max;
    }

    public void setMin(DateTime newMin) {
        min = newMin;
    }

    public void setMax(DateTime newMax) {
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

        Calendar c = Calendar.getInstance();
        c.setTime(date);
        long time = date.getTime();
        if (DateTime.class.isAssignableFrom(type)) {
            return new DateTime(time);
        } else if (java.util.Date.class.isAssignableFrom(type)) {
            return new java.util.Date(time);
        } else {
            throw new net.vpc.upa.exceptions.IllegalArgumentException();
        }
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder("DateTimeType[" + getPlatformType().getName() + "]");
        Map<String, Object> v = new LinkedHashMap<>();
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
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        if (!super.equals(o)) return false;

        DateTimeType that = (DateTimeType) o;

        if (min != null ? !min.equals(that.min) : that.min != null) return false;
        return max != null ? max.equals(that.max) : that.max == null;
    }

    @Override
    public int hashCode() {
        int result = super.hashCode();
        result = 31 * result + (min != null ? min.hashCode() : 0);
        result = 31 * result + (max != null ? max.hashCode() : 0);
        return result;
    }
}
