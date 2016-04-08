/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiledreplacer;

import java.util.List;
import net.vpc.upa.Entity;
import net.vpc.upa.Field;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.Relationship;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.CompiledExpression;
import net.vpc.upa.extensions.HierarchyExtension;
import net.vpc.upa.impl.extension.HierarchicalRelationshipSupport;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.impl.uql.CompiledExpressionReplacer;
import net.vpc.upa.impl.uql.compiledexpression.CompiledCast;
import net.vpc.upa.impl.uql.compiledexpression.CompiledConcat;
import net.vpc.upa.impl.uql.compiledexpression.CompiledD2V;
import net.vpc.upa.impl.uql.compiledexpression.CompiledEntityName;
import net.vpc.upa.impl.uql.compiledexpression.CompiledI2V;
import net.vpc.upa.impl.uql.compiledexpression.CompiledLike;
import net.vpc.upa.impl.uql.compiledexpression.CompiledLiteral;
import net.vpc.upa.impl.uql.compiledexpression.CompiledOr;
import net.vpc.upa.impl.uql.compiledexpression.CompiledParam;
import net.vpc.upa.impl.uql.compiledexpression.IsHierarchyDescendentCompiled;
import net.vpc.upa.impl.uql.compiledexpression.CompiledVar;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;
import net.vpc.upa.impl.util.UPAUtils;
import net.vpc.upa.types.ByteType;
import net.vpc.upa.types.DataType;
import net.vpc.upa.types.DoubleType;
import net.vpc.upa.types.FloatType;
import net.vpc.upa.types.IntType;
import net.vpc.upa.types.LongType;
import net.vpc.upa.types.ShortType;
import net.vpc.upa.types.StringType;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class IsHierarchyDescendentReplacer implements CompiledExpressionReplacer {

    private PersistenceUnit persistenceUnit;

    public IsHierarchyDescendentReplacer(PersistenceUnit persistenceUnit) {
        this.persistenceUnit = persistenceUnit;
    }

    public CompiledExpression update(CompiledExpression e) {
        IsHierarchyDescendentCompiled o = (IsHierarchyDescendentCompiled) e;
        DefaultCompiledExpression c = o.getChildExpression();
        DefaultCompiledExpression p = o.getAncestorExpression();
        CompiledEntityName n = o.getEntityName();
        Entity treeEntity = null;
        Field treeField = null;
        if (c instanceof CompiledVar) {

            Object childReferrer = ((CompiledVar) c).getFinest().getReferrer();
            if (childReferrer != null) {
                if (childReferrer instanceof Entity) {
                    if (treeEntity == null) {
                        treeEntity = (Entity) childReferrer;
                    } else {
                        if (!treeEntity.getName().equals(((Entity) childReferrer).getName())) {
                            throw new IllegalArgumentException("Ambigous or Invalid Type " + treeEntity.getName() + " in TreeEntity near " + e);
                        }
                    }
                }
            }
        } else if (c instanceof CompiledParam) {
            Object co = ((CompiledParam) c).getObject();
            if (co != null && persistenceUnit.containsEntity(co.getClass())) {
                Entity rr = persistenceUnit.getEntity(co.getClass());
                if (treeEntity == null) {
                    treeEntity = rr;
                }
                ((CompiledParam) c).setObject(rr.getBuilder().objectToId(co));
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
                            throw new IllegalArgumentException("Ambigous or Invalid Type " + treeEntity.getName() + " in TreeEntity near " + e);
                        }
                    }
                }
            }
        } else if (p instanceof CompiledParam) {
            Object co = ((CompiledParam) p).getObject();
            if (co != null && persistenceUnit.containsEntity(co.getClass())) {
                Entity rr = persistenceUnit.getEntity(co.getClass());
                if (treeEntity == null) {
                    treeEntity = rr;
                }
                ((CompiledParam) p).setObject(rr.getBuilder().objectToId(co));
                if (rr.getPrimaryFields().size() > 1) {
                    throw new IllegalArgumentException("Not supported");
                }
                ((CompiledParam) p).setDataType(UPAUtils.getTypeTransformOrIdentity(rr.getPrimaryFields().get(0)));
            }
//            Object co = ((CompiledParam) c).getEffectiveDataType();
        }
        if (treeEntity == null) {
            treeEntity = persistenceUnit.getEntity(n.getName());
        }

        Relationship t = HierarchicalRelationshipSupport.getTreeRelationName(treeEntity);
        if (t == null) {
            throw new IllegalArgumentException("Tree Relationship not found");
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
            CompiledVar cv = (CompiledVar) alias;
            if (cv.getReferrer() instanceof Entity) {
                CompiledVar v = new CompiledVar(field.getName());
                ((CompiledVar) alias).setChild(v);
            } else {
                throw new IllegalArgumentException("Expected " + field.getEntity().getName() + " var name");
            }
        } else {
            throw new IllegalArgumentException("Expected " + field.getEntity().getName() + " var name");
        }
        id = id.copy();
        List<Field> primaryFields = field.getEntity().getPrimaryFields();
        if (primaryFields.size() > 1) {
            throw new IllegalArgumentException("Composite ID unsupported for function treeancestor");
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
                    new CompiledLike(
                            alias.copy(),
                            new CompiledConcat(new CompiledLiteral("%" + pathSep), strId.copy())),
                    new CompiledLike(
                            alias.copy(),
                            new CompiledConcat(new CompiledLiteral("%" + pathSep), strId.copy(), new CompiledLiteral(pathSep + "%"))));
        } else {
            return new CompiledLike(
                    alias.copy(),
                    new CompiledConcat(new CompiledLiteral("%" + pathSep), strId.copy(), new CompiledLiteral(pathSep + "%")));
        }
    }

}
