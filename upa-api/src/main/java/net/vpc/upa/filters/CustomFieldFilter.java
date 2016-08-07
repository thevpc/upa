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
package net.vpc.upa.filters;

import net.vpc.upa.AccessLevel;
import net.vpc.upa.Field;
import net.vpc.upa.FieldModifier;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.types.ManyToOneType;

import java.util.Collection;
import java.util.List;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class CustomFieldFilter extends AbstractFieldFilter {

    private FieldFilter base;

    CustomFieldFilter(FieldFilter base) {
        this.base = base;
    }

    public static RichFieldFilter as(FieldFilter base) {
        if (base == null) {
            return FieldFilters.all();
        }
        if (base instanceof CustomFieldFilter) {
            return (CustomFieldFilter) base;
        }
        return new CustomFieldFilter(base);
    }

    public RichFieldFilter byPrimitive() {
        return as(new FieldPrimitiveFilter(base));
    }

    public RichFieldFilter and(FieldFilter other) {
        return as(FieldAndFilter.and(base, other));
    }

    public RichFieldFilter andNot(FieldFilter other) {
        return and(new FieldReverseFilter(other));
    }

    public RichFieldFilter or(FieldFilter other) {
        return new CustomFieldFilter(FieldOrFilter.or(base, other));
    }

    public RichFieldFilter orNot(FieldFilter other) {
        return or(new FieldReverseFilter(other));
    }

    public RichFieldFilter negate() {
        return new CustomFieldFilter(new FieldReverseFilter(base));
    }

    @Override
    public boolean acceptDynamic() throws UPAException {
        return base.acceptDynamic();
    }

    @Override
    public boolean accept(Field f) throws UPAException {
        return base.accept(f);
    }

    @Override
    public int hashCode() {
        int hash = 3;
        hash = 97 * hash + (this.base != null ? this.base.hashCode() : 0);
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
        final CustomFieldFilter other = (CustomFieldFilter) obj;
        if (this.base != other.base && (this.base == null || !this.base.equals(other.base))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return String.valueOf(base);
    }

}
