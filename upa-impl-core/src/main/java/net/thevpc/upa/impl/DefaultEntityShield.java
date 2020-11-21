package net.thevpc.upa.impl;

import net.thevpc.upa.*;
import net.thevpc.upa.exceptions.*;
import net.thevpc.upa.expressions.*;
import net.thevpc.upa.impl.upql.util.UPQLUtils;
import net.thevpc.upa.impl.util.PlatformUtils;
import net.thevpc.upa.impl.util.UPAUtils;
import net.thevpc.upa.impl.util.filters.FieldFilters2;

import net.thevpc.upa.exceptions.*;
import net.thevpc.upa.expressions.*;

import java.util.*;
import java.util.logging.Logger;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/2/12 5:47 PM
 */
public class DefaultEntityShield implements EntityShield {

    private static final Logger log = Logger.getLogger(DefaultEntityShield.class.getName());
    private Entity entity;
    private Map<VetoableOperation, List<EntityShieldVeto>> vetoMap = new HashMap<VetoableOperation, List<EntityShieldVeto>>();
    private Expression nonDeletableDocumentsExpression;
    private Expression nonUpdatableDocumentsExpression;
    private Expression nonRenamableDocumentsExpression;
    private Expression nonCloneableDocumentsExpression;

    public void init(Entity entity) {
        this.entity = entity;
    }

    public Expression getNonRemovableDocumentsExpression() {
        return nonDeletableDocumentsExpression;
    }

    public void setNonRemovableDocumentsExpression(Expression expression) {
        this.nonDeletableDocumentsExpression = expression;
    }

    public Expression getNonUpdatableDocumentsExpression() {
        return nonUpdatableDocumentsExpression;
    }

    public void setNonUpdatableDocumentsExpression(Expression expression) {
        this.nonUpdatableDocumentsExpression = expression;
    }

    public Expression getNonRenamableDocumentsExpression() {
        return nonRenamableDocumentsExpression;
    }

    public void setNonRenamableDocumentsExpression(Expression expression) {
        this.nonRenamableDocumentsExpression = expression;
    }

    public Expression getNonCloneableDocumentsExpression() {
        return nonCloneableDocumentsExpression;
    }

    public void setNonCloneableDocumentsExpression(Expression expression) {
        this.nonCloneableDocumentsExpression = expression;
    }

    public Expression getFullNonRenamableDocumentsExpression() throws UPAException {
        Entity parent = entity.getParentEntity();
        Expression a = getNonRenamableDocumentsExpression();
        Expression b = parent == null ? null : entity.parentToChildExpression(parent.getShield().getFullNonRenamableDocumentsExpression());
        a = (a == null) ? b : new Or(a, b);
        return (a == null || !a.isValid()) ? null : a;
    }

    public Expression getFullNonCloneableDocumentsExpression() throws UPAException {
        Entity parent = entity.getParentEntity();
        Expression a = getNonCloneableDocumentsExpression();
        Expression b = parent == null ? null : entity.parentToChildExpression(parent.getShield().getFullNonRenamableDocumentsExpression());
        a = (a == null) ? b : new Or(a, b);
        return (a == null || !a.isValid()) ? null : a;
    }

    public Expression getFullNonRemovableDocumentsExpression() throws UPAException {
        Entity parent = entity.getParentEntity();
        Expression a = getNonRemovableDocumentsExpression();
        Expression b = parent == null ? null : entity.parentToChildExpression(parent.getShield().getFullNonUpdatableDocumentsExpression());
        a = (a == null) ? b : new Or(a, b);
        return (a == null || !a.isValid()) ? null : a;
    }

