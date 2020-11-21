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

import net.thevpc.upa.Field;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class FieldOrFilter extends AbstractFieldFilter {

    private FieldFilter[] v = new FieldFilter[0];

    public FieldOrFilter(FieldFilter... filters) {
        this(Arrays.asList(filters));
    }

    public FieldOrFilter(List<FieldFilter> filters) {
        ArrayList<FieldFilter> all = new ArrayList<FieldFilter>(filters.size());
        for (FieldFilter a : filters) {
            if (a != null) {
                all.add(a);
            }
        }
        v = all.toArray(new FieldFilter[all.size()]);
    }

    public List<FieldFilter> getChildren() {
        return Arrays.asList(v);
    }

    public static FieldOrFilter or(FieldFilter... filters) {
        ArrayList<FieldFilter> all = new ArrayList<FieldFilter>(filters.length);
        for (FieldFilter filter : filters) {
            if (filter != null) {
                if (filter instanceof FieldOrFilter) {
                    all.addAll(((FieldOrFilter) filter).getChildren());
                } else {
                    all.add(filter);
                }
            }
        }
        return new FieldOrFilter(all);
    }

    public FieldOrFilter or(FieldFilter filter) {
        if (filter != null) {
            if (filter instanceof FieldOrFilter) {
                List<FieldFilter> children = ((FieldOrFilter) filter).getChildren();
                ArrayList<FieldFilter> all = new ArrayList<FieldFilter>(v.length + children.size());
                all.addAll(Arrays.asList(v));
                all.addAll(children);
                return new FieldOrFilter(all);
            } else {
                ArrayList<FieldFilter> all = new ArrayList<FieldFilter>(v.length + 1);
                all.addAll(Arrays.asList(v));
                all.add(filter);
                return new FieldOrFilter(all);
            }
        } else {
            return this;
        }
    }

    public boolean accept(Field field) {
        for (FieldFilter fieldFilter : v) {
            if (!fieldFilter.accept(field)) {
                return false;
            }
        }
        return true;
    }

    @Override
    public boolean acceptDynamic() {
        for (FieldFilter fieldFilter : v) {
            if (fieldFilter.acceptDynamic()) {
                return true;
            }
        }
        return false;
    }

    @Override
    public String toString() {
        if (v.length == 0) {
            return "false";
        } else if (v.length == 1) {
            return v[0].toString();
        } else {
            StringBuilder b = new StringBuilder("(");
            b.append(v[0]);
            for (int i = 1; i < v.length; i++) {
                b.append(" or ");
                b.append(v[i].toString());
            }
            b.append(")");
            return b.toString();
        }
    }

    @Override
    public int hashCode() {
        int hash = 3;
        hash = 43 * hash;
        for (FieldFilter v1 : this.v) {
            hash = 43 * hash + v1.hashCode();
        }
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
        final FieldOrFilter other = (FieldOrFilter) obj;
        if (this.v == other.v) {
            return true;
        }
        if (this.v == null || other.v == null) {
            return false;
        }
        int length = this.v.length;
        if (other.v.length != length) {
            return false;
        }

        for (int i = 0; i < length; i++) {
            Object e1 = this.v[i];
            Object e2 = other.v[i];

            if (e1 == e2) {
                continue;
            }
            if (e1 == null) {
                return false;
            }

            // Figure out whether the two elements are equal
            boolean eq = e1.equals(e2);

            if (!eq) {
                return false;
            }
        }
        return true;
    }
}
