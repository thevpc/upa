package net.vpc.upa.impl.uql.compiledexpression;


import java.util.ArrayList;
import java.util.List;

import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.types.DataTypeTransform;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 22 janv. 2006
 * Time: 09:48:59
 * To change this template use File | Settings | File Templates.
 */
public class CompiledIdEnumerationExpression extends DefaultCompiledExpressionImpl implements Cloneable {
    private List<Object> keys;
    private CompiledVar alias;

    public CompiledIdEnumerationExpression(List<Object> ids, CompiledVar alias) {
        this.keys = ids;
        this.alias = alias;
        bindChildren(alias);
    }

//    public String toSQL(boolean flag, PersistenceUnitFilter database) {
//        if(keys.length==0){
//            return "1=2";
//        }
//        Field[] pfs = database.getEntity(tableName).getIdFields();
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
    public CompiledExpressionExt copy() {
        CompiledIdEnumerationExpression o=new CompiledIdEnumerationExpression(new ArrayList<Object>(keys),alias==null?null:(CompiledVar)alias.copy());
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }

    @Override
    public CompiledExpressionExt[] getSubExpressions() {
        return alias==null?new CompiledExpressionExt[0]: new CompiledExpressionExt[]{alias};
    }

    @Override
    public void setSubExpression(int index, CompiledExpressionExt expression) {
        if(index ==0){
            unbindChildren(this.alias);
            alias=(CompiledVar)expression;
            bindChildren(expression);
        }else{
            throw new IllegalArgumentException("Invalid index");
        }
    }

    @Override
    public String toString() {
        StringBuilder sb=new StringBuilder();
        sb.append(alias);
        sb.append(" in ");
        sb.append("(");
        for (int i = 0; i < keys.size(); i++) {
            if(i==0){
                sb.append(",");
            }
            sb.append(keys.get(i));
        }
        sb.append(")");
        return sb.toString();
    }
}
