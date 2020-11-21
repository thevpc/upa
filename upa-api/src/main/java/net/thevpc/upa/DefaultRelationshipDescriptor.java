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
package net.thevpc.upa;

import net.thevpc.upa.expressions.Expression;
import net.thevpc.upa.types.PlatformUtils;

/**
 * Created by vpc on 7/20/15.
 */
public class DefaultRelationshipDescriptor implements RelationshipDescriptor {

    public int hierarchyConfigOrder;
    public String hierarchyPathSeparator;
    public boolean hierarchy;
    public boolean nullable;
    public boolean oneToOne;
    public String hierarchyPathField;
    public String sourceEntity;
    public Class sourceEntityType;
    public String targetEntity;
    public Class targetEntityType;
    public Expression filter;
    public String baseField;
    public String[] mappedTo;
    public String[] sourceFields;
    public String name;
    public RelationshipType relationshipType;

    public DefaultRelationshipDescriptor() {
    }

    public DefaultRelationshipDescriptor(RelationshipDescriptor other) {
        copyFrom(other);
    }

    public DefaultRelationshipDescriptor copyFrom(RelationshipDescriptor other) {
        if (other != null) {
            setHierarchyConfigOrder(other.getHierarchyConfigOrder());
            setHierarchyPathSeparator(other.getHierarchyPathSeparator());
            setHierarchy(other.isHierarchy());
            setNullable(other.isNullable());
            setOneToOne(other.isOneToOne());
            setHierarchyPathField(other.getHierarchyPathField());
            setSourceEntity(other.getSourceEntity());
            setTargetEntity(other.getTargetEntity());
            setFilter(other.getFilter());
            setBaseField(other.getBaseField());
            setMappedTo(PlatformUtils.copyOf(other.getMappedTo()));
            setSourceFields(PlatformUtils.copyOf(other.getSourceFields()));
            setName(other.getName());
            setRelationshipType(other.getRelationshipType());
        }
        return this;
    }

    public int getHierarchyConfigOrder() {
        return hierarchyConfigOrder;
    }

    @Override
    public boolean isOneToOne() {
        return oneToOne;
    }

    public void setOneToOne(boolean oneToOne) {
        this.oneToOne = oneToOne;
    }

    public void setManyToOne(boolean manyToOne) {
        setOneToOne(!manyToOne);
    }

    @Override
    public boolean isManyToOne() {
        return !isOneToOne();
    }

    public DefaultRelationshipDescriptor setHierarchyConfigOrder(int hierarchyConfigOrder) {
        this.hierarchyConfigOrder = hierarchyConfigOrder;
        return this;
    }

    public String getHierarchyPathSeparator() {
        return hierarchyPathSeparator;
    }

    public DefaultRelationshipDescriptor setHierarchyPathSeparator(String hierarchyPathSeparator) {
        this.hierarchyPathSeparator = hierarchyPathSeparator;
        return this;
    }

    public boolean isHierarchy() {
        return hierarchy;
    }

    public DefaultRelationshipDescriptor setHierarchy(boolean isHierarchy) {
        this.hierarchy = isHierarchy;
        return this;
    }

    public String getHierarchyPathField() {
        return hierarchyPathField;
    }

    public DefaultRelationshipDescriptor setHierarchyPathField(String hierarchyPathField) {
        this.hierarchyPathField = hierarchyPathField;
        return this;
    }

    public String getSourceEntity() {
        return sourceEntity;
    }

    public DefaultRelationshipDescriptor setSourceEntity(String sourceEntity) {
        this.sourceEntity = sourceEntity;
        return this;
    }

    public Class getSourceEntityType() {
        return sourceEntityType;
    }

    public DefaultRelationshipDescriptor setSourceEntityType(Class sourceEntityType) {
        this.sourceEntityType = sourceEntityType;
        return this;
    }

    public String getTargetEntity() {
        return targetEntity;
    }

    public DefaultRelationshipDescriptor setTargetEntity(String targetEntity) {
        this.targetEntity = targetEntity;
        return this;
    }

    public Class getTargetEntityType() {
        return targetEntityType;
    }

    public DefaultRelationshipDescriptor setTargetEntityType(Class targetEntityType) {
        this.targetEntityType = targetEntityType;
        return this;
    }

    public Expression getFilter() {
        return filter;
    }

    public DefaultRelationshipDescriptor setFilter(Expression filter) {
        this.filter = filter;
        return this;
    }

    public String getBaseField() {
        return baseField;
    }

    public DefaultRelationshipDescriptor setBaseField(String baseField) {
        this.baseField = baseField;
        return this;
    }

    public String[] getMappedTo() {
        return mappedTo;
    }

    public DefaultRelationshipDescriptor setMappedTo(String[] mappedTo) {
        this.mappedTo = mappedTo;
        return this;
    }

    public String[] getSourceFields() {
        return sourceFields;
    }

    public DefaultRelationshipDescriptor setSourceFields(String[] sourceFields) {
        this.sourceFields = sourceFields;
        return this;
    }

    public String getName() {
        return name;
    }

    public DefaultRelationshipDescriptor setName(String name) {
        this.name = name;
        return this;
    }

    public RelationshipType getRelationshipType() {
        return relationshipType;
    }

    public DefaultRelationshipDescriptor setRelationshipType(RelationshipType relationshipType) {
        this.relationshipType = relationshipType;
        return this;
    }

    public boolean isNullable() {
        return nullable;
    }

    public DefaultRelationshipDescriptor setNullable(boolean nullable) {
        this.nullable = nullable;
        return this;
    }
}
