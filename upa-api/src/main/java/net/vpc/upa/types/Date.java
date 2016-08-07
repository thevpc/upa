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

/**
 * User: taha
 * Date: 5 sept. 2003
 * Time: 13:02:55
 */
@PortabilityHint(target = "C#", name = "partial")
public class Date extends Temporal {
    @PortabilityHint(target = "C#", name = "ignore")
    public static final long serialVersionUID = 1L;


    @PortabilityHint(target = "C#", name = "ignore")
    public Date() {
        this(System.currentTimeMillis());
    }


    @PortabilityHint(target = "C#", name = "ignore")
    public Date(java.util.Date date) {
        this(date.getTime());
    }

    public Date(long date) {
        super(validateTime(date));
    }

    public Date nextDay() {
        return getRelativeDay(1);
    }

    public Date previousDay() {
        return getRelativeDay(-1);
    }

    @PortabilityHint(target = "C#", name = "ignore")
    public Date getRelativeDay(int relative) {
        Calendar calendar = Calendar.getInstance();
        calendar.setTimeInMillis(getTime());
        calendar.add(Calendar.DAY_OF_YEAR, relative);
        return new Date(calendar.getTime());
    }

    @PortabilityHint(target = "C#", name = "ignore")
    private static long validateTime(long time) {
        Calendar calendar = Calendar.getInstance();
        calendar.setTimeInMillis(time);
        calendar.set(Calendar.HOUR_OF_DAY, 0);
        calendar.set(Calendar.MINUTE, 0);
        calendar.set(Calendar.SECOND, 0);
        calendar.set(Calendar.MILLISECOND, 0);
        return calendar.getTime().getTime();
    }

    @Override
    public String toString() {
        Calendar c = Calendar.getInstance();
        c.setTime(this);
        int year = c.get(Calendar.YEAR);
        int month = c.get(Calendar.MONTH) + 1;
        int day = c.get(Calendar.DAY_OF_MONTH);
        char[] buf = "2000-00-00".toCharArray();
        buf[0] = (char) ('0' + (year / 1000));
        buf[1] = (char) ('0' + ((year / 100) % 10));
        buf[2] = (char) ('0' + ((year / 10) % 10));
        buf[3] = (char) ('0' + (year % 10));
        buf[5] = (char) ('0' + (month / 10));
        buf[6] = (char) ('0' + (month % 10));
        buf[8] = (char) ('0' + (day / 10));
        buf[9] = (char) ('0' + (day % 10));
        return new String(buf);
    }

}
