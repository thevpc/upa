package net.vpc.upa.impl.persistence;

import net.vpc.upa.Field;
import net.vpc.upa.QueryHints;
import net.vpc.upa.Relationship;
import net.vpc.upa.exceptions.IllegalUPAArgumentException;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.upql.DefaultExpressionDeclarationList;
import net.vpc.upa.impl.upql.ext.expr.CompiledBinaryOperatorExpression;
import net.vpc.upa.impl.upql.ext.expr.CompiledLiteral;
import net.vpc.upa.impl.upql.ext.expr.CompiledParam;
import net.vpc.upa.impl.upql.util.UPQLCompiledUtils;
import net.vpc.upa.impl.util.ExprTypeInfo;
import net.vpc.upa.persistence.*;
import net.vpc.upa.types.DataTypeTransform;
import net.vpc.upa.types.I18NString;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.util.UPAUtils;

import java.sql.SQLException;
import java.util.*;
import java.util.logging.Logger;

public class DefaultQueryExecutor implements QueryExecutor {

    private static final Logger log = Logger.getLogger(DefaultQueryExecutor.class.getName());
    private final Map<String,Object> hints;
    private String query;
    private UConnection connection;

    private final net.vpc.upa.impl.persistence.NativeStatementType statementType;
    private final HashMap<String, String> parameters;
    private Object returnValue;
    private int currentStatementIndex;
    private final boolean updatable;
    private String errorTrace;
    private final NativeField[] fields;
    private final ResultMetaData metaData;
    private List<Parameter> queryParameters;
//    private List<Parameter> generatedValues;
    private final CompiledExpressionExt compiledExpression;
    private final boolean noTypeTransform;
    private final List<CompiledParam> compiledParams;
    private EntityExecutionContext context;
    private final Expression userQuery;
    private final SQLManager sqlManager;
    private boolean forceRebuildSQL=true;
    public DefaultQueryExecutor(Expression userQuery,CompiledExpressionExt compiledExpression, Map<String, Object> hints,
                                NativeField[] nativeFields, boolean updatable, ResultMetaData metaData,
                                boolean noTypeTransform,
                                EntityExecutionContext context,SQLManager sqlManager
    ) {
        this.context = context;
        this.userQuery = userQuery;
        this.statementType = context.getOperation() == ContextOperation.FIND ? NativeStatementType.SELECT : NativeStatementType.UPDATE;
        this.updatable = updatable;
        this.metaData = metaData;
        this.sqlManager = sqlManager;
        this.fields = nativeFields;
        this.connection = context.getConnection();
        this.compiledExpression = compiledExpression;
        this.noTypeTransform = noTypeTransform;
        this.parameters = new HashMap<String, String>();
        this.hints=hints;
        this.compiledParams = compiledExpression.findExpressionsList(UPQLCompiledUtils.PARAM_FILTER);

        this.queryParameters = new ArrayList<Parameter>();
        for (CompiledParam e : this.compiledParams) {
            ExprTypeInfo ei = UPAUtils.resolveExprTypeInfo(e);
            Object objectValue = e.getValue();
            if (ei.getOldReferrer() != null) {
                Field oldField = (Field) ei.getOldReferrer();
                Relationship manyToOneRelationship= oldField.getManyToOneRelationship();
                if (manyToOneRelationship!=null) {
                    objectValue = manyToOneRelationship.getTargetEntity().getBuilder().objectToId(objectValue);
                }
            }
            boolean fieldNoTypeTransform = noTypeTransform;
            if (ei.getReferrer() instanceof Field) {
                if (!noTypeTransform) {
                    Field field = (Field) ei.getReferrer();
                    String fieldKey = QueryHints.NO_TYPE_TRANSFORM + "." + field.getAbsoluteName();
                    fieldNoTypeTransform = (Boolean) (hints.get(fieldKey) == null ? false : hints.get(fieldKey));
                }
            }
            DataTypeTransform baseTransform = ei.getTypeTransform();
            DataTypeTransform preferedTransform = fieldNoTypeTransform ? IdentityDataTypeTransform.ofType(baseTransform.getSourceType()) : baseTransform;

            queryParameters.add(new DefaultParameter(e.getName(), objectValue, preferedTransform));
        }
    }

    public NativeStatementType getStatementType() {
        return statementType;
    }

    @Override
    public String toString() {
        return "BEGIN NATIVE_SQL"
                + "\n" + userQuery
                + "\n" + query
                + "\n" + "parameters=" + parameters
                + "\n" + "END NATIVE_SQL";
    }

    public void dispose() {
//        try {
//            for (int i = statements.size() - 1; i >= 0; i--) {
//                (statements.get(i)).dispose();
//            }
//        } catch (SQLException e) {
//            throw new UPAException(e, new I18NString("NativeException"));
//        }
    }

    public String getErrorTrace() {
        return errorTrace;
    }

    public int getCurrentStatementIndex() {
        return currentStatementIndex;
    }

