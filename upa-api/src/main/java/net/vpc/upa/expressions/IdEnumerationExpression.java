package net.vpc.upa.expressions;


import java.util.ArrayList;
import java.util.List;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 22 janv. 2006
 * Time: 09:48:59
 * To change this template use File | Settings | File Templates.
 */
public class IdEnumerationExpression extends DefaultExpression implements Cloneable {
    private List<Object> ids;
    private Var alias;

    public IdEnumerationExpression(List<Object> keys, Var alias) {
        this.ids = keys;
        this.alias = alias;
    }

    public List<Object> getIds() {
        return ids;
    }

    public Var getAlias() {
        return alias;
    }

    @Override
    public Expression copy() {
        IdEnumerationExpression o=new IdEnumerationExpression(new ArrayList<Object>(ids),alias==null?null:(Var)alias.copy());
        return o;
    }

    @Override
    public String toString() {
        return "IdEnumerationExpression(" + "ids=" + ids + ", alias=" + alias + ')';
    }
    
}
