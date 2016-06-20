/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql;

import java.io.File;
import net.vpc.upa.QLEvaluator;
import net.vpc.upa.QLTypeEvaluator;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.Function;

/**
 *
 * @author vpc
 */
class FileExistsExpressionEvaluator implements QLTypeEvaluator {

    public FileExistsExpressionEvaluator() {
    }

    @Override
    public Object evalObject(Expression e, QLEvaluator evaluator, Object context) {
        Function f = (Function) e;
        if (f.getArgumentsCount() != 1) {
            throw new IllegalArgumentException("file_exists requires 1 arg");
        }
        Object oo = evaluator.evalObject(f.getArguments()[0], context);
        String file = oo == null ? "" : oo.toString();
        if (file == null) {
            return false;
        }
        return new File(file).exists();
    }
    
}
