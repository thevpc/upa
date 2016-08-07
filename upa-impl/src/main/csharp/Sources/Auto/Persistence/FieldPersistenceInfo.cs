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



namespace Net.Vpc.Upa.Impl.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 12/16/12 11:21 PM
     */
    public class FieldPersistenceInfo {

        public Net.Vpc.Upa.Field field;

        public Net.Vpc.Upa.Persistence.FieldPersister persistFieldPersister;

        public Net.Vpc.Upa.Persistence.FieldPersister updateFieldPersister;

        public Net.Vpc.Upa.Expressions.Expression insertExpression;

        public Net.Vpc.Upa.Expressions.Expression updateExpression;

        public Net.Vpc.Upa.Expressions.Expression findtExpression;

        public int persistFormulaPass;

        public int updateFormulaPass;

        public Net.Vpc.Upa.Persistence.PersistenceStore persistenceStore;

        public bool postPersistFormula;

        public bool postUpdateFormula;

        private Net.Vpc.Upa.Persistence.FieldPersister UpdateFieldPersister(Net.Vpc.Upa.Persistence.FieldPersister oldValue, Net.Vpc.Upa.Persistence.FieldPersister newValue) {
            if (oldValue != null && oldValue.Equals(newValue)) {
                return oldValue;
            }
            return newValue;
        }

        public virtual Net.Vpc.Upa.Impl.Persistence.RebuildExpressionInfo RebuildExpression(Net.Vpc.Upa.ExpressionFormula persistFormula) {
            Net.Vpc.Upa.Expressions.Expression e = ((Net.Vpc.Upa.ExpressionFormula) persistFormula).GetExpression();
            Net.Vpc.Upa.Impl.Persistence.RebuildExpressionInfo rr = new Net.Vpc.Upa.Impl.Persistence.RebuildExpressionInfo();
            rr.initialFormula = ((Net.Vpc.Upa.ExpressionFormula) persistFormula);
            Net.Vpc.Upa.Expressions.Expression e0 = e;
            Net.Vpc.Upa.Persistence.ExpressionCompilerConfig config = new Net.Vpc.Upa.Persistence.ExpressionCompilerConfig();
            config.SetExpandEntityFilter(false);
            //this is needed not to fire "this" alias usage exception
            config.SetThisAlias("this");
            config.BindAliastoEntity("this", field.GetEntity().GetName());
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression ce = null;
            Net.Vpc.Upa.ExpressionManager expressionManager = field.GetEntity().GetPersistenceUnit().GetExpressionManager();
            try {
                ce = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) expressionManager.CompileExpression(e, config);
            } catch (System.ArgumentException  ex) {
                if ((ex).Message.StartsWith("No enclosing Select found for")) {
                    Net.Vpc.Upa.Expressions.Select ss = new Net.Vpc.Upa.Expressions.Select();
                    ss.Field(e).From(field.GetEntity().GetName(), "this2");
                    Net.Vpc.Upa.Expressions.Expression w = null;
                    foreach (Net.Vpc.Upa.Field primaryField in field.GetEntity().GetPrimaryFields()) {
                        Net.Vpc.Upa.Expressions.Expression pfe = new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.UserExpression("this." + primaryField.GetName()), new Net.Vpc.Upa.Expressions.UserExpression("this2." + primaryField.GetName()));
                        if (w == null) {
                            w = pfe;
                        } else {
                            w = new Net.Vpc.Upa.Expressions.And(w, pfe);
                        }
                    }
                    Net.Vpc.Upa.Impl.Uql.Util.UQLUtils.ReplaceThisVar(ss, "this2", expressionManager);
                    ss.Where(w);
                    e = ss;
                } else {
                    throw ex;
                }
            }
            //throw new IllegalArgumentException("No enclosing Select found for " + v)
            if (ce == null) {
                ce = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) expressionManager.CompileExpression(e, config);
                rr.compiledExpression = ce;
                rr.rebuiltFormula = (new Net.Vpc.Upa.ExpressionFormula(e));
            } else {
                rr.compiledExpression = ce;
            }
            rr.expression = e;
            return rr;
        }

        public virtual void Synchronize() {
            if (field.GetDataType() is Net.Vpc.Upa.Types.ManyToOneType) {
                Net.Vpc.Upa.Types.ManyToOneType t = (Net.Vpc.Upa.Types.ManyToOneType) field.GetDataType();
                Net.Vpc.Upa.Relationship relation = t.GetRelationship();
                if (relation == null) {
                    throw new Net.Vpc.Upa.Exceptions.UPAException("MissingRelationForField", field);
                }
                Net.Vpc.Upa.RelationshipRole detailRole = relation.GetSourceRole();
                Net.Vpc.Upa.RelationshipUpdateType u = detailRole.GetRelationshipUpdateType();
                if (u == Net.Vpc.Upa.RelationshipUpdateType.COMPOSED) {
                    persistFieldPersister = new Net.Vpc.Upa.Impl.Persistence.ComposedToFlatFieldPersister(field);
                    updateFieldPersister = new Net.Vpc.Upa.Impl.Persistence.ComposedToFlatFieldPersister(field);
                }
                persistFormulaPass = 0;
                updateFormulaPass = 0;
                postPersistFormula = false;
                postUpdateFormula = false;
                return;
            }
            Net.Vpc.Upa.Formula persistFormula = field.GetPersistFormula();
            if (persistFormula != null) {
                if (persistFormula is Net.Vpc.Upa.Sequence) {
                    persistFieldPersister = UpdateFieldPersister(persistFieldPersister, persistenceStore.CreatePersistSequenceGenerator(field));
                    persistFormulaPass = 0;
                    postPersistFormula = false;
                } else if (persistFormula is Net.Vpc.Upa.ExpressionFormula) {
                    Net.Vpc.Upa.Impl.Persistence.RebuildExpressionInfo re = RebuildExpression((Net.Vpc.Upa.ExpressionFormula) persistFormula);
                    if (re.rebuiltFormula != null) {
                        field.SetPersistFormula(re.rebuiltFormula);
                    }
                    bool complex = re.compiledExpression.FindFirstExpression<T>(Net.Vpc.Upa.Impl.Uql.Compiledfilters.CompiledExpressionHelper.THIS_VAR_FILTER) != default(T);
                    persistFormulaPass = field.GetPersistFormulaOrder();
                    if (!complex && persistFormulaPass == 0) {
                        insertExpression = re.expression;
                        persistFieldPersister = UpdateFieldPersister(persistFieldPersister, new Net.Vpc.Upa.Impl.Persistence.ExpressionFieldPersister(field.GetName(), re.expression));
                        postPersistFormula = false;
                    } else {
                        postPersistFormula = true;
                    }
                } else {
                    postPersistFormula = true;
                }
            } else {
                postPersistFormula = false;
            }
            Net.Vpc.Upa.Formula updateFormula = field.GetUpdateFormula();
            if (updateFormula != null) {
                if (updateFormula is Net.Vpc.Upa.Sequence) {
                    updateFieldPersister = UpdateFieldPersister(updateFieldPersister, persistenceStore.CreateUpdateSequenceGenerator(field));
                    updateFormulaPass = 0;
                    postUpdateFormula = false;
                } else if (updateFormula is Net.Vpc.Upa.ExpressionFormula) {
                    Net.Vpc.Upa.Impl.Persistence.RebuildExpressionInfo re = RebuildExpression((Net.Vpc.Upa.ExpressionFormula) persistFormula);
                    if (re.rebuiltFormula != null) {
                        field.SetUpdateFormula(re.rebuiltFormula);
                    }
                    //                List<DefaultCompiledExpression> complex = re.compiledExpression.findExpressionsList(CompiledExpressionHelper.THIS_VAR_FILTER);
                    updateFormulaPass = field.GetUpdateFormulaOrder();
                    if (updateFormulaPass == 0) {
                        updateExpression = re.expression;
                        updateFieldPersister = UpdateFieldPersister(updateFieldPersister, new Net.Vpc.Upa.Impl.Persistence.ExpressionFieldPersister(field.GetName(), re.expression));
                        postUpdateFormula = false;
                    } else {
                        postUpdateFormula = true;
                    }
                } else {
                    postUpdateFormula = true;
                }
            } else {
                postUpdateFormula = true;
            }
            Net.Vpc.Upa.Formula selectFormula = field.GetSelectFormula();
            if (selectFormula != null) {
                if (selectFormula is Net.Vpc.Upa.ExpressionFormula) {
                    findtExpression = ((Net.Vpc.Upa.ExpressionFormula) selectFormula).GetExpression();
                } else if (selectFormula is Net.Vpc.Upa.Sequence) {
                    throw new System.ArgumentException ("Sequences are not supported as Select Expressions");
                } else if (updateFormula is Net.Vpc.Upa.CustomUpdaterFormula) {
                    throw new System.ArgumentException ("CustomUpdaterFormulas are not supported as Select Expressions");
                }
            }
        }
    }
}
