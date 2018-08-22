package net.vpc.upa.impl.persistence;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.persistence.shared.sql.*;
import net.vpc.upa.impl.upql.ExpressionDeclarationList;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.util.ClassMap;
import net.vpc.upa.persistence.EntityExecutionContext;


/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/6/12 12:31 AM
 */
public class DefaultSQLManager implements SQLManager {

    private ClassMap<SQLProvider> sqlProviders = new ClassMap<SQLProvider>();
    private MarshallManager marshallManager;

    public DefaultSQLManager(MarshallManager marshallManager) {
        this.marshallManager = marshallManager;
//        register0(new BinaryOperatorExpressionSQLProvider());
//        register0(new PlusExpressionSQLProvider());
        register0(new VarSQLProvider());
        register0(new UnaryOperatorSQLProvider());
        register0(new BinaryExpressionSQLProvider());
        register0(new LiteralSQLProvider());
        register0(new AverageSQLProvider());
        register0(new BetweenSQLProvider());
        register0(new EntityNameSQLProvider());
        register0(new SelectSQLProvider());
        register0(new DeleteSQLProvider());
        register0(new UpdateSQLProvider());
        register0(new InsertSQLProvider());
        register0(new InCollectionSQLProvider());
        register0(new InSelectionSQLProvider());
        register0(new ExistsSQLProvider());
        register0(new UnionSQLProvider());
        register0(new ParamSQLProvider());
        register0(new UpletSQLProvider());
        register0(new ValueSQLProvider());
        register0(new CountANSISQLProvider());
        register0(new MaxANSISQLProvider());
        register0(new MinANSISQLProvider());
        register0(new SumANSISQLProvider());
        register0(new AvgANSISQLProvider());
        register0(new TypeNameSQLProvider());
        register0(new CurrentUserSQLProvider());
        register0(new CompiledQLFunctionExpressionSQLProvider());
        register0(new IdEnumerationExpressionSQLProvider());
        register0(new ExpANSISQLProvider());
        register0(new SignANSISQLProvider());
    }

    public void register(SQLProvider provider) {
        register0(provider);
    }

    private void register0(SQLProvider provider) {
        sqlProviders.put(provider.getExpressionType(), provider);
//        if (provider instanceof net.vpc.upa.impl.persistence.parser.FunctionSQLProvider) {
//            net.vpc.upa.impl.persistence.parser.FunctionSQLProvider f = (net.vpc.upa.impl.persistence.parser.FunctionSQLProvider) provider;
//            getParser().registerFunction(f.getExpressionType().getSimpleName(), f);
//        }
    }

//    public String getSQL(Expression expression, ExecutionContext context) throws UPAException {
//        CompiledExpression compiledExpression = (CompiledExpression) persistenceUnit.compile(expression);
//        return getSQL(compiledExpression, context, declarations);
//    }
//
//    public String getSQL(CompiledExpression expression, ExecutionContext context) throws UPAException {
//        return getSQL(expression, context, new ExpressionDeclarationList());
//    }

    public String getSQL(CompiledExpressionExt expression, EntityExecutionContext context, ExpressionDeclarationList declarations) throws UPAException {
//        if (context == null) {
//            context = createContext(ContextOperation.FIND);
//        }
        if (expression != null) {
            SQLProvider p = sqlProviders.get(expression.getClass());
            if (p != null) {
                return p.getSQL(expression, context, this, declarations);
            }
        }
        throw new net.vpc.upa.exceptions.NoSuchUPAElementException("MissingSqlProvider",(expression==null?"null":expression.getClass().getName())+" :: "+(expression==null?null:expression.toString()));
    }

    @Override
    public MarshallManager getMarshallManager() {
        return marshallManager;
    }
}
