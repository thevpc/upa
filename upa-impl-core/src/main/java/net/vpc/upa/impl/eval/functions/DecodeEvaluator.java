/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.eval.functions;

import net.vpc.upa.FunctionEvalContext;
import net.vpc.upa.Function;

import java.util.Objects;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class DecodeEvaluator implements net.vpc.upa.Function {
    public static final Function INSTANCE=new DecodeEvaluator();

    public DecodeEvaluator() {
    }

    @Override
    public Object eval(FunctionEvalContext evalContext) {
        StringBuilder sb=new StringBuilder();
        Object[] args = evalContext.getArguments();
        int i = 1;
        while (i < args.length) {
            if(i<args.length-1) {
                if (Objects.equals(args[0], args[i])) {
                    return args[i + 1];
                }
                i++;
            }else {
                return args[i];
            }
            i++;
        }
        return null;
    }


    
}
