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



namespace Net.Vpc.Upa
{


    /**
     *
     * @author taha.bensalah@gmaol.com
     */
    internal class ObjectFactoryComparator : System.Collections.Generic.IComparer<Net.Vpc.Upa.ObjectFactory> {

        private static readonly System.Collections.Generic.IComparer<Net.Vpc.Upa.ObjectFactory> instance = new Net.Vpc.Upa.ObjectFactoryComparator();

        public static System.Collections.Generic.IComparer<Net.Vpc.Upa.ObjectFactory> GetInstance() {
            return instance;
        }

        private ObjectFactoryComparator() {
        }

        public virtual int Compare(Net.Vpc.Upa.ObjectFactory o1, Net.Vpc.Upa.ObjectFactory o2) {
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
