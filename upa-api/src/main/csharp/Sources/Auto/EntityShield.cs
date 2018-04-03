/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.Vpc.Upa
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/2/12 5:38 PM
     */
    public interface EntityShield {

         void Init(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsUpdateFormulaSupported() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsUpdateFormulaOnPersistSupported() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsUpdateFormulaOnUpdateSupported() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsLockingSupported() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsPersistSupported() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsUpdateSupported() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsDeleteSupported() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsCloneSupported() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsRenameSupported() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsKeyEditionSupported() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsNavigateSupported() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsGeneratedId() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Expressions.Expression GetFullNonDeletableDocumentsExpression() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Expressions.Expression GetFullNonRenamableDocumentsExpression() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Expressions.Expression GetFullNonCloneableDocumentsExpression() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Expressions.Expression GetFullNonUpdatableDocumentsExpression() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Expressions.Expression GetNonDeletableDocumentsExpression() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void SetNonDeletableDocumentsExpression(Net.Vpc.Upa.Expressions.Expression expression) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Expressions.Expression GetNonUpdatableDocumentsExpression() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void SetNonUpdatableDocumentsExpression(Net.Vpc.Upa.Expressions.Expression expression) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Expressions.Expression GetNonRenamableDocumentsExpression() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void SetNonRenamableDocumentsExpression(Net.Vpc.Upa.Expressions.Expression expression) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Expressions.Expression GetNonCloneableDocumentsExpression() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void SetNonCloneableDocumentsExpression(Net.Vpc.Upa.Expressions.Expression expression) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void CheckInitialize() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void CheckClear() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void CheckPersist(Net.Vpc.Upa.Document document) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void CheckUpdate(Net.Vpc.Upa.Document updates, Net.Vpc.Upa.Expressions.Expression condition) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

        /**
             * @param oldId
             * @param newId
             * @throws net.vpc.upa.exceptions.UPAException
             * CloneDocumentNotAllowedException, CloneDocumentNotAllowedException,
             * CloneDocumentNotAllowedException, CloneDocumentOldKeyNotFoundException,
             * CloneDocumentNewKeyInUseException
             */
         void CheckClone(object oldId, object newId) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

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
         void CheckRename(object oldId, object newId) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void CheckLoad() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void CheckNavigate() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void CheckRemove(Net.Vpc.Upa.Expressions.Expression condition, bool recurse, long toRemoveCount) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsDeletableDocument(object k, bool recurse) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsUpdatableDocument(object k) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsPersistEnabled() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsUpdateEnabled() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsDeleteEnabled() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsRenameEnabled() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsCloneEnabled() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsClearSupported() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsSystem() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsPrivate() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsTransient() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void AddVeto(Net.Vpc.Upa.VetoableOperation operation, Net.Vpc.Upa.EntityShieldVeto veto) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void RemoveVeto(Net.Vpc.Upa.VetoableOperation operation, Net.Vpc.Upa.EntityShieldVeto veto) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.EntityShieldVeto> GetVetoList(Net.Vpc.Upa.VetoableOperation operation) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;
    }
}
