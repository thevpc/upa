package net.thevpc.upa.impl.persistence.specific.mysql;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.LinkedHashSet;

import net.thevpc.upa.*;
import net.thevpc.upa.exceptions.IllegalUPAArgumentException;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.exceptions.UnexpectedException;
import net.thevpc.upa.exceptions.UnsupportedUPAFeatureException;
import net.thevpc.upa.expressions.Expression;
import net.thevpc.upa.expressions.QueryStatement;
import net.thevpc.upa.expressions.Select;
import net.thevpc.upa.expressions.Var;
import net.thevpc.upa.filters.FieldFilters;
import net.thevpc.upa.impl.ext.PersistenceUnitExt;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.impl.persistence.shared.sql.CastANSISQLProvider;
import net.thevpc.upa.impl.persistence.shared.sql.NullValANSISQLProvider;
import net.thevpc.upa.impl.persistence.shared.sql.SignANSISQLProvider;
import net.thevpc.upa.impl.upql.DefaultExpressionDeclarationList;
import net.thevpc.upa.impl.upql.ext.expr.CompiledLiteral;
import net.thevpc.upa.impl.util.PlatformUtils;
import net.thevpc.upa.impl.util.UPAUtils;
import net.thevpc.upa.persistence.*;

import net.thevpc.upa.impl.persistence.DefaultPersistenceStore;

import java.util.List;
import java.util.Set;
import java.util.logging.Level;

import net.thevpc.upa.impl.persistence.DatabaseIdentityPersister;
import net.thevpc.upa.impl.persistence.NavigatorIdentityPersister;
import net.thevpc.upa.impl.persistence.TableSequenceIdentityPersisterInt;
import net.thevpc.upa.impl.persistence.TableSequenceIdentityPersisterString;
import net.thevpc.upa.impl.persistence.DefaultPrimaryKeyPersistenceDefinition;
import net.thevpc.upa.impl.persistence.DefaultViewKeyPersistenceDefinition;
import net.thevpc.upa.impl.persistence.SqlTypeName;
import net.thevpc.upa.persistence.*;
import net.thevpc.upa.types.DataTypeTransform;
import net.thevpc.upa.types.I18NString;
import net.thevpc.upa.types.DataType;
import net.thevpc.upa.types.EnumType;
import net.thevpc.upa.types.TemporalOption;
import net.thevpc.upa.types.TemporalType;

@PortabilityHint(target = "C#", name = "suppress")
public class MySQLPersistenceStore extends DefaultPersistenceStore {

    public void configureStore() {
        super.configureStore();
        Properties map = getStoreParameters();
        map.setBoolean(PARAM_IS_COMPLEX_SELECT_SUPPORTED, true);
        map.setBoolean(PARAM_IS_UPDATE_COMPLEX_VALUES_STATEMENT_SUPPORTED, true);
        map.setBoolean(PARAM_IS_UPDATE_COMPLEX_VALUES_INCLUDING_UPDATED_TABLE_SUPPORTED, false);
        map.setBoolean(PARAM_IS_FROM_CLAUSE_IN_UPDATE_STATMENT_SUPPORTED, true);
        map.setBoolean(PARAM_IS_FROM_CLAUSE_IN_DELETE_STATMENT_SUPPORTED, false);
        map.setBoolean(PARAM_IS_REFERENCING_SUPPORTED, true);
        map.setBoolean(PARAM_IS_VIEW_SUPPORTED, true);
        map.setBoolean(PARAM_IS_TOP_SUPPORTED, true);
        map.setInt(PARAM_MAX_QUERY_JOIN_COUNT, 60); //actually 61=table+60joins!
        getSqlManager().register(new MySQLCoalesceSQLProvider());
        getSqlManager().register(new CastANSISQLProvider());
        getSqlManager().register(new MySQLConcatSQLProvider());
        getSqlManager().register(new MySQLDateAddSQLProvider());
        getSqlManager().register(new MySQLDateDiffSQLProvider());
        getSqlManager().register(new MySQLDatePartSQLProvider());
        getSqlManager().register(new MySQLD2VSQLProvider());
        getSqlManager().register(new MySQLDecodeSQLProvider());
        getSqlManager().register(new MySQLIfSQLProvider());
        getSqlManager().register(new SignANSISQLProvider());
        getSqlManager().register(new MySQLStrLenSQLProvider());
        getSqlManager().register(new MySQLCurrentTimeSQLProvider());
        getSqlManager().register(new MySQLCurrentTimestampSQLProvider());
        getSqlManager().register(new MySQLCurrentDateSQLProvider());
        getSqlManager().register(new NullValANSISQLProvider());
        getSqlManager().register(new MySQLSelectSQLProvider());

        getSqlManager().register(new MySQLCastSQLProvider());
        getSqlManager().register(new MySQLUpdateSQLProvider());
        getSqlManager().register(new MySQLDeleteSQLProvider());
    }

