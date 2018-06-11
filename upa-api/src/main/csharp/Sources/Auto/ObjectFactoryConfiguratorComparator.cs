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


    /**
     * @author taha.bensalah@gmaol.com
     */
    internal class ObjectFactoryConfiguratorComparator : System.Collections.Generic.IComparer<Net.Vpc.Upa.ObjectFactoryConfigurator> {

        private static readonly System.Collections.Generic.IComparer<Net.Vpc.Upa.ObjectFactoryConfigurator> instance = new Net.Vpc.Upa.ObjectFactoryConfiguratorComparator();

        public static System.Collections.Generic.IComparer<Net.Vpc.Upa.ObjectFactoryConfigurator> GetInstance() {
            return instance;
        }

        private ObjectFactoryConfiguratorComparator() {
        }

        public virtual int Compare(Net.Vpc.Upa.ObjectFactoryConfigurator o1, Net.Vpc.Upa.ObjectFactoryConfigurator o2) {
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
