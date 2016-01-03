/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.Field;
import net.vpc.upa.impl.util.UPAUtils;
import net.vpc.upa.types.DataType;
import net.vpc.upa.types.DataTypeTransform;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public abstract class CompiledVarOrMethod extends DefaultCompiledExpressionImpl {

    private CompiledVarOrMethod child;
    private Object referrer;
    private String name;
    private String binding;

    public CompiledVarOrMethod() {
    }

    public CompiledVarOrMethod getChild() {
        return child;
    }

    public void setChild(CompiledVarOrMethod child) {
        this.child = child;
        prepareChildren(child);
    }

    public Object getReferrer() {
        return referrer;
    }

    public void setReferrer(Object referrer) {
        this.referrer = referrer;
        if (this.referrer instanceof Field) {
            this.setDataType(UPAUtils.getTypeTransformOrIdentity((Field) referrer));
        }
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getBinding() {
        return binding;
    }

    public void setBinding(String binding) {
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
    
    public CompiledVarOrMethod getFinest(){
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
