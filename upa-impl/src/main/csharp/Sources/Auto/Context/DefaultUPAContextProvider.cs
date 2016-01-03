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



namespace Net.Vpc.Upa.Impl.Context
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class DefaultUPAContextProvider : Net.Vpc.Upa.UPAContextProvider {

        private static Net.Vpc.Upa.UPAContext instance;

        public virtual Net.Vpc.Upa.UPAContext GetContext() {
            return instance;
        }

        public virtual void SetContext(Net.Vpc.Upa.UPAContext newInstance) {
            instance = newInstance;
        }
    }
}
