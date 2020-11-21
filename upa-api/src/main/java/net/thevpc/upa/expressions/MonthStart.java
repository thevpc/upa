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

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

/**
 * the date at the start of the next "count" month of the given "date"
 * <pre>
 * monthstart()
 *      params
 *          N/A
 *      Synopsis :
 *          the date at the end of the current month
 *          equivalent to : monthstart(CurrentTimestamp(),0) : the date at the end of the month
 *
 * monthstart(count)
 *      params
 *          count : integer expression
 *      Synopsis :
 *          the date at the end of the next "count" month. when count=0, the end of the current month
 *          equivalent to : monthend(CurrentTimestamp(),count)
 * monthstart(date,count)
 *      params
 *          date  : date expression
 *          count : integer expression
 *      Synopsis  :
 *          the date at the end of the next "count" month. when count=0, the end of the current month
 * </pre>
 */
public class MonthStart extends FunctionExpression {

    private static final long serialVersionUID = 1L;
    private List<Expression> expressions = new ArrayList<Expression>(2);

    public MonthStart(Expression[] expressions) {
        if (expressions.length != 0 && expressions.length != 1 && expressions.length != 2) {
            checkArgCount(getName(), expressions, 1);
        }
        this.expressions.addAll(Arrays.asList(expressions));
    }

    public MonthStart() {

    }

    public MonthStart(Expression date, Expression count) {
        expressions.add(date);
        expressions.add(count);
    }

    public MonthStart(Expression count) {
        expressions.add(count);
    }

    @Override
    public void setArgument(int index, Expression e) {
        expressions.set(index, e);
    }

    @Override
    public String getName() {
        return "MonthStart";
    }

    @Override
    public int getArgumentsCount() {
        return expressions.size();
    }

    @Override
    public Expression getArgument(int index) {
        return expressions.get(index);
    }

    @Override
    public Expression copy() {
        MonthStart o = new MonthStart();
        for (Expression expression : expressions) {
            o.expressions.add(expression.copy());
        }
        return o;
    }

}
