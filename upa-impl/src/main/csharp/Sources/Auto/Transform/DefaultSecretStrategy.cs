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



namespace Net.Vpc.Upa.Impl.Transform
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class DefaultSecretStrategy : Net.Vpc.Upa.SecretStrategy {

        private static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.Transform.DefaultSecretStrategy)).FullName);

        private Javax.Crypto.Cipher aes;

        private Javax.Crypto.Spec.SecretKeySpec encodeKey;

        private Javax.Crypto.Spec.SecretKeySpec decodeKey;

        public virtual void Init(Net.Vpc.Upa.PersistenceUnit persistenceUnit, string encodingKey, string decodingKey) {
            
        }

        public DefaultSecretStrategy() {
        }

        


        


        public virtual byte[] Encode(byte[] @value) {
            if (@value == null) {
                return @value;
            }
            return value;
        }

        public virtual byte[] Decode(byte[] @value) {
            if (@value == null) {
                return @value;
            }
            return value;
        }


        public override string ToString() {
            return "DefaultSecretStrategy";
        }
    }
}
