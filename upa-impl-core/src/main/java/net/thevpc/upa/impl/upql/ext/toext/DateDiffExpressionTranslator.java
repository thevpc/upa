/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.upql.ext.toext;

import net.thevpc.upa.expressions.DateDiff;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.impl.upql.ExpressionTranslationManager;
import net.thevpc.upa.impl.upql.ExpressionTranslator;
import net.thevpc.upa.impl.upql.ext.expr.CompiledDateDiff;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;

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
