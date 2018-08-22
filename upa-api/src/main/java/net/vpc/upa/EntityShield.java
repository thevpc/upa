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

    void init(Entity entity) ;

    boolean isUpdateFormulaSupported() ;

    boolean isUpdateFormulaOnPersistSupported() ;

    boolean isUpdateFormulaOnUpdateSupported() ;

    boolean isLockingSupported() ;

    boolean isPersistSupported() ;

    boolean isUpdateSupported() ;

    boolean isRemoveSupported();

    boolean isCloneSupported() ;

    boolean isRenameSupported() ;

    boolean isKeyEditionSupported() ;

    boolean isNavigateSupported() ;

    boolean isGeneratedId() ;

    Expression getFullNonRemovableDocumentsExpression();

    Expression getFullNonRenamableDocumentsExpression() ;

    Expression getFullNonCloneableDocumentsExpression() ;

    Expression getFullNonUpdatableDocumentsExpression() ;

    Expression getNonRemovableDocumentsExpression();

    void setNonRemovableDocumentsExpression(Expression expression);

    Expression getNonUpdatableDocumentsExpression() ;

    void setNonUpdatableDocumentsExpression(Expression expression) ;

    Expression getNonRenamableDocumentsExpression() ;

    void setNonRenamableDocumentsExpression(Expression expression) ;

    Expression getNonCloneableDocumentsExpression() ;

    void setNonCloneableDocumentsExpression(Expression expression) ;

    void checkInitialize() ;

    void checkClear() ;

    void checkPersist(Document document) ;

    void checkUpdate(Document updates, Expression condition) ;

    /**
     * @param oldId
     * @param newId
     * @throws net.vpc.upa.exceptions.UPAException
     * CloneDocumentNotAllowedException, CloneDocumentNotAllowedException,
     * CloneDocumentNotAllowedException, CloneDocumentOldKeyNotFoundException,
     * CloneDocumentNewKeyInUseException
     */
    void checkClone(Object oldId, Object newId) ;

    /**
     * Check for the feasibility of the rename operation. When oldId is null, the
     * verification is done for ALL keys (name should be supported+enabled for
     * the current user) When newId is null, the verification is done only on
     * oldId
     *
     * @param oldId old id
     * @param newId new id
     * @throws net.vpc.upa.exceptions.UPAException :
     * RenameDocumentNotAllowedException, UnrenamableDocumentException,
     * RenameDocumentOldKeyNotFoundException, RenameDocumentNewKeyInUseException
     */
    void checkRename(Object oldId, Object newId) ;

    void checkLoad() ;

    void checkNavigate() ;

    void checkRemove(Expression condition, boolean recurse, long toRemoveCount) ;

    boolean isRemovableDocument(Object k, boolean recurse);

    boolean isUpdatableDocument(Object k) ;

    boolean isPersistEnabled() ;

    boolean isUpdateEnabled() ;

    boolean isRemoveEnabled();

    boolean isRenameEnabled() ;

    boolean isCloneEnabled() ;

    boolean isClearSupported() ;

    boolean isSystem() ;

    boolean isPrivate() ;

    boolean isTransient() ;

    void addVeto(VetoableOperation operation, EntityShieldVeto veto) ;

    void removeVeto(VetoableOperation operation, EntityShieldVeto veto) ;

    List<EntityShieldVeto> getVetoList(VetoableOperation operation) ;
}
