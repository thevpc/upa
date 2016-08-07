/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.config;

/**
 *
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
        return s == null || s.trim().length() == 0 || s.equals(net.vpc.upa.UPA.UNDEFINED_STRING);
    }

}
