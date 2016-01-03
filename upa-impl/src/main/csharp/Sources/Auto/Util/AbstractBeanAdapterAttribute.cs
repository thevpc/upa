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
    * @creationdate 1/5/13 11:18 PM*/
    internal abstract class AbstractBeanAdapterAttribute : Net.Vpc.Upa.Impl.Util.BeanAdapterAttribute {

        protected internal string name;

        protected internal System.Type fieldType;

        internal AbstractBeanAdapterAttribute(string name, System.Type fieldType) {
            this.name = name;
            this.fieldType = fieldType;
        }


        public virtual string GetName() {
            return name;
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
