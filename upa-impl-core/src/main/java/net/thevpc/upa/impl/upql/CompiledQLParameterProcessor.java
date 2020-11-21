package net.thevpc.upa.impl.upql;

import net.thevpc.upa.QLParameter;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;

import java.util.List;
import java.util.Map;

public interface CompiledQLParameterProcessor {
    void processSQLParameters(List<QLParameter> parameter, Map<String, CompiledExpressionExt> output, String message) ;
}
