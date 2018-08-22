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

import java.util.Collections;
import java.util.List;
import net.vpc.upa.exceptions.UnsupportedUPAFeatureException;


/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class Param extends DefaultExpression {
    private static final long serialVersionUID = 1L;
    private Object value;
    private String name;
    private boolean unspecified;

    public Param() {
        this(null);
    }

    public Param(String name) {
        this.unspecified = true;
        this.name = name;
    }

    public Param(String name, Object value) {
        this.unspecified = false;
        this.value = value;
        this.name = name;
    }

    public void setUnspecified(boolean unspecified) {
        this.unspecified = unspecified;
    }

    @Override
    public List<TaggedExpression> getChildren() {
        return Collections.EMPTY_LIST;
    }

    @Override
    public void setChild(Expression e, ExpressionTag tag) {
        throw new UnsupportedUPAFeatureException("Not supported yet.");
    }

    public String getName() {
        return name;
    }

    public Object getValue() {
        return value;
    }

    public boolean isUnspecified() {
        return unspecified;
    }

    public void setValue(Object value) {
        this.value = value;
    }

    @Override
    public Expression copy() {
        Param o = unspecified ? new Param(name) : new Param(name, value);
        return o;
    }

    //    public String toSQL(boolean flag, PersistenceUnit database) {
    //        return "?";
    //    }
    @Override
    public String toString() {
        if (isUnspecified()) {
            return ":" + (getName() == null ? "?" : getName());
        }
        return ":" + (getName() == null ? "?" : getName()) + "(=" + getValue() + ")";
    }

}
