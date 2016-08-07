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
    public class BeanAdapterRecord : Net.Vpc.Upa.Impl.AbstractRecord {

        private bool ignoreUnspecified;

        private object userObject;

        private System.Collections.Generic.IDictionary<string , object> extra;

        private string entityName;

        private Net.Vpc.Upa.BeanType nfo;

        private Net.Vpc.Upa.PropertyChangeSupport propertyChangeSupport;

        public BeanAdapterRecord(object userObject, string entityName, Net.Vpc.Upa.BeanType nfo, bool ignoreUnspecified) {
            this.userObject = userObject;
            this.entityName = entityName;
            this.nfo = nfo;
            this.ignoreUnspecified = ignoreUnspecified;
            propertyChangeSupport = new Net.Vpc.Upa.PropertyChangeSupport(this);
        }

        public virtual object UserObject() {
            return this.userObject;
        }


        public override  T GetObject<T>(string key) {
            T y = (T) nfo.GetProperty(userObject, key);
            //in C# could not compare y == default(y)
            //so cast y to Object to do so
            if (((object) y) == null && !nfo.ContainsProperty(key) && extra != null) {
                y = (T) Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(extra,key);
            }
            return y;
        }


        public override void SetObject(string key, object @value) {
            SetUpdated(key);
            object oldValue = nfo.GetProperty(userObject, key);
            if (@value is Net.Vpc.Upa.Expressions.Expression || !nfo.SetProperty(userObject, key, @value)) {
                // handle unstructured fields (non defined in the bean class)
                if (extra == null) {
                    extra = new System.Collections.Generic.Dictionary<string , object>();
                }
                extra[key]=@value;
            }
            FireChange(key, oldValue, @value);
        }


        public override  T GetSingleResult<T>() {
            foreach (object o in (ToMap()).Values) {
                return (T) o;
            }
            return default(T);
        }


        public override bool IsSet(string key) {
            if (nfo.ContainsProperty(key)) {
                if (!ignoreUnspecified || !nfo.IsDefaultValue(userObject, key)) {
                    return true;
                }
            }
            if (extra != null) {
                if (extra.ContainsKey(key)) {
                    return true;
                }
            }
            return false;
        }


        public override void Remove(string key) {
            nfo.ResetToDefaultValue(userObject, key);
            if (extra != null) {
                extra.Remove(key);
            }
        }


        public override System.Collections.Generic.ISet<string> KeySet() {
            bool? includeDefaults = null;
            if (ignoreUnspecified) {
                includeDefaults = false;
            }
            System.Collections.Generic.ISet<string> keySet = nfo.GetPropertyNames(userObject, includeDefaults);
            if (extra != null && (extra).Count > 0) {
                Net.Vpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(keySet, new System.Collections.Generic.HashSet<string>(extra.Keys));
            }
            return keySet;
        }


        public override int Size() {
            return (KeySet()).Count;
        }


        public override System.Collections.Generic.IDictionary<string , object> ToMap() {
            bool? includeDefaults = null;
            if (ignoreUnspecified) {
                includeDefaults = false;
            }
            System.Collections.Generic.IDictionary<string , object> m = nfo.ToMap(userObject, includeDefaults);
            if (extra != null && (extra).Count > 0) {
                Net.Vpc.Upa.Impl.FwkConvertUtils.PutAllMap<string,object>(m,extra);
            }
            return m;
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

        protected internal virtual void FireChange(string property, object oldVal, object newVal) {
            propertyChangeSupport.FirePropertyChange(property, oldVal, newVal);
        }


        public override string ToString() {
            return entityName + ToMap().ToString();
        }
    }
}
