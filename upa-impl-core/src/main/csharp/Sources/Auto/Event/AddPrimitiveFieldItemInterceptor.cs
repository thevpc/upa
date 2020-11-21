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



namespace Net.TheVpc.Upa.Impl.Event
{


    /**
    * @author Taha BEN SALAH <taha.bensalah@gmail.com>
    * @creationdate 1/4/13 12:17 AM*/
    public class AddPrimitiveFieldItemInterceptor : Net.TheVpc.Upa.Impl.Util.ItemInterceptor<Net.TheVpc.Upa.PrimitiveField> {

        private Net.TheVpc.Upa.Impl.DefaultCompoundField defaultCompoundField;

        public AddPrimitiveFieldItemInterceptor(Net.TheVpc.Upa.Impl.DefaultCompoundField defaultCompoundField) {
            this.defaultCompoundField = defaultCompoundField;
        }


        public virtual void Before(Net.TheVpc.Upa.PrimitiveField primitiveField, int index) {
        }


        public virtual void After(Net.TheVpc.Upa.PrimitiveField child, int index) {
            Net.TheVpc.Upa.EntityPart oldParent = child.GetParent();
            if (oldParent != null && oldParent != defaultCompoundField) {
                if (oldParent is Net.TheVpc.Upa.Section) {
                    Net.TheVpc.Upa.Section x = (Net.TheVpc.Upa.Section) oldParent;
                    x.RemovePartAt(x.IndexOfPart(child));
                } else if (oldParent is Net.TheVpc.Upa.CompoundField) {
                    Net.TheVpc.Upa.CompoundField x = (Net.TheVpc.Upa.CompoundField) oldParent;
                    ((Net.TheVpc.Upa.Impl.DefaultCompoundField) x).DropFieldAt(x.IndexOfField(child));
                }
            }
            if (oldParent != defaultCompoundField) {
                Net.TheVpc.Upa.Impl.Util.DefaultBeanAdapter adapter = new Net.TheVpc.Upa.Impl.Util.DefaultBeanAdapter(child);
                adapter.SetProperty("parent", defaultCompoundField);
            }
        }
    }
}
