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


    public class CompoundFieldInfo : Net.Vpc.Upa.FieldInfo {

        private System.Collections.Generic.IList<Net.Vpc.Upa.PrimitiveFieldInfo> children;

        public CompoundFieldInfo()  : base("compound"){

        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.PrimitiveFieldInfo> GetChildren() {
            return children;
        }

        public virtual void SetChildren(System.Collections.Generic.IList<Net.Vpc.Upa.PrimitiveFieldInfo> children) {
            this.children = children;
        }
    }
}
