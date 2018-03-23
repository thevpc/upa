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

import net.vpc.upa.config.ScanFilter;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class UPAContextConfig {

    public static final int XML_ORDER = Integer.MAX_VALUE;
    public static final int BOOT_TYPE_ORDER = 999999999;

    private Boolean autoScan;
    private List<PersistenceGroupConfig> persistenceGroups = new ArrayList<PersistenceGroupConfig>(2);
    private List<ScanFilter> filters = new ArrayList<ScanFilter>(2);
    private Map<String, Object> properties = new HashMap<>();

    public Boolean getAutoScan() {
        return autoScan;
    }

    public void setAutoScan(Boolean autoScan) {
        this.autoScan = autoScan;
    }

    public List<ScanFilter> getFilters() {
        return filters;
    }

    public void setFilters(List<ScanFilter> filters) {
        this.filters = filters;
    }

    public List<PersistenceGroupConfig> getPersistenceGroups() {
        return persistenceGroups;
    }

    public void setPersistenceGroups(List<PersistenceGroupConfig> persistenceGroups) {
        this.persistenceGroups = persistenceGroups;
    }

    @Override
    public String toString() {
        return "UPAContextConfig{" + "persistenceGroups=" + persistenceGroups + ", filters=" + filters + '}';
    }

    public Map<String, Object> getProperties() {
        return properties;
    }

    public void setProperties(Map<String, Object> properties) {
        this.properties = properties;
    }

    static String trim(String s) {
        if (s == null) {
            s = "";
        }
        s = s.trim();
        return s;
    }
}
