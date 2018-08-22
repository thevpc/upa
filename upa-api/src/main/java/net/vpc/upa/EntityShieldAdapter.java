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
 * @creationdate 9/2/12 6:30 PM
 */
public class EntityShieldAdapter implements EntityShield {

    private EntityShield base;

    public EntityShieldAdapter(EntityShield base) {
        this.base = base;
    }

    @Override
    public void init(Entity entity)  {
        base.init(entity);
    }

    @Override
    public void checkClone(Object oldId, Object newId)  {
        base.checkClone(oldId, newId);
    }

    @Override
    public void checkRename(Object oldId, Object newId)  {
        base.checkRename(oldId, newId);
    }

    @Override
    public boolean isRemovableDocument(Object k, boolean recurse)  {
        return base.isRemovableDocument(k, recurse);
    }

    @Override
    public boolean isUpdatableDocument(Object k)  {
        return base.isUpdatableDocument(k);
    }

    @Override
    public boolean isUpdateFormulaSupported()  {
        return base.isUpdateFormulaSupported();
    }

    @Override
    public boolean isUpdateFormulaOnPersistSupported()  {
        return base.isUpdateFormulaOnPersistSupported();
    }

    @Override
    public boolean isUpdateFormulaOnUpdateSupported()  {
        return base.isUpdateFormulaOnUpdateSupported();
    }

    public boolean isLockingSupported()  {
        return base.isLockingSupported();
    }

    public boolean isPersistSupported()  {
        return base.isPersistSupported();
    }

    public boolean isUpdateSupported()  {
        return base.isUpdateSupported();
    }

    public boolean isRemoveSupported()  {
        return base.isRemoveSupported();
    }

    public boolean isCloneSupported()  {
        return base.isCloneSupported();
    }

    public boolean isRenameSupported()  {
        return base.isRenameSupported();
    }

    public boolean isKeyEditionSupported()  {
        return base.isKeyEditionSupported();
    }

    public boolean isNavigateSupported()  {
        return base.isNavigateSupported();
    }

    public boolean isGeneratedId()  {
        return base.isGeneratedId();
    }

    public Expression getFullNonRemovableDocumentsExpression()  {
        return base.getFullNonRemovableDocumentsExpression();
    }

    public Expression getFullNonRenamableDocumentsExpression()  {
        return base.getFullNonRenamableDocumentsExpression();
    }

    public Expression getFullNonCloneableDocumentsExpression()  {
        return base.getFullNonCloneableDocumentsExpression();
    }

    public Expression getFullNonUpdatableDocumentsExpression()  {
        return base.getFullNonUpdatableDocumentsExpression();
    }

    public Expression getNonRemovableDocumentsExpression()  {
        return base.getNonRemovableDocumentsExpression();
    }

    public void setNonRemovableDocumentsExpression(Expression expression)  {
        base.setNonRemovableDocumentsExpression(expression);
    }

    public Expression getNonUpdatableDocumentsExpression()  {
        return base.getNonUpdatableDocumentsExpression();
    }

    public void setNonUpdatableDocumentsExpression(Expression expression)  {
        base.setNonUpdatableDocumentsExpression(expression);
    }

    public Expression getNonRenamableDocumentsExpression()  {
        return base.getNonRenamableDocumentsExpression();
    }

    public void setNonRenamableDocumentsExpression(Expression expression)  {
        base.setNonRenamableDocumentsExpression(expression);
    }

    public Expression getNonCloneableDocumentsExpression()  {
        return base.getNonCloneableDocumentsExpression();
    }

    public void setNonCloneableDocumentsExpression(Expression expression)  {
        base.setNonCloneableDocumentsExpression(expression);
    }

    public void checkPersist(Document document)  {
        base.checkPersist(document);
    }

    public void checkUpdate(Document updates, Expression condition)  {
        base.checkUpdate(updates, condition);
    }

    public void checkLoad()  {
        base.checkLoad();
    }

    public void checkNavigate()  {
        base.checkNavigate();
    }

    public void checkRemove(Expression condition, boolean recurse, long toRemoveCount)  {
        base.checkRemove(condition, recurse, toRemoveCount);
    }

    public boolean isPersistEnabled()  {
        return base.isPersistEnabled();
    }

    public boolean isUpdateEnabled()  {
        return base.isUpdateEnabled();
    }

    public boolean isRemoveEnabled()  {
        return base.isRemoveEnabled();
    }

    public boolean isRenameEnabled()  {
        return base.isRenameEnabled();
    }

    public boolean isCloneEnabled()  {
        return base.isCloneEnabled();
    }

    @Override
    public boolean isClearSupported()  {
        return base.isClearSupported();
    }

    @Override
    public boolean isPrivate()  {
        return base.isPrivate();
    }

    @Override
    public boolean isTransient()  {
        return base.isTransient();
    }

    @Override
    public void addVeto(VetoableOperation operation, EntityShieldVeto veto)  {
        base.addVeto(operation, veto);
    }

    @Override
    public void removeVeto(VetoableOperation operation, EntityShieldVeto veto)  {
        base.removeVeto(operation, veto);
    }

    @Override
    public List<EntityShieldVeto> getVetoList(VetoableOperation operation)  {
        return base.getVetoList(operation);
    }

    @Override
    public void checkInitialize()  {
        base.checkInitialize();
    }

    @Override
    public void checkClear()  {
        base.checkClear();
    }
//
//    @Override
//    public void checkReset()  {
//        base.checkReset();
//    }

    public boolean isSystem()  {
        return base.isSystem();
    }

}
