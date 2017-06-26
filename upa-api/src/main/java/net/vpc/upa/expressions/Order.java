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
/*
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
package net.vpc.upa.expressions;

import java.io.Serializable;
import java.util.ArrayList;

public class Order implements Serializable, Cloneable {

    private ArrayList<OrderItem> fields = new ArrayList<OrderItem>(3);

    public Order() {
    }

    public Order ascendant(Expression field) {
        return addOrder(field, true);
    }

    public Order descendant(Expression field) {
        return addOrder(field, false);
    }

    public Order addOrder(Order order) {
        for (OrderItem field : order.fields) {
            fields.add(new OrderItem(field.getExpression(), field.isAsc()));
        }
        return this;
    }

    public Order addOrder(Expression field, boolean is_asc) {
        fields.add(new OrderItem(field, is_asc));
        return this;
    }

    public int indexOf(Expression field) {
        for (int i = 0; i < fields.size(); i++) {
            if (fields.get(i).getExpression().equals(field)) {
                return i;
            }
        }
        return -1;
    }

    public Order removeOrder(Expression field) {

        int i = indexOf(field);
        if (i >= 0) {
            fields.remove(i);
        }
        return this;
    }

    public Order removeOrder(int index) {
        fields.remove(index);
        return this;
    }

    public Order insertOrder(int index, Expression field, boolean is_asc) {
        fields.add(index, new OrderItem(field, is_asc));
        return this;
    }

    //    public void setOrderAt(int index,Expression expression) {
//        fields.get(index).expression=expression;
//    }
    public Order setOrderAt(int index, boolean asc) {
        OrderItem o = fields.get(index);
        fields.set(index, new OrderItem(o.getExpression(), asc));
        return this;
    }

    public Order setOrderAt(int index, Expression e, boolean asc) {
        OrderItem o = fields.get(index);
        fields.set(index, new OrderItem(e, asc));
        return this;
    }

    public Order setOrderAt(int index, Expression e) {
        OrderItem o = fields.get(index);
        fields.set(index, new OrderItem(e, o.isAsc()));
        return this;
    }

    public Expression getOrderAt(int index) {
        return fields.get(index).getExpression();
    }

    public boolean isAscendentAt(int index) {
        return fields.get(index).isAsc();
    }

    public int size() {
        return fields.size();
    }

    public Order clear() {
        fields.clear();
        return this;
    }

    public Order noOrder() {
        fields.clear();
        return this;
    }

    public Order copy() {
        Order o = new Order();
        for (OrderItem i : fields) {
            o.fields.add(new OrderItem(i.getExpression().copy(), i.isAsc()));
        }
        return o;
    }

//    public String toSQL(PersistenceUnit database){
//        int max=fields.size();
//        if(max==0) return "";
//        StringBuffer sb=new StringBuffer("ORDER BY ");
//        for (int i = 0; i < max; i++) {
//            if (i > 0)
//                sb.append(", ");
//            sb.append(((Expression) fields.get(i)).toSQL(database));
//            if(((Boolean) asc.get(i))==Boolean.TRUE){
//                sb.append(" ASC ");
//            }else{
//                sb.append(" DESC ");
//            }
//        }
//        return sb.toString();
//    }
}
