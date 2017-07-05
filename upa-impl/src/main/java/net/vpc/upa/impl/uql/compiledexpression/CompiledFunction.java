package net.vpc.upa.impl.uql.compiledexpression;

import java.util.ArrayList;
import java.util.List;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/16/12 Time: 10:54 PM To change
 * this template use File | Settings | File Templates.
 */
public abstract class CompiledFunction extends DefaultCompiledExpressionImpl {

    private List<DefaultCompiledExpression> expressions = new ArrayList<DefaultCompiledExpression>();
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

    public DefaultCompiledExpression getArgument(int index) {
        return expressions.get(index);
    }

    protected void protectedSetArgument(int i, DefaultCompiledExpression e) {
        if (e == null) {
            throw new IllegalArgumentException();
        }
        if(i<expressions.size()){
            unbindChildren(this.expressions.get(i));
        }
        expressions.set(i, e);
        bindChildren(e);
    }

    protected void protectedAddArgument(DefaultCompiledExpression e) {
        if (e == null) {
            throw new IllegalArgumentException();
        }
        expressions.add(e);
        bindChildren(e);
    }

    public final DefaultCompiledExpression getArgumentImpl(int index) {
        return null;
    }

    @Override
    public DefaultCompiledExpression[] getSubExpressions() {
        return getArguments();
    }

    @Override
    public void setSubExpression(int index, DefaultCompiledExpression expression) {
        protectedSetArgument(index, expression);
    }

    public DefaultCompiledExpression[] getArguments() {
        int max = getArgumentsCount();
        DefaultCompiledExpression[] p = new DefaultCompiledExpression[max];
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
            DefaultCompiledExpression e = getArgument(i);
            if (e.isValid()) {
                valid = true;
            }
        }
        return valid;
    }
    
    protected void protectedCopyTo(CompiledFunction o){
        for (DefaultCompiledExpression element : getArguments()) {
            o.protectedAddArgument(element.copy());
        }
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
    }
    
    protected void protectedClear(){
        expressions.clear();
    }
}
