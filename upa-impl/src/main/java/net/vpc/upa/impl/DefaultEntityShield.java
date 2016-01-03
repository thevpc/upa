package net.vpc.upa.impl;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.*;
import net.vpc.upa.expressions.*;

import java.util.*;
import net.vpc.upa.filters.FieldFilter;
import net.vpc.upa.filters.Fields;
import net.vpc.upa.impl.util.PlatformUtils;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/2/12 5:47 PM
 */
public class DefaultEntityShield implements EntityShield {

    private static final FieldFilter PERSISTENT_NON_FORMULA = Fields.byModifiersNoneOf(FieldModifier.PERSIST_FORMULA, FieldModifier.UPDATE_FORMULA, FieldModifier.TRANSIENT);
    private Entity entity;
    private Map<VetoableOperation, List<EntityShieldVeto>> vetoMap = new HashMap<VetoableOperation, List<EntityShieldVeto>>();
    private Expression nonDeletableRecordsExpression;
    private Expression nonUpdatableRecordsExpression;
    private Expression nonRenamableRecordsExpression;
    private Expression nonCloneableRecordsExpression;

    public void init(Entity entity) {
        this.entity = entity;
    }

    @Override
    public Expression getNonDeletableRecordsExpression() {
        return nonDeletableRecordsExpression;
    }

    @Override
    public void setNonDeletableRecordsExpression(Expression expression) {
        this.nonDeletableRecordsExpression = expression;
    }

    @Override
    public Expression getNonUpdatableRecordsExpression() {
        return nonUpdatableRecordsExpression;
    }

    @Override
    public void setNonUpdatableRecordsExpression(Expression expression) {
        this.nonUpdatableRecordsExpression = expression;
    }

    @Override
    public Expression getNonRenamableRecordsExpression() {
        return nonRenamableRecordsExpression;
    }

    @Override
    public void setNonRenamableRecordsExpression(Expression expression) {
        this.nonRenamableRecordsExpression = expression;
    }

    @Override
    public Expression getNonCloneableRecordsExpression() {
        return nonCloneableRecordsExpression;
    }

    @Override
    public void setNonCloneableRecordsExpression(Expression expression) {
        this.nonCloneableRecordsExpression = expression;
    }

    public Expression getFullNonRenamableRecordsExpression() throws UPAException {
        Entity parent = entity.getParentEntity();
        Expression a = getNonRenamableRecordsExpression();
        Expression b = parent == null ? null : entity.parentToChildExpression(parent.getShield().getFullNonRenamableRecordsExpression());
        a = (a == null) ? b : new Or(a, b);
        return (a == null || !a.isValid()) ? null : a;
    }

    public Expression getFullNonCloneableRecordsExpression() throws UPAException {
        Entity parent = entity.getParentEntity();
        Expression a = getNonCloneableRecordsExpression();
        Expression b = parent == null ? null : entity.parentToChildExpression(parent.getShield().getFullNonRenamableRecordsExpression());
        a = (a == null) ? b : new Or(a, b);
        return (a == null || !a.isValid()) ? null : a;
    }

    public Expression getFullNonDeletableRecordsExpression() throws UPAException {
        Entity parent = entity.getParentEntity();
        Expression a = getNonDeletableRecordsExpression();
        Expression b = parent == null ? null : entity.parentToChildExpression(parent.getShield().getFullNonUpdatableRecordsExpression());
        a = (a == null) ? b : new Or(a, b);
        return (a == null || !a.isValid()) ? null : a;
    }

    public Expression getFullNonUpdatableRecordsExpression() throws UPAException {
        Entity parent = entity.getParentEntity();
        Expression a = getNonUpdatableRecordsExpression();
        Expression b = parent == null ? null : entity.parentToChildExpression(parent.getShield().getFullNonUpdatableRecordsExpression());
        a = (a == null) ? b : new Or(a, b);
        return (a == null || !a.isValid()) ? null : a;
    }

    protected FlagSet<EntityModifier> getEffectiveModifiers() {
        return entity.getModifiers();
    }

    //////////////////////////////////////////////
    // VetoableOperation Supported
    //////////////////////////////////////////////
    @Override
    public boolean isLockingSupported() {
        return getEffectiveModifiers().contains(EntityModifier.LOCK);
    }

//    @Override
//    public void setLockingSupported(boolean value) {
//        getModifiers().setModifiers(EntityModifier.LOCK, value);
//    }
    @Override
    public boolean isUpdateFormulaOnPersistSupported() {
        return getEffectiveModifiers().contains(EntityModifier.VALIDATE_PERSIST);
    }

