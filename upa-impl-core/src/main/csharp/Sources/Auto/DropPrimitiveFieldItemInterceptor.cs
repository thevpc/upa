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
    * @creationdate 1/4/13 12:18 AM*/
    internal class DropPrimitiveFieldItemInterceptor : Net.TheVpc.Upa.Impl.Util.ItemInterceptor<Net.TheVpc.Upa.PrimitiveField> {


        public virtual void Before(Net.TheVpc.Upa.PrimitiveField primitiveField, int index) {
        }


        public virtual void After(Net.TheVpc.Upa.PrimitiveField primitiveField, int index) {
            Net.TheVpc.Upa.Impl.Util.DefaultBeanAdapter adapter = new Net.TheVpc.Upa.Impl.Util.DefaultBeanAdapter(primitiveField);
            adapter.InjectNull("parent");
        }
    }
}
