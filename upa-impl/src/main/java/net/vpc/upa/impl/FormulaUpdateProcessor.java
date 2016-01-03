/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.*;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;
import net.vpc.upa.persistence.EntityOperationManager;
import net.vpc.upa.persistence.EntityExecutionContext;

import java.util.*;
import net.vpc.upa.impl.uql.CompiledExpressionHelper;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class FormulaUpdateProcessor {

    boolean nothingToValidate = false;
    boolean forceExpressionTypeCasting = false;
    private Map<Integer, ValidationPass[]> orderedPasses = new HashMap<Integer, ValidationPass[]>(1);
    // private TreeSet passIndexes = new TreeSet();
    private Set<Field> inUseFields = new HashSet<Field>();
    private int size = 0;
    private EntityOperationManager entityOperationManager;
    private PersistenceUnit persistenceUnit;
    private Entity entity;
    private boolean onPersist;
    private Expression expr;
    private EntityExecutionContext context;
    private List<Object> keysToUpdate = null;

    public FormulaUpdateProcessor(boolean onPersist, List<Field> fields, Expression expr, EntityExecutionContext context, Entity entity, EntityOperationManager epm) {
        this.entityOperationManager = epm;
        this.entity = entity;
        this.expr = expr;
        this.context = context;
        this.onPersist = onPersist;
        this.persistenceUnit = entity.getPersistenceUnit();
        for (Field field : fields) {
            addField(field);
        }
    }

    private static Expression getFieldExpression(Field field, boolean forPersist) {
        if (forPersist) {
            return (field.getPersistFormula() instanceof ExpressionFormula) ? ((ExpressionFormula) field.getPersistFormula()).getExpression() : null;
        } else {
            return (field.getUpdateFormula() instanceof ExpressionFormula) ? ((ExpressionFormula) field.getUpdateFormula()).getExpression() : null;
        }
    }

    public boolean addField(Field f) {
        if (inUseFields.contains(f)) {
            return false;
        }
        Formula formula = onPersist ? f.getPersistFormula() : f.getUpdateFormula();
        ValidationPass pass = null;
        int formulaPassInteger = onPersist ? f.getPersistFormulaOrder() : f.getUpdateFormulaOrder();
        // passIndexes.add(formulaPassInteger);
        ValidationPass[] passArray = orderedPasses.get(formulaPassInteger);
        if (passArray == null) {
            orderedPasses.put(formulaPassInteger, passArray = new ValidationPass[ValidationPassType.values().length]);
        }
        int pass1 = formulaPassInteger;
        if (formula instanceof CustomUpdaterFormula) {
            pass = passArray[ValidationPassType.MANUAL_VALIDATION.ordinal()];
            if (pass == null) {
                pass = passArray[ValidationPassType.MANUAL_VALIDATION.ordinal()] = new ValidationPass(pass1, ValidationPassType.MANUAL_VALIDATION);
                size++;
            }
        } else if (formula instanceof CustomFormula) {
            pass = passArray[ValidationPassType.CUSTOM_VALIDATION.ordinal()];
            if (pass == null) {
                pass = passArray[ValidationPassType.CUSTOM_VALIDATION.ordinal()] = new ValidationPass(pass1, ValidationPassType.CUSTOM_VALIDATION);
                size++;
            }
        } else {
            if (!entityOperationManager.getPersistenceStore().isComplexSelectSupported()) {
                Expression fe = getFieldExpression(f, onPersist);

                DefaultCompiledExpression ce = (DefaultCompiledExpression) entity.compile(fe);
                List<DefaultCompiledExpression> found = ce.findExpressionsList(CompiledExpressionHelper.QUERY_STATEMENT_FILTER);
                if (found.size() > 0) {
                    pass = passArray[ValidationPassType.ITERATIVE_VALIDATION.ordinal()];
                    if (pass == null) {
                        pass = passArray[ValidationPassType.ITERATIVE_VALIDATION.ordinal()] = new ValidationPass(pass1, ValidationPassType.ITERATIVE_VALIDATION);
                        size++;
                    }
                } else {
                    pass = passArray[ValidationPassType.DEFAULT_VALIDATION.ordinal()];
                    if (pass == null) {
                        pass = passArray[ValidationPassType.DEFAULT_VALIDATION.ordinal()] = new ValidationPass(pass1, ValidationPassType.DEFAULT_VALIDATION);
                        size++;
                    }
                }
            } else {
                pass = passArray[ValidationPassType.DEFAULT_VALIDATION.ordinal()];
                if (pass == null) {
                    pass = passArray[ValidationPassType.DEFAULT_VALIDATION.ordinal()] = new ValidationPass(pass1, ValidationPassType.DEFAULT_VALIDATION);
                    size++;
                }
            }
        }
        pass.fields.add(f);
        inUseFields.add(f);
        Collection<PrimitiveField> dependency = (Collection<PrimitiveField>) f.getProperties().getObject(onPersist ? DefaultEntity.PERSIST_DEPENDENT_FIELDS : DefaultEntity.UPDATE_DEPENDENT_FIELDS);
        if (dependency != null) {
            for (PrimitiveField aDependency : dependency) {
                PrimitiveField df = (PrimitiveField) aDependency;
                //include only dependent fields from the same entity
                if (df.getEntity().getName().equals(f.getEntity().getName())) {
                    // add only formulas fields that are validateSupported
                    if (onPersist) {
                        Formula ff = df.getPersistFormula();
                        if (ff != null && df.getModifiers().contains(FieldModifier.PERSIST_FORMULA)) {
                            addField(df);
                        }
                    } else {
                        Formula ff = df.getUpdateFormula();
                        if (ff != null && df.getModifiers().contains(FieldModifier.UPDATE_FORMULA)) {
                            addField(df);
                        }
                    }
                }
            }
        }
        return true;
    }

    public int size() {
        return size;
    }

    public int size0() {
        TreeSet<ValidationPass> ts = new TreeSet<ValidationPass>();
        for (ValidationPass[] o : orderedPasses.values()) {
            for (int i = 0; i < 4; i++) {
                if (o[i] != null) {
                    ts.add(o[i]);
                }
            }
        }
        return ts.size();
    }

    public Collection<ValidationPass> getValidationPasses() {
        TreeSet<ValidationPass> ts = new TreeSet<ValidationPass>();
        for (ValidationPass[] o : orderedPasses.values()) {
            for (int i = 0; i < 4; i++) {
                if (o[i] != null) {
                    ts.add(o[i]);
                }
            }
        }
        return ts;
    }

    public void updateFormulasCore() throws UPAException {
//        Object transaction = getPersistenceUnit().getPersistenceStore().getConnection().tryBeginTransaction();
//        boolean transactionSucceeded = false;
//        try {

        keysToUpdate = null;
//            if (monitor != null) {
//                if (monitor.isStopped()) {
//                    return;
//                }
//                monitor.setIndeterminate(false);
//                monitor.setIndex(0);
//                monitor.setMax(data.size0());
//                System.out.println("Validate " + getName() + " : max = "
//                        + monitor.getMax());
//            }
        for (ValidationPass validationPass : getValidationPasses()) {
            int updates = 0;
            switch (validationPass.type) {
                case DEFAULT_VALIDATION: {
                    updates = validateDefault(validationPass.fields, expr);
                    break;
                }
                case ITERATIVE_VALIDATION: {
                    updates = validateDefaultIterative(validationPass.fields, expr);
                    break;
                }
                case CUSTOM_VALIDATION: {
                    updates = validateCustomFormula(validationPass.fields);
                    break;
                }
                case MANUAL_VALIDATION: {
                    // System.out.println("MANUAL_VALIDATION = " +
                    // validationPass.pass+" : "+validationPass.fields);
                    updates = validateCustomUpdaterFormula(validationPass.fields);
//                        if (monitor != null) {
//                            if (monitor.isStopped()) {
//                                return;
//                            }
//                            monitor.progress(String.valueOf(validationPass.pass),
//                                    "Passe " + (validationPass.pass + 1), null);
//                        }
                    break;
                }
            }
            if (updates == 0) {
                break;
            }
        }
//            transactionSucceeded = true;
//        } finally {
//            getPersistenceUnit().getPersistenceManager().getConnection().tryFinalizeTransaction(
//                    transactionSucceeded, transaction);
//        }
    }

    protected int validateCustomUpdaterFormula(Set<Field> fields) throws UPAException {
        LinkedHashSet<CustomUpdaterFormula> unique = new LinkedHashSet<CustomUpdaterFormula>();
        for (Field field : fields) {
            CustomUpdaterFormula c = (CustomUpdaterFormula) (onPersist ? field.getPersistFormula() : field.getUpdateFormula());
            unique.add(c);
        }
        for (CustomUpdaterFormula f : unique) {
            f.updateFormula(fields, expr, context);
        }
        return (int) entity.getEntityCount(expr);
    }

    protected int validateCustomFormula(Set<Field> fields) throws UPAException {
//                        if (monitor != null) {
//                            if (monitor.isStopped()) {
//                                return;
//                            }
//                            monitor.stepIn(keysToUpdate.size());
//                        }
        int x = 0;
        for (Object aKeysToUpdate : getKeysToUpdate()) {
//                            if (monitor != null) {
//                                if (monitor.isStopped()) {
//                                    return;
//                                }
//                                monitor.progress(String.valueOf(validationPass.pass), "Passe "
//                                        + (validationPass.pass + 1), null);
//                            }
            // System.out.println("ITERATIVE_VALIDATION = " +
            // validationPass.pass+" : "+validationPass.fields+" :
            // "+keysToUpdate[r]);
            Record u = entity.getBuilder().createRecord();
            for (Field field : fields) {
                CustomFormula cf = (CustomFormula) (onPersist ? field.getPersistFormula() : field.getUpdateFormula());
                Object v = cf.getValue(field, aKeysToUpdate, context);
                u.setObject(field.getName(), new Cast(new Param(null, v), field.getDataType()));
            }
            x += entity.updateCore(u, entity.getBuilder().idToExpression(aKeysToUpdate, entity.getName()), context);
        }
//                        if (monitor != null) {
//                            monitor.stepOut();
//                        }
        return x;
    }

    private List<Object> getKeysToUpdate() {
        if (keysToUpdate == null) {
            keysToUpdate = entity.createQueryBuilder().setExpression(expr).setOrder(entity.getUpdateFormulasOrder()).getIdList();
            if (keysToUpdate.isEmpty()) {
                nothingToValidate = true;
            }
        }
        return keysToUpdate;
    }

    protected int validateDefaultIterative(Set<Field> fields, Expression expression) throws UPAException {
//                        if (monitor != null) {
//                            if (monitor.isStopped()) {
//                                return;
//                            }
//                            monitor.stepIn(keysToUpdate.size());
//                        }
        int x = 0;
        for (Object aKeysToUpdate : getKeysToUpdate()) {
//                            if (monitor != null) {
//                                if (monitor.isStopped()) {
//                                    return;
//                                }
//                                monitor.progress(String.valueOf(validationPass.pass), "Passe "
//                                        + (validationPass.pass + 1), null);
//                            }
            // System.out.println("ITERATIVE_VALIDATION = " +
            // validationPass.pass+" : "+validationPass.fields+" :
            // "+keysToUpdate[r]);
            x += validateDefault(fields, entity.getBuilder().idToExpression(aKeysToUpdate, entity.getName()));
        }
//                        if (monitor != null) {
//                            monitor.stepOut();
//                        }
        return x;
    }

    protected int validateDefault(Collection<Field> fields, Expression expression) throws UPAException {
        // System.out.println("DEFAULT_VALIDATION = " +
        // validationPass.pass+" : "+ validationPass.fields);
        Record u = entity.getBuilder().createRecord();
        for (Field field : fields) {
            Expression fieldExpression = getFieldExpression(field, onPersist);
            Expression validExpression = fieldExpression;
            if (forceExpressionTypeCasting || (fieldExpression instanceof Literal && ((Literal) fieldExpression).getValue() == null)) {
                validExpression = new Cast(fieldExpression, field.getDataType());
            }
            u.setObject(field.getName(), validExpression);
        }
        try {
            return entity.updateCore(u, expression, context);
        } catch (UPAException ex) {
//            Log.bug(ex);
            Select sb0 = new Select();
            for (Field f : fields) {
                Expression fieldExpression = getFieldExpression(f, onPersist);
                sb0.field(fieldExpression, f.getName() + "Expression");
                Expression validExpression = fieldExpression;
                if (forceExpressionTypeCasting || (fieldExpression instanceof Literal && ((Literal) fieldExpression).getValue() == null)) {
                    validExpression = new Cast(fieldExpression, f.getDataType());
                }
                sb0.field(validExpression, f.getName() + "CastExpression");
            }
            sb0.from(entity.getName());
            sb0.setWhere(expression);

//            Log.bug("Values to update are : ");
            for (Record ur : entity.createQuery(sb0).getRecordList()) {
                for (Map.Entry<String, Object> entry : ur.toMap().entrySet()) {
                    //Log.bug(entry.getKey() + " : " + entry.getValue());
                }
            }
            throw ex;
        }
//                        if (monitor != null) {
//                            if (monitor.isStopped()) {
//                                return;
//                            }
//                            monitor.progress(String.valueOf(validationPass.pass),
//                                    "Passe " + (validationPass.pass + 1), null);
//                        }
    }

}
