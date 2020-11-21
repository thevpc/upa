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



namespace Net.TheVpc.Upa.Impl
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/27/12 2:06 AM
     */
    public class BeanAdapterKey : Net.TheVpc.Upa.Impl.AbstractKey {

        private System.Type keyType;

        private Net.TheVpc.Upa.BeanType nfo;

        private object userObject;

        public BeanAdapterKey(System.Type keyType, object userObject, Net.TheVpc.Upa.Entity entity) {
            this.keyType = keyType;
            this.userObject = userObject;
            nfo = Net.TheVpc.Upa.Impl.Util.PlatformBeanTypeRepository.GetInstance().GetBeanType(keyType);
        }


        public override object[] GetValue() {
            object o = userObject;
            System.Collections.Generic.ISet<string> names = nfo.GetPropertyNames();
            object[] v = new object[(names).Count];
            int i = 0;
            foreach (string name in names) {
                v[i] = nfo.GetProperty(o, name);
                i++;
            }
            return v;
        }


        public override void SetValue(object[] @value) {
            object o = userObject;
            System.Collections.Generic.ISet<string> names = nfo.GetPropertyNames();
            int i = 0;
            foreach (string name in names) {
                nfo.SetProperty(o, name, @value[i]);
                i++;
            }
        }
    }
}
