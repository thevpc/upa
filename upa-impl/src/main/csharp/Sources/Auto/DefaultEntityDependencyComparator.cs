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



namespace Net.Vpc.Upa.Impl
{


    /**
     * @author taha.bensalah@gmail.com on 7/6/16.
     */
    internal class DefaultEntityDependencyComparator : System.Collections.Generic.IComparer<Net.Vpc.Upa.Entity> {

        public static readonly System.Collections.Generic.IComparer<Net.Vpc.Upa.Entity> INSTANCE = new Net.Vpc.Upa.Impl.DefaultEntityDependencyComparator();


        public virtual int Compare(Net.Vpc.Upa.Entity o1, Net.Vpc.Upa.Entity o2) {
            System.Collections.Generic.ISet<string> s1 = FindEntityDependencies(o1);
            System.Collections.Generic.ISet<string> s2 = FindEntityDependencies(o2);
            if (s1.Contains(o2.GetName()) && s2.Contains(o1.GetName())) {
                return o1.GetName().CompareTo(o2.GetName());
            } else if (s1.Contains(o2.GetName())) {
                return -1;
            } else if (s2.Contains(o1.GetName())) {
                return 1;
            } else {
                return o1.GetName().CompareTo(o2.GetName());
            }
        }

        private System.Collections.Generic.ISet<string> FindEntityDependencies(Net.Vpc.Upa.Entity o1) {
            System.Collections.Generic.ISet<string> all = new System.Collections.Generic.HashSet<string>();
            foreach (Net.Vpc.Upa.Field field in o1.GetFields()) {
                if (!field.GetModifiers().Contains(Net.Vpc.Upa.FieldModifier.TRANSIENT)) {
                    Net.Vpc.Upa.Types.DataType dt = field.GetDataType();
                    if (dt is Net.Vpc.Upa.Types.ManyToOneType) {
                        all.Add(((Net.Vpc.Upa.Types.ManyToOneType) dt).GetRelationship().GetTargetEntity().GetName());
                    }
                }
            }
            return all;
        }
    }
}
