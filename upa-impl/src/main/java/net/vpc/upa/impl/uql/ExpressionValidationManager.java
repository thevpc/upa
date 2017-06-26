/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql;

import net.vpc.upa.*;
import net.vpc.upa.expressions.BinaryOperator;
import net.vpc.upa.expressions.CompiledExpression;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.ExpressionHelper;
import net.vpc.upa.filters.FieldFilter;
import net.vpc.upa.filters.FieldFilters;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.impl.uql.compiledexpression.*;
import net.vpc.upa.impl.uql.compiledfilteredreplacers.LifeFieldCompiledExpressionFilter;
import net.vpc.upa.impl.uql.compiledfilters.CompiledExpressionUtils;
import net.vpc.upa.impl.uql.compiledfilters.RefEqualCompiledExpressionFilter;
import net.vpc.upa.impl.uql.compiledreplacer.CompiledExpressionReplacerTemp;
import net.vpc.upa.impl.uql.compiledreplacer.CompiledQLFunctionExpressionSimplifier;
import net.vpc.upa.impl.uql.compiledfilteredreplacers.IsHierarchyDescendantReplacer;
import net.vpc.upa.impl.uql.compiledreplacer.ValueCompiledExpressionReplacer;
import net.vpc.upa.impl.uql.util.UQLUtils;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.impl.util.StringUtils;
import net.vpc.upa.impl.util.UPAUtils;
import net.vpc.upa.impl.util.filters.Fields2;
import net.vpc.upa.persistence.ExpressionCompilerConfig;
import net.vpc.upa.types.DataType;
import net.vpc.upa.types.DataTypeTransform;
import net.vpc.upa.types.ManyToOneType;
import net.vpc.upa.types.SerializableType;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class ExpressionValidationManager {

    private static Logger log = Logger.getLogger(ExpressionValidationManager.class.getName());
    private PersistenceUnit persistenceUnit;

    public ExpressionValidationManager(PersistenceUnit persistenceUnit) {
        this.persistenceUnit = persistenceUnit;
    }

    public CompiledExpression validateExpression(CompiledExpression expression, ExpressionCompilerConfig config) {
        log.log(Level.FINEST, "Validate Compiled Expression {0}\n\t using config {1}", new Object[]{expression, config});
        DefaultCompiledExpression dce = (DefaultCompiledExpression) expression;
        //dce.copy()
        String entityBaseName = null;
        String entityAlias = null;
        if (dce instanceof CompiledEntityStatement) {
            entityBaseName = ((CompiledEntityStatement) dce).getEntityName();
            entityAlias = ((CompiledEntityStatement) dce).getEntityAlias();
        }
        //add missing aliases, to fix problem occurring when entity table has different names in stoe

        List<CompiledSelect> allSelects = dce.findExpressionsList(CompiledExpressionUtils.SELECT_FILTER);
        //List<CompiledExpression> recurse = new ArrayList<CompiledExpression>();
        for (CompiledSelect compiledSelect : allSelects) {
            if (config.isExpandEntityFilter()) {
                expandEntityFilters(compiledSelect, config);
            }
        }
        dce.replaceExpressions(CompiledExpressionUtils.ALIAS_ENFORCER);

        for (CompiledVar compiledVar : CompiledExpressionUtils.findChildrenLeafVars(dce)) {
//            validateCompiledVar(compiledVar, config);
            validateCompiledVarReferrer(compiledVar, entityBaseName, config);
        }
        dce.replaceExpressions(new CompiledQLFunctionExpressionSimplifier(persistenceUnit));
        dce.replaceExpressions(new IsHierarchyDescendantReplacer(persistenceUnit));
        dce.replaceExpressions(new LifeFieldCompiledExpressionFilter(persistenceUnit));
        for (CompiledVar compiledVar : CompiledExpressionUtils.findChildrenLeafVars(dce)) {
//            validateCompiledVar(compiledVar, config);
            validateCompiledVarReferrer(compiledVar, entityBaseName, config);
        }
        if(config.isExpandFields()) {
            //vars may have changed
            for (CompiledVar compiledVar : CompiledExpressionUtils.findChildrenLeafVars(dce)) {
//            validateCompiledVar(compiledVar, config);
                validateCompiledVarRelation(compiledVar, config);
            }
        }
//        if (config.getThisAlias() == null || UQLUtils.THIS.equals(config.getThisAlias()) && entityAlias == null && CompiledExpressionUtils.findThisVar(expression) != null) {
//            if (expression instanceof CompiledSelect) {
//                ((CompiledSelect) expression).setEntityAlias(UQLUtils.THIS);
//            } else if (expression instanceof CompiledDelete) {
//                ((CompiledDelete) expression).setEntityAlias(UQLUtils.THIS);
//            } else if (expression instanceof CompiledUpdate) {
//                ((CompiledUpdate) expression).setEntityAlias(UQLUtils.THIS);
//            }
//        }
        if (expression instanceof CompiledInsert) {
            CompiledInsert ci = (CompiledInsert) expression;
            for (int i = 0; i < ci.countFields(); i++) {
                CompiledVar fvar = ci.getField(i);
                DefaultCompiledExpression vv = ci.getFieldValue(i);

//                if (!(fvar.getReferrer() instanceof Field)) {
//                    System.out.println("How come");
//                }
                Field f = (Field) fvar.getReferrer();
                if (config.isValidate()) {
                    if (f == null) {
                        throw new IllegalArgumentException("Field not found " + fvar + " in " + ci.getEntity().getName());
                    }
                    if (vv.getTypeTransform() == null || vv.getTypeTransform().getTargetType().getPlatformType().equals(Object.class)) {
                        vv.setTypeTransform(UPAUtils.getTypeTransformOrIdentity(f));
                    } else {
                        //ignore
                    }
                }
            }
        } else if (expression instanceof CompiledUpdate) {
            CompiledUpdate ci = (CompiledUpdate) expression;
            for (int i = 0; i < ci.countFields(); i++) {
                CompiledVar fvar = ci.getField(i);
                DefaultCompiledExpression vv = ci.getFieldValue(i);

                Field f = (Field) fvar.getReferrer();
                if (config.isValidate()) {
                    if (f == null) {
                        throw new IllegalArgumentException("Field not found " + fvar + " in " + ci.getEntity().getName());
                    }
                    if (vv.getTypeTransform() == null || vv.getTypeTransform().getTargetType().getPlatformType().equals(Object.class)) {
                        vv.setTypeTransform(UPAUtils.getTypeTransformOrIdentity(f));
                    } else {
                        //ignore
                    }
                }
                if (fvar.getChild() != null) {
                    if (!(fvar.getChild() instanceof CompiledVar)) {
                        throw new IllegalArgumentException();
                    }
                    if (fvar.getChild().getChild() != null) {
                        throw new IllegalArgumentException();
                    }
                }
            }
        }

        allSelects = dce.findExpressionsList(CompiledExpressionUtils.SELECT_FILTER);
        //List<CompiledExpression> recurse = new ArrayList<CompiledExpression>();
        for (CompiledSelect compiledSelect : allSelects) {
            if (config.isExpandFields()) {
                expandFields(compiledSelect, config);
                if (config.isValidate()) {
                    if (compiledSelect.countFields() == 0) {
                        throw new IllegalArgumentException("Empty Field List in " + compiledSelect);
                    }
                }
            }
        }

//        dce.replaceExpressions(CompiledExpressionUtils.QL_FUNCTION_FILTER, new CompiledQLFunctionExpressionSimplifier(persistenceUnit));
//        dce.replaceExpressions(CompiledExpressionUtils.DESCENDANT_FILTER, new IsHierarchyDescendantReplacer(persistenceUnit));

        List<CompiledParam> allParams = dce.findExpressionsList(CompiledExpressionUtils.PARAM_FILTER);
        for (CompiledParam p : allParams) {
            validateCompiledParam(p, config);
        }
        String newName = entityAlias;//entityAlias != null ? entityAlias : entityBaseName;
        if (!UQLUtils.THIS.equals(config.getThisAlias())) {
            newName = config.getThisAlias();
        }
        if (newName != null) {
            CompiledExpressionUtils.replaceThisVar(dce, newName);
        }else{
            CompiledExpressionUtils.removeThisVar(dce);
        }
        return dce;
    }

    private void expandEntityFilters(CompiledSelect compiledSelect, ExpressionCompilerConfig config) {
        CompiledNameOrSelect nameOrSelect = compiledSelect.getEntity();
        if (nameOrSelect instanceof CompiledEntityName) {
            String entityName = ((CompiledEntityName) nameOrSelect).getName();
            final Entity re = persistenceUnit.getEntity(entityName);
            for (String filterName : re.getFilterNames()) {
                Expression filter = re.getFilter(filterName);
                ExpressionCompilerConfig conf2 = new ExpressionCompilerConfig();
                String name = compiledSelect.getEntityAlias();
                if (name == null) {
                    name = entityName;
                }
                conf2.bindAliastoEntity(name, entityName);
                conf2.setValidate(true);
                conf2.setThisAlias(name);
                DefaultCompiledExpression compiledFilter = (DefaultCompiledExpression) persistenceUnit.getExpressionManager().compileExpression(filter, conf2);
//                                    compiledFilter.getClientParameters().setBoolean("UPA.EntityFilter:", true);
//                                    DefaultCompiledExpression oldCond = compiledSelect.getCondition();
//                                    List<DefaultCompiledExpression> found = oldCond == null ? null : oldCond.findExpressionsList(new CompiledExpressionFilter() {
//                                        public boolean accept(DefaultCompiledExpression e) {
//                                            return e.getClientParameters().getBoolean("UPA.EntityFilter", false);
//                                        }
//                                    });
                compiledSelect.addWhere(compiledFilter);
            }
            Expression f2 = persistenceUnit.getSecurityManager().getEntityFilter(re);
            if (f2 != null) {
                ExpressionCompilerConfig conf2 = new ExpressionCompilerConfig();
                String name = compiledSelect.getEntityAlias();
                if (name == null) {
                    name = entityName;
                }
                conf2.bindAliastoEntity(name, entityName);
                conf2.setValidate(false);
                conf2.setThisAlias(name);
                conf2.setExpandFields(false);
                conf2.setExpandEntityFilter(false);
                //just to help compileExpressionTo Work as it needs to upderstands where fields are from!
//                Select s=new Select().field("1").from(entityName,name).where(f2);

                DefaultCompiledExpression compiledFilter = (DefaultCompiledExpression) persistenceUnit.getExpressionManager().compileExpression(f2, conf2);
                compiledFilter = CompiledExpressionUtils.replaceThisVar(compiledFilter, name);
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
                    final Entity re = persistenceUnit.getEntity(entityName);
                    for (String filterName : re.getFilterNames()) {
                        Expression filter = re.getFilter(filterName);
                        ExpressionCompilerConfig conf2 = new ExpressionCompilerConfig();
                        String name = join.getEntityAlias();
                        if (name == null) {
                            name = entityName;
                        }
                        conf2.bindAliastoEntity(name, entityName);
                        conf2.setValidate(true);
                        conf2.setThisAlias(name);
                        DefaultCompiledExpression compiledFilter = (DefaultCompiledExpression) persistenceUnit.getExpressionManager().compileExpression(filter, conf2);
//                                    compiledFilter.getClientParameters().setBoolean("UPA.EntityFilter:", true);
//                                    DefaultCompiledExpression oldCond = compiledSelect.getCondition();
//                                    List<DefaultCompiledExpression> found = oldCond == null ? null : oldCond.findExpressionsList(new CompiledExpressionFilter() {
//                                        public boolean accept(DefaultCompiledExpression e) {
//                                            return e.getClientParameters().getBoolean("UPA.EntityFilter", false);
//                                        }
//                                    });
                        join.addCondition(compiledFilter);
                    }
                    break;
                }
                case CROSS_JOIN: {
                    nameOrSelect = join.getEntity();
                    String entityName = ((CompiledEntityName) nameOrSelect).getName();
                    final Entity re = persistenceUnit.getEntity(entityName);
                    for (String filterName : re.getFilterNames()) {
                        Expression filter = re.getFilter(filterName);
                        ExpressionCompilerConfig conf2 = new ExpressionCompilerConfig();
                        String name = join.getEntityAlias();
                        if (name == null) {
                            name = entityName;
                        }
                        conf2.bindAliastoEntity(name, entityName);
                        conf2.setValidate(true);
                        conf2.setThisAlias(name);
                        DefaultCompiledExpression compiledFilter = (DefaultCompiledExpression) persistenceUnit.getExpressionManager().compileExpression(filter, conf2);
//                                    compiledFilter.getClientParameters().setBoolean("UPA.EntityFilter:", true);
//                                    DefaultCompiledExpression oldCond = compiledSelect.getCondition();
//                                    List<DefaultCompiledExpression> found = oldCond == null ? null : oldCond.findExpressionsList(new CompiledExpressionFilter() {
//                                        public boolean accept(DefaultCompiledExpression e) {
//                                            return e.getClientParameters().getBoolean("UPA.EntityFilter", false);
//                                        }
//                                    });
                        compiledSelect.addWhere(compiledFilter);
                    }
                    break;
                }
            }
        }
    }

    private void expandField(CompiledSelect qs, CompiledQueryField f,ExpansionVisitTracker visitedEntities,ExpressionCompilerConfig config) {
        DefaultCompiledExpression fe = f.getExpression();
        String fieldAlias = f.getAlias();
        int fieldIndex = f.getIndex();
        if (fe instanceof CompiledVar) {
            CompiledVar cv = (CompiledVar) fe;
            Object referrer = cv.getReferrer();
            if ("*".equals(cv.getName())) {
                List<NamedEntity2> usedEntities = getUsedEntities(qs);
                for (NamedEntity2 entry : usedEntities) {
                    String alias = entry.alias == null ? entry.entity.getName() : entry.alias;
                    expandEntityFields(qs, fieldIndex, entry.entity, alias, alias, fieldAlias, visitedEntities, config);
                }
            } else if (referrer instanceof Entity) {
                NamedEntity2 selectedEntry = null;
                List<NamedEntity2> usedEntities = getUsedEntities(qs);
                for (NamedEntity2 entry : usedEntities) {
                    if (cv.getName().equals(entry.alias)) {
                        selectedEntry = entry;
                        break;
                    }
                }
                if (selectedEntry == null) {
                    for (NamedEntity2 entry : usedEntities) {
                        if (cv.getName().equals(entry.entity.getName())) {
                            selectedEntry = entry;
                            break;
                        }
                    }
                }
                if (selectedEntry == null) {
                    throw new IllegalArgumentException("Unknown alias " + cv.getName());
                }
                final Entity _entity = selectedEntry.entity;
                if (cv.getChild() == null || cv.getChild().getName().equals("*")) {
                    String alias = selectedEntry.alias == null ? _entity.getName() : selectedEntry.alias;
                    expandEntityFields(qs, fieldIndex, _entity, alias, alias, alias, visitedEntities, config);
                } else {
                    CompiledVar ff = (CompiledVar) cv.getChild();
                    Field ef = (Field) ff.getReferrer();
                    String entityAlias=null;
                    if (ef.getDataType() instanceof ManyToOneType) {
                        String binding = f.getBinding() == null ? "" : f.getBinding();
                        entityAlias = selectedEntry.alias;
                        expandOnNeedField(qs, fieldIndex, ef, entityAlias, binding, fieldAlias, visitedEntities,config);
                    } else if (ef.getModifiers().contains(FieldModifier.SELECT_LIVE)) {
                        DefaultCompiledExpression pe = cv.getParentExpression();
                        CompiledVar pp = pe instanceof CompiledVar ? ((CompiledVar) pe) : null;
                        entityAlias = pp == null ? null : pp.getName();
                        expandOnNeedField(qs, fieldIndex, ef, entityAlias, null, fieldAlias, visitedEntities,config);
                    } else {
                        qs.addField(f);
                    }
                }
            } else if (referrer instanceof Field) {
                Field ef = (Field) referrer;
                DefaultCompiledExpression pe = cv.getParentExpression();
                CompiledVar pp = pe instanceof CompiledVar ? ((CompiledVar) pe) : null;
                if (!expandOnNeedField(qs, fieldIndex, ef, pp == null ? null : pp.getName(), null, fieldAlias, visitedEntities,config)) {
                    qs.addField(f);
                }
            } else {
                qs.addField(f);
            }
        } else {
            qs.addField(f);
        }
    }
    private void expandFields(CompiledSelect qs, ExpressionCompilerConfig config) {
        int navigationDepth = (Integer) config.getHint(QueryHints.NAVIGATION_DEPTH, -1);
        ExpansionVisitTracker visitedEntities = new ExpansionVisitTracker(navigationDepth);

        if (qs.countFields() == 0) {
            CompiledVar fvar = new CompiledVar("*");//throw unsupported
            qs.field(fvar, null);
        }
        final List<CompiledQueryField> fields = new ArrayList<CompiledQueryField>(qs.getFields());
        qs.removeAllFields();
        for (CompiledQueryField f : fields) {
            expandField(qs, f, visitedEntities,config);

        }

    }

    private boolean expandOnNeedField(CompiledSelect qs, int index, Field field, String entityAlias, String binding, String aliasBinding, ExpansionVisitTracker expansionVisitTracker, ExpressionCompilerConfig config) {
        if (binding !=null && binding.length() == 0) {
            binding = null;
        }
        if (field.getModifiers().contains(FieldModifier.SELECT_LIVE)) {
            Formula f = field.getSelectFormula();
            if (f instanceof CustomFormula) {
                //do nothing, should be processed as custom formula later
            } else if (f instanceof ExpressionFormula) {
                ExpressionFormula ef = (ExpressionFormula) f;
                Expression expr = ef.getExpression();

                ExpressionCompilerConfig cfg = new ExpressionCompilerConfig();
                cfg.setThisAlias(entityAlias);
                cfg.setExpandEntityFilter(false);
                cfg.setExpandFields(false);
                cfg.setValidate(false);
                Map<String, String> aliasToEntityContext = new HashMap<String, String>();
                aliasToEntityContext.put(entityAlias, field.getEntity().getName());
                cfg.setAliasToEntityContext(aliasToEntityContext);
                DefaultCompiledExpression rr = (DefaultCompiledExpression) persistenceUnit.getExpressionManager().compileExpression(expr, cfg);
                if (rr instanceof CompiledVarOrMethod) {
                    ((CompiledVarOrMethod) rr).getFinest().setBaseReferrer(field);
                }

                cfg = new ExpressionCompilerConfig();
                cfg.setThisAlias(entityAlias);
                cfg.setExpandEntityFilter(false);
                cfg.setExpandFields(false);
                cfg.setValidate(true);
                aliasToEntityContext = new HashMap<String, String>();
                aliasToEntityContext.put(entityAlias, field.getEntity().getName());
                cfg.setAliasToEntityContext(aliasToEntityContext);
                persistenceUnit.getExpressionManager().compileExpression(rr, cfg);
//                expandField(qs,new CompiledQueryField(field.getName(),rr,index,false,field.getName(),binding,null),expansionVisitTracker,config);
                expandField(qs,new CompiledQueryField(field.getName(),rr,-1,false,field.getName(),binding,null),expansionVisitTracker,config);
                for (CompiledVar compiledVar : CompiledExpressionUtils.findChildrenLeafVars(qs)) {
//            validateCompiledVar(compiledVar, config);
                    validateCompiledVarRelation(compiledVar, config);
                }
            } else {
                //ignore
            }


            return true;
        } else if (field.getDataType() instanceof ManyToOneType) {
            QueryFetchStrategy fetchStrategy = (QueryFetchStrategy) config.getHint(QueryHints.FETCH_STRATEGY, QueryFetchStrategy.JOIN);
            if (fetchStrategy == null) {
                fetchStrategy = QueryFetchStrategy.JOIN;
            }
            if (QueryFetchStrategy.JOIN == (fetchStrategy)) {
                expandManyToOneFieldJoinFetch(qs, index, field, entityAlias, binding, aliasBinding, config.getExpandFieldFilter(), expansionVisitTracker,config);
            } else if (QueryFetchStrategy.SELECT == (fetchStrategy)) {
                expandManyToOneFieldSelectFetch(qs, index, field, entityAlias, binding, aliasBinding, config.getExpandFieldFilter(), expansionVisitTracker);
            }
            return true;
        }
        return false;
    }

    private void expandEntityFields(CompiledSelect qs, int index, Entity e, String entityAlias, String binding, String aliasBinding, ExpansionVisitTracker visitedEntities, ExpressionCompilerConfig config) {
        for (Field field : e.getFields(FieldFilters.as(config.getExpandFieldFilter()).and(Fields2.READ))) {
            ExpansionVisitTracker c = visitedEntities.copy();
            String aliasBinding1 = UPAUtils.dotConcat(aliasBinding, field.getName());
            if (!expandOnNeedField(qs, index, field, entityAlias, binding,aliasBinding1,c,config)) {
                CompiledVar vv = new CompiledVar(entityAlias, e);
                vv.setChild(new CompiledVar(field));
                qs.addField(vv, field.getName())
                        .setBinding(binding)
                        .setIndex(index)
                        .setExpanded(true)
                        .setAliasBinding(aliasBinding1);
            }
        }

    }

    private void expandManyToOneFieldJoinFetch(CompiledSelect qs, int index, Field field, String entityAlias, String binding, String aliasBinding, FieldFilter fieldFilter, ExpansionVisitTracker visitedEntities, ExpressionCompilerConfig config) {
        if (binding!=null && binding.length() == 0) {
            binding = null;
        }
        ManyToOneType manyToOneType = (ManyToOneType) field.getDataType();
        Relationship rel = manyToOneType.getRelationship();
        Entity masterEntity = rel.getTargetRole().getEntity();
        ExpansionVisitTracker dived = visitedEntities.dive();
        if (dived == null || !dived.nextVisit(masterEntity.getName())) {
            //should add only ids
            List<Field> otherFields = manyToOneType.getRelationship().getSourceRole().getFields();
            for (Field f : otherFields) {
                if (!(f.getDataType() instanceof ManyToOneType)) {
                    CompiledVar vv = new CompiledVar(entityAlias, field.getEntity());
                    vv.setChild(new CompiledVar(f));
                    //binding = (binding == null ? "" : (binding + ".")) + field.getName();
                    qs.addField(vv, f.getName())
                            .setIndex(index)
                            .setExpanded(true)
                            .setBinding(binding);
                }
            }
            return;
        }
        BindingJoinInfo d = addBindingJoin(qs, field, entityAlias,
                (StringUtils.isNullOrEmpty(binding) ? ExpressionHelper.escapeIdentifier(field.getName()) : (binding + "." + ExpressionHelper.escapeIdentifier(field.getName()))),
                (StringUtils.isNullOrEmpty(aliasBinding) ? ExpressionHelper.escapeIdentifier(field.getName()) : (aliasBinding + "." + ExpressionHelper.escapeIdentifier(field.getName())))
        );
        expandEntityFields(qs, index, masterEntity, d.alias, d.binding, aliasBinding, dived,config);
    }

    private void expandManyToOneFieldSelectFetch(CompiledSelect qs, int index, Field field, String entityAlias, String binding, String aliasBinding, FieldFilter fieldFilter, ExpansionVisitTracker visitedEntities) {
        if (binding!=null && binding.length() == 0) {
            binding = null;
        }
        ManyToOneType manyToOneType = (ManyToOneType) field.getDataType();
        Relationship rel = manyToOneType.getRelationship();
        Entity masterEntity = rel.getTargetRole().getEntity();
        ExpansionVisitTracker dived = visitedEntities.dive();
//        if (dived == null || !dived.nextVisit(masterEntity.getName())) {
//            //should add only ids
//            return;
//        }
        List<Field> otherFields = manyToOneType.getRelationship().getSourceRole().getFields();
        for (Field f : otherFields) {
            if (!(f.getDataType() instanceof ManyToOneType)) {
                CompiledVar vv = new CompiledVar(entityAlias, field.getEntity());
                vv.setChild(new CompiledVar(f));
                //binding = (binding == null ? "" : (binding + ".")) + field.getName();
                qs.addField(vv, f.getName())
                        .setIndex(index)
                        .setBinding(binding)
                        .setExpanded(true)
                        .setAliasBinding(aliasBinding);
            }
        }
    }

    private BindingJoinInfo addBindingJoin(CompiledSelect qs, Field field, String entityAlias, String binding, String aliasBinding) {
        BindingJoinInfo ret = new BindingJoinInfo();
        Relationship rel = ((ManyToOneType) field.getDataType()).getRelationship();
        Entity masterEntity = rel.getTargetRole().getEntity();
        Map<String, String> upaBindingAliases = (Map<String, String>) qs.getClientProperty("upaBindingAliases");
        if (upaBindingAliases == null) {
            upaBindingAliases = new HashMap<String, String>();
            qs.setClientProperty("upaBindingAliases", upaBindingAliases);
        }
        binding = (binding == null ? "" : binding);
        String generatedAlias = upaBindingAliases.get(binding.toLowerCase());
        boolean addJoin = generatedAlias == null;
        ret.entity = masterEntity;
        ret.binding = binding;
        if (!addJoin) {
            ret.alias = generatedAlias;
        } else {
            Integer upaBindingAliasIndex = (Integer) qs.getClientProperty("upaBindingAliasIndex");
            if (upaBindingAliasIndex == null) {
                upaBindingAliasIndex = 1;
            }
            generatedAlias = "upa" + upaBindingAliasIndex;
            qs.setClientProperty("upaBindingAliasIndex", upaBindingAliasIndex + 1);
            DefaultCompiledExpression cond = null;
            Entity detailEntity = field.getEntity();
            for (Map.Entry<String, String> entry : rel.getTargetToSourceFieldNamesMap(false).entrySet()) {

                CompiledVar detailAlias = new CompiledVar(entityAlias, detailEntity);
                CompiledVar masterAlias = new CompiledVar(generatedAlias, masterEntity);
                detailAlias.setChild(new CompiledVar(detailEntity.getField(entry.getValue())));
                masterAlias.setChild(new CompiledVar(masterEntity.getField(entry.getKey())));
                CompiledEquals cond0 = new CompiledEquals(detailAlias, masterAlias);

                if (cond == null) {
                    cond = cond0;
                } else {
                    cond = new CompiledAnd(cond, cond0);
                }
            }
            qs.leftJoin(rel.getTargetRole().getEntity().getName(), generatedAlias, cond);
//            qs.getDeclarationList().push(masterAliasString, masterEntity);
            ret.alias = generatedAlias;
            upaBindingAliases.put(binding.toLowerCase(), generatedAlias);
        }
        return ret;
    }
    private BindingJoinInfo addBindingJoin(CompiledUpdate qs, Field field, String entityAlias, String binding, String aliasBinding) {
        BindingJoinInfo ret = new BindingJoinInfo();
        Relationship rel = ((ManyToOneType) field.getDataType()).getRelationship();
        Entity masterEntity = rel.getTargetRole().getEntity();
        Map<String, String> upaBindingAliases = (Map<String, String>) qs.getClientProperty("upaBindingAliases");
        if (upaBindingAliases == null) {
            upaBindingAliases = new HashMap<String, String>();
            qs.setClientProperty("upaBindingAliases", upaBindingAliases);
        }
        binding = (binding == null ? "" : binding);
        String generatedAlias = upaBindingAliases.get(binding.toLowerCase());
        boolean addJoin = generatedAlias == null;
        ret.entity = masterEntity;
        ret.binding = binding;
        if (!addJoin) {
            ret.alias = generatedAlias;
        } else {
            Integer upaBindingAliasIndex = (Integer) qs.getClientProperty("upaBindingAliasIndex");
            if (upaBindingAliasIndex == null) {
                upaBindingAliasIndex = 1;
            }
            generatedAlias = "upa" + upaBindingAliasIndex;
            qs.setClientProperty("upaBindingAliasIndex", upaBindingAliasIndex + 1);
            DefaultCompiledExpression cond = null;
            Entity detailEntity = field.getEntity();
            for (Map.Entry<String, String> entry : rel.getTargetToSourceFieldNamesMap(false).entrySet()) {

                CompiledVar detailAlias = new CompiledVar(entityAlias, detailEntity);
                CompiledVar masterAlias = new CompiledVar(generatedAlias, masterEntity);
                detailAlias.setChild(new CompiledVar(detailEntity.getField(entry.getValue())));
                masterAlias.setChild(new CompiledVar(masterEntity.getField(entry.getKey())));
                CompiledEquals cond0 = new CompiledEquals(detailAlias, masterAlias);

                if (cond == null) {
                    cond = cond0;
                } else {
                    cond = new CompiledAnd(cond, cond0);
                }
            }
            qs.leftJoin(rel.getTargetRole().getEntity().getName(), generatedAlias, cond);
//            qs.getDeclarationList().push(masterAliasString, masterEntity);
            ret.alias = generatedAlias;
            upaBindingAliases.put(binding.toLowerCase(), generatedAlias);
        }
        return ret;
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

    private ExpressionDeclaration getDeclaration(String name, DefaultCompiledExpression expression, ExpressionCompilerConfig config) {
        ExpressionDeclaration declaration = expression.getDeclaration(name);
        if (declaration != null) {
            return declaration;
        }
        Map<String, String> m = config.getAliasToEntityContext();
        if (m != null) {
            String t = m.get(name);
            if (t != null) {
                return new ExpressionDeclaration(name, DecObjectType.ENTITY, t, null);
            }
        }
        return null;
    }

    private List<ExpressionDeclaration> getDeclarations(String name, DefaultCompiledExpression expression, ExpressionCompilerConfig config) {
        List<ExpressionDeclaration> declarations = expression.getDeclarations(name);
        if (declarations != null && declarations.size() > 0) {
            return declarations;
        }
        Map<String, String> m = config.getAliasToEntityContext();
        if (m != null) {
            String t = m.get(name);
            if (t != null) {
                ExpressionDeclaration d = new ExpressionDeclaration(name, DecObjectType.ENTITY, t, null);
                declarations = new ArrayList<ExpressionDeclaration>(1);
                declarations.add(d);
                return declarations;
            }
        }
        return PlatformUtils.emptyList();
    }

    public CompiledParam validateCompiledParam(CompiledParam v, ExpressionCompilerConfig config) {
        DataTypeTransform d = getValidDataType(v);
        if (d != null) {
            return v;
        }
        if (v.getValue() != null) {
            v.setTypeTransform(IdentityDataTypeTransform.forNativeType(v.getValue().getClass()));
            d = getValidDataType(v);
            if (d != null) {
                return v;
            }
        }
        DefaultCompiledExpression pe = v.getParentExpression();
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
                    DefaultCompiledExpression a = c.getLeft();
                    DefaultCompiledExpression b = c.getRight();
                    if (v == a) {
                        DataTypeTransform d2 = getValidDataType(b);
                        if (d2 != null) {
                            v.setTypeTransform(d2);
                            return v;
                        }
                    } else if (v == b) {
                        DataTypeTransform d2 = getValidDataType(a);
                        if (d2 != null) {
                            v.setTypeTransform(d2);
                            return v;
                        }
                    }
                    return v;
                }
                case LIKE: {
                    DefaultCompiledExpression a = c.getLeft();
                    DefaultCompiledExpression b = c.getRight();
                    v.setTypeTransform(IdentityDataTypeTransform.STRING_UNLIMITED);
                    return v;
                }
                case OR:
                case AND: {
                    v.setTypeTransform(IdentityDataTypeTransform.BOOLEAN);
                    return v;
                }
            }
        } else if (pe instanceof CompiledVarVal) {
            CompiledVarVal cvv = (CompiledVarVal) pe;
            if (cvv.getVal() == v) {
                //it should be the case
                v.setTypeTransform(cvv.getVar().getTypeTransform());
                return v;
            }
        }
        return v;
    }

    private DataTypeTransform getValidDataType(DefaultCompiledExpression a) {
        DataTypeTransform d = a.getEffectiveDataType();
        if (d == null) {
            return null;
        }
        if (d.getTargetType().getClass().equals(SerializableType.class) && d.getTargetType().getPlatformType().equals(Object.class)) {
            return null;
        }
        return d;
    }

    //    public CompiledVar validateCompiledVar(CompiledVar v, ExpressionCompilerConfig config) {
