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



namespace Net.Vpc.Upa.Impl.Extension
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 1/8/13 2:29 PM
     */
    internal class UnionPersistenceUnitInterceptorAdapter : Net.Vpc.Upa.Callbacks.PersistenceUnitListenerAdapter {

        private Net.Vpc.Upa.Impl.Extension.DefaultUnionEntityExtension defaultUnionEntityExtensionSupport;

        public UnionPersistenceUnitInterceptorAdapter(Net.Vpc.Upa.Impl.Extension.DefaultUnionEntityExtension defaultUnionEntityExtensionSupport) {
            this.defaultUnionEntityExtensionSupport = defaultUnionEntityExtensionSupport;
        }


        public override void OnModelChanged(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event) {
            if (defaultUnionEntityExtensionSupport.viewQuery == null) {
                defaultUnionEntityExtensionSupport.viewQuery = defaultUnionEntityExtensionSupport.CreateViewQuery();
            }
        }
    }
}
