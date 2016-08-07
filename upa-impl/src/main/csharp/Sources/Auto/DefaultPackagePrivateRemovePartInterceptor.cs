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



namespace Net.Vpc.Upa.Impl
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    internal class DefaultPackagePrivateRemovePartInterceptor : Net.Vpc.Upa.Impl.Util.ItemInterceptor<Net.Vpc.Upa.PersistenceUnitPart> {

        public DefaultPackagePrivateRemovePartInterceptor() {
        }


        public virtual void Before(Net.Vpc.Upa.PersistenceUnitPart persistenceUnitItem, int index) {
        }


        public virtual void After(Net.Vpc.Upa.PersistenceUnitPart persistenceUnitItem, int index) {
            Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter a = new Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter(persistenceUnitItem);
            a.InjectNull("parent");
        }
    }
}
