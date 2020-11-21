package net.thevpc.upa.impl;

import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.impl.upql.CompiledExpressionVisitor;
import net.thevpc.upa.impl.upql.ext.expr.CompiledVar;
import net.thevpc.upa.Field;

import java.util.Set;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/7/13 11:37 PM
*/
class FieldCollectorCompiledExpressionVisitor implements CompiledExpressionVisitor {
    private final Set<Field> usedFields;

    public FieldCollectorCompiledExpressionVisitor(Set<Field> usedFields) {
        this.usedFields = usedFields;
    }

    public boolean visit(CompiledExpressionExt e) {
        if (e instanceof CompiledVar) {
            CompiledVar v = (CompiledVar) e;
            if (v.getReferrer() instanceof Field) {
                usedFields.add((Field) v.getReferrer());
            }
        }
        return true;
    }
}
