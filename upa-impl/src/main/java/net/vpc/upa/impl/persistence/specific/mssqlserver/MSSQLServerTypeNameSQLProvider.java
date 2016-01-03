package net.vpc.upa.impl.persistence.specific.mssqlserver;

import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.types.*;
import net.vpc.upa.impl.persistence.SQLManager;
import net.vpc.upa.impl.persistence.shared.AbstractSQLProvider;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.compiledexpression.CompiledTypeName;
import net.vpc.upa.persistence.EntityExecutionContext;

/**
 * Created with IntelliJ IDEA.
 * User: vpc
 * Date: 8/15/12
 * Time: 11:46 PM
 * To change this template use File | Settings | File Templates.
 */
public class MSSQLServerTypeNameSQLProvider extends AbstractSQLProvider {
    public MSSQLServerTypeNameSQLProvider() {
        super(CompiledTypeName.class);
    }

    @Override
    public String getSQL(Object oo, EntityExecutionContext qlContext, SQLManager sqlManager, ExpressionDeclarationList declarations) {
        CompiledTypeName o = (CompiledTypeName) oo;
        return getSqlTypeName(o.getTypeTransform().getTargetType());
    }

    public String getSqlTypeName(DataType datatype) {
        Class platformType = datatype.getPlatformType();
        int length = datatype.getScale();
        int precision = datatype.getPrecision();
        if (platformType.equals(String.class)) {
            if (length <= 0) {
                length = 256;
            }
            if (length > 8000) {
                return "NTEXT";
            } else {
                return "VARCHAR(" + length + ")";
            }
        }
        if ((Integer.class).equals(platformType)) {
            return "INT";
        }
        if (Byte.class.equals(platformType)) {
            return "SMALLINT";
        }
        if (Short.class.equals(platformType)) {
            return "SMALLINT";
        }
        if ((Long.class).equals(platformType)) {
            return "NUMERIC";
        }
        if (Float.class.equals(platformType)) {
            return "FLOAT";
        }
        if ((Double.class).equals(platformType)) {
            if (datatype instanceof DoubleType) {
                DoubleType n = ((DoubleType) datatype);
                return n.isFixedDigits() ? "DECIMAL(" + (n.getMaximumIntegerDigits() + n.getMaximumFractionDigits()) + "," + n.getMaximumFractionDigits() + ")" : "FLOAT";
            } else {
                return "FLOAT";
            }
        }
        if ((Number.class).isAssignableFrom(platformType)) {
            return "NUMERIC";
        }
        if ((Boolean.class).equals(platformType)) {
            return "INT";
        }
        if (java.util.Date.class.isAssignableFrom(platformType)) {
            if (java.sql.Time.class.isAssignableFrom(platformType) || Time.class.isAssignableFrom(platformType)) {
                return "TIME";
            } else if (java.sql.Date.class.isAssignableFrom(platformType)
                    || Date.class.isAssignableFrom(platformType)
                    || Month.class.isAssignableFrom(platformType)
                    || Year.class.isAssignableFrom(platformType)
                    ) {
                return "DATE";
            } else if (java.sql.Timestamp.class.isAssignableFrom(platformType)) {
//                return "DATE";
                return "TIMESTAMP";
            } else {
//                return "DATE";
                return "DATETIME";
            }
        }
        if(datatype instanceof EnumType){
            //TODO should support marshalling types
            return "INT";
        }
//        if(ImageData.class.equals(platformType)){
//            return "IMAGE"; // serialized form
//        }
//        if(FileData.class.equals(platformType)){
//            return "IMAGE"; // serialized form
//        }
        if (Object.class.equals(platformType) || PlatformUtils.isSerializable(platformType)) {
            return "IMAGE"; // serialized form
        }
        throw new IllegalArgumentException("UNKNOWN_TYPE<" + platformType.getName() + "," + length + "," + precision + ">");
    }

}
