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
    internal class DefaultSectionPrivateRemoveItemInterceptor : Net.TheVpc.Upa.Impl.Util.ItemInterceptor<Net.TheVpc.Upa.EntityPart> {

        public DefaultSectionPrivateRemoveItemInterceptor() {
        }


        public virtual void Before(Net.TheVpc.Upa.EntityPart child, int index) {
            Net.TheVpc.Upa.Impl.Util.DefaultBeanAdapter adapter = new Net.TheVpc.Upa.Impl.Util.DefaultBeanAdapter(child);
            adapter.InjectNull("parent");
        }


        public virtual void After(Net.TheVpc.Upa.EntityPart entityItem, int index) {
        }
    }
}
