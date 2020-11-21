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
     * @creationdate 1/5/13 11:24 PM
     */
    internal abstract class AbstractEntityBeanAttribute : Net.TheVpc.Upa.Impl.Util.EntityBeanAttribute {

        private string name;

        private System.Type fieldType;

        private Net.TheVpc.Upa.Impl.Util.EntityBeanType entityBeanAdapter;

        internal AbstractEntityBeanAttribute(Net.TheVpc.Upa.Impl.Util.EntityBeanType entityBeanAdapter, string name, System.Type fieldType) {
            this.entityBeanAdapter = entityBeanAdapter;
            this.name = name;
            this.fieldType = fieldType;
        }


        public virtual string GetName() {
            return name;
        }


        public virtual object GetDefaultValue() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Entity entity = entityBeanAdapter.GetEntity();
            Net.TheVpc.Upa.Field field = null;
            if (entity != null) {
                field = entity.FindField(GetName());
                if (field == null) {
                    entity = null;
                }
            }
            if (entity == null || field == null) {
                return Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,object>(Net.TheVpc.Upa.Impl.Util.PlatformUtils.DEFAULT_VALUES_BY_TYPE,GetFieldType());
            } else {
                return field.GetUnspecifiedValueDecoded();
            }
        }

        public virtual bool IsDefaultValue(object o) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            object fieldValue = GetValue(o);
            Net.TheVpc.Upa.Entity entity = entityBeanAdapter.GetEntity();
            Net.TheVpc.Upa.Field field = null;
            if (entity != null) {
                field = entity.FindField(GetName());
                if (field == null) {
                    entity = null;
                }
            }
            if (entity == null || field == null) {
                object fieldDefaultValue = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,object>(Net.TheVpc.Upa.Impl.Util.PlatformUtils.DEFAULT_VALUES_BY_TYPE,GetFieldType());
                if (fieldDefaultValue == null) {
                    return fieldValue == null;
                } else {
                    return fieldDefaultValue.Equals(fieldValue);
                }
            } else {
                return field.IsUnspecifiedValue(fieldValue);
            }
        }

        public virtual System.Type GetFieldType() {
            return fieldType;
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract object GetValue(object arg1);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract void SetValue(object arg1, object arg2);
    }
}
