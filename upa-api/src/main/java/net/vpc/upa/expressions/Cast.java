/**
 * ==================================================================== UPA
 * (Unstructured Persistence API) Yet another ORM Framework
 * ++++++++++++++++++++++++++++++++++ Unstructured Persistence API, referred to
 * as UPA, is a genuine effort to raise programming language frameworks managing
 * relational data in applications using Java Platform, Standard Edition and
 * Java Platform, Enterprise Edition and Dot Net Framework equally to the next
 * level of handling ORM for mutable data structures. UPA is intended to provide
 * a solid reflection mechanisms to the mapped data structures while affording
 * to make changes at runtime of those data structures. Besides, UPA has learned
 * considerably of the leading ORM (JPA, Hibernate/NHibernate, MyBatis and
 * Entity Framework to name a few) failures to satisfy very common even known to
 * be trivial requirement in enterprise applications.
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

/**
 * Created by IntelliJ IDEA. User: root Date: 22 mai 2003 Time: 12:21:56 To
 * change this template use Options | File Templates.
 */
public class Cast extends FunctionExpression {

    private static final long serialVersionUID = 1L;
    private Expression value;
    private DataType targetType;

    public Cast(Expression[] expressions) {
        checkArgCount(getName(),expressions,2);
        init(expressions[0],(DataType) ((Cst)expressions[1]).getValue());
    }

    public Cast(Expression value, DataType primitiveType) {
        init(value,primitiveType);
    }
    private void init(Expression value, DataType primitiveType) {
        this.value = value;
        this.targetType = primitiveType;
    }

    public Expression getValue() {
        return value;
    }

    public DataType getDataType() {
        return targetType;
    }

    @Override
    public String getName() {
        return "Cast";
    }

    @Override
    public int getArgumentsCount() {
        return 2;
    }

    @Override
    public void setArgument(int index, Expression e) {
        if (index == 0) {
            this.value = e;
        } else {
            this.targetType = (DataType) ((Cst) e).getValue();
        }
    }

    @Override
    public Expression getArgument(int index) {
        switch (index) {
            case 0:
                return value;
            case 1:
                return new Cst(targetType);
        }
        throw new ArrayIndexOutOfBoundsException();
    }

    @Override
    public Expression copy() {
        return new Cast(value.copy(), targetType);
    }

    @Override
    public String toString() {
        Class javaClass = targetType.getPlatformType();
        int length = targetType.getScale();
        int precision = targetType.getPrecision();
        String tname = TypesFactory.getTypeName(javaClass);
        if (tname == null) {
            tname = ("UNKNOWN_TYPE(" + javaClass.getName() + "," + length + "," + precision + ")");
        }
        if (javaClass.equals(String.class)) {
            if (length > 0) {
                tname = tname + "(" + length + ")";
            }
        }
        return "cast(" + value + "," + tname + ")";
    }
}
