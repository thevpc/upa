/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.DateDiff;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledDateDiff;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class DateDiffExpressionTranslator implements ExpressionTranslator {
    public CompiledExpressionExt translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        return compileDateDiff((DateDiff) o,manager, declarations);
    }

    protected CompiledDateDiff compileDateDiff(DateDiff v, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledDateDiff s = new CompiledDateDiff(v.getDatePartType()
                , manager.translateAny(v.getStart(), declarations)
                , manager.translateAny(v.getEnd(), declarations));
        //        s.setDeclarationList(declarations);
        return s;
    }
    
}
