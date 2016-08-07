package net.vpc.upa.impl.uql.compiledexpression;

public final class IsHierarchyDescendentCompiled extends CompiledFunction
        implements Cloneable {

    private static final long serialVersionUID = 1L;
    private DefaultCompiledExpression ancestorExpression;
    private DefaultCompiledExpression childExpression;
    private CompiledEntityName entityName;

    public IsHierarchyDescendentCompiled(DefaultCompiledExpression ancestorExpression, DefaultCompiledExpression childExpression,CompiledEntityName entityName) {
        super("treeAncestor");
        this.ancestorExpression = ancestorExpression;
        this.childExpression = childExpression;
        this.entityName = entityName;
        protectedAddArgument(ancestorExpression);
        protectedAddArgument(childExpression);
        protectedAddArgument(entityName);
    }

    public DefaultCompiledExpression getAncestorExpression() {
        return ancestorExpression;
    }

    public DefaultCompiledExpression getChildExpression() {
        return childExpression;
    }

    public CompiledEntityName getEntityName() {
        return entityName;
    }
    
    public DefaultCompiledExpression copy() {
        return new IsHierarchyDescendentCompiled(ancestorExpression.copy(), childExpression.copy(),(CompiledEntityName)entityName.copy());
    }

}
