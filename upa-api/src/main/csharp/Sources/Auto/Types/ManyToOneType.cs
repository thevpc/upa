/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
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


        public override bool Equals(object o) {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            if (!base.Equals(o)) return false;
            Net.Vpc.Upa.Types.ManyToOneType that = (Net.Vpc.Upa.Types.ManyToOneType) o;
            if (updatable != that.updatable) return false;
            if (targetEntityName != null ? !targetEntityName.Equals(that.targetEntityName) : that.targetEntityName != null) return false;
            return relationship != null ? relationship.Equals(that.relationship) : that.relationship == null;
        }


        public override int GetHashCode() {
            int result = base.GetHashCode();
            result = 31 * result + (targetEntityName != null ? targetEntityName.GetHashCode() : 0);
            result = 31 * result + (relationship != null ? relationship.GetHashCode() : 0);
            result = 31 * result + (updatable ? 1 : 0);
            return result;
        }


        public override Net.Vpc.Upa.DataTypeInfo GetInfo() {
            Net.Vpc.Upa.DataTypeInfo d = base.GetInfo();
            d.GetProperties()["updatable"]=System.Convert.ToString(updatable);
            if (targetEntityName != null) {
                d.GetProperties()["targetEntityName"]=System.Convert.ToString(targetEntityName);
            }
            if (relationship != null) {
                d.GetProperties()["relationship"]=System.Convert.ToString(relationship.GetName());
            }
            if (relationship != null) {
            }
            return d;
        }
    }
}
