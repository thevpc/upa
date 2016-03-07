package net.vpc.upa.impl.persistence;

import java.util.List;
import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.And;
import net.vpc.upa.expressions.Equals;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.ExpressionTag;
import net.vpc.upa.expressions.ExpressionVisitor;
import net.vpc.upa.expressions.Select;
import net.vpc.upa.expressions.TaggedExpression;
import net.vpc.upa.expressions.UserExpression;
import net.vpc.upa.expressions.Var;
import net.vpc.upa.impl.uql.CompiledExpressionHelper;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;
import net.vpc.upa.persistence.ExpressionCompilerConfig;
import net.vpc.upa.persistence.FieldPersister;
import net.vpc.upa.persistence.PersistenceStore;
import net.vpc.upa.types.EntityType;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 12/16/12 11:21 PM
 */
public class FieldPersistenceInfo {

    public Field field;
    public FieldPersister persistFieldPersister;
    public FieldPersister updateFieldPersister;
    public Expression insertExpression;
    public Expression updateExpression;
    public Expression findtExpression;
    public int persistFormulaPass;
    public int updateFormulaPass;
    public PersistenceStore persistenceStore;
    public boolean postPersistFormula;
    public boolean postUpdateFormula;

    private FieldPersister updateFieldPersister(FieldPersister oldValue, FieldPersister newValue) {
        if (oldValue != null && oldValue.equals(newValue)) {
            return oldValue;
        }
        return newValue;
    }

    public void synchronize() {
        if (field.getDataType() instanceof EntityType) {
            EntityType t = (EntityType) field.getDataType();
            Relationship relation = t.getRelationship();
            if (relation == null) {
                throw new UPAException("MissingRelationForField", field);
            }
            RelationshipRole detailRole = relation.getSourceRole();
            RelationshipUpdateType u = detailRole.getRelationshipUpdateType();
            if (u == RelationshipUpdateType.COMPOSED) {
                persistFieldPersister = new ComposedToFlatFieldPersister(field);
                updateFieldPersister = new ComposedToFlatFieldPersister(field);
            }
            persistFormulaPass = 0;
            updateFormulaPass = 0;
            postPersistFormula = false;
            postUpdateFormula = false;
            return;
        }
        Formula persistFormula = field.getPersistFormula();
        if (persistFormula != null) {
            if (persistFormula instanceof Sequence) {
                persistFieldPersister = updateFieldPersister(persistFieldPersister, persistenceStore.createPersistSequenceGenerator(field));
                persistFormulaPass = 0;
                postPersistFormula = false;
            } else if (persistFormula instanceof ExpressionFormula) {
                Expression e = ((ExpressionFormula) persistFormula).getExpression();
                Expression e0 = e;
                ExpressionCompilerConfig config = new ExpressionCompilerConfig();
                config.setExpandEntityFilter(false);
                //this is needed not to fire "this" alias usage exception
                config.setThisAlias("this");
                config.bindAliastoEntity("this", field.getEntity().getName());
                DefaultCompiledExpression ce = null;
                final ExpressionManager expressionManager = field.getEntity().getPersistenceUnit().getExpressionManager();
                try {
                    ce = (DefaultCompiledExpression) expressionManager.compileExpression(e, config);
                } catch (IllegalArgumentException ex) {
                    if (ex.getMessage().startsWith("No enclosing Select found for")) {
                        Select ss = new Select();
                        ss.field(e).from(field.getEntity().getName(), "this2");

                        Expression w = null;
                        for (Field primaryField : field.getEntity().getPrimaryFields()) {
                            Expression pfe = new Equals(new UserExpression("this." + primaryField.getName()), new UserExpression("this2." + primaryField.getName()));
                            if (w == null) {
                                w = pfe;
                            } else {
                                w = new And(w, pfe);
                            }
                        }
                        ExpressionVisitor expressionVisitor = new ThisRenamerVisitor(expressionManager,"this2");
                        ss.visit(expressionVisitor);
                        ss.where(w);
                        e = ss;
                    } else {
                        throw ex;
                    }
                    //throw new IllegalArgumentException("No enclosing Select found for " + v)
                }
                if (ce == null) {
                    ce = (DefaultCompiledExpression) expressionManager.compileExpression(e, config);
                    field.setPersistFormula(new ExpressionFormula(e));
                }

                List<DefaultCompiledExpression> complex = ce.findExpressionsList(CompiledExpressionHelper.THIS_VAR_FILTER);
                persistFormulaPass = field.getPersistFormulaOrder();
                if (complex.isEmpty() && persistFormulaPass == 0) {
                    insertExpression = e;
                    persistFieldPersister = updateFieldPersister(persistFieldPersister, new ExpressionFieldPersister(field.getName(), e));
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
        Formula updateFormula = field.getUpdateFormula();
        if (updateFormula != null) {
            if (updateFormula instanceof Sequence) {
                updateFieldPersister = updateFieldPersister(updateFieldPersister, persistenceStore.createUpdateSequenceGenerator(field));
                updateFormulaPass = 0;
                postUpdateFormula = false;
            } else if (updateFormula instanceof ExpressionFormula) {
                final Expression e = ((ExpressionFormula) updateFormula).getExpression();
                updateFormulaPass = field.getUpdateFormulaOrder();
                if (updateFormulaPass == 0) {
                    updateExpression = e;
                    updateFieldPersister = updateFieldPersister(updateFieldPersister, new ExpressionFieldPersister(field.getName(), e));
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
        Formula selectFormula = field.getSelectFormula();
        if (selectFormula != null) {
            if (selectFormula instanceof ExpressionFormula) {
                findtExpression = ((ExpressionFormula) selectFormula).getExpression();
            } else if (selectFormula instanceof Sequence) {
                throw new IllegalArgumentException("Sequences are not supported as Select Expressions");
            } else if (updateFormula instanceof CustomUpdaterFormula) {
                throw new IllegalArgumentException("CustomUpdaterFormulas are not supported as Select Expressions");
            }
        }
    }


}
