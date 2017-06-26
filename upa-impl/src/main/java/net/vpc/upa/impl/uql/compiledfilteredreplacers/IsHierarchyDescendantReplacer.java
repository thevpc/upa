/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiledfilteredreplacers;

import net.vpc.upa.Entity;
import net.vpc.upa.Field;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.Relationship;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.CompiledExpression;
import net.vpc.upa.extensions.HierarchyExtension;
import net.vpc.upa.impl.extension.HierarchicalRelationshipSupport;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.impl.uql.CompiledExpressionFilteredReplacer;
import net.vpc.upa.impl.uql.CompiledExpressionReplacer;
import net.vpc.upa.impl.uql.compiledexpression.*;
import net.vpc.upa.impl.util.UPAUtils;
import net.vpc.upa.types.*;

import java.util.List;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class IsHierarchyDescendantReplacer implements CompiledExpressionFilteredReplacer {

    private PersistenceUnit persistenceUnit;

    public IsHierarchyDescendantReplacer(PersistenceUnit persistenceUnit) {
        this.persistenceUnit = persistenceUnit;
    }

    @Override
    public boolean accept(DefaultCompiledExpression e) {
        return e instanceof IsHierarchyDescendantCompiled;
    }

    public CompiledExpression update(CompiledExpression e) {
        IsHierarchyDescendantCompiled o = (IsHierarchyDescendantCompiled) e;
        DefaultCompiledExpression c = o.getChildExpression();
        DefaultCompiledExpression p = o.getAncestorExpression();
        CompiledEntityName n = o.getEntityName();
        Entity treeEntity = null;
        if (c instanceof CompiledVar) {

            Object childReferrer = ((CompiledVar) c).getFinest().getReferrer();
            if (childReferrer != null) {
                if (childReferrer instanceof Entity) {
                    if (treeEntity == null) {
                        treeEntity = (Entity) childReferrer;
                    } else {
                        if (!treeEntity.getName().equals(((Entity) childReferrer).getName())) {
                            throw new IllegalArgumentException("Ambiguous or Invalid Type " + treeEntity.getName() + " in TreeEntity near " + e);
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
            Object parentReferrer = ((CompiledVar) p).getFinest().getReferrer();
            if (parentReferrer != null) {
                if (parentReferrer instanceof Entity) {
                    if (treeEntity == null) {
                        treeEntity = (Entity) parentReferrer;
                    } else {
                        if (!treeEntity.getName().equals(((Entity) parentReferrer).getName())) {
                            throw new IllegalArgumentException("Ambiguous or Invalid Type " + treeEntity.getName() + " in TreeEntity near " + e);
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
                if (rr.getPrimaryFields().size() > 1) {
                    throw new IllegalArgumentException("Not supported");
                }
                ((CompiledParam) p).setTypeTransform(UPAUtils.getTypeTransformOrIdentity(rr.getPrimaryFields().get(0)));
            }
//            Object co = ((CompiledParam) c).getEffectiveDataType();
        }
        Entity expectedEntity = n.getName() == null ? null : persistenceUnit.getEntity(n.getName());
        if (treeEntity == null) {
            if (expectedEntity != null) {
                treeEntity = expectedEntity;
            } else {
                throw new IllegalArgumentException("Unable to resolve Hierarchy Entity in " + e);
            }
        } else if (expectedEntity != null && !expectedEntity.getName().equals(treeEntity.getName())) {
            throw new IllegalArgumentException("Expected " + expectedEntity.getName() + " but found " + treeEntity.getName() + " in " + e);
        }

        Relationship t = HierarchicalRelationshipSupport.getTreeRelation(treeEntity);
        if (t == null) {
            throw new IllegalArgumentException("Hierarchy Relationship not found");
        }
        HierarchyExtension s = t.getHierarchyExtension();
        if (s == null) {
            throw new IllegalArgumentException("Not a valid TreeEntity");
        }
        Field pathField = treeEntity.getField(s.getHierarchyPathField());
        String pathSep = s.getHierarchyPathSeparator();
        return createConditionForDeepSearch(c, (DefaultCompiledExpression) p, true, pathField, pathSep);
    }

    public CompiledExpression createConditionForDeepSearch(DefaultCompiledExpression alias, DefaultCompiledExpression id, boolean includeId, Field field, String pathSep) throws UPAException {
        alias = alias.copy();
        if (alias instanceof CompiledVar) {
//            CompiledVar cv = (CompiledVar) alias;
            CompiledVarOrMethod finest = ((CompiledVar) alias).getFinest();
            if (finest.getReferrer() instanceof Entity) {

                CompiledVar v = new CompiledVar(field.getName());
                ((CompiledVar) alias).getFinest().setChild(v);
            } else if (finest.getReferrer() instanceof Field && ((Field) finest.getReferrer()).getDataType() instanceof ManyToOneType &&
                    ((ManyToOneType) ((Field) finest.getReferrer()).getDataType()).getTargetEntity().getName().equals(field.getEntity().getName())
                    ) {
                CompiledVar v = new CompiledVar(field.getName());
                finest.setChild(v);
            } else {
                throw new IllegalArgumentException("Expected " + field.getEntity().getName() + " var name");
            }
        } else {
            throw new IllegalArgumentException("Expected " + field.getEntity().getName() + " var name");
        }
        id = id.copy();
        List<Field> primaryFields = field.getEntity().getPrimaryFields();
        if (primaryFields.size() > 1) {
            throw new IllegalArgumentException("Composite ID unsupported for function isHierarchyDescendant");
        }
        DataType pkType = primaryFields.get(0).getDataType();
        DefaultCompiledExpression strId = null;
        if (pkType instanceof IntType) {
            strId = new CompiledI2V(id);
        } else if (pkType instanceof LongType) {
            strId = new CompiledI2V(id);
        } else if (pkType instanceof ShortType) {
            strId = new CompiledI2V(id);
        } else if (pkType instanceof ByteType) {
            strId = new CompiledI2V(id);
        } else if (pkType instanceof FloatType) {
            strId = new CompiledD2V(id);
        } else if (pkType instanceof DoubleType) {
            strId = new CompiledD2V(id);
        } else if (pkType instanceof StringType) {
            strId = id;
        } else {
            strId = new CompiledCast(id, IdentityDataTypeTransform.STRING);
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
                                            new CompiledConcat(new CompiledLiteral("%" + pathSep), strId.copy(), new CompiledLiteral(pathSep + "%")))
                                    ,
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

}
