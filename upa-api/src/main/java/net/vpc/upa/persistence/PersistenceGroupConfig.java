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
public class PersistenceGroupConfig {

    private int configOrder;
    private String name;
    private Boolean autoScan;
    private List<PersistenceUnitConfig> persistenceUnits = new ArrayList<PersistenceUnitConfig>(2);
    private List<ScanFilter> filters = new ArrayList<ScanFilter>(2);
    private Map<String, Object> properties = new HashMap<String, Object>();

    public PersistenceGroupConfig(int configOrder) {
        this.configOrder = configOrder;
    }

    public int getConfigOrder() {
        return configOrder;
    }

    public void setConfigOrder(int configOrder) {
        this.configOrder = configOrder;
    }

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

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Map<String, Object> getProperties() {
        return properties;
    }

    public void setProperties(Map<String, Object> properties) {
        this.properties = properties;
    }

    public List<PersistenceUnitConfig> getPersistenceUnits() {
        return persistenceUnits;
    }

    public void setPersistenceUnits(List<PersistenceUnitConfig> persistenceUnits) {
        this.persistenceUnits = persistenceUnits;
    }

    public List<ScanFilter> getContextAnnotationStrategyFilters() {
        return filters;
    }

    public void setContextAnnotationStrategyFilters(List<ScanFilter> filters) {
        this.filters = filters == null ? new ArrayList<ScanFilter>() : new ArrayList<ScanFilter>(filters);
    }

    @Override
    public String toString() {
        return "PersistenceGroupConfig{" + "name=" + name + ", persistenceUnits=" + persistenceUnits + ", filters=" + filters + ", properties=" + properties + '}';
    }

}
