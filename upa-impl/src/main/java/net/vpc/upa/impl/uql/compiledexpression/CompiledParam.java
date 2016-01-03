package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.Field;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.impl.util.UPAUtils;
import net.vpc.upa.types.DataTypeTransform;

/**
 *
 * User: taha Date: 18 juin 2003 Time: 19:31:17
 *
 */
public class CompiledParam extends DefaultCompiledExpressionImpl {

    private Object object;
    private String name;
    private boolean unspecified = true;
    private static final long serialVersionUID = 1L;

    public CompiledParam(Object object, String name, DataTypeTransform type, boolean unspecified) {
        this.object = object;
        this.name = name;
        this.unspecified = unspecified;
        if (type == null) {
            if (object == null) {
                setDataType(IdentityDataTypeTransform.OBJECT);
            } else {
                setDataType(IdentityDataTypeTransform.forNativeType(object.getClass()));
            }
        } else {
            setDataType(type);
        }
    }

    @Override
    public void setDataType(DataTypeTransform type) {
        super.setDataType(type); //To change body of generated methods, choose Tools | Templates.
    }

    public Object getObject() {
        return object;
    }

    public String getName() {
        return name;
    }

    public void setObject(Object object) {
        this.object = object;
    }

    public boolean isUnspecified() {
        return unspecified;
    }

    public void setUnspecified(boolean unspecified) {
        this.unspecified = unspecified;
    }

    @Override
    public DefaultCompiledExpression copy() {
        CompiledParam o = new CompiledParam(object, name, getTypeTransform(), unspecified);
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }
    //    public String toSQL(boolean flag, PersistenceUnitFilter database) {
//        return "?";
//    }

    @Override
    public DefaultCompiledExpression[] getSubExpressions() {
        return null;
    }

    @Override
    public void setSubExpression(int index, DefaultCompiledExpression expression) {
        throw new UnsupportedOperationException("Not supported.");
    }

    @Override
    public String toString() {
        return ('{' + name + "=" + (unspecified ? "?" : object) + '}');
    }

    @Override
    public DataTypeTransform getEffectiveDataType() {
        DataTypeTransform d = getTypeTransform();
        DefaultCompiledExpression p = getParentExpression();
        if (p instanceof CompiledVarVal) {
            CompiledVarOrMethod v = ((CompiledVarVal) p).getVar();
            v = ((CompiledVarOrMethod) v).getFinest();
            final Object r = v.getReferrer();
            if (r instanceof Field) {
                return UPAUtils.getTypeTransformOrIdentity((Field) r);
            }
        } else if ((p instanceof CompiledEquals) || (p instanceof CompiledDifferent)) {
            DefaultCompiledExpression o = ((CompiledBinaryOperatorExpression) p).getOther(this);
            if (o instanceof CompiledVarOrMethod) {
                o = ((CompiledVarOrMethod) o).getFinest();
                Object r = ((CompiledVarOrMethod) o).getReferrer();
                if (r instanceof Field) {
                    return UPAUtils.getTypeTransformOrIdentity((Field) r);
                }
            }
        }
        return d;
    }

}
