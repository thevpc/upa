package net.vpc.upa.impl.persistence.specific.oracle;

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
@PortabilityHint(target = "C#", name = "suppress")
public class OracleTypeNameSQLProvider extends AbstractSQLProvider {
    public OracleTypeNameSQLProvider() {
        super(CompiledTypeName.class);
    }

    @Override
    public String getSQL(Object oo, EntityExecutionContext qlContext, SQLManager sqlManager, ExpressionDeclarationList declarations) {
        CompiledTypeName o = (CompiledTypeName) oo;
        return getSqlTypeName(o.getTypeTransform().getTargetType());
    }

    public String getSqlTypeName(DataType datatype) {
//        String databaseProductVersion = qlContext.getPersistenceStore().getStoreParameters().getString("databaseProductVersion");
//        if(databaseProductVersion==null){
//            databaseProductVersion="";
//        }
        Class platformType = datatype.getPlatformType();
        int length = datatype.getScale();
        int precision = datatype.getPrecision();
        if (PlatformUtils.isString(platformType)) {
            if (length <= 0)
                length = 256;
            if (length <= 8000) {
                return "VARCHAR2(" + length + ")";
            } else {
                return "BLOB";
            }
        }
        if (PlatformUtils.isInt8(platformType)) {
            return "SMALLINT";
        }
        if (PlatformUtils.isInt16(platformType)) {
            return "SMALLINT";
        }
        if (PlatformUtils.isInt32(platformType)) {
            return "INT";
        }
        if (PlatformUtils.isInt64(platformType)) {
            return "NUMBER";
        }
        if (PlatformUtils.isFloat32(platformType)) {
            return "NUMBER";
        }
        if (PlatformUtils.isFloat64(platformType)) {
            if (datatype instanceof NumberType) {
                DoubleType n = ((DoubleType) datatype);
                return n.isFixedDigits() ? "NUMBER(" + (n.getMaximumIntegerDigits() + n.getMaximumFractionDigits()) + "," + n.getMaximumFractionDigits() + ")" : "NUMBER";
            } else {
                return "NUMBER";
            }
        }
        if (PlatformUtils.isAnyNumber(platformType)) {
            return "NUMBER";
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
                case DATETIME: return "TIMESTAMP";
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
            return "BLOB"; // serialized form
        }
        throw new UPAIllegalArgumentException("UNKNOWN_TYPE<" + platformType.getName() + "," + length + "," + precision + ">");
    }

}
