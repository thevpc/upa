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



namespace Net.Vpc.Upa.Impl
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/27/12 2:06 AM
     */
    public class BeanAdapterKey : Net.Vpc.Upa.Impl.AbstractKey {

        private System.Type keyType;

        private Net.Vpc.Upa.Impl.Util.EntityBeanAdapter nfo;

        private object userObject;

        public BeanAdapterKey(System.Type keyType, object userObject, Net.Vpc.Upa.Entity entity) {
            this.keyType = keyType;
            this.userObject = userObject;
            nfo = new Net.Vpc.Upa.Impl.Util.EntityBeanAdapter(keyType, entity);
        }


        public override object[] GetValue() {
            object o = userObject;
            System.Collections.Generic.IList<string> names = nfo.GetFieldNames();
            object[] v = new object[(names).Count];
            int i = 0;
            foreach (string name in names) {
                v[i] = nfo.GetProperty<object>(o, name);
                i++;
            }
            return v;
        }


        public override void SetValue(object[] @value) {
            object o = userObject;
            System.Collections.Generic.IList<string> names = nfo.GetFieldNames();
            int i = 0;
            foreach (string name in names) {
                nfo.SetProperty<object>(o, name, @value[i]);
                i++;
            }
        }
    }
}
