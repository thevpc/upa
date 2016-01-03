package net.vpc.upa.impl.persistence;

import net.vpc.upa.Record;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.persistence.FieldPersister;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 12/17/12 12:23 AM
 */
public class ExpressionFieldPersister implements FieldPersister {
    private String field;
    private Expression expression;

    public ExpressionFieldPersister(String field, Expression expression) {
        this.field = field;
        this.expression = expression;
    }

    @Override
    public void beforePersist(Record record, EntityExecutionContext context) throws UPAException {
        record.setObject(field,expression);
    }

    @Override
    public void afterPersist(Record record, EntityExecutionContext context) throws UPAException {
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        ExpressionFieldPersister that = (ExpressionFieldPersister) o;

        if (expression != null ? !expression.equals(that.expression) : that.expression != null) return false;
        if (field != null ? !field.equals(that.field) : that.field != null) return false;

        return true;
    }

    @Override
    public int hashCode() {
        int result = field != null ? field.hashCode() : 0;
        result = 31 * result + (expression != null ? expression.hashCode() : 0);
        return result;
    }
}
