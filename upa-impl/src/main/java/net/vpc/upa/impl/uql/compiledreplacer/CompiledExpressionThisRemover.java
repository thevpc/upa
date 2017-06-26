package net.vpc.upa.impl.uql.compiledreplacer;

import net.vpc.upa.expressions.CompiledExpression;
import net.vpc.upa.impl.uql.CompiledExpressionReplacer;
import net.vpc.upa.impl.uql.compiledexpression.*;

/**
 * Created by vpc on 6/24/17.
 */
public class CompiledExpressionThisRemover implements CompiledExpressionReplacer {





    @Override
    public CompiledExpression update(CompiledExpression e) {
        if (e instanceof CompiledVar) {
            CompiledVarOrMethod child = ((CompiledVar) e).getChild();
            if (child != null) {
                child.setParentExpression(null);
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
