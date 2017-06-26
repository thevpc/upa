/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa;

/**
 * @author taha.bensalah@gmail.com
 */
public class EvalContext {
    private String functionName;
    private Object[] arguments;
    private PersistenceUnit persistenceUnit;

    public EvalContext(String functionName, Object[] arguments, PersistenceUnit persistenceUnit) {
        this.functionName = functionName;
        this.arguments = arguments;
        this.persistenceUnit = persistenceUnit;
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
