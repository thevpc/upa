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



namespace Net.TheVpc.Upa.Impl
{


    /**
     * User: taha Date: 28 aout 2003 Time: 20:28:38
     */
    public class DefaultRelationshipRole : Net.TheVpc.Upa.Impl.AbstractUPAObject, Net.TheVpc.Upa.RelationshipRole {

        private Net.TheVpc.Upa.Field entityField;

        private Net.TheVpc.Upa.Field[] fields;

        private Net.TheVpc.Upa.Entity entity;

        private Net.TheVpc.Upa.Relationship relation;

        private Net.TheVpc.Upa.RelationshipRoleType relationRoleType;

        private Net.TheVpc.Upa.RelationshipUpdateType relationUpdateType;

        public DefaultRelationshipRole() {
        }


        public override string GetAbsoluteName() {
            return GetName();
        }

        public virtual Net.TheVpc.Upa.Relationship GetRelationship() {
            return relation;
        }

        public virtual void SetRelationship(Net.TheVpc.Upa.Relationship relation) {
            this.relation = relation;
        }

        public virtual Net.TheVpc.Upa.RelationshipRoleType GetRelationshipRoleType() {
            return relationRoleType;
        }

        public virtual void SetRelationshipRoleType(Net.TheVpc.Upa.RelationshipRoleType relationRoteType) {
            this.relationRoleType = relationRoteType;
        }

        public virtual Net.TheVpc.Upa.Entity GetEntity() {
            return entity;
        }

        public virtual void SetEntity(Net.TheVpc.Upa.Entity entity) {
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

        public virtual Net.TheVpc.Upa.Field GetEntityField() {
            return entityField;
        }

        public virtual void SetEntityField(Net.TheVpc.Upa.Field entityField) {
            this.entityField = entityField;
        }

        public virtual Net.TheVpc.Upa.Field GetField(int i) {
            return fields[i];
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Field> GetFields() {
            return new System.Collections.Generic.List<Net.TheVpc.Upa.Field>(new System.Collections.Generic.List<Net.TheVpc.Upa.Field>(fields));
        }

        public virtual void SetFields(Net.TheVpc.Upa.Field[] fields) {
            this.fields = fields;
            entity = fields[0].GetEntity();
        }

        public virtual Net.TheVpc.Upa.RelationshipUpdateType GetRelationshipUpdateType() {
            return relationUpdateType;
        }

        public virtual void SetRelationshipUpdateType(Net.TheVpc.Upa.RelationshipUpdateType relationUpdateType) {
            this.relationUpdateType = relationUpdateType;
        }
    }
}
