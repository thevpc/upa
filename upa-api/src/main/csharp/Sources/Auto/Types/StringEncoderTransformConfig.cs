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



namespace Net.Vpc.Upa.Types
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class StringEncoderTransformConfig : Net.Vpc.Upa.Types.DataTypeTransformConfig {

        private object encoder;

        private int size;

        public virtual void SetEncoder(string stringEncoder) {
            SetEncoderObject(stringEncoder);
        }

        public virtual void SetEncoder(Net.Vpc.Upa.Types.StringEncoder stringEncoder) {
            SetEncoderObject(stringEncoder);
        }

        public virtual void SetEncoder(Net.Vpc.Upa.Config.StringEncoderType stringEncoder) {
            SetEncoderObject(stringEncoder);
        }

        protected internal virtual void SetEncoderObject(object stringifyStrategy) {
            if (!(stringifyStrategy == null || stringifyStrategy is string || stringifyStrategy is System.Type || stringifyStrategy is Net.Vpc.Upa.Types.StringEncoder || (stringifyStrategy is Net.Vpc.Upa.Config.StringEncoderType && !stringifyStrategy.Equals(Net.Vpc.Upa.Config.StringEncoderType.CUSTOM)))) {
                throw new Net.Vpc.Upa.Exceptions.UPAIllegalArgumentException("secretStrategy should be of type String (as SecretStrategy class name), Class (SecretStrategy implementing class) or SecretStrategy (instance)");
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
