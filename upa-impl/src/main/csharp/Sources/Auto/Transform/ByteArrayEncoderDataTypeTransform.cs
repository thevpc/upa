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
     * @author vpc
     */
    public class ByteArrayEncoderDataTypeTransform : Net.Vpc.Upa.Types.DataTypeTransform {

        private Net.Vpc.Upa.Types.ByteArrayEncoder byteArrayEncoder;

        private Net.Vpc.Upa.Types.DataType sourceType;

        private Net.Vpc.Upa.Types.DataType targetType;

        public ByteArrayEncoderDataTypeTransform(Net.Vpc.Upa.Types.ByteArrayEncoder byteArrayEncoder, Net.Vpc.Upa.Types.DataType sourceType, int? max) {
            this.byteArrayEncoder = byteArrayEncoder;
            this.sourceType = sourceType;
            this.targetType = new Net.Vpc.Upa.Types.ByteArrayType(null, max == null ? ((int?)(255)) : max, sourceType.IsNullable());
        }

        public virtual object TransformValue(object @value) {
            Net.Vpc.Upa.Types.ByteArrayEncoder ss = byteArrayEncoder;
            return ss.Encode(@value);
        }

        public virtual object ReverseTransformValue(object @value) {
            return byteArrayEncoder.Decode((byte[]) @value);
        }

        public virtual Net.Vpc.Upa.Types.DataType GetSourceType() {
            return sourceType;
        }

        public virtual Net.Vpc.Upa.Types.DataType GetTargetType() {
            return targetType;
        }


        public override string ToString() {
            return "StringEncoder{" + byteArrayEncoder + '}';
        }


        public virtual Net.Vpc.Upa.Types.DataTypeTransform Chain(Net.Vpc.Upa.Types.DataTypeTransform other) {
            return Net.Vpc.Upa.Impl.Transform.DataTypeTransformList.Chain(this, other);
        }
    }
}
