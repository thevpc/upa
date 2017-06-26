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

import java.util.Arrays;
import java.util.Collection;
import java.util.HashSet;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/25/12 11:54 AM
 */
public class FieldNameFilter extends AbstractFieldFilter {
    private HashSet<String> acceptedFields = new HashSet<String>();
    private HashSet<String> nonAcceptedFields;
    private boolean absoluteNames;
    private boolean acceptDynamic;

    public FieldNameFilter(String... acceptedFields) {
        this.acceptedFields = new HashSet<String>(Arrays.asList(acceptedFields));
    }

    public FieldNameFilter(Collection<String> acceptedFields) {
        this.acceptedFields = new HashSet<String>(acceptedFields);
    }

    @Override
    public boolean accept(Field field) {
        String f = getFieldName(field);
        return !
                (
                        (acceptedFields != null && !acceptedFields.contains(f))
                                ||
                                (nonAcceptedFields != null && nonAcceptedFields.contains(f))
                );
    }

    private String getFieldName(Field field) {
        return (absoluteNames) ? field.getAbsoluteName() : field.getName();
    }

    @Override
    public boolean acceptDynamic() {
        return acceptDynamic;
    }

    public boolean isAcceptDynamic() {
        return acceptDynamic;
    }

    public FieldNameFilter setAcceptDynamic(boolean acceptDynamic) {
        this.acceptDynamic = acceptDynamic;
        return this;
    }

    public boolean isAbsoluteNames() {
        return absoluteNames;
    }

    public FieldNameFilter setAbsoluteNames(boolean absoluteNames) {
        this.absoluteNames = absoluteNames;
        return this;
    }

    public FieldNameFilter setAccepted(String... f) {
        if (acceptedFields == null) {
            acceptedFields = new HashSet<String>();
        }
        for (String s : f) {
            if (s != null) {
                acceptedFields.add(s);
            }
        }
        return this;
    }

    public FieldNameFilter setAccepted(Field... f) {
        if (acceptedFields == null) {
            acceptedFields = new HashSet<String>();
        }
        for (Field s : f) {
            if (s != null) {
                acceptedFields.add(getFieldName(s));
            }
        }
        return this;
    }

    public FieldNameFilter setAccepted(Collection<String> f) {
        if (acceptedFields == null) {
            acceptedFields = new HashSet<String>();
        }
        for (String ff : f) {
            acceptedFields.add(ff);
        }
        return this;
    }

    public FieldNameFilter setRejected(String... f) {
        if (acceptedFields == null) {
            nonAcceptedFields = new HashSet<String>();
        }
        for (String s : f) {
            if (s != null) {
                nonAcceptedFields.add(s);
            }
        }
        return this;
    }

    public FieldNameFilter setRejected(Collection<String> f) {
        if (acceptedFields == null) {
            nonAcceptedFields = new HashSet<String>();
        }
        for (String s : f) {
            if (s != null) {
                nonAcceptedFields.add(s);
            }
        }
        return this;
    }

    @Override
    public String toString() {
        return getClass().getSimpleName() + "(" + acceptedFields + ", ! " + nonAcceptedFields + ")";
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        if (!super.equals(o)) return false;

        FieldNameFilter that = (FieldNameFilter) o;

        if (absoluteNames != that.absoluteNames) return false;
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
        result = 31 * result + (absoluteNames ? 1 : 0);
        result = 31 * result + (acceptDynamic ? 1 : 0);
        return result;
    }

}
