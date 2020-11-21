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



namespace Net.TheVpc.Upa
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class PasswordTransformConfig : Net.TheVpc.Upa.Types.DataTypeTransformConfig {

        public static readonly object NO_VALUE = new object();

        private object cipherValue;

        private object cipherStrategy;

        public virtual object GetCipherValue() {
            return cipherValue;
        }

        public virtual void SetCipherValue(object cipherValue) {
            this.cipherValue = cipherValue;
        }

        public virtual object GetCipherStrategy() {
            return cipherStrategy;
        }

        public virtual void SetCipherStrategy(string cipherStrategy) {
            this.SetObjectCipherStrategy(cipherStrategy);
        }

        public virtual void SetCipherStrategy(System.Type cipherStrategy) {
            this.SetObjectCipherStrategy(cipherStrategy);
        }

        public virtual void SetCipherStrategy(Net.TheVpc.Upa.PasswordStrategy cipherStrategy) {
            this.SetObjectCipherStrategy(cipherStrategy);
        }

        public virtual void SetCipherStrategy(Net.TheVpc.Upa.PasswordStrategyType cipherStrategy) {
            this.SetObjectCipherStrategy(cipherStrategy);
        }

        protected internal virtual void SetObjectCipherStrategy(object cipherStrategy) {
            if (cipherStrategy == null) {
                throw new System.NullReferenceException();
            }
            if (!(cipherStrategy is string || cipherStrategy is System.Type || cipherStrategy is Net.TheVpc.Upa.PasswordStrategy || (cipherStrategy is Net.TheVpc.Upa.PasswordStrategyType && !cipherStrategy.Equals(Net.TheVpc.Upa.PasswordStrategyType.CUSTOM)))) {
                throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("cipherStrategy should be of type String (as CipherStrategy class name), Class (CipherStrategy implementing class), CipherStrategy (instance), or CipherStrategyType (any value but custom)");
            }
            this.cipherStrategy = cipherStrategy;
        }
    }
}
