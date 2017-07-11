package net.vpc.upa.impl.persistence.specific.oracle;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.exceptions.UPAIllegalArgumentException;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.types.*;
import net.vpc.upa.impl.persistence.SQLManager;
import net.vpc.upa.impl.persistence.shared.sql.AbstractSQLProvider;
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
        Class platformType = datatype.getPlatformType();
        int length = datatype.getScale();
        int precision = datatype.getPrecision();
        if (platformType.equals(String.class)) {
            if (length <= 0)
                length = 256;
            if (length > 8000) {
                return "BLOB";//return "NTEXT";
            } else {
                return "VARCHAR2(" + length + ")";
            }
        }
        if ((Integer.class).equals(platformType))
            return "INT";
        if (Byte.class.equals(platformType))
            return "SMALLINT";
        if (Short.class.equals(platformType))
            return "SMALLINT";
        if ((Long.class).equals(platformType))
            return "NUMBER";
        if (Float.class.equals(platformType))
            return "NUMBER";
        if ((Double.class).equals(platformType)) {
            if (datatype instanceof NumberType) {
                DoubleType n = ((DoubleType) datatype);
                return n.isFixedDigits() ? "NUMBER(" + (n.getMaximumIntegerDigits() + n.getMaximumFractionDigits()) + "," + n.getMaximumFractionDigits() + ")" : "NUMBER";
            } else {
                return "NUMBER";
            }
        }
        if ((Number.class).isAssignableFrom(platformType))
            return "NUMBER";
        if ((Boolean.class).equals(platformType))
            return "INT";
        if (platformType.equals(java.util.Date.class) || platformType.equals(java.sql.Date.class)) {
            return "DATE";
        }
        if(datatype instanceof EnumType){
            //TODO should support marshalling types
            return "INT";
        }
        if (Object.class.equals(platformType) || PlatformUtils.isSerializable(platformType)) {
            return "BLOB"; // serialized form
        }
        throw new UPAIllegalArgumentException("UNKNOWN_TYPE<" + platformType.getName() + "," + length + "," + precision + ">");
    }

}
