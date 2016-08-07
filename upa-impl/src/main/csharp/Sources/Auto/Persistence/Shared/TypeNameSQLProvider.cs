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



namespace Net.Vpc.Upa.Impl.Persistence.Shared
{


    /**
     * Created with IntelliJ IDEA. User: vpc Date: 8/15/12 Time: 11:46 PM To change
     * this template use File | Settings | File Templates.
     */
    public class TypeNameSQLProvider : Net.Vpc.Upa.Impl.Persistence.Shared.AbstractSQLProvider {

        public TypeNameSQLProvider()  : base(typeof(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledTypeName)){

        }


        public override string GetSQL(object oo, Net.Vpc.Upa.Persistence.EntityExecutionContext qlContext, Net.Vpc.Upa.Impl.Persistence.SQLManager sqlManager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledTypeName o = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledTypeName) oo;
            return GetSqlTypeName(o.GetTypeTransform().GetTargetType());
        }

        public virtual string GetSqlTypeName(Net.Vpc.Upa.Types.DataType datatype) {
            System.Type platformType = datatype.GetPlatformType();
            int length = datatype.GetScale();
            int precision = datatype.GetPrecision();
            if (platformType.Equals(typeof(string))) {
                if (length <= 0) {
                    length = 255;
                }
                return "VARCHAR(" + length + ")";
            }
            if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsInt32(platformType)) {
                return "INT";
            }
            if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsInt8(platformType)) {
                return "SMALLINT";
            }
            if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsInt16(platformType)) {
                return "SMALLINT";
            }
            if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsInt64(platformType)) {
                return "NUMERIC";
            }
            if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsFloat32(platformType)) {
                return "FLOAT";
            }
            if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsFloat64(platformType)) {
                return "FLOAT";
            }
            if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsAnyNumber(platformType)) {
                return "NUMERIC";
            }
            if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsBool(platformType)) {
                return "INT";
            }
            if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsAnyDate(platformType)) {
                if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsTime(platformType)) {
                    return "TIME";
                } else if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsTimestamp(platformType)) {
                    return "TIMESTAMP";
                } else if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsDateTime(platformType)) {
                    return "DATETIME";
                } else if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsDateOnly(platformType)) {
                    return "DATE";
                }
            }
            if (typeof(object).Equals(platformType) || Net.Vpc.Upa.Impl.Util.PlatformUtils.IsSerializable(platformType)) {
                return "BLOB";
            }
            // serialized form
            throw new System.ArgumentException ("UNKNOWN_TYPE<" + (platformType).FullName + "," + length + "," + precision + ">");
        }
    }
}
