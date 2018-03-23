package net.vpc.upa.impl.eval;

import net.vpc.upa.CustomMultiFormulaContext;
import net.vpc.upa.Entity;
import net.vpc.upa.Field;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.persistence.EntityExecutionContext;

import java.util.Set;

public class DefaultCustomMultiFormulaContext extends AbstractBaseFormulaContext implements CustomMultiFormulaContext {
    private Set<Field> fields;
    private Expression expression;

    public DefaultCustomMultiFormulaContext(Set<Field> fields, Expression expression, EntityExecutionContext executionContext) {
        super(executionContext);
        this.fields = fields;
        this.expression = expression;
    }

    @Override
    public Set<Field> getFields() {
        return fields;
    }

    @Override
    public Expression getFilter() {
        return expression;
    }

}
