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



namespace Net.Vpc.Upa.Types
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class ByteArrayEncoderTransformConfig : Net.Vpc.Upa.Types.DataTypeTransformConfig {

        private object encoder;

        private int size;

        public virtual void SetEncoder(string encoder) {
            SetEncoderObject(encoder);
        }

        public virtual void SetEncoder(Net.Vpc.Upa.Types.ByteArrayEncoder encoder) {
            SetEncoderObject(encoder);
        }

        protected internal virtual void SetEncoderObject(object encoder) {
            if (!(encoder == null || encoder is string || encoder is System.Type || encoder is Net.Vpc.Upa.Types.ByteArrayEncoder)) {
                throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("secretStrategy shoud be of type String (as class/bean name), Class (implementing class) or ByteArrayEncoder instance");
            }
            this.encoder = encoder;
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
