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

        public Net.Vpc.Upa.Persistence.FieldPersister insertFieldPersister;

        public Net.Vpc.Upa.Persistence.FieldPersister updateFieldPersister;

        public Net.Vpc.Upa.Expressions.Expression insertExpression;

        public Net.Vpc.Upa.Expressions.Expression updateExpression;

        public Net.Vpc.Upa.Expressions.Expression selectExpression;

        public int insertFormulaPass;

        public int updateFormulaPass;

        public Net.Vpc.Upa.Persistence.PersistenceStore persistenceStore;

        public bool postInsertFormula;

        public bool postUpdateFormula;

        private Net.Vpc.Upa.Persistence.FieldPersister UpdateFieldPersister(Net.Vpc.Upa.Persistence.FieldPersister oldValue, Net.Vpc.Upa.Persistence.FieldPersister newValue) {
            if (oldValue != null && oldValue.Equals(newValue)) {
                return oldValue;
            }
            return newValue;
        }

        public virtual void Synchronize() {
            if (field.GetDataType() is Net.Vpc.Upa.Types.EntityType) {
                Net.Vpc.Upa.Types.EntityType t = (Net.Vpc.Upa.Types.EntityType) field.GetDataType();
                Net.Vpc.Upa.Relationship relation = t.GetRelationship();
                if (relation == null) {
                    throw new Net.Vpc.Upa.Exceptions.UPAException("MissingRelationForField", field);
                }
                Net.Vpc.Upa.RelationshipRole detailRole = relation.GetSourceRole();
                Net.Vpc.Upa.RelationshipUpdateType u = detailRole.GetRelationshipUpdateType();
                if (u == Net.Vpc.Upa.RelationshipUpdateType.COMPOSED) {
                    insertFieldPersister = new Net.Vpc.Upa.Impl.Persistence.ComposedToFlatFieldPersister(field);
                    updateFieldPersister = new Net.Vpc.Upa.Impl.Persistence.ComposedToFlatFieldPersister(field);
                }
                insertFormulaPass = 0;
                updateFormulaPass = 0;
                postInsertFormula = false;
                postUpdateFormula = false;
                return;
            }
            Net.Vpc.Upa.Formula insertFormula = field.GetInsertFormula();
            if (insertFormula != null) {
                if (insertFormula is Net.Vpc.Upa.Sequence) {
                    insertFieldPersister = UpdateFieldPersister(insertFieldPersister, persistenceStore.CreateInsertSequenceGenerator(field));
                    insertFormulaPass = 0;
                    postInsertFormula = false;
                } else if (insertFormula is Net.Vpc.Upa.ExpressionFormula) {
                    Net.Vpc.Upa.Expressions.Expression e = ((Net.Vpc.Upa.ExpressionFormula) insertFormula).GetExpression();
                    Net.Vpc.Upa.Persistence.ExpressionCompilerConfig config = new Net.Vpc.Upa.Persistence.ExpressionCompilerConfig();
                    config.SetExpandEntityFilter(false);
                    //this is needed not to fire "this" alias usage exception
                    config.SetThisAlias("this");
                    config.BindAliastoEntity("this", field.GetEntity().GetName());
                    Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression ce = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) field.GetEntity().GetPersistenceUnit().GetExpressionManager().CompileExpression(e, config);
                    System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression> complex = ce.FindExpressionsList<Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression>(Net.Vpc.Upa.Impl.Uql.CompiledExpressionHelper.THIS_VAR_FILTER);
                    insertFormulaPass = field.GetInsertFormulaOrder();
                    if ((complex.Count==0) && insertFormulaPass == 0) {
                        insertExpression = e;
                        insertFieldPersister = UpdateFieldPersister(insertFieldPersister, new Net.Vpc.Upa.Impl.Persistence.ExpressionFieldPersister(field.GetName(), e));
                        postInsertFormula = false;
                    } else {
                        postInsertFormula = true;
                    }
                } else {
                    postInsertFormula = true;
                }
            } else {
                postInsertFormula = false;
            }
            Net.Vpc.Upa.Formula updateFormula = field.GetUpdateFormula();
            if (updateFormula != null) {
                if (updateFormula is Net.Vpc.Upa.Sequence) {
                    updateFieldPersister = UpdateFieldPersister(updateFieldPersister, persistenceStore.CreateUpdateSequenceGenerator(field));
                    updateFormulaPass = 0;
                    postUpdateFormula = false;
                } else if (updateFormula is Net.Vpc.Upa.ExpressionFormula) {
                    Net.Vpc.Upa.Expressions.Expression e = ((Net.Vpc.Upa.ExpressionFormula) updateFormula).GetExpression();
                    updateFormulaPass = field.GetUpdateFormulaOrder();
                    if (updateFormulaPass == 0) {
                        updateExpression = e;
                        updateFieldPersister = UpdateFieldPersister(updateFieldPersister, new Net.Vpc.Upa.Impl.Persistence.ExpressionFieldPersister(field.GetName(), e));
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
                    selectExpression = ((Net.Vpc.Upa.ExpressionFormula) selectFormula).GetExpression();
                } else if (selectFormula is Net.Vpc.Upa.Sequence) {
                    throw new System.ArgumentException ("Sequences are not supported as Select Expressions");
                } else if (updateFormula is Net.Vpc.Upa.CustomUpdaterFormula) {
                    throw new System.ArgumentException ("CustomUpdaterFormulas are not supported as Select Expressions");
                }
            }
        }
    }
}
