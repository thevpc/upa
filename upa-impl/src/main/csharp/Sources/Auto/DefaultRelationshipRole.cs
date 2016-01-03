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



namespace Net.Vpc.Upa.Impl
{


    /**
     * User: taha Date: 28 aout 2003 Time: 20:28:38
     */
    public class DefaultRelationshipRole : Net.Vpc.Upa.Impl.AbstractUPAObject, Net.Vpc.Upa.RelationshipRole {

        private Net.Vpc.Upa.Field entityField;

        private Net.Vpc.Upa.Field[] fields;

        private Net.Vpc.Upa.Entity entity;

        private Net.Vpc.Upa.Relationship relation;

        private Net.Vpc.Upa.RelationshipRoleType relationRoleType;

        private Net.Vpc.Upa.RelationshipUpdateType relationUpdateType;

        public DefaultRelationshipRole() {
        }


        public override string GetAbsoluteName() {
            return GetName();
        }

        public virtual Net.Vpc.Upa.Relationship GetRelationship() {
            return relation;
        }

        public virtual void SetRelationship(Net.Vpc.Upa.Relationship relation) {
            this.relation = relation;
        }

        public virtual Net.Vpc.Upa.RelationshipRoleType GetRelationshipRoleType() {
            return relationRoleType;
        }

        public virtual void SetRelationshipRoleType(Net.Vpc.Upa.RelationshipRoleType relationRoteType) {
            this.relationRoleType = relationRoteType;
        }

        public virtual Net.Vpc.Upa.Entity GetEntity() {
            return entity;
        }

        public virtual void SetEntity(Net.Vpc.Upa.Entity entity) {
            this.entity = entity;
        }

        public virtual int IndexOf(string fieldName) {
            for (int i = 0; i < fields.Length; i++) {
                if (fields[i].GetName().Equals(fieldName)) {
                    return i;
                }
            }
            return -1;
        }

        public virtual Net.Vpc.Upa.Field GetEntityField() {
            return entityField;
        }

        public virtual void SetEntityField(Net.Vpc.Upa.Field entityField) {
            this.entityField = entityField;
        }

        public virtual Net.Vpc.Upa.Field GetField(int i) {
            return fields[i];
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Field> GetFields() {
            return new System.Collections.Generic.List<Net.Vpc.Upa.Field>(new System.Collections.Generic.List<Net.Vpc.Upa.Field>(fields));
        }

        public virtual void SetFields(Net.Vpc.Upa.Field[] fields) {
            this.fields = fields;
            entity = fields[0].GetEntity();
        }

        public virtual Net.Vpc.Upa.RelationshipUpdateType GetRelationshipUpdateType() {
            return relationUpdateType;
        }

        public virtual void SetRelationshipUpdateType(Net.Vpc.Upa.RelationshipUpdateType relationUpdateType) {
            this.relationUpdateType = relationUpdateType;
        }
    }
}
