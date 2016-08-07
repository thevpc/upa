package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.types.DataTypeTransform;
import net.vpc.upa.types.TypesFactory;


/**
 * Created by IntelliJ IDEA.
 * User: root
 * Date: 10 juin 2003
 * Time: 16:29:33
 * To change this template use Options | File Templates.
 */
public class CompiledUplet extends DefaultCompiledExpressionImpl {
    private static final long serialVersionUID = 1L;
    private DefaultCompiledExpression[] expressions;

    public CompiledUplet(DefaultCompiledExpression[] expressions) {
        super();
        this.expressions=expressions;
        prepareChildren(expressions);
    }

//    public String toSQL(boolean flag, PersistenceUnitFilter database) {
//        Expression sql;
//        if(expressions.length>1){
//            Concat concat=new Concat();
//            for(int i=0;i<expressions.length;i++){
//                if(i>0){
//                    concat.add(new Literal('~'));
//                }
//                concat.add(expressions[i]);
//            }
//            sql=concat;
//        }else{
//            sql=expressions[0];
//        }
//        return sql.toSQL(flag, database);
//    }

    @Override
    public DataTypeTransform getTypeTransform() {
        return IdentityDataTypeTransform.STRING;
    }

    public DefaultCompiledExpression[] getExpressions() {
        return expressions;
    }

    @Override
    public DefaultCompiledExpression copy() {
        DefaultCompiledExpression[] expressions2=new DefaultCompiledExpression[expressions.length];
        for (int i = 0; i < expressions2.length; i++) {
            expressions2[i]=expressions[i].copy();
        }
        CompiledUplet o=new CompiledUplet(expressions2);
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }

    @Override
    public DefaultCompiledExpression[] getSubExpressions() {
        DefaultCompiledExpression[] r=new DefaultCompiledExpression[expressions.length];
        System.arraycopy(expressions, 0, r, 0, expressions.length);
        return r;
    }

    @Override
    public void setSubExpression(int index, DefaultCompiledExpression expression) {
        expressions[index]=expression;
        prepareChildren(expression);
    }
    
}
