package net.vpc.upa.impl.upql.ext.expr;

import net.vpc.upa.Field;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.types.DataTypeTransform;

/**
 *
 * User: taha Date: 18 juin 2003 Time: 19:31:17
 *
 */
public class CompiledParam extends DefaultCompiledExpressionImpl {

    private Object value;
    private String name;
    private boolean unspecified = true;
    private static final long serialVersionUID = 1L;

    public CompiledParam(Object value, String name, DataTypeTransform type, boolean unspecified) {
        this.value = value;
        this.name = name;
        this.unspecified = unspecified;
        if (type == null) {
            if (value == null) {
                setTypeTransform(IdentityDataTypeTransform.OBJECT);
            } else {
                setTypeTransform(IdentityDataTypeTransform.ofType(value.getClass()));
            }
        } else {
            setTypeTransform(type);
        }
    }

    @Override
    public void setTypeTransform(DataTypeTransform type) {
        super.setTypeTransform(type); //To change body of generated methods, choose Tools | Templates.
    }

    public Object getValue() {
        return value;
    }

    public String getName() {
        return name;
    }

    public void setValue(Object value) {
        this.value = value;
    }

    public boolean isUnspecified() {
        return unspecified;
    }

    public void setUnspecified(boolean unspecified) {
        this.unspecified = unspecified;
    }

    @Override
    public CompiledExpressionExt copy() {
        CompiledParam o = new CompiledParam(value, name, getTypeTransform(), unspecified);
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }
    //    public String toSQL(boolean flag, PersistenceUnitFilter database) {
//        return "?";
//    }

    @Override
    public CompiledExpressionExt[] getSubExpressions() {
        return null;
    }

    @Override
    public void setSubExpression(int index, CompiledExpressionExt expression) {
        throw new UnsupportedOperationException("Not supported.");
    }

    @Override
    public String toString() {
        return ('{' + name + "=" + (unspecified ? "?" : value) + '}');
    }

    @Override
    public DataTypeTransform getEffectiveDataType() {
        DataTypeTransform d = getTypeTransform();
        CompiledExpressionExt p = getParentExpression();
        if (p instanceof CompiledVarVal) {
            CompiledVarOrMethod v = ((CompiledVarVal) p).getVar();
            v = ((CompiledVarOrMethod) v).getDeepest();
            final Object r = v.getReferrer();
            if (r instanceof Field) {
                return ((Field) r).getEffectiveTypeTransform();
            }
        } else if ((p instanceof CompiledEquals) || (p instanceof CompiledDifferent)) {
            CompiledExpressionExt o = ((CompiledBinaryOperatorExpression) p).getOther(this);
            if (o instanceof CompiledVarOrMethod) {
                o = ((CompiledVarOrMethod) o).getDeepest();
                Object r = ((CompiledVarOrMethod) o).getReferrer();
                if (r instanceof Field) {
                    return ((Field) r).getEffectiveTypeTransform();
                }
            }
        }
        return d;
    }

}
