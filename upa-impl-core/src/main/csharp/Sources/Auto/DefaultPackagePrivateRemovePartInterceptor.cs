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



namespace Net.TheVpc.Upa.Impl
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    internal class DefaultPackagePrivateRemovePartInterceptor : Net.TheVpc.Upa.Impl.Util.ItemInterceptor<Net.TheVpc.Upa.PersistenceUnitPart> {

        public DefaultPackagePrivateRemovePartInterceptor() {
        }


        public virtual void Before(Net.TheVpc.Upa.PersistenceUnitPart persistenceUnitItem, int index) {
        }


        public virtual void After(Net.TheVpc.Upa.PersistenceUnitPart persistenceUnitItem, int index) {
            Net.TheVpc.Upa.Impl.Util.DefaultBeanAdapter a = new Net.TheVpc.Upa.Impl.Util.DefaultBeanAdapter(persistenceUnitItem);
            a.InjectNull("parent");
        }
    }
}