    @Override
    public int getSupportLevel(ConnectionProfile connectionProfile, Properties parameters) {
        DatabaseProduct p = connectionProfile.getDatabaseProduct();
        if (p == DatabaseProduct.MYSQL) {
            return 10;
        }
        return -1;
    }

    @Override
    protected Set<String> getCustomReservedKeywords() {
        String resourcePath = null;
        /**
         * @PortabilityHint(target="C#",name="replace") resourcePath =
         * "Persistence.MySQLKeywords.txt";
         */
        resourcePath = "net/thevpc/upa/impl/persistence/MySQLKeywords.txt";
        return UPAUtils.loadLinesSet(resourcePath);
    }

    public String getDefaultProfile() {
        return "";//DatabaseProduct.PROFILE_DERBY_EMBEDDED;
    }

    @Override
    public Set<String> getSupportedDrivers() {
        LinkedHashSet<String> valid = new LinkedHashSet<String>();
        valid.add(DRIVER_TYPE_EMBEDDED);
        return valid;
    }

    @Override
    public FieldPersister createPersistSequenceGenerator(Field field) throws UPAException {
        return createSequenceGenerator(field, true);
    }

    @Override
    public FieldPersister createUpdateSequenceGenerator(Field field) throws UPAException {
        return createSequenceGenerator(field, true);
    }

