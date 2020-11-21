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
     * @creationdate 12/31/12 1:19 PM
     */
    public class IdToKeyConverter<K> : Net.TheVpc.Upa.Impl.Util.Converter<K , Net.TheVpc.Upa.Key> {

        private Net.TheVpc.Upa.Entity entity;

        public IdToKeyConverter(Net.TheVpc.Upa.Entity entity) {
            this.entity = entity;
        }


        public virtual Net.TheVpc.Upa.Key Convert(K id) {
            return entity.GetBuilder().IdToKey(id);
        }
    }
}
