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

import net.vpc.upa.types.DataType;
import net.vpc.upa.types.TypesFactory;

public final class NullVal extends FunctionExpression
        implements Cloneable {

    private static final long serialVersionUID = 1L;
    private DataType type;

    public NullVal(Expression[] expressions) {
        if(expressions.length!=0 && expressions.length!=1 && expressions.length!=2) {
            checkArgCount(getName(), expressions, 1);
        }
        this.type=(DataType) ((Cst) expressions[0]).getValue();
    }

    public NullVal(DataType type) {
        this.type = type;
    }

    @Override
    public void setArgument(int index, Expression e) {
        if (index == 0) {
            this.type = (DataType) ((Cst) e).getValue();
        } else {
            throw new ArrayIndexOutOfBoundsException();
        }
    }

    @Override
    public String getName() {
        return "NullVal";
    }

    @Override
    public int getArgumentsCount() {
        return 1;
    }

    @Override
    public Expression getArgument(int index) {
        if (index != 0) {
            throw new ArrayIndexOutOfBoundsException();
        }
        return new Cst(type);
    }

//    public synchronized String toSQL(boolean integrated, PersistenceUnit database) {
//        return "nullval("+database.getPersistenceManager().getSqlTypeName(type.getType())+")";
//    }
//    public Object clone() {
//        return new NullVal(type);
//    }
    public String getDescription() {
        return "NULL";
    }

    @Override
    public Expression copy() {
        NullVal o = new NullVal(type);
        return o;
    }

    public String toString() {
        Class javaClass = type.getPlatformType();
        int length = type.getScale();
        int precision = type.getPrecision();

        String tname = TypesFactory.getTypeName(javaClass);
        if (tname == null) {
            tname = ("UNKNOWN_TYPE(" + javaClass.getName() + "," + length + "," + precision + ")");
        }
        if (javaClass.equals(String.class)) {
            if (length > 0) {
                tname = tname + "(" + length + ")";
            }
        }
        return "nullval(" + tname + ")";
    }
}
