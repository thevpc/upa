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
     * @creationdate 1/5/13 11:28 PM
     */
    internal class EntityBeanGetterSetterAttribute : Net.TheVpc.Upa.Impl.Util.AbstractEntityBeanAttribute {

        private System.Reflection.MethodInfo getter;

        private System.Reflection.MethodInfo setter;

        private string fieldName;

        private System.Type fieldType;

        private Net.TheVpc.Upa.Impl.Util.EntityBeanType entityBeanAdapter;

        internal EntityBeanGetterSetterAttribute(Net.TheVpc.Upa.Impl.Util.EntityBeanType entityBeanAdapter, string fieldName, System.Type fieldType, System.Type type)  : base(entityBeanAdapter, fieldName, fieldType){

            this.entityBeanAdapter = entityBeanAdapter;
            this.fieldName = fieldName;
            this.fieldType = fieldType;
            getter = entityBeanAdapter.GetMethod(type, Net.TheVpc.Upa.Impl.Util.PlatformUtils.GetterName(fieldName, fieldType), fieldType);
            if (getter == null) {
                getter = entityBeanAdapter.GetMethod(type, Net.TheVpc.Upa.Impl.Util.PlatformUtils.GetterName(fieldName, fieldType), fieldType);
            }
            //            System.out.println("why");
            if (getter != null) {
                //getter.SetAccessible(true);
            }
            setter = entityBeanAdapter.GetMethod(type, Net.TheVpc.Upa.Impl.Util.PlatformUtils.SetterName(fieldName), typeof(void), fieldType);
            if (setter != null) {
                //setter.SetAccessible(true);
            }
        }

        public virtual bool IsValid() {
            return getter != null || setter != null;
        }


        public override object GetValue(object o) {
            if (getter == null) {
                throw new System.Exception("Field inaccessible : no getter found for field " + fieldName);
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
                throw new System.Exception("Field " + fieldName + " is readonly : no setter found");
            }
            try {
                setter.Invoke(o, @value);
            } catch (System.Exception e) {
                if (e is System.Exception) {
                    e = (System.Exception) (((System.Exception) e)).InnerException;
                }
                throw new Net.TheVpc.Upa.Exceptions.UPAException(e, new Net.TheVpc.Upa.Types.I18NString("UnableToSetFieldValue"), fieldName, entityBeanAdapter.GetEntity(), setter);
            }
        }
    }
}
