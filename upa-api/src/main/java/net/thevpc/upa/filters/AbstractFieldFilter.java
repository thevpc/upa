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
package net.thevpc.upa.filters;

import net.thevpc.upa.CompoundField;
import net.thevpc.upa.Field;
import net.thevpc.upa.PrimitiveField;

import java.util.ArrayList;
import java.util.List;


public abstract class AbstractFieldFilter implements RichFieldFilter {
    public abstract boolean acceptDynamic() ;

    public abstract boolean accept(Field f) ;

    public static AbstractFieldFilter toAbstractFieldFilter(FieldFilter filter) {
        if (filter == null) {
            return new FieldAnyFilter();
        } else if (filter instanceof AbstractFieldFilter) {
            return (AbstractFieldFilter) filter;
        } else {
            return new FieldFilterAdapter(filter);
        }
    }

    public List<Field> filter(List<Field> fields)  {
        List<Field> v = new ArrayList<Field>(fields.size());
        for (Field field : fields) {
            if (accept(field)) {
                v.add(field);
            }
        }
        return v;
    }

    public Field[] filter(Field[] fields)  {
        List<Field> v = new ArrayList<Field>(fields.length);
        for (Field field : fields) {
            if (accept(field)) {
                v.add(field);
            }
        }
        return v.toArray(new Field[v.size()]);
    }

    public PrimitiveField[] filter(PrimitiveField[] fields)  {
        ArrayList<PrimitiveField> v = new ArrayList<PrimitiveField>(fields.length);
        for (Field field : fields) {
            if (accept(field)) {
                v.add((PrimitiveField) field);
            }
        }
        return v.toArray(new PrimitiveField[v.size()]);
    }

    public CompoundField[] filter(CompoundField[] fields)  {
        ArrayList<CompoundField> v = new ArrayList<CompoundField>(fields.length);
        for (Field field : fields) {
            if (accept(field)) {
                v.add((CompoundField) field);
            }
        }
        return v.toArray(new CompoundField[v.size()]);
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        return true;
    }

    @Override
    public int hashCode() {
        return 731;
    }

    @Override
    public RichFieldFilter and(FieldFilter filter) {
        return FieldAndFilter.and(this, filter);
    }

    @Override
    public RichFieldFilter andNot(FieldFilter filter) {
        return FieldAndFilter.and(this, FieldFilters.as(filter).negate());
    }

    @Override
    public RichFieldFilter or(FieldFilter filter) {
        return FieldOrFilter.or(this, filter);
    }

    @Override
    public RichFieldFilter orNot(FieldFilter filter) {
        return FieldOrFilter.or(this, FieldFilters.as(filter).negate());
    }

    @Override
    public RichFieldFilter negate() {
        return new FieldReverseFilter(this);
    }
}
