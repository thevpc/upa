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

public final class StrFormat extends FunctionExpression implements Cloneable {

    private static final long serialVersionUID = 1L;
    private Expression[] expressions;
    private Literal pattern;

    public StrFormat(Expression[] expressions) {
        if (expressions.length < 1) {
            checkArgCount(getName(), expressions, 1);
        }
        this.pattern = (Literal) expressions[0];
        this.expressions = new Expression[expressions.length - 1];
        System.arraycopy(this.expressions, 1, this.expressions, 0, expressions.length - 1);
    }

    public StrFormat(String pattern, Expression... expressions) {
        this.expressions = expressions;
        this.pattern = new Literal(pattern);
    }

    @Override
    public String getName() {
        return "strformat";
    }

    @Override
    public int getArgumentsCount() {
        return expressions.length + 1;
    }

    @Override
    public Expression getArgument(int index) {
        return index == 0 ? pattern : expressions[index - 1];
    }

    @Override
    public void setArgument(int index, Expression e) {
        if (index == 0) {
            this.pattern = (Literal) e;
        } else {
            expressions[index - 1] = e;
        }
    }

    @Override
    public Expression copy() {
        StrFormat o = new StrFormat((String) (pattern.getValue()));
        o.expressions = new Expression[expressions.length];
        for (int i = 0; i < expressions.length; i++) {
            o.expressions[i] = expressions[i].copy();
        }
        return o;
    }
}
