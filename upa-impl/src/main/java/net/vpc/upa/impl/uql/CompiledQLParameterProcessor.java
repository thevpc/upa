package net.vpc.upa.impl.uql;

import net.vpc.upa.QLParameter;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;

import java.util.List;
import java.util.Map;

public interface CompiledQLParameterProcessor {
    void processSQLParameters(List<QLParameter> parameter, Map<String, CompiledExpressionExt> output, String message) ;
}
