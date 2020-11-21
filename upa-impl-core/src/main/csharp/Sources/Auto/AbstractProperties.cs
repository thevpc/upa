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
     * AbstractParameters is an abstract implementation of the Parameters interface
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/25/12 1:31 AM
     */
    public abstract class AbstractProperties : Net.TheVpc.Upa.Properties {


        public virtual void SetAll(System.Collections.Generic.IDictionary<string , object> other, params string [] keys) {
            if (keys.Length == 0) {
                foreach (System.Collections.Generic.KeyValuePair<string , object> entry in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,object>>(other)) {
                    SetObject((entry).Key, (entry).Value);
                }
            } else {
                System.Collections.Generic.HashSet<string> accepted = new System.Collections.Generic.HashSet<string>(new System.Collections.Generic.List<string>(keys));
                foreach (string s in accepted) {
                    if (other.ContainsKey(s)) {
                        SetObject(s, Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(other,s));
                    }
                }
            }
        }


        public virtual int GetInt(string key) {
            return System.Convert.ToInt32(((object) GetObject<T>(key)));
        }


        public virtual int GetInt(string key, int defaultValue) {
            return System.Convert.ToInt32(((object) GetObject<int>(key, defaultValue)));
        }


        public virtual void SetInt(string key, int @value) {
            SetObject(key, @value);
        }


        public virtual int GetSingleInt() {
            return GetSingleObject<T>();
        }


        public virtual long GetLong(string key) {
            return System.Convert.ToInt32(((object) GetObject<T>(key)));
        }


        public virtual long GetLong(string key, long defaultValue) {
            object @object = GetObject<long>(key, defaultValue);
            return System.Convert.ToInt32(@object);
        }


        public virtual void SetLong(string key, long @value) {
            SetObject(key, @value);
        }


        public virtual long GetSingleLong() {
            return GetSingleObject<T>();
        }


        public virtual double GetDouble(string key) {
            return System.Convert.ToDouble(((object) GetObject<T>(key)));
        }


        public virtual double GetDouble(string key, double defaultValue) {
            return System.Convert.ToDouble(((object) GetObject<double>(key, defaultValue)));
        }


        public virtual void SetDouble(string key, double @value) {
            SetObject(key, @value);
        }


        public virtual double GetSingleDouble() {
            return System.Convert.ToDouble(((object) GetSingleObject<T>()));
        }


        public virtual float GetFloat(string key) {
            return System.Convert.ToSingle(((object) GetObject<T>(key)));
        }


        public virtual float GetFloat(string key, float defaultValue) {
            return System.Convert.ToSingle(((object) GetObject<float>(key, defaultValue)));
        }


        public virtual void SetFloat(string key, float @value) {
            SetObject(key, @value);
        }


        public virtual float GetSingleFloat() {
            return System.Convert.ToSingle(((object) GetSingleObject<T>()));
        }










        public virtual System.Numerics.BigInteger? GetBigInteger(string key) {
            return GetObject<T>(key);
        }


        public virtual System.Numerics.BigInteger? GetBigInteger(string key, System.Numerics.BigInteger? defaultValue) {
            return GetObject<System.Numerics.BigInteger?>(key, defaultValue);
        }


        public virtual void SetBigInteger(string key, System.Numerics.BigInteger? @value) {
            SetObject(key, @value);
        }


        public virtual System.Numerics.BigInteger? GetSingleBigInteger() {
            return GetSingleObject<T>();
        }










        public virtual bool GetBoolean(string key) {
            return GetObject<T>(key);
        }


        public virtual bool GetBoolean(string key, bool defaultValue) {
            return GetObject<bool>(key, defaultValue);
        }


        public virtual void SetBoolean(string key, bool @value) {
            SetObject(key, @value);
        }


        public virtual bool GetSingleBoolean() {
            return GetSingleObject<T>();
        }


        public virtual string GetString(string key) {
            return ((string) GetObject<T>(key));
        }


        public virtual string GetString(string key, string defaultValue) {
            return GetObject<string>(key, defaultValue);
        }


        public virtual void SetString(string key, string @value) {
            SetObject(key, @value);
        }


        public virtual string GetSingleString() {
            return GetSingleObject<T>();
        }


        public virtual Net.TheVpc.Upa.Types.Temporal GetDate(string key) {
            return GetObject<T>(key);
        }


        public virtual Net.TheVpc.Upa.Types.Temporal GetDate(string key, Net.TheVpc.Upa.Types.Temporal defaultValue) {
            return GetObject<Net.TheVpc.Upa.Types.Temporal>(key, defaultValue);
        }


        public virtual void SetDate(string key, Net.TheVpc.Upa.Types.Temporal @value) {
            SetObject(key, @value);
        }


        public virtual Net.TheVpc.Upa.Types.Temporal GetSingleDate() {
            return GetSingleObject<T>();
        }


        public virtual void SetAll(Net.TheVpc.Upa.Properties other, params string [] keys) {
            SetAll(other.ToMap(), keys);
        }

        public virtual object Eval(string key) {
            if (key == null || !(key is string)) {
                return key;
            }
            System.Collections.Generic.IList<string> vars = Net.TheVpc.Upa.Impl.Util.StringUtils.ParseVarsList(key);
            switch((vars).Count) {
                case 0:
                    {
                        return key;
                    }
                case 1:
                    {
                        string v = vars[0];
                        object ov = GetObject<T>(v);
                        if (ov != null || !(ov is string)) {
                            return ov;
                        }
                        return Eval((string) v);
                    }
                default:
                    {
                        string s = key;
                        System.Collections.Generic.ISet<string> vars2 = new System.Collections.Generic.HashSet<string>(vars);
                        foreach (string v in vars2) {
                            object ov = GetObject<T>(v);
                            if (ov == null) {
                                ov = "";
                            } else if (!(ov is string)) {
                                ov = System.Convert.ToString(ov);
                            } else {
                                ov = Eval((string) v);
                            }
                            s = System.Text.RegularExpressions.Regex.Replace(s, "\\$\\{" + v + "\\}", System.Convert.ToString(ov));
                        }
                        return s;
                    }
            }
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract void AddPropertyChangeListener(string arg1, Net.TheVpc.Upa.PropertyChangeListener arg2);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract System.Collections.Generic.IDictionary<string , object> ToMap();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract T GetObject<T>(string arg1, T arg2);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract void AddPropertyChangeListener(Net.TheVpc.Upa.PropertyChangeListener arg1);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract void SetObject(string arg1, object arg2);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract void RemovePropertyChangeListener(Net.TheVpc.Upa.PropertyChangeListener arg1);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract void RemovePropertyChangeListener(string arg1, Net.TheVpc.Upa.PropertyChangeListener arg2);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract T GetObject<T>(string arg1);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract bool ContainsKey(string arg1);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract T GetSingleObject<T>();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract System.Collections.Generic.ISet<string> KeySet();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract void Remove(string arg1);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract bool IsSet(string arg1);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract int Size();
    }
}
