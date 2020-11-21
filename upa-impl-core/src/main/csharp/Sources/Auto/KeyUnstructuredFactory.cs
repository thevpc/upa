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
    public class KeyUnstructuredFactory : Net.TheVpc.Upa.Impl.KeyFactory {

        private Net.TheVpc.Upa.Entity entity;

        public KeyUnstructuredFactory(Net.TheVpc.Upa.Entity entity) {
            this.entity = entity;
        }

        public virtual System.Type GetIdType() {
            return typeof(Net.TheVpc.Upa.Key);
        }


        public virtual Net.TheVpc.Upa.Key CreateKey(params object [] idValues) {
            return new Net.TheVpc.Upa.Impl.DefaultKey(idValues);
        }


        public virtual object CreateId(params object [] idValues) {
            if ((entity.GetPrimaryFields()).Count != idValues.Length) {
                throw new System.ArgumentException ("Invalid Key Size. Expected " + (entity.GetPrimaryFields()).Count + " but found " + idValues.Length);
            }
            return new Net.TheVpc.Upa.Impl.DefaultKey(idValues);
        }


        public virtual object GetId(Net.TheVpc.Upa.Key unstructuredKey) {
            return unstructuredKey;
        }


        public virtual Net.TheVpc.Upa.Key GetKey(object id) {
            return (Net.TheVpc.Upa.Key) id;
        }
    }
}
