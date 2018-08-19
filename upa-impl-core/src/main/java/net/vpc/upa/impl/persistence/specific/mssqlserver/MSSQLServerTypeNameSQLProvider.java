package net.vpc.upa.impl.persistence.specific.mssqlserver;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.exceptions.UPAIllegalArgumentException;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.types.*;
import net.vpc.upa.impl.persistence.SQLManager;
import net.vpc.upa.impl.persistence.shared.sql.AbstractSQLProvider;
import net.vpc.upa.impl.upql.ExpressionDeclarationList;
import net.vpc.upa.impl.upql.ext.expr.CompiledTypeName;
import net.vpc.upa.persistence.EntityExecutionContext;

/**
 * Created with IntelliJ IDEA.
 * User: vpc
 * Date: 8/15/12
 * Time: 11:46 PM
 * To change this template use File | Settings | File Templates.
 */
@PortabilityHint(target = "C#",name = "suppress")
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
        if (PlatformUtils.isString(platformType)) {
            if (length <= 0) {
                length = 255;
            }
            if (length <= 8000) {
                return "VARCHAR(" + length + ")";
            } else {
                return "NTEXT";
            }
        }
        if (PlatformUtils.isInt32(platformType)) {
            return "INT";
        }
        if (PlatformUtils.isInt8(platformType)) {
            return "SMALLINT";
        }
        if (PlatformUtils.isInt16(platformType)) {
            return "SMALLINT";
        }
        if (PlatformUtils.isInt64(platformType)) {
            return "NUMERIC";
        }
        if (PlatformUtils.isFloat32(platformType)) {
            return "FLOAT";
        }
        if (PlatformUtils.isFloat64(platformType)) {
            if (datatype instanceof DoubleType) {
                DoubleType n = ((DoubleType) datatype);
                return n.isFixedDigits() ? "DECIMAL(" + (n.getMaximumIntegerDigits() + n.getMaximumFractionDigits()) + "," + n.getMaximumFractionDigits() + ")" : "FLOAT";
            } else {
                return "FLOAT";
            }
        }
        if (PlatformUtils.isAnyNumber(platformType)) {
            return "NUMERIC";
        }
        if (PlatformUtils.isBool(platformType)) {
            return "INT";
        }

        if(datatype instanceof TemporalType){
            TemporalOption temporalOption = ((TemporalType) datatype).getTemporalOption();
            if(temporalOption==null){
                temporalOption=TemporalOption.DEFAULT;
            }
            switch (temporalOption){
                case DATE: return "DATE";
                case DATETIME: return "DATETIME";
                case TIMESTAMP: return "TIMESTAMP";
                case TIME: return "TIME";
                case MONTH: return "DATE";
                case YEAR: return "DATE";
                default:{
                    throw new IllegalArgumentException("Unsupported "+datatype);
                }
            }
        }
        if (datatype instanceof EnumType) {
            //TODO should support marshalling types
            return "INT";
        }
        if (Object.class.equals(platformType) || PlatformUtils.isSerializable(platformType)) {
            return "IMAGE"; // serialized form
        }
        throw new UPAIllegalArgumentException("UNKNOWN_TYPE<" + platformType.getName() + "," + length + "," + precision + ">");
    }

}
