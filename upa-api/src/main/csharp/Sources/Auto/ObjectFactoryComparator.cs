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


    /**
     * @author taha.bensalah@gmaol.com
     */
    internal class ObjectFactoryComparator : System.Collections.Generic.IComparer<Net.TheVpc.Upa.ObjectFactory> {

        private static readonly System.Collections.Generic.IComparer<Net.TheVpc.Upa.ObjectFactory> instance = new Net.TheVpc.Upa.ObjectFactoryComparator();

        public static System.Collections.Generic.IComparer<Net.TheVpc.Upa.ObjectFactory> GetInstance() {
            return instance;
        }

        private ObjectFactoryComparator() {
        }

        public virtual int Compare(Net.TheVpc.Upa.ObjectFactory o1, Net.TheVpc.Upa.ObjectFactory o2) {
            if (o1 == o2) {
                return 0;
            }
            if (o1 == null) {
                return -1;
            }
            if (o2 == null) {
                return 1;
            }
            if (o1.Equals(o2)) {
                return 0;
            }
            return o1.GetContextSupportLevel().CompareTo(o2.GetContextSupportLevel());
        }
    }
}
