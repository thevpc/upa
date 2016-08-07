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



namespace Net.Vpc.Upa.Impl.Util
{

    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 1/20/13 6:50 PM
     */
    public class CastConverter<K, V> : Net.Vpc.Upa.Impl.Util.Converter<K , V> {


        public virtual V Convert(K k) {
            //Double casting is mandatory in dotNet :(
            return (V) (object) k;
        }
    }
}
