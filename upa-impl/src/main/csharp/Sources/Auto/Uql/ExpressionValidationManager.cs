/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE AS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.Vpc.Upa.Impl.Uql
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class ExpressionValidationManager {

        private static System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.Uql.ExpressionValidationManager)).FullName);

        private Net.Vpc.Upa.PersistenceUnit persistenceUnit;

        public ExpressionValidationManager(Net.Vpc.Upa.PersistenceUnit persistenceUnit) {
            this.persistenceUnit = persistenceUnit;
        }

        public virtual Net.Vpc.Upa.Expressions.CompiledExpression ValidateExpression(Net.Vpc.Upa.Expressions.CompiledExpression expression, Net.Vpc.Upa.Persistence.ExpressionCompilerConfig config) {
            log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,40,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Validate Compiled Expression {0}\n\t using config {1}",null,new object[] { expression, config }));
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression dce = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) expression;
            //dce.copy()
            System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect> allSelects = dce.FindExpressionsList<T>(Net.Vpc.Upa.Impl.Uql.Compiledfilters.CompiledExpressionHelper.SELECT_FILTER);
            //List<CompiledExpression> recurse = new ArrayList<CompiledExpression>();
            foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect compiledSelect in allSelects) {
                if (config.IsExpandEntityFilter()) {
                    ExpandEntityFilters(compiledSelect, config);
                }
            }
            foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar compiledVar in Net.Vpc.Upa.Impl.Uql.Compiledfilters.CompiledExpressionHelper.FindChildrenLeafVars(dce)) {
                //            validateCompiledVar(compiledVar, config);
                ValidateCompiledVarReferrer(compiledVar, config);
            }
            //vars may have changed
            foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar compiledVar in Net.Vpc.Upa.Impl.Uql.Compiledfilters.CompiledExpressionHelper.FindChildrenLeafVars(dce)) {
                //            validateCompiledVar(compiledVar, config);
                ValidateCompiledVarRelation(compiledVar, config);
            }
            if (expression is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledInsert) {
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledInsert ci = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledInsert) expression;
                for (int i = 0; i < ci.CountFields(); i++) {
                    Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar fvar = ci.GetField(i);
                    Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression vv = ci.GetFieldValue(i);
                    if (!(fvar.GetReferrer() is Net.Vpc.Upa.Field)) {
                        System.Console.Out.WriteLine("How come");
                    }
                    Net.Vpc.Upa.Field f = (Net.Vpc.Upa.Field) fvar.GetReferrer();
                    if (config.IsValidate()) {
                        if (f == null) {
                            throw new System.ArgumentException ("Field not found " + fvar + " in " + ci.GetEntity().GetName());
                        }
                        if (vv.GetTypeTransform() == null || vv.GetTypeTransform().GetTargetType().GetPlatformType().Equals(typeof(object))) {
                            vv.SetTypeTransform(Net.Vpc.Upa.Impl.Util.UPAUtils.GetTypeTransformOrIdentity(f));
                        } else {
                        }
                    }
                }
            }
            //ignore
            if (expression is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledUpdate) {
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledUpdate ci = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledUpdate) expression;
                for (int i = 0; i < ci.CountFields(); i++) {
                    Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar fvar = ci.GetField(i);
                    Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression vv = ci.GetFieldValue(i);
                    Net.Vpc.Upa.Field f = (Net.Vpc.Upa.Field) fvar.GetReferrer();
                    if (config.IsValidate()) {
                        if (f == null) {
                            throw new System.ArgumentException ("Field not found " + fvar + " in " + ci.GetEntity().GetName());
                        }
                        if (vv.GetTypeTransform() == null || vv.GetTypeTransform().GetTargetType().GetPlatformType().Equals(typeof(object))) {
                            vv.SetTypeTransform(Net.Vpc.Upa.Impl.Util.UPAUtils.GetTypeTransformOrIdentity(f));
                        } else {
                        }
                    }
                    //ignore
                    if (fvar.GetChild() != null) {
                        if (!(fvar.GetChild() is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar)) {
                            throw new System.ArgumentException ();
                        }
                        if (fvar.GetChild().GetChild() != null) {
                            throw new System.ArgumentException ();
                        }
                    }
                }
            }
            allSelects = dce.FindExpressionsList<T>(Net.Vpc.Upa.Impl.Uql.Compiledfilters.CompiledExpressionHelper.SELECT_FILTER);
            //List<CompiledExpression> recurse = new ArrayList<CompiledExpression>();
            foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect compiledSelect in allSelects) {
                if (config.IsExpandFields()) {
                    ExpandFields(compiledSelect, config);
                    if (config.IsValidate()) {
                        if (compiledSelect.CountFields() == 0) {
                            throw new System.ArgumentException ("Empty Field List in " + compiledSelect);
                        }
                    }
                }
            }
            dce.ReplaceExpressions(Net.Vpc.Upa.Impl.Uql.Compiledfilters.CompiledExpressionHelper.QL_FUNCTION_FILTER, new Net.Vpc.Upa.Impl.Uql.Compiledreplacer.CompiledQLFunctionExpressionSimplifier(persistenceUnit));
            dce.ReplaceExpressions(Net.Vpc.Upa.Impl.Uql.Compiledfilters.CompiledExpressionHelper.DESCENDENT_FILTER, new Net.Vpc.Upa.Impl.Uql.Compiledreplacer.IsHierarchyDescendentReplacer(persistenceUnit));
            System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledParam> allParams = dce.FindExpressionsList<T>(Net.Vpc.Upa.Impl.Uql.Compiledfilters.CompiledExpressionHelper.PARAM_FILTER);
            foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledParam p in allParams) {
                ValidateCompiledParam(p, config);
            }
            return dce;
        }

        private void ExpandEntityFilters(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect compiledSelect, Net.Vpc.Upa.Persistence.ExpressionCompilerConfig config) {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect nameOrSelect = compiledSelect.GetEntity();
            if (nameOrSelect is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) {
                string entityName = ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) nameOrSelect).GetName();
                Net.Vpc.Upa.Entity re = persistenceUnit.GetEntity(entityName);
                foreach (string filterName in re.GetFilterNames()) {
                    Net.Vpc.Upa.Expressions.Expression filter = re.GetFilter(filterName);
                    Net.Vpc.Upa.Persistence.ExpressionCompilerConfig conf2 = new Net.Vpc.Upa.Persistence.ExpressionCompilerConfig();
                    string name = compiledSelect.GetEntityAlias();
                    if (name == null) {
                        name = entityName;
                    }
                    conf2.BindAliastoEntity(name, entityName);
                    conf2.SetValidate(true);
                    conf2.SetThisAlias(name);
                    Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression compiledFilter = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) persistenceUnit.GetExpressionManager().CompileExpression(filter, conf2);
                    //                                    compiledFilter.getClientParameters().setBoolean("UPA.EntityFilter:", true);
                    //                                    DefaultCompiledExpression oldCond = compiledSelect.getCondition();
                    //                                    List<DefaultCompiledExpression> found = oldCond == null ? null : oldCond.findExpressionsList(new CompiledExpressionFilter() {
                    //                                        public boolean accept(DefaultCompiledExpression e) {
                    //                                            return e.getClientParameters().getBoolean("UPA.EntityFilter", false);
                    //                                        }
                    //                                    });
                    compiledSelect.AddWhere(compiledFilter);
                }
                Net.Vpc.Upa.Expressions.Expression f2 = persistenceUnit.GetSecurityManager().GetEntityFilter(re);
                if (f2 != null) {
                    Net.Vpc.Upa.Persistence.ExpressionCompilerConfig conf2 = new Net.Vpc.Upa.Persistence.ExpressionCompilerConfig();
                    string name = compiledSelect.GetEntityAlias();
                    if (name == null) {
                        name = entityName;
                    }
                    conf2.BindAliastoEntity(name, entityName);
                    conf2.SetValidate(false);
                    conf2.SetThisAlias(name);
                    conf2.SetExpandFields(false);
                    conf2.SetExpandEntityFilter(false);
                    //just to help compileExpressionTo Work as it needs to upderstands where fields are from!
                    //                Select s=new Select().field("1").from(entityName,name).where(f2);
                    Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression compiledFilter = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) persistenceUnit.GetExpressionManager().CompileExpression(f2, conf2);
                    compiledFilter = compiledFilter.ReplaceExpressions(Net.Vpc.Upa.Impl.Uql.Compiledfilters.CompiledExpressionHelper.THIS_VAR_FILTER, new Net.Vpc.Upa.Impl.Uql.CompiledExpressionThisReplacer(name));
                    compiledSelect.AddWhere(compiledFilter);
                }
            }
            foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledJoinCriteria join in compiledSelect.GetJoins()) {
                switch(join.GetJoinType()) {
                    case Net.Vpc.Upa.Expressions.JoinType.LEFT_JOIN:
                    case Net.Vpc.Upa.Expressions.JoinType.RIGHT_JOIN:
                    case Net.Vpc.Upa.Expressions.JoinType.FULL_JOIN:
                    case Net.Vpc.Upa.Expressions.JoinType.INNER_JOIN:
                        {
                            nameOrSelect = join.GetEntity();
                            string entityName = ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) nameOrSelect).GetName();
                            Net.Vpc.Upa.Entity re = persistenceUnit.GetEntity(entityName);
                            foreach (string filterName in re.GetFilterNames()) {
                                Net.Vpc.Upa.Expressions.Expression filter = re.GetFilter(filterName);
                                Net.Vpc.Upa.Persistence.ExpressionCompilerConfig conf2 = new Net.Vpc.Upa.Persistence.ExpressionCompilerConfig();
                                string name = join.GetEntityAlias();
                                if (name == null) {
                                    name = entityName;
                                }
                                conf2.BindAliastoEntity(name, entityName);
                                conf2.SetValidate(true);
                                conf2.SetThisAlias(name);
                                Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression compiledFilter = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) persistenceUnit.GetExpressionManager().CompileExpression(filter, conf2);
                                //                                    compiledFilter.getClientParameters().setBoolean("UPA.EntityFilter:", true);
                                //                                    DefaultCompiledExpression oldCond = compiledSelect.getCondition();
                                //                                    List<DefaultCompiledExpression> found = oldCond == null ? null : oldCond.findExpressionsList(new CompiledExpressionFilter() {
                                //                                        public boolean accept(DefaultCompiledExpression e) {
                                //                                            return e.getClientParameters().getBoolean("UPA.EntityFilter", false);
                                //                                        }
                                //                                    });
                                join.AddCondition(compiledFilter);
                            }
                            break;
                        }
                    case Net.Vpc.Upa.Expressions.JoinType.CROSS_JOIN:
                        {
                            nameOrSelect = join.GetEntity();
                            string entityName = ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) nameOrSelect).GetName();
                            Net.Vpc.Upa.Entity re = persistenceUnit.GetEntity(entityName);
                            foreach (string filterName in re.GetFilterNames()) {
                                Net.Vpc.Upa.Expressions.Expression filter = re.GetFilter(filterName);
                                Net.Vpc.Upa.Persistence.ExpressionCompilerConfig conf2 = new Net.Vpc.Upa.Persistence.ExpressionCompilerConfig();
                                string name = join.GetEntityAlias();
                                if (name == null) {
                                    name = entityName;
                                }
                                conf2.BindAliastoEntity(name, entityName);
                                conf2.SetValidate(true);
                                conf2.SetThisAlias(name);
                                Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression compiledFilter = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) persistenceUnit.GetExpressionManager().CompileExpression(filter, conf2);
                                //                                    compiledFilter.getClientParameters().setBoolean("UPA.EntityFilter:", true);
                                //                                    DefaultCompiledExpression oldCond = compiledSelect.getCondition();
                                //                                    List<DefaultCompiledExpression> found = oldCond == null ? null : oldCond.findExpressionsList(new CompiledExpressionFilter() {
                                //                                        public boolean accept(DefaultCompiledExpression e) {
                                //                                            return e.getClientParameters().getBoolean("UPA.EntityFilter", false);
                                //                                        }
                                //                                    });
                                compiledSelect.AddWhere(compiledFilter);
                            }
                            break;
                        }
                }
            }
        }

        private void ExpandFields(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect qs, Net.Vpc.Upa.Persistence.ExpressionCompilerConfig config) {
            int navigationDepth = ((int?) config.GetHint(Net.Vpc.Upa.QueryHints.NAVIGATION_DEPTH, -1)).Value;
            Net.Vpc.Upa.QueryFetchStrategy fetchStrategy = (Net.Vpc.Upa.QueryFetchStrategy) config.GetHint(Net.Vpc.Upa.QueryHints.FETCH_STRATEGY, Net.Vpc.Upa.QueryFetchStrategy.JOIN);
            if (fetchStrategy == default(Net.Vpc.Upa.QueryFetchStrategy)) {
                fetchStrategy = Net.Vpc.Upa.QueryFetchStrategy.JOIN;
            }
            Net.Vpc.Upa.Impl.Uql.ExpansionVisitTracker visitedEntities = new Net.Vpc.Upa.Impl.Uql.ExpansionVisitTracker(navigationDepth);
            if (qs.CountFields() == 0) {
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar fvar = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar("*");
                //throw unsupported
                qs.Field(fvar, null);
            }
            System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField> fields = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField>(qs.GetFields());
            qs.RemoveAllFields();
            System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.NamedEntity2> usedEntities = GetUsedEntities(qs);
            foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField f in fields) {
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression fe = f.GetExpression();
                string fieldAlias = f.GetAlias();
                //            boolean indexChanged = false;
                if (fe is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) {
                    Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar cv = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) fe;
                    object referrer = cv.GetReferrer();
                    if ("*".Equals(cv.GetName())) {
                        foreach (Net.Vpc.Upa.Impl.Uql.NamedEntity2 entry in usedEntities) {
                            string alias = entry.alias == null ? entry.entity.GetName() : entry.alias;
                            if (Net.Vpc.Upa.QueryFetchStrategy.JOIN == (fetchStrategy)) {
                                ExpandEntityFieldsJoinFetch(qs, f.GetIndex(), entry.entity, alias, alias, fieldAlias, config.GetExpandFieldFilter(), visitedEntities);
                            } else if (Net.Vpc.Upa.QueryFetchStrategy.SELECT == (fetchStrategy)) {
                                ExpandEntityFieldsSelectFetch(qs, f.GetIndex(), entry.entity, alias, alias, fieldAlias, config.GetExpandFieldFilter(), visitedEntities);
                            }
                        }
                    } else if (referrer is Net.Vpc.Upa.Entity) {
                        Net.Vpc.Upa.Impl.Uql.NamedEntity2 selectedEntry = null;
                        foreach (Net.Vpc.Upa.Impl.Uql.NamedEntity2 entry in usedEntities) {
                            if (cv.GetName().Equals(entry.alias)) {
                                selectedEntry = entry;
                                break;
                            }
                        }
                        if (selectedEntry == null) {
                            foreach (Net.Vpc.Upa.Impl.Uql.NamedEntity2 entry in usedEntities) {
                                if (cv.GetName().Equals(entry.entity.GetName())) {
                                    selectedEntry = entry;
                                    break;
                                }
                            }
                        }
                        if (selectedEntry == null) {
                            throw new System.ArgumentException ("Unknown alias " + cv.GetName());
                        }
                        Net.Vpc.Upa.Entity _entity = selectedEntry.entity;
                        if (cv.GetChild() == null || cv.GetChild().GetName().Equals("*")) {
                            string alias = selectedEntry.alias == null ? _entity.GetName() : selectedEntry.alias;
                            if (Net.Vpc.Upa.QueryFetchStrategy.JOIN == (fetchStrategy)) {
                                ExpandEntityFieldsJoinFetch(qs, f.GetIndex(), _entity, alias, alias, alias, config.GetExpandFieldFilter(), visitedEntities);
                            } else if (Net.Vpc.Upa.QueryFetchStrategy.SELECT == (fetchStrategy)) {
                                ExpandEntityFieldsSelectFetch(qs, f.GetIndex(), _entity, alias, alias, fieldAlias, config.GetExpandFieldFilter(), visitedEntities);
                            }
                        } else {
                            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar ff = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) cv.GetChild();
                            Net.Vpc.Upa.Field ef = (Net.Vpc.Upa.Field) ff.GetReferrer();
                            if (ef.GetDataType() is Net.Vpc.Upa.Types.ManyToOneType) {
                                string binding = "";
                                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod r = cv;
                                while (r != null) {
                                    if ((binding).Length == 0) {
                                        binding = r.GetName();
                                    } else {
                                        binding = r.GetName() + "." + binding;
                                    }
                                    if (r.GetParentExpression() is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod) {
                                        r = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod) r.GetParentExpression();
                                    } else {
                                        r = null;
                                    }
                                }
                                if ((binding).Length == 0) {
                                    binding = null;
                                }
                                if (Net.Vpc.Upa.QueryFetchStrategy.JOIN == (fetchStrategy)) {
                                    ExpandManyToOneFieldJoinFetch(qs, f.GetIndex(), ef, selectedEntry.alias, binding, fieldAlias, config.GetExpandFieldFilter(), visitedEntities);
                                } else if (Net.Vpc.Upa.QueryFetchStrategy.SELECT == (fetchStrategy)) {
                                    ExpandManyToOneFieldSelectFetch(qs, f.GetIndex(), ef, selectedEntry.alias, binding, fieldAlias, config.GetExpandFieldFilter(), visitedEntities);
                                }
                            } else {
                                qs.AddField(f);
                            }
                        }
                    } else if (referrer is Net.Vpc.Upa.Field) {
                        Net.Vpc.Upa.Field ef = (Net.Vpc.Upa.Field) referrer;
                        Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression pe = cv.GetParentExpression();
                        Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar pp = pe is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar ? ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) pe) : null;
                        if (ef.GetModifiers().Contains(Net.Vpc.Upa.FieldModifier.SELECT_LIVE)) {
                            ExpandLiveFormulaField(qs, f.GetIndex(), ef, ef.GetEntity(), pp == null ? null : pp.GetName(), null);
                        } else if (ef.GetDataType() is Net.Vpc.Upa.Types.ManyToOneType) {
                            if (Net.Vpc.Upa.QueryFetchStrategy.JOIN == (fetchStrategy)) {
                                ExpandManyToOneFieldJoinFetch(qs, f.GetIndex(), ef, pp == null ? null : pp.GetName(), null, fieldAlias, config.GetExpandFieldFilter(), visitedEntities);
                            }
                            if (Net.Vpc.Upa.QueryFetchStrategy.SELECT == (fetchStrategy)) {
                                ExpandManyToOneFieldSelectFetch(qs, f.GetIndex(), ef, pp == null ? null : pp.GetName(), null, fieldAlias, config.GetExpandFieldFilter(), visitedEntities);
                            }
                        } else {
                            qs.AddField(f);
                        }
                    } else {
                        qs.AddField(f);
                    }
                } else {
                    qs.AddField(f);
                }
            }
        }

        private void ExpandLiveFormulaField(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect qs, int index, Net.Vpc.Upa.Field field, Net.Vpc.Upa.Entity e, string entityAlias, string binding) {
            Net.Vpc.Upa.Formula f = field.GetSelectFormula();
            if (f is Net.Vpc.Upa.CustomFormula) {
            } else if (f is Net.Vpc.Upa.ExpressionFormula) {
                Net.Vpc.Upa.ExpressionFormula ef = (Net.Vpc.Upa.ExpressionFormula) f;
                Net.Vpc.Upa.Expressions.Expression expr = ef.GetExpression();
                Net.Vpc.Upa.Persistence.ExpressionCompilerConfig cfg = new Net.Vpc.Upa.Persistence.ExpressionCompilerConfig();
                cfg.SetThisAlias(entityAlias);
                cfg.SetExpandEntityFilter(false);
                cfg.SetExpandFields(false);
                cfg.SetValidate(false);
                System.Collections.Generic.IDictionary<string , string> aliasToEntityContext = new System.Collections.Generic.Dictionary<string , string>();
                aliasToEntityContext[entityAlias]=e.GetName();
                cfg.SetAliasToEntityContext(aliasToEntityContext);
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression rr = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) persistenceUnit.GetExpressionManager().CompileExpression(expr, cfg);
                qs.AddField(rr, field.GetName()).SetIndex(index).SetExpanded(true).SetBinding(binding);
                cfg = new Net.Vpc.Upa.Persistence.ExpressionCompilerConfig();
                cfg.SetThisAlias(entityAlias);
                cfg.SetExpandEntityFilter(true);
                cfg.SetExpandFields(true);
                cfg.SetValidate(true);
                aliasToEntityContext = new System.Collections.Generic.Dictionary<string , string>();
                aliasToEntityContext[entityAlias]=e.GetName();
                cfg.SetAliasToEntityContext(aliasToEntityContext);
                persistenceUnit.GetExpressionManager().CompileExpression(rr, cfg);
            } else {
            }
        }

        private void ExpandEntityFieldsJoinFetch(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect qs, int index, Net.Vpc.Upa.Entity e, string entityAlias, string binding, string aliasBinding, Net.Vpc.Upa.Filters.FieldFilter fieldFilter, Net.Vpc.Upa.Impl.Uql.ExpansionVisitTracker visitedEntities) {
            foreach (Net.Vpc.Upa.Field field in e.GetFields(Net.Vpc.Upa.Filters.Fields.As(fieldFilter).And(Net.Vpc.Upa.Impl.Util.Filters.Fields2.READ))) {
                if (field.GetModifiers().Contains(Net.Vpc.Upa.FieldModifier.SELECT_LIVE)) {
                    ExpandLiveFormulaField(qs, index, field, e, entityAlias, binding);
                } else if (field.GetDataType() is Net.Vpc.Upa.Types.ManyToOneType) {
                    Net.Vpc.Upa.Impl.Uql.ExpansionVisitTracker c = visitedEntities.Copy();
                    ExpandManyToOneFieldJoinFetch(qs, index, field, entityAlias, binding, Net.Vpc.Upa.Impl.Util.UPAUtils.DotConcat(aliasBinding, field.GetName()), fieldFilter, c);
                } else {
                    Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar vv = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(entityAlias, e);
                    vv.SetChild(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(field));
                    //binding = (binding == null ? "" : (binding + ".")) + field.getName();
                    qs.AddField(vv, field.GetName()).SetBinding(binding).SetIndex(index).SetExpanded(true).SetAliasBinding(Net.Vpc.Upa.Impl.Util.UPAUtils.DotConcat(aliasBinding, field.GetName()));
                }
            }
        }

        private void ExpandEntityFieldsSelectFetch(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect qs, int index, Net.Vpc.Upa.Entity e, string entityAlias, string binding, string aliasBinding, Net.Vpc.Upa.Filters.FieldFilter fieldFilter, Net.Vpc.Upa.Impl.Uql.ExpansionVisitTracker visitedEntities) {
            foreach (Net.Vpc.Upa.Field field in e.GetFields(Net.Vpc.Upa.Filters.Fields.As(fieldFilter).And(Net.Vpc.Upa.Impl.Util.Filters.Fields2.READ))) {
                if (field.GetModifiers().Contains(Net.Vpc.Upa.FieldModifier.SELECT_LIVE)) {
                    ExpandLiveFormulaField(qs, index, field, e, entityAlias, binding);
                } else if (field.GetDataType() is Net.Vpc.Upa.Types.ManyToOneType) {
                    Net.Vpc.Upa.Impl.Uql.ExpansionVisitTracker c = visitedEntities.Copy();
                    ExpandManyToOneFieldSelectFetch(qs, index, field, entityAlias, binding, aliasBinding, fieldFilter, c);
                } else {
                    Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar vv = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(entityAlias, e);
                    vv.SetChild(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(field));
                    //binding = (binding == null ? "" : (binding + ".")) + field.getName();
                    qs.AddField(vv, field.GetName()).SetIndex(index).SetExpanded(true).SetBinding(binding);
                }
            }
        }

        private void ExpandManyToOneFieldJoinFetch(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect qs, int index, Net.Vpc.Upa.Field field, string entityAlias, string binding, string aliasBinding, Net.Vpc.Upa.Filters.FieldFilter fieldFilter, Net.Vpc.Upa.Impl.Uql.ExpansionVisitTracker visitedEntities) {
            Net.Vpc.Upa.Types.ManyToOneType manyToOneType = (Net.Vpc.Upa.Types.ManyToOneType) field.GetDataType();
            Net.Vpc.Upa.Relationship rel = manyToOneType.GetRelationship();
            Net.Vpc.Upa.Entity masterEntity = rel.GetTargetRole().GetEntity();
            Net.Vpc.Upa.Impl.Uql.ExpansionVisitTracker dived = visitedEntities.Dive();
            if (dived == null || !dived.NextVisit(masterEntity.GetName())) {
                //should add only ids
                System.Collections.Generic.IList<Net.Vpc.Upa.Field> otherFields = manyToOneType.GetRelationship().GetSourceRole().GetFields();
                foreach (Net.Vpc.Upa.Field f in otherFields) {
                    if (!(f.GetDataType() is Net.Vpc.Upa.Types.ManyToOneType)) {
                        Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar vv = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(entityAlias, field.GetEntity());
                        vv.SetChild(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(f));
                        //binding = (binding == null ? "" : (binding + ".")) + field.getName();
                        qs.AddField(vv, f.GetName()).SetIndex(index).SetExpanded(true).SetBinding(binding);
                    }
                }
                return;
            }
            Net.Vpc.Upa.Impl.Uql.BindingJoinInfo d = AddBindingJoin(qs, field, entityAlias, (Net.Vpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(binding) ? field.GetName() : (binding + "." + field.GetName())), (Net.Vpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(aliasBinding) ? field.GetName() : (aliasBinding + "." + field.GetName())));
            ExpandEntityFieldsJoinFetch(qs, index, masterEntity, d.alias, d.binding, aliasBinding, fieldFilter, dived);
        }

        private void ExpandManyToOneFieldSelectFetch(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect qs, int index, Net.Vpc.Upa.Field field, string entityAlias, string binding, string aliasBinding, Net.Vpc.Upa.Filters.FieldFilter fieldFilter, Net.Vpc.Upa.Impl.Uql.ExpansionVisitTracker visitedEntities) {
            Net.Vpc.Upa.Types.ManyToOneType manyToOneType = (Net.Vpc.Upa.Types.ManyToOneType) field.GetDataType();
            Net.Vpc.Upa.Relationship rel = manyToOneType.GetRelationship();
            Net.Vpc.Upa.Entity masterEntity = rel.GetTargetRole().GetEntity();
            Net.Vpc.Upa.Impl.Uql.ExpansionVisitTracker dived = visitedEntities.Dive();
            //        if (dived == null || !dived.nextVisit(masterEntity.getName())) {
            //            //should add only ids
            //            return;
            //        }
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> otherFields = manyToOneType.GetRelationship().GetSourceRole().GetFields();
            foreach (Net.Vpc.Upa.Field f in otherFields) {
                if (!(f.GetDataType() is Net.Vpc.Upa.Types.ManyToOneType)) {
                    Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar vv = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(entityAlias, field.GetEntity());
                    vv.SetChild(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(f));
                    //binding = (binding == null ? "" : (binding + ".")) + field.getName();
                    qs.AddField(vv, f.GetName()).SetIndex(index).SetBinding(binding).SetExpanded(true).SetAliasBinding(aliasBinding);
                }
            }
        }

        private Net.Vpc.Upa.Impl.Uql.BindingJoinInfo AddBindingJoin(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect qs, Net.Vpc.Upa.Field field, string entityAlias, string binding, string aliasBinding) {
            Net.Vpc.Upa.Impl.Uql.BindingJoinInfo ret = new Net.Vpc.Upa.Impl.Uql.BindingJoinInfo();
            Net.Vpc.Upa.Relationship rel = ((Net.Vpc.Upa.Types.ManyToOneType) field.GetDataType()).GetRelationship();
            Net.Vpc.Upa.Entity masterEntity = rel.GetTargetRole().GetEntity();
            System.Collections.Generic.IDictionary<string , string> upaBindingAliases = (System.Collections.Generic.IDictionary<string , string>) qs.GetClientProperty("upaBindingAliases");
            if (upaBindingAliases == null) {
                upaBindingAliases = new System.Collections.Generic.Dictionary<string , string>();
                qs.SetClientProperty("upaBindingAliases", upaBindingAliases);
            }
            binding = (binding == null ? "" : binding);
            string generatedAlias = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(upaBindingAliases,binding.ToLower());
            bool addJoin = generatedAlias == null;
            ret.entity = masterEntity;
            ret.binding = binding;
            if (!addJoin) {
                ret.alias = generatedAlias;
            } else {
                int? upaBindingAliasIndex = (int?) qs.GetClientProperty("upaBindingAliasIndex");
                if (upaBindingAliasIndex == null) {
                    upaBindingAliasIndex = 1;
                }
                generatedAlias = "upa" + upaBindingAliasIndex;
                qs.SetClientProperty("upaBindingAliasIndex", upaBindingAliasIndex + 1);
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression cond = null;
                Net.Vpc.Upa.Entity detailEntity = field.GetEntity();
                foreach (System.Collections.Generic.KeyValuePair<string , string> entry in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,string>>(rel.GetTargetToSourceFieldNamesMap(false))) {
                    Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar detailAlias = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(entityAlias, detailEntity);
                    Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar masterAlias = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(generatedAlias, masterEntity);
                    detailAlias.SetChild(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(detailEntity.GetField((entry).Value)));
                    masterAlias.SetChild(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(masterEntity.GetField((entry).Key)));
                    Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEquals cond0 = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEquals(detailAlias, masterAlias);
                    if (cond == null) {
                        cond = cond0;
                    } else {
                        cond = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledAnd(cond, cond0);
                    }
                }
                qs.LeftJoin(rel.GetTargetRole().GetEntity().GetName(), generatedAlias, cond);
                //            qs.getDeclarationList().push(masterAliasString, masterEntity);
                ret.alias = generatedAlias;
                upaBindingAliases[binding.ToLower()]=generatedAlias;
            }
            return ret;
        }

        private System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.NamedEntity2> GetUsedEntities(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect qs) {
            System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.NamedEntity2> found = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.NamedEntity2>();
            if (qs.GetEntity() is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) {
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName en = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) qs.GetEntity();
                Net.Vpc.Upa.Entity _entity = persistenceUnit.GetEntity(en.GetName());
                found.Add(new Net.Vpc.Upa.Impl.Uql.NamedEntity2(qs.GetEntityAlias(), _entity));
            }
            foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledJoinCriteria c in qs.GetJoins()) {
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect e = c.GetEntity();
                if (e is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) {
                    Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName en = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) e;
                    Net.Vpc.Upa.Entity _entity = persistenceUnit.GetEntity(en.GetName());
                    found.Add(new Net.Vpc.Upa.Impl.Uql.NamedEntity2(c.GetEntityAlias(), _entity));
                }
            }
            return found;
        }

        private Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration GetDeclaration(string name, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression, Net.Vpc.Upa.Persistence.ExpressionCompilerConfig config) {
            Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration declaration = expression.GetDeclaration(name);
            if (declaration != null) {
                return declaration;
            }
            System.Collections.Generic.IDictionary<string , string> m = config.GetAliasToEntityContext();
            if (m != null) {
                string t = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(m,name);
                if (t != null) {
                    return new Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration(name, Net.Vpc.Upa.Impl.Uql.DecObjectType.ENTITY, t, null);
                }
            }
            return null;
        }

        private System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration> GetDeclarations(string name, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression, Net.Vpc.Upa.Persistence.ExpressionCompilerConfig config) {
            System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration> declarations = expression.GetDeclarations(name);
            if (declarations != null && (declarations).Count > 0) {
                return declarations;
            }
            System.Collections.Generic.IDictionary<string , string> m = config.GetAliasToEntityContext();
            if (m != null) {
                string t = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(m,name);
                if (t != null) {
                    Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration d = new Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration(name, Net.Vpc.Upa.Impl.Uql.DecObjectType.ENTITY, t, null);
                    declarations = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration>(1);
                    declarations.Add(d);
                    return declarations;
                }
            }
            return Net.Vpc.Upa.Impl.Util.PlatformUtils.EmptyList<T>();
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledParam ValidateCompiledParam(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledParam v, Net.Vpc.Upa.Persistence.ExpressionCompilerConfig config) {
            Net.Vpc.Upa.Types.DataTypeTransform d = GetValidDataType(v);
            if (d != null) {
                return v;
            }
            if (v.GetValue() != null) {
                v.SetTypeTransform(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.ForNativeType(v.GetValue().GetType()));
                d = GetValidDataType(v);
                if (d != null) {
                    return v;
                }
            }
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression pe = v.GetParentExpression();
            if (pe is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledBinaryOperatorExpression) {
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledBinaryOperatorExpression c = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledBinaryOperatorExpression) pe;
                Net.Vpc.Upa.Expressions.BinaryOperator @operator = c.GetOperator();
                switch(@operator) {
                    case Net.Vpc.Upa.Expressions.BinaryOperator.EQ:
                    case Net.Vpc.Upa.Expressions.BinaryOperator.DIFF:
                    case Net.Vpc.Upa.Expressions.BinaryOperator.LE:
                    case Net.Vpc.Upa.Expressions.BinaryOperator.LT:
                    case Net.Vpc.Upa.Expressions.BinaryOperator.GE:
                    case Net.Vpc.Upa.Expressions.BinaryOperator.GT:
                    case Net.Vpc.Upa.Expressions.BinaryOperator.BIT_AND:
                    case Net.Vpc.Upa.Expressions.BinaryOperator.BIT_OR:
                    case Net.Vpc.Upa.Expressions.BinaryOperator.PLUS:
                    case Net.Vpc.Upa.Expressions.BinaryOperator.MINUS:
                    case Net.Vpc.Upa.Expressions.BinaryOperator.MUL:
                    case Net.Vpc.Upa.Expressions.BinaryOperator.DIV:
                    case Net.Vpc.Upa.Expressions.BinaryOperator.REM:
                    case Net.Vpc.Upa.Expressions.BinaryOperator.LSHIFT:
                    case Net.Vpc.Upa.Expressions.BinaryOperator.RSHIFT:
                    case Net.Vpc.Upa.Expressions.BinaryOperator.XOR:
                    case Net.Vpc.Upa.Expressions.BinaryOperator.URSHIFT:
                        {
                            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression a = c.GetLeft();
                            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression b = c.GetRight();
                            if (v == a) {
                                Net.Vpc.Upa.Types.DataTypeTransform d2 = GetValidDataType(b);
                                if (d2 != null) {
                                    v.SetTypeTransform(d2);
                                    return v;
                                }
                            } else if (v == b) {
                                Net.Vpc.Upa.Types.DataTypeTransform d2 = GetValidDataType(a);
                                if (d2 != null) {
                                    v.SetTypeTransform(d2);
                                    return v;
                                }
                            }
                            return v;
                        }
                    case Net.Vpc.Upa.Expressions.BinaryOperator.LIKE:
                        {
                            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression a = c.GetLeft();
                            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression b = c.GetRight();
                            v.SetTypeTransform(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.STRING_UNLIMITED);
                            return v;
                        }
                    case Net.Vpc.Upa.Expressions.BinaryOperator.OR:
                    case Net.Vpc.Upa.Expressions.BinaryOperator.AND:
                        {
                            v.SetTypeTransform(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.BOOLEAN);
                            return v;
                        }
                }
            } else if (pe is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarVal) {
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarVal cvv = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarVal) pe;
                if (cvv.GetVal() == v) {
                    //it should be the case
                    v.SetTypeTransform(cvv.GetVar().GetTypeTransform());
                    return v;
                }
            }
            return v;
        }

        private Net.Vpc.Upa.Types.DataTypeTransform GetValidDataType(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression a) {
            Net.Vpc.Upa.Types.DataTypeTransform d = a.GetEffectiveDataType();
            if (d == null) {
                return null;
            }
            if (d.GetTargetType().GetType().Equals(typeof(Net.Vpc.Upa.Types.SerializableType)) && d.GetTargetType().GetPlatformType().Equals(typeof(object))) {
                return null;
            }
            return d;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar ValidateCompiledVarRelation(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar v, Net.Vpc.Upa.Persistence.ExpressionCompilerConfig config) {
            if (v.GetChild() == null && v.GetReferrer() is Net.Vpc.Upa.Field) {
                Net.Vpc.Upa.Field f = (Net.Vpc.Upa.Field) v.GetReferrer();
                if (f.GetDataType() is Net.Vpc.Upa.Types.ManyToOneType) {
                    Net.Vpc.Upa.Types.ManyToOneType e = (Net.Vpc.Upa.Types.ManyToOneType) f.GetDataType();
                    System.Collections.Generic.IList<Net.Vpc.Upa.Field> fields = e.GetRelationship().GetSourceRole().GetFields();
                    if ((fields).Count == 1) {
                        if (v is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) {
                            Net.Vpc.Upa.Expressions.CompiledExpression pe = v.GetNonVarParent();
                            if (pe != null && pe is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledBinaryOperatorExpression) {
                                v.SetName(fields[0].GetName());
                                object oldReferrer = v.GetReferrer();
                                v.SetReferrer(fields[0]);
                                v.SetOldReferrer(oldReferrer);
                            }
                        }
                    }
                }
            }
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar p0 = (v.GetParentExpression() is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) ? ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) v.GetParentExpression()) : null;
            if (p0 != null) {
                ValidateCompiledVarRelation(p0, config);
            }
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar p1 = (v.GetParentExpression() is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) ? (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) v.GetParentExpression() : null;
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar p2 = p1 == null ? null : ((p1.GetParentExpression() is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) ? (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) p1.GetParentExpression() : null);
            if (p1 != null && p2 != null && p1.GetReferrer() is Net.Vpc.Upa.Field) {
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
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect s = Net.Vpc.Upa.Impl.Uql.Compiledfilters.CompiledExpressionHelper.FindEnclosingSelect(v);
                if (s != null) {
                    //this 
                    Net.Vpc.Upa.Field f = (Net.Vpc.Upa.Field) p1.GetReferrer();
                    if (f.GetDataType() is Net.Vpc.Upa.Types.ManyToOneType) {
                        Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField cqf = Net.Vpc.Upa.Impl.Uql.Compiledfilters.CompiledExpressionHelper.FindRootCompiledQueryField(p1);
                        Net.Vpc.Upa.Impl.Uql.BindingJoinInfo alias = AddBindingJoin(s, f, p2.GetName(), CreateBindingID(p1), cqf == null ? null : cqf.GetAlias());
                        p2.SetName(alias.alias);
                        p2.SetReferrer(alias.entity);
                        //remove p1, disconnect it form parent and child
                        p2.SetChild(null);
                        p1.SetParentExpression(null);
                        p1.SetChild(null);
                        v.SetParentExpression(null);
                        //connect v to p2
                        p2.SetChild(v);
                        return v;
                    }
                } else {
                    throw new System.ArgumentException ("No enclosing Select found for " + v);
                }
            }
            return v;
        }

        private string CreateBindingID(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar rv) {
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod t = rv;
            while (t != null) {
                if ((s).Length > 0) {
                    s.Insert(0, ".");
                }
                s.Insert(0, t.GetName());
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression pe = t.GetParentExpression();
                if (pe is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod) {
                    t = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod) pe;
                } else {
                    t = null;
                }
            }
            return s.ToString();
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar ValidateCompiledVarReferrer(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar v, Net.Vpc.Upa.Persistence.ExpressionCompilerConfig config) {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar p = (v.GetParentExpression() is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) ? ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) v.GetParentExpression()) : null;
            if (p == null) {
                string thisAlias = config.GetThisAlias();
                if ("this".Equals(v.GetName())) {
                    if (thisAlias != null) {
                        v.SetName(thisAlias);
                    } else {
                    }
                    //                    throw new IllegalArgumentException("Incountered this alias but never declared");
                    Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration declaration = GetDeclaration(v.GetName(), v, config);
                    if (declaration != null) {
                        switch(declaration.GetReferrerType()) {
                            case Net.Vpc.Upa.Impl.Uql.DecObjectType.ENTITY:
                                {
                                    v.SetReferrer(persistenceUnit.GetEntity((string) declaration.GetReferrerName()));
                                    return v;
                                }
                        }
                    }
                    throw new System.ArgumentException ("'this' alias is not declared");
                }
                //check if field
                System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration> values = GetDeclarations(null, v, config);
                if (values != null) {
                    foreach (Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration @ref in values) {
                        switch(@ref.GetReferrerType()) {
                            case Net.Vpc.Upa.Impl.Uql.DecObjectType.ENTITY:
                                {
                                    Net.Vpc.Upa.Entity ee = persistenceUnit.GetEntity((string) @ref.GetReferrerName());
                                    if (ee.ContainsField(v.GetName())) {
                                        if (v.GetParentExpression() is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarVal) {
                                            //need no alias
                                            v.SetReferrer(ee.GetField(v.GetName()));
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
                                            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar v2 = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(v.GetName());
                                            v2.SetName(@ref.GetValidName());
                                            v2.SetReferrer(ee);
                                            v.GetParentExpression().ReplaceExpressions(new Net.Vpc.Upa.Impl.Uql.Compiledfilters.RefEqualCompiledExpressionFilter(v), new Net.Vpc.Upa.Impl.Uql.Compiledreplacer.ValueCompiledExpressionReplacer(v2));
                                            v.SetParentExpression(null);
                                            v.SetReferrer(ee.GetField(v.GetName()));
                                            v2.SetChild(v);
                                            return v2;
                                        }
                                    }
                                    break;
                                }
                        }
                    }
                }
                //check if alias
                values = GetDeclarations(v.GetName(), v, config);
                if (values != null) {
                    foreach (Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration @ref in values) {
                        switch(@ref.GetReferrerType()) {
                            case Net.Vpc.Upa.Impl.Uql.DecObjectType.ENTITY:
                                {
                                    v.SetReferrer(persistenceUnit.GetEntity((string) @ref.GetReferrerName()));
                                    return v;
                                }
                            case Net.Vpc.Upa.Impl.Uql.DecObjectType.FIELD:
                                {
                                    Net.Vpc.Upa.Entity ee = persistenceUnit.GetEntity((string) @ref.GetReferrerParent());
                                    v.SetReferrer(ee.GetField(v.GetName()));
                                    return v;
                                }
                        }
                        throw new System.ArgumentException ("Problem");
                    }
                }
                //check if entity
                if (persistenceUnit.ContainsEntity(v.GetName())) {
                    v.SetReferrer(persistenceUnit.GetEntity(v.GetName()));
                    return v;
                }
                if ("*".Equals(v.GetName())) {
                    return v;
                }
                if (thisAlias != null) {
                    Net.Vpc.Upa.Impl.Uql.CompiledExpressionReplacerTemp compiledExpressionReplacer = new Net.Vpc.Upa.Impl.Uql.CompiledExpressionReplacerTemp(thisAlias);
                    v.GetParentExpression().ReplaceExpressions(new Net.Vpc.Upa.Impl.Uql.Compiledfilters.RefEqualCompiledExpressionFilter(v), compiledExpressionReplacer);
                    //                v = compiledExpressionReplacer.e2;
                    //validateCompiledVar(implicitParent, config);
                    //check if field
                    System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration> values2 = GetDeclarations(thisAlias, v, config);
                    if (values2 != null) {
                        foreach (Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration @ref in values2) {
                            switch(@ref.GetReferrerType()) {
                                case Net.Vpc.Upa.Impl.Uql.DecObjectType.ENTITY:
                                    {
                                        Net.Vpc.Upa.Entity ee = persistenceUnit.GetEntity((string) @ref.GetReferrerName());
                                        if (ee.ContainsField(v.GetName())) {
                                            v.SetReferrer(ee.GetField(v.GetName()));
                                            return v;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                }
                //TODO remove me
                //            validateCompiledVar(v, config);
                throw new System.ArgumentException ("Field or alias not found : " + v.GetName());
            } else {
                string before = p.ToString();
                /*p =*/
                ValidateCompiledVarReferrer(p, config);
                object @ref = p.GetReferrer();
                if (@ref is Net.Vpc.Upa.Entity) {
                    Net.Vpc.Upa.Entity ee = (Net.Vpc.Upa.Entity) @ref;
                    if (ee.ContainsField(v.GetName())) {
                        v.SetReferrer(ee.GetField(v.GetName()));
                        ResolveToAlias(p);
                        return v;
                    } else if ("*".Equals(v.GetName())) {
                        return v;
                    }
                    throw new System.ArgumentException ("Field not found " + v.GetName());
                } else if (@ref is Net.Vpc.Upa.Field) {
                    Net.Vpc.Upa.Types.DataType dataType = ((Net.Vpc.Upa.Field) @ref).GetDataType();
                    if (dataType is Net.Vpc.Upa.Types.ManyToOneType) {
                        Net.Vpc.Upa.Types.ManyToOneType et = (Net.Vpc.Upa.Types.ManyToOneType) dataType;
                        Net.Vpc.Upa.Entity ee = et.GetRelationship().GetTargetRole().GetEntity();
                        if (ee.ContainsField(v.GetName())) {
                            v.SetReferrer(ee.GetField(v.GetName()));
                            ResolveToAlias(p);
                            return v;
                        } else if ("*".Equals(v.GetName())) {
                            return v;
                        }
                    }
                }
                throw new System.ArgumentException ("Field not found " + v.GetName());
            }
        }

        private Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar ResolveToAlias(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar p) {
            return p;
        }
    }
}