    @Override
    public boolean isUpdateFormulaOnUpdateSupported() {
        return getEffectiveModifiers().contains(EntityModifier.VALIDATE_UPDATE);
    }

    @Override
    public boolean isUpdateFormulaSupported() {
        return !isTransient()
                && (getEffectiveModifiers().contains(EntityModifier.VALIDATE_PERSIST)
                || getEffectiveModifiers().contains(EntityModifier.VALIDATE_UPDATE));
    }

    public final boolean isPersistSupported() {
        return (!isTransient()) && getEffectiveModifiers().contains(EntityModifier.PERSIST);
    }

    public final boolean isUpdateSupported() {
        return !isTransient() && getEffectiveModifiers().contains(EntityModifier.UPDATE);
    }

    public final boolean isDeleteSupported() {
        return !isTransient() && getEffectiveModifiers().contains(EntityModifier.REMOVE);
    }

    public final boolean isCloneSupported() {
        return !isTransient() && getEffectiveModifiers().contains(EntityModifier.CLONE);
    }

    public final boolean isRenameSupported() {
        return !isTransient() && getEffectiveModifiers().contains(EntityModifier.RENAME);
    }

    public boolean isClearSupported() {
        return getEffectiveModifiers().contains(EntityModifier.CLEAR);
    }

    //////////////////////////////////////////////
    // VetoableOperation Enabled
    //////////////////////////////////////////////
    public boolean isPersistEnabled() throws UPAException {
        return isPersistSupported()
                && entity.getPersistenceUnit().getSecurityManager().isAllowedPersist(entity) && isNoVeto(VetoableOperation.persistEnabled);
    }

    public boolean isUpdateEnabled() throws UPAException {
        return isUpdateSupported() && entity.getPersistenceUnit().getSecurityManager().isAllowedUpdate(entity) && isNoVeto(VetoableOperation.updateEnabled);
    }

    public boolean isDeleteEnabled() throws UPAException {
        return isDeleteSupported() && entity.getPersistenceUnit().getSecurityManager().isAllowedRemove(entity) && isNoVeto(VetoableOperation.removeEnabled);
    }

    public boolean isRenameEnabled() throws UPAException {
        return isRenameSupported() && entity.getPersistenceUnit().getSecurityManager().isAllowedRename(entity) && isNoVeto(VetoableOperation.renameEnabled);
    }

    public boolean isCloneEnabled() throws UPAException {
        return isCloneSupported() && entity.getPersistenceUnit().getSecurityManager().isAllowedClone(entity) && isNoVeto(VetoableOperation.cloneEnabled);
    }

    public boolean isKeyEditionSupported() {
        return getEffectiveModifiers().contains(EntityModifier.USER_ID);
    }

    public boolean isNavigateSupported() {
        return getEffectiveModifiers().contains(EntityModifier.NAVIGATE);
    }

    public boolean isGeneratedId() {
        for (Field field : entity.getPrimaryFields()) {
            if (field.getModifiers().contains(FieldModifier.PERSIST_FORMULA)) {
                if (field.getPersistFormula() instanceof Sequence) {
                    return true;
                }
            }
        }
        return false;
    }

    //    public void setNavigateSupported(boolean navigateSupported) {
//        entity.setModifiers(EntityModifier.NAVIGATE, navigateSupported);
//    }
//
//    public void setNewKeySupported(boolean newKeySupported) {
//        entity.setModifiers(EntityModifier.AUTO_ID, newKeySupported);
//    }
//
//    /**
//     * setKeyEditionSupported
//     *
//     * @param keyEditionSupported
//     */
//    public void setUserIdSupported(boolean keyEditionSupported) {
//        entity.setModifiers(EntityModifier.USER_ID, keyEditionSupported);
//    }
    //////////////////////////////////////////////
    // Check Operations
    //////////////////////////////////////////////
    public void checkLoad() throws UPAException {
        if (!entity.getPersistenceUnit().getSecurityManager().isAllowedLoad(entity)) {
            throw new LoadRecordNotAllowedException(entity);
        }
        checkVeto(VetoableOperation.checkLoad);
    }

