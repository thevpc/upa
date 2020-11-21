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
    * @creationdate 1/5/13 11:27 PM*/
    internal class EntityBeanFieldAttribute : Net.TheVpc.Upa.Impl.Util.AbstractEntityBeanAttribute {

        private System.Reflection.FieldInfo field;

        internal EntityBeanFieldAttribute(Net.TheVpc.Upa.Impl.Util.EntityBeanType entityBeanAdapter, System.Reflection.FieldInfo field, System.Type cls)  : base(entityBeanAdapter, (field).Name, field.GetType()){

            this.field = field;
            //field.SetAccessible(true);
        }


        public override object GetValue(object o) {
            try {
                return field.GetValue(o);
            } catch (System.Exception e) {
                throw new System.Exception("RuntimeException", e);
            }
        }


        public override void SetValue(object o, object @value) {
            try {
                field.SetValue(o, @value);
            } catch (System.Exception e) {
                throw new System.Exception("RuntimeException", e);
            }
        }
    }
}
