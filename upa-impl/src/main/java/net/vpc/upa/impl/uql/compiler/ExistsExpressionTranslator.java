/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.Exists;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.Insert;
import net.vpc.upa.expressions.Var;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledExists;
import net.vpc.upa.impl.uql.compiledexpression.CompiledInsert;
import net.vpc.upa.impl.uql.compiledexpression.CompiledQueryStatement;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class ExistsExpressionTranslator implements ExpressionTranslator {
    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        return compileInsert((Exists) o, manager,declarations);
    }

    protected CompiledExists compileInsert(Exists v, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        return new CompiledExists(
                (CompiledQueryStatement) manager.translateAny(v.getQuery(), declarations)
        );
    }
    
}
