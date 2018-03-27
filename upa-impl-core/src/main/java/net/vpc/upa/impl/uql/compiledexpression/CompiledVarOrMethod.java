/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.Field;
import net.vpc.upa.impl.uql.BindingId;
import net.vpc.upa.impl.uql.ExpressionDeclaration;
import net.vpc.upa.impl.util.UPAUtils;
import net.vpc.upa.types.DataTypeTransform;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public abstract class CompiledVarOrMethod extends DefaultCompiledExpressionImpl {

    private CompiledVarOrMethod child;
    private Object referrer;
    private String name;
    private BindingId binding;
    private ExpressionDeclaration implicitDeclaration;

    public CompiledVarOrMethod() {
    }

    public CompiledVarOrMethod getChild() {
        return child;
    }

    public void setChild(CompiledVarOrMethod child) {
        if(child!=this.child) {
            unbindChildren(this.child);
            this.child = child;
            bindChildren(child);
        }
    }

    public ExpressionDeclaration getImplicitDeclaration() {
        return implicitDeclaration;
    }

    public void setImplicitDeclaration(ExpressionDeclaration implicitDeclaration) {
        this.implicitDeclaration = implicitDeclaration;
    }

    public Object getReferrer() {
        return referrer;
    }

    public void setReferrer(Object referrer) {
        this.referrer = referrer;
        if (this.referrer instanceof Field) {
            this.setTypeTransform(UPAUtils.getTypeTransformOrIdentity((Field) referrer));
        }
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public BindingId getBinding() {
        return binding;
    }

    public void setBinding(BindingId binding) {
        this.binding = binding;
    }

    @Override
    public DataTypeTransform getEffectiveDataType() {
        CompiledVarOrMethod c = getChild();
        if(c!=null){
            return c.getEffectiveDataType();
        }
        return getTypeTransform();
    }
    
    public CompiledVarOrMethod getDeepest(){
        CompiledVarOrMethod c = getDeepChild();
        if(c==null){
            return this;
        }
        return c;
    }
    
    public CompiledVarOrMethod getDeepChild(){
        CompiledVarOrMethod c = getChild();
        if(c==null){
            return null;
        }
        if(c.getChild()==null){
            return c;
        }
        return c.getDeepChild();
    }
}
