package net.vpc.upa.impl.uql.parser;

//package net.vpc.upa.impl.persistence.parser;
//
//
//import net.vpc.upa.persistence.ExecutionContext;
//import net.vpc.upa.expression.Expression;
//import org.slf4j.Logger;
//import org.slf4j.LoggerFactory;
//
//import java.util.*;
//
///**
// * User: taha
// * Date: 25 juin 2003
// * Time: 16:27:41
// */
//public class SQLParser {
//    protected static Logger log = Logger.getLogger(SQLParser.class);
//    static final public FunctionSQLProvider DEFAULT_FUNCTION = new FunctionSQLProvider(null) {
//        @Override
//        public String getSQL(Expression o, ExecutionContext qlContext) {
//            return null;
//        }
//
//        public String simplify(String functionName, String[] params, Map<String, Object> context) {
//            log.warn("UNKNOWN DBFUNCTION " + functionName);
//            //log.log(Level.WARNING,"UNKNOWN DBFUNCTION " + functionName);
//            StringBuilder sb = new StringBuilder(functionName);
//            if (params != null) {
//                sb.append('(');
//                if (params.length > 0) {
//                    sb.append(params[0]);
//                    for (int i = 1; i < params.length; i++) {
//                        sb.append(',');
//                        sb.append(params[i]);
//                    }
//                }
//                sb.append(')');
//            }
//            return sb.toString();
//        }
//    };
//    private Map<String,FunctionSQLProvider> registeredFunctionsMap = new Hashtable<String, FunctionSQLProvider>();
//    private boolean functionParenthesesRequired;
//
//
//    public SQLParser() {
//        functionParenthesesRequired = true;
//    }
//
//    public void registerFunction(String functionName, FunctionSQLProvider function) {
//        registeredFunctionsMap.put(functionName.toLowerCase(), function);
//    }
//
//    public void unregisterFunction(String functionName) {
//        registeredFunctionsMap.remove(functionName.toLowerCase());
//    }
//
//    public FunctionSQLProvider getFunction(String functionName) {
//        FunctionSQLProvider functionHandler = (FunctionSQLProvider) registeredFunctionsMap.get(functionName.toLowerCase());
//        if (functionHandler == null) {
//            return DEFAULT_FUNCTION;
//        }
//        return functionHandler;
//    }
//
//    public void unregisterAllFunctions() {
//        registeredFunctionsMap.clear();
//    }
//
//    public String[] parseCommaSeparatedParams(String query, int startIndex, int endIndex) {
//        List<String> functionParamsList = new ArrayList<String>();
//        int fct_startIndex = startIndex;
//        int fct_endIndex = endIndex;
//        StringBuffer currentParam = null;
//        while (fct_startIndex < fct_endIndex) {
//            SQLToken token = SQLToken.getForewardTokenAt(query, fct_startIndex, true);
//            if (token == null) {
//                // no more params
//                fct_startIndex = endIndex;
//                break;
//            } else if (token.accept(SQLToken.WHITE)) {
//                if (currentParam == null) {
//                    // ignore
//                } else {
//                    currentParam.append(token.getValue());
//                }
//            } else if (token.accept(SQLToken.SEPARATOR) && ",".equals(token.getValue())) {
//                if (currentParam == null) {
//                    functionParamsList.add("");
//                    // ignore
//                } else {
//                    functionParamsList.add(currentParam.toString().trim());
//                    currentParam = null;
//                }
//            } else {
//                if (currentParam == null) {
//                    currentParam = new StringBuffer();
//                    currentParam.append(token.getValue());
//                    // ignore
//                } else {
//                    currentParam.append(token.getValue());
//                }
//            }
//            fct_startIndex = token.getEnd();
//        }
//        if (currentParam != null) {
//            functionParamsList.add(currentParam.toString().trim());
//            currentParam = null;
//        }
//        return (String[]) functionParamsList.toArray(new String[functionParamsList.size()]);
//    }
//
//    public String simplify(String query, Map<String, Object> context)  {
//        int startIndex = 0;
//        int endIndex = query.length();
//        StringBuilder sb = new StringBuilder();
////        SQLToken previous_token = null;
////        SQLToken before_previous_token = null;
//        for (int index = startIndex; index >= startIndex && index < endIndex; ) {
//            SQLToken t = SQLToken.getForewardTokenAt(query, index, true);
//            if (t == null) {
//                index = -1;
//                break;
//            } else if (t.accept(SQLToken.VAR)) {
//                SQLToken next = SQLToken.getForewardTokenAt(query, t.getEnd(), true);
//                if (next != null && next.accept(SQLToken.WHITE)) {
//                    SQLToken next_next = SQLToken.getForewardTokenAt(query, next.getEnd(), true);
//                    if (next_next != null && next_next.accept(SQLToken.PAR)) {
//                        String[] params = parseCommaSeparatedParams(query, next_next.getStart() + 1, next_next.getEnd() - 1);
//                        for (int i = 0; i < params.length; i++) {
//                            params[i] = simplify(params[i], context);
//                        }
//                        if (!isFunctionSupported(t.getValue(), params)) {
//                            throw new IllegalArgumentException("Function " + t.getValue() + "(<" + params.length + " params>) is not supported");
//                        }
//                        sb.append(getFunction(t.getValue()).simplify(t.getValue(), params, context));
//                        index = next_next.getEnd();
//                    } else {
//                        sb.append(t.getValue());
//                        index = t.getEnd();
//                    }
//                } else if (next != null && next.accept(SQLToken.PAR)) {
//                    String[] params = parseCommaSeparatedParams(query, next.getStart() + 1, next.getEnd() - 1);
//                    for (int i = 0; i < params.length; i++) {
//                        params[i] = simplify(params[i], context);
//                    }
//                    sb.append(getFunction(t.getValue()).simplify(t.getValue(), params, context));
//                    index = next.getEnd();
//                } else {
//                    sb.append(t.getValue());
//                    index = t.getEnd();
//                }
//            } else if (t.accept(SQLToken.PAR)) {
//                sb.append('(');
//                if (t.getEnd() < 0) {
//                    throw new IllegalArgumentException("Expected closing parentheses near '" + query.substring(t.getStart() - 8, t.getStart() + 8));
//                }
//                sb.append(simplify(t.getValue().substring(1, t.getValue().length() - 1), context));
//                sb.append(')');
//                index = t.getEnd();
//            } else {
//                sb.append(t.getValue());
//                index = t.getEnd();
//            }
//        }
//        return sb.toString();
//    }
//
//    public boolean isFunctionSupported(String functionName, String[] params) {
//        return true;
//    }
//
//    public boolean isFunctionParenthesesRequired() {
//        return functionParenthesesRequired;
//    }
//
//    public void setFunctionParenthesesRequired(boolean functionParenthesesRequired) {
//        this.functionParenthesesRequired = functionParenthesesRequired;
//    }
//
//}
