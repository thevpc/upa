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



namespace Net.Vpc.Upa.Types
{


    public class EntityType : Net.Vpc.Upa.Types.DataType {

        private string referencedEntityName;

        private Net.Vpc.Upa.Relationship relationship;

        private bool updatable;

        public EntityType(string typeName, System.Type entityType, string entityName, bool updatable, bool nullable)  : base(typeName, entityType, nullable){

            this.updatable = updatable;
            this.referencedEntityName = entityName;
        }

        public virtual string GetReferencedEntityName() {
            return referencedEntityName;
        }

        public virtual void SetReferencedEntityName(string referencedEntityName) {
            this.referencedEntityName = referencedEntityName;
        }

        public virtual Net.Vpc.Upa.Relationship GetRelationship() {
            return relationship;
        }

        public virtual void SetRelationship(Net.Vpc.Upa.Relationship relationship) {
            this.relationship = relationship;
        }

        public virtual bool IsUpdatable() {
            return updatable;
        }


        public override object Clone() {
            return base.MemberwiseClone();
        }


        public override string ToString() {
            string n = GetPlatformType() == null ? null : (GetPlatformType()).FullName;
            if (n == null) {
                n = GetReferencedEntityName();
            } else if (GetReferencedEntityName() != null) {
                n = n + ":" + GetReferencedEntityName();
            }
            return "EntityType{" + n + ", updatable=" + updatable + '}';
        }
    }
}
