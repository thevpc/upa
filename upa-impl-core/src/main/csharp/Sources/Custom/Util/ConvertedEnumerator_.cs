using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Net.TheVpc.Upa.Impl.Util
{
    class ConvertedEnumerator<K,V> : IEnumerator<V>
    {
        private IEnumerator<K> source;
        private Net.TheVpc.Upa.Impl.Util.Converter<K, V> converter;

        public ConvertedEnumerator(IEnumerator<K> source, Converter<K, V> converter)
        {
            this.source = source;
            this.converter = converter;
        }

        public void Dispose()
        {
            source.Dispose();
        }

        public bool MoveNext()
        {
            return source.MoveNext();
        }

        public void Reset()
        {
            source.Reset();
        }

        object IEnumerator.Current
        {
            get { return converter.Convert(source.Current); }
        }

        public V Current
        {
            get { return converter.Convert(source.Current); }
        }
    }
}
