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


    public class CompoundFieldInfo : Net.TheVpc.Upa.FieldInfo {

        private System.Collections.Generic.IList<Net.TheVpc.Upa.PrimitiveFieldInfo> children;

        public CompoundFieldInfo()  : base("compound"){

        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.PrimitiveFieldInfo> GetChildren() {
            return children;
        }

        public virtual void SetChildren(System.Collections.Generic.IList<Net.TheVpc.Upa.PrimitiveFieldInfo> children) {
            this.children = children;
        }
    }
}
