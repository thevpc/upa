/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.upql.ext.toext;

import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.expressions.CompiledExpression;
import net.thevpc.upa.expressions.Var;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.impl.upql.ExpressionTranslationManager;
import net.thevpc.upa.impl.upql.ExpressionTranslator;
import net.thevpc.upa.impl.upql.ext.expr.CompiledVar;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class VarExpressionTranslator implements ExpressionTranslator {

    public VarExpressionTranslator() {

    }

    public CompiledExpressionExt translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        return compileVar((Var) o, manager,declarations);
    }
    
    protected CompiledVar compileVar(Var v, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledExpression p = null;
        if (v.getApplier() != null) {
            p = manager.translateAny(v.getApplier(), declarations);
        }
        if (p == null) {
            return new CompiledVar(v.getName());
        } else {
            CompiledVar r = new CompiledVar(v.getName());
            if(p instanceof CompiledVar) {
                ((CompiledVar) ((CompiledVar)p).getDeepest()).setChild(r);
                return (CompiledVar) p;
            }else{
                throw new UPAException("Unsupported");
            }
        }
    }
}
