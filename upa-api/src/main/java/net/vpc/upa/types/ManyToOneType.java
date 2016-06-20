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
package net.vpc.upa.types;

import net.vpc.upa.Entity;
import net.vpc.upa.Relationship;

public class ManyToOneType extends DefaultDataType implements Cloneable {

    private String referencedEntityName;
    private Relationship relationship;
    private boolean updatable;

//    public ManyToOneType(String name, Class platformType, boolean updatable) {
//        super(name, platformType);
//        this.updatable = updatable;
//    }
    public ManyToOneType(String typeName, Class entityType, String entityName, boolean updatable, boolean nullable) {
        super(typeName, entityType, nullable);
        this.updatable = updatable;
        this.referencedEntityName=entityName;
    }

    public String getReferencedEntityName() {
        return referencedEntityName;
    }

    public void setReferencedEntityName(String referencedEntityName) {
        this.referencedEntityName = referencedEntityName;
    }

    public Relationship getRelationship() {
        return relationship;
    }

    public Entity getReferencedType() {
        return getRelationship().getTargetRole().getEntity();
    }

    public void setRelationship(Relationship relationship) {
        this.relationship = relationship;
    }

    public boolean isUpdatable() {
        return updatable;
    }

    @Override
    public Object clone() {
        return super.clone();
    }

    @Override
    public String toString() {
        String n = getPlatformType() == null ? null : getPlatformType().getName();
        if (n == null) {
            n = getReferencedEntityName();
        } else if (getReferencedEntityName() != null) {
            n = n + ":" + getReferencedEntityName();
        }
        return "ManyToOneType{" + n + ", updatable=" + updatable + '}';
    }

}