    public void checkNavigate() throws UPAException {
        if (!isNavigateSupported()) {
            throw new NavigateEntityNotSupportedException(entity);
        }
        if (!entity.getPersistenceUnit().getSecurityManager().isAllowedNavigate(entity)) {
            throw new NavigateEntityNotAllowedException(entity);
        }
        checkVeto(VetoableOperation.checkNavigate);
    }

    public void checkRemove(Expression condition, boolean recurse)
            throws UPAException {
        if (entity.getEntityCount(condition) == 0) {
            //nothing to remove!!
            return;
        }
        if (!isDeleteSupported()) {
            throw new UndeletableRecordException(entity);
        }
        if (!entity.getPersistenceUnit().getSecurityManager().isAllowedRemove(entity)) {
            throw new DeleteRecordNotAllowedException(entity);
        }
        Expression e = getFullNonDeletableRecordsExpression();
        if (e != null && e.isValid()) {
            Expression a = (condition == null) ? e : new And(condition, e);
            if (entity.getEntityCount(a) > 0) {
                throw new UndeletableRecordException(entity);
            }
        }
        Entity p = entity.getParentEntity();
        if (p != null) {
            Expression ss = entity.childToParentExpression(condition);
            p.getShield().checkRemove(ss, recurse);
        }
        checkVeto(VetoableOperation.checkDelete, condition, recurse);
    }

    /**
     * @param oldId
     * @param newId
     * @throws net.vpc.upa.exceptions.UPAException
     * CloneRecordNotAllowedException, CloneRecordNotAllowedException,
     * CloneRecordNotAllowedException, CloneRecordOldKeyNotFoundException,
     * CloneRecordNewKeyInUseException
     */
    public void checkClone(Object oldId, Object newId) throws UPAException {
        if (!entity.getPersistenceUnit().getSecurityManager().isAllowedClone(entity)) {
            throw new CloneRecordNotAllowedException(entity);
        }
        if (!isCloneSupported()) {
            throw new CloneRecordNotAllowedException(entity);
        }
        if (oldId != null) {
            Expression e = getFullNonCloneableRecordsExpression();
            if (e != null && e.isValid()) {
                And a = new And(entity.getBuilder().idToExpression(oldId, null), e);
                if (entity.getEntityCount(a) > 0) {
                    throw new CloneRecordNotAllowedException(entity);
                }
            }
            Object o = entity.createQueryBuilder().setId(oldId).setFieldFilter(PERSISTENT_NON_FORMULA).getEntity();
            if (o == null) {
                throw new CloneRecordOldKeyNotFoundException(entity);
            }
        }
        if (newId != null) {
            if (entity.contains(newId)) {
                throw new CloneRecordNewKeyInUseException(entity);
            }
        }
        checkVeto(VetoableOperation.checkClone, oldId, newId);
    }

    /**
     * Check for the faisabilty of the rename operation. When oldId is null, the
     * verification is done for ALL keys (rname should be supported+enabled for
     * the curent user) When newId is null, the verification is done only on
     * oldId
     *
     * @param oldId old id
     * @param newId new id
     * @throws net.vpc.upa.exceptions.UPAException :
     * RenameRecordNotAllowedException, UnrenamableRecordException,
     * RenameRecordOldKeyNotFoundException, RenameRecordNewKeyInUseException
     */
    public void checkRename(Object oldId, Object newId) throws UPAException {
        if (!entity.getPersistenceUnit().getSecurityManager().isAllowedRename(entity)) {
            throw new RenameRecordNotAllowedException(entity);
        }
        if (!isRenameSupported()) {
            throw new UnrenamableRecordException(entity);
        }
        if (oldId != null) {
            Expression e = getFullNonRenamableRecordsExpression();
            if (e != null && e.isValid()) {
                And a = new And(entity.getBuilder().idToExpression(oldId, null), e);
                if (entity.getEntityCount(a) > 0) {
                    throw new UnrenamableRecordException(entity);
                }
            }

            Object o = entity.createQueryBuilder().setId(oldId).setFieldFilter(PERSISTENT_NON_FORMULA).getEntity();
            if (o == null) {
                throw new RenameRecordOldKeyNotFoundException(entity);
            }
        }
        if (newId != null) {
            if (entity.contains(newId)) {
                throw new RenameRecordNewKeyInUseException(entity);
            }
        }
        checkVeto(VetoableOperation.checkRename, oldId, newId);
    }

