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
    public class KeyToIdConverter<K> : Net.TheVpc.Upa.Impl.Util.Converter<Net.TheVpc.Upa.Key , K> {

        private Net.TheVpc.Upa.Entity entity;

        public KeyToIdConverter(Net.TheVpc.Upa.Entity entity) {
            this.entity = entity;
        }


        public virtual K Convert(Net.TheVpc.Upa.Key key) {
            return (K) entity.GetBuilder().KeyToId(key);
        }
    }
}
