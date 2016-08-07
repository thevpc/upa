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
public class IndexedVar extends Var {
    private Expression[] arguments;

    public IndexedVar(String field, Expression... arguments) {
        this(null, field, arguments);
    }

    public IndexedVar(Expression parent, String name, Expression... arguments) {
        super(parent, name);
        this.arguments = arguments;
    }


    @Override
    public Expression copy() {
        IndexedVar o = new IndexedVar(getApplier(), getName(), getArguments());
        return o;
    }


    public int getArgumentsCount() {
        return arguments.length;
    }

    public Expression getArgument(int index) {
        return arguments[index];
    }

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
        if (getApplier() != null) {
            return getApplier().toString() + "." + getName();
        }
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
