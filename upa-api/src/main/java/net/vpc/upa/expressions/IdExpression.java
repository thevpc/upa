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
package net.vpc.upa.expressions;

import net.vpc.upa.Entity;
import net.vpc.upa.exceptions.UPAIllegalArgumentException;

import java.util.ArrayList;
import java.util.List;

public class IdExpression extends DefaultExpression implements Cloneable {

    private static final long serialVersionUID = 1L;
    private Object id;
    private String entityName;
    private String alias;
    private Entity entity;

    public IdExpression(Entity entity, Object id, String alias) {
        if (id == null) {
            throw new UPAIllegalArgumentException("Id could not be null");
        }
//        entity.getIdType().cast(key);
        this.id = id;
        this.entityName = entity.getName();
        this.alias = alias;
        this.entity = entity;
    }

    public void setId(Object id) {
        this.id = id;
    }

    public void setEntityName(String entityName) {
        this.entityName = entityName;
    }

    public void setAlias(String alias) {
        this.alias = alias;
    }

    public void setEntity(Entity entity) {
        this.entity = entity;
    }

    @Override
    public List<TaggedExpression> getChildren() {
        List<TaggedExpression> list = new ArrayList<TaggedExpression>(1);
        return list;
    }

    @Override
    public void setChild(Expression e, ExpressionTag tag) {
        throw new UPAIllegalArgumentException("Insupported");
    }

    public Object getId() {
        return id;
    }

    public Entity getEntity() {
        return entity;//PersistenceUnitFilter.getPersistenceUnit().getEntity(entityName);
    }

    public String getAlias() {
        return alias;
    }

    public String getEntityName() {
        return entityName;
    }

    @Override
    public Expression copy() {
        IdExpression o = new IdExpression(entity, id, alias);
        return o;
    }

    @Override
    public String toString() {
        return "Key(" + entityName + "," + alias + "," + id + ")";
    }

    @Override
    public int hashCode() {
        int hash = 7;
        hash = 97 * hash + (this.id != null ? this.id.hashCode() : 0);
        hash = 97 * hash + (this.entityName != null ? this.entityName.hashCode() : 0);
        hash = 97 * hash + (this.alias != null ? this.alias.hashCode() : 0);
        hash = 97 * hash + (this.entity != null ? this.entity.hashCode() : 0);
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
        final IdExpression other = (IdExpression) obj;
        if (this.id != other.id && (this.id == null || !this.id.equals(other.id))) {
            return false;
        }
        if ((this.entityName == null) ? (other.entityName != null) : !this.entityName.equals(other.entityName)) {
            return false;
        }
        if ((this.alias == null) ? (other.alias != null) : !this.alias.equals(other.alias)) {
            return false;
        }
        if (this.entity != other.entity && (this.entity == null || !this.entity.equals(other.entity))) {
            return false;
        }
        return true;
    }

}
