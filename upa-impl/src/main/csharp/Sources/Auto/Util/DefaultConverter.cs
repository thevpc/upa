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
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class DefaultConverter<K, V> : Net.Vpc.Upa.Impl.Util.Converter<K , V> {

        private System.Collections.Generic.IDictionary<K , V> map;

        public DefaultConverter(System.Collections.Generic.IDictionary<K , V> map) {
            this.map = map;
        }


        public virtual V Convert(K k) {
            return Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<,>(map,k);
        }
    }
}
