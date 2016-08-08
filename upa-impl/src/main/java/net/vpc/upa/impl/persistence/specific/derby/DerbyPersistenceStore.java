package net.vpc.upa.impl.persistence.specific.derby;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.CreatePersistenceUnitException;
import net.vpc.upa.exceptions.DatabaseNotFoundException;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.QueryStatement;
import net.vpc.upa.expressions.Select;
import net.vpc.upa.expressions.Var;
import net.vpc.upa.filters.FieldFilters;
import net.vpc.upa.impl.persistence.*;
import net.vpc.upa.impl.persistence.shared.sql.CastANSISQLProvider;
import net.vpc.upa.impl.persistence.shared.marshallers.FloatAsDoubleMarshaller;
import net.vpc.upa.impl.persistence.shared.sql.SignANSISQLProvider;
import net.vpc.upa.impl.persistence.shared.marshallers.StringToBlobDataMarshallerFactory;
import net.vpc.upa.impl.uql.DefaultExpressionDeclarationList;
import net.vpc.upa.impl.uql.compiledexpression.CompiledLiteral;
import net.vpc.upa.impl.uql.compiledexpression.CompiledTypeName;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.impl.util.UPAUtils;
import net.vpc.upa.persistence.*;
import net.vpc.upa.types.*;

import java.io.File;
import java.sql.Connection;
import java.sql.SQLException;
import java.util.LinkedHashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;
import java.util.logging.Level;
import net.vpc.upa.impl.DefaultPersistenceUnit;

@PortabilityHint(target = "C#", name = "suppress")
public class DerbyPersistenceStore extends DefaultPersistenceStore {

//    private Set<String> keywords;

    public DerbyPersistenceStore() {
        super();

        Properties map = getProperties();
        map.setBoolean("isComplexSelectSupported", Boolean.TRUE);
        map.setBoolean("isUpdateComplexValuesStatementSupported", Boolean.TRUE);
        map.setBoolean("isUpdateComplexValuesIncludingUpdatedTableSupported", Boolean.TRUE);
        map.setBoolean("isFromClauseInUpdateStatementSupported", false);
        map.setBoolean("isFromClauseInDeleteStatementSupported", false);
        map.setBoolean("isReferencingSupported", Boolean.TRUE);
        map.setBoolean("isViewSupported", Boolean.TRUE);
        map.setBoolean("isTopSupported", Boolean.FALSE);
        getSqlManager().register(new DerbyCoalesceSQLProvider());
        getSqlManager().register(new CastANSISQLProvider());
        getSqlManager().register(new DerbyConcatSQLProvider());
        getSqlManager().register(new DerbyDateAddSQLProvider());
        getSqlManager().register(new DerbyDateDiffSQLProvider());
        getSqlManager().register(new DerbyDatePartSQLProvider());
        getSqlManager().register(new DerbyI2VSQLProvider());
        getSqlManager().register(new DerbyD2VSQLProvider());
        getSqlManager().register(new DerbyDecodeSQLProvider());
        getSqlManager().register(new DerbyIfSQLProvider());
        getSqlManager().register(new SignANSISQLProvider());
        getSqlManager().register(new DerbyStrLenSQLProvider());
        getSqlManager().register(new DerbyCurrentTimeSQLProvider());
        getSqlManager().register(new DerbyCurrentTimestampSQLProvider());
        getSqlManager().register(new DerbyCurrentDateSQLProvider());
        getSqlManager().register(new DerbyNullValSQLProvider());
        getSqlManager().register(new DerbyMonthEndSQLProvider());
        getSqlManager().register(new DerbyTypeNameSQLProvider());
        getSqlManager().register(new DerbySelectSQLProvider());
//        parser.registerFunction("datepart", new Derby_DatePart());

//        parser.registerFunction("monthstart", new Derby_MonthStart());
//        parser.registerFunction("monthend", new Derby_MonthEnd());
//        DataWrapperUtils.setWrapperFactory(DateType.class, F_DATE);
//        DataWrapperUtils.setWrapperFactory(NumberType.class, F_NUMBER);
//        DataWrapperUtils.setWrapperFactory(StringType.class, F_STRING);
//        DataWrapperUtils.setWrapperFactory(BooleanType.class, F_BOOLEAN_FROM_NUMBER);
//        DataWrapperUtils.setWrapperFactory(ListType.class, F_LIST);
        getMarshallManager().setTypeMarshaller(Float.class, new FloatAsDoubleMarshaller());
        getMarshallManager().setTypeMarshallerFactory(StringType.class, new StringToBlobDataMarshallerFactory(32672));
        map.setInt("maxQueryColumnsCount", 1012);

    }

