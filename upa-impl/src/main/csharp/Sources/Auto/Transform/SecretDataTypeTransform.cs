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
    public class SecretDataTypeTransform : Net.Vpc.Upa.Types.DataTypeTransform {

        private Net.Vpc.Upa.SecretStrategy secretStrategy;

        private Net.Vpc.Upa.Types.DataType sourceType;

        private Net.Vpc.Upa.Types.DataType targetType;

        public SecretDataTypeTransform(Net.Vpc.Upa.SecretStrategy secretStrategy, Net.Vpc.Upa.Types.DataType source, int? targetMax) {
            this.secretStrategy = secretStrategy;
            this.sourceType = source;
            this.targetType = new Net.Vpc.Upa.Types.ByteArrayType(null, targetMax == null ? ((int?)(255)) : targetMax, source.IsNullable());
        }

        public virtual object TransformValue(object @value) {
            Net.Vpc.Upa.SecretStrategy ss = secretStrategy;
            byte[] bytes = ss.Encode((byte[]) @value);
            return bytes;
        }

        public virtual object ReverseTransformValue(object @value) {
            return secretStrategy.Decode((byte[]) @value);
        }

        public virtual Net.Vpc.Upa.Types.DataType GetSourceType() {
            return sourceType;
        }

        public virtual Net.Vpc.Upa.Types.DataType GetTargetType() {
            return targetType;
        }


        public override string ToString() {
            return "SecretDataTypeTransform{" + secretStrategy + '}';
        }


        public virtual Net.Vpc.Upa.Types.DataTypeTransform Chain(Net.Vpc.Upa.Types.DataTypeTransform other) {
            return Net.Vpc.Upa.Impl.Transform.DataTypeTransformList.Chain(this, other);
        }
    }
}