    public void checkUpdate(Record updates, Expression condition)
            throws UPAException {
        if (!entity.getPersistenceUnit().getSecurityManager().isAllowedUpdate(entity)) {
            throw new UpdateRecordNotAllowedException(entity);
        }
        if (!isUpdateSupported()) {
            throw new UnupdatableRecordException(entity);
        }
        Expression e = getFullNonUpdatableRecordsExpression();
        if (e != null && e.isValid()) {
            Expression a = (condition == null) ? e : new And(condition, e);
            if (entity.getEntityCount(a) > 0) {
                throw new UnupdatableRecordException(entity);
            }
        }
        long updated = 0;
        if ((updated = entity.getEntityCount(condition)) == 0) {
            throw new UpdateRecordKeyNotFoundException(entity, condition);
        }
        //TODO c koa cet unique fields qui n'impose pas toutes les validations
        if (false/*
                 * uniqueFields == null || uniqueFields.size() == 0
                 */) {
            return;
        } else if (updated == 1) {
            if (condition != null) {
                if (updates != null) {
                    Expression or = null;
                    for (Index index : entity.getIndexes(true)) {
                        Field[] f = index.getFields();
                        Expression a = null;
                        int found = 0;
                        for (Field aF : f) {
                            if (updates.isSet(aF.getName())) {
                                found++;
                                Expression b = (new Equals(new Var(aF.getName()), ExpressionFactory.toLiteral(updates.getObject(aF.getName()))));
                                a = a == null ? b : new And(a, b);
                            }
                        }
                        if (found != 0 && found != f.length) {
                            throw new UPAException("NotFound");
                        } else if (found == f.length) {
                            or = or == null ? a : new Or(or, a);
                        }
                    }
                    if (or != null) {
                        And and = new And(new Not(condition), or);
                        if (entity.getEntityCount(and) > 0) {
                            throw new UpdateRecordDuplicateKeyException(entity);
                        }
                    }
                }
            }
        } else {
            if (updates != null) {
                for (Index index : entity.getIndexes(true)) {
                    Field[] f = index.getFields();
                    for (Field aF : f) {
                        if (updates.isSet(aF.getName())) {
                            throw new UpdateRecordDuplicateKeyException(entity);
                        }
                    }
                }
            }
        }
        Entity p = entity.getParentEntity();
        if (p != null) {
            Expression ss = entity.childToParentExpression(condition);
            p.getShield().checkUpdate(null, ss);
        }
        checkVeto(VetoableOperation.checkUpdate, updates, condition);
    }

    @Override
    public void checkInitialize() throws UPAException {
//        if (!isPersistSupported()) {
//            throw new InsertRecordNotAllowedException(entity);
//        }
    }

    @Override
    public void checkClear() throws UPAException {
        if (!isDeleteSupported()) {
            throw new UndeletableRecordException(entity);
        }
    }

//    @Override
//    public void checkReset() throws UPAException {
////        if(!isResetSupported()){
////
////        }
////        if (!isDeleteSupported()) {
////            throw new UndeletableRecordException(entity);
////        }
////        if (!isPersistSupported()) {
////            throw new InsertRecordNotAllowedException(entity);
////        }
//    }

