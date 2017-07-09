package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.types.DataTypeTransform;


/**
 * Created by IntelliJ IDEA.
 * User: root
 * Date: 10 juin 2003
 * Time: 16:29:33
 * To change this template use Options | File Templates.
 */
public class CompiledUplet extends DefaultCompiledExpressionImpl {
    private static final long serialVersionUID = 1L;
    private CompiledExpressionExt[] expressions;

    public CompiledUplet(CompiledExpressionExt[] expressions) {
        super();
        this.expressions=expressions;
        bindChildren(expressions);
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

    public CompiledExpressionExt[] getExpressions() {
        return expressions;
    }

    @Override
    public CompiledExpressionExt copy() {
        CompiledExpressionExt[] expressions2=new CompiledExpressionExt[expressions.length];
        for (int i = 0; i < expressions2.length; i++) {
            expressions2[i]=expressions[i].copy();
        }
        CompiledUplet o=new CompiledUplet(expressions2);
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }

    @Override
    public CompiledExpressionExt[] getSubExpressions() {
        CompiledExpressionExt[] r=new CompiledExpressionExt[expressions.length];
        System.arraycopy(expressions, 0, r, 0, expressions.length);
        return r;
    }

    @Override
    public void setSubExpression(int index, CompiledExpressionExt expression) {
        unbindChildren(this.expressions[index]);
        expressions[index]=expression;
        bindChildren(expression);
    }
    
}
