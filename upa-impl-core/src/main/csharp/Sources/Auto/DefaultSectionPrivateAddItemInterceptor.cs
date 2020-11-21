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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 1/8/13 2:27 PM
     */
    internal class DefaultSectionPrivateAddItemInterceptor : Net.TheVpc.Upa.Impl.Util.ItemInterceptor<Net.TheVpc.Upa.EntityPart> {

        private Net.TheVpc.Upa.Impl.DefaultSection defaultSection;

        public DefaultSectionPrivateAddItemInterceptor(Net.TheVpc.Upa.Impl.DefaultSection defaultSection) {
            this.defaultSection = defaultSection;
        }


        public virtual void Before(Net.TheVpc.Upa.EntityPart child, int index) {
            Net.TheVpc.Upa.EntityPart oldParent = child.GetParent();
            //        ((DefaultEntity) defaultSection.getEntity()).beforePartAdded(defaultSection, child, index);
            if (oldParent != null && oldParent != defaultSection) {
                if (oldParent is Net.TheVpc.Upa.Section) {
                    Net.TheVpc.Upa.Section x = (Net.TheVpc.Upa.Section) oldParent;
                    x.RemovePartAt(x.IndexOfPart(child));
                }
            }
            Net.TheVpc.Upa.Impl.Util.DefaultBeanAdapter adapter = new Net.TheVpc.Upa.Impl.Util.DefaultBeanAdapter(child);
            if (oldParent != defaultSection) {
                adapter.SetProperty("parent", defaultSection);
            }
            adapter.SetProperty("entity", defaultSection.GetEntity());
        }


        public virtual void After(Net.TheVpc.Upa.EntityPart entityItem, int index) {
        }
    }
}
