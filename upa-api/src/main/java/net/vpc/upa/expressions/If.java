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
import java.util.List;

/**
 * Created by IntelliJ IDEA.
 * User: root
 * Date: 22 mai 2003
 * Time: 10:07:06
 * To change this template use Options | File Templates.
 */
public class If extends Function implements Cloneable {
    private static final long serialVersionUID = 1L;
    private final int EXPECT_CONDITION = 0;
    private final int EXPECT_VALUE = 1;
    private final int VALID = 2;
    private ArrayList<Expression> params;
    private int state = 0;

    private If() {
        params = new ArrayList<Expression>();
    }

    public If(List<Expression> expressions) {
        params = new ArrayList<Expression>(2);
        params.addAll(expressions);
        state = VALID;
    }

    public If(Expression condition) {
        params = new ArrayList<Expression>(2);
        add(condition);
        state = EXPECT_VALUE;
    }

//    public If Then(Object value){
//        return Then(Litteral.toExpression(value));
//    }

    public If Then(Expression value) {
        if (state == EXPECT_VALUE) {
            add(value);
            state = EXPECT_CONDITION;
            return this;
        } else if (state == VALID) {
            throw new IllegalArgumentException("No more tokens are expected");
        } else {
            throw new IllegalArgumentException("Expected a value");
        }
    }

//    public If Else(Object value){
//        return Else(Litteral.toExpression(value));
//    }

    public If Else(Expression value) {
        if (state == EXPECT_CONDITION) {
            add(value);
            state = VALID;
            return this;
        } else if (state == VALID) {
            throw new IllegalArgumentException("No more tokens are expected");
        } else {
            throw new IllegalArgumentException("Expected a value");
        }
    }

//    public If ElseIf(String condition){
//        return ElseIf(new UserExpression(condition));
//    }

    public If ElseIf(Expression condition) {
        if (state == EXPECT_CONDITION) {
            add(condition);
            state = EXPECT_VALUE;
            return this;
        } else if (state == VALID) {
            throw new IllegalArgumentException("No more tokens are expected");
        } else {
            throw new IllegalArgumentException("Expected a condition");
        }
    }

    private void add(Expression expression) {
        params.add(expression);
    }

    public boolean isValid() {
        return state == VALID;
    }

    @Override
    public String getName() {
        return "If";
    }

    @Override
    public int getArgumentsCount() {
        return params.size();
    }

    @Override
    public Expression getArgument(int index) {
        return params.get(index);
    }

    @Override
    public Expression copy() {
        If o = new If();
        o.state = state;
        for (Expression param : params) {
            o.params.add(param.copy());
        }
        return o;
    }

    //if (0) then 1 end
    //if (0) then 1 else 2 end
    //if (0) then 1 elseif 2 then 3 else 4 end
    @Override
    public String toString() {
        StringBuilder s = new StringBuilder();
        int i = 0;
        for (Expression expression : params) {
            if (i % 2 == 0) {
                if (i == 0) {
                    s.append("if (").append(expression).append(") then ");
                } else if (i < params.size() - 1) {
                    s.append(" elseif (").append(expression).append(") then ");
                } else {
                    s.append(" else (");
                    s.append(expression);
                    s.append(")");
                }
            } else {
                s.append(" (").append(expression).append(")");
            }
            i++;
        }
        s.append(" end");
        return s.toString();
    }

}
