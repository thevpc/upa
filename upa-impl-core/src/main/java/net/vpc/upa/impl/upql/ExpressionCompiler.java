package net.vpc.upa.impl.upql;

import net.vpc.upa.impl.upql.ext.expr.CompiledOrderItem;
import net.vpc.upa.impl.upql.ext.expr.CompiledURShift;
import net.vpc.upa.impl.upql.ext.expr.CompiledBitAnd;
import net.vpc.upa.impl.upql.ext.expr.CompiledMinus;
import net.vpc.upa.impl.upql.ext.expr.CompiledParam;
import net.vpc.upa.impl.upql.ext.expr.CompiledEntityStatement;
import net.vpc.upa.impl.upql.ext.expr.CompiledLShift;
import net.vpc.upa.impl.upql.ext.expr.CompiledVar;
import net.vpc.upa.impl.upql.ext.expr.CompiledPlus;
import net.vpc.upa.impl.upql.ext.expr.CompiledMul;
import net.vpc.upa.impl.upql.ext.expr.CompiledUpdate;
import net.vpc.upa.impl.upql.ext.expr.CompiledDiv;
import net.vpc.upa.impl.upql.ext.expr.CompiledRShift;
import net.vpc.upa.impl.upql.ext.expr.CompiledEquals;
import net.vpc.upa.impl.upql.ext.expr.CompiledDelete;
import net.vpc.upa.impl.upql.ext.expr.CompiledXOr;
import net.vpc.upa.impl.upql.ext.expr.CompiledJoinCriteria;
import net.vpc.upa.impl.upql.ext.expr.CompiledQueryField;
import net.vpc.upa.impl.upql.ext.expr.CompiledBinaryOperatorExpression;
import net.vpc.upa.impl.upql.ext.expr.CompiledQLFunctionExpression;
import net.vpc.upa.impl.upql.ext.expr.CompiledSelect;
import net.vpc.upa.impl.upql.ext.expr.CompiledLiteral;
import net.vpc.upa.impl.upql.ext.expr.CompiledBitOr;
import net.vpc.upa.impl.upql.ext.expr.CompiledVarVal;
import net.vpc.upa.impl.upql.ext.expr.CompiledReminder;
import net.vpc.upa.impl.upql.ext.expr.CompiledInsert;
import net.vpc.upa.impl.upql.ext.expr.CompiledVarOrMethod;
import net.vpc.upa.impl.upql.ext.expr.CompiledAnd;
import net.vpc.upa.impl.upql.ext.expr.CompiledEntityName;
import net.vpc.upa.impl.upql.ext.expr.CompiledNameOrSelect;
import net.vpc.upa.*;
import net.vpc.upa.exceptions.IllegalUPAArgumentException;
import net.vpc.upa.expressions.BinaryOperator;
import net.vpc.upa.expressions.CompiledExpression;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.ExpressionHelper;
import net.vpc.upa.impl.UPAImplDefaults;
import net.vpc.upa.impl.UPAImplKeys;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.impl.upql.util.UPQLCompiledUtils;
import net.vpc.upa.impl.upql.util.UPQLUtils;
import net.vpc.upa.impl.upql.*;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.impl.util.StringUtils;
import net.vpc.upa.impl.util.UPAUtils;
import net.vpc.upa.impl.util.filters.FieldFilters2;
import net.vpc.upa.persistence.ExpressionCompilerConfig;
import net.vpc.upa.types.*;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 * Created by vpc on 6/28/17.
 */
public class ExpressionCompiler implements CompiledExpressionFilteredReplacer {

    private static Logger log = Logger.getLogger(ExpressionCompiler.class.getName());
    private PersistenceUnit persistenceUnit;
    private CompiledExpression rootExpression;
    private ExpressionCompilerConfig config;
    private int navigationDepth;
    private int maxJoins;
    private int maxColumns;
    private int maxHierarchyDepth;
    private int currentJoins;
    private QueryFetchStrategy fetchStrategy;
    private ExpressionManager expressionManager;

    public ExpressionCompiler(CompiledExpression rootExpression, ExpressionCompilerConfig config, PersistenceUnit persistenceUnit) {
        this.persistenceUnit = persistenceUnit;
        this.expressionManager = persistenceUnit.getExpressionManager();
        this.rootExpression = rootExpression;
        this.config = config;
        navigationDepth = (Integer) config.getHint(QueryHints.MAX_NAVIGATION_DEPTH, -1);
        if (navigationDepth < 0) {
            navigationDepth = persistenceUnit.getProperties().getInt("QueryHints." + QueryHints.MAX_NAVIGATION_DEPTH, UPAImplDefaults.QueryHints_MAX_NAVIGATION_DEPTH);
            if (navigationDepth < 0) {
                navigationDepth = UPAImplDefaults.QueryHints_MAX_NAVIGATION_DEPTH;
            }
        }
        this.maxJoins = (Integer) config.getHint(QueryHints.MAX_JOINS, -1);
        if (maxJoins < 0) {
            maxJoins = persistenceUnit.getProperties().getInt("QueryHints." + QueryHints.MAX_JOINS, UPAImplDefaults.QueryHints_MAX_JOINS);
            if (maxJoins < 0) {
                maxJoins = UPAImplDefaults.QueryHints_MAX_JOINS;
            }
        }
        this.maxColumns = (Integer) config.getHint(UPAImplKeys.QueryHints_maxColumns, -1);
        if (maxColumns < 0) {
            maxColumns = persistenceUnit.getProperties().getInt("QueryHints." + UPAImplKeys.QueryHints_maxColumns, UPAImplDefaults.QueryHints_MAX_COLUMNS);
            if (maxColumns < 0) {
                maxColumns = UPAImplDefaults.QueryHints_MAX_COLUMNS;
            }
        }
        this.maxHierarchyDepth = (Integer) config.getHint(UPAImplKeys.QueryHints_maxHierarchyNavigationDepth, -1);
        if (maxHierarchyDepth < 0) {
            maxHierarchyDepth = persistenceUnit.getProperties().getInt("QueryHints." + UPAImplKeys.QueryHints_maxHierarchyNavigationDepth, UPAImplDefaults.QueryHints_MAX_HIERARCHY_NAVIGATION_DEPTH);
            if (maxHierarchyDepth < 0) {
                maxHierarchyDepth = UPAImplDefaults.QueryHints_MAX_HIERARCHY_NAVIGATION_DEPTH;
            }
        }
        fetchStrategy = (QueryFetchStrategy) config.getHint(QueryHints.FETCH_STRATEGY, QueryFetchStrategy.JOIN);
        if (PlatformUtils.isUndefinedEnumValue(QueryFetchStrategy.class, fetchStrategy)) {
            fetchStrategy = QueryFetchStrategy.JOIN;
        }
    }

    public CompiledExpression compile() {
        //will not create a copy in production mode
        CompiledExpression expression = UPAImplDefaults.DEBUG_MODE ? ((CompiledExpressionExt) rootExpression).copy() : rootExpression;
        log.log(Level.FINEST, "Validate Compiled Expression {0}\n\t using config {1}", new Object[]{expression, config});

        CompiledExpressionExt dce = (CompiledExpressionExt) expression;
        //dce.copy()
        String entityBaseName = null;
        String entityAlias = null;
        if (config.isResolveThis()) {
            if (dce instanceof CompiledEntityStatement) {
                entityBaseName = ((CompiledEntityStatement) dce).getEntityName();
                entityAlias = ((CompiledEntityStatement) dce).getEntityAlias();
                if (entityBaseName != null) { // && config.getAliasToEntityContext().get(UPQLUtils.THIS)==null
                    config.bindAliasToEntity(UPQLUtils.THIS, entityBaseName);
                }
                if (entityAlias != null) {
                    config.setThisAlias(entityAlias);
                } else {
                    config.setThisAlias(UPQLUtils.THIS);
                }
            }
        }
        Map<String, Object> updateContext = new HashMap<String, Object>();

        ReplaceResult v2 = UPQLCompiledUtils.replaceExpressions(dce, this, updateContext);
        if (v2.isNewInstance()) {
            dce = v2.getExpression();
        }

//        String newName = entityAlias;//entityAlias != null ? entityAlias : entityBaseName;
//        if (!UPQLUtils.THIS.equals(config.getThisAlias())) {
//            newName = config.getThisAlias();
//        }
//        if (newName != null) {
//            CompiledExpressionUtils.replaceThisVar(dce, newName);
//        } else {
//            CompiledExpressionUtils.removeThisVar(dce);
//        }
        if (dce instanceof CompiledSelect) {
            CompiledSelect d = (CompiledSelect) dce;
            int size = d.getFields().size();
            for (int i = 0; i < size; i++) {
                CompiledQueryField ff = d.getFields().get(i);
                int old = ff.getIndex();
                if (old < 0) {
//                    System.out.println("why ========================");
                    ff.setIndex(i);
                } else if (old == i) {
                    //
                } else {
                    //why?
                    ff.setIndex(i);
                }
            }
        }
        return dce;
    }

