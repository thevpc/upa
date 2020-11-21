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
/*
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
package net.thevpc.upa.expressions;

import java.io.Serializable;

public class JoinCriteria implements Serializable, Cloneable {
    private final JoinType joinType;
    private NameOrQuery entity;
    private String alias;
    private Expression condition;

    public JoinType getJoinType() {
        return joinType;
    }

    public String getEntityName() {
        if (entity instanceof EntityName) {
            return ((EntityName) entity).getName();
        }
        return null;
    }

    public NameOrQuery getEntity() {
        return entity;
    }

    public void setEntity(NameOrQuery entity) {
        this.entity = entity;
    }

    public void setCondition(Expression condition) {
        this.condition = condition;
    }

    public String getEntityAlias() {
        return alias;
    }

    public Expression getCondition() {
        return condition;
    }

    public JoinCriteria(JoinType type, NameOrQuery entity, String alias, Expression condition) {
        this.joinType = type;
        this.entity = entity;
        this.alias = alias;
        this.condition = condition;
        if (type.equals(JoinType.CROSS_JOIN)) {
            this.condition = null;
        }
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        String valueString = String.valueOf(entity);
        String aliasString = getEntityAlias();
        String joinKey = "Inner Join";
        switch (getJoinType()) {
            case INNER_JOIN: // '\0'
                joinKey = "Inner Join";
                break;

            case FULL_JOIN: // '\001'
                joinKey = "Full Join";
                break;

            case LEFT_JOIN: // '\002'
                joinKey = "Left Join";
                break;

            case RIGHT_JOIN: // '\003'
                joinKey = "Right Join";
                break;

            case CROSS_JOIN: // '\003'
                joinKey = "Cross Join";
                break;
        }
        sb.append(" ").append(joinKey).append(" ").append(valueString);
        if (aliasString != null && !valueString.equals(aliasString)) {
            sb.append(" ").append(aliasString);
        }
        if (condition != null && condition.isValid()) {
            sb.append(" On ").append(condition);
        }
        return sb.toString();
    }
}
