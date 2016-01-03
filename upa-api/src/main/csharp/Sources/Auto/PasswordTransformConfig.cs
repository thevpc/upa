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



namespace Net.Vpc.Upa
{


    /**
     *
     * @author vpc
     */
    public class PasswordTransformConfig : Net.Vpc.Upa.Types.DataTypeTransformConfig {

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

        public virtual void SetCipherStrategy(Net.Vpc.Upa.PasswordStrategy cipherStrategy) {
            this.SetObjectCipherStrategy(cipherStrategy);
        }

        public virtual void SetCipherStrategy(Net.Vpc.Upa.PasswordStrategyType cipherStrategy) {
            this.SetObjectCipherStrategy(cipherStrategy);
        }

        protected internal virtual void SetObjectCipherStrategy(object cipherStrategy) {
            if (cipherStrategy == null) {
                throw new System.NullReferenceException();
            }
            if (!(cipherStrategy is string || cipherStrategy is System.Type || cipherStrategy is Net.Vpc.Upa.PasswordStrategy || (cipherStrategy is Net.Vpc.Upa.PasswordStrategyType && !cipherStrategy.Equals(Net.Vpc.Upa.PasswordStrategyType.CUSTOM)))) {
                throw new System.ArgumentException ("cipherStrategy shoud be of type String (as CipherStrategy class name), Class (CipherStrategy implementing class), CipherStrategy (instance), or CipherStrategyType (any balue but custom)");
            }
            this.cipherStrategy = cipherStrategy;
        }
    }
}
