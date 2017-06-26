package net.vpc.upa.impl.uql.compiledfilteredreplacers;

import net.vpc.upa.*;
import net.vpc.upa.expressions.CompiledExpression;
import net.vpc.upa.impl.uql.CompiledExpressionFilteredReplacer;
import net.vpc.upa.impl.uql.compiledexpression.CompiledVar;
import net.vpc.upa.impl.uql.compiledexpression.CompiledVarOrMethod;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;
import net.vpc.upa.impl.uql.compiledfilters.CompiledExpressionUtils;
import net.vpc.upa.persistence.ExpressionCompilerConfig;

/**
 * Created by vpc on 6/25/17.
 */
public class LifeFieldCompiledExpressionFilter implements CompiledExpressionFilteredReplacer {
    PersistenceUnit persistenceUnit;

    public LifeFieldCompiledExpressionFilter(PersistenceUnit persistenceUnit) {
        this.persistenceUnit = persistenceUnit;
    }

    @Override
    public boolean accept(DefaultCompiledExpression e) {
        if (e instanceof CompiledVar) {
            Object r = ((CompiledVar) e).getReferrer();
            if (r instanceof Field) {
                Field referrer = (Field) r;
                if (referrer.getModifiers().contains(FieldModifier.SELECT_LIVE)) {
                    Formula selectFormula = referrer.getSelectFormula();
                    return selectFormula instanceof ExpressionFormula;
                }
            }
        }
        return false;
    }

    @Override
    public CompiledExpression update(CompiledExpression e) {
        CompiledVar v = (CompiledVar) e;
        CompiledVarOrMethod c = v.getChild();
        Field referrer = (Field) v.getReferrer();
        Formula selectFormula = referrer.getSelectFormula();
        if (selectFormula instanceof ExpressionFormula) {
            CompiledExpression expr2 = persistenceUnit.getExpressionManager().compileExpression(((ExpressionFormula) selectFormula).getExpression(), new ExpressionCompilerConfig().setExpandFields(false).setValidate(false));
            //Remove this!
            expr2 = CompiledExpressionUtils.removeThisVar(expr2);
            if (c == null) {
                if (expr2 instanceof CompiledVarOrMethod) {
                    ((CompiledVarOrMethod) expr2).getFinest().setBaseReferrer(referrer);
                }
                return expr2;
            } else {
                if (expr2 instanceof CompiledVar) {
                    CompiledVar vexpr2 = (CompiledVar) expr2;
                    vexpr2.getFinest().setChild(c);
                    vexpr2.setBaseReferrer(referrer);
                    return vexpr2;
                } else {
                    throw new IllegalArgumentException("Invalid expression when expanding LiveFormula for " + referrer + " (" + expr2 + ")." + c);
                }
            }
        }
        return null;
    }
}
