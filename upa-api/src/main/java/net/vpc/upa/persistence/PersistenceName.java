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

import net.vpc.upa.exceptions.UPAException;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class PersistenceName {

    private int configOrder;
    private String object;

    private PersistenceNameType persistenceNameType;

    private String value;

    public PersistenceName(String object, PersistenceNameType type, String name, int configOrder) {
        if (type == null) {
            throw new UPAException("NullType");
        }
        if (name == null || name.trim().length() == 0) {
            throw new UPAException("NullName");
        } else {
            name = name.trim();
        }
        if (object == null || object.trim().length() == 0) {
            object = null;
        }
        this.object = object;
        this.persistenceNameType = type;
        this.value = name;
        this.configOrder = configOrder;
    }

    public int getConfigOrder() {
        return configOrder;
    }

    public String getObject() {
        return object;
    }

    public PersistenceNameType getPersistenceNameType() {
        return persistenceNameType;
    }

    public String getValue() {
        return value;
    }

    @Override
    public int hashCode() {
        int hash = 3;
        hash = 29 * hash + (this.object != null ? this.object.hashCode() : 0);
        hash = 29 * hash + (this.persistenceNameType != null ? this.persistenceNameType.hashCode() : 0);
        hash = 29 * hash + (this.value != null ? this.value.hashCode() : 0);
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
        final PersistenceName other = (PersistenceName) obj;
        if ((this.object == null) ? (other.object != null) : !this.object.equals(other.object)) {
            return false;
        }
        if (this.persistenceNameType != other.persistenceNameType && (this.persistenceNameType == null || !this.persistenceNameType.equals(other.persistenceNameType))) {
            return false;
        }
        if ((this.value == null) ? (other.value != null) : !this.value.equals(other.value)) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "PersistenceName{" + "object=" + object + ", type=" + persistenceNameType + ", value=" + value + '}';
    }

}
