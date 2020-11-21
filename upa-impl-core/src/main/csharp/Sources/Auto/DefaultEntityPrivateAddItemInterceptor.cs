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
    * @creationdate 1/8/13 2:25 PM*/
    internal class DefaultEntityPrivateAddItemInterceptor : Net.TheVpc.Upa.Impl.Util.ItemInterceptor<Net.TheVpc.Upa.EntityPart> {

        private Net.TheVpc.Upa.Impl.DefaultEntity defaultEntity;

        public DefaultEntityPrivateAddItemInterceptor(Net.TheVpc.Upa.Impl.DefaultEntity defaultEntity) {
            this.defaultEntity = defaultEntity;
        }


        public virtual void Before(Net.TheVpc.Upa.EntityPart item, int index) {
            Net.TheVpc.Upa.EntityPart oldParent = item.GetParent();
            if (oldParent != null) {
                if (!(oldParent is Net.TheVpc.Upa.Section) && !(oldParent is Net.TheVpc.Upa.CompoundField)) {
                    throw new System.ArgumentException ("Field Parent is neither a Field Section nor a Field");
                }
            }
            defaultEntity.BeforePartAdded(null, item, index);
            if (oldParent != null) {
                if (oldParent is Net.TheVpc.Upa.Section) {
                    Net.TheVpc.Upa.Section x = (Net.TheVpc.Upa.Section) oldParent;
                    x.RemovePartAt(x.IndexOfPart(item));
                } else if (oldParent is Net.TheVpc.Upa.CompoundField) {
                    Net.TheVpc.Upa.CompoundField x = (Net.TheVpc.Upa.CompoundField) oldParent;
                    ((Net.TheVpc.Upa.Impl.DefaultCompoundField) x).DropFieldAt(x.IndexOfField((Net.TheVpc.Upa.PrimitiveField) item));
                }
            }
            //
            Net.TheVpc.Upa.Impl.Util.DefaultBeanAdapter a = new Net.TheVpc.Upa.Impl.Util.DefaultBeanAdapter(item);
            if (oldParent != null) {
                a.InjectNull("parent");
            }
            a.SetProperty("entity", defaultEntity);
        }


        public virtual void After(Net.TheVpc.Upa.EntityPart item, int index) {
            defaultEntity.AfterPartAdded(null, item, index);
        }
    }
}
