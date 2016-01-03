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

import net.vpc.upa.PortabilityHint;

import java.util.Calendar;
import java.util.Date;

public class TimeType extends TemporalType implements Cloneable {
    public static final TimeType DEFAULT = new TimeType("DATE", Time.class, null, null, true);

    @PortabilityHint(target = "C#", name = "suppress")
    public static final TimeType JAVA_SQL = new TimeType("DATE", java.sql.Time.class, null, null, true);

    @PortabilityHint(target = "C#", name = "suppress")
    public static final TimeType JAVA_UTIL = new TimeType("DATE", java.util.Date.class, null, null, true);

    protected Time min = null;
    protected Time max = null;

    public TimeType(boolean nullable) {
        this("TIME", Time.class, null, null, nullable);
    }

    public TimeType(Time min, Time max, boolean nullable) {
        this("TIME", Time.class, min, max, nullable);
    }

    public TimeType(Class<? extends Date> type, boolean nullable) {
        this("TIME", type, null, null, nullable);
    }

    public TimeType(Class<? extends Date> type, Time min, Time max, boolean nullable) {
        this("TIME", type, min, max, nullable);
    }

    public TimeType(String name, Class<? extends Date> type, boolean nullable) {
        this(name, type, null, null, nullable);
    }

    public TimeType(String name, Class<? extends Date> type, Time min, Time max, boolean nullable) {
        super(name, type == null ? net.vpc.upa.types.Time.class : type, 0, 0, nullable);
        if (
                type != null &&
                        /**@PortabilityHint(target="C#",name="suppress",value="begin")*/
                        !java.sql.Time.class.equals(type) &&
                        /**@PortabilityHint(target="C#",name="suppress",value="end")*/
                        !Time.class.equals(type) && !java.util.Date.class.equals(type)) {
            throw new IllegalArgumentException("Invalid Temporal Type " + type);
        }
        this.min = min;
        this.max = max;
        setDefaultNonNullValue(convert(new DateTime(0)));
    }

    public Time getMin() {
        return min;
    }

    public Time getMax() {
        return max;
    }

    public void setMin(Time newMin) {
        min = newMin;
    }

    public void setMax(Time newMax) {
        max = newMax;
    }

    @Override
    public void check(Object value, String name, String description) throws ConstraintsException {
        super.check(value, name, description);
        if (value == null) {
            return;
        }
        if (getMin() != null && getMin().compareTo((Date) value) > 0) {
            throw new ConstraintsException("DateTooEarly", name, description, value, min);
        }
        if (getMax() != null && getMax().compareTo((Date) value) < 0) {
            throw new ConstraintsException("DateTooLate", name, description, value, max);
        }
    }

    @Override
    public Object convert(Object value) {
        if (value == null) {
            return null;
        }
        if (value instanceof Date) {
            return validateDate((Date) value);
        }
        return super.convert(value);
    }


    public Date validateDate(Date date) {
        if (date == null) {
            return null;
        }
        Class type = getPlatformType();

        Calendar c = Calendar.getInstance();
        c.setTime(date);
        long time = date.getTime();
        if (java.sql.Time.class.isAssignableFrom(type)) {
            return new java.sql.Time(time);
        } else if (Time.class.isAssignableFrom(type)) {
            return new Time(time);
        } else if (java.util.Date.class.isAssignableFrom(type)) {
            return new java.util.Date(time);
        } else {
            throw new IllegalArgumentException();
        }
    }
}
