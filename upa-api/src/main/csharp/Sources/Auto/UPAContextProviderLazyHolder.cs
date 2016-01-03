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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 1/2/13 12:53 PM
     */
    internal class UPAContextProviderLazyHolder {

        internal static Net.Vpc.Upa.UPAContextProvider INSTANCE = Create();

        public static Net.Vpc.Upa.UPAContextProvider Create() {
            Net.Vpc.Upa.UPAContextProvider o = Net.Vpc.Upa.UPA.GetBootstrapFactory().CreateObject<Net.Vpc.Upa.UPAContextProvider>(typeof(Net.Vpc.Upa.UPAContextProvider));
            Net.Vpc.Upa.UPA.contextProviderCreated = true;
            return o;
        }
    }
}
