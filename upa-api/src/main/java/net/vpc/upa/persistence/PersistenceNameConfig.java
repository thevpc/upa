/**
 * ==================================================================== 
 * UPA (Unstructured Persistence API)
 *    Yet another ORM Framework
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
 *
 * Copyright (C) 2014-2015 Taha BEN SALAH
 *
 * This program is free software; you can redistribute it and/or modify it under
 * the terms of the GNU General Public License as published by the Free Software
 * Foundation; either version 2 of the License, or (at your option) any later
 * version.
 *
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE. See the GNU General Public License for more
 * details.
 *
 * You should have received a copy of the GNU General Public License along with
 * this program; if not, write to the Free Software Foundation, Inc., 51
 * Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 * ====================================================================
 */
package net.vpc.upa.persistence;

import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author vpc
 */
public class PersistenceNameConfig {

    private int configOrder;
    private List<PersistenceName> names = new ArrayList<PersistenceName>();
    private String globalPersistenceName;
    private String localPersistenceName;

    private String persistenceNameEscape;

    public PersistenceNameConfig(int configOrder) {
        this.configOrder=configOrder;
    }

    public int getConfigOrder() {
        return configOrder;
    }

    public void setConfigOrder(int configOrder) {
        this.configOrder = configOrder;
    }

    public String getGlobalPersistenceName() {
        return globalPersistenceName;
    }

    public void setGlobalPersistenceName(String globalPersistenceName) {
        this.globalPersistenceName = globalPersistenceName;
    }

    public String getPersistenceNameEscape() {
        return persistenceNameEscape;
    }

    public void setPersistenceNameEscape(String persistenceNameEscape) {
        this.persistenceNameEscape = persistenceNameEscape;
    }

    public List<PersistenceName> getNames() {
        return names;
    }

    public String getLocalPersistenceName() {
        return localPersistenceName;
    }

    public void setLocalPersistenceName(String localPersistenceName) {
        this.localPersistenceName = localPersistenceName;
    }

    @Override
    public int hashCode() {
        int hash = 5;
        hash = 59 * hash + (this.names != null ? this.names.hashCode() : 0);
        hash = 59 * hash + (this.globalPersistenceName != null ? this.globalPersistenceName.hashCode() : 0);
        hash = 59 * hash + (this.localPersistenceName != null ? this.localPersistenceName.hashCode() : 0);
        hash = 59 * hash + (this.persistenceNameEscape != null ? this.persistenceNameEscape.hashCode() : 0);
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
        final PersistenceNameConfig other = (PersistenceNameConfig) obj;
        if (this.names != other.names && (this.names == null || !this.names.equals(other.names))) {
            return false;
        }
        if ((this.globalPersistenceName == null) ? (other.globalPersistenceName != null) : !this.globalPersistenceName.equals(other.globalPersistenceName)) {
            return false;
        }
        if ((this.localPersistenceName == null) ? (other.localPersistenceName != null) : !this.localPersistenceName.equals(other.localPersistenceName)) {
            return false;
        }
        if ((this.persistenceNameEscape == null) ? (other.persistenceNameEscape != null) : !this.persistenceNameEscape.equals(other.persistenceNameEscape)) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "PersistenceNameStrategyModel{" + "names=" + names + ", globalPersistenceName=" + globalPersistenceName + ", localPersistenceName=" + localPersistenceName + ", persistenceNameEscape=" + persistenceNameEscape + '}';
    }

}
