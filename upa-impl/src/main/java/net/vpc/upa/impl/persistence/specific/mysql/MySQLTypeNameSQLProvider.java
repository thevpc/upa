package net.vpc.upa.impl.persistence.specific.mysql;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.types.DataType;
import net.vpc.upa.impl.persistence.SQLManager;
import net.vpc.upa.impl.persistence.shared.AbstractSQLProvider;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.compiledexpression.CompiledTypeName;
import net.vpc.upa.persistence.EntityExecutionContext;

import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.types.EnumType;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/15/12 Time: 11:46 PM To change
 * this template use File | Settings | File Templates.
 */
@PortabilityHint(target = "C#", name = "suppress")
public class MySQLTypeNameSQLProvider extends AbstractSQLProvider {

    public MySQLTypeNameSQLProvider() {
        super(CompiledTypeName.class);
    }

    @Override
    public String getSQL(Object oo, EntityExecutionContext qlContext, SQLManager sqlManager, ExpressionDeclarationList declarations) {
        CompiledTypeName o = (CompiledTypeName) oo;
        return getSqlTypeName(o.getTypeTransform().getTargetType(),qlContext);
    }

    public String getSqlTypeName(DataType datatype,EntityExecutionContext qlContext) {
        String databaseProductVersion = qlContext.getPersistenceStore().getProperties().getString("databaseProductVersion");
        if(databaseProductVersion==null){
            databaseProductVersion="";
        }
        Class platformType = datatype.getPlatformType();
        int length = datatype.getScale();
        int precision = datatype.getPrecision();
        if (platformType.equals(String.class)) {
            if (length <= 0) {
                length = 255;
            }
            
            return length > 255 ? "BLOB" : "VARCHAR(" + length + ")";
        }
        if (PlatformUtils.isInt32(platformType)) {
            return "INT";
        }
        if (PlatformUtils.isInt16(platformType)) {
            return "SMALLINT";
        }
        if (PlatformUtils.isInt8(platformType)) {
            return "SMALLINT";
        }
        if (PlatformUtils.isInt64(platformType)) {
            return "NUMERIC";
        }
        if (PlatformUtils.isFloat32(platformType)) {
            return "FLOAT";
        }
        if (PlatformUtils.isFloat64(platformType)) {
            return "FLOAT";
        }
        if ((Number.class).isAssignableFrom(platformType)) {
            return "NUMERIC";
        }
        if (PlatformUtils.isBool(platformType)) {
            return "INT";
        }
        if (PlatformUtils.isAnyDate(platformType)) {
            if (PlatformUtils.isTime(platformType)) {
                return "TIME";
            } else if (PlatformUtils.isTimestamp(platformType)) {
                return "TIMESTAMP";
            } else if (PlatformUtils.isDateTime(platformType)) {
                return "DATETIME";
            } else if (PlatformUtils.isDateOnly(platformType)) {
                return "DATE";
            }
        }
        if (datatype instanceof EnumType) {
            //TODO should support marshalling types
            return "INT";
        }
        if (Object.class.equals(platformType) || PlatformUtils.isSerializable(platformType)) {
            return "BLOB"; // serialized form
        }
        throw new IllegalArgumentException("UNKNOWN_TYPE<" + platformType.getName() + "," + length + "," + precision + ">");
    }

}
