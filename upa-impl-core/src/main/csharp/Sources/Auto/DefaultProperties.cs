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
     * @creationdate 8/23/12 1:26 PM
     */
    public class DefaultProperties : Net.Vpc.Upa.Impl.AbstractProperties {

        private System.Collections.Generic.IDictionary<string , object> @base = new System.Collections.Generic.Dictionary<string , object>();

        private Net.Vpc.Upa.PropertyChangeSupport propertyChangeSupport;

        private Net.Vpc.Upa.Properties parent;

        public DefaultProperties()  : this(null){

        }

        public DefaultProperties(Net.Vpc.Upa.Properties parent) {
            propertyChangeSupport = new Net.Vpc.Upa.PropertyChangeSupport(this);
            this.parent = parent;
        }

        public override bool ContainsKey(string key) {
            if (@base.ContainsKey(key)) {
                return true;
            }
            return parent != null && parent.ContainsKey(key);
        }

        public virtual Net.Vpc.Upa.Properties GetParent() {
            return parent;
        }

        public virtual void SetParent(Net.Vpc.Upa.Properties parent) {
            this.parent = parent;
        }


        public override  T GetObject<T>(string key) {
            if (parent == null || @base.ContainsKey(key)) {
                return (T) Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(@base,key);
            }
            return parent.GetObject<T>(key);
        }


        public override  T GetObject<T>(string key, T @value) {
            if (@base.ContainsKey(key)) {
                return (T) Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(@base,key);
            } else {
                if (parent != null) {
                    return parent.GetObject<T>(key, @value);
                }
                return @value;
            }
        }


        public override void SetObject(string key, object @value) {
            @base[key]=@value;
        }


        public override  T GetSingleObject<T>() {
            foreach (object o in (@base).Values) {
                return (T) o;
            }
            if (parent != null) {
                return parent.GetSingleObject<T>();
            }
            return default(T);
        }


        public override bool IsSet(string key) {
            return @base.ContainsKey(key) || (parent != null && parent.IsSet(key));
        }


        public override void Remove(string key) {
            @base.Remove(key);
        }


        public override System.Collections.Generic.ISet<string> KeySet() {
            if (parent == null) {
                return new System.Collections.Generic.HashSet<string>(@base.Keys);
            }
            System.Collections.Generic.HashSet<string> all = new System.Collections.Generic.HashSet<string>();
            Net.Vpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(all, new System.Collections.Generic.HashSet<string>(@base.Keys));
            Net.Vpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(all, parent.KeySet());
            return all;
        }


        public override int Size() {
            return (KeySet()).Count;
        }


        public override System.Collections.Generic.IDictionary<string , object> ToMap() {
            if (parent == null) {
                return new System.Collections.Generic.Dictionary<string , object>(@base);
            }
            System.Collections.Generic.IDictionary<string , object> r = new System.Collections.Generic.Dictionary<string , object>(parent.ToMap());
            Net.Vpc.Upa.Impl.FwkConvertUtils.PutAllMap<string,object>(r,@base);
            return r;
        }


        public override void AddPropertyChangeListener(string key, Net.Vpc.Upa.PropertyChangeListener listener) {
            propertyChangeSupport.AddPropertyChangeListener(key, listener);
        }


        public override void RemovePropertyChangeListener(string key, Net.Vpc.Upa.PropertyChangeListener listener) {
            propertyChangeSupport.RemovePropertyChangeListener(key, listener);
        }


        public override void AddPropertyChangeListener(Net.Vpc.Upa.PropertyChangeListener listener) {
            propertyChangeSupport.AddPropertyChangeListener(listener);
        }


        public override void RemovePropertyChangeListener(Net.Vpc.Upa.PropertyChangeListener listener) {
            propertyChangeSupport.RemovePropertyChangeListener(listener);
        }


        public override string ToString() {
            return ToMap().ToString();
        }
    }
}
