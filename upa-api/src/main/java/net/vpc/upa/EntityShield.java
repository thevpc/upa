/**
 * ====================================================================
 * UPA (Unstructured Persistence API)
 * Yet another ORM Framework
 * ++++++++++++++++++++++++++++++++++
 * Unstructured Persistence API, referred to as UPA, is a genuine effort
 * to raise programming language frameworks managing relational data in
 * applications using Java Platform, Standard Edition and Java Platform,
 * Enterprise Edition and Dot Net Framework equally to the next level of
 * handling ORM for mutable data structures. UPA is intended to provide
 * a solid reflection mechanisms to the mapped data structures while
 * affording to make changes at runtime of those data structures.
 * Besides, UPA has learned considerably of the leading ORM
 * (JPA, Hibernate/NHibernate, MyBatis and Entity Framework to name a few)
 * failures to satisfy very common even known to be trivial requirement in
 * enterprise applications.
 * <p>
 * Copyright (C) 2014-2015 Taha BEN SALAH
 * <p>
 * This program is free software; you can redistribute it and/or modify it under
 * the terms of the GNU General Public License as published by the Free Software
 * Foundation; either version 2 of the License, or (at your option) any later
 * version.
 * <p>
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE. See the GNU General Public License for more
 * details.
 * <p>
 * You should have received a copy of the GNU General Public License along with
 * this program; if not, write to the Free Software Foundation, Inc., 51
 * Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 * ====================================================================
 */
package net.vpc.upa;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Expression;

import java.util.List;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/2/12 5:38 PM
 */
public interface EntityShield {

    void init(Entity entity) throws UPAException;

    boolean isUpdateFormulaSupported() throws UPAException;

    boolean isUpdateFormulaOnPersistSupported() throws UPAException;

    boolean isUpdateFormulaOnUpdateSupported() throws UPAException;

    boolean isLockingSupported() throws UPAException;

    boolean isPersistSupported() throws UPAException;

    boolean isUpdateSupported() throws UPAException;

    boolean isDeleteSupported() throws UPAException;

    boolean isCloneSupported() throws UPAException;

    boolean isRenameSupported() throws UPAException;

    //    boolean isPrintSupported();
    boolean isKeyEditionSupported() throws UPAException;

    boolean isNavigateSupported() throws UPAException;

    boolean isGeneratedId() throws UPAException;

    Expression getFullNonDeletableDocumentsExpression() throws UPAException;

    Expression getFullNonRenamableDocumentsExpression() throws UPAException;

    Expression getFullNonCloneableDocumentsExpression() throws UPAException;

    Expression getFullNonUpdatableDocumentsExpression() throws UPAException;

    Expression getNonDeletableDocumentsExpression() throws UPAException;

    void setNonDeletableDocumentsExpression(Expression expression) throws UPAException;

    Expression getNonUpdatableDocumentsExpression() throws UPAException;

    void setNonUpdatableDocumentsExpression(Expression expression) throws UPAException;

    Expression getNonRenamableDocumentsExpression() throws UPAException;

    void setNonRenamableDocumentsExpression(Expression expression) throws UPAException;

    Expression getNonCloneableDocumentsExpression() throws UPAException;

    void setNonCloneableDocumentsExpression(Expression expression) throws UPAException;

    void checkInitialize() throws UPAException;

    void checkClear() throws UPAException;

    void checkPersist(Document document) throws UPAException;

    void checkUpdate(Document updates, Expression condition) throws UPAException;

    /**
     * @param oldId
     * @param newId
     * @throws net.vpc.upa.exceptions.UPAException
     * CloneDocumentNotAllowedException, CloneDocumentNotAllowedException,
     * CloneDocumentNotAllowedException, CloneDocumentOldKeyNotFoundException,
     * CloneDocumentNewKeyInUseException
     */
    void checkClone(Object oldId, Object newId) throws UPAException;

    /**
     * Check for the faisabilty of the rename operation. When oldId is null, the
     * verification is done for ALL keys (rname should be supported+enabled for
     * the curent user) When newId is null, the verification is done only on
     * oldId
     *
     * @param oldId old id
     * @param newId new id
     * @throws net.vpc.upa.exceptions.UPAException :
     * RenameDocumentNotAllowedException, UnrenamableDocumentException,
     * RenameDocumentOldKeyNotFoundException, RenameDocumentNewKeyInUseException
     */
    void checkRename(Object oldId, Object newId) throws UPAException;

    void checkLoad() throws UPAException;

    void checkNavigate() throws UPAException;

    void checkRemove(Expression condition, boolean recurse, long toRemoveCount) throws UPAException;

    // boolean isDeletableDocument(Key instanceID) {
    // return true;
    // }
    //
    // boolean isUpdatableDocument(Key instanceID) {
    // return true;
    // }
    boolean isDeletableDocument(Object k, boolean recurse) throws UPAException;

    boolean isUpdatableDocument(Object k) throws UPAException;

    boolean isPersistEnabled() throws UPAException;

    boolean isUpdateEnabled() throws UPAException;

    boolean isDeleteEnabled() throws UPAException;

    boolean isRenameEnabled() throws UPAException;

    boolean isCloneEnabled() throws UPAException;

    boolean isClearSupported() throws UPAException;

    boolean isSystem() throws UPAException;

    boolean isPrivate() throws UPAException;

    boolean isTransient() throws UPAException;

    //    boolean isFieldEditable(Field field, K instanceID) throws UPAException;
//
//    boolean isFieldVisible(Field field, K instanceID) throws UPAException;
//    boolean isAllowed(EntitySecurityAction a) throws UPAException;
//    boolean isAllowed(Field field, FieldSecurityAction a) throws UPAException;
    //    void setRenameSupported(boolean renameSupported);
//
//    void setCloneSupported(boolean cloneSupported);
//
//    void setDeleteSupported(boolean deleteSupported);
//
//    void setUpdateSupported(boolean updateSupported);
//
//    void setInsertSupported(boolean insertSupported);
//
////    void setPrintSupported(boolean printSupported);
//
//    void setClearSupported(boolean clearSupported);
//
//    void setValidateOnInsertSupported(boolean enable) ;
//
//    void setValidateOnUpdateSupported(boolean enable) ;
    void addVeto(VetoableOperation operation, EntityShieldVeto veto) throws UPAException;

    void removeVeto(VetoableOperation operation, EntityShieldVeto veto) throws UPAException;

    List<EntityShieldVeto> getVetoList(VetoableOperation operation) throws UPAException;
}
