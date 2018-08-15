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
public class PersistenceUnitConfig {

    private int configOrder;
    private String name;
    private String persistenceGroup;
    private Boolean autoStart;
    private Boolean autoScan;
    private Boolean inheritScanFilters;
    private List<ConnectionConfig> rootConnections = new ArrayList<ConnectionConfig>(2);
    private List<ConnectionConfig> connections = new ArrayList<ConnectionConfig>(2);
    private Map<String, Object> properties = new HashMap<String, Object>(5);
    private final List<ScanFilter> filters = new ArrayList<ScanFilter>(2);

    private List<PersistenceNameFormat> nameFormats = new ArrayList<PersistenceNameFormat>(2);
    private String globalPersistenceNameFormat;
    private String localPersistenceNameFormat;
    private String persistenceNameEscape;

    public PersistenceUnitConfig() {
    }

    public PersistenceUnitConfig(String name) {
        this.name = name;
    }

    public int getConfigOrder() {
        return configOrder;
    }

    public PersistenceUnitConfig setConfigOrder(int configOrder) {
        this.configOrder = configOrder;
        return this;
    }

    public String getName() {
        return name;
    }

    public PersistenceUnitConfig setName(String name) {
        this.name = name;
        return this;
    }

    public String getPersistenceGroup() {
        return persistenceGroup;
    }

    public PersistenceUnitConfig setPersistenceGroup(String persistenceGroup) {
        this.persistenceGroup = persistenceGroup;
        return this;
    }

    public Map<String, Object> getProperties() {
        return properties;
    }

    public PersistenceUnitConfig setProperties(Map<String, Object> properties) {
        this.properties = properties;
        return this;
    }

    public PersistenceUnitConfig setProperty(String property, Object value) {
        getProperties().put(property, value);
        return this;
    }

    public Boolean getAutoStart() {
        return autoStart;
    }

    public PersistenceUnitConfig setAutoStart(Boolean autoStart) {
        this.autoStart = autoStart;
        return this;
    }

    public Boolean getAutoScan() {
        return autoScan;
    }

    public PersistenceUnitConfig setAutoScan(Boolean autoScan) {
        this.autoScan = autoScan;
        return this;
    }

    public Boolean getInheritScanFilters() {
        return inheritScanFilters;
    }

    public PersistenceUnitConfig setInheritScanFilters(Boolean inheritScanFilters) {
        this.inheritScanFilters = inheritScanFilters;
        return this;
    }

    public PersistenceUnitConfig setFilters(List<ScanFilter> filters) {
        this.filters.clear();
        if (filters != null) {
            this.filters.addAll(filters);
        }
        return this;
    }

    public PersistenceUnitConfig addFilter(ScanFilter filter) {
        filters.add(filter);
        return this;
    }

    public PersistenceUnitConfig removeFilter(ScanFilter filter) {
        filters.remove(filter);
        return this;
    }

    public ScanFilter[] getFilters() {
        return filters.toArray(new ScanFilter[filters.size()]);
    }

    public List<ConnectionConfig> getRootConnections() {
        return rootConnections;
    }

    public PersistenceUnitConfig setRootConnections(List<ConnectionConfig> rootConnections) {
        this.rootConnections = rootConnections;
        return this;
    }

    public List<ConnectionConfig> getConnections() {
        return connections;
    }

    public PersistenceUnitConfig setConnections(List<ConnectionConfig> connections) {
        this.connections = connections;
        return this;
    }

    @Override
    public String toString() {
        return "PersistenceUnitConfig{" + "name=" + name + ", persistenceGroup=" + persistenceGroup + ", autoStart=" + autoStart + ", rootConnections=" + rootConnections + ", connections=" + connections + ", properties=" + properties + ", filters=" + filters + '}';
    }

    public PersistenceUnitConfig addConnectionConfig(ConnectionConfig connectionConfig) {
        if (connectionConfig != null) {
            if (connections == null) {
                connections = new ArrayList<ConnectionConfig>();
            }
            connections.add(connectionConfig);
        }
        return this;
    }

    public PersistenceUnitConfig addRootConnectionConfig(ConnectionConfig connectionConfig) {
        if (connectionConfig != null) {
            if (rootConnections == null) {
                rootConnections = new ArrayList<ConnectionConfig>();
            }
            rootConnections.add(connectionConfig);
        }
        return this;
    }

    public List<PersistenceNameFormat> getNameFormats() {
        return nameFormats;
    }

    public void setNameFormats(List<PersistenceNameFormat> nameFormats) {
        this.nameFormats = nameFormats;
    }

    public String getGlobalPersistenceNameFormat() {
        return globalPersistenceNameFormat;
    }

    public void setGlobalPersistenceNameFormat(String globalPersistenceNameFormat) {
        this.globalPersistenceNameFormat = globalPersistenceNameFormat;
    }

    public String getLocalPersistenceNameFormat() {
        return localPersistenceNameFormat;
    }

    public void setLocalPersistenceNameFormat(String localPersistenceNameFormat) {
        this.localPersistenceNameFormat = localPersistenceNameFormat;
    }

    public String getPersistenceNameEscape() {
        return persistenceNameEscape;
    }

    public void setPersistenceNameEscape(String persistenceNameEscape) {
        this.persistenceNameEscape = persistenceNameEscape;
    }
}
