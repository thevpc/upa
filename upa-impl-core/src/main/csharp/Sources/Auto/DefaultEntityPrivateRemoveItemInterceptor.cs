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
     * @author taha.bensalah@gmail.com
     */
    internal class DefaultEntityPrivateRemoveItemInterceptor : Net.TheVpc.Upa.Impl.Util.ItemInterceptor<Net.TheVpc.Upa.EntityPart> {

        public DefaultEntityPrivateRemoveItemInterceptor() {
        }


        public virtual void Before(Net.TheVpc.Upa.EntityPart entityItem, int index) {
            Net.TheVpc.Upa.Impl.Util.DefaultBeanAdapter a = new Net.TheVpc.Upa.Impl.Util.DefaultBeanAdapter(entityItem);
            a.InjectNull("parent");
        }


        public virtual void After(Net.TheVpc.Upa.EntityPart entityItem, int index) {
        }
    }
}
