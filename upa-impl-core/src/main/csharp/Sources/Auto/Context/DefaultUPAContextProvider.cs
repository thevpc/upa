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



namespace Net.TheVpc.Upa.Impl.Context
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class DefaultUPAContextProvider : Net.TheVpc.Upa.UPAContextProvider {

        private static Net.TheVpc.Upa.UPAContext instance;

        public virtual Net.TheVpc.Upa.UPAContext GetContext() {
            return instance;
        }

        public virtual void SetContext(Net.TheVpc.Upa.UPAContext newInstance) {
            instance = newInstance;
        }
    }
}
