package net.vpc.upa.impl.upql.ext.expr;


import java.util.ArrayList;
import java.util.List;

import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.types.DataTypeTransform;


public final class CompiledInSelection extends DefaultCompiledExpressionImpl
        implements Cloneable {
    private static final long serialVersionUID = 1L;
    private CompiledExpressionExt[] left;
    private CompiledSelect query;

    public CompiledInSelection(CompiledExpressionExt left, CompiledSelect query) {
        this(new CompiledExpressionExt[]{
            left
        }, query);
    }

    public DataTypeTransform getTypeTransform() {
        return IdentityDataTypeTransform.BOOLEAN;
    }

    public CompiledInSelection(CompiledExpressionExt[] left, CompiledSelect query) {
        this.left = left;
        this.query = query;
        bindChildren(left);
        bindChildren(query);
    }

    public int size() {
        return 2;
    }

    public CompiledExpressionExt[] getLeft() {
        return left;
    }

    public CompiledSelect getSelection() {
        return query;
    }

    public boolean isValid() {
        return query.isValid();
    }

    @Override
    public CompiledExpressionExt copy() {
        CompiledExpressionExt[] left2=new CompiledExpressionExt[left.length];
        for (int i = 0; i < left2.length; i++) {
            left2[i]=left[i].copy();
        }
        CompiledInSelection o=new CompiledInSelection(left2,(CompiledSelect) query.copy());
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }

    @Override
    public CompiledExpressionExt[] getSubExpressions() {
        List<CompiledExpressionExt> all=new ArrayList<CompiledExpressionExt>();
        PlatformUtils.addAll(all, left);
        all.add(query);
        return all.toArray(new CompiledExpressionExt[all.size()]);
    }

    @Override
    public void setSubExpression(int index, CompiledExpressionExt expression) {
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
