using System.Collections;
using System.Collections.Generic;

namespace Net.TheVpc.Upa.Impl.Util
{


    /**
     * @author Taha BEN Salah
     * @creationdate 8/26/12 4:41 PM
     */
    public class ConvertedList<K, V> : AbstractReadOnlyList<V>
    {

        private Net.TheVpc.Upa.Impl.Util.Converter<K , V> converter;

        private System.Collections.Generic.IList<K> @base;

        public ConvertedList(System.Collections.Generic.IList<K> @base, Net.TheVpc.Upa.Impl.Util.Converter<K , V> converter) {
            this.@base = @base;
            this.converter = converter;
        }


        protected override V Get(int index)
        {
            return converter.Convert(@base[index]);
        }

        public override int Count
        {
            get { return @base.Count; }
        }
    }
}
