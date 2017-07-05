package net.vpc.upa.impl.persistence;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;
import net.vpc.upa.persistence.EntityExecutionContext;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/6/12 12:29 AM
 */
public interface SQLManager {
    void register(SQLProvider provider);

    MarshallManager getMarshallManager();

    String getSQL(DefaultCompiledExpression expression, EntityExecutionContext context, ExpressionDeclarationList declarations) throws UPAException;
}
