package net.vpc.upa.impl.persistence.specific.oracle;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import net.vpc.upa.filters.FieldFilters;
import net.vpc.upa.persistence.ConnectionProfile;
import net.vpc.upa.persistence.DatabaseProduct;
import net.vpc.upa.types.*;
import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.persistence.DefaultPersistenceStore;
import net.vpc.upa.impl.persistence.shared.marshallers.ConstantDataMarshallerFactory;
import net.vpc.upa.impl.persistence.shared.sql.NullValANSISQLProvider;
import net.vpc.upa.impl.persistence.shared.sql.SignANSISQLProvider;

import java.util.LinkedHashSet;
import java.util.List;
import java.util.Set;
import net.vpc.upa.exceptions.IllegalUPAArgumentException;
import net.vpc.upa.impl.persistence.DefaultViewKeyPersistenceDefinition;
import net.vpc.upa.impl.persistence.SqlTypeName;
import net.vpc.upa.persistence.ColumnPersistenceDefinition;

import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.persistence.ViewPersistenceDefinition;

@PortabilityHint(target = "C#", name = "suppress")
public class OraclePersistenceStore extends DefaultPersistenceStore {

    public OraclePersistenceStore() {
    }

    @Override
    public int getSupportLevel(ConnectionProfile connectionProfile, Properties parameters) {
        DatabaseProduct p = connectionProfile.getDatabaseProduct();
        if (p == DatabaseProduct.ORACLE) {
            return 10;
        }
        return -1;
    }

    public void configureStore() {
        super.configureStore();
        Properties map = getStoreParameters();
        map.setBoolean(PARAM_IS_COMPLEX_SELECT_SUPPORTED, Boolean.TRUE);
        map.setBoolean(PARAM_IS_UPDATE_COMPLEX_VALUES_STATEMENT_SUPPORTED, Boolean.TRUE);
        map.setBoolean(PARAM_IS_UPDATE_COMPLEX_VALUES_INCLUDING_UPDATED_TABLE_SUPPORTED, Boolean.TRUE);
        map.setBoolean(PARAM_IS_FROM_CLAUSE_IN_UPDATE_STATMENT_SUPPORTED, Boolean.FALSE);
        map.setBoolean(PARAM_IS_FROM_CLAUSE_IN_DELETE_STATMENT_SUPPORTED, Boolean.FALSE);
        map.setBoolean(PARAM_IS_REFERENCING_SUPPORTED, Boolean.TRUE);
        map.setBoolean(PARAM_IS_VIEW_SUPPORTED, Boolean.TRUE);
        map.setBoolean(PARAM_IS_TOP_SUPPORTED, Boolean.FALSE);
        getSqlManager().register(new OracleCoalesceSQLProvider());
        getSqlManager().register(new OracleConcatSQLProvider());
        getSqlManager().register(new OracleDateTruncSQLProvider());
        getSqlManager().register(new OracleDateAddSQLProvider());
        getSqlManager().register(new OracleDatePartSQLProvider());
        getSqlManager().register(new OracleDateDiffSQLProvider());
        getSqlManager().register(new OracleDecodeSQLProvider());
        getSqlManager().register(new OracleIfSQLProvider());
        getSqlManager().register(new SignANSISQLProvider());
        getSqlManager().register(new OracleStrLenSQLProvider());
        getSqlManager().register(new OracleCurrentTimestampSQLProvider());
        getSqlManager().register(new OracleMonthStartSQLProvider());
        getSqlManager().register(new OracleMonthEndSQLProvider());
        getSqlManager().register(new OracleCastSQLProvider());
        getSqlManager().register(new OracleD2VSQLProvider());
        getSqlManager().register(new NullValANSISQLProvider());
        getSqlManager().register(new OracleSelectSQLProvider());

        OracleSerializablePlatformObjectMarshaller oracleSerializablePlatformObjectWrapper = new OracleSerializablePlatformObjectMarshaller(getMarshallManager());

        getMarshallManager().setTypeMarshaller(Float.class, new OracleFloatAsDoubleMarshaller(getMarshallManager()));
//        getMarshallManager().setTypeMarshaller(ImageData.class, oracleSerializableJavaObjectWrapper);
        getMarshallManager().setTypeMarshaller(Object.class, oracleSerializablePlatformObjectWrapper);
        getMarshallManager().setTypeMarshaller(FileData.class, oracleSerializablePlatformObjectWrapper);
        getMarshallManager().setTypeMarshaller(DataType.class, oracleSerializablePlatformObjectWrapper);
        ConstantDataMarshallerFactory blobfactory = new ConstantDataMarshallerFactory(getMarshallManager(), oracleSerializablePlatformObjectWrapper);
        getMarshallManager().setTypeMarshallerFactory(DataType.class, blobfactory);

        getMarshallManager().setTypeMarshallerFactory(ImageType.class, blobfactory);
        getMarshallManager().setTypeMarshallerFactory(FileType.class, blobfactory);
//        DataWrapperUtils.setWrapperFactory(DateType.class, F_DATE);
//        DataWrapperUtils.setWrapperFactory(NumberType.class, F_NUMBER);
//        DataWrapperUtils.setWrapperFactory(StringType.class, F_STRING);
//        DataWrapperUtils.setWrapperFactory(BooleanType.class, F_BOOLEAN_FROM_NUMBER);
//        DataWrapperUtils.setWrapperFactory(ListType.class, F_LIST);

        //parser.registerFunction("cast", new CastAsSQLProvider());
    }