    public boolean isTopDown() {
        return true;
    }

    public ReplaceResult update(CompiledExpression e, Map<String, Object> updateContext) {
        ReplaceResult result = ReplaceResult.NO_UPDATES_CONTINUE;
        if (e instanceof CompiledSelect) {
            return updateCompiledSelect((CompiledSelect) e, updateContext);
        } else if (e instanceof CompiledUpdate) {
            return updateCompiledUpdate((CompiledUpdate) e, updateContext);
        } else if (e instanceof CompiledInsert) {
            return updateCompiledInsert((CompiledInsert) e, updateContext);
        } else if (e instanceof CompiledQueryField) {
            throw new IllegalUPAArgumentException("Should have been processed elsewhere");
        } else if (e instanceof CompiledVar) {
            return updateCompiledVar((CompiledVar) e, updateContext);
        } else if (e instanceof CompiledParam) {
            return updateCompiledParam((CompiledParam) e, updateContext);
        } else if (e instanceof CompiledLiteral) {
            return updateCompiledLiteral((CompiledLiteral) e, updateContext);
//        } else if (e instanceof IsHierarchyDescendantCompiled) {
//            return updateIsHierarchyDescendantCompiled((IsHierarchyDescendantCompiled) e);
        } else if (e instanceof CompiledQLFunctionExpression) {
            return updateCompiledQLFunctionExpression((CompiledQLFunctionExpression) e, updateContext);
        } else if (e instanceof CompiledBinaryOperatorExpression) {
            return updateCompiledBinaryOperatorExpression((CompiledBinaryOperatorExpression) e, updateContext);
        }
        return result;
    }

    private ReplaceResult updateCompiledBinaryOperatorExpression(CompiledBinaryOperatorExpression tt, Map<String, Object> updateContext) {
        UPQLCompiledUtils.replaceExpressionChildren(tt, this, updateContext);
        //process children first !!
        CompiledExpressionExt left = tt.getLeft();
        CompiledExpressionExt right = tt.getRight();
        if (tt instanceof CompiledMul || tt instanceof CompiledDiv || tt instanceof CompiledPlus || tt instanceof CompiledMinus
                || tt instanceof CompiledLShift || tt instanceof CompiledRShift || tt instanceof CompiledURShift || tt instanceof CompiledXOr
                || tt instanceof CompiledReminder || tt instanceof CompiledBitAnd || tt instanceof CompiledBitOr) {
            CompiledExpressionExt left0 = left;
            CompiledExpressionExt right0 = right;
            if (left0 instanceof CompiledVarOrMethod) {
                left0 = ((CompiledVarOrMethod) left0).getDeepest();
            }
            if (right0 instanceof CompiledVarOrMethod) {
                right0 = ((CompiledVarOrMethod) right0).getDeepest();
            }
            if (tt instanceof CompiledPlus) {
                tt.setTypeTransform(PlatformUtils.getDataTypeTransformAfterImplicitConversionPlus(left0.getTypeTransform(), right0.getTypeTransform()));
            } else {
                tt.setTypeTransform(PlatformUtils.getDataTypeTransformAfterImplicitConversion(left0.getTypeTransform(), right0.getTypeTransform()));
            }
        }
        if (left instanceof CompiledVarOrMethod) {
            left = ((CompiledVarOrMethod) left).getDeepest();
        }
        if (right instanceof CompiledVarOrMethod) {
            right = ((CompiledVarOrMethod) right).getDeepest();
        }
        Field baseField = (Field) left.getClientProperty("UPA.Flattened.BaseField");
        if (right instanceof CompiledVar && !(left instanceof CompiledVar)) {
            CompiledExpressionExt temp = left;
            left = right;
            right = temp;
        }
        Relationship manyToOneRelationship = baseField == null ? null : baseField.getManyToOneRelationship();
        if (left instanceof CompiledVar && manyToOneRelationship != null) {
            if (right instanceof CompiledParam) {
                CompiledParam p = (CompiledParam) right;
                EntityBuilder builder = manyToOneRelationship.getTargetEntity().getBuilder();
                PrimitiveId primitiveIdImpl = builder.objectToPrimitiveId(p.getValue());
                if (primitiveIdImpl == null && p.getValue() != null) {
                    p.setValue(null);
                } else if (primitiveIdImpl != null && primitiveIdImpl.size() == 1) {
                    p.setValue(primitiveIdImpl.getValue());
//                    p.setType(primitiveIdImpl.fields[0].getEffectiveTypeTransform());
                    return ReplaceResult.UPDATE_AND_STOP;
                }
            } else if (right instanceof CompiledLiteral) {
                CompiledLiteral p = (CompiledLiteral) right;
                EntityBuilder builder = manyToOneRelationship.getTargetEntity().getBuilder();
                PrimitiveId primitiveIdImpl = builder.objectToPrimitiveId(p.getValue());
                if (primitiveIdImpl == null && p.getValue() != null) {
                    p.setValue(null);
                } else if (primitiveIdImpl != null && primitiveIdImpl.size() == 1) {
                    p.setValue(primitiveIdImpl.getValue());
                    p.setDataTypeTransform(primitiveIdImpl.getField(0).getEffectiveTypeTransform());
                    return ReplaceResult.UPDATE_AND_STOP;
                }
            }
        }
        if (left instanceof CompiledVar
                && right.getTypeTransform().getSourceType() instanceof StringType
                && (right instanceof CompiledParam || right instanceof CompiledLiteral)) {

            if (left.getTypeTransform().getSourceType() instanceof EnumType) {
                EnumType et = (EnumType) left.getTypeTransform().getSourceType();
                if (right instanceof CompiledParam) {
                    CompiledParam p = (CompiledParam) right;
                    String value = (String) p.getValue();
                    if (value != null) {
                        p.setValue(et.parse(value));
                        p.setTypeTransform(left.getTypeTransform());
                        return ReplaceResult.UPDATE_AND_STOP;
                    }
                } else if (right instanceof CompiledLiteral) {
                    CompiledLiteral p = (CompiledLiteral) right;
                    String value = (String) p.getValue();
                    if (value != null) {
                        p.setValue(et.parse(value));
                        p.setTypeTransform(left.getTypeTransform());
                        return ReplaceResult.UPDATE_AND_STOP;
                    }
                }
            } else if (left.getTypeTransform().getSourceType() instanceof TemporalType) {
                TemporalType et = (TemporalType) left.getTypeTransform().getSourceType();
                if (right instanceof CompiledParam) {
                    CompiledParam p = (CompiledParam) right;
                    String value = (String) p.getValue();
                    if (value != null) {
                        p.setValue(et.parse(value));
                        p.setTypeTransform(left.getTypeTransform());
                        return ReplaceResult.UPDATE_AND_STOP;
                    }
                } else if (right instanceof CompiledLiteral) {
                    CompiledLiteral p = (CompiledLiteral) right;
                    String value = (String) p.getValue();
                    if (value != null) {
                        p.setValue(et.parse(value));
                        p.setTypeTransform(left.getTypeTransform());
                        return ReplaceResult.UPDATE_AND_STOP;
                    }
                }
            }
        }
        return ReplaceResult.NO_UPDATES_STOP;
    }

