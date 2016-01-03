/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import java.util.logging.Level;
import net.vpc.upa.expressions.Var;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledVar;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class VarExpressionTranslator implements ExpressionTranslator {
    private final ExpressionTranslationManager outer;

    public VarExpressionTranslator(final ExpressionTranslationManager outer) {
        this.outer = outer;
    }

    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager expressionTranslationManager, ExpressionDeclarationList declarations) {
        return compileVar((Var) o, declarations);
    }
    
    protected CompiledVar compileVar(Var v, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledVar p = null;
        if (v.getParent() != null) {
            p = compileVar(v.getParent(), declarations);
        }
        if (p == null) {
            return new CompiledVar(v.getName());
        } else {
            CompiledVar r = new CompiledVar(v.getName());
            ((CompiledVar)p.getFinest()).setChild(r);
            return p;
        }
    }
}
