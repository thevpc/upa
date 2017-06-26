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
    private PersistenceNameConfig model;
    private Boolean autoStart;
    private Boolean autoScan;
    private List<ConnectionConfig> rootConnections = new ArrayList<ConnectionConfig>(2);
    private List<ConnectionConfig> connections = new ArrayList<ConnectionConfig>(2);
    private Map<String, Object> properties = new HashMap<String, Object>(5);
    private final List<ScanFilter> filters = new ArrayList<ScanFilter>(2);

    public PersistenceUnitConfig() {
    }

    public int getConfigOrder() {
        return configOrder;
    }

    public void setConfigOrder(int configOrder) {
        this.configOrder = configOrder;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getPersistenceGroup() {
        return persistenceGroup;
    }

    public void setPersistenceGroup(String persistenceGroup) {
        this.persistenceGroup = persistenceGroup;
    }

    public PersistenceNameConfig getModel() {
        return model;
    }

    public void setModel(PersistenceNameConfig model) {
        this.model = model;
    }

    public Map<String, Object> getProperties() {
        return properties;
    }

    public void setProperties(Map<String, Object> properties) {
        this.properties = properties;
    }

    public Boolean getAutoStart() {
        return autoStart;
    }

    public void setAutoStart(Boolean autoStart) {
        this.autoStart = autoStart;
    }

    public Boolean getAutoScan() {
        return autoScan;
    }

    public void setAutoScan(Boolean autoScan) {
        this.autoScan = autoScan;
    }

    public void setContextAnnotationStrategyFilters(List<ScanFilter> filters) {
        this.filters.clear();
        if (filters != null) {
            this.filters.addAll(filters);
        }
    }

    public void addContextAnnotationStrategyFilter(ScanFilter filter) {
        filters.add(filter);
    }

    public void removeContextAnnotationStrategyFilter(ScanFilter filter) {
        filters.remove(filter);
    }

    public ScanFilter[] getFilters() {
        return filters.toArray(new ScanFilter[filters.size()]);
    }

    public List<ConnectionConfig> getRootConnections() {
        return rootConnections;
    }

    public void setRootConnections(List<ConnectionConfig> rootConnections) {
        this.rootConnections = rootConnections;
    }

    public List<ConnectionConfig> getConnections() {
        return connections;
    }

    public void setConnections(List<ConnectionConfig> connections) {
        this.connections = connections;
    }

    @Override
    public String toString() {
        return "PersistenceUnitConfig{" + "name=" + name + ", persistenceGroup=" + persistenceGroup + ", model=" + model + ", autoStart=" + autoStart + ", rootConnections=" + rootConnections + ", connections=" + connections + ", properties=" + properties + ", filters=" + filters + '}';
    }

}
