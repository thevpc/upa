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
    public class EntityBeanAdapter {

        private System.Type cls;

        private System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.Impl.Util.EntityBeanAttribute> fields = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Impl.Util.EntityBeanAttribute>();

        private Net.Vpc.Upa.Entity entity;

        public EntityBeanAdapter(System.Type cls, Net.Vpc.Upa.Entity entity) {
            this.cls = cls;
            this.entity = entity;
            try {
                //cls.GetConstructor().SetAccessible(true);
            } catch (System.Exception e) {
                throw new System.ArgumentException ("Unable to resolve default constructor for type " + cls + " (entity " + entity.GetName() + ")", e);
            }
        }

        public virtual Net.Vpc.Upa.Entity GetEntity() {
            return entity;
        }

        public virtual object NewInstance() {
            try {
                return System.Activator.CreateInstance(cls);
            } catch (System.Exception e) {
                System.Exception c = (e).InnerException;
                if (c is System.Exception) {
                    throw (System.Exception) c;
                }
                throw new System.Exception("RuntimeException", c);
            }
        }

        public virtual Net.Vpc.Upa.Impl.Util.EntityBeanAttribute GetAttrAdapter(string field) {
            Net.Vpc.Upa.Impl.Util.EntityBeanAttribute r = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.Impl.Util.EntityBeanAttribute>(fields,field);
            if (r != null) {
                return r;
            }
            Net.Vpc.Upa.Field f = entity.GetField(field);
            Net.Vpc.Upa.PropertyAccessType propertyAccessType = f.GetPropertyAccessType();
            if (propertyAccessType == null) {
                propertyAccessType = Net.Vpc.Upa.PropertyAccessType.PROPERTY;
            }
            if (propertyAccessType == Net.Vpc.Upa.PropertyAccessType.FIELD) {
                System.Reflection.FieldInfo ff = Net.Vpc.Upa.Impl.Util.PlatformUtils.FindField(cls, f.GetName(), Net.Vpc.Upa.Impl.Util.BeanFieldFilter.INSTANCE);
                if (ff != null) {
                    r = new Net.Vpc.Upa.Impl.Util.EntityBeanFieldAttribute(this, ff, cls);
                    fields[field]=r;
                }
            } else {
                Net.Vpc.Upa.Impl.Util.EntityBeanGetterSetterAttribute a = new Net.Vpc.Upa.Impl.Util.EntityBeanGetterSetterAttribute(this, field, f.GetDataType().GetPlatformType(), cls);
                if (a.IsValid()) {
                    r = a;
                    fields[field]=r;
                }
            }
            return r;
        }

        public virtual bool ResetToDefaultValue(object o, string field) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.Util.EntityBeanAttribute attrAdapter = GetAttrAdapter(field);
            if (attrAdapter != null) {
                attrAdapter.SetValue(o, attrAdapter.GetDefaultValue());
                return true;
            } else {
                return false;
            }
        }

        public virtual bool IsDefaultValue(object o, string field) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.Util.EntityBeanAttribute attrAdapter = GetAttrAdapter(field);
            return attrAdapter.IsDefaultValue(o);
        }

        public virtual System.Reflection.MethodInfo GetMethod(System.Type type, string name, System.Type ret, params System.Type [] args) {
            try {
                System.Reflection.MethodInfo method = type.GetMethod(name, args);
                if (ret == null || (method).ReturnType.Equals(ret)) {
                    return method;
                }
            } catch (System.Exception ignored) {
            }
            System.Type s = (type).BaseType;
            if (s != null) {
                return GetMethod(s, name, ret, args);
            }
            return null;
        }

        public virtual System.Collections.Generic.IList<string> GetFieldNames() {
            System.Collections.Generic.IList<string> t = new System.Collections.Generic.List<string>();
            foreach (Net.Vpc.Upa.Field f in entity.GetFields()) {
                if (GetAttrAdapter(f.GetName()) != null) {
                    t.Add(f.GetName());
                }
            }
            return t;
        }

        public virtual System.Collections.Generic.ISet<string> KeySet(object o, bool? includeDefaults) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.HashSet<string> set = new System.Collections.Generic.HashSet<string>();
            if (includeDefaults == null) {
                Net.Vpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(set, GetFieldNames());
            } else {
                foreach (string k in GetFieldNames()) {
                    Net.Vpc.Upa.Impl.Util.EntityBeanAttribute e = GetAttrAdapter(k);
                    if ((includeDefaults).Value == e.IsDefaultValue(o)) {
                        set.Add(k);
                    }
                }
            }
            return set;
        }

        public virtual System.Collections.Generic.IDictionary<string , object> ToMap(object o, bool? includeDefaults) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.Dictionary<string , object> set = new System.Collections.Generic.Dictionary<string , object>();
            if (includeDefaults == null) {
                foreach (string k in GetFieldNames()) {
                    Net.Vpc.Upa.Impl.Util.EntityBeanAttribute e = GetAttrAdapter(k);
                    set[k]=e.GetValue(o);
                }
            } else {
                foreach (string k in GetFieldNames()) {
                    Net.Vpc.Upa.Impl.Util.EntityBeanAttribute e = GetAttrAdapter(k);
                    if ((includeDefaults).Value == e.IsDefaultValue(o)) {
                        set[k]=e.GetValue(o);
                    }
                }
            }
            return set;
        }

        public virtual  R GetProperty<R>(object o, string field) {
            Net.Vpc.Upa.Impl.Util.EntityBeanAttribute attrAdapter = GetAttrAdapter(field);
            if (attrAdapter != null) {
                return (R) attrAdapter.GetValue(o);
            }
            return default(R);
        }

        public virtual  bool SetProperty<R>(object o, string field, R @value) {
            Net.Vpc.Upa.Impl.Util.EntityBeanAttribute attrAdapter = GetAttrAdapter(field);
            if (attrAdapter != null) {
                attrAdapter.SetValue(o, @value);
                return true;
            }
            return false;
        }

        public virtual  R GetPropertyDefaultValue<R>(string field) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.Util.EntityBeanAttribute attrAdapter = GetAttrAdapter(field);
            return (R) attrAdapter.GetDefaultValue();
        }

        public static bool IsTypeDefaultValue(System.Type c, object v) {
            object t = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,object>(Net.Vpc.Upa.Impl.Util.PlatformUtils.DEFAULT_VALUES_BY_TYPE,c);
            if (t == null) {
                return v == null;
            }
            return t.Equals(v);
        }

        public static string GetterName(System.Reflection.FieldInfo field) {
            return Net.Vpc.Upa.Impl.Util.PlatformUtils.GetterName((field).Name, field.GetType());
        }

        public static string SetterName(System.Reflection.FieldInfo field) {
            return Net.Vpc.Upa.Impl.Util.PlatformUtils.SetterName((field).Name);
        }

        internal virtual System.Type GetCls() {
            return cls;
        }

        internal virtual System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.Impl.Util.EntityBeanAttribute> GetFields() {
            return fields;
        }
    }
}
