package net.vpc.upa.impl.uql.compiledexpression;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/16/12 Time: 10:10 PM To change
 * this template use File | Settings | File Templates.
 */
public class CompiledQueryField extends CompiledNamedExpression {

    private int index=-1;
    private boolean expanded=false;
    private String alias;
    private String binding;
    private String aliasBinding;

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

    private static String resolveBinding(DefaultCompiledExpression expression) {
        if (expression instanceof CompiledVar) {
            CompiledVar cv = (CompiledVar) expression;
            CompiledVarOrMethod cv1 = cv.getDeepChild();
            if (cv1 != null && cv1 instanceof CompiledVar) {
                DefaultCompiledExpression cv2 = cv1.getParentExpression();
                if (cv2 != null && cv2 instanceof CompiledVar) {
                    return ((CompiledVar) cv2).getChildlessPath();
                }
            }
        }
        return null;
    }

    public CompiledQueryField(String alias, DefaultCompiledExpression expression/*, Object relative*/) {
        super(resolveName(alias, expression), expression);
        this.alias = alias;
        this.binding = resolveBinding(expression);
    }

    public String getAlias() {
        return alias;
    }

    public void setAlias(String alias) {
        this.alias = alias;
    }

    @Override
    public String toString() {
        DefaultCompiledExpression e = getExpression();
        return (e == null ? "NULL" : e.toString()) + (alias == null ? "" : (" " + alias));
    }

    public String getBinding() {
        return binding;
    }

    public CompiledQueryField setBinding(String binding) {
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