    @Override
    public Set<String> getSupportedDrivers() {
        LinkedHashSet<String> valid = new LinkedHashSet<String>();
        valid.add(DRIVER_TYPE_DEFAULT);
        return valid;
    }

    @Override
    public String getColumnDeclaration(PrimitiveField field, net.vpc.upa.persistence.EntityExecutionContext entityPersistenceContext) throws UPAException {
        String s = super.getColumnDeclaration(field, entityPersistenceContext);
//        if (field.isAutoIncrement()) {
        //throw new UPAIllegalArgumentException("Not yet supported");
        //s += " IDENTITY(" + field.getAutoIncrement().getSeed() + "," + field.getAutoIncrement().getIncrement() + ")";
//        }
        return s;
    }

    @Override
    public void dropStorage(EntityExecutionContext context) throws UPAException {
    }

    @Override
    public String getDisableIdentityConstraintsStatement(Entity table) {
        return null;
    }

    @Override
    public String getEnableIdentityConstraintsStatement(Entity table) {
        return null;
    }

    @Override
    public String getCreateIndexStatement(Index index) throws UPAException {
        StringBuilder sb = new StringBuilder("Create");
        //how is cluster supported ?
//        switch(index.getDataType()){
//        	case CLUSTERED:{
//        		sb.append(" CLUSTERED");
//        		break;
//        	}
//        	case NON_CLUSTERED:{
//        		sb.append(" NON_CLUSTERED");
//        		break;
//        	}
//        }
        sb.append(" Index ");
        sb.append(getValidIdentifier(getPersistenceName(index)));
        sb.append(" On ");
        sb.append(getValidIdentifier(getPersistenceName(index.getEntity())));
        sb.append("(");
        boolean first = true;
        List<PrimitiveField> primitiveFields = index.getEntity().getPrimitiveFields(
                FieldFilters.regular().and(FieldFilters.byList(index.getFields()))
        );
        for (Field field : primitiveFields) {
            if (first) {
                first = false;
            } else {
                sb.append(", ");
            }
            sb.append(getValidIdentifier(getPersistenceName(field)));
        }
        sb.append(")");
        return (sb.toString());
    }

    protected ViewPersistenceDefinition getViewPersistenceDefinition(String persistenceName, EntityExecutionContext entityExecutionContext) {
        try {
            ResultSet rs = null;
            /**
             * @PortabilityHint(target = "C#", name = "replace")
             *
             * System.Data.IDbConnection connection =
             * entityExecutionContext.GetConnection().GetPlatformConnection();
             * if (connection is System.Data.Common.DbConnection) {
             * System.Data.Common.DbConnection dconnection =
             * (System.Data.Common.DbConnection)connection;
             * System.Data.DataTable found = dconnection.GetSchema("Tables", new
             * string[] { null, null, persistenceName, "VIEW" }); return
             * (found.Rows.Count != 0); }
             */
            try {
                Connection connection = (Connection) entityExecutionContext.getConnection().getMetadataAccessibleConnection();
                String catalog = connection.getCatalog();
                String schema = connection.getSchema();
                rs = connection.getMetaData().getTables(catalog, schema, getIdentifierStoreTranslator().translateIdentifier(persistenceName), null);
                if (rs.next()) {
                    String n = rs.getString("TABLE_NAME");
                    String t = rs.getString("TYPE_NAME");
                    return new DefaultViewKeyPersistenceDefinition(n, catalog, schema, getViewDefinition(n, connection));
                }
            } finally {
                if (rs != null) {
                    rs.close();
                }
            }
        } catch (SQLException ex) {
            throw createUPAException(ex, "UnableToGetEntityPersistenceState", "Table " + persistenceName);
        }
        return null;
    }

