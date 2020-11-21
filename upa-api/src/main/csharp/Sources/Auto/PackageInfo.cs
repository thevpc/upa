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


    public class PackageInfo : Net.TheVpc.Upa.PersistenceUnitPartInfo {

        private System.Collections.Generic.IList<Net.TheVpc.Upa.PersistenceUnitPartInfo> children;

        public PackageInfo()  : base("package"){

        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.PersistenceUnitPartInfo> GetChildren() {
            return children;
        }

        public virtual void SetChildren(System.Collections.Generic.IList<Net.TheVpc.Upa.PersistenceUnitPartInfo> children) {
            this.children = children;
        }
    }
}
