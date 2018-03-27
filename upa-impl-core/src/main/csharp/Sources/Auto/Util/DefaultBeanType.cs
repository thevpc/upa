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
namespace Net.Vpc.Upa.Impl.Util
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/27/12 12:16 AM
     */
    public class DefaultBeanType : Net.Vpc.Upa.BeanType {

        private System.Type platformType;

        private System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.Impl.Util.BeanAdapterAttribute> properties = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Impl.Util.BeanAdapterAttribute>();

        private System.Collections.Generic.ISet<string> propertyNames;

        private System.Collections.Generic.IDictionary<Net.Vpc.Upa.Impl.Util.MethodSignature , System.Reflection.MethodInfo> methods = new System.Collections.Generic.Dictionary<Net.Vpc.Upa.Impl.Util.MethodSignature , System.Reflection.MethodInfo>();

        private System.Collections.Generic.IDictionary<string , System.Collections.Generic.IList<System.Reflection.FieldInfo>> fields = new System.Collections.Generic.Dictionary<string , System.Collections.Generic.IList<System.Reflection.FieldInfo>>();

        private bool propertiesLoaded = false;

        public DefaultBeanType(System.Type platformType) {
            this.platformType = platformType;
        }


        public virtual System.Type GetPlatformType() {
            return platformType;
        }

        public virtual object NewInstance() {
            //        try {
            //            if(constructor==null) {
            //                constructor = platformType.getConstructor();
            //                constructor.setAccessible(true);
            //            }
            //        } catch (NoSuchMethodException e) {
            //            throw new IllegalArgumentException(e);
            //        }
            try {
                return System.Activator.CreateInstance(platformType);
            } catch (System.Exception e) {
                System.Exception c = (e).InnerException;
                if (c is System.Exception) {
                    throw (System.Exception) c;
                }
                throw new System.Exception("RuntimeException", c);
            }
        }

        private Net.Vpc.Upa.Impl.Util.BeanAdapterAttribute CreateAttrAdapter(string field) {
            string g1 = GetterName(field, typeof(object));
            string g2 = GetterName(field, typeof(bool));
            string s = SetterName(field);
            System.Type x = platformType;
            System.Reflection.MethodInfo getter = null;
            System.Reflection.MethodInfo setter = null;
            System.Type propertyType = null;
            System.Collections.Generic.Dictionary<System.Type , System.Reflection.MethodInfo> setters = new System.Collections.Generic.Dictionary<System.Type , System.Reflection.MethodInfo>();
            while (x != null) {
                foreach (System.Reflection.MethodInfo m in x.GetMethods(System.Reflection.BindingFlags.Default)) {
                    if (!Net.Vpc.Upa.Impl.Util.PlatformUtils.IsStatic(m)) {
                        string mn = (m).Name;
                        if (getter == null) {
                            if (g1.Equals(mn) || g2.Equals(mn)) {
                                if (Net.Vpc.Upa.Impl.FwkConvertUtils.GetMethodParameterTypes(m).Length == 0 && !typeof(void).Equals((m).ReturnType)) {
                                    getter = m;
                                    System.Type ftype = (getter).ReturnType;
                                    foreach (System.Type key in new System.Collections.Generic.HashSet<System.Type>(new System.Collections.Generic.HashSet<System.Type>(setters.Keys))) {
                                        if (!key.Equals(ftype)) {
                                            setters.Remove(key);
                                        }
                                    }
                                    if (setter == null) {
                                        setter = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,System.Reflection.MethodInfo>(setters,ftype);
                                    }
                                }
                            }
                        }
                        if (setter == null) {
                            if (s.Equals(mn)) {
                                if (Net.Vpc.Upa.Impl.FwkConvertUtils.GetMethodParameterTypes(m).Length == 1) {
                                    System.Type stype = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMethodParameterTypes(m)[0];
                                    if (getter != null) {
                                        System.Type gtype = (getter).ReturnType;
                                        if (gtype.Equals(stype)) {
                                            if (!setters.ContainsKey(stype)) {
                                                setters[stype]=m;
                                            }
                                            if (setter == null) {
                                                setter = m;
                                            }
                                        }
                                    } else {
                                        if (!setters.ContainsKey(stype)) {
                                            setters[stype]=m;
                                        }
                                    }
                                }
                            }
                        }
                        if (getter != null && setter != null) {
                            break;
                        }
                    }
                }
                if (getter != null && setter != null) {
                    break;
                }
                x = (x).BaseType;
            }
            if (getter != null) {
                propertyType = (getter).ReturnType;
            }
            if (getter == null && setter == null && (setters).Count > 0) {
                System.Reflection.MethodInfo[] settersArray = (setters).Values.ToArray();
                setter = settersArray[0];
                if (settersArray.Length > 1) {
                }
            }
            //TODO log?
            if (getter == null && setter != null && propertyType == null) {
                propertyType = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMethodParameterTypes(setter)[0];
            }
            if (getter != null || setter != null) {
                return new Net.Vpc.Upa.Impl.Util.BeanAdapterGetterSetterAttribute(field, propertyType, getter, setter);
            }
            return null;
        }

        /**
             * @param field
             * @return
             */
        public virtual Net.Vpc.Upa.Impl.Util.BeanAdapterAttribute GetAttrAdapter(string field) {
            Net.Vpc.Upa.Impl.Util.BeanAdapterAttribute f = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.Impl.Util.BeanAdapterAttribute>(properties,field);
            if (f == null) {
                f = CreateAttrAdapter(field);
                if (f != null) {
                    if (((Net.Vpc.Upa.Impl.Util.BeanAdapterGetterSetterAttribute) f).GetSetter() == null) {
                        f = CreateAttrAdapter(field);
                    }
                }
                if (f != null) {
                    properties[field]=f;
                }
            }
            return f;
        }

        public virtual System.Reflection.MethodInfo GetMethod(System.Type type, string name, System.Type ret, params System.Type [] args) {
            Net.Vpc.Upa.Impl.Util.MethodSignature key = new Net.Vpc.Upa.Impl.Util.MethodSignature(name, args);
            System.Reflection.MethodInfo method = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<Net.Vpc.Upa.Impl.Util.MethodSignature,System.Reflection.MethodInfo>(methods,key);
            if (method == null) {
                if (!methods.ContainsKey(key)) {
                    method = GetMethod00(type, name, ret, args);
                    methods[key]=method;
                }
            }
            return method;
        }

        public virtual System.Reflection.MethodInfo GetMethod00(System.Type type, string name, System.Type ret, params System.Type [] args) {
            try {
                System.Reflection.MethodInfo method = type.GetMethod(name, args);
                if (ret == null || (method).ReturnType.Equals(ret)) {
                    return method;
                }
            } catch (System.Exception ignored) {
            }
            System.Type s = (type).BaseType;
            if (s != null) {
                return GetMethod00(s, name, ret, args);
            }
            return null;
        }

        public virtual System.Collections.Generic.ISet<string> GetPropertyNames() {
            if (propertyNames == null) {
                LoadProperties();
                propertyNames = new System.Collections.Generic.HashSet<string>(new System.Collections.Generic.HashSet<string>(properties.Keys));
            }
            return propertyNames;
        }

        public virtual System.Collections.Generic.ISet<string> GetPropertyNames(object o, bool? includeDefaults) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.HashSet<string> set = new System.Collections.Generic.HashSet<string>();
            if (includeDefaults == null) {
                Net.Vpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(set, GetPropertyNames());
            } else {
                foreach (string k in GetPropertyNames()) {
                    Net.Vpc.Upa.Impl.Util.BeanAdapterAttribute e = GetAttrAdapter(k);
                    if (includeDefaults == e.IsDefaultValue(o)) {
                        set.Add(k);
                    }
                }
            }
            return set;
        }

        private void LoadProperties() {
            if (!propertiesLoaded) {
                propertiesLoaded = true;
                foreach (System.Reflection.MethodInfo method in platformType.GetMethods()) {
                    if (!(method).DeclaringType.Equals(typeof(object))) {
                        string n = (method).Name;
                        if ((n).Length > 2) {
                            if (n.StartsWith("is") && char.IsUpper(n[2])) {
                                string fieldName = char.ToLower(n[2]) + n.Substring(3);
                                GetAttrAdapter(fieldName);
                            } else if ((n).Length > 3) {
                                if ((n.StartsWith("get") || n.StartsWith("set")) && char.IsUpper(n[3])) {
                                    string fieldName = char.ToLower(n[3]) + n.Substring(4);
                                    GetAttrAdapter(fieldName);
                                }
                            }
                        }
                    }
                }
            }
        }

        public virtual bool ContainsProperty(string property) {
            Net.Vpc.Upa.Impl.Util.BeanAdapterAttribute attrAdapter = GetAttrAdapter(property);
            return attrAdapter != null;
        }

        public virtual object GetProperty(object o, string field) {
            Net.Vpc.Upa.Impl.Util.BeanAdapterAttribute attrAdapter = GetAttrAdapter(field);
            if (attrAdapter != null) {
                return attrAdapter.GetValue(o);
            }
            return null;
        }

        public virtual void InjectNull(object instance, string property) {
            Inject(instance, property, (object) null);
        }

        public virtual void Inject(object instance, string property, object @value) {
            Net.Vpc.Upa.Impl.Util.BeanAdapterAttribute attrAdapter = GetAttrAdapter(property);
            if (attrAdapter != null) {
                attrAdapter.SetValue(instance, @value);
            } else {
                System.Console.Error.WriteLine("inject " + property + " into " + instance.GetType() + " failed.");
            }
        }

        public virtual bool SetProperty(object instance, string property, object @value) {
            Net.Vpc.Upa.Impl.Util.BeanAdapterAttribute attrAdapter = GetAttrAdapter(property);
            if (attrAdapter != null) {
                attrAdapter.SetValue(instance, @value);
                return true;
            } else {
                return false;
            }
        }

        public static bool IsTypeDefaultValue(System.Type c, object v) {
            object t = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,object>(Net.Vpc.Upa.Impl.Util.PlatformUtils.DEFAULT_VALUES_BY_TYPE,c);
            if (t == null) {
                return v == null;
            }
            return t.Equals(v);
        }

        public static string GetterName(string field, System.Type type) {
            if (typeof(bool).Equals(type)) {
                return "is" + Suffix(field);
            }
            return "get" + Suffix(field);
        }

        public static string SetterName(string field) {
            return "set" + Suffix(field);
        }

        public static string Suffix(string s) {
            char[] chars = s.ToCharArray();
            chars[0] = char.ToUpper(chars[0]);
            return new string(chars);
        }

        public virtual System.Reflection.FieldInfo FindField(string name, Net.Vpc.Upa.Filters.ObjectFilter<System.Reflection.FieldInfo> filter) {
            System.Collections.Generic.IList<System.Reflection.FieldInfo> fieldsList = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,System.Collections.Generic.IList<System.Reflection.FieldInfo>>(fields,name);
            if (fieldsList == null) {
                if (!fields.ContainsKey(name)) {
                    fieldsList = Net.Vpc.Upa.Impl.Util.PlatformUtils.FindFields(platformType, name);
                    if ((fieldsList).Count > 0) {
                        fields[name]=fieldsList;
                    } else {
                        fields[name]=null;
                    }
                }
            }
            if (filter == null) {
                return fieldsList[0];
            }
            foreach (System.Reflection.FieldInfo field in fieldsList) {
                if (filter.Accept(field)) {
                    return field;
                }
            }
            return null;
        }

        public virtual bool ResetToDefaultValue(object instance, string field) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.Util.BeanAdapterAttribute attrAdapter = GetAttrAdapter(field);
            if (attrAdapter != null) {
                attrAdapter.SetValue(instance, attrAdapter.GetDefaultValue());
                return true;
            } else {
                return false;
            }
        }


        public virtual bool IsDefaultValue(object instance, string field) {
            Net.Vpc.Upa.Impl.Util.BeanAdapterAttribute attrAdapter = GetAttrAdapter(field);
            if (attrAdapter != null) {
                return attrAdapter.IsDefaultValue(instance);
            }
            return false;
        }

        public virtual System.Collections.Generic.IDictionary<string , object> ToMap(object o, bool? includeDefaults) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.Dictionary<string , object> map = new System.Collections.Generic.Dictionary<string , object>();
            if (includeDefaults == null) {
                foreach (string k in GetPropertyNames()) {
                    Net.Vpc.Upa.Impl.Util.BeanAdapterAttribute e = GetAttrAdapter(k);
                    map[k]=e.GetValue(o);
                }
            } else {
                foreach (string k in GetPropertyNames()) {
                    Net.Vpc.Upa.Impl.Util.BeanAdapterAttribute e = GetAttrAdapter(k);
                    if (includeDefaults == e.IsDefaultValue(o)) {
                        map[k]=e.GetValue(o);
                    }
                }
            }
            return map;
        }
    }
}
