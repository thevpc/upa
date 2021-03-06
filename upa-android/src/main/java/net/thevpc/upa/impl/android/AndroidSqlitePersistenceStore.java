package net.thevpc.upa.impl.android;

import net.thevpc.upa.*;
import net.thevpc.upa.exceptions.CreatePersistenceUnitException;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.expressions.Expression;
import net.thevpc.upa.expressions.QueryStatement;
import net.thevpc.upa.expressions.Select;
import net.thevpc.upa.expressions.Var;
import net.thevpc.upa.filters.FieldFilters;
import net.thevpc.upa.impl.ext.PersistenceUnitExt;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.impl.persistence.*;
import net.thevpc.upa.impl.persistence.shared.marshallers.FloatAsDoubleMarshaller;
import net.thevpc.upa.impl.persistence.shared.marshallers.StringToBlobUTFMarshallerFactory;
import net.thevpc.upa.impl.persistence.shared.sql.CastANSISQLProvider;
import net.thevpc.upa.impl.persistence.shared.sql.SignANSISQLProvider;
import net.thevpc.upa.impl.upql.DefaultExpressionDeclarationList;
import net.thevpc.upa.impl.upql.ext.expr.CompiledLiteral;
import net.thevpc.upa.impl.upql.ext.expr.CompiledTypeName;
import net.thevpc.upa.impl.util.PlatformUtils;
import net.thevpc.upa.impl.util.UPAUtils;
import net.thevpc.upa.persistence.*;
import net.thevpc.upa.types.DataType;
import net.thevpc.upa.types.DataTypeTransform;
import net.thevpc.upa.types.StringType;

import java.util.List;
import java.util.Set;
import java.util.logging.Level;

@PortabilityHint(target = "C#", name = "suppress")
public class AndroidSqlitePersistenceStore extends AbstractPersistenceStore {

    public void configureStore() {
        super.configureStore();

        Properties map = getStoreParameters();
        map.setBoolean(PARAM_IS_COMPLEX_SELECT_SUPPORTED, Boolean.TRUE);
        map.setBoolean(PARAM_IS_UPDATE_COMPLEX_VALUES_STATEMENT_SUPPORTED, Boolean.TRUE);
        map.setBoolean(PARAM_IS_UPDATE_COMPLEX_VALUES_INCLUDING_UPDATED_TABLE_SUPPORTED, Boolean.TRUE);
        map.setBoolean(PARAM_IS_FROM_CLAUSE_IN_UPDATE_STATMENT_SUPPORTED, false);
        map.setBoolean("isFromClauseInDeleteStatementSupported", false);
        map.setBoolean("isReferencingSupported", Boolean.TRUE);
        map.setBoolean("isViewSupported", Boolean.TRUE);
        map.setBoolean("isTopSupported", Boolean.FALSE);
//        getSqlManager().register(new DerbyCoalesceSQLProvider());
        getSqlManager().register(new CastANSISQLProvider());
//        getSqlManager().register(new DerbyConcatSQLProvider());
//        getSqlManager().register(new DerbyDateAddSQLProvider());
//        getSqlManager().register(new DerbyDateDiffSQLProvider());
//        getSqlManager().register(new DerbyDatePartSQLProvider());
//        getSqlManager().register(new DerbyToStringSQLProvider());
//        getSqlManager().register(new DerbyDecodeSQLProvider());
//        getSqlManager().register(new DerbyIfSQLProvider());
        getSqlManager().register(new SignANSISQLProvider());
//        getSqlManager().register(new DerbyStrLenSQLProvider());
//        getSqlManager().register(new DerbyCurrentTimeSQLProvider());
//        getSqlManager().register(new DerbyCurrentTimestampSQLProvider());
//        getSqlManager().register(new DerbyCurrentDateSQLProvider());
//        getSqlManager().register(new DerbyNullValSQLProvider());
//        getSqlManager().register(new DerbyMonthEndSQLProvider());
//        getSqlManager().register(new DerbyTypeNameSQLProvider());
//        getSqlManager().register(new DerbySelectSQLProvider());
        getMarshallManager().setTypeMarshaller(Float.class, new FloatAsDoubleMarshaller(getMarshallManager()));
        getMarshallManager().setTypeMarshallerFactory(StringType.class, new StringToBlobUTFMarshallerFactory(getMarshallManager(), 32672));
        map.setInt(PARAM_MAX_QUERY_COLUMN_COUNT, 1012);

    }

