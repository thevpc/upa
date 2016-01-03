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
     * @author Taha BEN SALAH (taha.bensalah@gmail.com)
     * @creationtime  13 juil. 2006 22:14:21
     */
    public class ClassMap<V> {

        private System.Collections.Generic.IDictionary<System.Type , V> data = new System.Collections.Generic.Dictionary<System.Type , V>();

        private System.Collections.Generic.IDictionary<System.Type , V> cache = new System.Collections.Generic.Dictionary<System.Type , V>();

        public ClassMap() {
        }

        public virtual V Put(System.Type key, V @value) {
            cache.Clear();
            return data[key]=@value;
        }

        public virtual V Remove(System.Type key) {
            cache.Clear();
            return Net.Vpc.Upa.Impl.FwkConvertUtils.RemoveMapKey<System.Type,V>(data,key);
        }

        public virtual V Get(System.Type clazz) {
            V v1 = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,V>(cache,clazz);
            if (v1 != default(V)) {
                return v1;
            }
            System.Collections.Generic.HashSet<System.Type> visited = new System.Collections.Generic.HashSet<System.Type>();
            System.Collections.Generic.IList<System.Type> s = new System.Collections.Generic.List<System.Type>();
            s.Add(clazz);
            while (!(s.Count==0)) {
                System.Type c = s[0];
                s.RemoveAt(0);
                if (!visited.Contains(c)) {
                    visited.Add(c);
                    V v = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,V>(cache,c);
                    if (v != default(V)) {
                        return v;
                    }
                    v = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,V>(data,c);
                    if (v != default(V)) {
                        cache[clazz]=v;
                        return v;
                    }
                    System.Type superclass = (c).BaseType;
                    if (superclass != null) {
                        s.Add(superclass);
                    }
                    foreach (System.Type i in c.GetInterfaces()) {
                        s.Add(i);
                    }
                }
            }
            if (!visited.Contains(typeof(object))) {
                visited.Add(typeof(object));
                V v = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,V>(cache,typeof(object));
                if (v != default(V)) {
                    cache[clazz]=v;
                    return v;
                }
            }
            return default(V);
        }
    }
}
