/**
 * ==================================================================== 
 * UPA (Unstructured Persistence API)
 *    Yet another ORM Framework
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
 *
 * Copyright (C) 2014-2015 Taha BEN SALAH
 *
 * This program is free software; you can redistribute it and/or modify it under
 * the terms of the GNU General Public License as published by the Free Software
 * Foundation; either version 2 of the License, or (at your option) any later
 * version.
 *
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE. See the GNU General Public License for more
 * details.
 *
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

    public void init(Entity entity) throws UPAException;

    public boolean isUpdateFormulaSupported() throws UPAException;

    public boolean isUpdateFormulaOnPersistSupported() throws UPAException;

    public boolean isUpdateFormulaOnUpdateSupported() throws UPAException;

    public boolean isLockingSupported() throws UPAException;

    public boolean isPersistSupported() throws UPAException;

    public boolean isUpdateSupported() throws UPAException;

    public boolean isDeleteSupported() throws UPAException;

    public boolean isCloneSupported() throws UPAException;

    public boolean isRenameSupported() throws UPAException;

    //    public boolean isPrintSupported();
    public boolean isKeyEditionSupported() throws UPAException;

    public boolean isNavigateSupported() throws UPAException;

    public boolean isGeneratedId() throws UPAException;

    public Expression getFullNonDeletableDocumentsExpression() throws UPAException;

    public Expression getFullNonRenamableDocumentsExpression() throws UPAException;

    public Expression getFullNonCloneableDocumentsExpression() throws UPAException;

    public Expression getFullNonUpdatableDocumentsExpression() throws UPAException;

    public Expression getNonDeletableDocumentsExpression() throws UPAException;

    public void setNonDeletableDocumentsExpression(Expression expression) throws UPAException;

    public Expression getNonUpdatableDocumentsExpression() throws UPAException;

    public void setNonUpdatableDocumentsExpression(Expression expression) throws UPAException;

    public Expression getNonRenamableDocumentsExpression() throws UPAException;

    public void setNonRenamableDocumentsExpression(Expression expression) throws UPAException;

    public Expression getNonCloneableDocumentsExpression() throws UPAException;

    public void setNonCloneableDocumentsExpression(Expression expression) throws UPAException;

    public void checkInitialize() throws UPAException;

    public void checkClear() throws UPAException;

    public void checkPersist(Document document) throws UPAException;

    public void checkUpdate(Document updates, Expression condition) throws UPAException;

    /**
     * @param oldId
     * @param newId
     * @throws net.vpc.upa.exceptions.UPAException
     * CloneDocumentNotAllowedException, CloneDocumentNotAllowedException,
     * CloneDocumentNotAllowedException, CloneDocumentOldKeyNotFoundException,
     * CloneDocumentNewKeyInUseException
     */
    public void checkClone(Object oldId, Object newId) throws UPAException;

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
    public void checkRename(Object oldId, Object newId) throws UPAException;

    public void checkLoad() throws UPAException;

    public void checkNavigate() throws UPAException;

    public void checkRemove(Expression condition, boolean recurse) throws UPAException;

    // public boolean isDeletableDocument(Key instanceID) {
    // return true;
    // }
    //
    // public boolean isUpdatableDocument(Key instanceID) {
    // return true;
    // }
    public boolean isDeletableDocument(Object k, boolean recurse) throws UPAException;

    public boolean isUpdatableDocument(Object k) throws UPAException;

    public boolean isPersistEnabled() throws UPAException;

    public boolean isUpdateEnabled() throws UPAException;

    public boolean isDeleteEnabled() throws UPAException;

    public boolean isRenameEnabled() throws UPAException;

    public boolean isCloneEnabled() throws UPAException;

    public boolean isClearSupported() throws UPAException;

    public boolean isSystem() throws UPAException;

    public boolean isPrivate() throws UPAException;

    public boolean isTransient() throws UPAException;

//    public boolean isFieldEditable(Field field, K instanceID) throws UPAException;
//
//    public boolean isFieldVisible(Field field, K instanceID) throws UPAException;
//    public boolean isAllowed(EntitySecurityAction a) throws UPAException;
//    public boolean isAllowed(Field field, FieldSecurityAction a) throws UPAException;
    //    public void setRenameSupported(boolean renameSupported);
//
//    public void setCloneSupported(boolean cloneSupported);
//
//    public void setDeleteSupported(boolean deleteSupported);
//
//    public void setUpdateSupported(boolean updateSupported);
//
//    public void setInsertSupported(boolean insertSupported);
//
////    public void setPrintSupported(boolean printSupported);
//
//    public void setClearSupported(boolean clearSupported);
//
//    public void setValidateOnInsertSupported(boolean enable) ;
//
//    public void setValidateOnUpdateSupported(boolean enable) ;
    public void addVeto(VetoableOperation operation, EntityShieldVeto veto) throws UPAException;

    public void removeVeto(VetoableOperation operation, EntityShieldVeto veto) throws UPAException;

    public List<EntityShieldVeto> getVetoList(VetoableOperation operation) throws UPAException;
}
