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
    public class StringEncoderDataTypeTransform : Net.Vpc.Upa.Types.DataTypeTransform {

        private Net.Vpc.Upa.Types.StringEncoder stringEncoder;

        private Net.Vpc.Upa.Types.ByteArrayEncoder serializer;

        private Net.Vpc.Upa.Types.DataType sourceType;

        private Net.Vpc.Upa.Types.DataType targetType;

        public StringEncoderDataTypeTransform(Net.Vpc.Upa.Types.StringEncoder stringEncoder, Net.Vpc.Upa.Types.DataType sourceType, int? max, Net.Vpc.Upa.Types.ByteArrayEncoder serializer) {
            this.serializer = serializer;
            this.stringEncoder = stringEncoder;
            this.sourceType = sourceType;
            this.targetType = new Net.Vpc.Upa.Types.StringType(null, 0, max == null ? ((Net.Vpc.Upa.Types.DataType)(255)) : max, sourceType.IsNullable());
        }

        public virtual object TransformValue(object @value) {
            Net.Vpc.Upa.Types.StringEncoder ss = stringEncoder;
            string bytes = ss.Encode(serializer.Encode(@value));
            return bytes;
        }

        public virtual object ReverseTransformValue(object @value) {
            byte[] bytes = stringEncoder.Decode((string) @value);
            return serializer.Decode(bytes);
        }

        public virtual Net.Vpc.Upa.Types.DataType GetSourceType() {
            return sourceType;
        }

        public virtual Net.Vpc.Upa.Types.DataType GetTargetType() {
            return targetType;
        }


        public override string ToString() {
            return "StringEncoder{" + "stringEncoder=" + stringEncoder + ", serializer=" + serializer + ", sourceType=" + sourceType + ", targetType=" + targetType + '}';
        }


        public virtual Net.Vpc.Upa.Types.DataTypeTransform Chain(Net.Vpc.Upa.Types.DataTypeTransform other) {
            return Net.Vpc.Upa.Impl.Transform.DataTypeTransformList.Chain(this, other);
        }
    }
}
