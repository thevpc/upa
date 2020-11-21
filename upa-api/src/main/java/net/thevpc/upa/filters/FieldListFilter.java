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

import net.thevpc.upa.DynamicField;
import net.thevpc.upa.Field;
import net.thevpc.upa.PrimitiveField;

import java.util.*;

public class FieldListFilter extends AbstractFieldFilter {
    private HashSet<Field> acceptedFields;
    private HashSet<Field> nonAcceptedFields;
    private boolean acceptDynamic;


    public FieldListFilter() {
    }

    public FieldListFilter(Field... accepted) {
        setAccepted(accepted);
    }

    public FieldListFilter(List<Field> accepted) {
        setAccepted(accepted);
    }

    public boolean accept(Field f) {
        return !
                (
                        (acceptedFields != null && !acceptedFields.contains(f))
                                ||
                                (nonAcceptedFields != null && nonAcceptedFields.contains(f))
                );
    }

    public FieldListFilter setAccepted(PrimitiveField[] f) {
        Collection<Field> a = new ArrayList<Field>(f.length);
        for (PrimitiveField primitiveField : f) {
            a.add(primitiveField);
        }
        //a.addAll(Arrays.asList(f));
        return setAccepted(a);
    }

    public FieldListFilter setAccepted(Field[] f) {
        return setAccepted(Arrays.asList(f));
    }

    public FieldListFilter setAccepted(Collection<Field> f) {
        if (f != null) {
            for (Field ff : f) {
                setAccepted(ff);
            }
        }
        return this;
    }

    public FieldListFilter setRejected(PrimitiveField[] f) {
        Collection<Field> a = new ArrayList<Field>(f.length);
        for (PrimitiveField primitiveField : f) {
            a.add(primitiveField);
        }
        return setRejected(a);
    }

    public FieldListFilter reject(Field[] f) {
        return setRejected(Arrays.asList(f));
    }

    public FieldListFilter setRejected(Collection<Field> f) {
        if (f != null) {
            for (Field ff : f) {
                setRejected(ff);
            }
        }
        return this;
    }

    @Override
    public String toString() {
        return "FieldFilter(" + acceptedFields + ", ! " + nonAcceptedFields + ")";
    }

    public FieldListFilter setAccepted(Field f) {
        if (f != null) {
            if (f instanceof DynamicField) {
                acceptDynamic = true;
            }
            if (acceptedFields == null) {
                acceptedFields = new HashSet<Field>();
            }
            acceptedFields.add(f);
        }
        return this;
    }

    public FieldListFilter setRejected(Field f) {
        if (f != null) {
            if (f instanceof DynamicField) {
                acceptDynamic = true;
            }
            if (nonAcceptedFields == null) {
                nonAcceptedFields = new HashSet<Field>();
            }
            nonAcceptedFields.add(f);
        }
        return this;
    }

    public boolean isAcceptDynamic() {
        return acceptDynamic;
    }

    public FieldListFilter setAcceptDynamic(boolean acceptDynamic) {
        this.acceptDynamic = acceptDynamic;
        return this;
    }

    @Override
    public boolean acceptDynamic() {
        return acceptDynamic;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        if (!super.equals(o)) return false;

        FieldListFilter that = (FieldListFilter) o;

        if (acceptDynamic != that.acceptDynamic) return false;
        if (acceptedFields != null ? !acceptedFields.equals(that.acceptedFields) : that.acceptedFields != null)
            return false;
        if (nonAcceptedFields != null ? !nonAcceptedFields.equals(that.nonAcceptedFields) : that.nonAcceptedFields != null)
            return false;

        return true;
    }

    @Override
    public int hashCode() {
        int result = super.hashCode();
        result = 31 * result + (acceptedFields != null ? acceptedFields.hashCode() : 0);
        result = 31 * result + (nonAcceptedFields != null ? nonAcceptedFields.hashCode() : 0);
        result = 31 * result + (acceptDynamic ? 1 : 0);
        return result;
    }
}