    public void checkPersist(Record record) throws UPAException {
        if (!entity.getPersistenceUnit().getSecurityManager().isAllowedPersist(entity)) {
            throw new PersistRecordNotAllowedException(entity);
        }
        if (!isPersistSupported()) {
            throw new PersistRecordNotAllowedException(entity);
        }
        if (record != null) {
            // check parent is not read only
            if (entity.getParentEntity() != null) {
                Expression parentUnupdatable = entity.getParentEntity().getShield().getFullNonUpdatableRecordsExpression();
                if (parentUnupdatable != null && parentUnupdatable.isValid()) {
                    Relationship r = entity.getCompositionRelation();
                    List<Field> df = r.getSourceRole().getFields();
                    List<Field> mf = r.getTargetRole().getFields();
                    Object[] pko = new Object[mf.size()];
                    for (int i = 0; i < pko.length; i++) {
                        pko[i] = record.getObject(df.get(i).getName());
                    }
                    Object pk = entity.createId(pko);
                    long c = entity.getParentEntity().getEntityCount(new And(parentUnupdatable, entity.getParentEntity().getBuilder().idToExpression(pk, null)));
                    if (c > 0) {
                        throw new UnupdatableRecordException(entity.getParentEntity());
                    }
                }
            }

            boolean keyGenerated = isGeneratedId();
            Expression keyExpresson = null;
            if (!keyGenerated) {
                Object key = entity.getBuilder().recordToId(record);
                keyExpresson = entity.getBuilder().idToExpression(key, null);
            }
            Entity p = entity.getParentEntity();
            if (p != null) {
                //Expression ss = childToParentExpression(toExpression(key));
                Expression ss = entity.childToParentExpression(record);
                p.getShield().checkUpdate(null, ss);
            }
            List<Index> uniqueIndexes = entity.getIndexes(true);
            if (uniqueIndexes.isEmpty()) {
                if (!keyGenerated) {
                    if (entity.getEntityCount(keyExpresson) > 0) {
                        throw new InsertRecordDuplicateKeyException(entity);
                    }
                }
            } else {
                Expression or = null;
                if (!keyGenerated) {
                    or = keyExpresson;
                }
                for (Index index : uniqueIndexes) {
                    Field[] f = index.getFields();
                    Expression e1 = null;
                    if (f.length == 1) {
                        e1 = new Equals(new Var(f[0].getName()), ExpressionFactory.toLiteral(record.getObject(f[0].getName())));
                    } else {
                        Expression a = null;
                        for (Field aF : f) {
                            Expression b = (new Equals(new Var(aF.getName()), ExpressionFactory.toLiteral(record.getObject(aF.getName()))));
                            a = a == null ? b : new And(a, b);
                        }
                        e1 = a;
                    }
                    or = or == null ? e1 : new Or(or, e1);
                }
                if (entity.getEntityCount(or) > 0) {
                    // finer lookup of problem
                    if (!keyGenerated) {
                        if (entity.getEntityCount(keyExpresson) > 0) {
                            throw new InsertRecordDuplicateKeyException(entity);
                        }
                    }
                    for (Index index : uniqueIndexes) {
                        Field[] f = index.getFields();
                        Expression e1 = null;
                        if (f.length == 1) {
                            e1 = new Equals(new Var(f[0].getName()), ExpressionFactory.toLiteral(record.getObject(f[0].getName())));
                        } else {
                            Expression a = null;
                            for (Field aF : f) {
                                Expression b = (new Equals(new Var(aF.getName()),
                                        ExpressionFactory.toLiteral(record.getObject(aF.getName()))));
                                a = a == null ? b : new And(a, b);
                            }
                            e1 = a;
                        }
                        if (entity.getEntityCount(e1) > 0) {
                            throw new InsertRecordDuplicateUniqueFieldsException(entity, index, record.getObject(f[0].getName()));
                        }
                    }
                    throw new RuntimeException("WouldNeverBeThrownException");
                }
            }
        }
        checkVeto(VetoableOperation.checkPersist, record);
    }

    //////////////////////////////////////////////
    // Misc
    //////////////////////////////////////////////
    public boolean isSystem() {
        return getEffectiveModifiers().contains(EntityModifier.SYSTEM);
    }

    public boolean isPrivate() {
        return getEffectiveModifiers().contains(EntityModifier.PRIVATE);
    }

    public boolean isTransient() {
        return getEffectiveModifiers().contains(EntityModifier.TRANSIENT);
    }

    //    public final boolean isPrintSupported() {
//        return printSupported;
//    }
    public boolean isDeletableRecord(Object k, boolean recurse) {
        try {
            if (!entity.getPersistenceUnit().getSecurityManager().isAllowedRemove(entity)) {
                return false;
            }
            Expression e = getFullNonDeletableRecordsExpression();
            if (e != null && e.isValid()) {
                Expression a = new And(entity.getBuilder().idToExpression(k, null), e);
                if (entity.getEntityCount(a) > 0) {
                    return false;
                }
            }
            checkVeto(VetoableOperation.deletableRecord, k, recurse);
            return true;
        } catch (UPAException e) {
            // e.printStackTrace(); //To change body of catch statement use
            // Options | File Templates.
        }
        return false;
    }

