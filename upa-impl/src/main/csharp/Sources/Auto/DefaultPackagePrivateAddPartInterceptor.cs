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
    internal class DefaultPackagePrivateAddPartInterceptor : Net.Vpc.Upa.Impl.Util.ItemInterceptor<Net.Vpc.Upa.PersistenceUnitPart> {

        private Net.Vpc.Upa.Package p;

        public DefaultPackagePrivateAddPartInterceptor(Net.Vpc.Upa.Package p) {
            this.p = p;
        }

        public virtual void Before(Net.Vpc.Upa.PersistenceUnitPart t, int index) {
            Net.Vpc.Upa.PersistenceUnitPart oldParent = t.GetParent();
            if (oldParent != null && oldParent != p) {
                if (oldParent is Net.Vpc.Upa.Package) {
                    Net.Vpc.Upa.Package x = (Net.Vpc.Upa.Package) oldParent;
                    x.RemovePartAt(x.IndexOfPart(t));
                } else if (oldParent is Net.Vpc.Upa.PrimitiveField) {
                }
            }
        }

        public virtual void After(Net.Vpc.Upa.PersistenceUnitPart t, int index) {
            Net.Vpc.Upa.PersistenceUnitPart oldParent = t.GetParent();
            if (oldParent != p) {
                Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter a = new Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter(t);
                a.SetProperty("parent", p);
            }
            //in case of move => same parent!
            Net.Vpc.Upa.Impl.Util.UPAUtils.PreparePostAdd(p.GetPersistenceUnit(), t);
        }
    }
}
