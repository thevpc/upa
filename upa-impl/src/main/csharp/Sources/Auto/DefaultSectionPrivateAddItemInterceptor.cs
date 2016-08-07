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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 1/8/13 2:27 PM
     */
    internal class DefaultSectionPrivateAddItemInterceptor : Net.Vpc.Upa.Impl.Util.ItemInterceptor<Net.Vpc.Upa.EntityPart> {

        private Net.Vpc.Upa.Impl.DefaultSection defaultSection;

        public DefaultSectionPrivateAddItemInterceptor(Net.Vpc.Upa.Impl.DefaultSection defaultSection) {
            this.defaultSection = defaultSection;
        }


        public virtual void Before(Net.Vpc.Upa.EntityPart child, int index) {
            Net.Vpc.Upa.EntityPart oldParent = child.GetParent();
            //        ((DefaultEntity) defaultSection.getEntity()).beforePartAdded(defaultSection, child, index);
            if (oldParent != null && oldParent != defaultSection) {
                if (oldParent is Net.Vpc.Upa.Section) {
                    Net.Vpc.Upa.Section x = (Net.Vpc.Upa.Section) oldParent;
                    x.RemovePartAt(x.IndexOfPart(child));
                }
            }
            Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter adapter = new Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter(child);
            if (oldParent != defaultSection) {
                adapter.SetProperty("parent", defaultSection);
            }
            adapter.SetProperty("entity", defaultSection.GetEntity());
        }


        public virtual void After(Net.Vpc.Upa.EntityPart entityItem, int index) {
        }
    }
}
