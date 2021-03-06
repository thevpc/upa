package net.thevpc.upa.impl.persistence.specific.mckoi;

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

@PortabilityHint(target = "C#", name = "suppress")
public class McKoiPersistenceStore extends DefaultPersistenceStore {

    public void configureStore() {
        super.configureStore();
        Properties map = getStoreParameters();
        map.setBoolean(PARAM_IS_COMPLEX_SELECT_SUPPORTED, Boolean.FALSE);
        map.setBoolean(PARAM_IS_FROM_CLAUSE_IN_UPDATE_STATMENT_SUPPORTED, Boolean.FALSE);
        map.setBoolean(PARAM_IS_FROM_CLAUSE_IN_DELETE_STATMENT_SUPPORTED, Boolean.FALSE);
        map.setBoolean(PARAM_IS_REFERENCING_SUPPORTED, Boolean.TRUE);
        map.setBoolean(PARAM_IS_VIEW_SUPPORTED, Boolean.FALSE);
        getSqlManager().register(new McKoiDatePart());
        getSqlManager().register(new McKoiSelectSQLProvider());
    }

    @Override
    public int getSupportLevel(ConnectionProfile connectionProfile, Properties parameters) {
        DatabaseProduct p = connectionProfile.getDatabaseProduct();
        if (p == DatabaseProduct.MCKOI) {
            return 10;
        }
        return -1;
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
                return new SqlTypeName("CLOB");
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
