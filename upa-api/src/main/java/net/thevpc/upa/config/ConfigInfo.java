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

import net.thevpc.upa.UPA;

/**
 * @author taha.bensalah@gmail.com
 */
public class ConfigInfo implements Comparable<ConfigInfo> {

    public static ConfigInfo DEFAULT = new ConfigInfo(0, ConfigAction.MERGE, null, null);
    public static ConfigInfo MIN = new ConfigInfo(Integer.MIN_VALUE, ConfigAction.MERGE, null, null);
    public static ConfigInfo MAX = new ConfigInfo(Integer.MAX_VALUE, ConfigAction.MERGE, null, null);
    private final int configOrder;

    private final ConfigAction configAction;

    private final String persistenceGroup;

    private final String persistenceUnit;

    public ConfigInfo(int configOrder, ConfigAction configAction, String persistenceGroup, String persistenceUnit) {
        this.configOrder = configOrder;
        this.configAction = configAction;
        this.persistenceGroup = isNullOrEmpty(persistenceGroup) ? null : persistenceGroup;
        this.persistenceUnit = isNullOrEmpty(persistenceUnit) ? null : persistenceUnit;
    }

    public int getOrder() {
        return configOrder;
    }

    public ConfigAction getConfigAction() {
        return configAction;
    }

    public String getPersistenceGroup() {
        return persistenceGroup;
    }

    public String getPersistenceUnit() {
        return persistenceUnit;
    }

    @Override
    public int hashCode() {
        int hash = 7;
        hash = 67 * hash + this.configOrder;
        hash = 67 * hash + (this.configAction != null ? this.configAction.hashCode() : 0);
        hash = 67 * hash + (this.persistenceGroup != null ? this.persistenceGroup.hashCode() : 0);
        hash = 67 * hash + (this.persistenceUnit != null ? this.persistenceUnit.hashCode() : 0);
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
        final ConfigInfo other = (ConfigInfo) obj;
        if (this.configOrder != other.configOrder) {
            return false;
        }
        if (this.configAction != other.configAction) {
            return false;
        }
        if ((this.persistenceGroup == null) ? (other.persistenceGroup != null) : !this.persistenceGroup.equals(other.persistenceGroup)) {
            return false;
        }
        if ((this.persistenceUnit == null) ? (other.persistenceUnit != null) : !this.persistenceUnit.equals(other.persistenceUnit)) {
            return false;
        }
        return true;
    }

    public int compareTo(ConfigInfo o) {
        if (o == null) {
            return 1;
        }
        int v = Integer.compare(configOrder, o.configOrder);
        if (v != 0) {
            return v;
        }

        v = compareExpr(persistenceGroup, o.persistenceGroup);
        if (v != 0) {
            return v;
        }
        v = compareExpr(persistenceUnit, o.persistenceUnit);
        if (v != 0) {
            return v;
        }
        return 0;
    }

    private int compareExpr(String a, String b) {
        if (a == null) {
            a = "";
        }
        if (b == null) {
            b = "";
        }
        return a.compareTo(b);
    }

    @Override
    public String toString() {
        StringBuilder b = new StringBuilder("Config(");
        b.append(configAction);
        if (configOrder != 0) {
            b.append(":");
            if (configOrder == Integer.MIN_VALUE) {
                b.append("MIN");
            } else if (configOrder == Integer.MAX_VALUE) {
                b.append("MAX");
            } else {
                b.append(configOrder);
            }
        }
        if (!isNullOrEmpty(persistenceGroup) || !isNullOrEmpty(persistenceUnit)) {
            b.append(";");
            b.append(isNullOrEmpty(persistenceGroup) ? "" : persistenceGroup);
            b.append("/");
            b.append(isNullOrEmpty(persistenceUnit) ? "" : persistenceUnit);
        }
        b.append(")");
        return b.toString();
    }

    private static boolean isNullOrEmpty(String s) {
        return s == null || s.trim().length() == 0 || s.equals(UPA.UNDEFINED_STRING);
    }

}
