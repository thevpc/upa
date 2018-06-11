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



namespace Net.Vpc.Upa
{


    public class PersistenceUnitInfo : Net.Vpc.Upa.UPAObjectInfo {

        private Net.Vpc.Upa.PackageInfo root;

        private System.Collections.Generic.IList<Net.Vpc.Upa.RelationshipInfo> relationships;

        public PersistenceUnitInfo()  : base("persistenceUnit"){

        }

        public virtual Net.Vpc.Upa.PackageInfo GetRoot() {
            return root;
        }

        public virtual void SetRoot(Net.Vpc.Upa.PackageInfo root) {
            this.root = root;
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.RelationshipInfo> GetRelationships() {
            return relationships;
        }

        public virtual void SetRelationships(System.Collections.Generic.IList<Net.Vpc.Upa.RelationshipInfo> relationships) {
            this.relationships = relationships;
        }
    }
}
