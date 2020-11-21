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



namespace Net.TheVpc.Upa.Impl.Util
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/27/12 12:16 AM
     */
    public class EntityBeanType : Net.TheVpc.Upa.BeanType {

        private Net.TheVpc.Upa.BeanType platformBeanType;

        private System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.Impl.Util.EntityBeanAttribute> fields = new System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Impl.Util.EntityBeanAttribute>();

        private System.Collections.Generic.ISet<string> propertyNames;

        private Net.TheVpc.Upa.Entity entity;

        public EntityBeanType(Net.TheVpc.Upa.Entity entity) {
            this.platformBeanType = Net.TheVpc.Upa.Impl.Util.PlatformBeanTypeRepository.GetInstance().GetBeanType(entity.GetEntityType());
            this.entity = entity;
            try {
                //entity.GetEntityType().GetConstructor().SetAccessible(true);
            } catch (System.Exception e) {
                throw new System.ArgumentException ("Unable to resolve default constructor for type " + entity.GetEntityType() + " (entity " + entity.GetName() + ")", e);
            }
            foreach (Net.TheVpc.Upa.Field field in entity.GetFields()) {
                GetAttrAdapter(field.GetName());
            }
        }


        public virtual System.Type GetPlatformType() {
            return entity.GetEntityType();
        }

        public virtual Net.TheVpc.Upa.Entity GetEntity() {
            return entity;
        }

        public virtual object NewInstance() {
            return platformBeanType.NewInstance();
        }

        public virtual Net.TheVpc.Upa.Impl.Util.EntityBeanAttribute GetAttrAdapter(string field) {
            Net.TheVpc.Upa.Impl.Util.EntityBeanAttribute r = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.TheVpc.Upa.Impl.Util.EntityBeanAttribute>(fields,field);
            if (r != null) {
                return r;
            }
            Net.TheVpc.Upa.Field f = entity.GetField(field);
            Net.TheVpc.Upa.PropertyAccessType propertyAccessType = f.GetPropertyAccessType();
            if (propertyAccessType == default(Net.TheVpc.Upa.PropertyAccessType)) {
                propertyAccessType = Net.TheVpc.Upa.PropertyAccessType.PROPERTY;
            }
            if (propertyAccessType == Net.TheVpc.Upa.PropertyAccessType.FIELD) {
                System.Reflection.FieldInfo ff = Net.TheVpc.Upa.Impl.Util.PlatformUtils.FindField(entity.GetEntityType(), f.GetName(), Net.TheVpc.Upa.Impl.Util.BeanFieldFilter.INSTANCE);
                if (ff != null) {
                    r = new Net.TheVpc.Upa.Impl.Util.EntityBeanFieldAttribute(this, ff, entity.GetEntityType());
                    fields[field]=r;
                }
            } else {
                Net.TheVpc.Upa.Impl.Util.EntityBeanGetterSetterAttribute a = new Net.TheVpc.Upa.Impl.Util.EntityBeanGetterSetterAttribute(this, field, f.GetDataType().GetPlatformType(), entity.GetEntityType());
                if (a.IsValid()) {
                    r = a;
                    fields[field]=r;
                }
            }
            return r;
        }

        public virtual bool ResetToDefaultValue(object instance, string field) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Impl.Util.EntityBeanAttribute attrAdapter = GetAttrAdapter(field);
            if (attrAdapter != null) {
                attrAdapter.SetValue(instance, attrAdapter.GetDefaultValue());
                return true;
            } else {
                return false;
            }
        }

        public virtual bool IsDefaultValue(object o, string field) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Impl.Util.EntityBeanAttribute attrAdapter = GetAttrAdapter(field);
            return attrAdapter.IsDefaultValue(o);
        }

        public virtual System.Collections.Generic.ISet<string> GetPropertyNames() {
            if (propertyNames == null) {
                System.Collections.Generic.HashSet<string> t = new System.Collections.Generic.HashSet<string>();
                foreach (Net.TheVpc.Upa.Field f in entity.GetFields()) {
                    if (GetAttrAdapter(f.GetName()) != null) {
                        t.Add(f.GetName());
                    }
                }
                propertyNames = t;
            }
            return new System.Collections.Generic.HashSet<string>(propertyNames);
        }

        public virtual System.Collections.Generic.ISet<string> GetPropertyNames(object o, bool? includeDefaults) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.HashSet<string> set = new System.Collections.Generic.HashSet<string>();
            if (includeDefaults == null) {
                Net.TheVpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(set, GetPropertyNames());
            } else {
                foreach (string k in GetPropertyNames()) {
                    Net.TheVpc.Upa.Impl.Util.EntityBeanAttribute e = GetAttrAdapter(k);
                    if (includeDefaults == e.IsDefaultValue(o)) {
                        set.Add(k);
                    }
                }
            }
            return set;
        }

        public virtual System.Collections.Generic.IDictionary<string , object> ToMap(object o, bool? includeDefaults) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.Dictionary<string , object> map = new System.Collections.Generic.Dictionary<string , object>();
            if (includeDefaults == null) {
                foreach (string k in GetPropertyNames()) {
                    Net.TheVpc.Upa.Impl.Util.EntityBeanAttribute e = GetAttrAdapter(k);
                    map[k]=e.GetValue(o);
                }
            } else {
                foreach (string k in GetPropertyNames()) {
                    Net.TheVpc.Upa.Impl.Util.EntityBeanAttribute e = GetAttrAdapter(k);
                    if (includeDefaults == e.IsDefaultValue(o)) {
                        map[k]=e.GetValue(o);
                    }
                }
            }
            return map;
        }

        public virtual object GetProperty(object o, string field) {
            Net.TheVpc.Upa.Impl.Util.EntityBeanAttribute attrAdapter = GetAttrAdapter(field);
            if (attrAdapter != null) {
                return attrAdapter.GetValue(o);
            }
            return null;
        }

        public virtual bool SetProperty(object o, string field, object @value) {
            Net.TheVpc.Upa.Impl.Util.EntityBeanAttribute attrAdapter = GetAttrAdapter(field);
            if (attrAdapter != null) {
                attrAdapter.SetValue(o, @value);
                return true;
            }
            return false;
        }


        public virtual bool ContainsProperty(string property) {
            return GetPropertyNames().Contains(property);
        }


        public virtual void Inject(object instance, string property, object @value) {
            Net.TheVpc.Upa.Impl.Util.EntityBeanAttribute a = GetAttrAdapter(property);
            if (a != null) {
                a.SetValue(instance, @value);
            }
        }


        public virtual System.Reflection.MethodInfo GetMethod(System.Type type, string name, System.Type ret, params System.Type [] args) {
            return platformBeanType.GetMethod(type, name, ret, args);
        }

        public virtual System.Reflection.FieldInfo FindField(string name, Net.TheVpc.Upa.Filters.ObjectFilter<System.Reflection.FieldInfo> filter) {
            return platformBeanType.FindField(name, filter);
        }
    }
}
