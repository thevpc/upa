package net.vpc.upa.impl.uql.compiledexpression;


import java.util.ArrayList;
import java.util.List;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.types.DataTypeTransform;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 22 janv. 2006
 * Time: 09:48:59
 * To change this template use File | Settings | File Templates.
 */
public class CompiledKeyEnumerationExpression extends DefaultCompiledExpressionImpl implements Cloneable {
    private List<Object> keys;
    private CompiledVar alias;

    public CompiledKeyEnumerationExpression(List<Object> keys, CompiledVar alias) {
        this.keys = keys;
        this.alias = alias;
        prepareChildren(alias);
    }

//    public String toSQL(boolean flag, PersistenceUnitFilter database) {
//        if(keys.length==0){
//            return "1=2";
//        }
//        Field[] pfs = database.getEntity(tableName).getPrimaryFields();
//        Or o = new Or();
//        for (int i = 0; i < keys.length; i++) {
//            And a = new And();
//            for (int j = 0; j < pfs.length; j++) {
//                a.and(new Equals(new Var(tableAlias + pfs[j].getName(),pfs[j].getDataType()), new Literal(keys[i].getObjectAt(j),pfs[j].getDataType())));
//            }
//            o.or(a);
//        }
//        return o.toSQL(flag, database);
//    }

    public List<Object> getKeys() {
        return keys;
    }

    public CompiledVar getAlias() {
        return alias;
    }

    @Override
    public DataTypeTransform getTypeTransform() {
        return IdentityDataTypeTransform.BOOLEAN;
    }

    @Override
    public DefaultCompiledExpression copy() {
        CompiledKeyEnumerationExpression o=new CompiledKeyEnumerationExpression(new ArrayList<Object>(keys),alias==null?null:(CompiledVar)alias.copy());
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }

    @Override
    public DefaultCompiledExpression[] getSubExpressions() {
        return alias==null?new DefaultCompiledExpression[0]: new DefaultCompiledExpression[]{alias};
    }

    @Override
    public void setSubExpression(int index, DefaultCompiledExpression expression) {
        if(index ==0){
            alias=(CompiledVar)expression;
            prepareChildren(expression);
        }else{
            throw new IllegalArgumentException("Invalid index");
        }
    }
    
}