    private ReplaceResult updateCompiledQueryField(CompiledQueryField tt, Map<String, Object> updateContext) {
        updateContext = updateContext == null ? new HashMap<String, Object>() : new HashMap<String, Object>(updateContext);
        CompiledEntityStatement enclosingStmt = (CompiledEntityStatement) updateContext.get("updateContext");
        int depth = UPAUtils.convertToInt(updateContext.get("depth"), navigationDepth + 1);
        int currColumnsCount = UPAUtils.convertToInt(updateContext.get("columnsCount"), 1);
        if (enclosingStmt == null) {
            enclosingStmt = (CompiledEntityStatement) tt.getParentExpression();
        }
        if (enclosingStmt == null) {
            throw new IllegalUPAArgumentException("No Enclosing Select for " + tt);
        }
        boolean again = true;
        CompiledExpressionExt ttExpr = tt.getExpression();
        CompiledExpressionExt ttExpr0 = ttExpr;
        ReplaceResult r = null;
        boolean someUpdates = false;
        updateContext.put("enclosingStmt", enclosingStmt);
        updateContext.put("depth", depth);
        while (again) {
            again = false;
            updateContext.put("flattenId", false);
            r = UPQLCompiledUtils.replaceExpressions(ttExpr0, this, updateContext);
            if (r.getReplaceResultType() != ReplaceResultType.NO_UPDATES) {
                someUpdates = true;
            }
            if (r.isNewInstance() && !r.isStop()) {
                again = true;
                ttExpr0 = r.getExpression(ttExpr);
                tt.setExpression(ttExpr0);
            }
        }
        CompiledQueryFieldsTuple tuple = new CompiledQueryFieldsTuple();
        CompiledExpressionExt e2 = r.getExpression(ttExpr0);
        if (e2 instanceof CompiledVar) {
            CompiledVar cv = (CompiledVar) e2;
            if (cv.getChild() != null && cv.getChild().getChild() != null) {
                throw new IllegalUPAArgumentException("Unexpected!!");
            }
            CompiledVar finest = (CompiledVar) cv.getDeepest();
            List<Field> fieldsToExpand = new ArrayList<Field>();
//            List<Field> fieldsToPreserve = new ArrayList<>();
            Object referrer = resolveReferrer(finest);
            if (referrer instanceof Entity) {
                fieldsToExpand.addAll(((Entity) referrer).getFields(depth == 0 ? FieldFilters2.ID : config.getExpandFieldFilter()));
            } else if (referrer instanceof Field) {
                Field field = (Field) referrer;
                Field oldReferrerField = tt.getReferrerField();
                Entity oldReferrerEntity = tt.getParentBindingEntity();
                if (oldReferrerEntity == null && oldReferrerField != null) {
                    oldReferrerEntity = oldReferrerField.getEntity();
                }
                if (oldReferrerEntity == null) {
                    oldReferrerEntity = ((Field) referrer).getEntity();
//                    throw new IllegalUPAArgumentException("Unexpected");
                }
                ManyToOneRelationship manyToOneRelationship = field.getManyToOneRelationship();
                if (manyToOneRelationship != null) {
                    List<Field> newFields = FieldFilters2.filter(manyToOneRelationship.getTargetEntity().getFields(), config.getExpandFieldFilter());
                    if (currentJoins >= maxJoins || depth <= 0 || (fetchStrategy == QueryFetchStrategy.SELECT) || (currColumnsCount + newFields.size()) > maxColumns) {
                        List<Field> sfields = manyToOneRelationship.getSourceRole().getFields();
                        List<Field> tfields = manyToOneRelationship.getTargetRole().getFields();
                        for (int i = 0; i < sfields.size(); i++) {
                            Field sfield = sfields.get(i);
                            Field tfield = tfields.get(i);
                            CompiledExpressionExt pp = finest.getParentExpression();
                            if (pp == null || (pp.getParentExpression() != null && !(pp.getParentExpression() instanceof CompiledQueryField))) {
                                throw new IllegalUPAArgumentException("Unexpected");
                            }
                            pp = pp.copy();
                            BindingId lbinding = BindingId.createChild(tt.getBinding(), tfield.getName());
                            CompiledVar f3 = new CompiledVar(sfield.getName(), sfield, lbinding);
                            ((CompiledVar) pp).setChild(f3);
                            resolveReferrer((CompiledVar) pp);
                            resolveReferrer(f3);

                            CompiledQueryField item = new CompiledQueryField(
                                    tfield.getName(),
                                    pp,
                                    -1,
                                    false,
                                    null,
                                    lbinding,
                                    null,
                                    true
                            );
                            item.setReferrerField(tfield);
                            item.setParentBindingEntity(oldReferrerEntity);
                            tuple.add(item);
                        }

                    } else if (fetchStrategy == QueryFetchStrategy.JOIN) {
                        CompiledExpressionExt pp = finest.getParentExpression();
                        String joinAlias = null;//tt.getAlias()
                        if (pp != null && pp instanceof CompiledVar) {
                            joinAlias = ((CompiledVar) pp).getName();
                        }
                        if (StringUtils.isNullOrEmpty(joinAlias)) {
                            throw new IllegalUPAArgumentException("Unable to resolve join alias : " + cv);
                        }
                        BindingJoinInfo bindingJoinInfo = addBindingJoin(enclosingStmt, field, joinAlias, tt.getBinding());
                        finest = new CompiledVar(
                                bindingJoinInfo.alias,
                                bindingJoinInfo.entity,
                                bindingJoinInfo.binding
                        );
                        fieldsToExpand.addAll(newFields);
                        updateContext.put("columnsCount", newFields.size() + currColumnsCount);
                        if (manyToOneRelationship.getHierarchyExtension() != null && depth > 3) {
                            depth = 3;
                            updateContext.put("depth", depth);
                        }
                    } else {
                        throw new IllegalUPAArgumentException("Unsupported Fetch Strategy " + fetchStrategy);
                    }
                } else {
                    if (someUpdates) {
                        tt.setExpression(e2);
                        tt.setReferrerField(field);
                        tt.setParentBindingEntity(oldReferrerEntity);
                        return ReplaceResult.UPDATE_AND_STOP;
                    }
                    tt.setReferrerField(field);
                    tt.setParentBindingEntity(field.getEntity());
                    return ReplaceResult.NO_UPDATES_STOP;
                }
            } else {
                throw new IllegalUPAArgumentException("Unexpected");
            }

            for (Field field : fieldsToExpand) {
                CompiledVar f2 = (CompiledVar) finest.copy();
                CompiledVar f3 = new CompiledVar(field.getName(), field, BindingId.createChild(tt.getBinding(), field.getName()));
                f2.setChild(f3);

                CompiledQueryField item = new CompiledQueryField(
                        field.getName(),
                        f2,
                        -1,
                        false,
                        null,
                        BindingId.createChild(tt.getBinding(), field.getName()),
                        null
                );
                item.setReferrerField(field);
                tt.setParentBindingEntity(field.getEntity());

                //just to help sub replacements!
                item.setParentExpression(enclosingStmt);

                if (depth > 0) {
                    updateContext = new HashMap<String, Object>(updateContext);
                    updateContext.put("depth", depth - 1);
                    ReplaceResult replaceResult = updateCompiledQueryField(item, updateContext);
                    CompiledExpression expression = replaceResult.getExpression(item);
                    if (expression instanceof CompiledQueryFieldsTuple) {
                        for (CompiledQueryField compiledQueryField : ((CompiledQueryFieldsTuple) expression).getItems()) {
                            tuple.add(compiledQueryField);
                        }
                    } else {
                        tuple.add((CompiledQueryField) expression);
                    }
                } else {
                    tuple.add(item);
                }

                //remove Binding
                item.unsetParent();
            }
            if (tuple.getItems().size() == 1) {
                return ReplaceResult.stopWithNewObj(tuple.getItems().get(0));
            } else if (tuple.getItems().size() == 0) {
                throw new IllegalUPAArgumentException("Unexpected");
            } else {
                return ReplaceResult.stopWithNewObj(tuple);
            }
        } else {
            tt.setExpression(e2);
            return ReplaceResult.UPDATE_AND_CONTINUE_CLEAN;
        }
    }