//        try {
//            CompiledVar v2 = v;
//            v2 = validateCompiledVarReferrer(v2, config);
//            v2 = validateCompiledVarRelation(v2, config);
//            return v2;
//        } catch (Exception e) {
//            log.log(Level.WARNING, "Unable to validateCompiledVar " + v, e);
//            return v;
//        }
//    }
    public CompiledVar validateCompiledVarRelation(CompiledVar v, ExpressionCompilerConfig config) {
        if (v.getChild() == null && v.getReferrer() instanceof Field) {
            Field f = (Field) v.getReferrer();
            if (f.getDataType() instanceof ManyToOneType) {
                ManyToOneType e = (ManyToOneType) f.getDataType();
                List<Field> fields = e.getRelationship().getSourceRole().getFields();
                if (fields.size() == 1) {
                    if (v instanceof CompiledVar) {
                        CompiledExpression pe = v.getNonVarParent();
                        if (pe != null && pe instanceof CompiledBinaryOperatorExpression) {
                            v.setName(fields.get(0).getName());
                            Object oldReferrer = v.getReferrer();
                            v.setReferrer(fields.get(0));
                            v.setOldReferrer(oldReferrer);
                        }
                    }
                }
            }
        }

        CompiledVar p0 = (v.getParentExpression() instanceof CompiledVar) ? ((CompiledVar) v.getParentExpression()) : null;
        if (p0 != null) {
            validateCompiledVarRelation(p0, config);
        }
        CompiledVar p1 = (v.getParentExpression() instanceof CompiledVar) ? (CompiledVar) v.getParentExpression() : null;
        CompiledVar p2 = p1 == null ? null : ((p1.getParentExpression() instanceof CompiledVar) ? (CompiledVar) p1.getParentExpression() : null);
        if (p1 != null && p2 != null && p1.getReferrer() instanceof Field) {
            CompiledSelect s = CompiledExpressionUtils.findEnclosingSelect(v);
            if (s != null) {
                //this 
                Field f = (Field) p1.getReferrer();
                if (f.getDataType() instanceof ManyToOneType) {
                    CompiledQueryField cqf = CompiledExpressionUtils.findRootCompiledQueryField(p1);
                    BindingJoinInfo alias = addBindingJoin(s, f, ExpressionHelper.escapeIdentifier(p2.getName()), createBindingID(p1), cqf == null ? null : cqf.getAlias());
                    p2.setName(alias.alias);
                    p2.setReferrer(alias.entity);

                    //remove p1, disconnect it form parent and child
                    p2.setChild(null);
                    p1.setParentExpression(null);
                    p1.setChild(null);
                    v.setParentExpression(null);

                    //connect v to p2
                    p2.setChild(v);
                    return v;
                }
                return v;
            }
            CompiledUpdate u = CompiledExpressionUtils.findRootCompiledUpdate(v);
            if (u != null) {
                //this
                Field f = (Field) p1.getReferrer();
                if (f.getDataType() instanceof ManyToOneType) {
                    CompiledQueryField cqf = CompiledExpressionUtils.findRootCompiledQueryField(p1);
                    BindingJoinInfo alias = addBindingJoin(u, f, ExpressionHelper.escapeIdentifier(p2.getName()), createBindingID(p1), cqf == null ? null : cqf.getAlias());
                    p2.setName(alias.alias);
                    p2.setReferrer(alias.entity);

                    //remove p1, disconnect it form parent and child
                    p2.setChild(null);
                    p1.setParentExpression(null);
                    p1.setChild(null);
                    v.setParentExpression(null);

                    //connect v to p2
                    p2.setChild(v);
                    return v;
                }
                return v;
            }
            throw new IllegalArgumentException("No enclosing Select o update found for " + v);
        }
        return v;
    }

    private String createBindingID(CompiledVar rv) {
        StringBuilder s = new StringBuilder();
        CompiledVarOrMethod t = rv;
        while (t != null) {
            if (s.length() > 0) {
                s.insert(0, ".");
            }
            s.insert(0, ExpressionHelper.escapeIdentifier(t.getName()));
            DefaultCompiledExpression pe = t.getParentExpression();
            if (pe instanceof CompiledVarOrMethod) {
                t = (CompiledVarOrMethod) pe;
            } else {
                t = null;
            }
        }
        return s.toString();
    }

    public CompiledVar validateCompiledVarReferrer(CompiledVar v, String entityBaseName, ExpressionCompilerConfig config) {
        CompiledVar p = (v.getParentExpression() instanceof CompiledVar) ? ((CompiledVar) v.getParentExpression()) : null;
        if (p == null) {
            final String thisAlias = config.getThisAlias();
            if (UQLUtils.THIS.equals(v.getName())) {
                if (thisAlias != null) {
                    v.setName(thisAlias);
                } else {
//                    throw new IllegalArgumentException("Incountered this alias but never declared");
                }
                ExpressionDeclaration declaration = getDeclaration(v.getName(), v, config);
                if (declaration != null) {
                    switch (declaration.getReferrerType()) {
                        case ENTITY: {
                            v.setReferrer(persistenceUnit.getEntity((String) declaration.getReferrerName()));
                            return v;
                        }
                    }
                }
                if (UQLUtils.THIS.equals(config.getThisAlias())) {
                    if (entityBaseName == null) {
                        throw new IllegalArgumentException("'this' alias is not declared");
                    }
                    v.setReferrer(persistenceUnit.getEntity(entityBaseName));
                    return v;
                } else {
                    throw new IllegalArgumentException("'this' alias is not declared");
                }
            }
            //check if field
            List<ExpressionDeclaration> values = getDeclarations(null, v, config);
            if (values != null) {
                for (ExpressionDeclaration ref : values) {
                    switch (ref.getReferrerType()) {
                        case ENTITY: {
                            Entity ee = persistenceUnit.getEntity((String) ref.getReferrerName());
                            if (ee.containsField(v.getName())) {
                                if (v.getParentExpression() instanceof CompiledVarVal) {
                                    //need no alias
                                    v.setReferrer(ee.getField(v.getName()));
                                    return v;
                                } else {
//                                    CompiledVar v2 = new CompiledVar(v.getName());
//                                    v2.setReferrer(ee.getField(v.getName()));
//                                    CompiledVarOrMethod c = v.getChild();
//                                    if (c != null) {
//                                        v.setChild(null);
//                                        c.setParentExpression(null);
//                                        v2.setChild(c);
//                                    }
//                                    v.setName(ref.getValidName());
//                                    v.setChild(v2);
//                                    v.setReferrer(ee);
//                                    return v;

                                    CompiledVar v2 = new CompiledVar(v.getName());
                                    v2.setName(ref.getValidName());
                                    v2.setReferrer(ee);
                                    v.getParentExpression().replaceExpressions(new RefEqualCompiledExpressionFilter(v), new ValueCompiledExpressionReplacer(v2));
                                    v.setParentExpression(null);
                                    v.setReferrer(ee.getField(v.getName()));
                                    v2.setChild(v);
                                    return v2;
                                }
                            }
                            break;
                        }
                    }
                }
            }
            //check if alias
            values = getDeclarations(v.getName(), v, config);
            if (values != null) {
                for (ExpressionDeclaration ref : values) {
                    switch (ref.getReferrerType()) {
                        case ENTITY: {
                            v.setReferrer(persistenceUnit.getEntity((String) ref.getReferrerName()));
                            return v;
                        }
                        case FIELD: {
                            Entity ee = persistenceUnit.getEntity((String) ref.getReferrerParent());
                            v.setReferrer(ee.getField(v.getName()));
                            return v;
                        }
                    }
                    throw new IllegalArgumentException("Problem");
                }
            }
            //check if entity
            if (persistenceUnit.containsEntity(v.getName())) {
                v.setReferrer(persistenceUnit.getEntity(v.getName()));
                return v;
            }
            if ("*".equals(v.getName())) {
                return v;
            }
            if (thisAlias != null) {

                CompiledExpressionReplacerTemp compiledExpressionReplacer = new CompiledExpressionReplacerTemp(thisAlias);
                v.getParentExpression().replaceExpressions(new RefEqualCompiledExpressionFilter(v), compiledExpressionReplacer);
//                v = compiledExpressionReplacer.e2;
                //validateCompiledVar(implicitParent, config);

                //check if field
                List<ExpressionDeclaration> values2 = getDeclarations(thisAlias, v, config);
                if (values2 != null) {
                    for (ExpressionDeclaration ref : values2) {
                        switch (ref.getReferrerType()) {
                            case ENTITY: {
                                Entity ee = persistenceUnit.getEntity((String) ref.getReferrerName());
                                if (ee.containsField(v.getName())) {
                                    v.setReferrer(ee.getField(v.getName()));
                                    return v;
                                }
                            }
                        }
                    }
                }
            }
            //TODO remove me
//            validateCompiledVar(v, config);
            throw new net.vpc.upa.exceptions.NoSuchFieldException(null, v.toString(), v.getName(), null);
        } else {
            String before = p.toString();
            /*p =*/
            validateCompiledVarReferrer(p, entityBaseName, config);
            Object ref = p.getReferrer();
            if (ref instanceof Entity) {
                Entity ee = (Entity) ref;
                if (ee.containsField(v.getName())) {
                    v.setReferrer(ee.getField(v.getName()));
                    resolveToAlias(p);
                    return v;
                } else if ("*".equals(v.getName())) {
                    return v;
                }
                throw new net.vpc.upa.exceptions.NoSuchFieldException(null, v.toString(), v.getName(), null);
            } else if (ref instanceof Field) {
                DataType dataType = ((Field) ref).getDataType();
                if (dataType instanceof ManyToOneType) {
                    ManyToOneType et = (ManyToOneType) dataType;
                    Entity ee = et.getRelationship().getTargetRole().getEntity();
                    if (ee.containsField(v.getName())) {
                        v.setReferrer(ee.getField(v.getName()));
                        resolveToAlias(p);
                        return v;
                    } else if ("*".equals(v.getName())) {
                        return v;
                    }
                } else {
                    log.severe("Type Cast Exception " + ((Field) ref).getAbsoluteName() + " is not of type " + ManyToOneType.class.getName() + " but " + dataType);
                    throw new net.vpc.upa.exceptions.NoSuchFieldException(null, v.toString(), v.getName(), null);
                }
            }
            throw new net.vpc.upa.exceptions.NoSuchFieldException(null, v.toString(), v.getName(), null);
        }
//        return defaultReferrer;
    }

    private CompiledVar resolveToAlias(CompiledVar p) {
        return p;
//        if (p.getReferrer() instanceof Field) {
//            Field f = (Field) p.getReferrer();
//            CompiledVar p2 = resolveToAlias((CompiledVar) p.getParentExpression());
//            DefaultCompiledExpression ce = p;
//            CompiledSelect s = null;
//            while (ce != null) {
//                if (ce instanceof CompiledSelect) {
//                    s = (CompiledSelect) ce;
//                    break;
//                }
//                ce = ce.getParentExpression();
//            }
//            if (s != null) {
//                addBindingJoin(s, f, p2.getName(), createBindingID(p));
//                p2.setChild(p.getChild());
//                return p2;
//            }
//            return p;
//        } else {
//            return p;
//        }
    }

}
