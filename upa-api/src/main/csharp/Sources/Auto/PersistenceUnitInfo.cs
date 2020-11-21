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



namespace Net.TheVpc.Upa
{


    public class PersistenceUnitInfo : Net.TheVpc.Upa.UPAObjectInfo {

        private Net.TheVpc.Upa.PackageInfo root;

        private System.Collections.Generic.IList<Net.TheVpc.Upa.RelationshipInfo> relationships;

        public PersistenceUnitInfo()  : base("persistenceUnit"){

        }

        public virtual Net.TheVpc.Upa.PackageInfo GetRoot() {
            return root;
        }

        public virtual void SetRoot(Net.TheVpc.Upa.PackageInfo root) {
            this.root = root;
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.RelationshipInfo> GetRelationships() {
            return relationships;
        }

        public virtual void SetRelationships(System.Collections.Generic.IList<Net.TheVpc.Upa.RelationshipInfo> relationships) {
            this.relationships = relationships;
        }
    }
}
