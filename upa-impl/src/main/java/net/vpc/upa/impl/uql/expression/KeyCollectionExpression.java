package net.vpc.upa.impl.uql.expression;

import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.InCollection;

import java.util.List;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 22 janv. 2006
 * Time: 09:17:10
 * To change this template use File | Settings | File Templates.
 */
public class KeyCollectionExpression extends InCollection implements Cloneable {
    private static final long serialVersionUID = 1L;

    public KeyCollectionExpression(Expression left) {
        super(left);
    }

    public KeyCollectionExpression(Expression left, List<Expression> collection) {
        super(left, collection);
    }

    public KeyCollectionExpression(Expression left, Expression[] collection) {
        super(left, collection);
    }

    public KeyCollectionExpression(Expression[] left) {
        super(left);
    }

    public KeyCollectionExpression(Expression[] left, List<Expression> collection) {
        super(left, collection);
    }

    @Override
    public Expression copy() {
        KeyCollectionExpression o=new KeyCollectionExpression(getLeft().copy());
        for (Expression expression : right) {
            o.add(expression);
        }
        return o;
    }

}
