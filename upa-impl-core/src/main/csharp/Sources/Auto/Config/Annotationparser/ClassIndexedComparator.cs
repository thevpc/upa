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



namespace Net.TheVpc.Upa.Impl.Config.Annotationparser
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    internal class ClassIndexedComparator : Net.TheVpc.Upa.Impl.Util.IndexedComparator<System.Type> {

        private Net.TheVpc.Upa.Impl.Config.Decorations.DecorationRepository repo;

        public ClassIndexedComparator(Net.TheVpc.Upa.Impl.Config.Decorations.DecorationRepository repo) {
            this.repo = repo;
        }


        public virtual int Compare(System.Type o1, System.Type o2, int i1, int i2) {
            Net.TheVpc.Upa.Config.Decoration e1 = (Net.TheVpc.Upa.Config.Decoration) repo.GetTypeDecoration(o1, typeof(Net.TheVpc.Upa.Config.Entity));
            Net.TheVpc.Upa.Config.Decoration e2 = (Net.TheVpc.Upa.Config.Decoration) repo.GetTypeDecoration(o1, typeof(Net.TheVpc.Upa.Config.Entity));
            int x = e1.GetDecoration("config").GetInt("order") - e2.GetDecoration("config").GetInt("order");
            if (x != 0) {
                return x;
            }
            Net.TheVpc.Upa.Config.Decoration p1 = (Net.TheVpc.Upa.Config.Decoration) repo.GetTypeDecoration(o1, typeof(Net.TheVpc.Upa.Config.Partial));
            Net.TheVpc.Upa.Config.Decoration p2 = (Net.TheVpc.Upa.Config.Decoration) repo.GetTypeDecoration(o1, typeof(Net.TheVpc.Upa.Config.Partial));
            if (p1 != null && p2 == null) {
                return 1;
            }
            if (p2 != null && p1 == null) {
                return -1;
            }
            if (p1 != null && p2 != null) {
                if (p1.GetType("value").Equals(o2)) {
                    return -1;
                }
                if (p2.GetType("value").Equals(o1)) {
                    return 1;
                }
            }
            return i1 - i2;
        }
    }
}
