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

import java.util.ArrayList;
import java.util.List;

/**
 * Created by IntelliJ IDEA. User: vpc Date: 22 janv. 2006 Time: 09:48:59 To
 * change this template use File | Settings | File Templates.
 */
public class IdEnumerationExpression extends DefaultExpression implements Cloneable {

    private static final DefaultTag ALIAS = new DefaultTag("ALIAS");
    private final List<Object> ids;
    private Var alias;

    public IdEnumerationExpression(List<Object> ids, Var alias) {
        this.ids = ids;
        this.alias = alias;
    }

    @Override
    public List<TaggedExpression> getChildren() {
        List<TaggedExpression> all = new ArrayList<TaggedExpression>(1);
        if (alias != null) {
            all.add(new TaggedExpression(alias, ALIAS));
        }
        return all;
    }

    @Override
    public void setChild(Expression e, ExpressionTag tag) {
        if (tag.equals(ALIAS)) {
            this.alias = (Var) e;
        }
    }

    public List<Object> getIds() {
        return ids;
    }

    public Var getAlias() {
        return alias;
    }

    @Override
    public Expression copy() {
        IdEnumerationExpression o = new IdEnumerationExpression(new ArrayList<Object>(ids), alias == null ? null : (Var) alias.copy());
        return o;
    }

    @Override
    public String toString() {
        return "IdEnumerationExpression(" + "ids=" + ids + ", alias=" + alias + ')';
    }

}
