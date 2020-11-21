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
    public class SecretDataTypeTransform : Net.TheVpc.Upa.Types.DataTypeTransform {

        private Net.TheVpc.Upa.SecretStrategy secretStrategy;

        private Net.TheVpc.Upa.Types.DataType sourceType;

        private Net.TheVpc.Upa.Types.DataType targetType;

        public SecretDataTypeTransform(Net.TheVpc.Upa.SecretStrategy secretStrategy, Net.TheVpc.Upa.Types.DataType source, int? targetMax) {
            this.secretStrategy = secretStrategy;
            this.sourceType = source;
            this.targetType = new Net.TheVpc.Upa.Types.ByteArrayType(null, targetMax == null ? ((Net.TheVpc.Upa.Types.DataType)(255)) : targetMax, source.IsNullable());
        }

        public virtual object TransformValue(object @value) {
            Net.TheVpc.Upa.SecretStrategy ss = secretStrategy;
            byte[] bytes = ss.Encode((byte[]) @value);
            return bytes;
        }

        public virtual object ReverseTransformValue(object @value) {
            return secretStrategy.Decode((byte[]) @value);
        }

        public virtual Net.TheVpc.Upa.Types.DataType GetSourceType() {
            return sourceType;
        }

        public virtual Net.TheVpc.Upa.Types.DataType GetTargetType() {
            return targetType;
        }


        public override string ToString() {
            return "SecretDataTypeTransform{" + secretStrategy + '}';
        }


        public virtual Net.TheVpc.Upa.Types.DataTypeTransform Chain(Net.TheVpc.Upa.Types.DataTypeTransform other) {
            return Net.TheVpc.Upa.Impl.Transform.DataTypeTransformList.Chain(this, other);
        }
    }
}
