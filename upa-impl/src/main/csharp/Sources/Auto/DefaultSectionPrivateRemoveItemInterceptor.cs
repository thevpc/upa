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
    internal class DefaultSectionPrivateRemoveItemInterceptor : Net.Vpc.Upa.Impl.Util.ItemInterceptor<Net.Vpc.Upa.EntityPart> {

        public DefaultSectionPrivateRemoveItemInterceptor() {
        }


        public virtual void Before(Net.Vpc.Upa.EntityPart child, int index) {
            Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter adapter = new Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter(child);
            adapter.InjectNull("parent");
        }


        public virtual void After(Net.Vpc.Upa.EntityPart entityItem, int index) {
        }
    }
}
