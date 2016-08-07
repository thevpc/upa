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

    public Expression getFullNonDeletableRecordsExpression() throws UPAException;

    public Expression getFullNonRenamableRecordsExpression() throws UPAException;

    public Expression getFullNonCloneableRecordsExpression() throws UPAException;

    public Expression getFullNonUpdatableRecordsExpression() throws UPAException;

    public Expression getNonDeletableRecordsExpression() throws UPAException;

    public void setNonDeletableRecordsExpression(Expression expression) throws UPAException;

    public Expression getNonUpdatableRecordsExpression() throws UPAException;

    public void setNonUpdatableRecordsExpression(Expression expression) throws UPAException;

    public Expression getNonRenamableRecordsExpression() throws UPAException;

    public void setNonRenamableRecordsExpression(Expression expression) throws UPAException;

    public Expression getNonCloneableRecordsExpression() throws UPAException;

    public void setNonCloneableRecordsExpression(Expression expression) throws UPAException;

    public void checkInitialize() throws UPAException;

    public void checkClear() throws UPAException;

    public void checkPersist(Record record) throws UPAException;

    public void checkUpdate(Record updates, Expression condition) throws UPAException;

    /**
     * @param oldId
     * @param newId
     * @throws net.vpc.upa.exceptions.UPAException
     * CloneRecordNotAllowedException, CloneRecordNotAllowedException,
     * CloneRecordNotAllowedException, CloneRecordOldKeyNotFoundException,
     * CloneRecordNewKeyInUseException
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
     * RenameRecordNotAllowedException, UnrenamableRecordException,
     * RenameRecordOldKeyNotFoundException, RenameRecordNewKeyInUseException
     */
    public void checkRename(Object oldId, Object newId) throws UPAException;

    public void checkLoad() throws UPAException;

    public void checkNavigate() throws UPAException;

    public void checkRemove(Expression condition, boolean recurse) throws UPAException;

    // public boolean isDeletableRecord(Key instanceID) {
    // return true;
    // }
    //
    // public boolean isUpdatableRecord(Key instanceID) {
    // return true;
    // }
    public boolean isDeletableRecord(Object k, boolean recurse) throws UPAException;

    public boolean isUpdatableRecord(Object k) throws UPAException;

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