    protected boolean isIdentityField(Field field) throws UPAException {
        if (UPAUtils.getPersistFormula(field) instanceof Sequence) {
            Sequence sequence = (Sequence) UPAUtils.getPersistFormula(field);
            SequenceStrategy strategy = sequence == null ? SequenceStrategy.AUTO : sequence.getStrategy();
            switch (strategy) {
                case DEFAULT:
                case AUTO:
                case IDENTITY: {
                    DataType d = (field.getDataType());
                    Class platformType = d.getPlatformType();
                    if (PlatformUtils.isAnyInteger(platformType) && field.isId()) {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public FieldPersister createSequenceGenerator(Field field, boolean insert) throws UPAException {
        Sequence sequence = (Sequence) UPAUtils.getFormula(field, insert);
        SequenceStrategy strategy = SequenceStrategy.AUTO;
        String g = null;
        String f = null;

        if (sequence != null) {
            g = sequence.getGroup();
            strategy = sequence.getStrategy();
            f = sequence.getFormat();
        }
        switch (strategy) {
            case DEFAULT:
            case AUTO:
            case IDENTITY: {
                DataType d = (field.getDataType());
                Class platformType = d.getPlatformType();
                boolean ofIntegerType = PlatformUtils.isAnyInteger(platformType);
                if (ofIntegerType && f != null) {
                    log.log(Level.WARNING, "Field {0} defines a sequence format but it has an integer type. Format is ignored", field);
                }
                if (ofIntegerType) {
                    if (field.isId() && g == null) {
                        return insert ? new DatabaseIdentityPersister(field) : new NavigatorIdentityPersister();
                    } else {
                        return new TableSequenceIdentityPersisterInt(field, sequence);
                    }
                } else if (String.class.equals(platformType)) {
                    return new TableSequenceIdentityPersisterString(field, sequence);
                } else {
                    throw new UnsupportedUPAFeatureException("UnsupportedGeneratedValueTypeException", field, platformType);
                }
            }
            case SEQUENCE: {
                return new TableSequenceIdentityPersisterString(field, sequence);
            }
            case TABLE: {
                return new TableSequenceIdentityPersisterString(field, sequence);
            }
            default: {
                throw new UnsupportedUPAFeatureException("UnsupportedGeneratedValueStrategyException", field);
            }
        }
    }

    @Override
    public String getColumnDeclaration(PrimitiveField field, EntityExecutionContext executionContext) throws UPAException {
        DataTypeTransform cr = field.getEffectiveTypeTransform();
        Object defaultObject = field.getDefaultObject();
        StringBuilder sb = new StringBuilder(getValidIdentifier(getColumnName(field)));
        sb.append('\t');
        PersistenceUnitExt pu = (PersistenceUnitExt) executionContext.getPersistenceUnit();
        EntityExecutionContext context = pu.createContext(ContextOperation.FIND, executionContext.getHints());
        if (field.getDataType() == null) {
            throw new UPAException(new I18NString("MissingDataTypeException"), field);
        }
        SqlTypeName sqlTypeName = getSqlTypeName(cr.getTargetType());
        sb.append(sqlTypeName.getFullName());
        if (isIdentityField(field)) {
            sb.append(" PRIMARY KEY AUTO_INCREMENT  ");
        } else {
            DataType sourceType = cr.getSourceType();
            if (defaultObject == null && !sourceType.isNullable()) {
                defaultObject = sourceType.getDefaultValue();
//                if (defaultObject == null) {
//                    defaultObject = sourceType.getDefaultNonNullValue();
//                }
            }
            if (defaultObject != null && !(defaultObject instanceof CustomDefaultObject)) {
                sb.append(" Default ").append(getSqlManager().getSQL(new CompiledLiteral(defaultObject, cr), context, new DefaultExpressionDeclarationList(null)));
            }

            if (!cr.getTargetType().isNullable()) {
                sb.append(" Not Null");
            } else {
                if (sqlTypeName.getName().equals("TIMESTAMP")) {
                    sb.append(" Null");
                }
            }
        }
        return sb.toString();
    }

    @Override
    public Connection createCustomPlatformConnection(ConnectionProfile p) throws UPAException {
        return createCustomPlatformConnection(p, true);
    }

    public Connection createCustomPlatformConnection(ConnectionProfile p, boolean create) throws UPAException {
        try {
            String connectionDriver = p.getConnectionDriver();
            if (connectionDriver == null || connectionDriver.trim().isEmpty()) {
                connectionDriver = DRIVER_TYPE_DEFAULT;
            }
//            Map<String, String> properties = p.getProperties();
            String userName = p.getProperty(ConnectionOption.USER_NAME);
            String password = p.getProperty(ConnectionOption.PASSWORD);
//            String driverKind = properties.get(ConnectionOption.DRIVER);
            //jdbc:mysql://localhost:3306/mysql?zeroDateTimeBehavior=convertToNull
            if (DRIVER_TYPE_DEFAULT.equalsIgnoreCase(connectionDriver)) {
                String url = "jdbc:mysql://";

                String server = p.getProperty(ConnectionOption.SERVER_ADDRESS);
                if (server == null || server.length() == 0) {
                    server = "localhost";
                }
                url += server;
                String port = p.getProperty(ConnectionOption.SERVER_PORT);
                if (port != null && port.trim().length() > 0) {
                    url += ":" + port;
                }
                String path = p.getProperty(ConnectionOption.DATABASE_PATH);
                if (path == null) {
                    path = "";
                }
                if (path.length() > 0 && !path.equals("/")) {
                    url += path;
                }
                String dbName = p.getProperty(ConnectionOption.DATABASE_NAME);
                if (dbName != null && dbName.length() > 0) {
                    url += "/" + dbName;
                }
                url += "?zeroDateTimeBehavior=convertToNull&useUnicode=yes&characterEncoding=UTF-8";
                String driverClass = "com.mysql.jdbc.Driver";
                log.log(Level.FINER, "Creating Connection \n\tProfile : {0} \n\tURL     : {1}\n\tDriver  : {2}\n\tUser    : {3}", new Object[]{p, url, driverClass, userName});
                return createPlatformConnection(driverClass, url, userName, password, p.getProperties());
            }
        } catch (UPAException e) {
            throw e;
        } catch (Exception e) {
            //
            throw new UPAException(e, new I18NString("CreateNativeConnectionFailed"));
        }
        throw new UPAException("Unknown driver");
    }

    /**
     * @param table
     * @return
     */
    @Override
    public String getDisableIdentityConstraintsStatement(Entity table) {
        return null;
    }

    @Override
    public String getEnableIdentityConstraintsStatement(Entity table) {
        return null;
    }

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
        if (index.isUnique()) {
            sb.append(" Unique ");
        }
        sb.append(" Index ");
        sb.append(getValidIdentifier(getIndexName(index)));
        sb.append(" On ");
        sb.append(getValidIdentifier(getTableName(index.getEntity())));
        sb.append("(");
        boolean first = true;
        List<PrimitiveField> primitiveFields = index.getEntity().getPrimitiveFields(
                FieldFilters.regular().and(FieldFilters.byList(index.getFields())));
        for (PrimitiveField field : primitiveFields) {
            if (first) {
                first = false;
            } else {
                sb.append(", ");
            }
            sb.append(getValidIdentifier(getColumnName(field)));
        }
        sb.append(")");
        return (sb.toString());
    }

    @Override
    public String getCreateViewStatement(Entity entity, EntityExecutionContext executionContext) throws UPAException {
        QueryStatement statement = getViewQueryStatement(entity);
        StringBuilder sb = new StringBuilder();
        sb.append("Create View ").append(getValidIdentifier(getTableName(entity)));
//        sb.append("(");
//        List<PrimitiveField> keys = entity.getPrimitiveFields();
//        for (int i = 0; i < keys.size(); i++) {
//            PrimitiveField field = keys.get(i);
//            if (i > 0) {
//                sb.append(',');
//            }
//            sb.append(getValidIdentifier(getColumnName(field)));
//        }
//        sb.append(")");
        sb.append(" As ").append("\n\t");
        CompiledExpressionExt compiledExpression = (CompiledExpressionExt) executionContext.getPersistenceUnit().getExpressionManager().compileExpression(statement, null);
        sb.append(getSqlManager().getSQL(compiledExpression, executionContext, new DefaultExpressionDeclarationList(null)));
        return (sb.toString());
    }

    @Override
    public String getCreateImplicitViewStatement(Entity table, EntityExecutionContext executionContext) throws UPAException {
        StringBuilder sb = new StringBuilder();
        sb.append("Create View ").append(getValidIdentifier(getImplicitViewName(table)));
        sb.append("(");
        List<PrimitiveField> keys = table.getPrimitiveFields();
        for (int i = 0; i < keys.size(); i++) {
            PrimitiveField field = keys.get(i);
            if (i > 0) {
                sb.append(',');
            }
            sb.append(getValidIdentifier(getColumnName(field)));
        }
        sb.append(")");
        sb.append(" As ").append("\n");

        Select s = new Select();
        for (PrimitiveField key : keys) {
            if (key.getModifiers().contains(FieldModifier.SELECT_COMPILED)) {
                Expression expression = ((ExpressionFormula) UPAUtils.getSelectFormula(key)).getExpression();
                s.field(expression, getColumnName(key));
            } else if (!key.getModifiers().contains(FieldModifier.TRANSIENT)) {
                s.field(new Var(new Var(table.getName()), key.getName()));
            }
        }
        PersistenceUnitExt pu = (PersistenceUnitExt) executionContext.getPersistenceUnit();

        EntityExecutionContext qlContext = pu.createContext(ContextOperation.CREATE_PERSISTENCE_NAME, executionContext.getHints());
        CompiledExpressionExt compiledExpression = (CompiledExpressionExt) executionContext.getPersistenceUnit().getExpressionManager().compileExpression(s, null);
        sb.append(getSqlManager().getSQL(compiledExpression, qlContext, new DefaultExpressionDeclarationList(null)));
        return (sb.toString());
    }

    @PortabilityHint(target = "C#", name = "ignore")
    protected PrimaryKeyPersistenceDefinition getStorePrimaryKeyDefinition(String tableName, String constraintsName, EntityExecutionContext entityExecutionContext) {
        try {
            ResultSet rs = null;
            try {
                Connection connection = (Connection) entityExecutionContext.getConnection().getMetadataAccessibleConnection();
                String catalog = connection.getCatalog();
                String schema = connection.getSchema();
                rs = connection.getMetaData().getPrimaryKeys(catalog, schema, getIdentifierStoreTranslator().translateIdentifier(tableName));
                while (rs.next()) {
                    String tn = rs.getString("TABLE_NAME");
                    String n = rs.getString("PK_NAME");
                    String expectedName = getIdentifierStoreTranslator().translateIdentifier(constraintsName);
                    if (expectedName.equals(n) || "PRIMARY".equals(n)) {
                        return new DefaultPrimaryKeyPersistenceDefinition(tn, n);
                    } else {
                        log.log(Level.WARNING, "Found Conflicting PK Constraints {0} instead of {1}", new Object[]{n, expectedName});
                        return new DefaultPrimaryKeyPersistenceDefinition(tn, n);
                    }
                }
            } finally {
                if (rs != null) {
                    rs.close();
                }
            }
        } catch (SQLException ex) {
            throw createUPAException(ex, "UnableToGetEntityPersistenceState", "PK Constraints " + tableName + "." + constraintsName);
        }
        return null;
    }

    public String getDropRelationshipStatement(Relationship relation) throws UPAException {
        StringBuilder sb = new StringBuilder();
        Entity table = relation.getSourceRole().getEntity();
        sb.append("Alter Table ").append(getValidIdentifier(getTableName(table))).append(" Drop FOREIGN KEY ").append(getValidIdentifier(getRelationshipName(relation)));
        return (sb.toString());
    }

    //    @Override
    public String getDropTablePKConstraintStatement(Entity entity) throws UPAException {
        StringBuilder sb = new StringBuilder();
        if (!entity.getShield().isTransient()) {
            List<Field> pk = entity.getFields(FieldFilters.id());
            if (pk.size() > 0) {
                sb.append("Alter Table ").append(getValidIdentifier(getTableName(entity))).append(" Drop PRIMARY KEY ").append(getValidIdentifier(getTablePKName(entity)));
                return (sb.toString());
            }
        }
        return null;
    }

    protected ViewPersistenceDefinition getStoreViewDefinition(String persistenceName, EntityExecutionContext entityExecutionContext) {
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
                    return new DefaultViewKeyPersistenceDefinition(n, catalog, schema, getStoreViewDefinitionSQL(n, connection));
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

    protected String getStoreViewDefinitionSQL(String viewName, Connection conn) {
        String definition = null;
        PreparedStatement ps = null;
        ResultSet rs = null;
        try {
            try {
                ps = conn.prepareStatement(
                        "SELECT  VIEW_DEFINITION \n"
                        + "    FROM    INFORMATION_SCHEMA.VIEWS\n"
                        + "    WHERE TABLE_NAME      = ? \n"
                        + "    AND TABLE_SCHEMA    = ?");
                ps.setString(1, viewName);
                ps.setString(2, conn.getSchema());
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
            throw new UnexpectedException(ex);
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
        if (PlatformUtils.isString(platformType)) {
            if (length <= 0) {
                length = 255;
            }
            /**
             * Values in VARCHAR columns are variable-length strings. The length
             * can be specified as a value from 0 to 255 before MySQL 5.0.3, and
             * 0 to 65,535 in 5.0.3 and later versions. The effective maximum
             * length of a VARCHAR in MySQL 5.0.3 and later is subject to the
             * maximum row size (65,535 bytes, which is shared among all
             * columns) and the character set used.
             */
            //will consider mysql>=5.0.3
            if (length <= 4096) {
                return new SqlTypeName("VARCHAR", length);
            }
            if (length <= 65535) {
                return new SqlTypeName("TEXT");
            } else if (length <= 1677215) {
                return new SqlTypeName("MEDIUMTEXT");
            } else {
                return new SqlTypeName("LONGTEXT");
            }
        }
        if (PlatformUtils.isInt8(platformType)) {
            return new SqlTypeName("SMALLINT");
        }
        if (PlatformUtils.isInt16(platformType)) {
            return new SqlTypeName("SMALLINT");
        }
        if (PlatformUtils.isInt32(platformType)) {
            return new SqlTypeName("INT");
        }
        if (PlatformUtils.isInt64(platformType)) {
            return new SqlTypeName("NUMERIC");
        }
        if (PlatformUtils.isFloat32(platformType)) {
            return new SqlTypeName("FLOAT");
        }
        if (PlatformUtils.isFloat64(platformType)) {
            return new SqlTypeName("FLOAT");
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
                    return new SqlTypeName("DATETIME");
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

    public String getAlterTableModifyColumnStatement(PrimitiveField field, EntityExecutionContext context) throws UPAException {
        String tableName = getPersistenceName(field.getEntity());
        String columnName = getPersistenceName(field);
        ColumnPersistenceDefinition persistenceDefinition = getStoreColumnDefinition(tableName, columnName, context, (Connection) context.getConnection().getPlatformConnection());
        ColumnPersistenceDefinition expected = getModelColumnPersistenceDefinition(field, context);
        StringBuilder sb = new StringBuilder("Alter Table ")
                .append(getTableName(field.getEntity()))
                .append(" Modify ")
                .append(getValidIdentifier(getColumnName(field)))
                .append(" ");
        DataTypeTransform cr = field.getEffectiveTypeTransform();
        if (!expected.getColumnTypeName().equals(persistenceDefinition.getColumnTypeName())
                || expected.getSize() != -1 && expected.getSize() != persistenceDefinition.getSize()
                || expected.getScale() != -1 && expected.getScale() != persistenceDefinition.getScale()) {
            sb.append(getSqlTypeName(cr.getTargetType()).getFullName());
        }
        return sb.toString();
    }

}
