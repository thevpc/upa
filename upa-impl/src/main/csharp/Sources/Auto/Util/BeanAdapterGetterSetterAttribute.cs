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
     * @creationdate 1/5/13 11:20 PM
     */
    internal class BeanAdapterGetterSetterAttribute : Net.Vpc.Upa.Impl.Util.AbstractBeanAdapterAttribute {

        private System.Reflection.MethodInfo getter;

        private System.Reflection.MethodInfo setter;

        internal BeanAdapterGetterSetterAttribute(string field, System.Type fieldType, System.Reflection.MethodInfo getter, System.Reflection.MethodInfo setter)  : base(field, fieldType){

            this.getter = getter;
            if (getter != null) {
                //getter.SetAccessible(true);
            }
            this.setter = setter;
            if (setter != null) {
                //setter.SetAccessible(true);
            }
        }

        public virtual System.Reflection.MethodInfo GetGetter() {
            return getter;
        }

        public virtual System.Reflection.MethodInfo GetSetter() {
            return setter;
        }


        public override object GetValue(object o) {
            if (getter == null) {
                throw new System.Exception("Field inaccessible : no getter found for field " + GetName());
            }
            try {
                return getter.Invoke(o, new object[0]);
            } catch (System.Exception e) {
                if (e is System.Exception) {
                    e = (System.Exception) (((System.Exception) e)).InnerException;
                }
                if (e is System.Exception) {
                    throw (System.Exception) e;
                }
                throw new System.Exception("RuntimeException", e);
            }
        }


        public override void SetValue(object o, object @value) {
            if (setter == null) {
                throw new System.Exception("Field readonly : no setter found for " + GetName() + " in class " + o.GetType());
            }
            try {
                setter.Invoke(o, new object[] { @value });
            } catch (System.Exception e) {
                //throw new IllegalArgumentException("Unable to set value " + (value == null ? "null" : value.getClass()) + " for property " + getName() + ". Expected Type is " + getFieldType(), e);
                if (e is System.Exception) {
                    e = (System.Exception) (((System.Exception) e)).InnerException;
                }
                if (e is System.Exception) {
                    throw (System.Exception) e;
                }
                throw new System.Exception("RuntimeException", e);
            }
        }
    }
}
