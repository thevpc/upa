package net.vpc.upa.impl.upql.ext.expr;

import net.vpc.upa.Entity;
import net.vpc.upa.Field;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.upql.BindingId;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/16/12 Time: 10:10 PM To change
 * this template use File | Settings | File Templates.
 */
public class CompiledQueryField extends DefaultCompiledExpressionImpl {
    private String name;
    private CompiledExpressionExt expression;

    private int index=-1;
    private boolean expanded=false;
    private String alias;
    private BindingId binding;
    private String aliasBinding;
    private boolean partialObject;
    private Field referrerField;
    private Entity parentBindingEntity;
    public CompiledQueryField(String alias, CompiledExpressionExt expression/*, Object relative*/) {
        this(resolveName(alias, expression), expression,-1,false,alias,null,null,false);
        this.alias = alias;
        this.binding = resolveBinding(expression);
    }

    public CompiledQueryField(String name, CompiledExpressionExt expression, int index, boolean expanded, String alias, BindingId binding, String aliasBinding) {
        this(name, expression, index,expanded,alias,binding,aliasBinding,false);
    }

    public CompiledQueryField(String name, CompiledExpressionExt expression, int index, boolean expanded, String alias, BindingId binding, String aliasBinding,boolean partialObject) {
//        super(name, expression);
        this.name = name;
        setExpression(expression);
        this.index = index;
        this.expanded = expanded;
        this.alias = alias;
        this.binding = binding;
        this.aliasBinding = aliasBinding;
        this.partialObject = partialObject;
        bindChildren(expression);
    }

    public Field getReferrerField() {
        return referrerField;
    }

    public void setReferrerField(Field referrerField) {
        this.referrerField = referrerField;
    }

    public void setPartialObject(boolean partialObject) {
        this.partialObject = partialObject;
    }

    public Entity getParentBindingEntity() {
        return parentBindingEntity;
    }

    public void setParentBindingEntity(Entity parentBindingEntity) {
        this.parentBindingEntity = parentBindingEntity;
    }

    public boolean isPartialObject() {
        return partialObject;
    }

    @Override
    public CompiledExpressionExt[] getSubExpressions() {
        return new CompiledExpressionExt[]{expression};
    }

    @Override
    public void setSubExpression(int index, CompiledExpressionExt expression) {
        if(index==0){
            setExpression(this.expression);
        }
    }

    @Override
    public CompiledExpressionExt copy() {
        CompiledQueryField compiledQueryField = new CompiledQueryField(name, expression, index, expanded, alias, binding, aliasBinding, partialObject);
        compiledQueryField.referrerField=referrerField;
        compiledQueryField.parentBindingEntity = parentBindingEntity;
        return compiledQueryField;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public CompiledExpressionExt getExpression() {
        return expression;
    }

    public void setExpression(CompiledExpressionExt expression) {
        unbindChildren(this.expression);
        this.expression = expression;
        bindChildren(expression);
    }

    private static String resolveName(String alias, CompiledExpressionExt expression) {
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

    private static BindingId resolveBinding(CompiledExpressionExt expression) {
        if (expression instanceof CompiledVar) {
            CompiledVar cv = (CompiledVar) expression;
            CompiledVarOrMethod cv1 = cv.getDeepChild();
            if (cv1 != null && cv1 instanceof CompiledVar) {
                CompiledExpressionExt cv2 = cv1.getParentExpression();
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
        CompiledExpressionExt e = getExpression();
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
