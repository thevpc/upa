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
import net.thevpc.upa.PortabilityHint;

import java.sql.Time;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Arrays;
import java.util.Date;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/12/13 3:44 AM
 */
@PortabilityHint(target = "C#",name = "ignore")
public class PlatformUtils {
    public static final DateFormat UNIVERSAL_TIMESTAMP_FORMAT = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss.SSS");
    public static final DateFormat UNIVERSAL_DATE_TIME_FORMAT = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
    public static final DateFormat UNIVERSAL_DATE_FORMAT = new SimpleDateFormat("yyyy-MM-dd");
    public static final DateFormat UNIVERSAL_TIME_FORMAT = new SimpleDateFormat("HH:mm:ss");
    public static final DateFormat UNIVERSAL_YEAR_FORMAT = new SimpleDateFormat("yyyy");
    public static final DateFormat UNIVERSAL_MONTH_YEAR_FORMAT = new SimpleDateFormat("yyyy-MM");

    public static Date parseUniversalDateTime(String date) {
        try {
            return UNIVERSAL_DATE_TIME_FORMAT.parse(date);
        } catch (ParseException e) {
            throw new IllegalUPAArgumentException(e);
        }
    }

    public static String formatUniversalDateTime(Date date){
        return UNIVERSAL_DATE_TIME_FORMAT.format(date);
    }

    public static Date parseUniversalYear(String date) {
        try {
            return UNIVERSAL_YEAR_FORMAT.parse(date);
        } catch (ParseException e) {
            throw new IllegalUPAArgumentException(e);
        }
    }

    public static String formatUniversalYear(Date date){
        return UNIVERSAL_YEAR_FORMAT.format(date);
    }

    public static Date parseUniversalTimestamp(String date) {
        try {
            return UNIVERSAL_TIMESTAMP_FORMAT.parse(date);
        } catch (ParseException e) {
            throw new IllegalUPAArgumentException(e);
        }
    }

    public static String formatUniversalTimestamp(Date date){
        return UNIVERSAL_TIMESTAMP_FORMAT.format(date);
    }

    public static Date parseUniversalMonthYear(String date) {
        try {
            return UNIVERSAL_MONTH_YEAR_FORMAT.parse(date);
        } catch (ParseException e) {
            throw new IllegalUPAArgumentException(e);
        }
    }

    public static String formatUniversalMonthYear(Date date){
        return UNIVERSAL_MONTH_YEAR_FORMAT.format(date);
    }

    public static java.sql.Date parseUniversalDate(String date) {
        try {
            return new java.sql.Date(UNIVERSAL_DATE_FORMAT.parse(date).getTime());
        } catch (ParseException e) {
            throw new IllegalUPAArgumentException(e);
        }
    }

    public static String formatUniversalDate(Date date){
        return UNIVERSAL_DATE_FORMAT.format(date);
    }

    public static Time parseUniversalTime(String date) {
        try {
            return new Time(UNIVERSAL_TIME_FORMAT.parse(date).getTime());
        } catch (ParseException e) {
            throw new IllegalUPAArgumentException(e);
        }
    }

    public static String formatUniversalTime(Date date){
        return UNIVERSAL_TIME_FORMAT.format(date);
    }

    public static Date parseDateTime(String date, String format) throws ParseException {
        SimpleDateFormat simpleDateFormat = new SimpleDateFormat(format);
        return simpleDateFormat.parse(date);
    }

    public static boolean equals(Object a, Object b) {
        return (a == b) || (a != null && a.equals(b));
    }
    
    public static <T> T[] copyOf(T[] original) {
        if(original==null){
            return null;
        }
        return (T[]) Arrays.copyOf(original, original.length, original.getClass());
    }

}
