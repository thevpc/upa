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

import java.util.ArrayList;

public final class Concat extends FunctionExpression
        implements Cloneable {

    private static final long serialVersionUID = 1L;
    private ArrayList<Expression> elements;

    public Concat() {
        elements = new ArrayList<Expression>(1);
    }

    public Concat(Expression[] expressions) {
        elements = new ArrayList<Expression>(expressions.length);
        for (Expression expression : expressions) {
            add(expression);
        }
    }

    @Override
    public void setArgument(int index, Expression e) {
        elements.set(index, e);
    }

    public Concat clear() {
        elements.clear();
        return this;
    }

    public Concat addAll(Concat other) {
        for (int i = 0; i < other.getArgumentsCount(); i++) {
            add((Expression) other.getArgument(i));
        }

        return this;
    }

    public Concat add(Expression expression) {
        if (expression == this) {
            throw new NullPointerException();
        } else {
            elements.add(expression);
            return this;
        }
    }

    public int getArgumentsCount() {
        return elements.size();
    }

    public Expression getArgument(int i) {
        return (Expression) elements.get(i);
    }

    public boolean isValid() {
        int max = getArgumentsCount();
        boolean valid = false;
        for (int i = 0; i < max; i++) {
            Expression e = getArgument(i);
            if (e.isValid()) {
                valid = true;
            }
        }

        return valid;
    }

    @Override
    public String getName() {
        return "Concat";
    }

    @Override
    public Expression copy() {
        Concat o = new Concat();
        for (Expression element : elements) {
            o.add((element).copy());
        }
        return o;
    }

}
