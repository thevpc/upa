package net.vpc.upa.expressions;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by IntelliJ IDEA. User: vpc Date: 22 janv. 2006 Time: 09:48:59 To
 * change this template use File | Settings | File Templates.
 */
public class IdEnumerationExpression extends DefaultExpression implements Cloneable {

    private static DefaultTag ALIAS = new DefaultTag("ALIAS");
    private List<Object> ids;
    private Var alias;

    public IdEnumerationExpression(List<Object> ids, Var alias) {
        this.ids = ids;
        this.alias = alias;
    }

    @Override
    public List<TaggedExpression> getChildren() {
        List<TaggedExpression> all = new ArrayList<TaggedExpression>(1);
        if (alias != null) {
            all.add(new TaggedExpression(alias, ALIAS));
        }
        return all;
    }

    @Override
    public void setChild(Expression e, ExpressionTag tag) {
        if (tag.equals(ALIAS)) {
            this.alias = (Var) e;
        }
    }

    public List<Object> getIds() {
        return ids;
    }

    public Var getAlias() {
        return alias;
    }

    @Override
    public Expression copy() {
        IdEnumerationExpression o = new IdEnumerationExpression(new ArrayList<Object>(ids), alias == null ? null : (Var) alias.copy());
        return o;
    }

    @Override
    public String toString() {
        return "IdEnumerationExpression(" + "ids=" + ids + ", alias=" + alias + ')';
    }

}