    private ReplaceResult updateCompiledVar(CompiledVar o, Map<String, Object> updateContext) {
        if (updateContext == null) {
            updateContext = new HashMap<String, Object>();
        }
        CompiledEntityStatement rootStatement = (CompiledEntityStatement) updateContext.get("rootStatement");
        CompiledEntityStatement enclosingStmt = (CompiledEntityStatement) updateContext.get("enclosingStmt");
        Boolean flattenId = (Boolean) updateContext.get("flattenId");
        if (flattenId == null) {
            flattenId = true;
        }
        updateContext.put("rootStatement", rootStatement);
        updateContext.put("enclosingStmt", enclosingStmt);
        updateContext.put("flattenId", flattenId);
        Object ref = resolveReferrer(o);
        if (o.getImplicitDeclaration() != null) {
            if (o.getImplicitDeclaration().getName() != null) {
                ExpressionDeclaration idec = o.getImplicitDeclaration();
                if (idec.getValidName() == null) {
                    throw new IllegalUPAArgumentException("Unexpected null name");
                }
                CompiledVar v2 = new CompiledVar(idec.getValidName());
                switch (idec.getReferrerType()) {
                    case ENTITY: {
                        v2.setReferrer(persistenceUnit.getEntity((String) idec.getReferrerName()));
                        break;
                    }
                    case FIELD: {
                        throw new IllegalUPAArgumentException("Unexpected field declaration");
                    }
                    case SELECT: {
                        throw new IllegalUPAArgumentException("Unexpected Select declaration");
                    }
                    default: {
                        throw new IllegalUPAArgumentException("Unexpected unknown declaration");
                    }
                }
                CompiledExpressionExt p = o.getParentExpression();
                o.unsetParent();
                o.setImplicitDeclaration(null);
                v2.setChild(o);
                v2.setParentExpression(p);
                ReplaceResult r2 = UPQLCompiledUtils.replaceExpressions(v2, this, updateContext);
                v2 = (CompiledVar) r2.getExpression(v2);
                v2.unsetParent();
                return ReplaceResult.stopWithNewObj(v2);
            }
        }
        if (enclosingStmt == null) {
            enclosingStmt = UPQLCompiledUtils.findEnclosingStatement(o, persistenceUnit);
        }
        if (enclosingStmt == null) {
            throw new IllegalUPAArgumentException("No Enclosing Statement for " + o);
        }
        updateContext.put("rootStatement", rootStatement);
        updateContext.put("enclosingStmt", enclosingStmt);
        updateContext.put("flattenId", flattenId);
        boolean isThis = !(o.getParentExpression() instanceof CompiledVar) && UPQLUtils.THIS.equals(o.getName());
        if (isThis) {
            if (rootStatement == null) {
                rootStatement = UPQLCompiledUtils.findRootStatement(o, persistenceUnit);
            }
            if (rootStatement == null) {
                throw new IllegalUPAArgumentException("No Root Statement for " + o);
            }
            updateContext.put("rootStatement", rootStatement);
            if (rootStatement.getEntityAlias() == null) {
                CompiledVarOrMethod child = o.getChild();
                if (child == null) {
                    if (rootStatement.getEntityName() == null) {
                        throw new IllegalUPAArgumentException("Missing Alias for " + rootStatement);
                    }
                    o.setName(rootStatement.getEntityName());
                    return ReplaceResult.UPDATE_AND_CONTINUE_CLEAN;
                }
                ReplaceResult replaceChild = null;
                replaceChild = UPQLCompiledUtils.replaceExpressions(child, this, updateContext);
                CompiledExpressionExt e2 = replaceChild.getExpression(child);
                if (replaceChild.isNewInstance()) {
                    return ReplaceResult.continueWithNewCleanObj(e2);
                }
                //no alias should replace this with Table Name
                if (o.getReferrer() instanceof Entity) {
                    o.setName("$(" + ((Entity) o.getReferrer()).getName() + ")");
                    return ReplaceResult.UPDATE_AND_CONTINUE_CLEAN;//continueWithNewCleanObj(e2);
                }
                e2.unsetParent();
                return ReplaceResult.continueWithNewCleanObj(e2);
            }
        }
        String entityAlias = enclosingStmt.getEntityAlias();
//        if (entityAlias == null) {
//            throw new IllegalUPAArgumentException("Missing entityAlias for "+enclosingStmt);
//        }
        if (ref instanceof Field) {

            Field field = (Field) ref;
            if (field.getModifiers().contains(FieldModifier.SELECT_LIVE)) {
                Formula liveFormula = UPAUtils.getSelectFormula(field);
                if (liveFormula instanceof CustomFormula) {
                    //do nothing, should be processed as custom formula later
                    throw new IllegalUPAArgumentException("Unsupported Live Formula for " + field + " : " + liveFormula);
                } else if (liveFormula instanceof ExpressionFormula) {
                    ExpressionFormula ef = (ExpressionFormula) liveFormula;
                    Expression expr = ef.getExpression();

                    ExpressionCompilerConfig cfg = new ExpressionCompilerConfig();
                    cfg.setTranslateOnly();
                    cfg.setThisAlias(entityAlias);
                    cfg.bindAliasToEntity(entityAlias, field.getEntity().getName());
                    CompiledExpressionExt rr = (CompiledExpressionExt) expressionManager.compileExpression(expr, cfg);
                    CompiledExpressionExt parentExpression = o.getParentExpression();
                    if (parentExpression == null) {
                        return ReplaceResult.continueWithNewDirtyObj(rr);
                    } else if (parentExpression instanceof CompiledVar) {
                        parentExpression = UPQLCompiledUtils.copyToRootVar((CompiledVar) parentExpression);
                        ReplaceResult pr = UPQLCompiledUtils.replaceThisVar(rr, (CompiledVarOrMethod) parentExpression, updateContext);
                        CompiledExpressionExt expression = pr.getExpression(rr);
                        expression.setParentExpression(UPQLCompiledUtils.findRootNonVar(o));
                        return ReplaceResult.continueWithNewDirtyObj(expression);
                    } else {
                        throw new IllegalUPAArgumentException("Should replace this with some thing else");
                    }
                } else {
                    throw new IllegalUPAArgumentException("Unsupported Live Formula for " + field + " : " + liveFormula);
                }
            } else {
                Relationship manyToOneRelationship = field.getManyToOneRelationship();
                if (manyToOneRelationship != null) {
                    if (o.getChild() == null) {
                        CompiledExpressionExt baseRoot = UPQLCompiledUtils.findRootNonVar(o);
                        if (baseRoot instanceof CompiledQueryField) {
                            //good no further guesses!
                        } else if (baseRoot instanceof CompiledBinaryOperatorExpression) {
                            //force flatten!
                            flattenId = true;
                            updateContext.put("flattenId", flattenId);
                        } else {

                        }
                        if (flattenId) {
                            List<Field> fields = manyToOneRelationship.getSourceRole().getFields();
                            if (fields.size() == 1) {
                                Field field0 = fields.get(0);
                                CompiledVar newVar = new CompiledVar(field0.getName(), field0, BindingId.createChild(o.getBinding(), field0.getName()));
                                newVar.setReferrer(field0);
                                newVar.setClientProperty("UPA.Flattened", true);
                                newVar.setClientProperty("UPA.Flattened.BaseField", field);
                                return ReplaceResult.stopWithNewObj(newVar);
                            } else {
                                throw new IllegalUPAArgumentException("Unsupported multi Id Entity " + manyToOneRelationship.getSourceRole().getEntity());
                            }
                        } else {
                            return ReplaceResult.NO_UPDATES_STOP;
                        }
                    } else {
                        String parentAlias = null;
                        String oldEntityAlias = null;
                        if (o.getParentExpression() instanceof CompiledVar
                                && (entityAlias == null
                                || !entityAlias.equals(((CompiledVar) o.getParentExpression()).getName()))) {
                            parentAlias = ((CompiledVar) o.getParentExpression()).getName();
                            oldEntityAlias = entityAlias;
                            entityAlias = parentAlias;
                        }
                        BindingJoinInfo d = addBindingJoin(enclosingStmt, field, entityAlias, BindingId.createChild(o.getBinding(), field.getName()));
                        CompiledVarOrMethod child = o.getChild();
                        CompiledVar newVar = new CompiledVar(d.alias, d.entity, d.binding);
                        newVar.setBinding(d.binding);
                        child.unsetParent();
                        child.setParentExpression(newVar);
                        ReplaceResult repl = UPQLCompiledUtils.replaceExpressions(child, this, updateContext);
                        o.setChild(null); //unbind child to old parent
                        if (repl.isNewInstance()) {
                            CompiledVarOrMethod child2 = (CompiledVarOrMethod) repl.getExpression(child);
                            if (child2.getChild() == null) {
                                newVar.setChild(child2);
                            } else {
                                newVar = (CompiledVar) child2;
                                newVar.setBinding(d.binding);
                            }
                        } else {
                            newVar.setChild(child);
                        }
                        return ReplaceResult.stopWithNewObj(newVar);
                    }
                }
            }
        } else if (ref instanceof Entity) {
            CompiledVarOrMethod child = o.getChild();
            if (child == null) {
                return ReplaceResult.NO_UPDATES_STOP;
            }
            ReplaceResult replaceChild = null;
            replaceChild = UPQLCompiledUtils.replaceExpressions(child, this, updateContext);
            switch (replaceChild.getReplaceResultType()) {
                case NEW_INSTANCE: {
                    ReplaceResult e2 = UPQLCompiledUtils.replaceThisVar(replaceChild.getExpression(), o, updateContext);
                    switch (UPAUtils.max(e2.getReplaceResultType(), replaceChild.getReplaceResultType())) {
                        case NO_UPDATES: {
                            return ReplaceResult.NO_UPDATES_STOP;
                        }
                        case UPDATE: {
                            return ReplaceResult.UPDATE_AND_STOP;
                        }
                        case NEW_INSTANCE: {
                            CompiledExpressionExt expression = e2.getExpression(replaceChild.getExpression(child));
                            if (expression instanceof CompiledVar) {
                                CompiledVarOrMethod cvar = (CompiledVarOrMethod) e2.getExpression(replaceChild.getExpression(child));
                                if (cvar.getChild() != null) {
                                    return ReplaceResult.stopWithNewCleanObj(cvar);
                                } else {
                                    o.setChild(cvar);
                                    return ReplaceResult.UPDATE_AND_STOP;
                                }
                            } else {
                                return ReplaceResult.stopWithNewDirtyObj(expression);
                            }
                        }
                        case REMOVE: {
                            o.setChild(null);
                            return ReplaceResult.UPDATE_AND_STOP;
                        }
                    }
                    throw new IllegalUPAArgumentException("Unexpected");
                }
                case UPDATE: {
                    return ReplaceResult.UPDATE_AND_STOP;
                }
                case REMOVE: {
                    child.unsetParent();
                    o.setChild(null);
                    return ReplaceResult.UPDATE_AND_STOP;
                }
            }
        }
        return ReplaceResult.NO_UPDATES_STOP;
    }

