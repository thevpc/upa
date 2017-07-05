package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.impl.uql.BindingId;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/16/12 Time: 10:10 PM To change
 * this template use File | Settings | File Templates.
 */
public class CompiledQueryField extends DefaultCompiledExpressionImpl {
    private String name;
    private DefaultCompiledExpression expression;

    private int index=-1;
    private boolean expanded=false;
    private String alias;
    private BindingId binding;
    private String aliasBinding;
    public CompiledQueryField(String alias, DefaultCompiledExpression expression/*, Object relative*/) {
        this(resolveName(alias, expression), expression,-1,false,alias,null,null);
        this.alias = alias;
        this.binding = resolveBinding(expression);
    }
    public CompiledQueryField(String name, DefaultCompiledExpression expression, int index, boolean expanded, String alias, BindingId binding, String aliasBinding) {
//        super(name, expression);
        this.name = name;
        setExpression(expression);
        this.index = index;
        this.expanded = expanded;
        this.alias = alias;
        this.binding = binding;
        this.aliasBinding = aliasBinding;
        bindChildren(expression);

    }

    @Override
    public DefaultCompiledExpression[] getSubExpressions() {
        return new DefaultCompiledExpression[]{expression};
    }

    @Override
    public void setSubExpression(int index, DefaultCompiledExpression expression) {
        if(index==0){
            setExpression(this.expression);
        }
    }

    @Override
    public DefaultCompiledExpression copy() {
        return new CompiledQueryField(name, expression, index, expanded, alias, binding, aliasBinding);
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public DefaultCompiledExpression getExpression() {
        return expression;
    }

    public void setExpression(DefaultCompiledExpression expression) {
        unbindChildren(this.expression);
        this.expression = expression;
        bindChildren(expression);
    }

    private static String resolveName(String alias, DefaultCompiledExpression expression) {
        if (alias != null) {
            return alias;
        }
        if (expression instanceof CompiledVar) {
            CompiledVar cv = (CompiledVar) expression;
            CompiledVarOrMethod dc = cv.getDeepChild();
            return (dc == null ? cv : dc).getName();
        }
        return null;
    }

    private static BindingId resolveBinding(DefaultCompiledExpression expression) {
        if (expression instanceof CompiledVar) {
            CompiledVar cv = (CompiledVar) expression;
            CompiledVarOrMethod cv1 = cv.getDeepChild();
            if (cv1 != null && cv1 instanceof CompiledVar) {
                DefaultCompiledExpression cv2 = cv1.getParentExpression();
                if (cv2 != null && cv2 instanceof CompiledVar) {
                    return ((CompiledVar) cv2).getBinding();
                }
            }
        }
        return null;
    }



    public String getAlias() {
        return alias;
    }

    public CompiledQueryField setAlias(String alias) {
        this.alias = alias;
        return this;
    }

    @Override
    public String toString() {
        DefaultCompiledExpression e = getExpression();
        return (e == null ? "NULL" : e.toString()) + (alias == null ? "" : (" " + alias));
    }

    public BindingId getBinding() {
        return binding;
    }

    public CompiledQueryField setBinding(BindingId binding) {
        this.binding = binding;
        return this;
    }

    public String getAliasBinding() {
        return aliasBinding;
    }

    public CompiledQueryField setAliasBinding(String aliasBinding) {
        this.aliasBinding = aliasBinding;
        return this;
    }

    public int getIndex() {
        return index;
    }

    public CompiledQueryField setIndex(int index) {
        this.index = index;
        return this;
    }

    public boolean isExpanded() {
        return expanded;
    }

    public CompiledQueryField setExpanded(boolean expanded) {
        this.expanded = expanded;
        return this;
    }
}
