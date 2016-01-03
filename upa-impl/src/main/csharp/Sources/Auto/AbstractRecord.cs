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
namespace Net.Vpc.Upa.Impl
{


    /**
     * AbstractRecord is an abstract implementation of the Record interface
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/25/12 1:31 AM
     */
    public abstract class AbstractRecord : Net.Vpc.Upa.Record {

        protected internal System.Collections.Generic.HashSet<string> updated;

        protected internal AbstractRecord() {
        }

        /**
             * reset all updated fields
             */
        public virtual void ResetUpdatedFields() {
            updated = null;
        }

        /**
             * return all updated fields
             * @return
             */
        public virtual string[] GetUpdatedFields() {
            return updated == null ? ((string[])(new string[0])) : updated.ToArray();
        }

        protected internal virtual void SetUpdated(string field) {
            if (updated == null) {
                updated = new System.Collections.Generic.HashSet<string>();
            }
            updated.Add(field);
        }

        /**
             * {@inheritDoc}
             */

        public virtual void SetAll(System.Collections.Generic.IDictionary<string , object> other, params string [] keys) {
            if (keys.Length == 0) {
                foreach (System.Collections.Generic.KeyValuePair<string , object> entry in other) {
                    SetObject((entry).Key, (entry).Value);
                }
            } else {
                System.Collections.Generic.HashSet<string> accepted = new System.Collections.Generic.HashSet<string>(new System.Collections.Generic.List<string>(keys));
                foreach (string s in accepted) {
                    if (other.ContainsKey(s)) {
                        SetObject(s, Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(other,s));
                    }
                }
            }
        }

        /**
             * {@inheritDoc}
             */

        public virtual  T GetObject<T>(string key, T @value) {
            if (IsSet(key)) {
                return (T) GetObject<T>(key);
            } else {
                return @value;
            }
        }

        /**
             * {@inheritDoc}
             */

        public virtual int GetInt(string key) {
            return System.Convert.ToInt32(((object) GetObject<object>(key)));
        }

        /**
             * {@inheritDoc}
             */

        public virtual int GetInt(string key, int defaultValue) {
            object @object = GetObject<int>(key, defaultValue);
            return System.Convert.ToInt32(@object);
        }

        /**
             * {@inheritDoc}
             */

        public virtual void SetInt(string key, int @value) {
            SetObject(key, @value);
        }

        /**
             * {@inheritDoc}
             */

        public virtual int GetInt() {
            return System.Convert.ToInt32(GetNumber());
        }

        /**
             * {@inheritDoc}
             */

        public virtual long GetLong(string key) {
            return System.Convert.ToInt32(((object) GetObject<object>(key)));
        }

        /**
             * {@inheritDoc}
             */

        public virtual long GetLong(string key, long defaultValue) {
            object @object = GetObject<long>(key, defaultValue);
            return System.Convert.ToInt32(@object);
        }

        /**
             * {@inheritDoc}
             */

        public virtual void SetLong(string key, long @value) {
            SetObject(key, @value);
        }

        /**
             * {@inheritDoc}
             */

        public virtual long GetLong() {
            return System.Convert.ToInt32(GetNumber());
        }

        /**
             * {@inheritDoc}
             */

        public virtual double GetDouble(string key) {
            return System.Convert.ToDouble(((object) GetObject<object>(key)));
        }

        /**
             * {@inheritDoc}
             */

        public virtual double GetDouble(string key, double defaultValue) {
            object @object = GetObject<double>(key, defaultValue);
            return System.Convert.ToDouble(@object);
        }

        /**
             * {@inheritDoc}
             */

        public virtual void SetDouble(string key, double @value) {
            SetObject(key, @value);
        }

        /**
             * {@inheritDoc}
             */

        public virtual double GetDouble() {
            return System.Convert.ToDouble(GetNumber());
        }

        /**
             * {@inheritDoc}
             */

        public virtual float GetFloat(string key) {
            return System.Convert.ToSingle(((object) GetObject<object>(key)));
        }

        /**
             * {@inheritDoc}
             */

        public virtual float GetFloat(string key, float defaultValue) {
            object @object = GetObject<float>(key, defaultValue);
            return System.Convert.ToSingle(@object);
        }

        /**
             * {@inheritDoc}
             */

        public virtual void SetFloat(string key, float @value) {
            SetObject(key, @value);
        }

        /**
             * {@inheritDoc}
             */

        public virtual float GetFloat() {
            return System.Convert.ToSingle(GetNumber());
        }









        /**
             * {@inheritDoc}
             */

        public virtual System.Numerics.BigInteger? GetBigInteger(string key) {
            return GetObject<System.Numerics.BigInteger?>(key);
        }

        /**
             * {@inheritDoc}
             */

        public virtual System.Numerics.BigInteger? GetBigInteger(string key, System.Numerics.BigInteger? defaultValue) {
            return GetObject<System.Numerics.BigInteger?>(key, defaultValue);
        }

        /**
             * {@inheritDoc}
             */

        public virtual void SetBigInteger(string key, System.Numerics.BigInteger? @value) {
            SetObject(key, @value);
        }

