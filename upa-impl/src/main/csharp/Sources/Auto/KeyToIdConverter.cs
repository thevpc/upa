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
    public class KeyToIdConverter<K> : Net.Vpc.Upa.Impl.Util.Converter<Net.Vpc.Upa.Key , K> {

        private Net.Vpc.Upa.Entity entity;

        public KeyToIdConverter(Net.Vpc.Upa.Entity entity) {
            this.entity = entity;
        }


        public virtual K Convert(Net.Vpc.Upa.Key key) {
            return (K) entity.GetBuilder().KeyToId(key);
        }
    }
}