    private ReplaceResult updateCompiledUpdate(CompiledUpdate s, Map<String, Object> updateContext) {
        for (int i = 0; i < s.countFields(); i++) {
            CompiledVar fvar = s.getField(i);
            CompiledExpressionExt vv = s.getFieldValue(i);

            Field f = (Field) resolveReferrer(fvar);
            if (f == null) {
                throw new IllegalUPAArgumentException("Field not found " + fvar + " in " + s.getEntity().getName());
            }
            if (vv.getTypeTransform() == null || vv.getTypeTransform().getTargetType().getPlatformType().equals(Object.class)) {
                vv.setTypeTransform(f.getEffectiveTypeTransform());
            } else {
                //ignore
            }
            if (fvar.getChild() != null) {
                if (!(fvar.getChild() instanceof CompiledVar)) {
                    throw new IllegalUPAArgumentException();
                }
                if (fvar.getChild().getChild() != null) {
                    throw new IllegalUPAArgumentException();
                }
            }
        }
        return ReplaceResult.UPDATE_AND_CONTINUE_CLEAN;
    }

    private ReplaceResult updateCompiledInsert(CompiledInsert s, Map<String, Object> updateContext) {
        for (int i = 0; i < s.countFields(); i++) {
            CompiledVar fvar = s.getField(i);
            CompiledExpressionExt vv = s.getFieldValue(i);
            Field f = (Field) resolveReferrer(fvar);
            if (f == null) {
                throw new IllegalUPAArgumentException("Field not found " + fvar + " in " + s.getEntity().getName());
            }
            if (vv.getTypeTransform() == null || vv.getTypeTransform().getTargetType().getPlatformType().equals(Object.class)) {
                vv.setTypeTransform(f.getEffectiveTypeTransform());
            } else {
                //ignore
            }
        }
        return ReplaceResult.UPDATE_AND_CONTINUE_CLEAN;
    }

    private ReplaceResult updateCompiledSelect(CompiledSelect s, Map<String, Object> updateContext) {
        ReplaceResult result = ReplaceResult.NO_UPDATES_STOP;
        if (s.getParentExpression() == null) {
            //this is the root select
            if (s.getFields().size() == 0) {
                String a = s.getEntityAlias();
                if (a == null) {
                    s.setEntityAlias(UPQLUtils.THIS);
                }
                CompiledVar v = new CompiledVar(s.getEntityAlias());
                v.setReferrer(persistenceUnit.getEntity(s.getEntityName()));
                s.field(v);
                //stop because all children will be processed here!
                result = ReplaceResult.UPDATE_AND_STOP;
            }
        } else {
            if (s.getFields().size() == 0) {
                throw new IllegalUPAArgumentException("Inner Select Should have at least one selected field");
            }
        }
        updateContext = updateContext == null ? new HashMap<String, Object>() : new HashMap<String, Object>(updateContext);
        expandEntityFilters(s, updateContext);
        List<CompiledQueryField> fields = new ArrayList<CompiledQueryField>(s.getFields());
        List<Integer> toRemove = new ArrayList<Integer>();
        updateContext.put("columnsCount", fields.size());
        for (int i = 0; i < fields.size(); i++) {
            CompiledQueryField qf = fields.get(i);
            qf.setBinding(BindingId.create(String.valueOf(i)));
            updateContext.put("enclosingStmt", s);
            updateContext.put("depth", navigationDepth + 1);
            updateContext.put("index", i);

            ReplaceResult rqf = updateCompiledQueryField(qf, updateContext);
            if (rqf.getReplaceResultType() == ReplaceResultType.NEW_INSTANCE) {
                result = ReplaceResult.UPDATE_AND_STOP;
                CompiledExpressionExt replacement = rqf.getExpression();
                if (replacement instanceof CompiledQueryFieldsTuple) {
                    CompiledQueryField[] subExpressions = ((CompiledQueryFieldsTuple) replacement).getCompiledQueryFields();
                    toRemove.add(i);
                    for (CompiledQueryField ee : subExpressions) {
                        s.addField(ee);
                    }
                    updateContext.put("columnsCount", UPAUtils.convertToInt(updateContext.get("columnsCount"), 0) - 1 + subExpressions.length);
                } else if (replacement instanceof CompiledQueryField) {
                    CompiledQueryField replacement1 = (CompiledQueryField) replacement;
                    s.setField(replacement1, i);
                } else {
                    qf.setExpression(replacement);
                }
            }
            if (rqf.getReplaceResultType() != ReplaceResultType.NO_UPDATES) {
                result = ReplaceResult.UPDATE_AND_STOP;
            }
        }
        for (int i = toRemove.size() - 1; i >= 0; i--) {
            s.removeField(toRemove.get(i));
        }
        CompiledExpressionExt[] groupByExpressions = s.getGroupByExpressions();
        for (int i = 0; i < groupByExpressions.length; i++) {
            CompiledExpressionExt ee = groupByExpressions[i];
            ReplaceResult rqf = UPQLCompiledUtils.replaceExpressions(ee, this, updateContext);
            if (rqf.getReplaceResultType() == ReplaceResultType.NEW_INSTANCE) {
                s.setGroupBy(rqf.getExpression(), i);
            }
            if (rqf.getReplaceResultType() != ReplaceResultType.NO_UPDATES) {
                result = ReplaceResult.UPDATE_AND_STOP;
            }
        }
        CompiledOrderItem[] orders = s.getOrderByExpressions();
        for (int i = 0; i < orders.length; i++) {
            CompiledExpressionExt ee = orders[i].getExpression();
            ReplaceResult rqf = UPQLCompiledUtils.replaceExpressions(ee, this, updateContext);
            if (rqf.getReplaceResultType() == ReplaceResultType.NEW_INSTANCE) {
                orders[i].setExpression(rqf.getExpression());
            }
            if (rqf.getReplaceResultType() != ReplaceResultType.NO_UPDATES) {
                result = ReplaceResult.UPDATE_AND_STOP;
            }
        }
        CompiledNameOrSelect entity = s.getEntity();
        if (entity != null) {
            ReplaceResult rqf = UPQLCompiledUtils.replaceExpressions(entity, this, updateContext);
            if (rqf.getReplaceResultType() == ReplaceResultType.NEW_INSTANCE) {
                s.from((CompiledNameOrSelect) rqf.getExpression(), s.getEntityAlias());
            }
            if (rqf.getReplaceResultType() != ReplaceResultType.NO_UPDATES) {
                result = ReplaceResult.UPDATE_AND_STOP;
            }
        }
        CompiledExpressionExt where = s.getWhere();
        if (where != null) {
            ReplaceResult rqf = UPQLCompiledUtils.replaceExpressions(where, this, updateContext);
            if (rqf.getReplaceResultType() == ReplaceResultType.NEW_INSTANCE) {
                s.where(rqf.getExpression(where));
            }
            if (rqf.getReplaceResultType() != ReplaceResultType.NO_UPDATES) {
                result = ReplaceResult.UPDATE_AND_STOP;
            }
        }
        CompiledExpressionExt having = s.getHaving();
        if (having != null) {
            ReplaceResult rqf = UPQLCompiledUtils.replaceExpressions(having, this, updateContext);
            if (rqf.getReplaceResultType() == ReplaceResultType.NEW_INSTANCE) {
                s.having(rqf.getExpression(having));
            }
            if (rqf.getReplaceResultType() != ReplaceResultType.NO_UPDATES) {
                result = ReplaceResult.UPDATE_AND_STOP;
            }
        }
        CompiledJoinCriteria[] joins = s.getJoins();
        currentJoins += joins.length;
        if (s != rootExpression) {
            currentJoins++;
        }
        for (int i = 0; i < joins.length; i++) {
            CompiledExpressionExt condition = joins[i].getCondition();
            if (condition != null) {
                ReplaceResult rqf = UPQLCompiledUtils.replaceExpressions(condition, this, updateContext);
                if (rqf.getReplaceResultType() == ReplaceResultType.NEW_INSTANCE) {
                    joins[i].setCondition(rqf.getExpression());

                }
                if (rqf.getReplaceResultType() != ReplaceResultType.NO_UPDATES) {
                    result = ReplaceResult.UPDATE_AND_STOP;
                }
            }
        }
        return result;
    }

