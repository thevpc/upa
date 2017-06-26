/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiledreplacer;

import net.vpc.upa.expressions.CompiledExpression;
import net.vpc.upa.impl.uql.CompiledExpressionFilteredReplacer;
import net.vpc.upa.impl.uql.CompiledExpressionReplacer;
import net.vpc.upa.impl.uql.compiledexpression.*;
import net.vpc.upa.impl.uql.util.UQLUtils;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class CompiledExpressionThisReplacer implements CompiledExpressionFilteredReplacer {

    private boolean varOnly;
    private String thisAlias;

    public CompiledExpressionThisReplacer(String thisAlias) {
        this(thisAlias,false);
    }

    public CompiledExpressionThisReplacer(String thisAlias,boolean varOnly) {
        this.thisAlias = thisAlias;
        this.varOnly = varOnly;
    }

    public boolean accept(DefaultCompiledExpression e) {
        if (e instanceof CompiledVar) {
            CompiledVar c = (CompiledVar) e;
            if (UQLUtils.THIS.equals(c.getName())) {
                return true;
            }
        }
        if(varOnly){
            return false;
        }
        if (e instanceof CompiledEntityName) {
            CompiledEntityName c = (CompiledEntityName) e;
            if (UQLUtils.THIS.equals(c.getName())) {
                return true;
            }
        }
        if (e instanceof CompiledEntityStatement) {
            CompiledEntityStatement c = (CompiledEntityStatement) e;
            if (UQLUtils.THIS.equals(c.getEntityAlias())) {
                return true;
            }
        }
        return false;
    }

    public CompiledExpression update(CompiledExpression e) {
        if(thisAlias==null){
            if(e instanceof CompiledVarOrMethod){
               return ((CompiledVarOrMethod) e).getChild();
            }
            //should not change
            return null;
        }
        if(e instanceof CompiledVar) {
            CompiledVar t = (CompiledVar) e;
            t.setName(thisAlias);
        }
        if(e instanceof CompiledEntityName) {
            CompiledEntityName t = (CompiledEntityName) e;
            t.setName(thisAlias);
        }
        if(e instanceof CompiledSelect) {
            CompiledSelect t = (CompiledSelect) e;
            t.setEntityAlias(thisAlias);
        }
        if(e instanceof CompiledUpdate) {
            CompiledUpdate t = (CompiledUpdate) e;
            t.setEntityAlias(thisAlias);
        }
        if(e instanceof CompiledDelete) {
            CompiledDelete t = (CompiledDelete) e;
            t.setEntityAlias(thisAlias);
        }
        if(e instanceof CompiledInsert) {
            CompiledInsert t = (CompiledInsert) e;
//            t.setEntityAlias(thisAlias);
        }
        return null;
    }
}
