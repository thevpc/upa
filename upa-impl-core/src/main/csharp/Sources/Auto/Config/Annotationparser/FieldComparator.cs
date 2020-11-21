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
    * @author Taha BEN SALAH <taha.bensalah@gmail.com>
    * @creationdate 1/7/13 2:32 AM*/
    internal class FieldComparator : System.Collections.Generic.IComparer<System.Reflection.FieldInfo> {

        internal Net.TheVpc.Upa.Impl.Config.Decorations.DecorationRepository repo;

        public FieldComparator(Net.TheVpc.Upa.Impl.Config.Decorations.DecorationRepository repo) {
            this.repo = repo;
        }

        public virtual int Compare(System.Reflection.FieldInfo o1, System.Reflection.FieldInfo o2) {
            Net.TheVpc.Upa.Config.Decoration f1 = repo.GetFieldDecoration(o1, typeof(Net.TheVpc.Upa.Config.Field));
            Net.TheVpc.Upa.Config.Decoration f2 = repo.GetFieldDecoration(o2, typeof(Net.TheVpc.Upa.Config.Field));
            if (f1 == null && f2 == null) {
                return 0;
            }
            if (f1 == null) {
                return -1;
            }
            if (f2 == null) {
                return 1;
            }
            return f1.GetConfig().GetOrder().CompareTo(f2.GetConfig().GetOrder());
        }
    }
}