    private ReplaceResult updateCompiledParam(CompiledParam o, Map<String, Object> updateContext) {
        DataTypeTransform d = getValidDataType(o);
        if (d != null) {
            return ReplaceResult.NO_UPDATES_STOP;
        }
        if (o.getValue() != null) {
            o.setTypeTransform(IdentityDataTypeTransform.ofType(o.getValue().getClass()));
            d = getValidDataType(o);
            if (d != null) {
                return ReplaceResult.NO_UPDATES_STOP;
            }
        }
        CompiledExpressionExt pe = o.getParentExpression();
        if (pe instanceof CompiledBinaryOperatorExpression) {
            CompiledBinaryOperatorExpression c = (CompiledBinaryOperatorExpression) pe;
            BinaryOperator operator = c.getOperator();
            switch (operator) {
                case EQ:
                case DIFF:
                case LE:
                case LT:
                case GE:
                case GT:
                case BIT_AND:
                case BIT_OR:
                case PLUS:
                case MINUS:
                case MUL:
                case DIV:
                case REM:
                case LSHIFT:
                case RSHIFT:
                case XOR:
                case URSHIFT: {
                    CompiledExpressionExt a = c.getLeft();
                    CompiledExpressionExt b = c.getRight();
                    if (o == a) {
                        DataTypeTransform d2 = getValidDataType(b);
                        if (d2 != null) {
                            o.setTypeTransform(d2);
                            return ReplaceResult.UPDATE_AND_STOP;
                        }
                    } else if (o == b) {
                        DataTypeTransform d2 = getValidDataType(a);
                        if (d2 != null) {
                            o.setTypeTransform(d2);
                            return ReplaceResult.UPDATE_AND_STOP;
                        }
                    }
                    return ReplaceResult.NO_UPDATES_STOP;
                }
                case LIKE: {
                    CompiledExpressionExt a = c.getLeft();
                    CompiledExpressionExt b = c.getRight();
                    o.setTypeTransform(IdentityDataTypeTransform.STRING_UNLIMITED);
                    return ReplaceResult.UPDATE_AND_STOP;
                }
                case OR:
                case AND: {
                    o.setTypeTransform(IdentityDataTypeTransform.BOOLEAN);
                    return ReplaceResult.UPDATE_AND_STOP;
                }
            }
        } else if (pe instanceof CompiledVarVal) {
            CompiledVarVal cvv = (CompiledVarVal) pe;
            if (cvv.getVal() == o) {
                //it should be the case
                o.setTypeTransform(cvv.getVar().getTypeTransform());
                return ReplaceResult.UPDATE_AND_STOP;
            }
        }
        return ReplaceResult.NO_UPDATES_STOP;
    }

    private ReplaceResult updateCompiledLiteral(CompiledLiteral o, Map<String, Object> updateContext) {
        DataTypeTransform d = getValidDataType(o);
        if (d != null) {
            return ReplaceResult.NO_UPDATES_STOP;
        }
        if (o.getValue() != null) {
            o.setTypeTransform(IdentityDataTypeTransform.ofType(o.getValue().getClass()));
            d = getValidDataType(o);
            if (d != null) {
                return ReplaceResult.NO_UPDATES_STOP;
            }
        }
        CompiledExpressionExt pe = o.getParentExpression();
        if (pe instanceof CompiledBinaryOperatorExpression) {
            CompiledBinaryOperatorExpression c = (CompiledBinaryOperatorExpression) pe;
            BinaryOperator operator = c.getOperator();
            switch (operator) {
                case EQ:
                case DIFF:
                case LE:
                case LT:
                case GE:
                case GT:
                case BIT_AND:
                case BIT_OR:
                case PLUS:
                case MINUS:
                case MUL:
                case DIV:
                case REM:
                case LSHIFT:
                case RSHIFT:
                case XOR:
                case URSHIFT: {
                    CompiledExpressionExt a = c.getLeft();
                    CompiledExpressionExt b = c.getRight();
                    if (o == a) {
                        DataTypeTransform d2 = getValidDataType(b);
                        if (d2 != null) {
                            o.setTypeTransform(d2);
                            return ReplaceResult.UPDATE_AND_STOP;
                        }
                    } else if (o == b) {
                        DataTypeTransform d2 = getValidDataType(a);
                        if (d2 != null) {
                            o.setTypeTransform(d2);
                            return ReplaceResult.UPDATE_AND_STOP;
                        }
                    }
                    return ReplaceResult.NO_UPDATES_STOP;
                }
                case LIKE: {
                    CompiledExpressionExt a = c.getLeft();
                    CompiledExpressionExt b = c.getRight();
                    o.setTypeTransform(IdentityDataTypeTransform.STRING_UNLIMITED);
                    return ReplaceResult.UPDATE_AND_STOP;
                }
                case OR:
                case AND: {
                    o.setTypeTransform(IdentityDataTypeTransform.BOOLEAN);
                    return ReplaceResult.UPDATE_AND_STOP;
                }
            }
        } else if (pe instanceof CompiledVarVal) {
            CompiledVarVal cvv = (CompiledVarVal) pe;
            if (cvv.getVal() == o) {
                //it should be the case
                o.setTypeTransform(cvv.getVar().getTypeTransform());
                return ReplaceResult.UPDATE_AND_STOP;
            }
        }
        return ReplaceResult.NO_UPDATES_STOP;
    }

    private BindingJoinInfo addBindingJoin(CompiledEntityStatement qs, Field field, String entityAlias, BindingId binding) {
        if (entityAlias == null) {
            throw new IllegalUPAArgumentException("Null Join Alias");
        }
        ExprContext context = ExprContext.get(qs);
        BindingJoinInfo ret = new BindingJoinInfo();
        Relationship rel = ((ManyToOneType) field.getDataType()).getRelationship();
        Entity masterEntity = rel.getTargetRole().getEntity();
        String generatedAlias = context.getAliasFor(binding);
        boolean addJoin = generatedAlias == null;
        ret.entity = masterEntity;
        ret.binding = binding;
        if (!addJoin) {
            ret.alias = generatedAlias;
        } else {
            currentJoins++;
            ret.newlyCreated = true;
            generatedAlias = context.createAliasFor(binding);
            CompiledExpressionExt cond = null;
            Entity detailEntity = field.getEntity();
            for (Map.Entry<String, String> entry : rel.getTargetToSourceFieldNamesMap(false).entrySet()) {
                String entityAlias2 = entityAlias;
                if (UPQLUtils.THIS.equals(entityAlias2) && qs instanceof CompiledUpdate) {
                    entityAlias2 = qs.getEntityAlias();
                    if (entityAlias2 == null) {
                        entityAlias2 = detailEntity.getName();
                    }
                }
                CompiledVar detailAlias = new CompiledVar(entityAlias2, detailEntity, null);
                CompiledVar masterAlias = new CompiledVar(generatedAlias, masterEntity, null);
                detailAlias.setChild(new CompiledVar(detailEntity.getField(entry.getValue())));
                masterAlias.setChild(new CompiledVar(masterEntity.getField(entry.getKey())));
                CompiledEquals cond0 = new CompiledEquals(detailAlias, masterAlias);

                if (cond == null) {
                    cond = cond0;
                } else {
                    cond = new CompiledAnd(cond, cond0);
                }
            }
            ret.alias = generatedAlias;
            ret.cond = cond;
            if (qs instanceof CompiledSelect) {
                ((CompiledSelect) qs).leftJoin(ret.entity.getName(), ret.alias, ret.cond);
            } else if (qs instanceof CompiledUpdate) {
                ((CompiledUpdate) qs).leftJoin(ret.entity.getName(), ret.alias, ret.cond);
            } else if (qs instanceof CompiledDelete) {
                throw new IllegalUPAArgumentException("Unsupported");
                //((CompiledDelete) qs).leftJoin(ret.entity.getName(), ret.alias, ret.cond);
            } else {
                throw new IllegalUPAArgumentException("Unsupported");
            }
//            qs.getDeclarationList().push(masterAliasString, masterEntity);
        }
        return ret;
    }

