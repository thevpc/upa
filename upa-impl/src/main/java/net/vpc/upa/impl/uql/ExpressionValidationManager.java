/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql;

import net.vpc.upa.*;
import net.vpc.upa.impl.uql.compiledreplacer.CompiledQLFunctionExpressionSimplifier;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.logging.Level;
import java.util.logging.Logger;

import net.vpc.upa.FieldModifier;
import net.vpc.upa.expressions.CompiledExpression;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.BinaryOperator;
import net.vpc.upa.filters.FieldFilter;
import net.vpc.upa.filters.Fields;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;

import net.vpc.upa.impl.uql.compiledexpression.CompiledAnd;
import net.vpc.upa.impl.uql.compiledexpression.CompiledBinaryOperatorExpression;
import net.vpc.upa.impl.uql.compiledexpression.CompiledEntityName;
import net.vpc.upa.impl.uql.compiledexpression.CompiledEquals;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;
import net.vpc.upa.impl.uql.compiledexpression.CompiledInsert;
import net.vpc.upa.impl.uql.compiledexpression.CompiledJoinCriteria;
import net.vpc.upa.impl.uql.compiledexpression.CompiledNameOrSelect;
import net.vpc.upa.impl.uql.compiledexpression.CompiledParam;
import net.vpc.upa.impl.uql.compiledexpression.CompiledQueryField;
import net.vpc.upa.impl.uql.compiledexpression.CompiledSelect;
import net.vpc.upa.impl.uql.compiledexpression.CompiledUpdate;
import net.vpc.upa.impl.uql.compiledexpression.CompiledVar;
import net.vpc.upa.impl.uql.compiledexpression.CompiledVarOrMethod;
import net.vpc.upa.impl.uql.compiledexpression.CompiledVarVal;
import net.vpc.upa.impl.uql.compiledreplacer.IsHierarchyDescendentReplacer;
import net.vpc.upa.impl.uql.compiledreplacer.ValueCompiledExpressionReplacer;
import net.vpc.upa.impl.util.Strings;
import net.vpc.upa.impl.util.UPAUtils;
import net.vpc.upa.persistence.ExpressionCompilerConfig;
import net.vpc.upa.types.DataType;
import net.vpc.upa.types.DataTypeTransform;
import net.vpc.upa.types.EntityType;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class ExpressionValidationManager {

    private static Logger log = Logger.getLogger(ExpressionValidationManager.class.getName());
    private PersistenceUnit persistenceUnit;
    private static final FieldFilter READABLE = Fields.regular().and(
            Fields.byModifiersAnyOf(FieldModifier.SELECT_DEFAULT,
                    FieldModifier.SELECT_COMPILED,
                    FieldModifier.SELECT_LIVE)).andNot(Fields.byAllAccessLevel(AccessLevel.PRIVATE));

    public ExpressionValidationManager(PersistenceUnit persistenceUnit) {
        this.persistenceUnit = persistenceUnit;
    }

    public void validateExpression(CompiledExpression qe, ExpressionCompilerConfig config) {
        log.log(Level.FINEST, "Validate Compiled Expression {0}\n\t using config {1}", new Object[]{qe, config});
        DefaultCompiledExpression dce = (DefaultCompiledExpression) qe;

        List<CompiledSelect> allSelects = dce.findExpressionsList(CompiledExpressionHelper.SELECT_FILTER);
        //List<CompiledExpression> recurse = new ArrayList<CompiledExpression>();
        for (CompiledSelect compiledSelect : allSelects) {
            if (config.isExpandEntityFilter()) {
                expandEntityFilters(compiledSelect, config);
            }
        }

        for (CompiledVar compiledVar : CompiledExpressionHelper.findChildrenLeafVars(dce)) {
//            validateCompiledVar(compiledVar, config);
            validateCompiledVarReferrer(compiledVar, config);
        }
        //vars may have changed
        for (CompiledVar compiledVar : CompiledExpressionHelper.findChildrenLeafVars(dce)) {
//            validateCompiledVar(compiledVar, config);
            validateCompiledVarRelation(compiledVar, config);
        }

        if (qe instanceof CompiledInsert) {
            CompiledInsert ci = (CompiledInsert) qe;
            for (int i = 0; i < ci.countFields(); i++) {
                CompiledVar fvar = ci.getField(i);
                DefaultCompiledExpression vv = ci.getFieldValue(i);

                if (!(fvar.getReferrer() instanceof Field)) {
                    System.out.println("How come");
                }
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
        }
        if (qe instanceof CompiledUpdate) {
            CompiledUpdate ci = (CompiledUpdate) qe;
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

        allSelects = dce.findExpressionsList(CompiledExpressionHelper.SELECT_FILTER);
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

        dce.replaceExpressions(CompiledExpressionHelper.QL_FUNCTION_FILTER, new CompiledQLFunctionExpressionSimplifier(persistenceUnit));
        dce.replaceExpressions(CompiledExpressionHelper.DESCENDENT_FILTER, new IsHierarchyDescendentReplacer(persistenceUnit));

        List<CompiledParam> allParams = dce.findExpressionsList(CompiledExpressionHelper.PARAM_FILTER);
        for (CompiledParam p : allParams) {
            validateCompiledParam(p, config);
        }
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
                compiledFilter = compiledFilter.replaceExpressions(CompiledExpressionHelper.THIS_VAR_FILTER, new CompiledExpressionThisReplacer(name));
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

    private void expandFields(CompiledSelect qs, ExpressionCompilerConfig config) {
        Map<String, Object> hints = config.getHints();
        int navigationDepth = -1;
        if (hints != null && hints.containsKey("navigationDepth")) {
            navigationDepth = (Integer) hints.get("navigationDepth");
        }
        ExpansionVisitTracker visitedEntities = new ExpansionVisitTracker(navigationDepth);

        if (qs.countFields() == 0) {
            CompiledVar fvar = new CompiledVar("*");
            qs.field(fvar, null);
        }
        final List<CompiledQueryField> fields = new ArrayList<CompiledQueryField>(qs.getFields());
        qs.removeAllFields();
        List<NamedEntity2> usedEntities = getUsedEntities(qs);
        for (CompiledQueryField f : fields) {
            DefaultCompiledExpression fe = f.getExpression();
//            boolean indexChanged = false;
            if (fe instanceof CompiledVar) {
                CompiledVar cv = (CompiledVar) fe;
                Object referrer = cv.getReferrer();
                if ("*".equals(cv.getName())) {
                    for (NamedEntity2 entry : usedEntities) {
                        String alias = entry.alias == null ? entry.entity.getName() : entry.alias;
                        expandEntityFields(qs, entry.entity, alias, alias, config.getExpandFieldFilter(), visitedEntities);
                    }
                } else if (referrer instanceof Entity) {
                    NamedEntity2 selectedEntry = null;
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
                        expandEntityFields(qs, _entity, alias, alias, config.getExpandFieldFilter(), visitedEntities);
                    } else {
                        CompiledVar ff = (CompiledVar) cv.getChild();
                        Field ef = (Field) ff.getReferrer();
                        if (ef.getDataType() instanceof EntityType) {
                            expandManyToOneField(qs, ef, selectedEntry.alias, null, config.getExpandFieldFilter(), visitedEntities);
                        } else {
                            qs.addField(f);
                        }
                    }
                } else if (referrer instanceof Field) {
                    Field ef = (Field) referrer;
                    DefaultCompiledExpression pe = cv.getParentExpression();
                    CompiledVar pp = pe instanceof CompiledVar ? ((CompiledVar) pe) : null;
                    if (ef.getModifiers().contains(FieldModifier.SELECT_LIVE)) {
                        expandLiveFormulaField(qs, ef, ef.getEntity(), pp == null ? null : pp.getName(), null);
                    } else if (ef.getDataType() instanceof EntityType) {
                        expandManyToOneField(qs, ef, pp == null ? null : pp.getName(), null, config.getExpandFieldFilter(), visitedEntities);
                    } else {
                        qs.addField(f);
                    }
                } else {
                    qs.addField(f);
                }
            } else {
                qs.addField(f);
            }
        }

    }

    private void expandLiveFormulaField(CompiledSelect qs, Field field, Entity e, String entityAlias, String binding) {
        Formula f = field.getSelectFormula();
        if (f instanceof CustomFormula) {
            //do nothing, should mak it as custom formula
        } else if (f instanceof ExpressionFormula) {
            ExpressionFormula ef = (ExpressionFormula) f;
            Expression expr = ef.getExpression();

            ExpressionCompilerConfig cfg = new ExpressionCompilerConfig();
            cfg.setThisAlias(entityAlias);
            cfg.setExpandEntityFilter(false);
            cfg.setExpandFields(false);
            cfg.setValidate(false);
            Map<String, String> aliasToEntityContext = new HashMap<String, String>();
            aliasToEntityContext.put(entityAlias, e.getName());
            cfg.setAliasToEntityContext(aliasToEntityContext);
            DefaultCompiledExpression rr = (DefaultCompiledExpression) persistenceUnit.getExpressionManager().compileExpression(expr, cfg);

            qs.addField(rr, field.getName()).setBinding(binding);

            cfg = new ExpressionCompilerConfig();
            cfg.setThisAlias(entityAlias);
            cfg.setExpandEntityFilter(true);
            cfg.setExpandFields(true);
            cfg.setValidate(true);
            aliasToEntityContext = new HashMap<String, String>();
            aliasToEntityContext.put(entityAlias, e.getName());
            cfg.setAliasToEntityContext(aliasToEntityContext);
            persistenceUnit.getExpressionManager().compileExpression(rr, cfg);

        } else {
            //ignore
        }
    }

    private void expandEntityFields(CompiledSelect qs, Entity e, String entityAlias, String binding, FieldFilter fieldFilter, ExpansionVisitTracker visitedEntities) {
        for (Field field : e.getFields(Fields.as(fieldFilter).and(READABLE))) {
            if (field.getModifiers().contains(FieldModifier.SELECT_LIVE)) {
                expandLiveFormulaField(qs, field, e, entityAlias, binding);
            } else if (field.getDataType() instanceof EntityType) {
//                EntityType et = (EntityType) field.getDataType();
//                if (field.isId()) {
//                    for (Field rf : et.getRelationship().getSourceRole().getFields()) {
//                        CompiledVar vv = new CompiledVar(entityAlias, e);
//                        vv.setChild(new CompiledVar(rf));
//                        //binding = (binding == null ? "" : (binding + ".")) + field.getName();
//                        qs.addField(vv, rf.getName()).setBinding(binding);
//                    }
//                }
                ExpansionVisitTracker c = visitedEntities.copy();
                expandManyToOneField(qs, field, entityAlias, binding, fieldFilter, c);
            } else {
                CompiledVar vv = new CompiledVar(entityAlias, e);
                vv.setChild(new CompiledVar(field));
                //binding = (binding == null ? "" : (binding + ".")) + field.getName();
                qs.addField(vv, field.getName()).setBinding(binding);
            }
        }
    }

    private void expandManyToOneField(CompiledSelect qs, Field field, String entityAlias, String binding, FieldFilter fieldFilter, ExpansionVisitTracker visitedEntities) {
        EntityType entityType = (EntityType) field.getDataType();
        Relationship rel = entityType.getRelationship();
        Entity masterEntity = rel.getTargetRole().getEntity();
        ExpansionVisitTracker dived = visitedEntities.dive();
        if (dived == null || !dived.nextVisit(masterEntity.getName())) {
            //should add only ids
            List<Field> otherFields = entityType.getRelationship().getSourceRole().getFields();
            for (Field f : otherFields) {
                if (!(f.getDataType() instanceof EntityType)) {
                    CompiledVar vv = new CompiledVar(entityAlias, field.getEntity());
                    vv.setChild(new CompiledVar(f));
                    //binding = (binding == null ? "" : (binding + ".")) + field.getName();
                    qs.addField(vv, f.getName()).setBinding(binding);
                }
            }
            return;
        }
        BindingJoinInfo d = addBindingJoin(qs, field, entityAlias, (Strings.isNullOrEmpty(binding) ? field.getName() : (binding + "." + field.getName())));
        expandEntityFields(qs, masterEntity, d.alias, d.binding, fieldFilter, dived);
    }

    private BindingJoinInfo addBindingJoin(CompiledSelect qs, Field field, String entityAlias, String binding) {
        BindingJoinInfo ret = new BindingJoinInfo();
        Relationship rel = ((EntityType) field.getDataType()).getRelationship();
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
        if (d.getClass().equals(DataType.class)) {
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
            if (f.getDataType() instanceof EntityType) {
                EntityType e = (EntityType) f.getDataType();
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
//            CompiledVar r = findRootVar(v);

            //get parent binding
//            CompiledVar rv = (CompiledVar) (r.copy());
//            CompiledVar rvc = (CompiledVar) rv.getChild();
//            CompiledVar varName=null;
//            while (rvc != null) {
//                if (rvc.getChild() == null) {
//                    CompiledVar t = (CompiledVar) rvc.getParentExpression();
//                    //t.setChild(null);
//                    varName=rvc;
//                }
//                rvc = (CompiledVar) rvc.getChild();
//            }
            CompiledSelect s = CompiledExpressionHelper.findEnclosingSelect(v);
            if (s != null) {
                //this 
                Field f = (Field) p1.getReferrer();
                if (f.getDataType() instanceof EntityType) {
                    BindingJoinInfo alias = addBindingJoin(s, f, p2.getName(), createBindingID(p1));
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
            } else {
                throw new IllegalArgumentException("No enclosing Select found for " + v);
            }
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
            s.insert(0, t.getName());
            DefaultCompiledExpression pe = t.getParentExpression();
            if (pe instanceof CompiledVarOrMethod) {
                t = (CompiledVarOrMethod) pe;
            } else {
                t = null;
            }
        }
        return s.toString();
    }

    public CompiledVar validateCompiledVarReferrer(CompiledVar v, ExpressionCompilerConfig config) {
        CompiledVar p = (v.getParentExpression() instanceof CompiledVar) ? ((CompiledVar) v.getParentExpression()) : null;
        if (p == null) {
            final String thisAlias = config.getThisAlias();
            if ("this".equals(v.getName())) {
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
                throw new IllegalArgumentException("'this' alias is not declared");
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
            throw new IllegalArgumentException("Field or alias not found : " + v.getName());
        } else {
            String before = p.toString();
            /*p =*/ validateCompiledVarReferrer(p, config);
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
                throw new IllegalArgumentException("Field not found " + v.getName());
            } else if (ref instanceof Field) {
                DataType dataType = ((Field) ref).getDataType();
                if (dataType instanceof EntityType) {
                    EntityType et = (EntityType) dataType;
                    Entity ee = et.getRelationship().getTargetRole().getEntity();
                    if (ee.containsField(v.getName())) {
                        v.setReferrer(ee.getField(v.getName()));
                        resolveToAlias(p);
                        return v;
                    } else if ("*".equals(v.getName())) {
                        return v;
                    }
                }
            }
            throw new IllegalArgumentException("Field not found " + v.getName());
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
