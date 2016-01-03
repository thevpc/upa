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

        private Net.Vpc.Upa.Impl.Util.EntityBeanAdapter nfo;

        private Net.Vpc.Upa.PropertyChangeSupport propertyChangeSupport;

        public BeanAdapterRecord(object userObject, Net.Vpc.Upa.Impl.Util.EntityBeanAdapter nfo, bool ignoreUnspecified) {
            this.userObject = userObject;
            this.nfo = nfo;
            this.ignoreUnspecified = ignoreUnspecified;
            propertyChangeSupport = new Net.Vpc.Upa.PropertyChangeSupport(this);
        }

        public virtual object UserObject() {
            return this.userObject;
        }


        public override  T GetObject<T>(string key) {
            T y = (T) nfo.GetProperty<T>(userObject, key);
            //in C# could not compare y == default(y)
            //so cast y to Object to do so
            if (((object) y) == null && nfo.GetAttrAdapter(key) == null && extra != null) {
                y = (T) Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(extra,key);
            }
            return y;
        }


        public override void SetObject(string key, object @value) {
            SetUpdated(key);
            object oldValue = nfo.GetProperty<object>(userObject, key);
            if (@value is Net.Vpc.Upa.Expressions.Expression || !nfo.SetProperty<object>(userObject, key, @value)) {
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
            Net.Vpc.Upa.Impl.Util.EntityBeanAttribute f = nfo.GetAttrAdapter(key);
            if (f != null) {
                if (!ignoreUnspecified || !f.IsDefaultValue(userObject)) {
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
            System.Collections.Generic.HashSet<string> s = new System.Collections.Generic.HashSet<string>(nfo.KeySet(userObject, includeDefaults));
            if (extra != null) {
                Net.Vpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(s, new System.Collections.Generic.HashSet<string>(extra.Keys));
            }
            return s;
        }


        public override int Size() {
            return (KeySet()).Count;
        }


        public override System.Collections.Generic.IDictionary<string , object> ToMap() {
            bool? includeDefaults = null;
            if (ignoreUnspecified) {
                includeDefaults = false;
            }
            System.Collections.Generic.Dictionary<string , object> map = new System.Collections.Generic.Dictionary<string , object>(nfo.ToMap(userObject, includeDefaults));
            if (extra != null) {
                Net.Vpc.Upa.Impl.FwkConvertUtils.PutAllMap<string,object>(map,extra);
            }
            return map;
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
            return nfo.GetEntity().GetName() + ToMap().ToString();
        }
    }
}