    private NamedEntity2 getUsedEntity(CompiledSelect qs, String name) {
        NamedEntity2 selectedEntry = null;
        List<NamedEntity2> usedEntities = getUsedEntities(qs);
        for (NamedEntity2 entry : usedEntities) {
            if (name.equals(entry.alias)) {
                selectedEntry = entry;
                break;
            }
        }
        if (selectedEntry == null) {
            for (NamedEntity2 entry : usedEntities) {
                if (name.equals(entry.entity.getName())) {
                    selectedEntry = entry;
                    break;
                }
            }
        }
        if (selectedEntry == null) {
            throw new IllegalUPAArgumentException("Unknown alias " + name);
        }
        return selectedEntry;
    }

    private List<NamedEntity2> getUsedEntities(CompiledSelect qs) {
        List<NamedEntity2> found = new ArrayList<NamedEntity2>();
        if (qs.getEntity() instanceof CompiledEntityName) {
            CompiledEntityName en = (CompiledEntityName) qs.getEntity();
            Entity _entity = persistenceUnit.getEntity(en.getName());
            found.add(new NamedEntity2(qs.getEntityAlias(), _entity));
        }
        for (CompiledJoinCriteria c : qs.getJoins()) {
            CompiledNameOrSelect e = c.getEntity();
            if (e instanceof CompiledEntityName) {
                CompiledEntityName en = (CompiledEntityName) e;
                Entity _entity = persistenceUnit.getEntity(en.getName());
                found.add(new NamedEntity2(c.getEntityAlias(), _entity));
            }
        }
        return found;
    }

    private ExpressionDeclaration getDeclaration(String name, CompiledExpressionExt expression) {
        ExpressionDeclaration declaration = expression.getDeclaration(name);
        if (declaration != null) {
            return declaration;
        }
        Map<String, String> m = config.getAliasToEntityContext();
        String t = m.get(name);
        if (t != null) {
            return new ExpressionDeclaration(name, DecObjectType.ENTITY, t, null);
        }
        return null;
    }

    private List<ExpressionDeclaration> getDeclarations(String name, CompiledExpressionExt expression) {
        List<ExpressionDeclaration> declarations = expression.getDeclarations(name);
        if (declarations != null && declarations.size() > 0) {
            return declarations;
        }
        Map<String, String> m = config.getAliasToEntityContext();
        String t = m.get(name);
        if (t != null) {
            ExpressionDeclaration d = new ExpressionDeclaration(name, DecObjectType.ENTITY, t, null);
            declarations = new ArrayList<ExpressionDeclaration>(1);
            declarations.add(d);
            return declarations;
        }
        return PlatformUtils.emptyList();
    }

    private DataTypeTransform getValidDataType(CompiledExpressionExt a) {
        DataTypeTransform d = a.getEffectiveDataType();
        if (d == null) {
            return null;
        }
        if (d.getTargetType().getClass().equals(SerializableType.class) && d.getTargetType().getPlatformType().equals(Object.class)) {
            return null;
        }
        return d;
    }

    private String createBindingID(CompiledVar rv) {
        StringBuilder s = new StringBuilder();
        CompiledVarOrMethod t = rv;
        while (t != null) {
            if (s.length() > 0) {
                s.insert(0, ".");
            }
            s.insert(0, ExpressionHelper.escapeIdentifier(t.getName()));
            CompiledExpressionExt pe = t.getParentExpression();
            if (pe instanceof CompiledVarOrMethod) {
                t = (CompiledVarOrMethod) pe;
            } else {
                t = null;
            }
        }
        return s.toString();
    }

    public Object resolveReferrer(CompiledVar var) {
        Object referrer = var.getReferrer();
        if (referrer == null) {
            referrer = resolveReferrer0(var);
        }
        return referrer;
    }

    private Object resolveReferrer0(CompiledVar var) {
        Object referrer = var.getReferrer();
        if (referrer == null) {
            //String entityBaseName,
            CompiledVar p = (var.getParentExpression() instanceof CompiledVar) ? ((CompiledVar) var.getParentExpression()) : null;
            if (p == null) {
                final String thisAlias = config.getThisAlias();
                if (UPQLUtils.THIS.equals(var.getName())) {
                    if (thisAlias != null) {
                        var.setName(thisAlias);
                    } else {
//                    throw new IllegalUPAArgumentException("Incountered this alias but never declared");
                    }
                    ExpressionDeclaration declaration = getDeclaration(var.getName(), var);
                    if (declaration != null) {
                        switch (declaration.getReferrerType()) {
                            case ENTITY: {
                                var.setReferrer(persistenceUnit.getEntity((String) declaration.getReferrerName()));
                                return var.getReferrer();
                            }
                        }
                    }
                    throw new IllegalUPAArgumentException("'this' alias is not declared");
                }
                //check if field
                List<ExpressionDeclaration> values = getDeclarations(null, var);
                if (values != null) {
                    for (ExpressionDeclaration ref : values) {
                        switch (ref.getReferrerType()) {
                            case ENTITY: {
                                Entity ee = persistenceUnit.getEntity((String) ref.getReferrerName());
                                if (var.getName().equals(ref.getName())) {
                                    var.setReferrer(ee);
                                } else if (ee.containsField(var.getName())) {
                                    if (var.getParentExpression() instanceof CompiledVarVal) {
                                        //need no alias
                                        var.setReferrer(ee.getField(var.getName()));
                                        return var.getReferrer();
                                    } else {
                                        if (ref.getName() == null) {
                                            var.setReferrer(ee.getField(var.getName()));
                                            return var.getReferrer();
                                        } else {
                                            var.setImplicitDeclaration(ref);
                                            var.setReferrer(ee.getField(var.getName()));
                                            return var.getReferrer();
//                                            CompiledVar v2 = new CompiledVar(var.getName());
//                                            v2.setName(ref.getValidName());
//                                            v2.setReferrer(ee);
//                                            CompiledExpressionExt parentExpression = var.getParentExpression();
//                                            UPQLCompiledUtils.replaceRef(parentExpression, var, v2);
//                                            var.unsetParent();
//                                            var.setReferrer(ee.getField(var.getName()));
//                                            v2.setChild(var);
//                                            return v2.getReferrer();
                                        }
                                    }
                                }
                                break;
                            }
                        }
                    }
                }
                //check if alias
                values = getDeclarations(var.getName(), var);
                if (values != null) {
                    for (ExpressionDeclaration ref : values) {
                        switch (ref.getReferrerType()) {
                            case ENTITY: {
                                var.setReferrer(persistenceUnit.getEntity((String) ref.getReferrerName()));
                                return var.getReferrer();
                            }
                            case FIELD: {
                                Entity ee = persistenceUnit.getEntity((String) ref.getReferrerParent());
                                var.setReferrer(ee.getField(var.getName()));
                                return var.getReferrer();
                            }
                        }
                        throw new IllegalUPAArgumentException("Problem");
                    }
                }
                //check if entity
                if (persistenceUnit.containsEntity(var.getName())) {
                    var.setReferrer(persistenceUnit.getEntity(var.getName()));
                    return var.getReferrer();
                }
                if ("*".equals(var.getName())) {
                    return var.getReferrer();
                }
                if (thisAlias != null) {
                    UPQLCompiledUtils.replaceRef(var.getParentExpression(), var, new CompiledVar(thisAlias), null);
                    //check if field
                    List<ExpressionDeclaration> values2 = getDeclarations(thisAlias, var);
                    if (values2 != null) {
                        for (ExpressionDeclaration ref : values2) {
                            switch (ref.getReferrerType()) {
                                case ENTITY: {
                                    Entity ee = persistenceUnit.getEntity((String) ref.getReferrerName());
                                    if (ee.containsField(var.getName())) {
                                        var.setReferrer(ee.getField(var.getName()));
                                        return var.getReferrer();
                                    }
                                }
                            }
                        }
                    }
                }
                //TODO remove me
//            validateCompiledVar(v, config);
                throw new net.vpc.upa.exceptions.NoSuchFieldException(null, var.toString(), var.getName());
            } else {
                String before = p.toString();
                /*p =*/
                resolveReferrer(p);
                Object ref = p.getReferrer();
                if (ref instanceof Entity) {
                    Entity ee = (Entity) ref;
                    if (ee.containsField(var.getName())) {
                        var.setReferrer(ee.getField(var.getName()));
                        return var.getReferrer();
                    } else if ("*".equals(var.getName())) {
                        return null;
                    }
                    throw new net.vpc.upa.exceptions.NoSuchFieldException(ee.getName(), var.toString(), var.getName());
                } else if (ref instanceof Field) {
                    Relationship manyToOneRelationship = ((Field) ref).getManyToOneRelationship();
                    if (manyToOneRelationship != null) {
                        Entity ee = manyToOneRelationship.getTargetRole().getEntity();
                        if (ee.containsField(var.getName())) {
                            var.setReferrer(ee.getField(var.getName()));
                            return var.getReferrer();
                        } else if ("*".equals(var.getName())) {
                            return null;
                        }
                    } else {
                        log.severe("Type Cast Exception " + ((Field) ref).getAbsoluteName() + " is not of type " + ManyToOneType.class.getName() + " but " + ((Field) ref).getDataType());
                        throw new net.vpc.upa.exceptions.NoSuchFieldException(null, var.toString(), var.getName());
                    }
                }
                throw new net.vpc.upa.exceptions.NoSuchFieldException(null, var.toString(), var.getName());
            }
//        return defaultReferrer;

        }
        return var.getReferrer();
    }