    public boolean isUpdatableRecord(Object id) {
        try {
            if (!entity.getPersistenceUnit().getSecurityManager().isAllowedUpdate(entity)) {
                return false;
            }
            Expression e = getFullNonUpdatableRecordsExpression();
            if (e != null && e.isValid()) {
                Expression a = new And(entity.getBuilder().idToExpression(id, null), e);
                if (entity.getEntityCount(a) > 0) {
                    return false;
                }
            }
            checkVeto(VetoableOperation.updatableRecord, id);
            return true;
        } catch (UPAException e) {
            // e.printStackTrace(); //To change body of catch statement use
            // Options | File Templates.
        }
        return false;
    }

//    public boolean isFieldEditable(Field field, K instanceID) throws UPAException {
//        if (isTransient()) {
//            return false;
//        }
//        FlagSet<FieldModifier> m = field.getModifiers();
//        if (instanceID==null?m.contains(FieldModifier.INSERT_PUBLIC):m.contains(FieldModifier.UPDATE_PUBLIC)) {
//            if (!isAllowed(field, EntitySecurityActionFactory.updateField)) {
//                return false;
//            }
//        }
//        if (!isNoVeto(EntityShieldVeto.VetoableOperation.fieldEditable, field, instanceID)) {
//            return false;
//        }
//        return true;
//    }
//
//    public boolean isFieldVisible(Field field, K instanceID) throws UPAException {
//        FlagSet<FieldModifier> m = field.getModifiers();
//        if (instanceID==null?!m.contains(FieldModifier.INSERT_PRIVATE):!m.contains(FieldModifier.UPDATE_PRIVATE)) {
//            if (!isAllowed(field, EntitySecurityActionFactory.readField)) {
//                return false;
//            }
//        }
//        if (!isNoVeto(EntityShieldVeto.VetoableOperation.fieldVisible, field, instanceID)) {
//            return false;
//        }
//        return true;
//    }
    //    public void setRenameSupported(boolean value) {
//        entity.setModifiers(EntityModifier.RENAME, value);
//    }
//
//    public void setCloneSupported(boolean value) {
//        entity.setModifiers(EntityModifier.CLONE, value);
//    }
//
//    public void setDeleteSupported(boolean value) {
//        entity.setModifiers(EntityModifier.DELETE, value);
//    }
//
//    public void setUpdateSupported(boolean value) {
//        entity.setModifiers(EntityModifier.UPDATE, value);
//    }
//
//    public void setInsertSupported(boolean value) {
//        entity.setModifiers(EntityModifier.INSERT, value);
//    }
//    public void setPrintSupported(boolean printSupported) {
//        this.printSupported = printSupported;
//    }
//    public void setClearSupported(boolean value) {
//        entity.setModifiers(EntityModifier.CLEAR, value);
//    }
//
//    public void setValidateOnInsertSupported(boolean enable) {
//        entity.setModifiers(EntityModifier.VALIDATE_INSERT, enable);
//    }
//
//    public void setValidateOnUpdateSupported(boolean enable) {
//        entity.setModifiers(EntityModifier.VALIDATE_UPDATE, enable);
//    }
    @Override
    public void addVeto(VetoableOperation operation, EntityShieldVeto veto) {
        getVetoList(operation, true).add(veto);
    }

    @Override
    public void removeVeto(VetoableOperation operation, EntityShieldVeto veto) {
        List<EntityShieldVeto> vetoList = getVetoList(operation, false);
        if (vetoList != null) {
            vetoList.remove(veto);
        }
    }

    @Override
    public List<EntityShieldVeto> getVetoList(VetoableOperation operation) {
        List<EntityShieldVeto> vetoList = getVetoList(operation, false);
        if (vetoList == null) {
            return PlatformUtils.emptyList();
        }
        return new ArrayList<EntityShieldVeto>(vetoList);
    }

    protected List<EntityShieldVeto> getVetoList(VetoableOperation operation, boolean create) {
        List<EntityShieldVeto> entityShieldVetos = vetoMap.get(operation);
        if (entityShieldVetos == null && create) {
            entityShieldVetos = new ArrayList<EntityShieldVeto>();
            vetoMap.put(operation, entityShieldVetos);
        }
        return entityShieldVetos;
    }

    protected boolean isNoVeto(VetoableOperation operation, Object... params) throws UPAException {
        for (EntityShieldVeto v : getVetoList(operation)) {
            try {
                v.checkVeto(operation, entity, params);
            } catch (VetoException e) {
                return false;
            }
        }
        return true;
    }

    protected void checkVeto(VetoableOperation operation, Object... params) throws UPAException {
        for (EntityShieldVeto v : getVetoList(operation)) {
            v.checkVeto(operation, entity, params);
        }

    }
}
