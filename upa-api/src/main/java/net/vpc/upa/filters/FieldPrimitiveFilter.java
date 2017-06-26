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
package net.vpc.upa.filters;

import net.vpc.upa.Field;
import net.vpc.upa.PrimitiveField;

/**
 * Created with IntelliJ IDEA.
 * User: vpc
 * Date: 8/15/12
 * Time: 7:15 PM
 * To change this template use File | Settings | File Templates.
 */
public class FieldPrimitiveFilter extends AbstractFieldFilter {
    private FieldFilter base;

    public FieldPrimitiveFilter(FieldFilter base) {
        this.base = base;
    }

    @Override
    public boolean acceptDynamic() {
        return false;
    }

    @Override
    public boolean accept(Field f) {
        return (f instanceof PrimitiveField) && (base == null || base.accept(f));
    }

    @Override
    public PrimitiveField[] filter(PrimitiveField[] fields) {
        if (fields == null || base == null) {
            return fields;
        }
        return toAbstractFieldFilter(base).filter(fields);
    }

    @Override
    public int hashCode() {
        int hash = 5;
        hash = 89 * hash + (this.base != null ? this.base.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object obj) {
        if (obj == null) {
            return false;
        }
        if (getClass() != obj.getClass()) {
            return false;
        }
        if (!super.equals(obj)) {
            return false;
        }
        final FieldPrimitiveFilter other = (FieldPrimitiveFilter) obj;
        if (this.base != other.base && (this.base == null || !this.base.equals(other.base))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "Primitive(" + (base == null ? "" : base.toString()) + ")";
    }

}
