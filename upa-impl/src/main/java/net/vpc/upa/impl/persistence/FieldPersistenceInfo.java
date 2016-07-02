package net.vpc.upa.impl.persistence;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.And;
import net.vpc.upa.expressions.Equals;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.Select;
import net.vpc.upa.expressions.UserExpression;
import net.vpc.upa.impl.uql.compiledfilters.CompiledExpressionHelper;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;
import net.vpc.upa.impl.uql.util.UQLUtils;
import net.vpc.upa.persistence.ExpressionCompilerConfig;
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
        Expression e = ((ExpressionFormula) persistFormula).getExpression();
        RebuildExpressionInfo rr = new RebuildExpressionInfo();
        rr.initialFormula=((ExpressionFormula) persistFormula);
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
                UQLUtils.replaceThisVar(ss, "this2", expressionManager);
                ss.where(w);
                e = ss;
            } else {
                throw ex;
            }
            //throw new IllegalArgumentException("No enclosing Select found for " + v)
        }
        if (ce == null) {
            ce = (DefaultCompiledExpression) expressionManager.compileExpression(e, config);
            rr.compiledExpression = ce;
            rr.rebuiltFormula = (new ExpressionFormula(e));
        }else{
            rr.compiledExpression=ce;
        }
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
                boolean complex = re.compiledExpression.findFirstExpression(CompiledExpressionHelper.THIS_VAR_FILTER)!=null;
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
                RebuildExpressionInfo re = rebuildExpression((ExpressionFormula) persistFormula);
                if (re.rebuiltFormula != null) {
                    field.setUpdateFormula(re.rebuiltFormula);
                }
//                List<DefaultCompiledExpression> complex = re.compiledExpression.findExpressionsList(CompiledExpressionHelper.THIS_VAR_FILTER);
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
