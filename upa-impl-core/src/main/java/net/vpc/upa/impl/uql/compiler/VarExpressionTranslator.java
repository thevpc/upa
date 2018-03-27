/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.CompiledExpression;
import net.vpc.upa.expressions.Var;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledVar;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;

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
