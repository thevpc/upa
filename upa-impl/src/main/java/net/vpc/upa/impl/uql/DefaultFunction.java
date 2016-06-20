package net.vpc.upa.impl.uql;

import net.vpc.upa.FunctionDefinition;
import net.vpc.upa.Function;
import net.vpc.upa.types.DataType;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 12/14/12 12:19 AM
 */
public class DefaultFunction implements FunctionDefinition {
    private String name;
    private DataType type;
    private Function handler;

    public DefaultFunction(String name, DataType type, Function handler) {
        this.name = name;
        this.type = type;
        this.handler = handler;
    }

    public String getName() {
        return name;
    }

    public DataType getDataType() {
        return type;
    }

    public Function getFunction() {
        return handler;
    }
}
