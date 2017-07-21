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
import net.vpc.upa.exceptions.UPAIllegalArgumentException;

import java.util.Calendar;
import java.util.LinkedHashMap;
import java.util.Map;

public class DateType extends TemporalType implements Cloneable {

    public static final DateType DEFAULT = new DateType("DATE", Date.class, null, null, true);

    @PortabilityHint(target = "C#", name = "suppress")
    public static final DateType JAVA_SQL = new DateType("DATE", java.sql.Date.class, null, null, true);

    @PortabilityHint(target = "C#", name = "suppress")
    public static final DateType JAVA_UTIL = new DateType("DATE", java.util.Date.class, null, null, true);

    protected Date min = null;
    protected Date max = null;

    public DateType(String name, Class<? extends java.util.Date> type, boolean nullable) {
        this(name, type, null, null, nullable);
    }

    public DateType(String name, Class<? extends java.util.Date> type, Date min, Date max, boolean nullable) {
        super(name, type == null ? Date.class : type, 0, 0, nullable);
        if (type != null && !type.equals(Date.class) && !type.equals(java.util.Date.class) && !type.equals(java.sql.Date.class)) {
            throw new UPAIllegalArgumentException("Invalid Temporal Type " + type);
        }
        this.min = min;
        this.max = max;
        setDefaultNonNullValue(convert(new DateTime(0)));
    }

    public Date getMin() {
        return min;
    }

    public void setMin(Date newMin) {
        min = newMin;
    }

    public Date getMax() {
        return max;
    }

    public void setMax(Date newMax) {
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

        /**
         * @PortabilityHint(target="C#",name="suppress")
         */
        if (java.sql.Date.class.isAssignableFrom(type)) {
            return new java.sql.Date(time);
        }

        if (Date.class.isAssignableFrom(type)) {
            return new Date(time);
        } else if (java.util.Date.class.isAssignableFrom(type)) {
            return new java.util.Date(time);
        } else {
            throw new UPAIllegalArgumentException();
        }
    }

    public boolean isYearOnly() {
        Class type = getPlatformType();
        return net.vpc.upa.types.Year.class.isAssignableFrom(type);
    }

    public boolean isMonthOnly() {
        Class type = getPlatformType();
        return net.vpc.upa.types.Month.class.isAssignableFrom(type);
    }

    public boolean isDateTime() {
        Class type = getPlatformType();
        return net.vpc.upa.types.DateTime.class.isAssignableFrom(type)
                || java.util.Date.class.equals(type);
    }

    public boolean isDateOnly() {
        Class type = getPlatformType();
        return net.vpc.upa.types.Date.class.isAssignableFrom(type)
                || java.sql.Date.class.isAssignableFrom(type);
    }

    public boolean isTimeOnly() {
        Class type = getPlatformType();
        return net.vpc.upa.types.Time.class.isAssignableFrom(type)
                || java.sql.Time.class.isAssignableFrom(type);
    }

    public boolean isTimestamp() {
        Class type = getPlatformType();
        return net.vpc.upa.types.Timestamp.class.isAssignableFrom(type)
                || java.sql.Timestamp.class.isAssignableFrom(type);
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        if (!super.equals(o)) return false;

        DateType dateType = (DateType) o;

        if (min != null ? !min.equals(dateType.min) : dateType.min != null) return false;
        return max != null ? max.equals(dateType.max) : dateType.max == null;
    }

    @Override
    public int hashCode() {
        int result = super.hashCode();
        result = 31 * result + (min != null ? min.hashCode() : 0);
        result = 31 * result + (max != null ? max.hashCode() : 0);
        return result;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder("DateType[" + getPlatformType().getName() + "]");
        Map<String, Object> v = new LinkedHashMap<String, Object>();
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
}
