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
package net.thevpc.upa.persistence;

import net.thevpc.upa.config.ScanFilter;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * @author taha.bensalah@gmail.com
 */
public class PersistenceGroupConfig {

    private int configOrder;
    private String name;
    private Boolean autoScan;
    private Boolean inheritScanFilters;
    private List<PersistenceUnitConfig> persistenceUnits = new ArrayList<PersistenceUnitConfig>(2);
    private List<ScanFilter> filters = new ArrayList<ScanFilter>(2);
    private Map<String, Object> properties = new HashMap<String, Object>();

    public PersistenceGroupConfig() {
    }

    public PersistenceGroupConfig(String name) {
        this.name = name;
    }

    public int getConfigOrder() {
        return configOrder;
    }

    public PersistenceGroupConfig setConfigOrder(int configOrder) {
        this.configOrder = configOrder;
        return this;
    }

    public Boolean getInheritScanFilters() {
        return inheritScanFilters;
    }

    public PersistenceGroupConfig setInheritScanFilters(Boolean inheritScanFilters) {
        this.inheritScanFilters = inheritScanFilters;
        return this;
    }
    

    public Boolean getAutoScan() {
        return autoScan;
    }

    public PersistenceGroupConfig setAutoScan(Boolean autoScan) {
        this.autoScan = autoScan;
        return this;
    }

    public List<ScanFilter> getFilters() {
        return filters;
    }

    public PersistenceGroupConfig setFilters(List<ScanFilter> filters) {
        this.filters = filters;
        return this;
    }

    public String getName() {
        return name;
    }

    public PersistenceGroupConfig setName(String name) {
        this.name = name;
        return this;
    }

    public PersistenceGroupConfig addFilter(ScanFilter filter) {
        if(filter!=null){
            this.filters.add(filter);
        }
        return this;
    }


    public Map<String, Object> getProperties() {
        return properties;
    }

    public PersistenceGroupConfig setProperties(Map<String, Object> properties) {
        this.properties = properties;
        return this;
    }

    public List<PersistenceUnitConfig> getPersistenceUnits() {
        return persistenceUnits;
    }

    public PersistenceGroupConfig setPersistenceUnits(List<PersistenceUnitConfig> persistenceUnits) {
        this.persistenceUnits = persistenceUnits;
        return this;
    }

    public List<ScanFilter> getScanFilters() {
        return filters;
    }

    public PersistenceGroupConfig setScanFilters(List<ScanFilter> filters) {
        this.filters = filters == null ? new ArrayList<ScanFilter>() : new ArrayList<ScanFilter>(filters);
        return this;
    }

    public PersistenceGroupConfig addPersistenceUnit(PersistenceUnitConfig persistenceUnitConfig) {
        if (persistenceUnitConfig != null) {
            getPersistenceUnits().add(persistenceUnitConfig);
        }
        return this;
    }

    public PersistenceGroupConfig setProperty(String property, Object value) {
        getProperties().put(property, value);
        return this;
    }

    public PersistenceUnitConfig getPersistenceUnit(String name, boolean create, int configOrder) {
        for (PersistenceUnitConfig persistenceGroup : persistenceUnits) {
            if (UPAContextConfig.trim(persistenceGroup.getName()).equals(UPAContextConfig.trim(name))) {
                return persistenceGroup;
            }
        }
        if (create) {
            PersistenceUnitConfig p = new PersistenceUnitConfig();
            p.setConfigOrder(configOrder);
            persistenceUnits.add(p);
            return p;
        }
        return null;
    }

    @Override
    public String toString() {
        return "PersistenceGroupConfig{" + "name=" + name + ", persistenceUnits=" + persistenceUnits + ", filters=" + filters + ", properties=" + properties + '}';
    }

}
