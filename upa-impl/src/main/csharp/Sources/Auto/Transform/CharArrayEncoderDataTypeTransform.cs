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
    public class CharArrayEncoderDataTypeTransform : Net.Vpc.Upa.Types.DataTypeTransform {

        private Net.Vpc.Upa.Types.CharArrayEncoder charArrayEncoder;

        private Net.Vpc.Upa.Types.DataType sourceType;

        private Net.Vpc.Upa.Types.DataType targetType;

        public CharArrayEncoderDataTypeTransform(Net.Vpc.Upa.Types.CharArrayEncoder byteArrayEncoder, Net.Vpc.Upa.Types.DataType sourceType, int? max) {
            this.charArrayEncoder = byteArrayEncoder;
            this.sourceType = sourceType;
            this.targetType = new Net.Vpc.Upa.Types.ByteArrayType(null, max == null ? ((Net.Vpc.Upa.Types.DataType)(255)) : max, sourceType.IsNullable());
        }

        public virtual object TransformValue(object @value) {
            Net.Vpc.Upa.Types.CharArrayEncoder ss = charArrayEncoder;
            return ss.Encode(@value);
        }

        public virtual object ReverseTransformValue(object @value) {
            return charArrayEncoder.Decode((char[]) @value);
        }

        public virtual Net.Vpc.Upa.Types.DataType GetSourceType() {
            return sourceType;
        }

        public virtual Net.Vpc.Upa.Types.DataType GetTargetType() {
            return targetType;
        }


        public override string ToString() {
            return "CharArrayEncoder{" + charArrayEncoder + '}';
        }


        public virtual Net.Vpc.Upa.Types.DataTypeTransform Chain(Net.Vpc.Upa.Types.DataTypeTransform other) {
            return Net.Vpc.Upa.Impl.Transform.DataTypeTransformList.Chain(this, other);
        }
    }
}
