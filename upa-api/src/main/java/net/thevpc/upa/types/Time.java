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

import java.util.Calendar;

import net.thevpc.upa.exceptions.IllegalUPAArgumentException;

/**
 * User: taha Date: 5 sept. 2003 Time: 13:02:55
 */
public class Time extends Temporal {

    public static final long serialVersionUID = 1L;

    public Time() {
        this(System.currentTimeMillis());
    }

    public Time(java.util.Date date) {
        this(date.getTime());
    }

    public Time(long date) {
        super(validateTime(date));

    }

    private static long validateTime(long time) {
        Calendar calendar = Calendar.getInstance();
        calendar.setTimeInMillis(time);
        calendar.set(Calendar.DAY_OF_MONTH, 1);
        calendar.set(Calendar.MONTH, 0);
        calendar.set(Calendar.YEAR, 1900);
        return calendar.getTime().getTime();
    }

    public static Time valueOf(String value) {
        if (value == null || value.length() != 12) {
            throw new IllegalUPAArgumentException("Invalid Time format (expected HH:mm:ss.SSS)");
        }
        try {
            Calendar calendar = Calendar.getInstance();
            calendar.set(Calendar.DAY_OF_MONTH, 1);
            calendar.set(Calendar.MONTH, 0);
            calendar.set(Calendar.YEAR, 1900);
            calendar.set(Calendar.HOUR_OF_DAY, Integer.parseInt(value.substring(0, 2)));
            calendar.set(Calendar.MINUTE, Integer.parseInt(value.substring(3, 5)));
            calendar.set(Calendar.SECOND, Integer.parseInt(value.substring(6, 8)));
            calendar.set(Calendar.MILLISECOND, Integer.parseInt(value.substring(9, 12)));
            return new Time(calendar.getTime().getTime());
        } catch (Exception ex) {
            throw new IllegalUPAArgumentException("Invalid Time format (expected yyyy-MM-dd)", ex);
        }
    }

    public int getHourValue() {
        Calendar calendar = Calendar.getInstance();
        calendar.setTimeInMillis(getTime());
        return calendar.get(Calendar.HOUR_OF_DAY);
    }

    public int getMinuteValue() {
        Calendar calendar = Calendar.getInstance();
        calendar.setTimeInMillis(getTime());
        return calendar.get(Calendar.MINUTE);
    }

    public int getSecondValue() {
        Calendar calendar = Calendar.getInstance();
        calendar.setTimeInMillis(getTime());
        return calendar.get(Calendar.SECOND);
    }

    public int getMillisecondValue() {
        Calendar calendar = Calendar.getInstance();
        calendar.setTimeInMillis(getTime());
        return calendar.get(Calendar.MILLISECOND);
    }

    @Override
    public String toString() {
        Calendar c = Calendar.getInstance();
        c.setTimeInMillis(getTime());
        int hour = c.get(Calendar.HOUR_OF_DAY);
        int minute = c.get(Calendar.MINUTE);
        int second = c.get(Calendar.SECOND);
        int millisecond = c.get(Calendar.MILLISECOND);
        String hourString;
        String minuteString;
        String secondString;
        String millisecondString;

        if (hour < 10) {
            hourString = "0" + hour;
        } else {
            hourString = Integer.toString(hour);
        }
        if (minute < 10) {
            minuteString = "0" + minute;
        } else {
            minuteString = Integer.toString(minute);
        }
        if (second < 10) {
            secondString = "0" + second;
        } else {
            secondString = Integer.toString(second);
        }
        if (second < 10) {
            millisecondString = "00" + millisecond;
        } else if (second < 100) {
            millisecondString = "0" + millisecond;
        } else {
            millisecondString = Integer.toString(second);
        }
        return (hourString + ":" + minuteString + ":" + secondString + "." + millisecondString);
    }
}
