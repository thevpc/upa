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



namespace Net.Vpc.Upa.Impl.Event
{


    /**
    * @author Taha BEN SALAH <taha.bensalah@gmail.com>
    * @creationdate 1/4/13 12:17 AM*/
    public class AddPrimitiveFieldItemInterceptor : Net.Vpc.Upa.Impl.Util.ItemInterceptor<Net.Vpc.Upa.PrimitiveField> {

        private Net.Vpc.Upa.Impl.DefaultCompoundField defaultCompoundField;

        public AddPrimitiveFieldItemInterceptor(Net.Vpc.Upa.Impl.DefaultCompoundField defaultCompoundField) {
            this.defaultCompoundField = defaultCompoundField;
        }


        public virtual void Before(Net.Vpc.Upa.PrimitiveField primitiveField, int index) {
        }


        public virtual void After(Net.Vpc.Upa.PrimitiveField child, int index) {
            Net.Vpc.Upa.EntityPart oldParent = child.GetParent();
            if (oldParent != null && oldParent != defaultCompoundField) {
                if (oldParent is Net.Vpc.Upa.Section) {
                    Net.Vpc.Upa.Section x = (Net.Vpc.Upa.Section) oldParent;
                    x.RemovePartAt(x.IndexOfPart(child));
                } else if (oldParent is Net.Vpc.Upa.CompoundField) {
                    Net.Vpc.Upa.CompoundField x = (Net.Vpc.Upa.CompoundField) oldParent;
                    ((Net.Vpc.Upa.Impl.DefaultCompoundField) x).DropFieldAt(x.IndexOfField(child));
                }
            }
            if (oldParent != defaultCompoundField) {
                Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter adapter = new Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter(child);
                adapter.SetProperty("parent", defaultCompoundField);
            }
        }
    }
}
