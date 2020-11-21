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
package net.thevpc.upa.expressions;

import java.util.Date;

/**
 * Created by IntelliJ IDEA. User: root Date: 22 mai 2003 Time: 12:07:34 To
 * change this template use Options | File Templates.
 */
public class DateDiff extends FunctionExpression {

    private static final long serialVersionUID = 1L;
    private DatePartType datePartType;
    private Expression start;
    private Expression end;

    public DateDiff(Expression[] expressions) {
        checkArgCount(getName(), expressions, 3);
        init((DatePartType) ((Cst) expressions[0]).getValue(), expressions[1], expressions[2]);
    }

    public DateDiff(DatePartType datePartType, Date date1, Date date2) {
        this(datePartType, new Literal(date1), new Literal(date2));
    }

    public DateDiff(DatePartType datePartType, Expression startDate, Expression endDate) {
        init(datePartType, startDate, endDate);
    }

    private void init(DatePartType datePartType, Expression startDate, Expression endDate) {
        this.datePartType = datePartType;
        this.start = startDate;
        this.end = endDate;
    }

    public DatePartType getDatePartType() {
        return datePartType;
    }

    public Expression getStart() {
        return start;
    }

    public Expression getEnd() {
        return end;
    }
    //    public String toSQL(boolean flag, PersistenceUnit database) {
//        return "DateDiff("+type.getName().toLowerCase()+","+start.toSQL(true, database)+","+end.toSQL(true, database)+")";
//    }

    @Override
    public String getName() {
        return "DateDiff";
    }

    @Override
    public int getArgumentsCount() {
        return 3;
    }

    @Override
    public Expression getArgument(int index) {
        switch (index) {
            case 0:
                return new Cst(datePartType);
            case 1:
                return start;
            case 2:
                return end;
        }
        throw new IndexOutOfBoundsException();
    }


    @Override
    public void setArgument(int index, Expression e) {
        switch (index) {
            case 0: {
                datePartType = (DatePartType) ((Cst) e).getValue();
                break;
            }
            case 1: {
                start = e;
                break;
            }
            case 2: {
                end = e;
                break;
            }
        }
        throw new IndexOutOfBoundsException();
    }

    @Override
    public Expression copy() {
        DateDiff o = new DateDiff(datePartType, start.copy(), end.copy());
        return o;
    }
}
