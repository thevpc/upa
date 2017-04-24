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

public class Var extends DefaultExpression {

    private static final DefaultTag PARENT = new DefaultTag("PARENT");
    private static final long serialVersionUID = 1L;
    public static final char DOT = '.';
    private Expression applier;
    private String name;

    public Var(String field) {
        this(null, field);
    }

    public Var(Expression applier, String name) {
        this.applier = applier;
        this.name = name;
        if (name.contains(".")) {
            throw new net.vpc.upa.exceptions.IllegalArgumentException("Name could not contain dots");
        }
    }

    public void setApplier(Var applier) {
        this.applier = applier;
    }

    public void setName(String name) {
        this.name = name;
    }

    @Override
    public List<TaggedExpression> getChildren() {
        List<TaggedExpression> list = new ArrayList<TaggedExpression>(1);
        if (applier != null) {
            list.add(new TaggedExpression(applier, PARENT));
        }
        return list;
    }

    @Override
    public void setChild(Expression e, ExpressionTag tag) {
        if (tag.equals(PARENT)) {
            this.applier = e;
        } else {
            throw new net.vpc.upa.exceptions.IllegalArgumentException("Not supported yet.");
        }
    }

    public Expression getApplier() {
        return applier;
    }

    public String getName() {
        return name;
    }

    @Override
    public Expression copy() {
        Var o = new Var(applier==null?null: applier.copy(), name);
        return o;
    }

    @Override
    public String toString() {
        if (applier != null) {
            return applier.toString() + "." + ExpressionHelper.escapeIdentifier(getName());
        }
        return ExpressionHelper.escapeIdentifier(getName());
    }

}
