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
package net.vpc.upa.expressions;

import net.vpc.upa.exceptions.IllegalUPAArgumentException;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

/**
 * Created by IntelliJ IDEA. User: root Date: 22 mai 2003 Time: 10:07:06 To
 * change this template use Options | File Templates.
 */
public class Decode extends FunctionExpression implements Cloneable {

    private static final long serialVersionUID = 1L;
    private ArrayList<Expression> params;
    private final int EXPECT_CONDITION = 0;
    private final int VALID = 2;
    private int state = 0;

    private Decode() {
        params = new ArrayList<Expression>(2);
    }

    public Decode(Expression[] expressions) {
        params = new ArrayList<Expression>(Arrays.asList(expressions));
        state = VALID;
    }

    public Decode(List<Expression> expressions) {
        params = new ArrayList<Expression>(expressions);
        state = VALID;
    }

    public Decode(Expression expression) {
        params = new ArrayList<Expression>(2);
        add(expression);
        state = EXPECT_CONDITION;
    }

    @Override
    public void setArgument(int index, Expression e) {
        params.set(index, e);
        state = VALID;
    }

    //    public If Then(Object value){
//        return Then(Litteral.toExpression(value));
//    }
    public Decode map(Expression oldValue, Expression newValue) {
        if (state != VALID) {
            add(oldValue);
            add(newValue);
            return this;
        } else {
            throw new IllegalUPAArgumentException("No more tokens are expected");
        }
    }

    //    public If Else(Object value){
//        return Else(Litteral.toExpression(value));
//    }
    public Decode otherwise(Expression value) {
        if (state != VALID) {
            add(value);
            state = VALID;
            return this;
        } else {
            throw new IllegalUPAArgumentException("Expected a value");
        }
    }

    private void add(Expression expression) {
        params.add(expression);
    }

    @Override
    public boolean isValid() {
        return state == VALID;
    }

    //    public String toSQL(boolean flag, PersistenceUnit database) {
//        throw new IllegalUPAArgumentException("Not supported");
//    }
    @Override
    public String getName() {
        return "Decode";
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
        Decode o = new Decode();
        for (Expression param : params) {
            o.params.add(param.copy());
        }
        o.state = state;
        return o;
    }

}
