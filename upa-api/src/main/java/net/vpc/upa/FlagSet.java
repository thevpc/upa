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
package net.vpc.upa;


import java.io.Serializable;
import java.util.*;

/**
 * This is a Read Only EnumSet implementation
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PortabilityHint(target = "C#", name = "ignore")
public final class FlagSet<E extends Enum<E>> implements Cloneable, Serializable, Iterable<E> {

    private final Class<E> elementType;
    private final EnumSet<E> enumSet;

    FlagSet(Class<E> elementType, EnumSet<E> enumSet) {
        this.elementType = elementType;
        this.enumSet = enumSet;
    }

    public Set<E> asSet() {
        return Collections.unmodifiableSet(enumSet);
    }

    public boolean isEmpty() {
        return enumSet.isEmpty();
    }

    public int size() {
        return enumSet.size();
    }

    public Iterator<E> iterator() {
        return enumSet.iterator();
    }

    public FlagSet<E> copy() {
        try {
            return (FlagSet<E>) super.clone();
        } catch (CloneNotSupportedException e) {
            throw new AssertionError(e);
        }
    }

    public boolean missing(E e) {
        return !enumSet.contains(e);
    }

    public boolean containsAll(FlagSet<E> c) {
        return enumSet.containsAll(c.enumSet);
    }

    public boolean missingAll(E... all) {
        return missingAll(Arrays.asList(all));
    }

    public boolean missingAll(Collection<E> c) {
        for (E object : c) {
            if (enumSet.contains(object)) {
                return false;
            }
        }
        return true;
    }

    public boolean missingAll(FlagSet<E> c) {
        return missingAll(c.enumSet);
    }

    public boolean contains(E e) {
        return enumSet.contains(e);
    }

    public boolean containsAll(Collection<E> c) {
        return enumSet.containsAll(c);
    }

    public boolean containsAll(E... arr) {
        return enumSet.containsAll(Arrays.asList(arr));
    }

    public FlagSet<E> add(E e) {
        EnumSet<E> c = EnumSet.copyOf(enumSet);
        c.add(e);
        return new FlagSet(elementType, c);
    }

    public FlagSet<E> addAll(Collection<E> collection) {
        EnumSet<E> c = EnumSet.copyOf(enumSet);
        c.addAll(collection);
        return new FlagSet(elementType, c);
    }

    public FlagSet<E> addAll(E... arr) {
        return addAll(Arrays.asList(arr));
    }

    public FlagSet<E> addAll(FlagSet<E> other) {
        return addAll(other.enumSet);
    }

    public FlagSet<E> remove(E e) {
        EnumSet<E> c = EnumSet.copyOf(enumSet);
        c.remove(e);
        return new FlagSet(elementType, c);
    }

    public FlagSet<E> removeAll(Collection<E> collection) {
        EnumSet<E> c = EnumSet.copyOf(enumSet);
        c.removeAll(collection);
        return new FlagSet(elementType, c);
    }

    public FlagSet<E> removeAll(E... arr) {
        return removeAll(Arrays.asList(arr));
    }

    public FlagSet<E> removeAll(FlagSet<E> other) {
        return removeAll(other.enumSet);
    }

    public FlagSet<E> retainAll(Collection<E> collection) {
        EnumSet<E> c = EnumSet.copyOf(enumSet);
        c.retainAll(collection);
        return new FlagSet(elementType, c);
    }

    public FlagSet<E> retainAll(E... arr) {
        return retainAll(Arrays.asList(arr));
    }

    public FlagSet<E> retainsAll(FlagSet<E> other) {
        return retainAll(other.enumSet);
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder("[");
        boolean first = true;
        for (E e : this) {
            if (first) {
                first = false;
            } else {
                sb.append(", ");
            }
            sb.append(e);
        }
        sb.append("]");
        return sb.toString();
    }


}
