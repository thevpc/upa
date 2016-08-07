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
    public class Base64SecretStrategy : Net.Vpc.Upa.SecretStrategy {

        public static readonly Net.Vpc.Upa.Impl.Transform.Base64SecretStrategy INSTANCE = new Net.Vpc.Upa.Impl.Transform.Base64SecretStrategy();

        public virtual void Init(Net.Vpc.Upa.PersistenceUnit persistenceUnit, string encodingKey, string decodingKey) {
        }

        public Base64SecretStrategy() {
        }

        public virtual byte[] Encode(byte[] @value) {
            if (@value == null) {
                return null;
            }
            return System.Text.Encoding.UTF8.GetBytes(Net.Vpc.Upa.Impl.Util.Base64.Encode(@value));
        }

        public virtual byte[] Decode(byte[] @value) {
            if (@value == null) {
                return null;
            }
            return Net.Vpc.Upa.Impl.Util.Base64.Decode(System.Text.Encoding.Default.GetString(@value));
        }
    }
}
