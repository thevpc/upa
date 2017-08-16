package net.vpc.upa.impl.persistence.specific.mysql;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.exceptions.UPAIllegalArgumentException;
import net.vpc.upa.impl.persistence.SQLManager;
import net.vpc.upa.impl.persistence.shared.sql.AbstractSQLProvider;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.compiledexpression.CompiledTypeName;
import net.vpc.upa.persistence.EntityExecutionContext;

import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.types.EnumType;
import net.vpc.upa.types.DataType;
import net.vpc.upa.types.TemporalOption;
import net.vpc.upa.types.TemporalType;

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
            /**
             * Values in VARCHAR columns are variable-length strings.
             * The length can be specified as a value from 0 to 255 before MySQL 5.0.3,
             * and 0 to 65,535 in 5.0.3 and later versions.
             * The effective maximum length of a VARCHAR in MySQL
             * 5.0.3 and later is subject to the maximum
             * row size (65,535 bytes, which is shared among all columns)
             * and the character set used.
             */
                //will consider mysql>=5.0.3
            if(length<=4096){
                return "VARCHAR(" + length + ")";
            }if(length <= 65535) {
                return "TEXT";
            }else if(length <= 1677215){
                return "MEDIUMTEXT";
            }else {
                return "LONGTEXT";
            }
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
            return "BLOB"; // serialized form
        }
        throw new UPAIllegalArgumentException("UNKNOWN_TYPE<" + platformType.getName() + "," + length + "," + precision + ">");
    }

}
