package net.vpc.upa.impl.uql.compiledexpression;

import java.util.Collection;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 22 janv. 2006
 * Time: 09:17:10
 * To change this template use File | Settings | File Templates.
 */
public class CompiledKeyCollectionExpression extends CompiledInCollection implements Cloneable {
    private static final long serialVersionUID = 1L;

    public CompiledKeyCollectionExpression(DefaultCompiledExpression left) {
        super(left);
    }

    public CompiledKeyCollectionExpression(DefaultCompiledExpression left, Collection<Object> collection) {
        super(left, collection);
    }

    public CompiledKeyCollectionExpression(DefaultCompiledExpression left, Object[] collection) {
        super(left, collection);
    }

    public CompiledKeyCollectionExpression(DefaultCompiledExpression[] left) {
        super(left);
    }

    public CompiledKeyCollectionExpression(DefaultCompiledExpression[] left, Collection<Object> collection) {
        super(left, collection);
    }

//    public KeyCollectionExpression(String left, DataPrimitiveType type,Collection collection) {
//        super(left, type,collection);
//    }

//    public KeyCollectionExpression(String left, DataPrimitiveType type, Object[] collection) {
//        super(left, type,collection);
//    }

    @Override
    public DefaultCompiledExpression copy() {
        CompiledKeyCollectionExpression o=new CompiledKeyCollectionExpression(getLeft().copy());
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        for (DefaultCompiledExpression expression : right) {
            o.add(expression);
        }
        return o;
    }

}
