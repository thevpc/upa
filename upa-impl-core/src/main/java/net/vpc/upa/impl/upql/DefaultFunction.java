package net.vpc.upa.impl.upql;

import net.vpc.upa.FunctionDefinition;
import net.vpc.upa.Function;
import net.vpc.upa.types.DataType;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 12/14/12 12:19 AM
 */
public class DefaultFunction implements FunctionDefinition {
    private final String name;
    private final DataType dataType;
    private final Function handler;

    public DefaultFunction(String name, DataType type, Function handler) {
        this.name = name;
        this.dataType = type;
        this.handler = handler;
    }

    public String getName() {
        return name;
    }

    public DataType getDataType() {
        return dataType;
    }

    public Function getFunction() {
        return handler;
    }
}
