/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.TheVpc.Upa.Types
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class SecretTransformConfig : Net.TheVpc.Upa.Types.DataTypeTransformConfig {

        private object secretStrategy;

        private string encodeKey;

        private string decodeKey;

        private int size;

        public virtual object GetSecretStrategy() {
            return secretStrategy;
        }

        public virtual void SetSecretStrategy(string cipherStrategy) {
            this.SetSecretStrategyObject(cipherStrategy);
        }

        public virtual void SetSecretStrategy(System.Type cipherStrategy) {
            this.SetSecretStrategyObject(cipherStrategy);
        }

        public virtual void SetSecretStrategy(Net.TheVpc.Upa.SecretStrategy secretStrategy) {
            this.SetSecretStrategyObject(secretStrategy);
        }

        public virtual void SetSecretStrategy(Net.TheVpc.Upa.SecretStrategyType secretStrategy) {
            this.SetSecretStrategyObject(secretStrategy);
        }

        protected internal virtual void SetSecretStrategyObject(object secretStrategy) {
            if (secretStrategy == null) {
                throw new System.NullReferenceException();
            }
            if (!(secretStrategy is string || secretStrategy is System.Type || secretStrategy is Net.TheVpc.Upa.SecretStrategy || (secretStrategy is Net.TheVpc.Upa.SecretStrategyType && !secretStrategy.Equals(Net.TheVpc.Upa.SecretStrategyType.CUSTOM)))) {
                throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("secretStrategy should be of type String (as SecretStrategy class name), Class (SecretStrategy implementing class) or SecretStrategy (instance)");
            }
            this.secretStrategy = secretStrategy;
        }

        public virtual int GetSize() {
            return size;
        }

        public virtual void SetSize(int size) {
            this.size = size;
        }

        public virtual string GetEncodeKey() {
            return encodeKey;
        }

        public virtual void SetEncodeKey(string encodeKey) {
            this.encodeKey = encodeKey;
        }

        public virtual string GetDecodeKey() {
            return decodeKey;
        }

        public virtual void SetDecodeKey(string decodeKey) {
            this.decodeKey = decodeKey;
        }


        public override string ToString() {
            return "SecretConfig{" + "secretStrategy=" + secretStrategy + '}';
        }
    }
}
