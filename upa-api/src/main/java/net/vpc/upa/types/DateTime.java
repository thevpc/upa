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

import java.util.Calendar;
import java.util.Date;

/**
 * User: taha Date: 5 sept. 2003 Time: 13:01:29
 */
public class DateTime extends Temporal {

    public static final long serialVersionUID = 1L;

    public DateTime() {
    }

    public DateTime(long date) {
        super(date);
    }

    public DateTime(Date date) {
        super(date.getTime());
    }

    @Override
    public String toString() {
        return super.toString();//UserFormats.getShortDateTimeFormat().format(this);
    }

    public static DateTime forDetails(int year, int month, int day) {
        return forDetails(year, month, day, 0, 0, 0, 0);
    }

    public static DateTime forDetails(int year, int month, int day, int hour, int minute, int seconds) {
        return forDetails(year, month, day, hour, minute, seconds, 0);
    }

    public static DateTime forDetails(int year, int month, int day, int hour, int minute, int seconds, int millis) {
        Calendar c = Calendar.getInstance();
        c.set(Calendar.YEAR, year);
        c.set(Calendar.MONTH, month);
        c.set(Calendar.DAY_OF_MONTH, day);
        c.set(Calendar.HOUR_OF_DAY, hour);
        c.set(Calendar.MINUTE, minute);
        c.set(Calendar.SECOND, seconds);
        c.set(Calendar.MILLISECOND, millis);
        return new DateTime(c.getTimeInMillis());
    }

    public int getYearValue() {
        Calendar calendar = Calendar.getInstance();
        calendar.setTimeInMillis(getTime());
        return calendar.get(Calendar.YEAR);
    }

    public int getMonthValue() {
        Calendar calendar = Calendar.getInstance();
        calendar.setTimeInMillis(getTime());
        return calendar.get(Calendar.MONTH);
    }

    public int getDateValue() {
        Calendar calendar = Calendar.getInstance();
        calendar.setTimeInMillis(getTime());
        return calendar.get(Calendar.DATE);
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
}