    @Override
    public int getSupportLevel(ConnectionProfile connectionProfile, Properties parameters) {
        DatabaseProduct p = connectionProfile.getDatabaseProduct();
        if (p == DatabaseProduct.SQLITE) {
            return 10;
        }
        return -1;
    }

    @Override
    protected Set<String> getCustomReservedKeywords() {
        String resourcePath = null;
        /**
         * @PortabilityHint(target="C#",name="replace") resourcePath =
         * "Persistence.DerbyKeywords.txt";
         */
        resourcePath = "net/thevpc/upa/impl/persistence/SqliteKeywords.txt";
        return UPAUtils.loadLinesSet(resourcePath);
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
        Sequence sequence = insert ? (Sequence) UPAUtils.getPersistFormula(field) : (Sequence) UPAUtils.getUpdateFormula(field);
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
    public String getColumnDeclaration(PrimitiveField field, EntityExecutionContext executionContext) throws UPAException {
        DataTypeTransform cr = field.getEffectiveTypeTransform();
        Object defaultObject = field.getDefaultObject();
        StringBuilder sb = new StringBuilder(getValidIdentifier(getColumnName(field)));
        sb.append('\t');
        PersistenceUnitExt pu = (PersistenceUnitExt) executionContext.getPersistenceUnit();
        EntityExecutionContext context = pu.createContext(ContextOperation.FIND, executionContext.getHints());
        sb.append(getSqlManager().getSQL(new CompiledTypeName(cr), context, new DefaultExpressionDeclarationList(null)));
        if (isIdentityField(field)) {
            sb.append(" Generated By Default As Identity ");
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
            }
        }
        return sb.toString();
    }

    @Override
    public void createStorage(EntityExecutionContext context) throws UPAException {
        if (isDelegationConnectionManagement()) {
            throw new CreatePersistenceUnitException("CreateSchemaForDelegatedConnectionException", context.getPersistenceUnit().getName());
        }
        checkAccessible(getConnectionProfile());
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
    public String getCreateViewStatement(Entity entity, EntityExecutionContext executionContext) throws UPAException {
        QueryStatement statement = getViewQueryStatement(entity);
        StringBuilder sb = new StringBuilder();
        sb.append("Create View ").append(getValidIdentifier(getTableName(entity)));
        sb.append("(");
        List<PrimitiveField> keys = entity.getPrimitiveFields();
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

        PersistenceUnitExt pu = (PersistenceUnitExt) executionContext.getPersistenceUnit();
        EntityExecutionContext qlContext = pu.createContext(ContextOperation.CREATE_PERSISTENCE_NAME, executionContext.getHints());
        CompiledExpressionExt compiledExpression = (CompiledExpressionExt) executionContext.getPersistenceUnit().getExpressionManager().compileExpression(s, null);
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

    @Override
    public UConnection createConnection() throws UPAException {
        return createConnection(getConnectionProfile());
    }

    @Override
    public UConnection createConnection(ConnectionProfile cnxProfile) throws UPAException {
        if (DatabaseProduct.SQLITE == cnxProfile.getDatabaseProduct()) {
            return new AndroidSqliteConnection(
                    cnxProfile.getProperty(ConnectionOption.DATABASE_NAME),
                    1,
                    getMarshallManager(),
                    persistenceUnit.getProperties(), persistenceUnit
            );
        }
        throw new UPAException("NotSupported");
    }

}
