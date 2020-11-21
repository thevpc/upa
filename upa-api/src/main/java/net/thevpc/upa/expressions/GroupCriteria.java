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

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

public class GroupCriteria implements Serializable, Cloneable {
    private List<Expression> fields = new ArrayList<Expression>(1);

    public GroupCriteria() {
    }

    public GroupCriteria addGroup(GroupCriteria order) {
        fields.addAll(order.fields);
        return this;
    }

    public GroupCriteria addGroup(Expression field) {
        fields.add(field);
        return this;
    }

    public GroupCriteria removeGroup(Expression field) {
        int i = fields.indexOf(field);
        if (i >= 0) {
            fields.remove(i);
        }
        return this;
    }

    public GroupCriteria removeGroup(int index) {
        fields.remove(index);
        return this;
    }

    public GroupCriteria insertGroup(int index, Expression field) {
        fields.add(index, field);
        return this;
    }

    public int indexOf(Expression field) {
        return fields.indexOf(field);
    }

    public void setGroupAt(int index, Expression expression) {
        fields.set(index, expression);
    }

    public Expression getGroupAt(int index) {
        return (Expression) fields.get(index);
    }

    public int size() {
        return fields.size();
    }

    public GroupCriteria clear() {
        fields.clear();
        return this;
    }

    public GroupCriteria noGroup() {
        fields.clear();
        return this;
    }

    public GroupCriteria copy() {
        GroupCriteria o = new GroupCriteria();
        for (Expression field : fields) {
            o.fields.add(field.copy());
        }
        return o;
    }

//    public String toSQL(PersistenceUnit database){
//        int max=fields.size();
//        if(max==0) return "";
//        StringBuffer sb=new StringBuffer("GROUP BY ");
//        for (int i = 0; i < max; i++) {
//            if (i > 0)
//                sb.append(", ");
//            sb.append(((Expression) fields.get(i)).toSQL(database));
//        }
//        return sb.toString();
//    }
}
