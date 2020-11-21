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



namespace Net.TheVpc.Upa.Impl.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 12/16/12 11:21 PM
     */
    public class FieldPersistenceInfo {

        public Net.TheVpc.Upa.Field field;

        public Net.TheVpc.Upa.Persistence.FieldPersister persistFieldPersister;

        public Net.TheVpc.Upa.Persistence.FieldPersister updateFieldPersister;

        public Net.TheVpc.Upa.Expressions.Expression insertExpression;

        public Net.TheVpc.Upa.Expressions.Expression updateExpression;

        public Net.TheVpc.Upa.Expressions.Expression findtExpression;

        public int persistFormulaPass;

        public int updateFormulaPass;

        public Net.TheVpc.Upa.Persistence.PersistenceStore persistenceStore;

        public bool postPersistFormula;

        public bool postUpdateFormula;

        private Net.TheVpc.Upa.Persistence.FieldPersister UpdateFieldPersister(Net.TheVpc.Upa.Persistence.FieldPersister oldValue, Net.TheVpc.Upa.Persistence.FieldPersister newValue) {
            if (oldValue != null && oldValue.Equals(newValue)) {
                return oldValue;
            }
            return newValue;
        }

        public virtual Net.TheVpc.Upa.Impl.Persistence.RebuildExpressionInfo RebuildExpression(Net.TheVpc.Upa.ExpressionFormula persistFormula) {
            Net.TheVpc.Upa.Expressions.Expression e = ((Net.TheVpc.Upa.ExpressionFormula) persistFormula).GetExpression();
            Net.TheVpc.Upa.Impl.Persistence.RebuildExpressionInfo rr = new Net.TheVpc.Upa.Impl.Persistence.RebuildExpressionInfo();
            rr.initialFormula = ((Net.TheVpc.Upa.ExpressionFormula) persistFormula);
            Net.TheVpc.Upa.Expressions.Expression e0 = e;
            Net.TheVpc.Upa.Persistence.ExpressionCompilerConfig config = new Net.TheVpc.Upa.Persistence.ExpressionCompilerConfig();
            config.SetExpandEntityFilter(false);
            //this is needed not to fire "this" alias usage exception
            config.SetThisAlias("this");
            config.BindAliastoEntity("this", field.GetEntity().GetName());
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression ce = null;
            Net.TheVpc.Upa.ExpressionManager expressionManager = field.GetEntity().GetPersistenceUnit().GetExpressionManager();
            try {
                ce = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) expressionManager.CompileExpression(e, config);
            } catch (System.ArgumentException  ex) {
                if ((ex).Message.StartsWith("No enclosing Select found for")) {
                    Net.TheVpc.Upa.Expressions.Select ss = new Net.TheVpc.Upa.Expressions.Select();
                    ss.Field(e).From(field.GetEntity().GetName(), "this2");
                    Net.TheVpc.Upa.Expressions.Expression w = null;
                    foreach (Net.TheVpc.Upa.Field primaryField in field.GetEntity().GetPrimaryFields()) {
                        Net.TheVpc.Upa.Expressions.Expression pfe = new Net.TheVpc.Upa.Expressions.Equals(new Net.TheVpc.Upa.Expressions.UserExpression("this." + primaryField.GetName()), new Net.TheVpc.Upa.Expressions.UserExpression("this2." + primaryField.GetName()));
                        if (w == null) {
                            w = pfe;
                        } else {
                            w = new Net.TheVpc.Upa.Expressions.And(w, pfe);
                        }
                    }
                    Net.TheVpc.Upa.Impl.Uql.Util.UQLUtils.ReplaceThisVar(ss, "this2", expressionManager);
                    ss.Where(w);
                    e = ss;
                } else {
                    throw ex;
                }
            }
            //throw new IllegalArgumentException("No enclosing Select found for " + v)
            if (ce == null) {
                ce = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) expressionManager.CompileExpression(e, config);
                rr.compiledExpression = ce;
                rr.rebuiltFormula = (new Net.TheVpc.Upa.ExpressionFormula(e));
            } else {
                rr.compiledExpression = ce;
            }
            rr.expression = e;
            return rr;
        }

        public virtual void Synchronize() {
            if (field.GetDataType() is Net.TheVpc.Upa.Types.ManyToOneType) {
                Net.TheVpc.Upa.Types.ManyToOneType t = (Net.TheVpc.Upa.Types.ManyToOneType) field.GetDataType();
                Net.TheVpc.Upa.Relationship relation = t.GetRelationship();
                if (relation == null) {
                    throw new Net.TheVpc.Upa.Exceptions.UPAException("MissingRelationForField", field);
                }
                Net.TheVpc.Upa.RelationshipRole detailRole = relation.GetSourceRole();
                Net.TheVpc.Upa.RelationshipUpdateType u = detailRole.GetRelationshipUpdateType();
                if (u == Net.TheVpc.Upa.RelationshipUpdateType.COMPOSED) {
                    persistFieldPersister = new Net.TheVpc.Upa.Impl.Persistence.ComposedToFlatFieldPersister(field);
                    updateFieldPersister = new Net.TheVpc.Upa.Impl.Persistence.ComposedToFlatFieldPersister(field);
                }
                persistFormulaPass = 0;
                updateFormulaPass = 0;
                postPersistFormula = false;
                postUpdateFormula = false;
                return;
            }
            Net.TheVpc.Upa.Formula persistFormula = field.GetPersistFormula();
            if (persistFormula != null) {
                if (persistFormula is Net.TheVpc.Upa.Sequence) {
                    persistFieldPersister = UpdateFieldPersister(persistFieldPersister, persistenceStore.CreatePersistSequenceGenerator(field));
                    persistFormulaPass = 0;
                    postPersistFormula = false;
                } else if (persistFormula is Net.TheVpc.Upa.ExpressionFormula) {
                    Net.TheVpc.Upa.Impl.Persistence.RebuildExpressionInfo re = RebuildExpression((Net.TheVpc.Upa.ExpressionFormula) persistFormula);
                    if (re.rebuiltFormula != null) {
                        field.SetPersistFormula(re.rebuiltFormula);
                    }
                    bool complex = re.compiledExpression.FindFirstExpression<T>(Net.TheVpc.Upa.Impl.Uql.Compiledfilters.CompiledExpressionHelper.THIS_VAR_FILTER) != default(T);
                    persistFormulaPass = field.GetPersistFormulaOrder();
                    if (!complex && persistFormulaPass == 0) {
                        insertExpression = re.expression;
                        persistFieldPersister = UpdateFieldPersister(persistFieldPersister, new Net.TheVpc.Upa.Impl.Persistence.ExpressionFieldPersister(field.GetName(), re.expression));
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
            Net.TheVpc.Upa.Formula updateFormula = field.GetUpdateFormula();
            if (updateFormula != null) {
                if (updateFormula is Net.TheVpc.Upa.Sequence) {
                    updateFieldPersister = UpdateFieldPersister(updateFieldPersister, persistenceStore.CreateUpdateSequenceGenerator(field));
                    updateFormulaPass = 0;
                    postUpdateFormula = false;
                } else if (updateFormula is Net.TheVpc.Upa.ExpressionFormula) {
                    Net.TheVpc.Upa.Impl.Persistence.RebuildExpressionInfo re = RebuildExpression((Net.TheVpc.Upa.ExpressionFormula) persistFormula);
                    if (re.rebuiltFormula != null) {
                        field.SetUpdateFormula(re.rebuiltFormula);
                    }
                    //                List<DefaultCompiledExpression> complex = re.compiledExpression.findExpressionsList(CompiledExpressionHelper.THIS_VAR_FILTER);
                    updateFormulaPass = field.GetUpdateFormulaOrder();
                    if (updateFormulaPass == 0) {
                        updateExpression = re.expression;
                        updateFieldPersister = UpdateFieldPersister(updateFieldPersister, new Net.TheVpc.Upa.Impl.Persistence.ExpressionFieldPersister(field.GetName(), re.expression));
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
            Net.TheVpc.Upa.Formula selectFormula = field.GetSelectFormula();
            if (selectFormula != null) {
                if (selectFormula is Net.TheVpc.Upa.ExpressionFormula) {
                    findtExpression = ((Net.TheVpc.Upa.ExpressionFormula) selectFormula).GetExpression();
                } else if (selectFormula is Net.TheVpc.Upa.Sequence) {
                    throw new System.ArgumentException ("Sequences are not supported as Select Expressions");
                } else if (updateFormula is Net.TheVpc.Upa.CustomUpdaterFormula) {
                    throw new System.ArgumentException ("CustomUpdaterFormulas are not supported as Select Expressions");
                }
            }
        }
    }
}
