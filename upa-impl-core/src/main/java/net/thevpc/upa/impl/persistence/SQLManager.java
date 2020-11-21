package net.thevpc.upa.impl.persistence;

import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.persistence.EntityExecutionContext;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/6/12 12:29 AM
 */
public interface SQLManager {
    void register(SQLProvider provider);

    MarshallManager getMarshallManager();

    String getSQL(CompiledExpressionExt expression, EntityExecutionContext context, ExpressionDeclarationList declarations) throws UPAException;
}
