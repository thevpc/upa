package net.vpc.upa.impl.persistence.specific.mysql;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.LinkedHashSet;

import net.vpc.upa.*;
import net.vpc.upa.filters.FieldFilters;
import net.vpc.upa.impl.ext.PersistenceUnitExt;
import net.vpc.upa.impl.persistence.DefaultPersistenceStore;
import net.vpc.upa.impl.persistence.shared.sql.NullValANSISQLProvider;

import java.util.List;
import java.util.Set;
import java.util.logging.Level;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.QueryStatement;
import net.vpc.upa.expressions.Select;
import net.vpc.upa.expressions.Var;
import net.vpc.upa.impl.persistence.DatabaseIdentityPersister;
import net.vpc.upa.impl.persistence.NavigatorIdentityPersister;
import net.vpc.upa.impl.persistence.TableSequenceIdentityPersisterInt;
import net.vpc.upa.impl.persistence.TableSequenceIdentityPersisterString;
import net.vpc.upa.impl.persistence.shared.sql.CastANSISQLProvider;
import net.vpc.upa.impl.persistence.shared.sql.SignANSISQLProvider;
import net.vpc.upa.impl.uql.DefaultExpressionDeclarationList;
import net.vpc.upa.impl.uql.compiledexpression.CompiledLiteral;
import net.vpc.upa.impl.uql.compiledexpression.CompiledTypeName;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.impl.util.UPAUtils;
import net.vpc.upa.persistence.*;
import net.vpc.upa.types.DataTypeTransform;
import net.vpc.upa.types.I18NString;
import net.vpc.upa.types.DataType;

@PortabilityHint(target = "C#", name = "suppress")
public class MySQLPersistenceStore extends DefaultPersistenceStore {

    public void configureStore(){
        super.configureStore();
        Properties map = getStoreParameters();
        map.setBoolean("isComplexSelectSupported", true);
        map.setBoolean("isUpdateComplexValuesStatementSupported", true);
        map.setBoolean("isUpdateComplexValuesIncludingUpdatedTableSupported", false);
        map.setBoolean("isFromClauseInUpdateStatementSupported", true);
        map.setBoolean("isFromClauseInDeleteStatementSupported", false);
        map.setBoolean("isReferencingSupported", true);
        map.setBoolean("isViewSupported", true);
        map.setBoolean("isTopSupported", true);
        map.setInt("maxQueryJoinCount", 60); //actually 61=table+61joins!
        getSqlManager().register(new MySQLCoalesceSQLProvider());
        getSqlManager().register(new CastANSISQLProvider());
        getSqlManager().register(new MySQLConcatSQLProvider());
        getSqlManager().register(new MySQLDateAddSQLProvider());
        getSqlManager().register(new MySQLDateDiffSQLProvider());
        getSqlManager().register(new MySQLDatePartSQLProvider());
        getSqlManager().register(new MySQLI2VSQLProvider());
        getSqlManager().register(new MySQLD2VSQLProvider());
        getSqlManager().register(new MySQLDecodeSQLProvider());
        getSqlManager().register(new MySQLIfSQLProvider());
        getSqlManager().register(new SignANSISQLProvider());
        getSqlManager().register(new MySQLStrLenSQLProvider());
        getSqlManager().register(new MySQLCurrentTimeSQLProvider());
        getSqlManager().register(new MySQLCurrentTimestampSQLProvider());
        getSqlManager().register(new MySQLCurrentDateSQLProvider());
        getSqlManager().register(new NullValANSISQLProvider());
        getSqlManager().register(new MySQLTypeNameSQLProvider());
        getSqlManager().register(new MySQLSelectSQLProvider());

        getSqlManager().register(new MySQLCastSQLProvider());
        getSqlManager().register(new MySQLUpdateSQLProvider());
        getSqlManager().register(new MySQLDeleteSQLProvider());
    }

