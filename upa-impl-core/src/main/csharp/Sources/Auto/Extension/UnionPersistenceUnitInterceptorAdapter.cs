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



namespace Net.TheVpc.Upa.Impl.Extension
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 1/8/13 2:29 PM
     */
    internal class UnionPersistenceUnitInterceptorAdapter : Net.TheVpc.Upa.Callbacks.PersistenceUnitListenerAdapter {

        private Net.TheVpc.Upa.Impl.Extension.DefaultUnionEntityExtension defaultUnionEntityExtensionSupport;

        public UnionPersistenceUnitInterceptorAdapter(Net.TheVpc.Upa.Impl.Extension.DefaultUnionEntityExtension defaultUnionEntityExtensionSupport) {
            this.defaultUnionEntityExtensionSupport = defaultUnionEntityExtensionSupport;
        }


        public override void OnModelChanged(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event) {
            if (defaultUnionEntityExtensionSupport.viewQuery == null) {
                defaultUnionEntityExtensionSupport.viewQuery = defaultUnionEntityExtensionSupport.CreateViewQuery();
            }
        }
    }
}
