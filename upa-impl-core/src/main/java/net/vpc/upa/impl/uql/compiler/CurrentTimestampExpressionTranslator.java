/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.CurrentTimestamp;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledCurrentTimestamp;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class CurrentTimestampExpressionTranslator implements ExpressionTranslator {
    public CompiledExpressionExt translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        return compileCurrentTimestamp((CurrentTimestamp) o, declarations);
    }

    protected CompiledCurrentTimestamp compileCurrentTimestamp(CurrentTimestamp v, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledCurrentTimestamp s = new CompiledCurrentTimestamp();
        //        s.setDeclarationList(declarations);
        return s;
    }
    
}
