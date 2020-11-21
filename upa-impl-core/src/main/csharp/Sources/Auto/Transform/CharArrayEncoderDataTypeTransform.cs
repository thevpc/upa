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
    public class CharArrayEncoderDataTypeTransform : Net.TheVpc.Upa.Types.DataTypeTransform {

        private Net.TheVpc.Upa.Types.CharArrayEncoder charArrayEncoder;

        private Net.TheVpc.Upa.Types.DataType sourceType;

        private Net.TheVpc.Upa.Types.DataType targetType;

        public CharArrayEncoderDataTypeTransform(Net.TheVpc.Upa.Types.CharArrayEncoder byteArrayEncoder, Net.TheVpc.Upa.Types.DataType sourceType, int? max) {
            this.charArrayEncoder = byteArrayEncoder;
            this.sourceType = sourceType;
            this.targetType = new Net.TheVpc.Upa.Types.ByteArrayType(null, max == null ? ((Net.TheVpc.Upa.Types.DataType)(255)) : max, sourceType.IsNullable());
        }

        public virtual object TransformValue(object @value) {
            Net.TheVpc.Upa.Types.CharArrayEncoder ss = charArrayEncoder;
            return ss.Encode(@value);
        }

        public virtual object ReverseTransformValue(object @value) {
            return charArrayEncoder.Decode((char[]) @value);
        }

        public virtual Net.TheVpc.Upa.Types.DataType GetSourceType() {
            return sourceType;
        }

        public virtual Net.TheVpc.Upa.Types.DataType GetTargetType() {
            return targetType;
        }


        public override string ToString() {
            return "CharArrayEncoder{" + charArrayEncoder + '}';
        }


        public virtual Net.TheVpc.Upa.Types.DataTypeTransform Chain(Net.TheVpc.Upa.Types.DataTypeTransform other) {
            return Net.TheVpc.Upa.Impl.Transform.DataTypeTransformList.Chain(this, other);
        }
    }
}
