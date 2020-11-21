package net.thevpc.upa.impl.persistence.specific.interbase;

import net.thevpc.upa.PortabilityHint;
import net.thevpc.upa.Properties;
import net.thevpc.upa.exceptions.IllegalUPAArgumentException;
import net.thevpc.upa.impl.persistence.DefaultPersistenceStore;
import net.thevpc.upa.impl.persistence.SqlTypeName;
import net.thevpc.upa.impl.util.PlatformUtils;
import net.thevpc.upa.persistence.ConnectionProfile;
import net.thevpc.upa.persistence.DatabaseProduct;
import net.thevpc.upa.types.DataType;
import net.thevpc.upa.types.EnumType;
import net.thevpc.upa.types.TemporalOption;
import net.thevpc.upa.types.TemporalType;

import java.util.LinkedHashSet;
import java.util.Set;

@PortabilityHint(target = "C#", name = "suppress")
public class InterBasePersistenceStore extends DefaultPersistenceStore {

    public void configureStore() {
        super.configureStore();
        Properties map = getStoreParameters();
        map.setBoolean(PARAM_IS_COMPLEX_SELECT_SUPPORTED, Boolean.FALSE);
        map.setBoolean(PARAM_IS_FROM_CLAUSE_IN_UPDATE_STATMENT_SUPPORTED, Boolean.FALSE);
        map.setBoolean(PARAM_IS_FROM_CLAUSE_IN_DELETE_STATMENT_SUPPORTED, Boolean.FALSE);
        map.setBoolean(PARAM_IS_REFERENCING_SUPPORTED, Boolean.FALSE);
        map.setBoolean(PARAM_IS_VIEW_SUPPORTED, Boolean.FALSE);
        getSqlManager().register(new InterBaseSelectSQLProvider());
    }

    @Override
    public int getSupportLevel(ConnectionProfile connectionProfile, Properties parameters) {
        DatabaseProduct p = connectionProfile.getDatabaseProduct();
        if (p == DatabaseProduct.INTERBASE) {
            return 10;
        }
        return -1;
    }

    @Override
    public Set<String> getSupportedDrivers() {
        LinkedHashSet<String> valid = new LinkedHashSet<String>();
        return valid;
    }

    public SqlTypeName getSqlTypeName(DataType datatype) {
        Class platformType = datatype.getPlatformType();
        int length = datatype.getScale();
        int precision = datatype.getPrecision();
        if (PlatformUtils.isString(platformType)) {
            if (length <= 0) {
                length = 255;
            }
            if (length <= 32672) {
                return new SqlTypeName("VARCHAR", length);
            } else {
                return new SqlTypeName("CLOB");//return "NTEXT";
            }
        }
        if (PlatformUtils.isInt32(platformType)) {
            return new SqlTypeName("INT");
        }
        if (PlatformUtils.isInt8(platformType)) {
            return new SqlTypeName("SMALLINT");
        }
        if (PlatformUtils.isInt16(platformType)) {
            return new SqlTypeName("SMALLINT");
        }
        if (PlatformUtils.isInt64(platformType)) {
            return new SqlTypeName("NUMERIC");
        }
        if (PlatformUtils.isFloat32(platformType)) {
            return new SqlTypeName("FLOAT");
        }
        if (PlatformUtils.isFloat64(platformType)) {
            return new SqlTypeName("DOUBLE PRECISION");
        }
        if (PlatformUtils.isAnyNumber(platformType)) {
            return new SqlTypeName("NUMERIC");
        }
        if (PlatformUtils.isBool(platformType)) {
            return new SqlTypeName("INT");
        }

        if (datatype instanceof TemporalType) {
            TemporalOption temporalOption = ((TemporalType) datatype).getTemporalOption();
            if (temporalOption == null) {
                temporalOption = TemporalOption.DEFAULT;
            }
            switch (temporalOption) {
                case DATE:
                    return new SqlTypeName("DATE");
                case DATETIME:
                    return new SqlTypeName("TIMESTAMP");
                case TIMESTAMP:
                    return new SqlTypeName("TIMESTAMP");
                case TIME:
                    return new SqlTypeName("TIME");
                case MONTH:
                    return new SqlTypeName("DATE");
                case YEAR:
                    return new SqlTypeName("DATE");
                default: {
                    throw new IllegalUPAArgumentException("UNKNOWN_TYPE<" + platformType.getName() + "," + length + "," + precision + ">");
                }
            }
        }
        if (datatype instanceof EnumType) {
            //TODO should support marshalling types
            return new SqlTypeName("INT");
        }

        if (Object.class.equals(platformType) || PlatformUtils.isSerializable(platformType)) {
            return new SqlTypeName("BLOB"); // serialized form
        }
        throw new IllegalUPAArgumentException("UNKNOWN_TYPE<" + platformType.getName() + "," + length + "," + precision + ">");
    }

}
