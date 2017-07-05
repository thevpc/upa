package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.impl.uql.CompiledExpressionFactory;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collection;
import java.util.List;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.types.DataTypeTransform;

public class CompiledInCollection extends DefaultCompiledExpressionImpl
        implements Cloneable {
    private static final long serialVersionUID = 1L;

    private DefaultCompiledExpression left;
    protected List<DefaultCompiledExpression> right;

    public CompiledInCollection(DefaultCompiledExpression left) {
        this(left,(Collection<Object>) null);
    }
    
    @Override
    public DataTypeTransform getTypeTransform() {
        return IdentityDataTypeTransform.BOOLEAN;
    }

    public CompiledInCollection(DefaultCompiledExpression[] left){
        this(new CompiledUplet(left),(Collection<Object>)null);
    }

//    public InCollection(String left,DataPrimitiveType type,Collection collection) {
//        this(new Var(left,type),collection);
//    }

//    public InCollection(String left,DataPrimitiveType type,Object[] collection) {
//        this(new Var(left,type),collection!=null ? Arrays.asList(collection) : null);
//    }

    public CompiledInCollection(DefaultCompiledExpression[] left, Collection<Object> collection) {
        this(new CompiledUplet(left),collection);
    }

    public CompiledInCollection(DefaultCompiledExpression left, Object[] collection) {
        this(left,collection!=null ? Arrays.asList(collection) :  null);
    }

    public CompiledInCollection(DefaultCompiledExpression left, Collection<Object> collection) {
        this.left = left;
        bindChildren(left);
        this.right = new ArrayList<DefaultCompiledExpression>(1);
        if(collection!=null){
            for (Object aCollection : collection) {
                add(aCollection);
            }
        }
    }

    @Override
    public DefaultCompiledExpression[] getSubExpressions() {
        ArrayList<DefaultCompiledExpression> all=new ArrayList<DefaultCompiledExpression>();
        all.add(getLeft());
        all.addAll(right);
        return all.toArray(new DefaultCompiledExpression[all.size()]);
    }

    
    @Override
    public void setSubExpression(int index, DefaultCompiledExpression expression) {
        if(index==0){
            unbindChildren(this.left);
            left=expression;
            bindChildren(expression);
        }else{
            unbindChildren(this.right.get(index-1));
            right.set(index-1, expression);
            bindChildren(expression);
        }
    }

    
    public int size() {
        return right.size()+1;
    }

    public DefaultCompiledExpression getLeft() {
        return left;
    }

    public void add(Object e) {
        add(CompiledExpressionFactory.toExpression(e, CompiledLiteral.class));
    }

    public void add(DefaultCompiledExpression e) {
        right.add(e);
        bindChildren(e);
    }

    public void add(DefaultCompiledExpression[] e) {
        add(new CompiledUplet(e));
    }

//    public synchronized String toSQL(boolean integrated, PersistenceUnitFilter database) {
//        StringBuffer sb = new StringBuffer();
//        int mySize=right.size();
//        if ( mySize== 0) {
//            sb.append("1 <> 1");
//        }else {
//            if (mySize == 1) {
//                sb.append(left.toSQL(database));
//                Expression e = (Expression) right.get(0);
//                if (e == null || (e instanceof Literal && ((Literal)e).getValue()==null)) {
//                    sb.append(" IS NULL");
//                } else {
//                    sb.append(" = ");
//                    sb.append(e.toSQL(true, database));
//                }
//            } else {
//                sb.append(left.toSQL(database));
//                sb.append(" IN (");
//                for (int i = 0; i < mySize; i++) {
//                    if (i > 0)
//                        sb.append(",");
//                    Expression e = (Expression) right.get(i);
//                    if(e==null){
//                        sb.append("NULL");
//                    }else{
//                        sb.append(e.toSQL(true, database));
//                    }
//                }
//
//                sb.append(")");
//            }
//        }
//        return integrated ? '(' + sb.toString() + ')' : sb.toString();
//    }

    public int getRightSize(){
        return right.size();
    }

    public DefaultCompiledExpression getRight(int i){
        return right.get(i);
    }

    @Override
    public DefaultCompiledExpression copy() {
        CompiledInCollection o=new CompiledInCollection(left.copy());
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        for (DefaultCompiledExpression expression : right) {
            o.add(expression.copy());
        }
        return o;
    }


    
}
