package net.vpc.upa.impl.uql;

import net.vpc.upa.QLParameter;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

import java.util.List;
import java.util.Map;

public interface CompiledQLParameterProcessor {
    void processSQLParameters(List<QLParameter> parameter, Map<String, DefaultCompiledExpression> output, String message) ;
}
