package net.vpc.upa;

import net.vpc.upa.expressions.Expression;

/**
 * Created by vpc on 7/20/15.
 */
public class DefaultRelationshipDescriptor implements RelationshipDescriptor {
    public int hierarchyConfigOrder;

    public String hierarchyPathSeparator;

    public boolean hierarchy;
    public boolean nullable;

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

    public int getHierarchyConfigOrder() {
        return hierarchyConfigOrder;
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
