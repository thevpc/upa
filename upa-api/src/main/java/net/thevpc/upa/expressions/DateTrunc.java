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
public class DateTrunc extends FunctionExpression {

    private static final long serialVersionUID = 1L;
    private DatePartType datePartType;
    private Expression value;

    public DateTrunc(Expression[] expressions) {
        checkArgCount(getName(), expressions, 2);
        init((DatePartType) ((Cst) expressions[0]).getValue(), expressions[1]);
    }

    public DateTrunc(DatePartType type, Date date) {
        this(type, new Literal(date));
    }

    public DateTrunc(DatePartType type, String varDate) {
        this(type, new UserExpression(varDate));
    }

    public DateTrunc(DatePartType type, Expression val) {
        init(type, val);
    }

    private void init(DatePartType type, Expression val) {
        this.datePartType = type;
        this.value = val;
    }

    public DatePartType getDatePartType() {
        return datePartType;
    }

    public Expression getValue() {
        return value;
    }

    @Override
    public String getName() {
        return "datetrunc";
    }

    @Override
    public int getArgumentsCount() {
        return 2;
    }

    @Override
    public Expression getArgument(int index) {
        switch (index) {
            case 0:
                return new Cst(datePartType);
            case 1:
                return value;
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
                value = e;
                break;
            }
        }
        throw new IndexOutOfBoundsException();
    }

    @Override
    public Expression copy() {
        DateTrunc o = new DateTrunc(datePartType, value.copy());
        return o;
    }
}
