/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.eval.functions;

import net.thevpc.upa.FunctionEvalContext;
import net.thevpc.upa.PasswordStrategy;
import net.thevpc.upa.Function;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class PasswordQLFunction implements Function {

    private PasswordStrategy strategy;

    public PasswordQLFunction(PasswordStrategy digest) {
        this.strategy = digest;
    }

    @Override
    public Object eval(FunctionEvalContext evalContext) {
        return strategy.encode((String) evalContext.getArguments()[0]);
    }
}
