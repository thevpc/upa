/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE AS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.Vpc.Upa
{


    /**
     * Created by vpc on 7/20/15.
     */
    public class DefaultRelationshipDescriptor : Net.Vpc.Upa.RelationshipDescriptor {

        public int hierarchyConfigOrder;

        public string hierarchyPathSeparator;

        public bool hierarchy;

        public bool nullable;

        public string hierarchyPathField;

        public string sourceEntity;

        public System.Type sourceEntityType;

        public string targetEntity;

        public System.Type targetEntityType;

        public Net.Vpc.Upa.Expressions.Expression filter;

        public string baseField;

        public string[] mappedTo;

        public string[] sourceFields;

        public string name;

        public Net.Vpc.Upa.RelationshipType relationshipType;

        public virtual int GetHierarchyConfigOrder() {
            return hierarchyConfigOrder;
        }

        public virtual Net.Vpc.Upa.DefaultRelationshipDescriptor SetHierarchyConfigOrder(int hierarchyConfigOrder) {
            this.hierarchyConfigOrder = hierarchyConfigOrder;
            return this;
        }

        public virtual string GetHierarchyPathSeparator() {
            return hierarchyPathSeparator;
        }

        public virtual Net.Vpc.Upa.DefaultRelationshipDescriptor SetHierarchyPathSeparator(string hierarchyPathSeparator) {
            this.hierarchyPathSeparator = hierarchyPathSeparator;
            return this;
        }

        public virtual bool IsHierarchy() {
            return hierarchy;
        }

        public virtual Net.Vpc.Upa.DefaultRelationshipDescriptor SetHierarchy(bool isHierarchy) {
            this.hierarchy = isHierarchy;
            return this;
        }

        public virtual string GetHierarchyPathField() {
            return hierarchyPathField;
        }

        public virtual Net.Vpc.Upa.DefaultRelationshipDescriptor SetHierarchyPathField(string hierarchyPathField) {
            this.hierarchyPathField = hierarchyPathField;
            return this;
        }

        public virtual string GetSourceEntity() {
            return sourceEntity;
        }

        public virtual Net.Vpc.Upa.DefaultRelationshipDescriptor SetSourceEntity(string sourceEntity) {
            this.sourceEntity = sourceEntity;
            return this;
        }

        public virtual System.Type GetSourceEntityType() {
            return sourceEntityType;
        }

        public virtual Net.Vpc.Upa.DefaultRelationshipDescriptor SetSourceEntityType(System.Type sourceEntityType) {
            this.sourceEntityType = sourceEntityType;
            return this;
        }

        public virtual string GetTargetEntity() {
            return targetEntity;
        }

        public virtual Net.Vpc.Upa.DefaultRelationshipDescriptor SetTargetEntity(string targetEntity) {
            this.targetEntity = targetEntity;
            return this;
        }

        public virtual System.Type GetTargetEntityType() {
            return targetEntityType;
        }

        public virtual Net.Vpc.Upa.DefaultRelationshipDescriptor SetTargetEntityType(System.Type targetEntityType) {
            this.targetEntityType = targetEntityType;
            return this;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetFilter() {
            return filter;
        }

        public virtual Net.Vpc.Upa.DefaultRelationshipDescriptor SetFilter(Net.Vpc.Upa.Expressions.Expression filter) {
            this.filter = filter;
            return this;
        }

        public virtual string GetBaseField() {
            return baseField;
        }

        public virtual Net.Vpc.Upa.DefaultRelationshipDescriptor SetBaseField(string baseField) {
            this.baseField = baseField;
            return this;
        }

        public virtual string[] GetMappedTo() {
            return mappedTo;
        }

        public virtual Net.Vpc.Upa.DefaultRelationshipDescriptor SetMappedTo(string[] mappedTo) {
            this.mappedTo = mappedTo;
            return this;
        }

        public virtual string[] GetSourceFields() {
            return sourceFields;
        }

        public virtual Net.Vpc.Upa.DefaultRelationshipDescriptor SetSourceFields(string[] sourceFields) {
            this.sourceFields = sourceFields;
            return this;
        }

        public virtual string GetName() {
            return name;
        }

        public virtual Net.Vpc.Upa.DefaultRelationshipDescriptor SetName(string name) {
            this.name = name;
            return this;
        }

        public virtual Net.Vpc.Upa.RelationshipType GetRelationshipType() {
            return relationshipType;
        }

        public virtual Net.Vpc.Upa.DefaultRelationshipDescriptor SetRelationshipType(Net.Vpc.Upa.RelationshipType relationshipType) {
            this.relationshipType = relationshipType;
            return this;
        }

        public virtual bool IsNullable() {
            return nullable;
        }

        public virtual Net.Vpc.Upa.DefaultRelationshipDescriptor SetNullable(bool nullable) {
            this.nullable = nullable;
            return this;
        }
    }
}
