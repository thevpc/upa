/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql;

import java.io.StringReader;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Set;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.ExpressionManager;
import net.vpc.upa.FunctionDefinition;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.Function;
import net.vpc.upa.expressions.*;
import net.vpc.upa.filters.FieldFilter;
import net.vpc.upa.impl.uql.parser.syntax.UQLParser;
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
    private ExpressionValidationManager validationManager;
    private ExpressionMetadataBuilder expressionMetadataBuilder;
    private HashMap<String, FunctionDefinition> qlFunctionMap = new HashMap<String, FunctionDefinition>();

    public DefaultExpressionManager(PersistenceUnit persistenceUnit) {
        this.persistenceUnit = persistenceUnit;
        translationManager = new ExpressionTranslationManager(this, persistenceUnit);
        validationManager = new ExpressionValidationManager(persistenceUnit);
        expressionMetadataBuilder = new ExpressionMetadataBuilder(this,persistenceUnit);
    }

    public ExpressionTranslationManager getTranslationManager() {
        return translationManager;
    }

    public ExpressionValidationManager getValidationManager() {
        return validationManager;
    }

    public ResultMetaData createMetaData(Expression baseExpression, FieldFilter fieldFilter) {
        return expressionMetadataBuilder.createResultMetaData(baseExpression, fieldFilter);
    }
    public Expression parseExpression(final UserExpression expression) {
        Expression expr = parseExpression(expression.getExpression());
        expr.visit(new UserExpressionToExpressionVisitor(expression));
        return expr;
    }
    public Expression parseExpression(String expression) {
        UQLParser p = new UQLParser(new StringReader(expression));
        try {
            return p.Any();
        } catch (net.vpc.upa.impl.uql.parser.syntax.ParseException e) {
            log.log(Level.SEVERE, "Unable to parse Expression : " + expression, e);
            throw e;
        }
    }

    public CompiledExpression compileExpression(Expression expression, ExpressionCompilerConfig config) {
        if (config == null) {
            config = new ExpressionCompilerConfig();
        }
        CompiledExpression qe = translationManager.compileExpression(expression, config);
        qe = compileExpression(qe, config);
        return qe;
    }

    public CompiledExpression compileExpression(CompiledExpression expression, ExpressionCompilerConfig config) {
        if (config == null) {
            config = new ExpressionCompilerConfig();
        }
        if (config.isValidate() || config.isExpandFields()) {
            expression=validationManager.validateExpression(expression, config);
        }
        return expression;
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

}
