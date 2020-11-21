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



using System.Linq;
namespace Net.TheVpc.Upa.Impl.Event
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class ListenerSupport<T> {

        private System.Collections.Generic.IList<T> allCommun = new System.Collections.Generic.List<T>();

        private System.Collections.Generic.IDictionary<string , System.Collections.Generic.IList<T>> someCommun = new System.Collections.Generic.Dictionary<string , System.Collections.Generic.IList<T>>();

        private System.Collections.Generic.IList<T> allSystem = new System.Collections.Generic.List<T>();

        private System.Collections.Generic.IDictionary<string , System.Collections.Generic.IList<T>> someSystem = new System.Collections.Generic.Dictionary<string , System.Collections.Generic.IList<T>>();

        public virtual void Add(bool system, string name, T t) {
            if (name != null && (name).Length == 0) {
                name = null;
            }
            if (system) {
                if (name == null) {
                    allSystem.Add(t);
                } else {
                    System.Collections.Generic.IList<T> v = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,System.Collections.Generic.IList<T>>(someSystem,name);
                    if (v == null) {
                        v = new System.Collections.Generic.List<T>();
                        someSystem[name]=v;
                    }
                    v.Add(t);
                }
            } else {
                if (name == null) {
                    allCommun.Add(t);
                } else {
                    System.Collections.Generic.IList<T> v = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,System.Collections.Generic.IList<T>>(someCommun,name);
                    if (v == null) {
                        v = new System.Collections.Generic.List<T>();
                        someCommun[name]=v;
                    }
                    v.Add(t);
                }
            }
        }

        public virtual void Remove(string n, T t) {
            Remove(true, n, t);
            Remove(false, n, t);
        }

        public virtual void Remove(bool system, string n, T t) {
            if (system) {
                if (n == null) {
                    allSystem.Remove(t);
                } else {
                    System.Collections.Generic.IList<T> v = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,System.Collections.Generic.IList<T>>(someSystem,n);
                    if (v != null) {
                        v.Remove(t);
                    }
                }
            } else {
                if (n == null) {
                    allCommun.Remove(t);
                } else {
                    System.Collections.Generic.IList<T> v = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,System.Collections.Generic.IList<T>>(someCommun,n);
                    if (v != null) {
                        v.Remove(t);
                    }
                }
            }
        }

        public virtual System.Collections.Generic.IList<T> GetAllListeners(bool system, params string [] names) {
            System.Collections.Generic.List<T> ret = new System.Collections.Generic.List<T>();
            if (names == null || names.Length == 0) {
                Net.TheVpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(ret, allSystem);
                if (!system) {
                    Net.TheVpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(ret, allCommun);
                }
            } else {
                Net.TheVpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(ret, allSystem);
                foreach (string n in names) {
                    System.Collections.Generic.IList<T> v = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,System.Collections.Generic.IList<T>>(someSystem,n);
                    if (v != null) {
                        Net.TheVpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(ret, v);
                    }
                }
                if (!system) {
                    Net.TheVpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(ret, allCommun);
                    foreach (string n in names) {
                        System.Collections.Generic.IList<T> v = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,System.Collections.Generic.IList<T>>(someCommun,n);
                        if (v != null) {
                            Net.TheVpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(ret, v);
                        }
                    }
                }
            }
            return ret;
        }

        public virtual T[] ToArrayConstrainted(bool system, string n, T[] arr) {
            if (system) {
                if (n == null) {
                    return allSystem.ToArray();
                } else {
                    System.Collections.Generic.IList<T> sum = new System.Collections.Generic.List<T>();
                    System.Collections.Generic.IList<T> v = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,System.Collections.Generic.IList<T>>(someSystem,n);
                    if (v != null) {
                        Net.TheVpc.Upa.Impl.FwkConvertUtils.ListAddRange(sum, v);
                    }
                    return sum.ToArray();
                }
            } else {
                if (n == null) {
                    return allCommun.ToArray();
                } else {
                    System.Collections.Generic.IList<T> sum = new System.Collections.Generic.List<T>();
                    System.Collections.Generic.IList<T> v = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,System.Collections.Generic.IList<T>>(someCommun,n);
                    if (v != null) {
                        Net.TheVpc.Upa.Impl.FwkConvertUtils.ListAddRange(sum, v);
                    }
                    return sum.ToArray();
                }
            }
        }
    }
}