    public QueryExecutor execute()
            throws UPAException {
        preExec();
//        String logString = null;
        try {
            errorTrace = null;
            this.currentStatementIndex = 0;
//        log.log(Level.FINE,"NATIVE QUERY : " + query);
//        Log.log(PersistenceUnitManager.DB_QUERY_LOG, "RETURN :=" + query);
            switch (getStatementType()) {
                case SELECT: {
                    DataTypeTransform[] types = new DataTypeTransform[fields.length];
                    for (int i = 0; i < types.length; i++) {
                        types[i] = fields[i].getTypeTransform();
                    }
                    setQueryResult(connection.executeQuery(query, types, queryParameters, updatable));
                    break;
                }
                case UPDATE: {
                    List<Parameter> generatedValues = context.getGeneratedValues();
                    if (generatedValues != null && generatedValues.size() > 0) {
                        int updates = connection.executeNonQuery(query, queryParameters, generatedValues);
                        setResultCount(updates);
                    } else {
                        setResultCount(connection.executeNonQuery(query, queryParameters, null));
                    }
                    break;
                }
                default:
                    throw new SQLException("Unexpected QueryExecutor type " + getStatementType());
            }

        } catch (Exception e) {
            errorTrace
                    = "--ERROR-EXEC--" + "\n"
                    + "     statement index =" + getCurrentStatementIndex() + "\n"
                    + "   execution-context =" + this + "\n"
                    + "          uql query  =" + userQuery + "\n"
                    + "        native query =" + query + "\n"
                    + " compiled uql query  =" + compiledExpression + "\n"
                    + "           exception =" + e + "\n"
                    + "          stacktrace =" + "\n";

            /**
             * @PortabilityHint(target="C#",name="suppress")
             */
            if (true) {
                errorTrace += UPAUtils.getStackTrace(e);
            }
//            Log.log(PersistenceUnitManager.DB_ERROR_LOG,errorTrace);
            throw new UPAException(e, new I18NString("NativeException"),errorTrace);
        } finally {
//            if (errorTrace == null){
//                switch (createExecutor.getDataType()) {
//                    case 2: // '\002'
//                        Log.log(DatabaseAdapter.DB_UPDATE_LOG,"[COUNT=?] " + getResultCount());
//                        break;
//                }
//            }
            dispose();
        }
        return this;
    }



    public void setQueryResult(QueryResult r) {
        returnValue = r;
    }

    public void setResultCount(int r) {
        returnValue = r;
    }

    public QueryResult getQueryResult() {
        return (QueryResult) returnValue;
    }

    public int getResultCount() {
        return (Integer) returnValue;
    }

    public void setParameter(String paramName, String value) {
        parameters.put(paramName, value);
    }

    public Map<String, String> getParameters() {
        return parameters;
    }

    public Map<String, Object> getHints() {
        return hints;
    }

    public ResultMetaData getMetaData() {
        return metaData;
    }

    @Override
    public NativeField[] getFields() {
        return fields;
    }

    @Override
    public UConnection getConnection() {
        return connection;
    }

    @Override
    public void setConnection(UConnection connection) {
        this.connection = connection;
    }

    public void preExec(){
        List<Parameter> nonNullParameters=new ArrayList<Parameter>();
        List<Parameter> nullParameters=new ArrayList<Parameter>();
        for (CompiledParam e : compiledParams) {
            if (e.isUnspecified()) {
                throw new IllegalUPAArgumentException("Unspecified Param " + e);
            }
            boolean isnull=false;
            if(e.getValue()==null && e.getParentExpression() instanceof CompiledBinaryOperatorExpression && e==((CompiledBinaryOperatorExpression) e.getParentExpression()).getRight()){
                isnull=true;
            }
            ExprTypeInfo ei = UPAUtils.resolveExprTypeInfo(e);
            Object objectValue = e.getValue();
            if (ei.getOldReferrer() != null) {
                Field oldField = (Field) ei.getOldReferrer();
                Relationship manyToOneRelationship= oldField.getManyToOneRelationship();
                if (manyToOneRelationship!=null) {
                    objectValue = manyToOneRelationship.getTargetEntity().getBuilder().objectToId(objectValue);
                }
            }
            boolean fieldNoTypeTransform = noTypeTransform;
            if (ei.getReferrer() instanceof Field) {
                if (!noTypeTransform) {
                    Field field = (Field) ei.getReferrer();
                    String fieldKey = QueryHints.NO_TYPE_TRANSFORM + "." + field.getAbsoluteName();
                    fieldNoTypeTransform = (Boolean) (hints.get(fieldKey) == null ? false : hints.get(fieldKey));
                }
            }
            DataTypeTransform baseTransform = ei.getTypeTransform();
            DataTypeTransform preferredTransform = fieldNoTypeTransform ? IdentityDataTypeTransform.ofType(baseTransform.getSourceType()) : baseTransform;

            if(isnull) {
                nullParameters.add(new DefaultParameter(e.getName(), objectValue, preferredTransform));
            }else {
                nonNullParameters.add(new DefaultParameter(e.getName(), objectValue, preferredTransform));
            }
        }
        if(this.query==null || forceRebuildSQL || nullParameters.size()>0){
            CompiledExpressionExt exprCopy = compiledExpression.copy();
            for (Parameter nullParameter : nullParameters) {
                UPQLCompiledUtils.replaceParam(exprCopy,nullParameter.getName(), new CompiledLiteral(null,nullParameter.getTypeTransform()),null);
            }
            this.queryParameters=nonNullParameters;
            this.query = sqlManager.getSQL(exprCopy, context, new DefaultExpressionDeclarationList(null));
        }else{
            this.queryParameters=nonNullParameters;
        }
        forceRebuildSQL=!nullParameters.isEmpty();
    }

    public void setParam(int index,Object value){
        compiledParams.get(index).setValue(value);
    }

    public void setParam(String name,Object value){
        for (CompiledParam compiledParam : compiledParams) {
            if(name.equals(compiledParam.getName())){
                compiledParam.setValue(value);
            }
        }
    }

    public void setContext(EntityExecutionContext context) {
        this.context = context;
    }
}
