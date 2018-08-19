package net.vpc.upa.impl.upql.ext.expr;

import net.vpc.upa.exceptions.UPAIllegalArgumentException;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;

import java.util.ArrayList;
import java.util.List;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/16/12 Time: 10:54 PM To change
 * this template use File | Settings | File Templates.
 */
public abstract class CompiledFunction extends DefaultCompiledExpressionImpl {

    private List<CompiledExpressionExt> expressions = new ArrayList<CompiledExpressionExt>();
    private String name;

    public CompiledFunction(String name) {
        this.name = name;
    }

//    public synchronized String toSQL(boolean integrated, PersistenceUnitFilter database) {
//        StringBuffer sb = new StringBuffer(getName()).append("(");
//        int max = getArgumentsCount();
//        boolean started = false;
//        for (int i = 0; i < max; i++) {
//            Expression e = (Expression) getArgument(i);
//            if (e.isValid()) {
//                if (started) {
//                    sb.append(" , ");
//                } else {
//                    started = true;
//                }
//                sb.append(e.toSQL(true, database));
//            }
//        }
//
//        sb.append(')');
//        return sb.toString();
//    }
    public final String getName() {
        return name;
    }

    public final int getArgumentsCount() {
        return expressions.size();
    }

    public CompiledExpressionExt getArgument(int index) {
        return expressions.get(index);
    }

    protected void protectedSetArgument(int i, CompiledExpressionExt e) {
        if (e == null) {
            throw new UPAIllegalArgumentException();
        }
        if(i<expressions.size()){
            unbindChildren(this.expressions.get(i));
        }
        expressions.set(i, e);
        bindChildren(e);
    }

    protected void protectedAddArgument(CompiledExpressionExt e) {
        if (e == null) {
            throw new UPAIllegalArgumentException();
        }
        expressions.add(e);
        bindChildren(e);
    }

    public final CompiledExpressionExt getArgumentImpl(int index) {
        return null;
    }

    @Override
    public CompiledExpressionExt[] getSubExpressions() {
        return getArguments();
    }

    @Override
    public void setSubExpression(int index, CompiledExpressionExt expression) {
        protectedSetArgument(index, expression);
    }

    public CompiledExpressionExt[] getArguments() {
        int max = getArgumentsCount();
        CompiledExpressionExt[] p = new CompiledExpressionExt[max];
        for (int i = 0; i < max; i++) {
            p[i] = getArgument(i);
        }
        return p;
    }

    @Override
    public String toString() {
        StringBuilder s = new StringBuilder(getName()).append("(");
        for (int i = 0; i < getArgumentsCount(); i++) {
            if (i > 0) {
                s.append(",");
            }
            s.append(getArgument(i));
        }
        s.append(")");
        return s.toString();
    }

    @Override
    public boolean isValid() {
        int max = getArgumentsCount();
        boolean valid = max==0;
        for (int i = 0; i < max; i++) {
            CompiledExpressionExt e = getArgument(i);
            if (e.isValid()) {
                valid = true;
            }
        }
        return valid;
    }
    
    protected void protectedCopyTo(CompiledFunction o){
        for (CompiledExpressionExt element : getArguments()) {
            o.protectedAddArgument(element.copy());
        }
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
    }
    
    protected void protectedClear(){
        expressions.clear();
    }
}
