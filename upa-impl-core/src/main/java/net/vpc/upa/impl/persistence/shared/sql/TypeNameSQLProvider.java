package net.vpc.upa.impl.persistence.shared.sql;

import net.vpc.upa.exceptions.UPAIllegalArgumentException;
import net.vpc.upa.impl.persistence.SQLManager;
import net.vpc.upa.impl.upql.ExpressionDeclarationList;
import net.vpc.upa.impl.upql.ext.expr.CompiledTypeName;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.types.DataType;
import net.vpc.upa.types.TemporalOption;
import net.vpc.upa.types.TemporalType;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/15/12 Time: 11:46 PM To change
 * this template use File | Settings | File Templates.
 */
public class TypeNameSQLProvider extends AbstractSQLProvider {

    public TypeNameSQLProvider() {
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
                length = 255;
            }
            return "VARCHAR(" + length + ")";
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
            return "FLOAT";
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
        if (Object.class
                .equals(platformType) || PlatformUtils.isSerializable(platformType)) {
            return "BLOB"; // serialized form
        }
        throw new UPAIllegalArgumentException(
                "UNKNOWN_TYPE<" + platformType.getName() + "," + length + "," + precision + ">");
    }

}
