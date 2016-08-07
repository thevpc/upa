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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/27/12 12:16 AM
     */
    public class RecordBeanType : Net.Vpc.Upa.BeanType {

        private System.Collections.Generic.ISet<string> propertyNames;

        private Net.Vpc.Upa.Entity entity;

        public RecordBeanType(Net.Vpc.Upa.Entity entity) {
            this.entity = entity;
        }


        public virtual System.Type GetPlatformType() {
            return typeof(Net.Vpc.Upa.Record);
        }

        public virtual Net.Vpc.Upa.Entity GetEntity() {
            return entity;
        }

        public virtual object NewInstance() {
            return new Net.Vpc.Upa.Impl.DefaultRecord();
        }

        public virtual bool ResetToDefaultValue(object instance, string field) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Record r = (Net.Vpc.Upa.Record) instance;
            if (r.IsSet(field)) {
                r.Remove(field);
                return true;
            }
            return false;
        }

        public virtual bool IsDefaultValue(object o, string field) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Record r = (Net.Vpc.Upa.Record) o;
            return !r.IsSet(field);
        }

        public virtual System.Collections.Generic.ISet<string> GetPropertyNames() {
            if (propertyNames == null) {
                System.Collections.Generic.HashSet<string> t = new System.Collections.Generic.HashSet<string>();
                foreach (Net.Vpc.Upa.Field f in entity.GetFields()) {
                    t.Add(f.GetName());
                }
                propertyNames = t;
            }
            return new System.Collections.Generic.HashSet<string>(propertyNames);
        }

        public virtual System.Collections.Generic.ISet<string> KeySet(object o, bool? includeDefaults) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.HashSet<string> set = new System.Collections.Generic.HashSet<string>();
            if (includeDefaults == null) {
                Net.Vpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(set, GetPropertyNames());
            } else {
                foreach (string k in GetPropertyNames()) {
                    if (includeDefaults == IsDefaultValue(o, k)) {
                        set.Add(k);
                    }
                }
            }
            return set;
        }

        public virtual System.Collections.Generic.IDictionary<string , object> ToMap(object o, bool? includeDefaults) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Record r = (Net.Vpc.Upa.Record) o;
            System.Collections.Generic.Dictionary<string , object> map = new System.Collections.Generic.Dictionary<string , object>();
            if (includeDefaults == null) {
                foreach (string k in GetPropertyNames()) {
                    map[k]=r.GetObject<T>(k);
                }
            } else {
                foreach (string k in GetPropertyNames()) {
                    if (includeDefaults == IsDefaultValue(o, k)) {
                        map[k]=r.GetObject<T>(k);
                    }
                }
            }
            return map;
        }

        public virtual object GetProperty(object o, string field) {
            Net.Vpc.Upa.Record r = (Net.Vpc.Upa.Record) o;
            return r.GetObject<T>(field);
        }

        public virtual bool SetProperty(object o, string property, object @value) {
            Net.Vpc.Upa.Record r = (Net.Vpc.Upa.Record) o;
            r.SetObject(property, o);
            return true;
        }


        public virtual bool ContainsProperty(string property) {
            return entity.ContainsField(property);
        }


        public virtual void Inject(object instance, string property, object @value) {
            Net.Vpc.Upa.Record r = (Net.Vpc.Upa.Record) instance;
            if (entity.Contains(property)) {
                r.SetObject(property, @value);
            }
        }


        public virtual System.Reflection.MethodInfo GetMethod(System.Type type, string name, System.Type ret, params System.Type [] args) {
            return null;
        }

        public virtual System.Reflection.FieldInfo FindField(string name, Net.Vpc.Upa.Filters.ObjectFilter<System.Reflection.FieldInfo> filter) {
            return null;
        }

        public virtual System.Collections.Generic.ISet<string> GetPropertyNames(object o, bool? includeDefaults) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.HashSet<string> set = new System.Collections.Generic.HashSet<string>();
            if (includeDefaults == null) {
                Net.Vpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(set, GetPropertyNames());
            } else {
                foreach (string k in GetPropertyNames()) {
                    if (includeDefaults == IsDefaultValue(o, k)) {
                        set.Add(k);
                    }
                }
            }
            return set;
        }
    }
}
