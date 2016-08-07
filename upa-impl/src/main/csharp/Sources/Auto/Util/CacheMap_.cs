using System.Collections.Generic;

namespace Net.Vpc.Upa.Impl.Util
{


    /**
     * @author Taha BEN Salah
     * @creationdate 1/14/13 1:10 AM
     */
    public class CacheMap<K, V> {

        private Dictionary<K , V> data;
        private SortedDictionary<int , K> order;
        private int orderIndex=0;
        private int maxCount= 0;

        public CacheMap(int maxCount) {
            data = new Dictionary<K, V>(maxCount);
            order = new SortedDictionary<int, K>();
        }

        public virtual V Get(K key) {
            return Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<K,V>(data,key);
        }

        public virtual bool ContainsKey(K key) {
            return data.ContainsKey(key);
        }

        public virtual void Put(K key, V @value) {
            if (!data.ContainsKey(key))
            {
                order[orderIndex] = key;
            }
            data[key]=@value;
            if (data.Count > maxCount)
            {
                bool found = false;
                int x = -1;
                K keyToRemove = default(K);
                foreach (var k in order)
                {
                    x = k.Key;
                    keyToRemove = k.Value;
                    found = true;
                    break;
                }
                if(found)
                {
                    order.Remove(x);
                    data.Remove(keyToRemove);
                }
            }
        }

        public virtual void Clear() {
            data.Clear();
            order.Clear();
            orderIndex = 0;
        }
    }
}
