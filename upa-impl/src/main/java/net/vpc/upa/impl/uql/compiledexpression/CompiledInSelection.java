package net.vpc.upa.impl.uql.compiledexpression;


import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.types.DataTypeTransform;


// Referenced classes of package net.vpc.lib.pheromone.ariana.database.sql:
//            Expression, Select

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
        prepareChildren(left);
        prepareChildren(query);
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
            left[index]=expression;
        }else {
            query=(CompiledSelect) expression;
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

}
