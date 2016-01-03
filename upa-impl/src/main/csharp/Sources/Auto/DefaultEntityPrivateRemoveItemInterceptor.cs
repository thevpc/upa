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
     * @author vpc
     */
    internal class DefaultEntityPrivateRemoveItemInterceptor : Net.Vpc.Upa.Impl.Util.ItemInterceptor<Net.Vpc.Upa.EntityPart> {

        public DefaultEntityPrivateRemoveItemInterceptor() {
        }


        public virtual void Before(Net.Vpc.Upa.EntityPart entityItem, int index) {
            Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter a = new Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter(entityItem);
            a.InjectNull("parent");
        }


        public virtual void After(Net.Vpc.Upa.EntityPart entityItem, int index) {
        }
    }
}
