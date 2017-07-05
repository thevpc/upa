/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql;

import java.io.StringReader;
import java.util.*;
import java.util.logging.Level;
import java.util.logging.Logger;

import net.vpc.upa.*;
import net.vpc.upa.Function;
import net.vpc.upa.expressions.*;
import net.vpc.upa.filters.FieldFilter;
import net.vpc.upa.impl.uql.parser.syntax.FunctionFactory;
import net.vpc.upa.impl.uql.util.SimplifyVarsExpressionTransformer;
import net.vpc.upa.impl.uql.util.UserExpressionParserVisitor;
import net.vpc.upa.impl.uql.util.UserExpressionParametersMatcherVisitor;
import net.vpc.upa.impl.util.UPAUtils;
import net.vpc.upa.persistence.ExpressionCompilerConfig;
import net.vpc.upa.persistence.ResultMetaData;
import net.vpc.upa.types.DataType;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class DefaultExpressionManager implements ExpressionManager {

    private static Logger log = Logger.getLogger(DefaultExpressionManager.class.getName());
    private PersistenceUnit persistenceUnit;
    private ExpressionTranslationManager translationManager;
    private ExpressionMetadataBuilder expressionMetadataBuilder;
    private HashMap<String, FunctionDefinition> qlFunctionMap = new HashMap<String, FunctionDefinition>();
    private QLExpressionParser parser;

    public DefaultExpressionManager(PersistenceUnit persistenceUnit) {
        this.persistenceUnit = persistenceUnit;
        translationManager = new ExpressionTranslationManager(this, persistenceUnit);
        expressionMetadataBuilder = new ExpressionMetadataBuilder(this,persistenceUnit);
        parser = persistenceUnit.getFactory().createObject(QLExpressionParser.class);
    }

    public ExpressionTranslationManager getTranslationManager() {
        return translationManager;
    }

    public ResultMetaData createMetaData(Expression baseExpression, FieldFilter fieldFilter) {
        return expressionMetadataBuilder.createResultMetaData(baseExpression, fieldFilter);
    }

    @Override
    public FunctionExpression createFunctionExpression(String name, Expression[] args) {
        return FunctionFactory.createFunction(name,Arrays.asList(args));
    }

    public Expression parseExpression(Expression expression) {
        if(expression instanceof UserExpression){
            UserExpression ucce = (UserExpression) expression;
            Expression expr = parseExpression(ucce.getExpression());
            expr.visit(new UserExpressionParametersMatcherVisitor(ucce));
            return expr;
        }else{
            UserExpressionParserVisitor v=new UserExpressionParserVisitor(this);
            expression.visit(v);
            return expression;
        }
    }

    public Expression parseExpression(String expression) {
        try {
            return parser.parse(new StringReader(expression));
        } catch (net.vpc.upa.impl.uql.parser.syntax.ParseException e) {
            log.log(Level.SEVERE, "Unable to parse Expression : " + expression, e);
            throw e;
        }
    }

    public CompiledExpression compileExpression(Expression expression, ExpressionCompilerConfig config) {
        if (config == null) {
            config = new ExpressionCompilerConfig();
        }
        CompiledExpression qe = translationManager.translateExpression(expression, config);
        qe = compileExpression(qe, config);
        return qe;
    }

    public CompiledExpression compileExpression(CompiledExpression expression, ExpressionCompilerConfig config) {
        if (config == null) {
            config = new ExpressionCompilerConfig();
        }
        if (!config.isCompile()) {
            return expression;
        }
        ExpressionCompiler w=new ExpressionCompiler(expression,config, persistenceUnit);
        CompiledExpression compiledExpression = w.compile();
        if(!UPAUtils.PRODUCTION_MODE) {
            System.out.println("==========DefaultExpressionManager==============");
            System.out.println(expression);
            System.out.println(compiledExpression);
            System.out.println("==========DefaultExpressionManager==============");
            compiledExpression = w.compile();
        }
        return compiledExpression;
    }

    @Override
    public FunctionDefinition addFunction(String name, DataType type, Function function) {
        if (name == null || function == null) {
            throw new NullPointerException();
        }
        if (containsFunction(name)) {
            throw new IllegalArgumentException("Function already exists " + name);
        }
        FunctionDefinition q = new DefaultFunction(name, type, function);
        addFunction(q);
        return q;
    }

    public void addFunction(FunctionDefinition function) {
        String name = persistenceUnit.getNamingStrategy().getUniformValue(function.getName());
        qlFunctionMap.put(name, function);
    }

    public void removeFunction(String name) {
        name = persistenceUnit.getNamingStrategy().getUniformValue(name);
        if (!qlFunctionMap.containsKey(name)) {
            throw new IllegalArgumentException("No Such Function " + name);
        }
        qlFunctionMap.remove(name);
    }

    public List<FunctionDefinition> getFunctions() {
        return new ArrayList<FunctionDefinition>(qlFunctionMap.values());
    }

    public Set<String> getFunctionNames() {
        HashSet<String> keys = new HashSet<String>();
        for (FunctionDefinition f : qlFunctionMap.values()) {
            keys.add(f.getName());
        }
        return keys;
    }

    public boolean containsFunction(String name) {
        name = persistenceUnit.getNamingStrategy().getUniformValue(name);
        return qlFunctionMap.containsKey(name);
    }

    public FunctionDefinition getFunction(String name) {
        name = persistenceUnit.getNamingStrategy().getUniformValue(name);
        FunctionDefinition qlFunction = qlFunctionMap.get(name);
        if (qlFunction == null) {
            throw new IllegalArgumentException("No Such QLFunction " + name);
        }
        return qlFunction;
    }

    public PersistenceUnit getPersistenceUnit() {
        return persistenceUnit;
    }

    @Override
    public Expression simplifyExpression(Expression expression, final Map<String, Object> vars) {
        Expression e=parseExpression(expression);
        ExpressionTransformerResult e2=e.transform(new SimplifyVarsExpressionTransformer(getPersistenceUnit(),vars));
        //return createEvaluator().evalObject(e2.getExpression(),null);
        return e2.getExpression();
    }

    @Override
    public Expression simplifyExpression(String expression, Map<String, Object> vars) {
        return simplifyExpression(parseExpression(expression), vars);
    }

    @Override
    public QLEvaluator createEvaluator() {
        return getPersistenceUnit().getFactory().createObject(QLEvaluator.class);
    }
}
