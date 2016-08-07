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
    public class PasswordDataTypeTransform : Net.Vpc.Upa.Types.DataTypeTransform {

        private object cipherValue;

        private Net.Vpc.Upa.PasswordStrategy passwordStrategy;

        private Net.Vpc.Upa.Types.DataType sourceType;

        private Net.Vpc.Upa.Types.DataType targetType;

        public PasswordDataTypeTransform(Net.Vpc.Upa.PasswordStrategy passwordStrategy, object cipherValue, Net.Vpc.Upa.Types.DataType sourceType) {
            this.passwordStrategy = passwordStrategy;
            this.cipherValue = cipherValue;
            this.sourceType = sourceType;
            int max = passwordStrategy.GetMaxSize();
            this.targetType = new Net.Vpc.Upa.Types.StringType(null, 0, (max <= 0) ? 255 : max, sourceType.IsNullable());
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

        public virtual Net.Vpc.Upa.Types.DataType GetSourceType() {
            return sourceType;
        }

        public virtual Net.Vpc.Upa.Types.DataType GetTargetType() {
            return targetType;
        }

        public virtual object GetCipherValue() {
            return cipherValue;
        }


        public override string ToString() {
            return "PasswordDataTypeTransform{" + targetType + '}';
        }


        public virtual Net.Vpc.Upa.Types.DataTypeTransform Chain(Net.Vpc.Upa.Types.DataTypeTransform other) {
            return Net.Vpc.Upa.Impl.Transform.DataTypeTransformList.Chain(this, other);
        }
    }
}
