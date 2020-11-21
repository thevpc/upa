package net.thevpc.upa.impl.upql;

import net.thevpc.upa.FunctionDefinition;
import net.thevpc.upa.Function;
import net.thevpc.upa.types.DataType;

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
