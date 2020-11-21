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


    public class SectionInfo : Net.TheVpc.Upa.EntityPartInfo {

        private System.Collections.Generic.IList<Net.TheVpc.Upa.EntityPartInfo> children;

        public SectionInfo()  : base("section"){

        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.EntityPartInfo> GetChildren() {
            return children;
        }

        public virtual void SetChildren(System.Collections.Generic.IList<Net.TheVpc.Upa.EntityPartInfo> children) {
            this.children = children;
        }
    }
}
