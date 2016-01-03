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
     * @creationdate 1/5/13 11:24 PM
     */
    internal abstract class AbstractEntityBeanAttribute : Net.Vpc.Upa.Impl.Util.EntityBeanAttribute {

        private string name;

        private System.Type fieldType;

        private Net.Vpc.Upa.Impl.Util.EntityBeanAdapter entityBeanAdapter;

        internal AbstractEntityBeanAttribute(Net.Vpc.Upa.Impl.Util.EntityBeanAdapter entityBeanAdapter, string name, System.Type fieldType) {
            this.entityBeanAdapter = entityBeanAdapter;
            this.name = name;
            this.fieldType = fieldType;
        }


        public virtual string GetName() {
            return name;
        }


        public virtual object GetDefaultValue() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Entity entity = entityBeanAdapter.GetEntity();
            Net.Vpc.Upa.Field field = null;
            if (entity != null) {
                field = entity.FindField(GetName());
                if (field == null) {
                    entity = null;
                }
            }
            if (entity == null || field == null) {
                return Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,object>(Net.Vpc.Upa.Impl.Util.PlatformUtils.DEFAULT_VALUES_BY_TYPE,GetFieldType());
            } else {
                return field.GetUnspecifiedValueDecoded();
            }
        }

        public virtual bool IsDefaultValue(object o) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            object fieldValue = GetValue(o);
            Net.Vpc.Upa.Entity entity = entityBeanAdapter.GetEntity();
            Net.Vpc.Upa.Field field = null;
            if (entity != null) {
                field = entity.FindField(GetName());
                if (field == null) {
                    entity = null;
                }
            }
            if (entity == null || field == null) {
                object fieldDefaultValue = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,object>(Net.Vpc.Upa.Impl.Util.PlatformUtils.DEFAULT_VALUES_BY_TYPE,GetFieldType());
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
