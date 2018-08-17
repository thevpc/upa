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

import java.io.Serializable;
import java.util.Calendar;
import java.util.Date;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 29 avr. 2003
 * Time: 09:16:24
 * 
 */
@PortabilityHint(target = "C#", name = "partial")
public class DatePeriod implements Serializable {
    private int count;
    private PeriodOption periodType;

    public DatePeriod(int count, PeriodOption type) {
        this.count = count;
        this.periodType = type;
    }

    public int getCount() {
        return count;
    }

    public PeriodOption getPeriodType() {
        return periodType;
    }

    @Override
    public String toString() {
        return count + " " + periodType.name();
    }

    @Override
    public int hashCode() {
        return count + 31 * periodType.hashCode();
    }

    @Override
    public boolean equals(Object obj) {
        if (obj == null) {
            return false;
        }
        DatePeriod datePeriod = (DatePeriod) obj;
        return (count == datePeriod.count) && (periodType == datePeriod.periodType);
    }

    @PortabilityHint(target = "C#", name = "ignore")
    public int compare(DatePeriod other, Date startDate) {
        Calendar c = Calendar.getInstance();
        c.setTime(startDate);
        switch (periodType) {
            case DAY: {
                c.add(Calendar.DATE, count);
                break;
            }
            case MONTH: {
                c.add(Calendar.MONTH, count);
                break;
            }
            case YEAR: {
                c.add(Calendar.YEAR, count);
                break;
            }
        }
        long d1 = c.getTime().getTime();
        c.setTime(startDate);
        switch (other.periodType) {
            case DAY: {
                c.add(Calendar.DATE, other.count);
                break;
            }
            case MONTH: {
                c.add(Calendar.MONTH, other.count);
                break;
            }
            case YEAR: {
                c.add(Calendar.YEAR, other.count);
                break;
            }
        }
        long d2 = c.getTime().getTime();
        return d1 == d2 ? 0 : d1 > d2 ? 1 : -1;
    }

    @PortabilityHint(target = "C#", name = "ignore")
    public Date next(Date startDate) {
        Calendar c = Calendar.getInstance();
        c.setTime(startDate);
        switch (periodType) {
            case DAY: {
                c.add(Calendar.DATE, count);
                break;
            }
            case MONTH: {
                c.add(Calendar.MONTH, count);
                break;
            }
            case YEAR: {
                c.add(Calendar.YEAR, count);
                break;
            }
        }
        return c.getTime();
    }
}