    public Expression getFullNonUpdatableDocumentsExpression() throws UPAException {
        Entity parent = entity.getParentEntity();
        Expression a = getNonUpdatableDocumentsExpression();
        Expression b = (parent == null
                //if hierarchical entity then ignore parent
                || parent.getName().equals(entity.getName())
        )? null : entity.parentToChildExpression(parent.getShield().getFullNonUpdatableDocumentsExpression());
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

    public final boolean isRemoveSupported() {
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

    public boolean isRemoveEnabled() throws UPAException {
        return isRemoveSupported() && entity.getPersistenceUnit().getSecurityManager().isAllowedRemove(entity) && isNoVeto(VetoableOperation.removeEnabled);
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
        for (Field field : entity.getIdFields()) {
            if (field.getModifiers().contains(FieldModifier.PERSIST_FORMULA)) {
                if (UPAUtils.getPersistFormula(field) instanceof Sequence) {
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
            throw new LoadDocumentNotAllowedException(entity);
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

    public void checkRemove(Expression condition, boolean recurse, long toRemoveCount)
            throws UPAException {
        if (toRemoveCount==0) {
            //nothing to remove!!
            return;
        }
        if (!isRemoveSupported()) {
            throw new RemoveDocumentNotSupportedException(entity);
        }
        if (!entity.getPersistenceUnit().getSecurityManager().isAllowedRemove(entity)) {
            throw new RemoveDocumentNotAllowedException(entity);
        }
        Expression e = getFullNonRemovableDocumentsExpression();
        if (e != null && e.isValid()) {
            Expression a = (condition == null) ? e : new And(condition, e);
            if (entity.getEntityCount(a) > 0) {
                throw new RemoveDocumentNotSupportedException(entity);
            }
        }
        Entity p = entity.getParentEntity();
        if (p != null) {
            Expression ss = entity.childToParentExpression(condition);
//            p.getShield().checkRemove(ss, recurse);
            try {
                p.getShield().checkUpdate(p.getBuilder().createDocument(), ss);
            }catch (UpdateDocumentIdNotFoundException ex){
                //ignore this error, because no parent to update...
            }
        }
        checkVeto(VetoableOperation.checkDelete, condition, recurse);
    }

    /**
     * @param oldId
     * @param newId
     * @throws UPAException
     * CloneDocumentNotAllowedException, CloneDocumentNotAllowedException,
 CloneDocumentNotAllowedException, CloneDocumentOldIdNotFoundException,
 CloneDocumentNewIdInUseException
     */
    public void checkClone(Object oldId, Object newId) throws UPAException {
        if (!entity.getPersistenceUnit().getSecurityManager().isAllowedClone(entity)) {
            throw new CloneDocumentNotAllowedException(entity);
        }
        if (!isCloneSupported()) {
            throw new CloneDocumentNotAllowedException(entity);
        }
        if (oldId != null) {
            Expression e = getFullNonCloneableDocumentsExpression();
            if (e != null && e.isValid()) {
                And a = new And(entity.getBuilder().idToExpression(oldId, UPQLUtils.THIS), e);
                if (entity.getEntityCount(a) > 0) {
                    throw new CloneDocumentNotAllowedException(entity);
                }
            }
            Object o = entity.createQueryBuilder().byId(oldId).setFieldFilter(FieldFilters2.PERSISTENT_NON_FORMULA).getSingleResultOrNull();
            if (o == null) {
                throw new CloneDocumentOldIdNotFoundException(entity);
            }
        }
        if (newId != null) {
            if (entity.contains(newId)) {
                throw new CloneDocumentNewIdInUseException(entity);
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
     * @throws UPAException :
 RenameDocumentNotAllowedException, RenameDocumentNotSupportedException,
 RenameDocumentOldIdNotFoundException, RenameDocumentNewIdInUseException
     */
    public void checkRename(Object oldId, Object newId) throws UPAException {
        if (!entity.getPersistenceUnit().getSecurityManager().isAllowedRename(entity)) {
            throw new RenameDocumentNotAllowedException(entity);
        }
        if (!isRenameSupported()) {
            throw new RenameDocumentNotSupportedException(entity);
        }
        if (oldId != null) {
            Expression e = getFullNonRenamableDocumentsExpression();
            if (e != null && e.isValid()) {
                And a = new And(entity.getBuilder().idToExpression(oldId, UPQLUtils.THIS), e);
                if (entity.getEntityCount(a) > 0) {
                    throw new RenameDocumentNotSupportedException(entity);
                }
            }

            Object o = entity.createQueryBuilder().byId(oldId).setFieldFilter(FieldFilters2.PERSISTENT_NON_FORMULA).getSingleResultOrNull();
            if (o == null) {
                throw new RenameDocumentOldIdNotFoundException(entity);
            }
        }
        if (newId != null) {
            if (entity.contains(newId)) {
                throw new RenameDocumentNewIdInUseException(entity);
            }
        }
        checkVeto(VetoableOperation.checkRename, oldId, newId);
    }

    @Override
    public void checkUpdate(Document updates, Expression condition)
            throws UPAException {
        if (!entity.getPersistenceUnit().getSecurityManager().isAllowedUpdate(entity)) {
            throw new UpdateDocumentNotAllowedException(entity);
        }
        if (!isUpdateSupported()) {
            throw new UpdateDocumentNotSupportedException(entity);
        }
        Expression e = getFullNonUpdatableDocumentsExpression();
        if (e != null && e.isValid()) {
            Expression a = (condition == null) ? e : new And(condition, e);
            if (entity.getEntityCount(a) > 0) {
                throw new UpdateDocumentNotSupportedException(entity);
            }
        }
        long updated = 0;
        if ((updated = entity.getEntityCount(condition)) == 0) {
            throw new UpdateDocumentIdNotFoundException(entity, condition);
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
                            throw new UpdateDocumentDuplicateIdException(entity);
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
                            throw new UpdateDocumentDuplicateIdException(entity);
                        }
                    }
                }
            }
        }
        Entity p = entity.getParentEntity();
        if (p != null && !p.equals(entity)) {
            Expression ss = entity.childToParentExpression(condition);
            try{
                p.getShield().checkUpdate(null, ss);
            }catch(UpdateDocumentIdNotFoundException ex){
                log.warning(entity.getName()+"'s parent seems not to be resolvable for condition ("+condition+"): "+ex);
                //ignore if parent not found!
            }
        }
        checkVeto(VetoableOperation.checkUpdate, updates, condition);
    }

    @Override
    public void checkInitialize() throws UPAException {
//        if (!isPersistSupported()) {
//            throw new InsertDocumentNotAllowedException(entity);
//        }
    }

    @Override
    public void checkClear() throws UPAException {
        if (!isRemoveSupported()) {
            throw new RemoveDocumentNotSupportedException(entity);
        }
    }

//    @Override
//    public void checkReset() throws UPAException {
////        if(!isResetSupported()){
////
////        }
////        if (!isRemoveSupported()) {
////            throw new RemoveDocumentNotSupportedException(entity);
////        }
////        if (!isPersistSupported()) {
////            throw new InsertDocumentNotAllowedException(entity);
////        }
//    }

    public void checkPersist(Document document) throws UPAException {
        if (!entity.getPersistenceUnit().getSecurityManager().isAllowedPersist(entity)) {
            throw new PersistDocumentNotAllowedException(entity);
        }
        if (!isPersistSupported()) {
            throw new PersistDocumentNotSupportedException(entity);
        }
        if (document != null) {
            // check parent is not read only
            if (entity.getParentEntity() != null) {
                Expression parentUnupdatable = entity.getParentEntity().getShield().getFullNonUpdatableDocumentsExpression();
                if (parentUnupdatable != null && parentUnupdatable.isValid()) {
                    Relationship r = entity.getCompositionRelation();
                    List<Field> df = r.getSourceRole().getFields();
                    List<Field> mf = r.getTargetRole().getFields();
                    Object[] pko = new Object[mf.size()];
                    for (int i = 0; i < pko.length; i++) {
                        pko[i] = document.getObject(df.get(i).getName());
                    }
                    Object pk = entity.createId(pko);
                    long c = entity.getParentEntity().getEntityCount(new And(parentUnupdatable, entity.getParentEntity().getBuilder().idToExpression(pk, UPQLUtils.THIS)));
                    if (c > 0) {
                        throw new UpdateDocumentNotSupportedException(entity.getParentEntity());
                    }
                }
            }

            boolean keyGenerated = isGeneratedId();
            Expression keyExpresson = null;
            if (!keyGenerated) {
                Object key = entity.getBuilder().documentToId(document);
                keyExpresson = entity.getBuilder().idToExpression(key, UPQLUtils.THIS);
            }
            Entity p = entity.getParentEntity();
            if (p != null) {
                //Expression ss = childToParentExpression(toExpression(key));
                Expression ss = entity.childToParentExpression(document);
                if(ss!=null) {
                    p.getShield().checkUpdate(null, ss);
                }
            }
            List<Index> uniqueIndexes = entity.getIndexes(true);
            if (uniqueIndexes.isEmpty()) {
                if (!keyGenerated) {
                    if (entity.getEntityCount(keyExpresson) > 0) {
                        throw new PersistDocumentDuplicateIdException(entity);
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
                        e1 = new Equals(new Var(f[0].getName()), ExpressionFactory.toLiteral(document.getObject(f[0].getName())));
                    } else {
                        Expression a = null;
                        for (Field aF : f) {
                            Expression b = (new Equals(new Var(aF.getName()), ExpressionFactory.toLiteral(document.getObject(aF.getName()))));
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
                            throw new PersistDocumentDuplicateIdException(entity);
                        }
                    }
                    for (Index index : uniqueIndexes) {
                        Field[] f = index.getFields();
                        Expression e1 = null;
                        if (f.length == 1) {
                            e1 = new Equals(new Var(f[0].getName()), ExpressionFactory.toLiteral(document.getObject(f[0].getName())));
                        } else {
                            Expression a = null;
                            for (Field aF : f) {
                                Expression b = (new Equals(new Var(aF.getName()),
                                        ExpressionFactory.toLiteral(document.getObject(aF.getName()))));
                                a = a == null ? b : new And(a, b);
                            }
                            e1 = a;
                        }
                        if (entity.getEntityCount(e1) > 0) {
                            throw new PersistDocumentDuplicateUniqueFieldsException(entity, index, document.getObject(f[0].getName()));
                        }
                    }
                    throw new RuntimeException("WouldNeverBeThrownException");
                }
            }
        }
        checkVeto(VetoableOperation.checkPersist, document);
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
    public boolean isRemovableDocument(Object k, boolean recurse) {
        try {
            if (!entity.getPersistenceUnit().getSecurityManager().isAllowedRemove(entity)) {
                return false;
            }
            Expression e = getFullNonRemovableDocumentsExpression();
            if (e != null && e.isValid()) {
                Expression a = new And(entity.getBuilder().idToExpression(k, UPQLUtils.THIS), e);
                if (entity.getEntityCount(a) > 0) {
                    return false;
                }
            }
            checkVeto(VetoableOperation.deletableDocument, k, recurse);
            return true;
        } catch (UPAException e) {
            // e.printStackTrace(); //To change body of catch statement use
            // Options | File Templates.
        }
        return false;
    }

    public boolean isUpdatableDocument(Object id) {
        try {
            if (!entity.getPersistenceUnit().getSecurityManager().isAllowedUpdate(entity)) {
                return false;
            }
            Expression e = getFullNonUpdatableDocumentsExpression();
            if (e != null && e.isValid()) {
                Expression a = new And(entity.getBuilder().idToExpression(id, UPQLUtils.THIS), e);
                if (entity.getEntityCount(a) > 0) {
                    return false;
                }
            }
            checkVeto(VetoableOperation.updatableDocument, id);
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
