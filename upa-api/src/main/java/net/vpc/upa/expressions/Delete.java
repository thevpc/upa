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

import java.util.ArrayList;
import java.util.List;

public class Delete extends DefaultEntityStatement
        implements Cloneable, NonQueryStatement {

    private static final DefaultTag ENTITY = new DefaultTag("ENTITY");
    private static final DefaultTag COND = new DefaultTag("COND");
    private static final long serialVersionUID = 1L;
    protected Expression condition;
    protected EntityName entity;
    protected String entityAlias;

    public Delete(Delete other) {
        this();
        addQuery(other);
    }

    public Delete() {
        entity = null;
        entityAlias = null;
    }

    public Delete from(String entity, String alias) {
        this.entity = new EntityName(entity);
        entityAlias = alias;
        return this;
    }

    @Override
    public List<TaggedExpression> getChildren() {
        List<TaggedExpression> all = new ArrayList<TaggedExpression>(2);
        if (entity != null) {
            all.add(new TaggedExpression(entity, ENTITY));
        }
        if (condition != null) {
            all.add(new TaggedExpression(condition, COND));
        }
        return all;
    }

    @Override
    public void setChild(Expression e, ExpressionTag tag) {
        if (ENTITY.equals(tag)) {
            this.entity = (EntityName) e;
        } else if (COND.equals(tag)) {
            this.condition = e;
        }
    }

    public Delete from(String entity) {
        return from(entity, null);
    }

    public EntityName getEntity() {
        return entity;
    }

    public String getEntityName() {
        EntityName e = getEntity();
        return (e != null) ? ((EntityName) e).getName() : null;
    }

    public String getEntityAlias() {
        return entityAlias;//== null ? entity.getName() : entityAlias;
    }

    public Delete where(Expression condition) {
        this.condition = condition;
        return this;
    }

    public Expression getCondition() {
        return condition;
    }

    public Expression copy() {
        Delete o = new Delete();
        o.addQuery(this);
        return o;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder("Delete From " + entity);
        if (entityAlias != null) {
            sb.append(" ").append(ExpressionHelper.escapeIdentifier(entityAlias));
        }
        if (condition != null && condition.isValid()) {
            sb.append(" Where ").append(getCondition().toString());
        }
        return sb.toString();
    }

    public int size() {
        return 3;
    }

    public Delete addQuery(Delete other) {
        if (other == null) {
            return this;
        }
        if (other.entity != null) {
            entity = (EntityName) other.entity.copy();
        }
        if (other.entityAlias != null) {
            entityAlias = other.entityAlias;
        }
        other.condition = condition.copy();
        return this;
    }
}
