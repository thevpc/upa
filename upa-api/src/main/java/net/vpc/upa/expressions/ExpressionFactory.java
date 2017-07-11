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


import net.vpc.upa.exceptions.UPAIllegalArgumentException;

import java.lang.reflect.Array;
import java.lang.reflect.Constructor;

/**
 * Created with IntelliJ IDEA.
 * User: vpc
 * Date: 8/17/12
 * Time: 2:56 AM
 * To change this template use File | Settings | File Templates.
 */
public class ExpressionFactory {
    public static Expression toExpression(Object e, Class defaultInstance) {
        if (e == null) {
            return new Literal(null, null);
        } else if (e instanceof Expression) {
            return (Expression) e;
        } else if (e.getClass().isArray()) {
            int l = Array.getLength(e);
            Expression[] eitems = new Expression[l];
            for (int i = 0; i < eitems.length; i++) {
                eitems[i] = toExpression(Array.get(e, i), defaultInstance);
            }
            return eitems.length == 1 ? eitems[0] : new Uplet(eitems);
        } else {
            Constructor c = null;
            try {
                c = defaultInstance.getConstructor(new Class[]{e.getClass()});
            } catch (NoSuchMethodException e1) {
                try {
                    c = defaultInstance.getConstructor(new Class[]{Object.class});
                } catch (NoSuchMethodException e2) {
                    throw new UPAIllegalArgumentException("Could not cast " + e + " as Expression", e1);
                }
            }
            try {
                return (Expression) c.newInstance(new Object[]{e});
            } catch (Throwable e1) {
                throw new UPAIllegalArgumentException(e1.toString());
            }
        }
    }

    //    public static String sqlForLitteral(Object value) {
    //        if(value == null){
    //            return "NULL";
    //        }else if (value instanceof ConvertableToPrimitiveType){
    //            value=((ConvertableToPrimitiveType)value).toPrimitiveType();
    //        }
    //        return
    //                (value instanceof Boolean) ? (((Boolean) value).booleanValue() ? "1" : "0")
    //                : (value instanceof Number) ? value.toString()
    //                : (value instanceof String) ? "'" + Utils.replaceString(value.toString(), "'", "''") + "'"
    //                : (value instanceof java.sql.Date) ? "'" + Utils.UNIVERSAL_DATE_FORMAT.format(value) + "'"
    //                : (value instanceof java.sql.Time) ? "'" + Utils.UNIVERSAL_TIME_FORMAT.format(value) + "'"
    //                : (value instanceof java.sql.Timestamp) ? "'" + Utils.UNIVERSAL_DATE_TIME_FORMAT.format(value) + "'"
    //                : (value instanceof java.util.Date) ? "'" + Utils.UNIVERSAL_DATE_TIME_FORMAT.format(value) + "'"
    //                : (value instanceof Blob) ? "'java.sql.Blob!" + Utils.replaceString(DBUtils.BlobToString((Blob) value), "'", "''") + "'"
    //                : (value instanceof byte[]) ? "'byte[]!" + Utils.replaceString(DBUtils.bytesToString((byte[]) value), "'", "''") + "'"
    //                : (value instanceof Key) ?
    //                (
    //                ((Key) value).getValue().length == 1 ?
    //                    ("'" + Utils.replaceString(String.valueOf(((Key) value).getValue()[0]), "'", "''") + "'")
    //                    :value.toString()
    //                )
    //                : (value instanceof Serializable) ? ("'java.io.Serializable!" + Utils.replaceString(DBUtils.bytesToString(Utils.getSerializedFormOf(value)), "'", "''") + "'")
    //                : null;
    //    }
    public static Expression toLiteral(Object value) {
        return ((Expression) (value == null || !(value instanceof Expression) ? new Literal(value, null) : (Expression) value));
    }

    public static Expression toVar(Object value) {
        return ((Expression) (value == null || !(value instanceof Expression) ? new Var((String) (value)) : (Expression) value));
    }
}
