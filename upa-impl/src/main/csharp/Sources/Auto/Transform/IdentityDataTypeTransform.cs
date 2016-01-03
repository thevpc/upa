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
    public sealed class IdentityDataTypeTransform : Net.Vpc.Upa.Types.DataTypeTransform {

        public static readonly Net.Vpc.Upa.Types.DataTypeTransform VOID = new Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform(Net.Vpc.Upa.Types.TypesFactory.VOID);

        public static readonly Net.Vpc.Upa.Types.DataTypeTransform STRING = new Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform(Net.Vpc.Upa.Types.TypesFactory.STRING);

        public static readonly Net.Vpc.Upa.Types.DataTypeTransform STRING_UNLIMITED = new Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform(Net.Vpc.Upa.Types.StringType.UNLIMITED);

        public static readonly Net.Vpc.Upa.Types.DataTypeTransform BOOLEAN = new Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform(Net.Vpc.Upa.Types.TypesFactory.BOOLEAN);

        public static readonly Net.Vpc.Upa.Types.DataTypeTransform BIGINT = new Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform(Net.Vpc.Upa.Types.TypesFactory.BIGINT);

        public static readonly Net.Vpc.Upa.Types.DataTypeTransform INT = new Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform(Net.Vpc.Upa.Types.TypesFactory.INT);

        public static readonly Net.Vpc.Upa.Types.DataTypeTransform LONG = new Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform(Net.Vpc.Upa.Types.TypesFactory.LONG);

        public static readonly Net.Vpc.Upa.Types.DataTypeTransform BIGDECIMAL = new Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform(Net.Vpc.Upa.Types.TypesFactory.BIGDECIMAL);

        public static readonly Net.Vpc.Upa.Types.DataTypeTransform DOUBLE = new Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform(Net.Vpc.Upa.Types.TypesFactory.DOUBLE);

        public static readonly Net.Vpc.Upa.Types.DataTypeTransform FLOAT = new Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform(Net.Vpc.Upa.Types.TypesFactory.FLOAT);

        public static readonly Net.Vpc.Upa.Types.DataTypeTransform DATE = new Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform(Net.Vpc.Upa.Types.TypesFactory.DATE);

        public static readonly Net.Vpc.Upa.Types.DataTypeTransform TIME = new Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform(Net.Vpc.Upa.Types.TypesFactory.TIME);

        public static readonly Net.Vpc.Upa.Types.DataTypeTransform DATETIME = new Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform(Net.Vpc.Upa.Types.TypesFactory.DATETIME);

        public static readonly Net.Vpc.Upa.Types.DataTypeTransform OBJECT = new Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform(Net.Vpc.Upa.Types.TypesFactory.OBJECT);

        private readonly Net.Vpc.Upa.Types.DataType sourceType;

        public IdentityDataTypeTransform(Net.Vpc.Upa.Types.DataType sourceType) {
            this.sourceType = sourceType;
        }

        public object TransformValue(object @value) {
            return @value;
        }

        public object ReverseTransformValue(object @value) {
            return @value;
        }

        public Net.Vpc.Upa.Types.DataType GetSourceType() {
            return sourceType;
        }

        public Net.Vpc.Upa.Types.DataType GetTargetType() {
            return sourceType;
        }


        public override string ToString() {
            return System.Convert.ToString(sourceType);
        }


        public Net.Vpc.Upa.Types.DataTypeTransform Chain(Net.Vpc.Upa.Types.DataTypeTransform other) {
            if (other == null) {
                return this;
            }
            return other;
        }

        public static Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform ForNativeType(System.Type clazz) {
            return new Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform(Net.Vpc.Upa.Types.TypesFactory.ForPlatformType(clazz));
        }
    }
}
