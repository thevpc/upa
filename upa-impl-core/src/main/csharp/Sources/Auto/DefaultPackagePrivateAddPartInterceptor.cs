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
    internal class DefaultPackagePrivateAddPartInterceptor : Net.TheVpc.Upa.Impl.Util.ItemInterceptor<Net.TheVpc.Upa.PersistenceUnitPart> {

        private Net.TheVpc.Upa.Package p;

        public DefaultPackagePrivateAddPartInterceptor(Net.TheVpc.Upa.Package p) {
            this.p = p;
        }

        public virtual void Before(Net.TheVpc.Upa.PersistenceUnitPart t, int index) {
            Net.TheVpc.Upa.PersistenceUnitPart oldParent = t.GetParent();
            if (oldParent != null && oldParent != p) {
                if (oldParent is Net.TheVpc.Upa.Package) {
                    Net.TheVpc.Upa.Package x = (Net.TheVpc.Upa.Package) oldParent;
                    x.RemovePartAt(x.IndexOfPart(t));
                } else if (oldParent is Net.TheVpc.Upa.PrimitiveField) {
                }
            }
        }

        public virtual void After(Net.TheVpc.Upa.PersistenceUnitPart t, int index) {
            Net.TheVpc.Upa.PersistenceUnitPart oldParent = t.GetParent();
            if (oldParent != p) {
                Net.TheVpc.Upa.Impl.Util.DefaultBeanAdapter a = new Net.TheVpc.Upa.Impl.Util.DefaultBeanAdapter(t);
                a.SetProperty("parent", p);
            }
            //in case of move => same parent!
            Net.TheVpc.Upa.Impl.Util.UPAUtils.PreparePostAdd(p.GetPersistenceUnit(), t);
        }
    }
}
