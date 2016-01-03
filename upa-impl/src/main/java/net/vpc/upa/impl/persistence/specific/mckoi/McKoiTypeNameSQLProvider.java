package net.vpc.upa.impl.persistence.specific.mckoi;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.types.DataType;
import net.vpc.upa.impl.persistence.SQLManager;
import net.vpc.upa.impl.persistence.TypeMarshaller;
import net.vpc.upa.impl.persistence.shared.AbstractSQLProvider;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.compiledexpression.CompiledTypeName;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.types.EnumType;

/**
 * Created with IntelliJ IDEA.
 * User: vpc
 * Date: 8/15/12
 * Time: 11:46 PM
 * To change this template use File | Settings | File Templates.
 */
@PortabilityHint(target = "C#", name = "suppress")
public class McKoiTypeNameSQLProvider extends AbstractSQLProvider {
    public McKoiTypeNameSQLProvider() {
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
            return "VARCHAR(" + length + ")";
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
            return "FLOAT";
        }
        if ((Number.class).isAssignableFrom(platformType)) {
            return "NUMERIC";
        }
        if ((Boolean.class).equals(platformType)) {
            return "INT";
        }
        if(datatype instanceof EnumType){
            //TODO should support marshalling types
            return "INT";
        }
        if (platformType.equals(java.util.Date.class) || platformType.equals(java.sql.Date.class)) {
            return "DATE";
        }
        else {
            throw new IllegalArgumentException("UNKNOWN_TYPE<" + platformType.getName() + "," + length + "," + precision + ">");
        }
    }

}
