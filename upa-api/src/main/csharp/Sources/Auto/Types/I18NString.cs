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
namespace Net.Vpc.Upa.Types
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/23/12 2:30 AM
     */
    public class I18NString {

        private System.Collections.Generic.IList<string> keys;

        private string defaultValue;

        public virtual string GetDefaultValue() {
            return defaultValue;
        }

        public virtual Net.Vpc.Upa.Types.I18NString SetDefaultValue(string defaultValue) {
            Net.Vpc.Upa.Types.I18NString n = new Net.Vpc.Upa.Types.I18NString(keys);
            n.defaultValue = defaultValue;
            return n;
        }

        public I18NString(params string [] keys)  : this(new System.Collections.Generic.List<string>(keys)){

        }

        public I18NString(System.Collections.Generic.IList<string> keys) {
            if (keys == null) {
                throw new System.ArgumentException ();
            }
            this.keys = new System.Collections.Generic.List<string>(keys);
        }

        public virtual string GetKey(int index) {
            return keys[index];
        }

        public virtual System.Collections.Generic.IList<string> GetKeys() {
            return keys;
        }

        public virtual Net.Vpc.Upa.Types.I18NString Append(Net.Vpc.Upa.Types.I18NString path) {
            if (path == null) {
                throw new System.ArgumentException ();
            }
            System.Collections.Generic.HashSet<string> a = new System.Collections.Generic.HashSet<string>();
            foreach (string key1 in keys) {
                foreach (string key2 in path.keys) {
                    string s = key1.Length==0 ? key2 : key2.Length==0 ? key1 : (key1 + "." + key2);
                    if (!a.Contains(s)) {
                        a.Add(s);
                    }
                }
            }
            return new Net.Vpc.Upa.Types.I18NString(a.ToArray());
        }

        public virtual Net.Vpc.Upa.Types.I18NString Append(string path) {
            if (path == null || path.Length==0) {
                throw new System.ArgumentException ();
            }
            System.Collections.Generic.List<string> a = new System.Collections.Generic.List<string>();
            foreach (string key in keys) {
                a.Add(key.Length==0 ? path : key + "." + path);
            }
            return new Net.Vpc.Upa.Types.I18NString(a);
        }

        public virtual Net.Vpc.Upa.Types.I18NString Union(Net.Vpc.Upa.Types.I18NString other) {
            System.Collections.Generic.List<string> a = new System.Collections.Generic.List<string>();
            Net.Vpc.Upa.FwkConvertUtils.CollectionAddRange(a, this.keys);
            Net.Vpc.Upa.FwkConvertUtils.CollectionAddRange(a, other.keys);
            Net.Vpc.Upa.Types.I18NString b = new Net.Vpc.Upa.Types.I18NString(a);
            string t = defaultValue;
            if (t == null) {
                t = other.defaultValue;
            }
            b.defaultValue = t;
            return b;
        }

        public virtual Net.Vpc.Upa.Types.I18NString Union(string other) {
            if (other == null || other.Length==0) {
                throw new System.ArgumentException ();
            }
            System.Collections.Generic.List<string> a = new System.Collections.Generic.List<string>();
            Net.Vpc.Upa.FwkConvertUtils.CollectionAddRange(a, this.keys);
            a.Add(other);
            return new Net.Vpc.Upa.Types.I18NString(a);
        }


        public override string ToString() {
            System.Text.StringBuilder b = new System.Text.StringBuilder();
            if (defaultValue != null) {
                b.Append(defaultValue);
                if (!(keys.Count==0)) {
                    b.Append(":");
                }
            }
            foreach (string key in keys) {
                if ((b).Length > 0) {
                    b.Append("|");
                }
                b.Append(key);
            }
            return b.ToString();
        }


        public override bool Equals(object o) {
            if (this == o) {
                return true;
            }
            if (o == null || GetType() != o.GetType()) {
                return false;
            }
            Net.Vpc.Upa.Types.I18NString that = (Net.Vpc.Upa.Types.I18NString) o;
            if (defaultValue != null ? !defaultValue.Equals(that.defaultValue) : that.defaultValue != null) {
                return false;
            }
            if (keys != null ? !keys.Equals(that.keys) : that.keys != null) {
                return false;
            }
            return true;
        }


        public override int GetHashCode() {
            int hash = 3;
            hash = 71 * hash + (this.keys != null ? this.keys.GetHashCode() : 0);
            hash = 71 * hash + (this.defaultValue != null ? this.defaultValue.GetHashCode() : 0);
            return hash;
        }
    }
}