    protected String getViewDefinition(String viewName, Connection conn) {
        String definition = null;
        PreparedStatement ps = null;
        ResultSet rs = null;
        try {
            try {
                ps = conn.prepareStatement(
                        "SELECT text FROM all_views WHERE view_name  = ?");
                ps.setString(1, viewName);
                rs = ps.executeQuery();
                if (rs.next()) {
                    definition = rs.getString(1);
                }
                rs.close();
            } finally {
                if (rs != null) {
                    rs.close();
                }
                if (ps != null) {
                    ps.close();
                }
            }
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
        return definition;
    }

    public SqlTypeName getSqlTypeName(DataType datatype) {
//        String databaseProductVersion = qlContext.getPersistenceStore().getStoreParameters().getString("databaseProductVersion");
//        if(databaseProductVersion==null){
//            databaseProductVersion="";
//        }
        Class platformType = datatype.getPlatformType();
        int length = datatype.getScale();
        int precision = datatype.getPrecision();
        if (net.vpc.upa.impl.util.PlatformUtils.isString(platformType)) {
            if (length <= 0) {
                length = 256;
            }
            if (length <= 8000) {
                return new SqlTypeName("VARCHAR2", length);
            } else {
                return new SqlTypeName("CLOB");
            }
        }
        if (net.vpc.upa.impl.util.PlatformUtils.isInt8(platformType)) {
            return new SqlTypeName("SMALLINT");
        }
        if (net.vpc.upa.impl.util.PlatformUtils.isInt16(platformType)) {
            return new SqlTypeName("SMALLINT");
        }
        if (net.vpc.upa.impl.util.PlatformUtils.isInt32(platformType)) {
            return new SqlTypeName("INT");
        }
        if (net.vpc.upa.impl.util.PlatformUtils.isInt64(platformType)) {
            return new SqlTypeName("NUMBER");
        }
        if (net.vpc.upa.impl.util.PlatformUtils.isFloat32(platformType)) {
            return new SqlTypeName("NUMBER");
        }
        if (net.vpc.upa.impl.util.PlatformUtils.isFloat64(platformType)) {
            if (datatype instanceof NumberType) {
                DoubleType n = ((DoubleType) datatype);
                return n.isFixedDigits()
                        ? new SqlTypeName("NUMBER", (n.getMaximumIntegerDigits() + n.getMaximumFractionDigits()), n.getMaximumFractionDigits())
                        : new SqlTypeName("NUMBER");
            } else {
                return new SqlTypeName("NUMBER");
            }
        }
        if (net.vpc.upa.impl.util.PlatformUtils.isAnyNumber(platformType)) {
            return new SqlTypeName("NUMBER");
        }
        if (net.vpc.upa.impl.util.PlatformUtils.isBool(platformType)) {
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
        if (Object.class.equals(platformType) || net.vpc.upa.impl.util.PlatformUtils.isSerializable(platformType)) {
            return new SqlTypeName("BLOB"); // serialized form
        }
        throw new IllegalUPAArgumentException("UNKNOWN_TYPE<" + platformType.getName() + "," + length + "," + precision + ">");
    }

    public String getAlterTableModifyColumnStatement(PrimitiveField field, EntityExecutionContext context) throws UPAException {
        String tableName = getPersistenceName(field.getEntity());
        String columnName = getPersistenceName(field);
        ColumnPersistenceDefinition persistenceDefinition = getColumnPersistenceDefinition(tableName, columnName, context, (Connection)context.getConnection().getPlatformConnection());
        ColumnPersistenceDefinition expected = getExpectedColumnPersistenceDefinition(field, context);
        StringBuilder sb = new StringBuilder("Alter Table ")
                .append(getTableName(field.getEntity()))
                .append(" Modify (")
                .append(getValidIdentifier(getColumnName(field)))
                .append(" ");
        DataTypeTransform cr = field.getEffectiveTypeTransform();
        if (!expected.getColumnTypeName().equals(persistenceDefinition.getColumnTypeName())
                || expected.getSize() != -1 && expected.getSize() != persistenceDefinition.getSize()
                || expected.getScale() != -1 && expected.getScale() != persistenceDefinition.getScale()) {
            sb.append(getSqlTypeName(cr.getTargetType()).getFullName());
        }
        sb.append(")");
        return sb.toString();
    }

}
