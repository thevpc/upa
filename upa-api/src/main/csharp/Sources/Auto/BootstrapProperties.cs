/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.Vpc.Upa
{


    /**
     * AbstractParameters is an abstract implementation of the Parameters interface
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/25/12 1:31 AM
     */
    internal class BootstrapProperties : Net.Vpc.Upa.Properties {

        private System.Collections.Generic.IDictionary<string , object> @base = new System.Collections.Generic.Dictionary<string , object>();

        private Net.Vpc.Upa.PropertyChangeSupport propertyChangeSupport;

        private Net.Vpc.Upa.Properties parent;

        public BootstrapProperties()  : this(null){

        }

        public BootstrapProperties(Net.Vpc.Upa.Properties parent) {
            propertyChangeSupport = new Net.Vpc.Upa.PropertyChangeSupport(this);
            this.parent = parent;
        }


        public virtual void SetAll(System.Collections.Generic.IDictionary<string , object> other, params string [] keys) {
            if (keys.Length == 0) {
                foreach (System.Collections.Generic.KeyValuePair<string , object> entry in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,object>>(other)) {
                    SetObject((entry).Key, (entry).Value);
                }
            } else {
                System.Collections.Generic.HashSet<string> accepted = new System.Collections.Generic.HashSet<string>(new System.Collections.Generic.List<string>(keys));
                foreach (string s in accepted) {
                    if (other.ContainsKey(s)) {
                        SetObject(s, Net.Vpc.Upa.FwkConvertUtils.GetMapValue<string,object>(other,s));
                    }
                }
            }
        }


        public virtual int GetInt(string key) {
            return System.Convert.ToInt32(((object) GetObject<>(key)));
        }


        public virtual int GetInt(string key, int defaultValue) {
            return System.Convert.ToInt32(((object) GetObject<>(key, defaultValue)));
        }


        public virtual void SetInt(string key, int @value) {
            SetObject(key, @value);
        }


        public virtual int GetSingleInt() {
            return GetSingleObject<>();
        }


        public virtual long GetLong(string key) {
            return System.Convert.ToInt32(((object) GetObject<>(key)));
        }


        public virtual long GetLong(string key, long defaultValue) {
            object @object = GetObject<>(key, defaultValue);
            return System.Convert.ToInt32(@object);
        }


        public virtual void SetLong(string key, long @value) {
            SetObject(key, @value);
        }


        public virtual long GetSingleLong() {
            return GetSingleObject<>();
        }


        public virtual double GetDouble(string key) {
            return System.Convert.ToDouble(((object) GetObject<>(key)));
        }


        public virtual double GetDouble(string key, double defaultValue) {
            return System.Convert.ToDouble(((object) GetObject<>(key, defaultValue)));
        }


        public virtual void SetDouble(string key, double @value) {
            SetObject(key, @value);
        }


        public virtual double GetSingleDouble() {
            return System.Convert.ToDouble(((object) GetSingleObject<>()));
        }


        public virtual float GetFloat(string key) {
            return System.Convert.ToSingle(((object) GetObject<>(key)));
        }


        public virtual float GetFloat(string key, float defaultValue) {
            return System.Convert.ToSingle(((object) GetObject<>(key, defaultValue)));
        }


        public virtual void SetFloat(string key, float @value) {
            SetObject(key, @value);
        }


        public virtual float GetSingleFloat() {
            return System.Convert.ToSingle(((object) GetSingleObject<>()));
        }










        public virtual System.Numerics.BigInteger? GetBigInteger(string key) {
            return GetObject<>(key);
        }


        public virtual System.Numerics.BigInteger? GetBigInteger(string key, System.Numerics.BigInteger? defaultValue) {
            return GetObject<>(key, defaultValue);
        }


        public virtual void SetBigInteger(string key, System.Numerics.BigInteger? @value) {
            SetObject(key, @value);
        }


        public virtual System.Numerics.BigInteger? GetSingleBigInteger() {
            return GetSingleObject<>();
        }










        public virtual bool GetBoolean(string key) {
            return GetObject<>(key);
        }


        public virtual bool GetBoolean(string key, bool defaultValue) {
            return GetObject<>(key, defaultValue);
        }


        public virtual void SetBoolean(string key, bool @value) {
            SetObject(key, @value);
        }


        public virtual bool GetSingleBoolean() {
            return GetSingleObject<>();
        }


        public virtual string GetString(string key) {
            return ((string) GetObject<>(key));
        }


        public virtual string GetString(string key, string defaultValue) {
            return GetObject<>(key, defaultValue);
        }


        public virtual void SetString(string key, string @value) {
            SetObject(key, @value);
        }


        public virtual string GetSingleString() {
            return GetSingleObject<>();
        }


        public virtual Net.Vpc.Upa.Types.Temporal GetDate(string key) {
            return GetObject<>(key);
        }


        public virtual Net.Vpc.Upa.Types.Temporal GetDate(string key, Net.Vpc.Upa.Types.Temporal defaultValue) {
            return GetObject<>(key, defaultValue);
        }


        public virtual void SetDate(string key, Net.Vpc.Upa.Types.Temporal @value) {
            SetObject(key, @value);
        }


        public virtual Net.Vpc.Upa.Types.Temporal GetSingleDate() {
            return GetSingleObject<>();
        }


        public virtual void SetAll(Net.Vpc.Upa.Properties other, params string [] keys) {
            SetAll(other.ToMap(), keys);
        }

        public virtual bool ContainsKey(string key) {
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


        public virtual  T GetObject<T>(string key) {
            if (parent == null || @base.ContainsKey(key)) {
                return (T) Net.Vpc.Upa.FwkConvertUtils.GetMapValue<string,object>(@base,key);
            }
            return parent.GetObject<>(key);
        }


        public virtual  T GetObject<T>(string key, T @value) {
            if (@base.ContainsKey(key)) {
                return (T) Net.Vpc.Upa.FwkConvertUtils.GetMapValue<string,object>(@base,key);
            } else {
                if (parent != null) {
                    return parent.GetObject<>(key, @value);
                }
                return @value;
            }
        }


        public virtual void SetObject(string key, object @value) {
            @base[key]=@value;
        }


        public virtual  T GetSingleObject<T>() {
            foreach (object o in (@base).Values) {
                return (T) o;
            }
            if (parent != null) {
                return parent.GetSingleObject<>();
            }
            return default(T);
        }


        public virtual bool IsSet(string key) {
            return @base.ContainsKey(key) || (parent != null && parent.IsSet(key));
        }


        public virtual void Remove(string key) {
            @base.Remove(key);
        }


        public virtual System.Collections.Generic.ISet<string> KeySet() {
            if (parent == null) {
                return new System.Collections.Generic.HashSet<K>(@base.Keys);
            }
            System.Collections.Generic.HashSet<string> all = new System.Collections.Generic.HashSet<string>();
            Net.Vpc.Upa.FwkConvertUtils.CollectionAddRange(all, new System.Collections.Generic.HashSet<K>(@base.Keys));
            Net.Vpc.Upa.FwkConvertUtils.CollectionAddRange(all, parent.KeySet());
            return all;
        }


        public virtual int Size() {
            return (KeySet()).Count;
        }


        public virtual System.Collections.Generic.IDictionary<string , object> ToMap() {
            if (parent == null) {
                return new System.Collections.Generic.Dictionary<string , object>(@base);
            }
            System.Collections.Generic.IDictionary<string , object> r = new System.Collections.Generic.Dictionary<string , object>(parent.ToMap());
            Net.Vpc.Upa.FwkConvertUtils.PutAllMap<string,object>(r,@base);
            return r;
        }


        public virtual void AddPropertyChangeListener(string key, Net.Vpc.Upa.PropertyChangeListener listener) {
            propertyChangeSupport.AddPropertyChangeListener(key, listener);
        }


        public virtual void RemovePropertyChangeListener(string key, Net.Vpc.Upa.PropertyChangeListener listener) {
            propertyChangeSupport.RemovePropertyChangeListener(key, listener);
        }


        public virtual void AddPropertyChangeListener(Net.Vpc.Upa.PropertyChangeListener listener) {
            propertyChangeSupport.AddPropertyChangeListener(listener);
        }


        public virtual void RemovePropertyChangeListener(Net.Vpc.Upa.PropertyChangeListener listener) {
            propertyChangeSupport.RemovePropertyChangeListener(listener);
        }


        public override string ToString() {
            return ToMap().ToString();
        }
    }
}
