/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.eval.functions;

import net.vpc.upa.EvalContext;
import net.vpc.upa.PasswordStrategy;
import net.vpc.upa.Function;

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
    public Object eval(EvalContext evalContext) {
        return strategy.encode((String) evalContext.getArguments()[0]);
    }
}
