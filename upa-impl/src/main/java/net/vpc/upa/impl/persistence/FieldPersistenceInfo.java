package net.vpc.upa.impl.persistence;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.impl.uql.util.ThisFilter;
import net.vpc.upa.persistence.FieldPersister;
import net.vpc.upa.persistence.PersistenceStore;
import net.vpc.upa.types.ManyToOneType;

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

    public RebuildExpressionInfo rebuildExpression(ExpressionFormula persistFormula) {
        Expression e = persistFormula.getExpression();
        RebuildExpressionInfo rr = new RebuildExpressionInfo();
        rr.initialFormula= persistFormula;
        rr.expression=e;
        return rr;
    }

    public void synchronize() {
        if (field.getDataType() instanceof ManyToOneType) {
            ManyToOneType t = (ManyToOneType) field.getDataType();
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
                RebuildExpressionInfo re = rebuildExpression((ExpressionFormula) persistFormula);
                if (re.rebuiltFormula != null) {
                    field.setPersistFormula(re.rebuiltFormula);
                }
                boolean complex = re.expression.findOne(ThisFilter.INSTANCE)!=null;
                persistFormulaPass = field.getPersistFormulaOrder();
                if (!complex && persistFormulaPass == 0) {
                    insertExpression = re.expression;
                    persistFieldPersister = updateFieldPersister(persistFieldPersister, new ExpressionFieldPersister(field.getName(), re.expression));
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
                RebuildExpressionInfo re = rebuildExpression((ExpressionFormula) updateFormula);
                if (re.rebuiltFormula != null) {
                    field.setUpdateFormula(re.rebuiltFormula);
                }
//                List<CompiledExpressionExt> complex = re.compiledExpression.findExpressionsList(CompiledExpressionUtils.THIS_VAR_FILTER);
                updateFormulaPass = field.getUpdateFormulaOrder();
                if (/*complex.isEmpty() && */updateFormulaPass == 0) {
                    updateExpression = re.expression;
                    updateFieldPersister = updateFieldPersister(updateFieldPersister, new ExpressionFieldPersister(field.getName(), re.expression));
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
