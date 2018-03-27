/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.eval.functions;

import net.vpc.upa.FunctionEvalContext;
import net.vpc.upa.Function;
import net.vpc.upa.expressions.Literal;
import net.vpc.upa.impl.util.IOUtils;

/**
 * @author taha.bensalah@gmail.com
 */
public class FileExistsEvaluator implements net.vpc.upa.Function {
    public static final Function INSTANCE=new FileExistsEvaluator();

    public FileExistsEvaluator() {
    }

    @Override
    public Object eval(FunctionEvalContext evalContext) {
        Object o = evalContext.getArguments()[0];
        String file = o == null ? "" : o.toString();
        if (file == null) {
            return Literal.FALSE;
        }
        return IOUtils.createFile(file).exists() ? Literal.TRUE : Literal.FALSE;
    }


}
