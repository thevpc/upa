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


    public class ManyToOneType : Net.Vpc.Upa.Types.DefaultDataType {

        private string targetEntityName;

        private Net.Vpc.Upa.Relationship relationship;

        private bool updatable;

        public ManyToOneType(System.Type entityType, string entityName, bool nullable)  : this(null, entityType, entityName, true, nullable){

        }

        public ManyToOneType(System.Type entityType, bool nullable)  : this(null, entityType, (entityType).Name, true, nullable){

        }

        public ManyToOneType(string typeName, System.Type entityType, string entityName, bool updatable, bool nullable)  : base(typeName, entityType, nullable){

            this.updatable = updatable;
            this.targetEntityName = entityName;
        }

        public virtual string GetTargetEntityName() {
            return targetEntityName;
        }

        public virtual void SetTargetEntityName(string targetEntityName) {
            this.targetEntityName = targetEntityName;
        }

        public virtual Net.Vpc.Upa.Relationship GetRelationship() {
            return relationship;
        }

        public virtual void SetRelationship(Net.Vpc.Upa.Relationship relationship) {
            this.relationship = relationship;
        }

        public virtual Net.Vpc.Upa.Entity GetTargetEntity() {
            return GetRelationship().GetTargetRole().GetEntity();
        }

        public virtual bool IsUpdatable() {
            return updatable;
        }


        public override string ToString() {
            string n = GetPlatformType() == null ? null : (GetPlatformType()).FullName;
            if (n == null) {
                n = GetTargetEntityName();
            } else if (GetTargetEntityName() != null) {
                n = n + ":" + GetTargetEntityName();
            }
            return "ManyToOneType{" + n + ", updatable=" + updatable + '}';
        }
    }
}
