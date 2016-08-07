package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.Field;
import net.vpc.upa.expressions.CompiledExpression;
import net.vpc.upa.expressions.ExpressionHelper;

// Referenced classes of package net.vpc.lib.pheromone.ariana.database.sql:
//            Expression
public class CompiledVar extends CompiledVarOrMethod {

    public static final char DOT = '.';
    private static final long serialVersionUID = 1L;
    private Object oldReferrer;

    public CompiledVar(Field field) {
        this(field.getName(), field);
    }

    //priceTaxFree
    public CompiledVar(String name) {
        this(name, null);
    }

    public Object getOldReferrer() {
        return oldReferrer;
    }

    public void setOldReferrer(Object oldReferrer) {
        this.oldReferrer = oldReferrer;
    }

    public CompiledVar(String name, Object referrer) {
        setName(name);
        setReferrer(referrer);
    }

    @Override
    public DefaultCompiledExpression copy() {
        CompiledVar o = new CompiledVar(getName(), getReferrer());
        CompiledVarOrMethod c = getChild();
        if (c != null) {
            c = (CompiledVarOrMethod) c.copy();
        }
        o.setChild(c);
        o.setBinding(getBinding());
        o.setDescription(getDescription());
        o.setOldReferrer(getOldReferrer());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }

    public CompiledExpression getNonVarParent() {
        DefaultCompiledExpression p=getParentExpression();
        while(p!=null){
            if(!(p instanceof CompiledVarOrMethod)){
                return p;
            }
            p=p.getParentExpression();
        }
        return null;
    }
    
    public String getChildlessPath() {
        StringBuilder v = new StringBuilder();
        if (getParentExpression() != null) {
            v.append(".");
            if (getParentExpression() instanceof CompiledVar) {
                v.append(((CompiledVar) getParentExpression()).getChildlessPath());
            } else {
                v.append(getParentExpression().toString());
            }
        }
        v.append(getName());
        return v.toString();
    }

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
    public void setSubExpression(int index, DefaultCompiledExpression expression) {
        if (index == 0) {
            setChild((CompiledVarOrMethod) expression);
        }
        throw new UnsupportedOperationException();
    }

    @Override
    public DefaultCompiledExpression[] getSubExpressions() {
        DefaultCompiledExpression c = getChild();
        return c == null ? null : new DefaultCompiledExpression[]{c};
    }
}
