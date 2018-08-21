package net.vpc.upa.impl.upql.ext.expr;


import java.util.Date;
import net.vpc.upa.Field;
import net.vpc.upa.exceptions.IllegalUPAArgumentException;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.types.DataTypeTransform;

public final class CompiledLiteral extends DefaultCompiledExpressionImpl
        implements Cloneable {
    public static final CompiledLiteral IONE = new CompiledLiteral(1);
    public static final CompiledLiteral IZERO = new CompiledLiteral(0);
    public static final CompiledLiteral DZERO = new CompiledLiteral(0.0);
    public static final CompiledLiteral ZERO = DZERO;
    public static final CompiledLiteral EMPTY_STRING = new CompiledLiteral("");
    private static final long serialVersionUID = 1L;
    private DataTypeTransform dataTypeTransform;
    private Object value;

    public CompiledLiteral(Date date) {
        setValue(date);
    }

    public CompiledLiteral(int value) {
        setValue(new Integer(value));
    }

    public CompiledLiteral(boolean value) {
        setValue((value) ? Boolean.TRUE : Boolean.FALSE);
    }

    public CompiledLiteral(long value) {
        setValue(new Long(value));
    }

    public CompiledLiteral(float value) {
        setValue(new Float(value));
    }

    public CompiledLiteral(double value) {
        setValue(new Double(value));
    }

    public CompiledLiteral(char value) {
        setValue(new Character(value));
    }

    public CompiledLiteral(String value) {
        setValue(value);
    }

    public CompiledLiteral(Object value, DataTypeTransform type) {
        this.value = value;

        if (type == null) {
            if (value == null) {
                type = IdentityDataTypeTransform.OBJECT;
            } else {
                type = IdentityDataTypeTransform.ofType(value.getClass());
            }
        }
        setDataTypeTransform(type);
    }


    @Override
    public String toString() {
        if(value instanceof String){
            return "'"+String.valueOf(value).replace("'", "''")+"'";
        }
        if(value instanceof Date){
            return "'"+String.valueOf(value).replace("'", "''")+"'";
        }
        return String.valueOf(value);
    }

    public static boolean isNull(CompiledExpressionExt e) {
        return e == null || ((e instanceof CompiledLiteral) && (((CompiledLiteral) e).value == null));
    }

    public Object getValue() {
        return value;
    }

    public void setValue(Object o) {
        this.value = o;
        setDataTypeTransform((o == null)?IdentityDataTypeTransform.OBJECT:IdentityDataTypeTransform.ofType(o.getClass()));
    }

    public void setDataTypeTransform(DataTypeTransform dataTypeTransform) {
        this.dataTypeTransform = dataTypeTransform;
        if(dataTypeTransform==null){
            throw new IllegalUPAArgumentException("Type cannot be null");
        }
    }

    @Override
    public DataTypeTransform getTypeTransform() {
        return dataTypeTransform;
    }


    @Override
    public CompiledExpressionExt copy() {
        CompiledLiteral o = new CompiledLiteral(value, dataTypeTransform);
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }

    @Override
    public CompiledExpressionExt[] getSubExpressions() {
        return null;
    }

    @Override
    public void setSubExpression(int index, CompiledExpressionExt expression) {
        throw new UnsupportedOperationException("Not supported.");
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
                return (((Field) r)).getEffectiveTypeTransform();
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
