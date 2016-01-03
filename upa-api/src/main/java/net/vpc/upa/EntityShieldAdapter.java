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
 * @creationdate 9/2/12 6:30 PM
 */
public class EntityShieldAdapter implements EntityShield {

    private EntityShield base;

    public EntityShieldAdapter(EntityShield base) {
        this.base = base;
    }

    @Override
    public void init(Entity entity) throws UPAException {
        base.init(entity);
    }

    @Override
    public void checkClone(Object oldId, Object newId) throws UPAException {
        base.checkClone(oldId, newId);
    }

    @Override
    public void checkRename(Object oldId, Object newId) throws UPAException {
        base.checkRename(oldId, newId);
    }

    @Override
    public boolean isDeletableRecord(Object k, boolean recurse) throws UPAException {
        return base.isDeletableRecord(k, recurse);
    }

    @Override
    public boolean isUpdatableRecord(Object k) throws UPAException {
        return base.isUpdatableRecord(k);
    }

    @Override
    public boolean isUpdateFormulaSupported() throws UPAException {
        return base.isUpdateFormulaSupported();
    }

    @Override
    public boolean isUpdateFormulaOnPersistSupported() throws UPAException {
        return base.isUpdateFormulaOnPersistSupported();
    }

    @Override
    public boolean isUpdateFormulaOnUpdateSupported() throws UPAException {
        return base.isUpdateFormulaOnUpdateSupported();
    }

    public boolean isLockingSupported() throws UPAException {
        return base.isLockingSupported();
    }

    public boolean isPersistSupported() throws UPAException {
        return base.isPersistSupported();
    }

    public boolean isUpdateSupported() throws UPAException {
        return base.isUpdateSupported();
    }

    public boolean isDeleteSupported() throws UPAException {
        return base.isDeleteSupported();
    }

    public boolean isCloneSupported() throws UPAException {
        return base.isCloneSupported();
    }

    public boolean isRenameSupported() throws UPAException {
        return base.isRenameSupported();
    }

    public boolean isKeyEditionSupported() throws UPAException {
        return base.isKeyEditionSupported();
    }

    public boolean isNavigateSupported() throws UPAException {
        return base.isNavigateSupported();
    }

    public boolean isGeneratedId() throws UPAException {
        return base.isGeneratedId();
    }

    public Expression getFullNonDeletableRecordsExpression() throws UPAException {
        return base.getFullNonDeletableRecordsExpression();
    }

    public Expression getFullNonRenamableRecordsExpression() throws UPAException {
        return base.getFullNonRenamableRecordsExpression();
    }

    public Expression getFullNonCloneableRecordsExpression() throws UPAException {
        return base.getFullNonCloneableRecordsExpression();
    }

    public Expression getFullNonUpdatableRecordsExpression() throws UPAException {
        return base.getFullNonUpdatableRecordsExpression();
    }

    public Expression getNonDeletableRecordsExpression() throws UPAException {
        return base.getNonDeletableRecordsExpression();
    }

    public void setNonDeletableRecordsExpression(Expression expression) throws UPAException {
        base.setNonDeletableRecordsExpression(expression);
    }

    public Expression getNonUpdatableRecordsExpression() throws UPAException {
        return base.getNonUpdatableRecordsExpression();
    }

    public void setNonUpdatableRecordsExpression(Expression expression) throws UPAException {
        base.setNonUpdatableRecordsExpression(expression);
    }

    public Expression getNonRenamableRecordsExpression() throws UPAException {
        return base.getNonRenamableRecordsExpression();
    }

    public void setNonRenamableRecordsExpression(Expression expression) throws UPAException {
        base.setNonRenamableRecordsExpression(expression);
    }

    public Expression getNonCloneableRecordsExpression() throws UPAException {
        return base.getNonCloneableRecordsExpression();
    }

    public void setNonCloneableRecordsExpression(Expression expression) throws UPAException {
        base.setNonCloneableRecordsExpression(expression);
    }

    public void checkPersist(Record record) throws UPAException {
        base.checkPersist(record);
    }

    public void checkUpdate(Record updates, Expression condition) throws UPAException {
        base.checkUpdate(updates, condition);
    }

    public void checkLoad() throws UPAException {
        base.checkLoad();
    }

    public void checkNavigate() throws UPAException {
        base.checkNavigate();
    }

    public void checkRemove(Expression condition, boolean recurse) throws UPAException {
        base.checkRemove(condition, recurse);
    }

    public boolean isPersistEnabled() throws UPAException {
        return base.isPersistEnabled();
    }

    public boolean isUpdateEnabled() throws UPAException {
        return base.isUpdateEnabled();
    }

    public boolean isDeleteEnabled() throws UPAException {
        return base.isDeleteEnabled();
    }

    public boolean isRenameEnabled() throws UPAException {
        return base.isRenameEnabled();
    }

    public boolean isCloneEnabled() throws UPAException {
        return base.isCloneEnabled();
    }

    @Override
    public boolean isClearSupported() throws UPAException {
        return base.isClearSupported();
    }

    @Override
    public boolean isPrivate() throws UPAException {
        return base.isPrivate();
    }

    @Override
    public boolean isTransient() throws UPAException {
        return base.isTransient();
    }

    @Override
    public void addVeto(VetoableOperation operation, EntityShieldVeto veto) throws UPAException {
        base.addVeto(operation, veto);
    }

    @Override
    public void removeVeto(VetoableOperation operation, EntityShieldVeto veto) throws UPAException {
        base.removeVeto(operation, veto);
    }

    @Override
    public List<EntityShieldVeto> getVetoList(VetoableOperation operation) throws UPAException {
        return base.getVetoList(operation);
    }

    @Override
    public void checkInitialize() throws UPAException {
        base.checkInitialize();
    }

    @Override
    public void checkClear() throws UPAException {
        base.checkClear();
    }
//
//    @Override
//    public void checkReset() throws UPAException {
//        base.checkReset();
//    }

    public boolean isSystem() throws UPAException {
        return base.isSystem();
    }

}