    @Override
    public int getSupportLevel(ConnectionProfile connectionProfile, Properties parameters) {
        DatabaseProduct p = connectionProfile.getDatabaseProduct();
        if(p==DatabaseProduct.MYSQL){
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
        resourcePath = "net/vpc/upa/impl/persistence/MySQLKeywords.txt";
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
        Sequence sequence = (Sequence) UPAUtils.getFormula(field,insert);
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
                    throw new UPAException("UnsupportedGeneratedValueTypeException", field, platformType);
                }
            }
            case SEQUENCE: {
                return new TableSequenceIdentityPersisterString(field, sequence);
            }
            case TABLE: {
                return new TableSequenceIdentityPersisterString(field, sequence);
            }
            default: {
                throw new UPAException("UnsupportedGeneratedValueStrategyException", field);
            }
        }
    }

    @Override
    public String getFieldDeclaration(PrimitiveField field, net.vpc.upa.persistence.EntityExecutionContext executionContext) throws UPAException {
        DataTypeTransform cr = UPAUtils.getTypeTransformOrIdentity(field);
        Object defaultObject = field.getDefaultObject();
        StringBuilder sb = new StringBuilder(getValidIdentifier(getColumnName(field)));
        sb.append('\t');
        PersistenceUnitExt pu = (PersistenceUnitExt)executionContext.getPersistenceUnit();
        EntityExecutionContext context = pu.createContext(ContextOperation.FIND,executionContext.getHints());
        if(field.getDataType()==null){
            throw new UPAException(new I18NString("MissingDataTypeException"),field);
        }
        sb.append(getSqlManager().getSQL(new CompiledTypeName(cr), context, new DefaultExpressionDeclarationList(null)));
        if (isIdentityField(field)) {
            sb.append(" PRIMARY KEY AUTO_INCREMENT  ");
        } else {
            if (defaultObject == null && !cr.getTargetType().isNullable()) {
                defaultObject = cr.getTargetType().getDefaultValue();
//                if (defaultObject == null) {
//                    defaultObject = cr.getTargetType().getDefaultNonNullValue();
//                }
            }
            if (defaultObject != null && !(defaultObject instanceof CustomDefaultObject)) {
                sb.append(" Default ").append(getSqlManager().getSQL(new CompiledLiteral(defaultObject, cr), context, new DefaultExpressionDeclarationList(null)));
            }

            if (!cr.getTargetType().isNullable()) {
                sb.append(" Not Null");
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
    public String getCreateViewStatement(Entity entityManager, QueryStatement statement, EntityExecutionContext executionContext) throws UPAException {
        StringBuilder sb = new StringBuilder();
        sb.append("Create View ").append(getValidIdentifier(getTableName(entityManager)));
        sb.append("(");
        List<PrimitiveField> keys = entityManager.getPrimitiveFields();
        for (int i = 0; i < keys.size(); i++) {
            PrimitiveField field = keys.get(i);
            if (i > 0) {
                sb.append(',');
            }
            sb.append(getValidIdentifier(getColumnName(field)));
        }
        sb.append(")");
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
        PersistenceUnitExt pu = (PersistenceUnitExt)executionContext.getPersistenceUnit();

        EntityExecutionContext qlContext = pu.createContext(ContextOperation.CREATE_PERSISTENCE_NAME,executionContext.getHints());
        CompiledExpressionExt compiledExpression = (CompiledExpressionExt) executionContext.getPersistenceUnit().getExpressionManager().compileExpression(s, null);
        sb.append(getSqlManager().getSQL(compiledExpression, qlContext, new DefaultExpressionDeclarationList(null)));
        return (sb.toString());
    }

    @PortabilityHint(target = "C#", name = "ignore")
    protected boolean pkConstraintsExists(String tableName, String constraintsName, EntityExecutionContext entityExecutionContext) {
        try {
            ResultSet rs = null;
            try {
                Connection connection = (Connection)entityExecutionContext.getConnection().getMetadataAccessibleConnection();
                String catalog = connection.getCatalog();
                String schema = connection.getSchema();
                rs = connection.getMetaData().getPrimaryKeys(catalog, schema, getIdentifierStoreTranslator().translateIdentifier(tableName));
                while (rs.next()) {
                    String n = rs.getString("PK_NAME");
                    String expectedName = getIdentifierStoreTranslator().translateIdentifier(constraintsName);
                    if (expectedName.equals(n) || "PRIMARY".equals(n)) {
                        return true;
                    } else {
                        log.log(Level.WARNING, "Found Conflicting PK Constraints " + n + " instead of " + expectedName);
                        return true;
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
        return false;
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
}
