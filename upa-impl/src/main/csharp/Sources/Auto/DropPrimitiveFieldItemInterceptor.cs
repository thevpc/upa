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
    * @creationdate 1/4/13 12:18 AM*/
    internal class DropPrimitiveFieldItemInterceptor : Net.Vpc.Upa.Impl.Util.ItemInterceptor<Net.Vpc.Upa.PrimitiveField> {


        public virtual void Before(Net.Vpc.Upa.PrimitiveField primitiveField, int index) {
        }


        public virtual void After(Net.Vpc.Upa.PrimitiveField primitiveField, int index) {
            Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter adapter = new Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter(primitiveField);
            adapter.InjectNull("parent");
        }
    }
}
