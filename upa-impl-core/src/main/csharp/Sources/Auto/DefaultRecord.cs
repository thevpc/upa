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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/23/12 1:26 PM
     */
    public class DefaultRecord : Net.TheVpc.Upa.Impl.AbstractRecord {

        private System.Collections.Generic.IDictionary<string , object> @base = new System.Collections.Generic.Dictionary<string , object>();

        private Net.TheVpc.Upa.PropertyChangeSupport propertyChangeSupport;

        public DefaultRecord() {
            propertyChangeSupport = new Net.TheVpc.Upa.PropertyChangeSupport(this);
        }


        public override  T GetObject<T>(string key) {
            return (T) Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(@base,key);
        }


        public override void SetObject(string key, object @value) {
            SetUpdated(key);
            object oldValue = @base[key]=@value;
            FireChange(key, oldValue, @value);
        }


        public override  T GetSingleResult<T>() {
            foreach (object o in (@base).Values) {
                return (T) o;
            }
            return default(T);
        }


        public override bool IsSet(string key) {
            return @base.ContainsKey(key);
        }


        public override void Remove(string key) {
            @base.Remove(key);
        }


        public override bool RetainAll(System.Collections.Generic.ISet<string> keys) {
            bool modified = false;
            foreach (string s in new System.Collections.Generic.HashSet<string>(new System.Collections.Generic.HashSet<string>(@base.Keys))) {
                if (!keys.Contains(s)) {
                    @base.Remove(s);
                    modified = true;
                }
            }
            return modified;
        }


        public override System.Collections.Generic.ISet<string> KeySet() {
            return new System.Collections.Generic.HashSet<string>(@base.Keys);
        }


        public override int Size() {
            return (@base).Count;
        }


        public override System.Collections.Generic.IDictionary<string , object> ToMap() {
            return new System.Collections.Generic.Dictionary<string , object>(@base);
        }


        public override void AddPropertyChangeListener(string key, Net.TheVpc.Upa.PropertyChangeListener listener) {
            propertyChangeSupport.AddPropertyChangeListener(key, listener);
        }


        public override void RemovePropertyChangeListener(string key, Net.TheVpc.Upa.PropertyChangeListener listener) {
            propertyChangeSupport.RemovePropertyChangeListener(key, listener);
        }


        public override void AddPropertyChangeListener(Net.TheVpc.Upa.PropertyChangeListener listener) {
            propertyChangeSupport.AddPropertyChangeListener(listener);
        }


        public override void RemovePropertyChangeListener(Net.TheVpc.Upa.PropertyChangeListener listener) {
            propertyChangeSupport.RemovePropertyChangeListener(listener);
        }

        protected internal virtual void FireChange(string property, object oldVal, object newVal) {
            propertyChangeSupport.FirePropertyChange(property, oldVal, newVal);
        }
    }
}
