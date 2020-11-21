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
    public sealed class IdentityDataTypeTransform : Net.TheVpc.Upa.Types.DataTypeTransform {

        public static readonly Net.TheVpc.Upa.Types.DataTypeTransform VOID = new Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform(Net.TheVpc.Upa.Types.TypesFactory.VOID);

        public static readonly Net.TheVpc.Upa.Types.DataTypeTransform STRING = new Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform(Net.TheVpc.Upa.Types.TypesFactory.STRING);

        public static readonly Net.TheVpc.Upa.Types.DataTypeTransform STRING_UNLIMITED = new Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform(Net.TheVpc.Upa.Types.StringType.UNLIMITED);

        public static readonly Net.TheVpc.Upa.Types.DataTypeTransform BOOLEAN = new Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform(Net.TheVpc.Upa.Types.TypesFactory.BOOLEAN);

        public static readonly Net.TheVpc.Upa.Types.DataTypeTransform BIGINT = new Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform(Net.TheVpc.Upa.Types.TypesFactory.BIGINT);

        public static readonly Net.TheVpc.Upa.Types.DataTypeTransform INT = new Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform(Net.TheVpc.Upa.Types.TypesFactory.INT);

        public static readonly Net.TheVpc.Upa.Types.DataTypeTransform LONG = new Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform(Net.TheVpc.Upa.Types.TypesFactory.LONG);



        public static readonly Net.TheVpc.Upa.Types.DataTypeTransform DOUBLE = new Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform(Net.TheVpc.Upa.Types.TypesFactory.DOUBLE);

        public static readonly Net.TheVpc.Upa.Types.DataTypeTransform FLOAT = new Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform(Net.TheVpc.Upa.Types.TypesFactory.FLOAT);

        public static readonly Net.TheVpc.Upa.Types.DataTypeTransform DATE = new Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform(Net.TheVpc.Upa.Types.TypesFactory.DATE);

        public static readonly Net.TheVpc.Upa.Types.DataTypeTransform TIME = new Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform(Net.TheVpc.Upa.Types.TypesFactory.TIME);

        public static readonly Net.TheVpc.Upa.Types.DataTypeTransform DATETIME = new Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform(Net.TheVpc.Upa.Types.TypesFactory.DATETIME);

        public static readonly Net.TheVpc.Upa.Types.DataTypeTransform OBJECT = new Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform(Net.TheVpc.Upa.Types.TypesFactory.OBJECT);

        private readonly Net.TheVpc.Upa.Types.DataType sourceType;

        public IdentityDataTypeTransform(Net.TheVpc.Upa.Types.DataType sourceType) {
            this.sourceType = sourceType;
        }

        public object TransformValue(object @value) {
            return @value;
        }

        public object ReverseTransformValue(object @value) {
            return @value;
        }

        public Net.TheVpc.Upa.Types.DataType GetSourceType() {
            return sourceType;
        }

        public Net.TheVpc.Upa.Types.DataType GetTargetType() {
            return sourceType;
        }


        public override string ToString() {
            return System.Convert.ToString(sourceType);
        }


        public Net.TheVpc.Upa.Types.DataTypeTransform Chain(Net.TheVpc.Upa.Types.DataTypeTransform other) {
            if (other == null) {
                return this;
            }
            return other;
        }

        public static Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform ForNativeType(System.Type clazz) {
            return new Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform(Net.TheVpc.Upa.Types.TypesFactory.ForPlatformType(clazz));
        }

        public static Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform ForDataType(Net.TheVpc.Upa.Types.DataType sourceType) {
            return new Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform(sourceType);
        }
    }
}
