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

import java.util.LinkedHashMap;
import java.util.Map;

/**
 * @author taha.bensalah@gmail.com
 */
public class ConnectionConfig {

    private String connectionString;
    private Boolean enabled;
    private String userName;
    private String password;
    private StructureStrategy structureStrategy;
    private Map<String, String> properties = new LinkedHashMap<String, String>();

    public String getConnectionString() {
        return connectionString;
    }

    public ConnectionConfig setConnectionString(String connectionString) {
        this.connectionString = connectionString;
        return this;
    }

    public ConnectionConfig setProperty(String property, String value) {
        getProperties().put(property, value);
        return this;
    }

    public String getUserName() {
        return userName;
    }

    public ConnectionConfig setUserName(String userName) {
        this.userName = userName;
        return this;
    }

    public String getPassword() {
        return password;
    }

    public ConnectionConfig setPassword(String password) {
        this.password = password;
        return this;
    }

    public StructureStrategy getStructureStrategy() {
        return structureStrategy;
    }

    public ConnectionConfig setStructureStrategy(StructureStrategy structureStrategy) {
        this.structureStrategy = structureStrategy;
        return this;
    }

    public Map<String, String> getProperties() {
        return properties;
    }

    public ConnectionConfig setProperties(Map<String, String> properties) {
        this.properties = properties;
        return this;
    }

    public Boolean isEnabled() {
        return enabled;
    }

    public ConnectionConfig setEnabled(Boolean enabled) {
        this.enabled = enabled;
        return this;
    }

    @Override
    public String toString() {
        return "ConnectionConfig{" + "connectionString=" + connectionString + ", userName=" + userName + ", password=" + password + ", structureStrategy=" + structureStrategy + ", properties=" + properties + '}';
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        ConnectionConfig that = (ConnectionConfig) o;

        if (connectionString != null ? !connectionString.equals(that.connectionString) : that.connectionString != null)
            return false;
        if (enabled != null ? !enabled.equals(that.enabled) : that.enabled != null) return false;
        if (userName != null ? !userName.equals(that.userName) : that.userName != null) return false;
        if (password != null ? !password.equals(that.password) : that.password != null) return false;
        if (structureStrategy != that.structureStrategy) return false;
        return properties != null ? properties.equals(that.properties) : that.properties == null;
    }

    @Override
    public int hashCode() {
        int result = connectionString != null ? connectionString.hashCode() : 0;
        result = 31 * result + (enabled != null ? enabled.hashCode() : 0);
        result = 31 * result + (userName != null ? userName.hashCode() : 0);
        result = 31 * result + (password != null ? password.hashCode() : 0);
        result = 31 * result + (structureStrategy != null ? structureStrategy.hashCode() : 0);
        result = 31 * result + (properties != null ? properties.hashCode() : 0);
        return result;
    }
}
