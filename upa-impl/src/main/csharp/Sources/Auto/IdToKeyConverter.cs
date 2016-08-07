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
     * @creationdate 12/31/12 1:19 PM
     */
    public class IdToKeyConverter<K> : Net.Vpc.Upa.Impl.Util.Converter<K , Net.Vpc.Upa.Key> {

        private Net.Vpc.Upa.Entity entity;

        public IdToKeyConverter(Net.Vpc.Upa.Entity entity) {
            this.entity = entity;
        }


        public virtual Net.Vpc.Upa.Key Convert(K id) {
            return entity.GetBuilder().IdToKey(id);
        }
    }
}
