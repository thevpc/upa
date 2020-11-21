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



namespace Net.TheVpc.Upa
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/2/12 5:38 PM
     */
    public interface EntityShield {

         void Init(Net.TheVpc.Upa.Entity entity) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsUpdateFormulaSupported() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsUpdateFormulaOnPersistSupported() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsUpdateFormulaOnUpdateSupported() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsLockingSupported() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsPersistSupported() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsUpdateSupported() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsDeleteSupported() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsCloneSupported() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsRenameSupported() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsKeyEditionSupported() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsNavigateSupported() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsGeneratedId() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Expressions.Expression GetFullNonDeletableDocumentsExpression() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Expressions.Expression GetFullNonRenamableDocumentsExpression() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Expressions.Expression GetFullNonCloneableDocumentsExpression() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Expressions.Expression GetFullNonUpdatableDocumentsExpression() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Expressions.Expression GetNonDeletableDocumentsExpression() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void SetNonDeletableDocumentsExpression(Net.TheVpc.Upa.Expressions.Expression expression) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Expressions.Expression GetNonUpdatableDocumentsExpression() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void SetNonUpdatableDocumentsExpression(Net.TheVpc.Upa.Expressions.Expression expression) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Expressions.Expression GetNonRenamableDocumentsExpression() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void SetNonRenamableDocumentsExpression(Net.TheVpc.Upa.Expressions.Expression expression) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Expressions.Expression GetNonCloneableDocumentsExpression() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void SetNonCloneableDocumentsExpression(Net.TheVpc.Upa.Expressions.Expression expression) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void CheckInitialize() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void CheckClear() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void CheckPersist(Net.TheVpc.Upa.Document document) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void CheckUpdate(Net.TheVpc.Upa.Document updates, Net.TheVpc.Upa.Expressions.Expression condition) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

        /**
             * @param oldId
             * @param newId
             * @throws Net.TheVpc.Upa.exceptions.UPAException
             * CloneDocumentNotAllowedException, CloneDocumentNotAllowedException,
             * CloneDocumentNotAllowedException, CloneDocumentOldKeyNotFoundException,
             * CloneDocumentNewKeyInUseException
             */
         void CheckClone(object oldId, object newId) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

        /**
             * Check for the feasibility of the rename operation. When oldId is null, the
             * verification is done for ALL keys (name should be supported+enabled for
             * the current user) When newId is null, the verification is done only on
             * oldId
             *
             * @param oldId old id
             * @param newId new id
             * @throws Net.TheVpc.Upa.exceptions.UPAException :
             * RenameDocumentNotAllowedException, UnrenamableDocumentException,
             * RenameDocumentOldKeyNotFoundException, RenameDocumentNewKeyInUseException
             */
         void CheckRename(object oldId, object newId) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void CheckLoad() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void CheckNavigate() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void CheckRemove(Net.TheVpc.Upa.Expressions.Expression condition, bool recurse, long toRemoveCount) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsDeletableDocument(object k, bool recurse) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsUpdatableDocument(object k) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsPersistEnabled() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsUpdateEnabled() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsDeleteEnabled() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsRenameEnabled() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsCloneEnabled() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsClearSupported() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsSystem() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsPrivate() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsTransient() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void AddVeto(Net.TheVpc.Upa.VetoableOperation operation, Net.TheVpc.Upa.EntityShieldVeto veto) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void RemoveVeto(Net.TheVpc.Upa.VetoableOperation operation, Net.TheVpc.Upa.EntityShieldVeto veto) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.TheVpc.Upa.EntityShieldVeto> GetVetoList(Net.TheVpc.Upa.VetoableOperation operation) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;
    }
}
