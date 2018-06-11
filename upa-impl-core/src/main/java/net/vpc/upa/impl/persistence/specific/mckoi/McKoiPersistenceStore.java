package net.vpc.upa.impl.persistence.specific.mckoi;


import net.vpc.upa.PortabilityHint;
import net.vpc.upa.Properties;
import net.vpc.upa.impl.persistence.DefaultPersistenceStore;
import net.vpc.upa.persistence.ConnectionProfile;
import net.vpc.upa.persistence.DatabaseProduct;


@PortabilityHint(target = "C#", name = "suppress")
public class McKoiPersistenceStore extends DefaultPersistenceStore {
    public void configureStore(){
        super.configureStore();
        Properties map = getStoreParameters();
        map.setBoolean("isComplexSelectSupported", Boolean.FALSE);
        map.setBoolean("isFromClauseInUpdateStatementSupported", Boolean.FALSE);
        map.setBoolean("isFromClauseInDeleteStatementSupported", Boolean.FALSE);
        map.setBoolean("isReferencingSupported", Boolean.TRUE);
        map.setBoolean("isViewSupported", Boolean.FALSE);
        getSqlManager().register(new McKoiDatePart());
        getSqlManager().register(new McKoiTypeNameSQLProvider());
        getSqlManager().register(new McKoiSelectSQLProvider());
    }

    @Override
    public int getSupportLevel(ConnectionProfile connectionProfile, Properties parameters) {
        DatabaseProduct p = connectionProfile.getDatabaseProduct();
        if(p==DatabaseProduct.MCKOI){
            return 10;
        }
        return -1;
    }




//    @Override
//    public QueryExecutor createExecutor(CompiledExpression expression, ExecutionContext qlContext, Map<String,DataType> generatedKeys)throws UPAException{
////        HashMap context = new HashMap(3);
////        String query = getSQL(expression, qlContext);
////        query = getParser().simplify(query, context);
//        QueryExecutor createExecutor = new DefaultQueryExecutor(NativeStatementType.SELECT);
//        if(expression instanceof CompiledInsertSelection){
//
//        }
//        SQLToken token = SQLToken.getForewardTokenAt(query, 0, false);
//        if ("INSERT".equalsIgnoreCase(token.getValue())) {
//            List<Param> values = ExpressionUtils.findExpressionsList(expression, new ExpressionFilter() {
//                @Override
//                public boolean accept(Expression e) {
//                    return e instanceof Param;
//                }
//            });
//            SQLToken t = SQLToken.findForwardToken(query.toUpperCase(), token.getEnd(), "SELECT", 2, 0, false);
//            if (t == null) {
//                createExecutor.addNativeStatement(new ReturnStatement(query, values,generatedKeys));
//            } else {
//                createExecutor.addNativeStatement(new InsertIntoSelectNativeStatement(query, values));
//            }
//        } else {
//            List<Param> values = ExpressionUtils.findExpressionsList(expression, new ExpressionFilter() {
//                @Override
//                public boolean accept(Expression e) {
//                    return e instanceof Param;
//                }
//            });
//            createExecutor.addNativeStatement(new ReturnStatement(simplifyQuery(query, 0, query.length(), createExecutor), values,generatedKeys));
//        }
//        return createExecutor;
//    }
//
//    public static String simplifyQuery(String query, int startIndex, int endIndex, QueryExecutor createExecutor) {
//        StringBuffer sb = new StringBuffer();
//        for (int index = startIndex; index >= startIndex && index < endIndex; ) {
//            SQLToken t = SQLToken.getForewardTokenAt(query, index, true);
//            if (t == null) {
//                index = -1;
//                break;
//            }
//            if (t.accept(SQLToken.PAR)) {
//                sb.append('(');
//                sb.append(simplifyQuery(query, t.getStart() + 1, t.getEnd() - 1, createExecutor));
//                sb.append(')');
//                index = t.getEnd();
//            } else {
//                sb.append(t.getValue());
//                index = t.getEnd();
//            }
//        }
//
//        String returned = null;
//        SQLToken lastToken = SQLToken.getForewardTokenAt(query, endIndex, true);
//        SQLToken firstToken = SQLToken.getForewardTokenAt(query, startIndex, true);
//        if (firstToken != null && firstToken.accept(2) && "SELECT".equals(firstToken.getValue().toUpperCase())) {
//            SQLToken nextToken = lastToken;
//            SQLToken previousToken = firstToken;
//            boolean isVar = false;
//            do {
//                if (nextToken != null) {
//                    nextToken = SQLToken.nextToken(query, nextToken, true);
//                    if (nextToken != null && nextToken.accept(64)) {
//                        isVar = true;
//                        break;
//                    }
//                    if (nextToken != null && (!nextToken.accept(128) && !nextToken.accept(1) && !nextToken.accept(4) || nextToken.accept(2)))
//                        nextToken = null;
//                }
//                if (previousToken == null)
//                    continue;
//                previousToken = SQLToken.previousToken(query, previousToken, true);
//                if (previousToken != null && previousToken.accept(64)) {
//                    isVar = true;
//                    break;
//                }
//                if (previousToken != null && (!previousToken.accept(128) && !previousToken.accept(1) && !previousToken.accept(4) || previousToken.accept(2)))
//                    previousToken = null;
//            } while (nextToken != null || previousToken != null);
//            if (isVar) {
//                String computation = "VAR" + UUID.randomUUID();
//                createExecutor.addNativeStatement(new ComputeStatement(computation, sb.toString(), null));
//                return '{' + computation + '}';
//            }
//            returned = sb.toString();
//        } else {
//            returned = sb.toString();
//        }
//        return returned;
//    }

}
