/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.persistence;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.*;
import net.vpc.upa.impl.DefaultEntity;
import net.vpc.upa.impl.eval.DefaultCustomMultiFormulaContext;
import net.vpc.upa.impl.ext.EntityExt;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.uql.util.UQLCompiledUtils;
import net.vpc.upa.impl.uql.util.UQLUtils;
import net.vpc.upa.impl.util.UPAUtils;
import net.vpc.upa.persistence.EntityOperationManager;
import net.vpc.upa.persistence.EntityExecutionContext;

import java.util.*;

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
    boolean isUpdateComplexValuesStatementSupported;
    boolean isUpdateComplexValuesIncludingUpdatedTableSupported;

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
        isUpdateComplexValuesStatementSupported = persistenceUnit.getPersistenceStore().getStoreParameters().getBoolean("isUpdateComplexValuesStatementSupported", false);
        isUpdateComplexValuesIncludingUpdatedTableSupported = persistenceUnit.getPersistenceStore().getStoreParameters().getBoolean("isUpdateComplexValuesIncludingUpdatedTableSupported", false);
    }

    private static Expression getFieldExpression(Field field, boolean forPersist) {
        if (forPersist) {
            return (UPAUtils.getPersistFormula(field) instanceof ExpressionFormula) ? ((ExpressionFormula) UPAUtils.getPersistFormula(field)).getExpression() : null;
        } else {
            return (UPAUtils.getUpdateFormula(field) instanceof ExpressionFormula) ? ((ExpressionFormula) UPAUtils.getUpdateFormula(field)).getExpression() : null;
        }
    }

    public boolean addField(Field f) {
        if (inUseFields.contains(f)) {
            return false;
        }
        Formula formula = UPAUtils.getFormula(f,onPersist);
        ValidationPass pass = null;
        int formulaPassInteger = onPersist ? f.getPersistFormulaOrder() : f.getUpdateFormulaOrder();
        // passIndexes.add(formulaPassInteger);
        ValidationPass[] passArray = orderedPasses.get(formulaPassInteger);
        if (passArray == null) {
            orderedPasses.put(formulaPassInteger, passArray = new ValidationPass[ValidationPassType.values().length]);
        }
        int pass1 = formulaPassInteger;
        if (formula instanceof CustomMultiFormula) {
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
        } else if (!entityOperationManager.getPersistenceStore().isComplexSelectSupported()) {
            Expression fe = getFieldExpression(f, onPersist);

            CompiledExpressionExt ce = (CompiledExpressionExt) entity.compile(fe, null);
            boolean found = ce.findFirstExpression(UQLCompiledUtils.QUERY_STATEMENT_FILTER) != null;
            if (found) {
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
        pass.getFields().add(f);
        inUseFields.add(f);
        Collection<PrimitiveField> dependency = (Collection<PrimitiveField>) f.getProperties().getObject(onPersist ? DefaultEntity.PERSIST_DEPENDENT_FIELDS : DefaultEntity.UPDATE_DEPENDENT_FIELDS);
        if (dependency != null) {
            for (PrimitiveField aDependency : dependency) {
                PrimitiveField df = (PrimitiveField) aDependency;
                //include only dependent fields from the same entity
                if (df.getEntity().getName().equals(f.getEntity().getName())) {
                    // add only formulas fields that are validateSupported
                    if (onPersist) {
                        Formula ff = UPAUtils.getPersistFormula(df);
                        if (ff != null && df.getModifiers().contains(FieldModifier.PERSIST_FORMULA)) {
                            addField(df);
                        }
                    } else {
                        Formula ff = UPAUtils.getUpdateFormula(df);
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
            for (int i = 0; i < o.length; i++) {
                if (o[i] != null) {
                    ts.add(o[i]);
                }
            }
        }
        return ts;
    }

    public long updateFormulasCore() throws UPAException {
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
        int allUpdates = 0;
        for (ValidationPass validationPass : getValidationPasses()) {
            int updates = 0;
            switch (validationPass.getType()) {
                case DEFAULT_VALIDATION: {
                    updates = validateDefault(validationPass.getFields(), expr);
                    break;
                }
                case ITERATIVE_VALIDATION: {
                    updates = validateDefaultIterative(validationPass.getFields(), expr);
                    break;
                }
                case CUSTOM_VALIDATION: {
                    updates = validateCustomFormula(validationPass.getFields());
                    break;
                }
                case MANUAL_VALIDATION: {
                    // System.out.println("MANUAL_VALIDATION = " +
                    // validationPass.pass+" : "+validationPass.fields);
                    updates = validateCustomMultiFormula(validationPass.getFields());
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
            allUpdates += updates;
            if (updates == 0) {
                break;
            }
        }
        return allUpdates;
//            transactionSucceeded = true;
//        } finally {
//            getPersistenceUnit().getPersistenceManager().getConnection().tryFinalizeTransaction(
//                    transactionSucceeded, transaction);
//        }
    }

    protected int validateCustomMultiFormula(Set<Field> fields) throws UPAException {
        LinkedHashSet<CustomMultiFormula> unique = new LinkedHashSet<CustomMultiFormula>();
        for (Field field : fields) {
            CustomMultiFormula c = (CustomMultiFormula) UPAUtils.getFormula(field,onPersist);
            unique.add(c);
        }
        DefaultCustomMultiFormulaContext context = new DefaultCustomMultiFormulaContext(fields, expr, this.context);
        for (CustomMultiFormula f : unique) {
            f.updateFormulas(context);
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
            Document u = entity.getBuilder().createDocument();
            for (Field field : fields) {
                CustomFormula cf = (CustomFormula) UPAUtils.getFormula(field,onPersist);
                Object v = cf.getValue(new DefaultCustomFormulaContext(field, aKeysToUpdate, context));
                u.setObject(field.getName(), new Cast(new Param(null, v), field.getDataType()));
            }
            x += ((EntityExt) entity).updateCore(u, entity.getBuilder().idToExpression(aKeysToUpdate, UQLUtils.THIS), context);
        }
//                        if (monitor != null) {
//                            monitor.stepOut();
//                        }
        return x;
    }

    private List<Object> getKeysToUpdate() {
        if (keysToUpdate == null) {
            keysToUpdate = entity.createQueryBuilder().byExpression(expr).orderBy(entity.getUpdateFormulasOrder()).getIdList();
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
            x += validateDefault(fields, entity.getBuilder().idToExpression(aKeysToUpdate, UQLUtils.THIS));
        }
//                        if (monitor != null) {
//                            monitor.stepOut();
//                        }
        return x;
    }

    protected int validateDefault(Collection<Field> fields, Expression expression) throws UPAException {
        // System.out.println("DEFAULT_VALIDATION = " +
        // validationPass.pass+" : "+ validationPass.fields);
        Document u = entity.getBuilder().createDocument();
        for (Field field : fields) {
            Expression fieldExpression = getFieldExpression(field, onPersist);
            Expression validExpression = fieldExpression;
            if (forceExpressionTypeCasting || (fieldExpression instanceof Literal && ((Literal) fieldExpression).getValue() == null)) {
                validExpression = new Cast(fieldExpression, field.getDataType());
            }
            u.setObject(field.getName(), validExpression);
        }
        try {
            return ((EntityExt) entity).updateCore(u, expression, context);
        } catch (UPAException ex) {
//            Log.bug(ex);
//            Select sb0 = new Select();
//            for (Field f : fields) {
//                Expression fieldExpression = getFieldExpression(f, onPersist);
//                sb0.field(fieldExpression, f.getName() + "Expression");
//                Expression validExpression = fieldExpression;
//                if (forceExpressionTypeCasting || (fieldExpression instanceof Literal && ((Literal) fieldExpression).getValue() == null)) {
//                    validExpression = new Cast(fieldExpression, f.getDataType());
//                }
//                sb0.field(validExpression, f.getName() + "CastExpression");
//            }
//            sb0.from(entity.getName());
//            sb0.setWhere(expression);
//
////            Log.bug("Values to update are : ");
//            for (Document ur : entity.createQuery(sb0).getDocumentList()) {
//                for (Map.Entry<String, Object> entry : ur.toMap().entrySet()) {
//                    //Log.bug(entry.getKey() + " : " + entry.getValue());
//                }
//            }
            throw ex;
        }
    }

//    private static final String COMPLEX_SELECT_PERSIST = "Store.COMPLEX_SELECT_PERSIST";
//    private static final String COMPLEX_SELECT_MERGE = "Store.COMPLEX_SELECT_MERGE";
//
//    protected int validateDefault(Collection<Field> fields, Expression expression) throws UPAException {
//        EntityBuilder eb = entity.getBuilder();
//        // System.out.println("DEFAULT_VALIDATION = " +
//        // validationPass.pass+" : "+ validationPass.fields);
////        map.setBoolean("isUpdateComplexValuesStatementSupported", Boolean.TRUE);
////        map.setBoolean("isUpdateComplexValuesIncludingUpdatedTableSupported", Boolean.TRUE);
//        Document u = eb.createDocument();
//        LinkedHashMap<String, Expression> selectBasedFields = new LinkedHashMap<String, Expression>();
//
//        if (isUpdateComplexValuesIncludingUpdatedTableSupported) {
//            //no test to do!
//            for (Field field : fields) {
//                Expression fieldExpression = getFieldExpression(field, onPersist);
//                Expression validExpression = fieldExpression;
//                if (forceExpressionTypeCasting || (fieldExpression instanceof Literal && ((Literal) fieldExpression).getValue() == null)) {
//                    validExpression = new Cast(fieldExpression, field.getDataType());
//                }
//                u.setObject(field.getName(), validExpression);
//            }
//        } else {
//            for (Field field : fields) {
//                Expression fieldExpression = getFieldExpression(field, onPersist);
//                Expression validExpression = fieldExpression;
//                String complexSelectKey = onPersist ? COMPLEX_SELECT_PERSIST : COMPLEX_SELECT_MERGE;
//                String complexSelectString = field.getProperties().getString(complexSelectKey, null);
//                boolean complexSelect = false;
//                if (complexSelectString == null) {
//                    for (Expression s : fieldExpression.findAll(new TypeExpressionFilter(Select.class))) {
//                        Select ss = (Select) s;
//                        if (isUpdateComplexValuesStatementSupported) {
//                            if (ss.getEntity() != null) {
//                                boolean meFound = false;
//                                String ssentityName = ss.getEntityName();
//                                if (ssentityName != null && ssentityName.equals(entity.getName())) {
//                                    meFound = true;
//                                }
//                                if (!meFound) {
//                                    for (JoinCriteria join : ss.getJoins()) {
//                                        String jentityName = join.getEntityName();
//                                        if (jentityName != null && jentityName.equals(entity.getName())) {
//                                            meFound = true;
//                                        }
//                                    }
//                                }
//                                if (meFound) {
//                                    complexSelect = true;
//                                }
//                            }
//                        } else {
//                            complexSelect = true;
//                        }
//                    }
//                    field.getProperties().setString(complexSelectKey, String.valueOf(complexSelect));
//                } else {
//                    complexSelect = Boolean.valueOf(complexSelectString);
//                }
//
//                if (forceExpressionTypeCasting || (fieldExpression instanceof Literal && ((Literal) fieldExpression).getValue() == null)) {
//                    validExpression = new Cast(fieldExpression, field.getDataType());
//                }
//                if (complexSelect) {
//                    selectBasedFields.put(field.getName(), validExpression);
//                } else {
//                    u.setObject(field.getName(), validExpression);
//                }
//            }
//        }
//        int count=0;
//        if (u.size() > 0) {
//            try {
//                count= entity.updateCore(u, expression, context);
//            } catch (UPAException ex) {
////            Log.bug(ex);
//                Select sb0 = new Select();
//                for (Field f : fields) {
//                    Expression fieldExpression = getFieldExpression(f, onPersist);
//                    sb0.field(fieldExpression, f.getName() + "Expression");
//                    Expression validExpression = fieldExpression;
//                    if (forceExpressionTypeCasting || (fieldExpression instanceof Literal && ((Literal) fieldExpression).getValue() == null)) {
//                        validExpression = new Cast(fieldExpression, f.getDataType());
//                    }
//                    sb0.field(validExpression, f.getName() + "CastExpression");
//                }
//                sb0.from(entity.getName());
//                sb0.setWhere(expression);
//
////            Log.bug("Values to update are : ");
//                for (Document ur : entity.createQuery(sb0).getDocumentList()) {
//                    for (Map.Entry<String, Object> entry : ur.toMap().entrySet()) {
//                        //Log.bug(entry.getKey() + " : " + entry.getValue());
//                    }
//                }
//                throw ex;
//            }
//        }
//        int count2=0;
//        if (selectBasedFields.size() > 0) {
//            Select s = new Select().from(entity.getName(),UQLUtils.THIS);
//            for (Field primaryField : entity.getIdFields()) {
//                s.field(primaryField.getName());
//            }
//            for (Map.Entry<String, Expression> f : selectBasedFields.entrySet()) {
//                s.field(f.getValue(), f.getKey());
//            }
//            s.where(expression);
//            for (Document document : entity.getPersistenceUnit().createQuery(s).getDocumentList()) {
//                for (Map.Entry<String, Expression> f : selectBasedFields.entrySet()) {
//                    u.setObject(f.getKey(),document.getObject(f.getKey()));
//                }
//                Expression exprId=eb.objectToIdExpression(document, UQLUtils.THIS);
//                count2+= entity.updateCore(u, exprId, context);
//            }
//        }
//        return Math.max(count, count2);
//    }

}