    protected Object evalQLFunction(CompiledExpressionExt o) {
        if (o == null) {
            return null;
        }
        if (o instanceof CompiledQLFunctionExpression) {
            CompiledQLFunctionExpression s = (CompiledQLFunctionExpression) o;
            int argumentsCount = s.getArgumentsCount();
            Object[] args = new Object[argumentsCount];
            for (int i = 0; i < args.length; i++) {
                args[i] = evalQLFunction(s.getArgument(i));
            }
            return (s.getHandler().eval(new FunctionEvalContext(s.getName(), args, persistenceUnit, this)));
        }
        if (o instanceof CompiledLiteral) {
            return ((CompiledLiteral) o).getValue();
        }
        if (o instanceof CompiledParam) {
            return ((CompiledParam) o).getValue();
        }
        return o;
    }

    public ReplaceResult updateCompiledQLFunctionExpression(CompiledQLFunctionExpression o, Map<String, Object> updateContext) {
        int argumentsCount = o.getArgumentsCount();
        Object[] args = new Object[argumentsCount];
        for (int i = 0; i < args.length; i++) {
            args[i] = evalQLFunction(o.getArgument(i));
        }
        Object v = o.getHandler().eval(new FunctionEvalContext(o.getName(), args, persistenceUnit, this));
        if (v != null) {
            if (v instanceof CompiledExpression) {
                return ReplaceResult.continueWithNewDirtyObj((CompiledExpressionExt) v);
            }
            if (v instanceof Expression) {
                throw new IllegalUPAArgumentException("Function should return literals of compiled expressions (CompiledExpression type)");
            }
            return ReplaceResult.continueWithNewCleanObj(new CompiledParam(v, null, o.getTypeTransform(), false));
        } else {
            return ReplaceResult.continueWithNewCleanObj(new CompiledLiteral(null, null));
        }
    }

    private void expandEntityFilters(CompiledSelect compiledSelect, Map<String, Object> updateContext) {
        CompiledNameOrSelect nameOrSelect = compiledSelect.getEntity();
        if (nameOrSelect instanceof CompiledEntityName) {
            String entityName = ((CompiledEntityName) nameOrSelect).getName();
            final Entity entity = persistenceUnit.getEntity(entityName);
            for (String filterName : entity.getFilterNames()) {
                Expression filter = entity.getFilter(filterName);
                ExpressionCompilerConfig conf2 = new ExpressionCompilerConfig();
                String name = compiledSelect.getEntityAlias();
                if (name == null) {
                    name = entityName;
                }
                conf2.setTranslateOnly();
                conf2.bindAliasToEntity(name, entityName);
                conf2.setThisAlias(name);
                CompiledExpressionExt compiledFilter = (CompiledExpressionExt) expressionManager.compileExpression(filter, conf2);
                if (compiledFilter != null) {
                    compiledFilter.getClientParameters().setString("UPA.EntityFilter", entity.getName() + ":" + filterName);
                }
                compiledSelect.addWhere(compiledFilter);
            }
            Expression securityFilter = persistenceUnit.getSecurityManager().getEntityFilter(entity);
            if (securityFilter != null) {
                ExpressionCompilerConfig conf2 = new ExpressionCompilerConfig();
                String name = compiledSelect.getEntityAlias();
                if (name == null) {
                    name = entityName;
                }
                conf2.bindAliasToEntity(name, entityName);
                conf2.setTranslateOnly();
                conf2.setThisAlias(name);
                CompiledExpressionExt compiledFilter = (CompiledExpressionExt) expressionManager.compileExpression(securityFilter, conf2);
                compiledFilter = UPQLCompiledUtils.replaceThisVar(compiledFilter, name, updateContext).getExpression(compiledFilter);

                if (compiledFilter != null) {
                    compiledFilter.getClientParameters().setString("UPA.EntityFilter", entity.getName() + ":(SecurityManager)");
                }

                compiledSelect.addWhere(compiledFilter);
            }
        }
        for (CompiledJoinCriteria join : compiledSelect.getJoins()) {
            switch (join.getJoinType()) {
                case LEFT_JOIN:
                case RIGHT_JOIN:
                case FULL_JOIN:
                case INNER_JOIN: {
                    nameOrSelect = join.getEntity();
                    String entityName = ((CompiledEntityName) nameOrSelect).getName();
                    final Entity entity = persistenceUnit.getEntity(entityName);
                    for (String filterName : entity.getFilterNames()) {
                        Expression filter = entity.getFilter(filterName);
                        ExpressionCompilerConfig conf2 = new ExpressionCompilerConfig();
                        String name = join.getEntityAlias();
                        if (name == null) {
                            name = entityName;
                        }
                        conf2.bindAliasToEntity(name, entityName);
                        conf2.setTranslateOnly();
                        conf2.setThisAlias(name);
                        CompiledExpressionExt compiledFilter = (CompiledExpressionExt) expressionManager.compileExpression(filter, conf2);
                        if (compiledFilter != null) {
                            compiledFilter.getClientParameters().setString("UPA.EntityFilter", entity.getName() + ":" + filterName);
                        }
                        join.addCondition(compiledFilter);
                    }
                    break;
                }
                case CROSS_JOIN: {
                    nameOrSelect = join.getEntity();
                    String entityName = ((CompiledEntityName) nameOrSelect).getName();
                    final Entity entity = persistenceUnit.getEntity(entityName);
                    for (String filterName : entity.getFilterNames()) {
                        Expression filter = entity.getFilter(filterName);
                        ExpressionCompilerConfig conf2 = new ExpressionCompilerConfig();
                        String name = join.getEntityAlias();
                        if (name == null) {
                            name = entityName;
                        }
                        conf2.bindAliasToEntity(name, entityName);
                        conf2.setTranslateOnly();
                        conf2.setThisAlias(name);
                        CompiledExpressionExt compiledFilter = (CompiledExpressionExt) expressionManager.compileExpression(filter, conf2);
                        if (compiledFilter != null) {
                            compiledFilter.getClientParameters().setString("UPA.EntityFilter", entity.getName() + ":" + filterName);
                        }
                        compiledSelect.addWhere(compiledFilter);
                    }
                    break;
                }
            }
        }
    }

    private static class ExprContext {
        private Map<String, String> upaBindingAliases = new HashMap<String, String>();
        private int upaBindingAliasIndex = 0;

        public static ExprContext get(CompiledEntityStatement s) {
            ExprContext c = s.getClientParameters().getObject("ExprContext");
            if (c == null) {
                c = new ExprContext();
                s.getClientParameters().setObject("ExprContext", c);
            }
            return c;
        }

        private String getAliasFor(BindingId binding) {
            String sbinding = (binding == null ? "" : binding.toString());
            return upaBindingAliases.get(sbinding.toLowerCase());
        }

        private String createAliasFor(BindingId binding) {
            upaBindingAliasIndex++;
            String generatedAlias = "upa" + upaBindingAliasIndex;
            String sbinding = (binding == null ? "" : binding.toString());
            upaBindingAliases.put(sbinding, generatedAlias);
            return generatedAlias;
        }

    }

}
