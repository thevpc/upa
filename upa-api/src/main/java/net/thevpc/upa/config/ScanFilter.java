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
package net.thevpc.upa.config;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class ScanFilter {

    private int configOrder;
    private String libs;
    private String types;
    /**
     * When true, filter is inherited in children items. Inheritance mean that
     * filter defined in context will be appended (as OR operator) to filters of
     * persistenceGroup and persistenceUnits; and persistenceGroup filter will
     * be appended to persistenceUnitFilter
     */
    private boolean propagate;

    public ScanFilter() {

    }

    public ScanFilter(String libs, String types) {
        this(libs,types,true,0);
    }

    public ScanFilter(String libs, String types, boolean propagate, int configOrder) {
        this.libs = libs == null ? "" : libs.trim();
        this.types = types == null ? "" : types.trim();
        this.propagate = propagate;
        this.configOrder = configOrder;
    }

    public int getConfigOrder() {
        return configOrder;
    }

    public ScanFilter setConfigOrder(int configOrder) {
        this.configOrder = configOrder;
        return this;
    }

    public boolean isPropagate() {
        return propagate;
    }

    public ScanFilter setPropagate(boolean propagate) {
        this.propagate = propagate;
        return this;
    }

    public String getLibs() {
        return libs;
    }

    public String getTypes() {
        return types;
    }

    public ScanFilter setLibs(String libs) {
        this.libs = libs;
        return this;
    }

    public ScanFilter setTypes(String types) {
        this.types = types;
        return this;
    }

    @Override
    public int hashCode() {
        int hash = 5;
        hash = 59 * hash + (this.libs != null ? this.libs.hashCode() : 0);
        hash = 59 * hash + (this.types != null ? this.types.hashCode() : 0);
        hash = 59 * hash + (this.propagate ? 1 : 0);
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
        final ScanFilter other = (ScanFilter) obj;
        if ((this.libs == null) ? (other.libs != null) : !this.libs.equals(other.libs)) {
            return false;
        }
        if ((this.types == null) ? (other.types != null) : !this.types.equals(other.types)) {
            return false;
        }
        if (this.propagate != other.propagate) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "ScanFilter{" + "libs=" + libs + ", types=" + types + ", propagate=" + propagate + '}';
    }

}
