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

public final class Coalesce extends Function
        implements Cloneable {
    private static final long serialVersionUID = 1L;

    private ArrayList<Expression> elements;

    public Coalesce() {
        elements = new ArrayList<Expression>(1);
    }

    public Coalesce(List<Expression> expressions) {
        this();
        for (Expression expression : expressions) {
            add(expression);
        }
    }

    public Coalesce(Expression expression1, Expression expression2) {
        this();
        add(expression1);
        add(expression2);
    }

    public Coalesce(Expression expression1, Expression expression2, Expression expression3) {
        this();
        add(expression1);
        add(expression2);
        add(expression3);
    }

    public Coalesce clear() {
        elements.clear();
        return this;
    }

    public Coalesce add(Object varName) {
        return add(ExpressionFactory.toVar(varName));
    }

    public Coalesce add(Expression expression) {
        elements.add(expression);
        return this;
    }

    public int size() {
        return elements.size();
    }

    public Expression get(int i) {
        return elements.get(i);
    }

    public boolean isValid() {
        int max = size();
        boolean valid = false;
        for (int i = 0; i < max; i++) {
            Expression e = get(i);
            if (e.isValid())
                valid = true;
        }

        return valid;
    }

//    public synchronized String toSQL(boolean integrated, PersistenceUnit database) {
//        StringBuffer sb = new StringBuffer("Coalesce(");
//        int max = size();
//        boolean started = false;
//        for (int i = 0; i < max; i++) {
//            Expression e = get(i);
//            if (e.isValid()) {
//                if (started){
//                    sb.append(", ");
//                }else{
//                    started = true;
//                }
//                sb.append(e.toSQL(true, database));
//            }
//        }
//        sb.append(')');
//        return sb.toString();
//    }

    public Expression copy() {
        Coalesce o = new Coalesce();
        o.elements = new ArrayList<Expression>();
        for (Expression element : elements) {
            o.add(element.copy());
        }

        return o;
    }

    @Override
    public String getName() {
        return "Coalesce";
    }

    @Override
    public int getArgumentsCount() {
        return elements.size();
    }

    @Override
    public Expression getArgument(int index) {
        return elements.get(index);
    }
}