        /**
             * {@inheritDoc}
             */

        public virtual System.Numerics.BigInteger? GetBigInteger() {
            object n = GetNumber();
            return (n is System.Numerics.BigInteger?) ? (System.Numerics.BigInteger?) n : Net.Vpc.Upa.Impl.FwkConvertUtils.CreateBigInteger(n.ToString());
        }

        /**
             * {@inheritDoc}
             */

        public virtual object GetNumber(string key) {
            return ((object) GetObject<object>(key));
        }

        /**
             * {@inheritDoc}
             */

        public virtual object GetNumber(string key, object defaultValue) {
            object @object = GetObject<object>(key, defaultValue);
            return System.Convert.ToInt32(@object);
        }

        /**
             * {@inheritDoc}
             */

        public virtual void SetNumber(string key, object @value) {
            SetObject(key, @value);
        }

        /**
             * {@inheritDoc}
             */

        public virtual object GetNumber() {
            return GetSingleResult<object>();
        }

        /**
             * {@inheritDoc}
             */

        public virtual bool GetBoolean(string key) {
            return GetObject<bool>(key);
        }

        /**
             * {@inheritDoc}
             */

        public virtual bool GetBoolean(string key, bool defaultValue) {
            return GetObject<bool>(key, defaultValue);
        }

        /**
             * {@inheritDoc}
             */

        public virtual void SetBoolean(string key, bool @value) {
            SetObject(key, @value);
        }

        /**
             * {@inheritDoc}
             */

        public virtual bool GetBoolean() {
            return GetSingleResult<bool>();
        }

        /**
             * {@inheritDoc}
             */

        public virtual string GetString(string key) {
            return ((string) GetObject<string>(key));
        }

        /**
             * {@inheritDoc}
             */

        public virtual string GetString(string key, string defaultValue) {
            return GetObject<string>(key, defaultValue);
        }

        /**
             * {@inheritDoc}
             */

        public virtual void SetString(string key, string @value) {
            SetObject(key, @value);
        }

        /**
             * {@inheritDoc}
             */

        public virtual string GetString() {
            return GetSingleResult<string>();
        }

        /**
             * {@inheritDoc}
             */

        public virtual Net.Vpc.Upa.Types.Temporal GetDate(string key) {
            return GetObject<Net.Vpc.Upa.Types.Temporal>(key);
        }

        /**
             * {@inheritDoc}
             */

        public virtual Net.Vpc.Upa.Types.Temporal GetDate(string key, Net.Vpc.Upa.Types.Temporal defaultValue) {
            return GetObject<Net.Vpc.Upa.Types.Temporal>(key, defaultValue);
        }

        /**
             * {@inheritDoc}
             */

        public virtual void SetDate(string key, Net.Vpc.Upa.Types.Temporal @value) {
            SetObject(key, @value);
        }

        /**
             * {@inheritDoc}
             */

        public virtual Net.Vpc.Upa.Types.Temporal GetDate() {
            return GetSingleResult<Net.Vpc.Upa.Types.Temporal>();
        }

        /**
             * {@inheritDoc}
             */

        public virtual void SetAll(Net.Vpc.Upa.Record other, params string [] keys) {
            if (other != null) {
                SetAll(other.ToMap(), keys);
            }
        }

        /**
             * {@inheritDoc}
             */

        public virtual bool RetainAll(System.Collections.Generic.ISet<string> keys) {
            bool modified = false;
            System.Collections.Generic.HashSet<string> k = new System.Collections.Generic.HashSet<string>(KeySet());
            Net.Vpc.Upa.Impl.FwkConvertUtils.SetRemoveRange(k, keys);
            foreach (string s in k) {
                modified = true;
                Remove(s);
            }
            return modified;
        }

        /**
             * {@inheritDoc}
             */

        public virtual bool IsEmpty() {
            return Size() == 0;
        }

        /**
             * {@inheritDoc}
             */
        public override bool Equals(object o) {
            if (o == null) {
                return false;
            }
            if (!(o is Net.Vpc.Upa.Record)) {
                return false;
            }
            return ToMap().Equals(((Net.Vpc.Upa.Record) o).ToMap());
        }

        /**
             * {@inheritDoc}
             */

        public override int GetHashCode() {
            return ToMap().GetHashCode();
        }

        /**
             * {@inheritDoc}
             */

        public override string ToString() {
            return ToMap().ToString();
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract void AddPropertyChangeListener(string arg1, Net.Vpc.Upa.PropertyChangeListener arg2);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract System.Collections.Generic.IDictionary<string , object> ToMap();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract T GetSingleResult<T>();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract void AddPropertyChangeListener(Net.Vpc.Upa.PropertyChangeListener arg1);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract void SetObject(string arg1, object arg2);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract void RemovePropertyChangeListener(Net.Vpc.Upa.PropertyChangeListener arg1);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract void RemovePropertyChangeListener(string arg1, Net.Vpc.Upa.PropertyChangeListener arg2);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract T GetObject<T>(string arg1);
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
