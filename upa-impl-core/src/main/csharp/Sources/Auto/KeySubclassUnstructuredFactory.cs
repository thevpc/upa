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
     * @creationdate 8/27/12 1:51 AM
     */
    public class KeySubclassUnstructuredFactory : Net.Vpc.Upa.Impl.KeyFactory {

        private Net.Vpc.Upa.BeanType nfo;

        public KeySubclassUnstructuredFactory(Net.Vpc.Upa.BeanType nfo) {
            this.nfo = nfo;
        }

        public virtual System.Type GetIdType() {
            return nfo.GetPlatformType();
        }


        public virtual Net.Vpc.Upa.Key CreateKey(params object [] keyValues) {
            Net.Vpc.Upa.Key o = (Net.Vpc.Upa.Key) nfo.NewInstance();
            o.SetValue(keyValues);
            return o;
        }


        public virtual object CreateId(params object [] keyValues) {
            Net.Vpc.Upa.Key o = (Net.Vpc.Upa.Key) nfo.NewInstance();
            o.SetValue(keyValues);
            return o;
        }


        public virtual object GetId(Net.Vpc.Upa.Key unstructuredKey) {
            if (nfo.GetPlatformType().IsInstanceOfType(unstructuredKey)) {
                return unstructuredKey;
            }
            Net.Vpc.Upa.Key o = (Net.Vpc.Upa.Key) nfo.NewInstance();
            o.SetValue(unstructuredKey.GetValue());
            return o;
        }


        public virtual Net.Vpc.Upa.Key GetKey(object id) {
            return (Net.Vpc.Upa.Key) id;
        }
    }
}
