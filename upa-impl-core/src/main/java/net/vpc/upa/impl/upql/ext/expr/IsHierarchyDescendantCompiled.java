package net.vpc.upa.impl.upql.ext.expr;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.exceptions.UPAIllegalArgumentException;
import net.vpc.upa.extensions.HierarchyExtension;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.extension.HierarchicalRelationshipSupport;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.impl.upql.ExpressionCompiler;
import net.vpc.upa.impl.util.UPAUtils;
import net.vpc.upa.types.*;

import java.util.List;

public final class IsHierarchyDescendantCompiled extends CompiledQLFunctionExpression
        implements Cloneable, net.vpc.upa.Function {

    private static final long serialVersionUID = 1L;
    private CompiledExpressionExt ancestorExpression;
    private CompiledExpressionExt childExpression;
    private CompiledEntityName entityName;

    public IsHierarchyDescendantCompiled(CompiledExpressionExt ancestorExpression, CompiledExpressionExt childExpression, CompiledEntityName entityName) {
        super("treeAncestor", new CompiledExpressionExt[]{ancestorExpression, childExpression, entityName}, IdentityDataTypeTransform.BOOLEAN, null);
        this.handler = this;
        this.ancestorExpression = ancestorExpression;
        this.childExpression = childExpression;
        this.entityName = entityName;
//        protectedAddArgument(ancestorExpression);
//        protectedAddArgument(childExpression);
//        protectedAddArgument(entityName);
    }

    public CompiledExpressionExt getAncestorExpression() {
        return ancestorExpression;
    }

    public CompiledExpressionExt getChildExpression() {
        return childExpression;
    }

    public CompiledEntityName getEntityName() {
        return entityName;
    }

    public CompiledExpressionExt copy() {
        return new IsHierarchyDescendantCompiled(ancestorExpression.copy(), childExpression.copy(), (CompiledEntityName) entityName.copy());
    }

    public Object eval(FunctionEvalContext evalContext) {
        IsHierarchyDescendantCompiled o = this;
        ExpressionCompiler expressionCompiler = (ExpressionCompiler) evalContext.getCompilerContext();
        PersistenceUnit persistenceUnit = evalContext.getPersistenceUnit();
        CompiledExpressionExt c = o.getChildExpression();
        CompiledExpressionExt p = o.getAncestorExpression();
        CompiledEntityName n = o.getEntityName();
        Entity treeEntity = null;
        if (c instanceof CompiledVar) {

            Object childReferrer = resolveReferrer((CompiledVar) ((CompiledVar) c).getDeepest(), expressionCompiler);
            if (childReferrer != null) {
                if (childReferrer instanceof Entity) {
                    if (treeEntity == null) {
                        treeEntity = (Entity) childReferrer;
                    } else {
                        if (!treeEntity.getName().equals(((Entity) childReferrer).getName())) {
                            throw new UPAIllegalArgumentException("Ambiguous or Invalid Type " + treeEntity.getName() + " in TreeEntity near " + o);
                        }
                    }
                }
            }
        } else if (c instanceof CompiledParam) {
            Object co = ((CompiledParam) c).getValue();
            if (co != null && persistenceUnit.containsEntity(co.getClass())) {
                Entity rr = persistenceUnit.getEntity(co.getClass());
                if (treeEntity == null) {
                    treeEntity = rr;
                }
                ((CompiledParam) c).setValue(rr.getBuilder().objectToId(co));
            }
//            Object co = ((CompiledParam) c).getEffectiveDataType();
        }
        if (p instanceof CompiledVar) {
            Object parentReferrer = resolveReferrer((CompiledVar) ((CompiledVar) p).getDeepest(), expressionCompiler);
            if (parentReferrer != null) {
                if (parentReferrer instanceof Entity) {
                    if (treeEntity == null) {
                        treeEntity = (Entity) parentReferrer;
                    } else {
                        if (!treeEntity.getName().equals(((Entity) parentReferrer).getName())) {
                            throw new UPAIllegalArgumentException("Ambiguous or Invalid Type " + treeEntity.getName() + " in TreeEntity near " + o);
                        }
                    }
                }
            }
        } else if (p instanceof CompiledParam) {
            Object co = ((CompiledParam) p).getValue();
            if (co != null && persistenceUnit.containsEntity(co.getClass())) {
                Entity rr = persistenceUnit.findEntity(co.getClass());
                if (treeEntity == null) {
                    treeEntity = rr;
                }
                ((CompiledParam) p).setValue(rr.getBuilder().objectToId(co));
                if (rr.getIdFields().size() > 1) {
                    throw new UPAIllegalArgumentException("Not supported");
                }
                ((CompiledParam) p).setTypeTransform((rr.getIdFields().get(0)).getEffectiveTypeTransform());
            }
//            Object co = ((CompiledParam) c).getEffectiveDataType();
        }
        Entity expectedEntity = n.getName() == null ? null : persistenceUnit.getEntity(n.getName());
        if (treeEntity == null) {
            if (expectedEntity != null) {
                treeEntity = expectedEntity;
            } else {
                throw new UPAIllegalArgumentException("Unable to resolve Hierarchy Entity in " + o);
            }
        } else if (expectedEntity != null && !expectedEntity.getName().equals(treeEntity.getName())) {
            throw new UPAIllegalArgumentException("Expected " + expectedEntity.getName() + " but found " + treeEntity.getName() + " in " + o);
        }

        ManyToOneRelationship t = HierarchicalRelationshipSupport.getTreeRelation(treeEntity);
        if (t == null) {
            throw new UPAIllegalArgumentException("Hierarchy Relationship not found");
        }
        HierarchyExtension s = t.getHierarchyExtension();
        if (s == null) {
            throw new UPAIllegalArgumentException("Not a valid TreeEntity");
        }
        Field pathField = treeEntity.getField(s.getHierarchyPathField());
        String pathSep = s.getHierarchyPathSeparator();
        return createConditionForDeepSearch(c, p, true, pathField, pathSep, expressionCompiler);
    }

    public CompiledExpressionExt createConditionForDeepSearch(CompiledExpressionExt alias, CompiledExpressionExt id, boolean includeId, Field field, String pathSep, ExpressionCompiler expressionCompiler) throws UPAException {
        alias = alias.copy();
        if (alias instanceof CompiledVar) {
//            CompiledVar cv = (CompiledVar) alias;
            CompiledVarOrMethod finest = ((CompiledVar) alias).getDeepest();
            Object referrer = resolveReferrer((CompiledVar) finest, expressionCompiler);
            if (referrer instanceof Entity) {

                CompiledVar v = new CompiledVar(field.getName());
                ((CompiledVar) alias).getDeepest().setChild(v);
            } else if (referrer instanceof Field && ((Field) referrer).isManyToOne()
                    && ((Field) referrer).getManyToOneRelationship().getTargetEntity().getName().equals(field.getEntity().getName())) {
                CompiledVar v = new CompiledVar(field.getName());
                finest.setChild(v);
            } else {
                throw new UPAIllegalArgumentException("Expected " + field.getEntity().getName() + " var name");
            }
        } else {
            throw new UPAIllegalArgumentException("Expected " + field.getEntity().getName() + " var name");
        }
        id = id.copy();
        List<Field> primaryFields = field.getEntity().getIdFields();
        if (primaryFields.size() > 1) {
            throw new UPAIllegalArgumentException("Composite ID unsupported for function isHierarchyDescendant");
        }
        DataType pkType = primaryFields.get(0).getDataType();
        CompiledExpressionExt strId = null;
        if (!net.vpc.upa.impl.util.PlatformUtils.isString(pkType.getPlatformType())) {
            strId = new CompiledToString(id);
        } else {
            strId = id;
        }
        if (includeId) {
            return new CompiledOr(
                    new CompiledEquals(alias.copy(), strId.copy()),
                    new CompiledOr(
                            new CompiledLike(
                                    alias.copy(),
                                    new CompiledConcat(new CompiledLiteral("%" + pathSep), strId.copy())),
                            new CompiledOr(
                                    new CompiledLike(
                                            alias.copy(),
                                            new CompiledConcat(new CompiledLiteral("%" + pathSep), strId.copy(), new CompiledLiteral(pathSep + "%"))),
                                     new CompiledLike(
                                            alias.copy(),
                                            new CompiledConcat(strId.copy(), new CompiledLiteral(pathSep + "%")))
                            )
                    )
            );
        } else {
            return new CompiledLike(
                    alias.copy(),
                    new CompiledConcat(new CompiledLiteral("%" + pathSep), strId.copy(), new CompiledLiteral(pathSep + "%")));
        }
    }

    public Object resolveReferrer(CompiledVar var, ExpressionCompiler expressionCompiler) {
        return expressionCompiler.resolveReferrer(var);
    }

}
