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

import java.util.Collections;

import net.vpc.upa.types.DataType;
import net.vpc.upa.types.TypesFactory;

import java.util.Date;
import java.util.List;

// Referenced classes of package net.vpc.lib.pheromone.ariana.database.sql:
//            Expression
public final class Literal extends DefaultExpression
        implements Cloneable {

    public static final Literal IONE = new Literal(1);
    public static final Literal IZERO = new Literal(0);
    public static final Literal DZERO = new Literal(0.0);
    public static final Literal ZERO = DZERO;
    public static final Literal NULL = new Literal(0);
    public static final Literal TRUE = new Literal(true);
    public static final Literal FALSE = new Literal(false);
    public static final Literal EMPTY_STRING = new Literal("");
    private static final long serialVersionUID = 1L;
    private DataType type;
    private Object value;

    public Literal(Date date) {
        setValue(date);
    }

    public Literal(int value) {
        setValue(value);
    }

    public Literal(boolean value) {
        setValue((value) ? Boolean.TRUE : Boolean.FALSE);
    }

    public Literal(long value) {
        setValue(value);
    }

    public Literal(float value) {
        setValue(value);
    }

    public Literal(double value) {
        setValue(value);
    }

    public Literal(char value) {
        setValue(value);
    }

    public Literal(String value) {
        setValue(value);
    }

    public Literal(Object value, DataType type) {

//        if (
//                value != null
//                && !(value instanceof String)
//                && !(value instanceof Number)
//                && !(value instanceof Date)
//                && !(value instanceof Boolean)
//        ) {
//            throw new RuntimeException("bad sql value : " + value.getClass().getName() + " ==> " + value);
//        } else {
        this.value = value;

        if (type == null) {
            if (value == null) {
                type = TypesFactory.OBJECT;
            } else {
                type = TypesFactory.forPlatformType(value.getClass());
            }
        }
        this.type = type;
//            return;
//        }
    }

    @Override
    public List<TaggedExpression> getChildren() {
        return Collections.EMPTY_LIST;
    }

    @Override
    public void setChild(Expression e, ExpressionTag tag) {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    public static boolean isNull(Expression e) {
        return e == null || ((e instanceof Literal) && (((Literal) e).value == null));
    }

    @Override
    public String toString() {
        if (value instanceof String) {
            return ExpressionHelper.escapeSimpleQuoteStringLiteral((String) value);
        }
        return String.valueOf(value);
    }

    public Object getValue() {
        return value;
    }

    private void setValue(Object o) {
        this.value = o;
        if (o == null) {
            type = TypesFactory.OBJECT;
        } else {
            type = TypesFactory.forPlatformType(o.getClass());
        }
    }

    @Override
    public Expression copy() {
        return new Literal(value, type);
    }
}
