package net.thevpc.upa.impl.eval;

import net.thevpc.upa.CustomMultiFormulaContext;
import net.thevpc.upa.Field;
import net.thevpc.upa.expressions.Expression;
import net.thevpc.upa.persistence.EntityExecutionContext;

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
