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
    public class StringEncoderDataTypeTransform : Net.TheVpc.Upa.Types.DataTypeTransform {

        private Net.TheVpc.Upa.Types.StringEncoder stringEncoder;

        private Net.TheVpc.Upa.Types.ByteArrayEncoder serializer;

        private Net.TheVpc.Upa.Types.DataType sourceType;

        private Net.TheVpc.Upa.Types.DataType targetType;

        public StringEncoderDataTypeTransform(Net.TheVpc.Upa.Types.StringEncoder stringEncoder, Net.TheVpc.Upa.Types.DataType sourceType, int? max, Net.TheVpc.Upa.Types.ByteArrayEncoder serializer) {
            this.serializer = serializer;
            this.stringEncoder = stringEncoder;
            this.sourceType = sourceType;
            this.targetType = new Net.TheVpc.Upa.Types.StringType(null, 0, max == null ? ((Net.TheVpc.Upa.Types.DataType)(255)) : max, sourceType.IsNullable());
        }

        public virtual object TransformValue(object @value) {
            Net.TheVpc.Upa.Types.StringEncoder ss = stringEncoder;
            string bytes = ss.Encode(serializer.Encode(@value));
            return bytes;
        }

        public virtual object ReverseTransformValue(object @value) {
            byte[] bytes = stringEncoder.Decode((string) @value);
            return serializer.Decode(bytes);
        }

        public virtual Net.TheVpc.Upa.Types.DataType GetSourceType() {
            return sourceType;
        }

        public virtual Net.TheVpc.Upa.Types.DataType GetTargetType() {
            return targetType;
        }


        public override string ToString() {
            return "StringEncoder{" + "stringEncoder=" + stringEncoder + ", serializer=" + serializer + ", sourceType=" + sourceType + ", targetType=" + targetType + '}';
        }


        public virtual Net.TheVpc.Upa.Types.DataTypeTransform Chain(Net.TheVpc.Upa.Types.DataTypeTransform other) {
            return Net.TheVpc.Upa.Impl.Transform.DataTypeTransformList.Chain(this, other);
        }
    }
}
