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
     * @creationdate 8/27/12 1:51 AM
     */
    public class KeySubclassUnstructuredFactory : Net.TheVpc.Upa.Impl.KeyFactory {

        private Net.TheVpc.Upa.BeanType nfo;

        public KeySubclassUnstructuredFactory(Net.TheVpc.Upa.BeanType nfo) {
            this.nfo = nfo;
        }

        public virtual System.Type GetIdType() {
            return nfo.GetPlatformType();
        }


        public virtual Net.TheVpc.Upa.Key CreateKey(params object [] keyValues) {
            Net.TheVpc.Upa.Key o = (Net.TheVpc.Upa.Key) nfo.NewInstance();
            o.SetValue(keyValues);
            return o;
        }


        public virtual object CreateId(params object [] keyValues) {
            Net.TheVpc.Upa.Key o = (Net.TheVpc.Upa.Key) nfo.NewInstance();
            o.SetValue(keyValues);
            return o;
        }


        public virtual object GetId(Net.TheVpc.Upa.Key unstructuredKey) {
            if (nfo.GetPlatformType().IsInstanceOfType(unstructuredKey)) {
                return unstructuredKey;
            }
            Net.TheVpc.Upa.Key o = (Net.TheVpc.Upa.Key) nfo.NewInstance();
            o.SetValue(unstructuredKey.GetValue());
            return o;
        }


        public virtual Net.TheVpc.Upa.Key GetKey(object id) {
            return (Net.TheVpc.Upa.Key) id;
        }
    }
}
