package net.vpc.upa.expressions;


import java.util.List;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 22 janv. 2006
 * Time: 09:17:10
 * To change this template use File | Settings | File Templates.
 */
public class IdCollectionExpression extends InCollection implements Cloneable {
    private static final long serialVersionUID = 1L;

    public IdCollectionExpression(Expression left) {
        super(left);
    }

    public IdCollectionExpression(Expression left, List<Expression> collection) {
        super(left, collection);
    }

    public IdCollectionExpression(Expression left, Expression[] collection) {
        super(left, collection);
    }

    public IdCollectionExpression(Expression[] left) {
        super(left);
    }

    public IdCollectionExpression(Expression[] left, List<Expression> collection) {
        super(left, collection);
    }

    @Override
    public Expression copy() {
        IdCollectionExpression o=new IdCollectionExpression(getLeft().copy());
        for (Expression expression : right) {
            o.add(expression);
        }
        return o;
    }

}
