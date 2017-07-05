package net.vpc.upa.impl.uql.compiledexpression;


import java.util.ArrayList;
import java.util.List;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.types.DataTypeTransform;


public final class CompiledInSelection extends DefaultCompiledExpressionImpl
        implements Cloneable {
    private static final long serialVersionUID = 1L;
    private DefaultCompiledExpression[] left;
    private CompiledSelect query;

    public CompiledInSelection(DefaultCompiledExpression left, CompiledSelect query) {
        this(new DefaultCompiledExpression[]{
            left
        }, query);
    }

    public DataTypeTransform getTypeTransform() {
        return IdentityDataTypeTransform.BOOLEAN;
    }

    public CompiledInSelection(DefaultCompiledExpression[] left, CompiledSelect query) {
        this.left = left;
        this.query = query;
        bindChildren(left);
        bindChildren(query);
    }

    public int size() {
        return 2;
    }

    public DefaultCompiledExpression[] getLeft() {
        return left;
    }

    public CompiledSelect getSelection() {
        return query;
    }

    public boolean isValid() {
        return query.isValid();
    }

    @Override
    public DefaultCompiledExpression copy() {
        DefaultCompiledExpression[] left2=new DefaultCompiledExpression[left.length];
        for (int i = 0; i < left2.length; i++) {
            left2[i]=left[i].copy();
        }
        CompiledInSelection o=new CompiledInSelection(left2,(CompiledSelect) query.copy());
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }

    @Override
    public DefaultCompiledExpression[] getSubExpressions() {
        List<DefaultCompiledExpression> all=new ArrayList<DefaultCompiledExpression>();
        PlatformUtils.addAll(all, left);
        all.add(query);
        return all.toArray(new DefaultCompiledExpression[all.size()]);
    }

    @Override
    public void setSubExpression(int index, DefaultCompiledExpression expression) {
        if(index<left.length){
            unbindChildren(this.left[index]);
            left[index]=expression;
            bindChildren(expression);
        }else {
            unbindChildren(this.query);
            query=(CompiledSelect) expression;
            bindChildren(query);
        }
    }

    //    public synchronized String toSQL(boolean integrated, PersistenceUnitFilter database) {
//        if (left.length == 1) {
//            String query = left[0].toSQL(true, database) + " in (" + getSelection().toSQL(database) + ")";
//            return integrated ? '(' + query + ')' : query;
//        }
//        Uplet uplet=new Uplet(left);
//        StringBuffer stringBuffer=new StringBuffer(uplet.toSQL(database));
//        stringBuffer.append(" IN (");
//        stringBuffer.append(this.query.toSQLPattern(database));
//        stringBuffer.append(")");
//        return integrated ? '(' + stringBuffer.toString() + ')' : stringBuffer.toString();
//    }
    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        if (left.length == 1) {
            sb.append(left[0]);
        } else {
            sb.append("(");
            for (int i = 0; i < left.length; i++) {
                if (i > 0) {
                    sb.append(", ");
                }
                sb.append(left[i]);
            }
            sb.append(")");
        }
        sb.append(" in (").append(query).append(")");
        return sb.toString();
    }
}
