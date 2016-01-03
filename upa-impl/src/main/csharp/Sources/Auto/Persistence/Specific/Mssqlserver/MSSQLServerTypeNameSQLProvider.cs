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



namespace Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver
{


    /**
     * Created with IntelliJ IDEA.
     * User: vpc
     * Date: 8/15/12
     * Time: 11:46 PM
     * To change this template use File | Settings | File Templates.
     */
    public class MSSQLServerTypeNameSQLProvider : Net.Vpc.Upa.Impl.Persistence.Shared.AbstractSQLProvider {

        public MSSQLServerTypeNameSQLProvider()  : base(typeof(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledTypeName)){

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
                    length = 256;
                }
                if (length > 8000) {
                    return "NTEXT";
                } else {
                    return "VARCHAR(" + length + ")";
                }
            }
            if ((typeof(int?)).Equals(platformType)) {
                return "INT";
            }
            if (typeof(byte?).Equals(platformType)) {
                return "SMALLINT";
            }
            if (typeof(short?).Equals(platformType)) {
                return "SMALLINT";
            }
            if ((typeof(long?)).Equals(platformType)) {
                return "NUMERIC";
            }
            if (typeof(float?).Equals(platformType)) {
                return "FLOAT";
            }
            if ((typeof(double?)).Equals(platformType)) {
                if (datatype is Net.Vpc.Upa.Types.DoubleType) {
                    Net.Vpc.Upa.Types.DoubleType n = ((Net.Vpc.Upa.Types.DoubleType) datatype);
                    return n.IsFixedDigits() ? "DECIMAL(" + (n.GetMaximumIntegerDigits() + n.GetMaximumFractionDigits()) + "," + n.GetMaximumFractionDigits() + ")" : "FLOAT";
                } else {
                    return "FLOAT";
                }
            }
            if ((typeof(object)).IsAssignableFrom(platformType)) {
                return "NUMERIC";
            }
            if ((typeof(bool?)).Equals(platformType)) {
                return "INT";
            }
            if (typeof(Net.Vpc.Upa.Types.Temporal).IsAssignableFrom(platformType)) {
                if (typeof(Net.Vpc.Upa.Types.Time).IsAssignableFrom(platformType) || typeof(Net.Vpc.Upa.Types.Time).IsAssignableFrom(platformType)) {
                    return "TIME";
                } else if (typeof(Net.Vpc.Upa.Types.Date).IsAssignableFrom(platformType) || typeof(Net.Vpc.Upa.Types.Date).IsAssignableFrom(platformType) || typeof(Net.Vpc.Upa.Types.Month).IsAssignableFrom(platformType) || typeof(Net.Vpc.Upa.Types.Year).IsAssignableFrom(platformType)) {
                    return "DATE";
                } else if (typeof(Net.Vpc.Upa.Types.Timestamp).IsAssignableFrom(platformType)) {
                    //                return "DATE";
                    return "TIMESTAMP";
                } else {
                    //                return "DATE";
                    return "DATETIME";
                }
            }
            if (datatype is Net.Vpc.Upa.Types.EnumType) {
                //TODO should support marshalling types
                return "INT";
            }
            //        if(ImageData.class.equals(platformType)){
            //            return "IMAGE"; // serialized form
            //        }
            //        if(FileData.class.equals(platformType)){
            //            return "IMAGE"; // serialized form
            //        }
            if (typeof(object).Equals(platformType) || Net.Vpc.Upa.Impl.Util.PlatformUtils.IsSerializable(platformType)) {
                return "IMAGE";
            }
            // serialized form
            throw new System.ArgumentException ("UNKNOWN_TYPE<" + (platformType).FullName + "," + length + "," + precision + ">");
        }
    }
}
