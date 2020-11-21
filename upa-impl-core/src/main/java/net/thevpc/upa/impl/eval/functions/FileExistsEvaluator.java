/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.eval.functions;

import net.thevpc.upa.impl.util.IOUtils;
import net.thevpc.upa.FunctionEvalContext;
import net.thevpc.upa.Function;
import net.thevpc.upa.expressions.Literal;

/**
 * @author taha.bensalah@gmail.com
 */
public class FileExistsEvaluator implements Function {
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
