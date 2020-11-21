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
    public class KeyTypeFactory : Net.TheVpc.Upa.Impl.KeyFactory {

        public static readonly System.Collections.Generic.HashSet<System.Type> ACCEPTED_TYPES = new System.Collections.Generic.HashSet<System.Type>(new System.Collections.Generic.List<System.Type>(new[]{typeof(string), typeof(Net.TheVpc.Upa.Types.Temporal), typeof(Net.TheVpc.Upa.Types.Date), typeof(Net.TheVpc.Upa.Types.Timestamp), typeof(Net.TheVpc.Upa.Types.Time), typeof(Net.TheVpc.Upa.Types.DateTime), typeof(Net.TheVpc.Upa.Types.Date), typeof(Net.TheVpc.Upa.Types.Month), typeof(Net.TheVpc.Upa.Types.Time), typeof(Net.TheVpc.Upa.Types.Year), typeof(int?), typeof(int), typeof(short?), typeof(short), typeof(long?), typeof(long), typeof(double?), typeof(double), typeof(float?), typeof(float)}));

        private System.Type keyType;

        public KeyTypeFactory(System.Type keyType) {
            if (!ACCEPTED_TYPES.Contains(keyType)) {
                throw new System.ArgumentException ("No Supported");
            }
            this.keyType = keyType;
        }

        public virtual System.Type GetIdType() {
            return keyType;
        }


        public virtual Net.TheVpc.Upa.Key CreateKey(params object [] idValues) {
            if (idValues == null) {
                return null;
            }
            return new Net.TheVpc.Upa.Impl.DefaultKey(idValues);
        }


        public virtual object CreateId(params object [] idValues) {
            if (idValues == null) {
                return null;
            }
            return idValues[0];
        }


        public virtual object GetId(Net.TheVpc.Upa.Key unstructuredKey) {
            if (unstructuredKey == null) {
                return null;
            }
            return CreateId(unstructuredKey.GetValue());
        }


        public virtual Net.TheVpc.Upa.Key GetKey(object id) {
            if (id == null) {
                return null;
            }
            return CreateKey(id);
        }
    }
}
