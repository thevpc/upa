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
    public class PasswordDataTypeTransform : Net.TheVpc.Upa.Types.DataTypeTransform {

        private object cipherValue;

        private Net.TheVpc.Upa.PasswordStrategy passwordStrategy;

        private Net.TheVpc.Upa.Types.DataType sourceType;

        private Net.TheVpc.Upa.Types.DataType targetType;

        public PasswordDataTypeTransform(Net.TheVpc.Upa.PasswordStrategy passwordStrategy, object cipherValue, Net.TheVpc.Upa.Types.DataType sourceType) {
            this.passwordStrategy = passwordStrategy;
            this.cipherValue = cipherValue;
            this.sourceType = sourceType;
            int max = passwordStrategy.GetMaxSize();
            this.targetType = new Net.TheVpc.Upa.Types.StringType(null, 0, (max <= 0) ? 255 : max, sourceType.IsNullable());
        }

        public virtual object TransformValue(object @value) {
            //        if (UPAUtils.equals(value, cipherValue)) {
            //            return PasswordTransformConfig.NO_VALUE;
            //        }
            return @value == null ? null : passwordStrategy.Encode((string) @value);
        }

        public virtual object ReverseTransformValue(object @value) {
            return cipherValue;
        }

        public virtual Net.TheVpc.Upa.Types.DataType GetSourceType() {
            return sourceType;
        }

        public virtual Net.TheVpc.Upa.Types.DataType GetTargetType() {
            return targetType;
        }

        public virtual object GetCipherValue() {
            return cipherValue;
        }


        public override string ToString() {
            return "PasswordDataTypeTransform{" + targetType + '}';
        }


        public virtual Net.TheVpc.Upa.Types.DataTypeTransform Chain(Net.TheVpc.Upa.Types.DataTypeTransform other) {
            return Net.TheVpc.Upa.Impl.Transform.DataTypeTransformList.Chain(this, other);
        }
    }
}
