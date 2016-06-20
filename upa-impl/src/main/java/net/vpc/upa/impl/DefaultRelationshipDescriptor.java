///*
// * To change this license header, choose License Headers in Project Properties.
// *
// * and open the template in the editor.
// */
//package net.vpc.upa.impl;
//
//import net.vpc.upa.RelationshipDescriptor;
//import net.vpc.upa.RelationshipType;
//import net.vpc.upa.expressions.Expression;
//
///**
// *
// * @author vpc
// */
//public class DefaultRelationshipDescriptor implements RelationshipDescriptor {
//
//    public int hierarchyConfigOrder;
//
//    private String hierarchyPathSeparator;
//
//    private boolean hierarchy;
//
//    private String hierarchyPathField;
//
//    private String sourceEntity;
//
//    private Class sourceEntityType;
//
//    private String targetEntity;
//
//    private Class targetEntityType;
//
//    private Expression filter;
//
//    private String baseField;
//
//    private String[] mappedTo;
//
//    private String[] sourceFields;
//
//    private String name;
//
//    private RelationshipType relationType;
//
//    public int getHierarchyConfigOrder() {
//        return hierarchyConfigOrder;
//    }
//
//    public void setHierarchyConfigOrder(int hierarchyConfigOrder) {
//        this.hierarchyConfigOrder = hierarchyConfigOrder;
//    }
//
//    public String getHierarchyPathSeparator() {
//        return hierarchyPathSeparator;
//    }
//
//    public void setHierarchyPathSeparator(String hierarchyPathSeparator) {
//        this.hierarchyPathSeparator = hierarchyPathSeparator;
//    }
//
//    public boolean isHierarchy() {
//        return hierarchy;
//    }
//
//    public void setHierarchy(boolean hierarchy) {
//        this.hierarchy = hierarchy;
//    }
//
//    public String getHierarchyPathField() {
//        return hierarchyPathField;
//    }
//
//    public void setHierarchyPathField(String hierarchyPathField) {
//        this.hierarchyPathField = hierarchyPathField;
//    }
//
//    public String getSourceEntity() {
//        return sourceEntity;
//    }
//
//    public void setSourceEntity(String sourceEntity) {
//        this.sourceEntity = sourceEntity;
//    }
//
//    public Class getSourceEntityType() {
//        return sourceEntityType;
//    }
//
//    public void setSourceEntityType(Class sourceEntityType) {
//        this.sourceEntityType = sourceEntityType;
//    }
//
//    public String getTargetEntity() {
//        return targetEntity;
//    }
//
//    public void setTargetEntity(String targetEntity) {
//        this.targetEntity = targetEntity;
//    }
//
//    public Class getTargetEntityType() {
//        return targetEntityType;
//    }
//
//    public void setTargetEntityType(Class targetEntityType) {
//        this.targetEntityType = targetEntityType;
//    }
//
//    public Expression getFilter() {
//        return filter;
//    }
//
//    public void setFilter(Expression filter) {
//        this.filter = filter;
//    }
//
//    public String getBaseField() {
//        return baseField;
//    }
//
//    public void setBaseField(String baseField) {
//        this.baseField = baseField;
//    }
//
//    public String[] getMappedTo() {
//        return mappedTo;
//    }
//
//    public void setMappedTo(String[] mappedTo) {
//        this.mappedTo = mappedTo;
//    }
//
//    public String getName() {
//        return name;
//    }
//
//    public void setName(String name) {
//        this.name = name;
//    }
//
//    public RelationshipType getRelationshipType() {
//        return relationType;
//    }
//
//    public void setRelationshipType(RelationshipType relationType) {
//        this.relationType = relationType;
//    }
//
//    public String[] getSourceFields() {
//        return sourceFields;
//    }
//
//    public void setSourceFields(String[] sourceFields) {
//        this.sourceFields = sourceFields;
//    }
//
//}