    @Override
    protected Set<String> getCustomReservedKeywords() {
        String resourcePath = null;
        /**
         * @PortabilityHint(target="C#",name="replace") resourcePath =
         * "Persistence.DerbyKeywords.txt";
         */
        resourcePath = "net/vpc/upa/impl/persistence/DerbyKeywords.txt";
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

    private boolean isIdentityField(Field field) throws UPAException {
        if (field.getPersistFormula() instanceof Sequence) {
            Sequence sequence = (Sequence) field.getPersistFormula();
            SequenceStrategy strategy = sequence == null ? SequenceStrategy.AUTO : sequence.getStrategy();
            switch (strategy) {
                case UNSPECIFIED:
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
        Sequence sequence = insert ? (Sequence) field.getPersistFormula() : (Sequence) field.getUpdateFormula();
        SequenceStrategy strategy = SequenceStrategy.AUTO;
        String g = null;
        String f = null;

        if (sequence != null) {
            g = sequence.getGroup();
            strategy = sequence.getStrategy();
            f = sequence.getFormat();
        }
        switch (strategy) {
            case UNSPECIFIED:
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
        DefaultPersistenceUnit pu = (DefaultPersistenceUnit)executionContext.getPersistenceUnit();
        EntityExecutionContext context = pu.createContext(ContextOperation.FIND,executionContext.getHints());
        sb.append(getSqlManager().getSQL(new CompiledTypeName(cr), context, new DefaultExpressionDeclarationList(null)));
        if (isIdentityField(field)) {
            sb.append(" Generated By Default As Identity ");
        } else {
            if (defaultObject == null && !cr.getTargetType().isNullable()) {
                defaultObject = cr.getTargetType().getDefaultValue();
                if (defaultObject == null) {
                    defaultObject = cr.getTargetType().getDefaultNonNullValue();
                }
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
            Map<String, String> properties = p.getProperties();
            String userName = properties.get(ConnectionOption.USER_NAME);
            String password = properties.get(ConnectionOption.PASSWORD);
//            String driverKind = properties.get(ConnectionOption.DRIVER);
            if (DRIVER_TYPE_EMBEDDED.equalsIgnoreCase(connectionDriver)) {
                String url = "jdbc:derby:";
                String path = concatPath(properties.get(ConnectionOption.SERVER_ADDRESS), properties.get(ConnectionOption.DATABASE_PATH), properties.get(ConnectionOption.DATABASE_NAME));
                if (path == null || path.length() == 0) {
                    path = new File(".").getAbsolutePath();
                }
                File file = new File(path);
                File parentFile = file.getParentFile();
                if (parentFile != null) {
                    parentFile.mkdirs();
                }
                url += file.getPath();
                if (create) {
                    url += ";create=true";
                }
                String userDir = ".";
                /**
                 * @PortabilityHint(target = "C#", name = "ignore")
                 */
                userDir = System.getProperty("user.dir");
                log.log(Level.FINE, "Using Derby Embedded at {0}", (file.isAbsolute() ? file.getPath() : userDir + "/" + file.getPath()));
                String driverClass = "org.apache.derby.jdbc.EmbeddedDriver";
                log.log(Level.FINER, "Creating Connection \n\tProfile : {0} \n\tURL :{1}\n\tDriver :{2}\n\tUser :{3}", new Object[]{p, url, driverClass, userName});
                return createPlatformConnection(driverClass, url, userName, password, properties);
            }
            if (DRIVER_TYPE_DEFAULT.equalsIgnoreCase(connectionDriver)) {
                String url = "jdbc:derby://";

                String server = properties.get(ConnectionOption.SERVER_ADDRESS);
                if (server == null || server.length() == 0) {
                    server = "localhost";
                }
                url += server;
                String port = properties.get(ConnectionOption.SERVER_PORT);
                if (port != null && port.trim().length() > 0) {
                    url += ":" + port;
                }
                String path = properties.get(ConnectionOption.DATABASE_PATH);
                if (path == null) {
                    path = "";
                }
                if (path.length() > 0 && !path.equals("/")) {
                    url += path;
                }
                String dbName = properties.get(ConnectionOption.DATABASE_NAME);
                if (dbName != null && dbName.length() > 0) {
                    url += "/" + dbName;
                }
                if (create) {
                    url += ";create=true";
                }
                String driverClass = "org.apache.derby.jdbc.ClientDriver";
                log.log(Level.FINER, "Creating Connection \n\tProfile : {0} \n\tURL :{1}\n\tDriver :{2}\n\tUser :{3}", new Object[]{p, url, driverClass, userName});
                return createPlatformConnection(driverClass, url, userName, password, properties);
            }
        } catch (UPAException e) {
            if(e.getCause() instanceof SQLException){
                int c = ((SQLException) e.getCause()).getErrorCode();
                if (c == 40000) {
                    throw new DatabaseNotFoundException(e, p.getProperties().get(ConnectionOption.DATABASE_NAME));
                }
            }
            throw e;
        } catch (Exception e) {
            //
            throw new UPAException(e, new I18NString("CreatePlatformConnectionFailed"));
        }
        throw new UPAException("Unknown driver");
    }

    @Override
    public void createStorage(EntityExecutionContext context) throws UPAException {
        if (isDelegationConnectionManagement()) {
            throw new CreatePersistenceUnitException("CreateSchemaForDelegatedConnectionException", context.getPersistenceUnit().getName());
        }
        Connection c = null;
        try {
            c = createCustomPlatformConnection(getConnectionProfile(), true);
        } finally {
            if (c != null) {
                try {
                    c.close();
                } catch (SQLException ignored) {
                    //
                }
            }
        }
    }

    
    /**
     * @param entity
     * @return
     */
    @Override
    public String getDisableIdentityConstraintsStatement(Entity entity) {
        return null;
    }

    @Override
    public String getEnableIdentityConstraintsStatement(Entity entity) {
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
        DefaultCompiledExpression compiledExpression = (DefaultCompiledExpression) executionContext.getPersistenceUnit().getExpressionManager().compileExpression(statement, null);
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
            if (key.getModifiers().contains(FieldModifier.SELECT_STORED)) {
                Expression expression = ((ExpressionFormula) key.getSelectFormula()).getExpression();
                s.field(expression, getColumnName(key));
            } else if (!key.getModifiers().contains(FieldModifier.TRANSIENT)) {
                s.field(new Var(new Var(table.getName()), key.getName()));
            }
        }

        DefaultPersistenceUnit pu = (DefaultPersistenceUnit)executionContext.getPersistenceUnit();
        EntityExecutionContext qlContext = pu.createContext(ContextOperation.CREATE_PERSISTENCE_NAME,executionContext.getHints());
        DefaultCompiledExpression compiledExpression = (DefaultCompiledExpression) executionContext.getPersistenceUnit().getExpressionManager().compileExpression(s, null);
        sb.append(getSqlManager().getSQL(compiledExpression, qlContext, new DefaultExpressionDeclarationList(null)));
        return (sb.toString());
    }

    private String concatPath(String... items) {
        StringBuilder b = new StringBuilder();
        for (String item : items) {
            if (item != null && item.length() > 0) {
                if (b.length() == 0) {
                    b.append(item);
                } else if (b.charAt(b.length() - 1) == '/' || item.startsWith("/")) {
                    b.append(item);
                } else {
                    b.append('/').append(item);
                }
            }
        }
        return b.toString();
    }
}
