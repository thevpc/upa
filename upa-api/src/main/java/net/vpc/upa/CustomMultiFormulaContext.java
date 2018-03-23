package net.vpc.upa;

import net.vpc.upa.expressions.Expression;
import net.vpc.upa.persistence.EntityExecutionContext;

import java.util.Set;

/**
 * Called once per pass to evaluate and <b>store</b> formula values for all the given fields
 * @param fields fields to update
 * @param expression entities (rows) filter
 * @param executionContext executionContext
 */
public interface CustomMultiFormulaContext extends BaseFormulaContext{
    Set<Field> getFields();
    Expression getFilter();
}
