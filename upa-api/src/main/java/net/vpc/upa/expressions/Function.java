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

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/16/12 Time: 10:54 PM To change
 * this template use File | Settings | File Templates.
 */
public abstract class Function extends DefaultExpression {
//    public synchronized String toSQL(boolean integrated, PersistenceUnit database) {
//        StringBuffer sb = new StringBuffer(getName()).append("(");
//        int max = getArgumentsCount();
//        boolean started = false;
//        for (int i = 0; i < max; i++) {
//            Expression e = (Expression) getArgument(i);
//            if (e.isValid()) {
//                if (started) {
//                    sb.append(" , ");
//                } else {
//                    started = true;
//                }
//                sb.append(e.toSQL(true, database));
//            }
//        }
//
//        sb.append(')');
//        return sb.toString();
//    }

    public abstract String getName();

    public abstract int getArgumentsCount();

    public abstract Expression getArgument(int index);

    public Expression[] getArguments() {
        int max = getArgumentsCount();
        Expression[] p = new Expression[max];
        for (int i = 0; i < max; i++) {
            p[i] = getArgument(i);
        }
        return p;
    }

    @Override
    public String toString() {
        StringBuilder s = new StringBuilder(getName()).append("(");
        for (int i = 0; i < getArgumentsCount(); i++) {
            if (i > 0) {
                s.append(",");
            }
            s.append(getArgument(i));
        }
        s.append(")");
        return s.toString();
    }
}
