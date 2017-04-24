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
package net.vpc.upa.expressions;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;


/**
 * the date at the end of the next "count" month of the given "date"
 * <pre>
 * monthend()
 *      params
 *          N/A
 *      Synopsis :
 *          the date at the end of the current month
 *          equivalent to : monthend(CurrentTimestamp(),0) : the date at the end of the month
 *
 * monthend(count)
 *      params
 *          count : integer expression
 *      Synopsis :
 *          the date at the end of the next "count" month. when count=0, the end of the current month
 *          equivalent to : monthend(CurrentTimestamp(),count)
 * monthend(date,count)
 *      params
 *          date  : date expression
 *          count : integer expression
 *      Synopsis  :
 *          the date at the end of the next "count" month. when count=0, the end of the current month
 * </pre>
 */
public class MonthEnd extends FunctionExpression {
    private static final long serialVersionUID = 1L;
    private List<Expression> expressions = new ArrayList<Expression>(2);

    public MonthEnd() {

    }

    public MonthEnd(Expression[] expressions) {
        if(expressions.length!=0 && expressions.length!=1 && expressions.length!=2) {
            checkArgCount(getName(), expressions, 1);
        }
        this.expressions.addAll(Arrays.asList(expressions));
    }

    public MonthEnd(Expression date, Expression count) {
        expressions.add(date);
        expressions.add(count);
    }

    public MonthEnd(Expression count) {
        expressions.add(count);
    }

    @Override
    public void setArgument(int index, Expression e) {
        expressions.set(index, e);
    }
    

//    public String toSQL(boolean integrated, PersistenceUnit database) {
//        return "i2v("+e.toSQL(true, database)+")";
//    }

//    public static Expression toExpression(Object value) {
//        return ((Expression) (value == null || !(value instanceof Expression) ? new I2V((String)(value)) : (Expression) value));
//    }

    @Override
    public String getName() {
        return "MonthEnd";
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
        MonthEnd o = new MonthEnd();
        for (Expression expression : expressions) {
            o.expressions.add(expression.copy());
        }
        return o;
    }
}
