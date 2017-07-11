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
package net.vpc.upa.persistence;

import net.vpc.upa.exceptions.UPAIllegalArgumentException;

import java.util.LinkedHashMap;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public final class PersistenceNameType {

    private static final LinkedHashMap<String, PersistenceNameType> values = new LinkedHashMap<String, PersistenceNameType>();

    private final String name;
    private final boolean global;

    public static final PersistenceNameType TABLE = create("TABLE", true);
    //    public static final PersistenceNameType TREE_TABLE = create("TREE_TABLE", true);
    public static final PersistenceNameType UNION_TABLE = create("UNION_TABLE", true);
    public static final PersistenceNameType VIEW = create("VIEW", true);
    public static final PersistenceNameType IMPLICIT_VIEW = create("IMPLICIT_VIEW", true);
    public static final PersistenceNameType COLUMN = create("COLUMN", false);
    public static final PersistenceNameType FK_CONSTRAINT = create("FK_CONSTRAINT", true);
    public static final PersistenceNameType PK_CONSTRAINT = create("PK_CONSTRAINT", true);
    public static final PersistenceNameType INDEX = create("INDEX", true);
    public static final PersistenceNameType ALIAS = create("ALIAS", false);

    private PersistenceNameType(String name, boolean global) {
        this.name = name;
        this.global = global;
    }

    public static PersistenceNameType valueOf(String name) {
        PersistenceNameType f = values.get(name);
        if (f == null) {
            throw new UPAIllegalArgumentException("PersistenceNameType not found " + name);
        }
        return f;
    }

    public static PersistenceNameType create(String name, boolean globalScope) {
        if (name == null || name.length() == 0 || name.trim().length() != name.length()) {
            throw new UPAIllegalArgumentException("Invalid PersistenceNameType Name " + name);
        }
        if (values.containsKey(name)) {
            throw new UPAIllegalArgumentException("PersistenceNameType already exists " + name);
        }
        PersistenceNameType t = new PersistenceNameType(name, globalScope);
        values.put(t.name(), t);
        return t;
    }

    public String name() {
        return this.name;
    }

    public boolean isGlobal() {
        return global;
    }

    @Override
    public int hashCode() {
        int hash = 3;
        hash = 11 * hash + (this.name != null ? this.name.hashCode() : 0);
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
        final PersistenceNameType other = (PersistenceNameType) obj;
        if ((this.name == null) ? (other.name != null) : !this.name.equals(other.name)) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "PersistenceNameType{" + "name=" + name + ", global=" + global + '}';
    }

}
