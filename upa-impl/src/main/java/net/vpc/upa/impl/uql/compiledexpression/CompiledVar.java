package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.Field;
import net.vpc.upa.expressions.CompiledExpression;
import net.vpc.upa.expressions.ExpressionHelper;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.uql.BindingId;

public class CompiledVar extends CompiledVarOrMethod {

    public static final char DOT = '.';
    private static final long serialVersionUID = 1L;

    public CompiledVar(Field field) {
        this(field.getName(), field,null);
    }

    public CompiledVar(String name) {
        this(name, null,null);
    }

    public CompiledVar(String name, Object referrer,BindingId binding) {
        setName(name);
        setReferrer(referrer);
        setBinding(binding);
    }

    @Override
    public CompiledExpressionExt copy() {
        CompiledVar o = new CompiledVar(getName(), getReferrer(),getBinding());
        CompiledVarOrMethod c = getChild();
        if (c != null) {
            c = (CompiledVarOrMethod) c.copy();
        }
        o.setChild(c);
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        o.setImplicitDeclaration(getImplicitDeclaration());
        return o;
    }

    public CompiledExpression getNonVarParent() {
        CompiledExpressionExt p=getParentExpression();
        while(p!=null){
            if(!(p instanceof CompiledVarOrMethod)){
                return p;
            }
            p=p.getParentExpression();
        }
        return null;
    }
    
//    public String getChildlessPath() {
//        StringBuilder v = new StringBuilder();
//        if (getParentExpression() != null) {
//            if (getParentExpression() instanceof CompiledVar) {
//                v.append(((CompiledVar) getParentExpression()).getChildlessPath());
//            } else {
//                v.append(getParentExpression().toString());
//            }
//            v.append(".");
//        }
//        v.append(getName());
//        return v.toString();
//    }

    @Override
    public String toString() {
        StringBuilder v = new StringBuilder();
        v.append(ExpressionHelper.escapeIdentifier(getName()));
        if (getChild() != null) {
            v.append(".");
            v.append(getChild().toString());
        }
        return v.toString();
    }

    @Override
    public void setSubExpression(int index, CompiledExpressionExt expression) {
        if (index == 0) {
            setChild((CompiledVarOrMethod) expression);
        }else {
            throw new UnsupportedOperationException();
        }
    }

    @Override
    public CompiledExpressionExt[] getSubExpressions() {
        CompiledExpressionExt c = getChild();
        return c == null ? null : new CompiledExpressionExt[]{c};
    }
}
