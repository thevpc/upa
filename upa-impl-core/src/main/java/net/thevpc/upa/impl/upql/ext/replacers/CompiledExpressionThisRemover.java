package net.thevpc.upa.impl.upql.ext.replacers;

import net.thevpc.upa.impl.upql.ext.expr.CompiledDelete;
import net.thevpc.upa.impl.upql.ext.expr.CompiledUpdate;
import net.thevpc.upa.impl.upql.ext.expr.CompiledInsert;
import net.thevpc.upa.impl.upql.ext.expr.CompiledVarOrMethod;
import net.thevpc.upa.impl.upql.ext.expr.CompiledEntityName;
import net.thevpc.upa.impl.upql.ext.expr.CompiledSelect;
import net.thevpc.upa.impl.upql.ext.expr.CompiledVar;
import net.thevpc.upa.expressions.CompiledExpression;
import net.thevpc.upa.impl.upql.CompiledExpressionReplacer;

/**
 * Created by vpc on 6/24/17.
 */
public class CompiledExpressionThisRemover implements CompiledExpressionReplacer {





    @Override
    public CompiledExpression update(CompiledExpression e) {
        if (e instanceof CompiledVar) {
            CompiledVarOrMethod child = ((CompiledVar) e).getChild();
            if (child != null) {
                child.unsetParent();
            }
            return child;
        }
        if(e instanceof CompiledEntityName) {
            CompiledEntityName t = (CompiledEntityName) e;
            t.setName(null);
        }
        if(e instanceof CompiledSelect) {
            CompiledSelect t = (CompiledSelect) e;
            t.setEntityAlias(null);
        }
        if(e instanceof CompiledUpdate) {
            CompiledUpdate t = (CompiledUpdate) e;
            t.setEntityAlias(null);
        }
        if(e instanceof CompiledDelete) {
            CompiledDelete t = (CompiledDelete) e;
            t.setEntityAlias(null);
        }
        if(e instanceof CompiledInsert) {
            CompiledInsert t = (CompiledInsert) e;
//            t.setEntityAlias(null);
        }

        return null;
    }
}
