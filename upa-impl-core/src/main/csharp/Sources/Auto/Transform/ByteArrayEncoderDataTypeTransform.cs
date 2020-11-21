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



namespace Net.TheVpc.Upa.Impl.Transform
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class ByteArrayEncoderDataTypeTransform : Net.TheVpc.Upa.Types.DataTypeTransform {

        private Net.TheVpc.Upa.Types.ByteArrayEncoder byteArrayEncoder;

        private Net.TheVpc.Upa.Types.DataType sourceType;

        private Net.TheVpc.Upa.Types.DataType targetType;

        public ByteArrayEncoderDataTypeTransform(Net.TheVpc.Upa.Types.ByteArrayEncoder byteArrayEncoder, Net.TheVpc.Upa.Types.DataType sourceType, int? max) {
            this.byteArrayEncoder = byteArrayEncoder;
            this.sourceType = sourceType;
            this.targetType = new Net.TheVpc.Upa.Types.ByteArrayType(null, max == null ? ((Net.TheVpc.Upa.Types.DataType)(255)) : max, sourceType.IsNullable());
        }

        public virtual object TransformValue(object @value) {
            Net.TheVpc.Upa.Types.ByteArrayEncoder ss = byteArrayEncoder;
            return ss.Encode(@value);
        }

        public virtual object ReverseTransformValue(object @value) {
            return byteArrayEncoder.Decode((byte[]) @value);
        }

        public virtual Net.TheVpc.Upa.Types.DataType GetSourceType() {
            return sourceType;
        }

        public virtual Net.TheVpc.Upa.Types.DataType GetTargetType() {
            return targetType;
        }


        public override string ToString() {
            return "StringEncoder{" + byteArrayEncoder + '}';
        }


        public virtual Net.TheVpc.Upa.Types.DataTypeTransform Chain(Net.TheVpc.Upa.Types.DataTypeTransform other) {
            return Net.TheVpc.Upa.Impl.Transform.DataTypeTransformList.Chain(this, other);
        }
    }
}
