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

/**
 * User: taha Date: 5 sept. 2003 Time: 13:02:55
 */
public class Timestamp extends Temporal {

    public static final long serialVersionUID = 1L;
    private int nanos;

    public Timestamp() {
        this(System.currentTimeMillis());
    }

    public Timestamp(java.util.Date date) {
        this(date.getTime());
    }

    public Timestamp(long time) {
        super((time / 1000) * 1000);
        nanos = (int) ((time % 1000) * 1000000);
        if (nanos < 0) {
            nanos = 1000000000 + nanos;
            super.setTime(((time / 1000) - 1) * 1000);
        }
    }

    public long getTime() {
        long time = super.getTime();
        return (time + (nanos / 1000000));
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

    @Override
    public String toString() {

        Calendar c = Calendar.getInstance();
        c.setTimeInMillis(getTime());
        int year = c.get(Calendar.YEAR);
        int month = c.get(Calendar.MONTH) + 1;
        int day = c.get(Calendar.DAY_OF_MONTH);
        int hour = c.get(Calendar.HOUR_OF_DAY);
        int minute = c.get(Calendar.MINUTE);
        int second = c.get(Calendar.SECOND);

//        int year = super.getYear() + 1900;
//        int month = super.getMonth() + 1;
//        int day = super.getDate();
//        int hour = super.getHours();
//        int minute = super.getMinutes();
//        int second = super.getSeconds();
        String yearString;
        String monthString;
        String dayString;
        String hourString;
        String minuteString;
        String secondString;
        String nanosString;
        String zeros = "000000000";
        String yearZeros = "0000";
        StringBuffer timestampBuf;

        if (year < 1000) {
            // Add leading zeros
            yearString = "" + year;
            yearString = yearZeros.substring(0, (4 - yearString.length()))
                    + yearString;
        } else {
            yearString = "" + year;
        }
        if (month < 10) {
            monthString = "0" + month;
        } else {
            monthString = Integer.toString(month);
        }
        if (day < 10) {
            dayString = "0" + day;
        } else {
            dayString = Integer.toString(day);
        }
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
        if (nanos == 0) {
            nanosString = "0";
        } else {
            nanosString = Integer.toString(nanos);

            // Add leading zeros
            nanosString = zeros.substring(0, (9 - nanosString.length()))
                    + nanosString;

            // Truncate trailing zeros
            char[] nanosChar = new char[nanosString.length()];
            nanosString.getChars(0, nanosString.length(), nanosChar, 0);
            int truncIndex = 8;
            while (nanosChar[truncIndex] == '0') {
                truncIndex--;
            }

            nanosString = new String(nanosChar, 0, truncIndex + 1);
        }

        // do a string buffer here instead.
        timestampBuf = new StringBuffer(20 + nanosString.length());
        timestampBuf.append(yearString);
        timestampBuf.append("-");
        timestampBuf.append(monthString);
        timestampBuf.append("-");
        timestampBuf.append(dayString);
        timestampBuf.append(" ");
        timestampBuf.append(hourString);
        timestampBuf.append(":");
        timestampBuf.append(minuteString);
        timestampBuf.append(":");
        timestampBuf.append(secondString);
        timestampBuf.append(".");
        timestampBuf.append(nanosString);

        return (timestampBuf.toString());
    }
}
