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
    * @creationdate 1/8/13 2:25 PM*/
    internal class DefaultEntityPrivateAddItemInterceptor : Net.Vpc.Upa.Impl.Util.ItemInterceptor<Net.Vpc.Upa.EntityPart> {

        private Net.Vpc.Upa.Impl.DefaultEntity defaultEntity;

        public DefaultEntityPrivateAddItemInterceptor(Net.Vpc.Upa.Impl.DefaultEntity defaultEntity) {
            this.defaultEntity = defaultEntity;
        }


        public virtual void Before(Net.Vpc.Upa.EntityPart item, int index) {
            Net.Vpc.Upa.EntityPart oldParent = item.GetParent();
            if (oldParent != null) {
                if (!(oldParent is Net.Vpc.Upa.Section) && !(oldParent is Net.Vpc.Upa.CompoundField)) {
                    throw new System.ArgumentException ("Field Parent is neither a Field Section nor a Field");
                }
            }
            defaultEntity.BeforePartAdded(null, item, index);
            if (oldParent != null) {
                if (oldParent is Net.Vpc.Upa.Section) {
                    Net.Vpc.Upa.Section x = (Net.Vpc.Upa.Section) oldParent;
                    x.RemovePartAt(x.IndexOfPart(item));
                } else if (oldParent is Net.Vpc.Upa.CompoundField) {
                    Net.Vpc.Upa.CompoundField x = (Net.Vpc.Upa.CompoundField) oldParent;
                    ((Net.Vpc.Upa.Impl.DefaultCompoundField) x).DropFieldAt(x.IndexOfField((Net.Vpc.Upa.PrimitiveField) item));
                }
            }
            //
            Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter a = new Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter(item);
            if (oldParent != null) {
                a.InjectNull("parent");
            }
            a.SetProperty("entity", defaultEntity);
        }


        public virtual void After(Net.Vpc.Upa.EntityPart item, int index) {
            defaultEntity.AfterPartAdded(null, item, index);
        }
    }
}
