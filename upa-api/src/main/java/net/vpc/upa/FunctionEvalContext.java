/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa;

/**
 * @author taha.bensalah@gmail.com
 */
public class FunctionEvalContext {
    private String functionName;
    private Object[] arguments;
    private PersistenceUnit persistenceUnit;
    private Object compilerContext;

    public FunctionEvalContext(String functionName, Object[] arguments, PersistenceUnit persistenceUnit, Object compilerContext) {
        this.functionName = functionName;
        this.arguments = arguments;
        this.persistenceUnit = persistenceUnit;
        this.compilerContext = compilerContext;
    }

    public Object getCompilerContext() {
        return compilerContext;
    }

    public String getFunctionName() {
        return functionName;
    }

    public Object[] getArguments() {
        return arguments;
    }

    public PersistenceUnit getPersistenceUnit() {
        return persistenceUnit;
    }

}
