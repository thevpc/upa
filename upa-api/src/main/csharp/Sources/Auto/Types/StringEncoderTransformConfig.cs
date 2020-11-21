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
    public class StringEncoderTransformConfig : Net.TheVpc.Upa.Types.DataTypeTransformConfig {

        private object encoder;

        private int size;

        public virtual void SetEncoder(string stringEncoder) {
            SetEncoderObject(stringEncoder);
        }

        public virtual void SetEncoder(Net.TheVpc.Upa.Types.StringEncoder stringEncoder) {
            SetEncoderObject(stringEncoder);
        }

        public virtual void SetEncoder(Net.TheVpc.Upa.Config.StringEncoderType stringEncoder) {
            SetEncoderObject(stringEncoder);
        }

        protected internal virtual void SetEncoderObject(object stringifyStrategy) {
            if (!(stringifyStrategy == null || stringifyStrategy is string || stringifyStrategy is System.Type || stringifyStrategy is Net.TheVpc.Upa.Types.StringEncoder || (stringifyStrategy is Net.TheVpc.Upa.Config.StringEncoderType && !stringifyStrategy.Equals(Net.TheVpc.Upa.Config.StringEncoderType.CUSTOM)))) {
                throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("secretStrategy should be of type String (as SecretStrategy class name), Class (SecretStrategy implementing class) or SecretStrategy (instance)");
            }
            this.encoder = stringifyStrategy;
        }

        public virtual object GetEncoder() {
            return encoder;
        }

        public virtual int GetSize() {
            return size;
        }

        public virtual void SetSize(int size) {
            this.size = size;
        }
    }
}
