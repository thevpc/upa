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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 1/2/13 12:53 PM
     */
    internal class UPAContextProviderLazyHolder {

        internal static Net.TheVpc.Upa.UPAContextProvider INSTANCE = Create();

        public static Net.TheVpc.Upa.UPAContextProvider Create() {
            Net.TheVpc.Upa.UPAContextProvider o = Net.TheVpc.Upa.UPA.GetBootstrapFactory().CreateObject<>(typeof(Net.TheVpc.Upa.UPAContextProvider));
            return o;
        }
    }
}
