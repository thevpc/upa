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
     * @creationdate 9/2/12 6:30 PM
     */
    public class EntityShieldAdapter : Net.TheVpc.Upa.EntityShield {

        private Net.TheVpc.Upa.EntityShield @base;

        public EntityShieldAdapter(Net.TheVpc.Upa.EntityShield @base) {
            this.@base = @base;
        }


        public virtual void Init(Net.TheVpc.Upa.Entity entity) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            @base.Init(entity);
        }


        public virtual void CheckClone(object oldId, object newId) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            @base.CheckClone(oldId, newId);
        }


        public virtual void CheckRename(object oldId, object newId) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            @base.CheckRename(oldId, newId);
        }


        public virtual bool IsDeletableDocument(object k, bool recurse) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return @base.IsDeletableDocument(k, recurse);
        }


        public virtual bool IsUpdatableDocument(object k) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return @base.IsUpdatableDocument(k);
        }


        public virtual bool IsUpdateFormulaSupported() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return @base.IsUpdateFormulaSupported();
        }


        public virtual bool IsUpdateFormulaOnPersistSupported() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return @base.IsUpdateFormulaOnPersistSupported();
        }


        public virtual bool IsUpdateFormulaOnUpdateSupported() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return @base.IsUpdateFormulaOnUpdateSupported();
        }

        public virtual bool IsLockingSupported() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return @base.IsLockingSupported();
        }

        public virtual bool IsPersistSupported() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return @base.IsPersistSupported();
        }

        public virtual bool IsUpdateSupported() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return @base.IsUpdateSupported();
        }

        public virtual bool IsDeleteSupported() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return @base.IsDeleteSupported();
        }

        public virtual bool IsCloneSupported() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return @base.IsCloneSupported();
        }

        public virtual bool IsRenameSupported() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return @base.IsRenameSupported();
        }

        public virtual bool IsKeyEditionSupported() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return @base.IsKeyEditionSupported();
        }

        public virtual bool IsNavigateSupported() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return @base.IsNavigateSupported();
        }

        public virtual bool IsGeneratedId() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return @base.IsGeneratedId();
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetFullNonDeletableDocumentsExpression() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return @base.GetFullNonDeletableDocumentsExpression();
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetFullNonRenamableDocumentsExpression() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return @base.GetFullNonRenamableDocumentsExpression();
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetFullNonCloneableDocumentsExpression() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return @base.GetFullNonCloneableDocumentsExpression();
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetFullNonUpdatableDocumentsExpression() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return @base.GetFullNonUpdatableDocumentsExpression();
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetNonDeletableDocumentsExpression() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return @base.GetNonDeletableDocumentsExpression();
        }

        public virtual void SetNonDeletableDocumentsExpression(Net.TheVpc.Upa.Expressions.Expression expression) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            @base.SetNonDeletableDocumentsExpression(expression);
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetNonUpdatableDocumentsExpression() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return @base.GetNonUpdatableDocumentsExpression();
        }

        public virtual void SetNonUpdatableDocumentsExpression(Net.TheVpc.Upa.Expressions.Expression expression) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            @base.SetNonUpdatableDocumentsExpression(expression);
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetNonRenamableDocumentsExpression() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return @base.GetNonRenamableDocumentsExpression();
        }

        public virtual void SetNonRenamableDocumentsExpression(Net.TheVpc.Upa.Expressions.Expression expression) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            @base.SetNonRenamableDocumentsExpression(expression);
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetNonCloneableDocumentsExpression() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return @base.GetNonCloneableDocumentsExpression();
        }

        public virtual void SetNonCloneableDocumentsExpression(Net.TheVpc.Upa.Expressions.Expression expression) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            @base.SetNonCloneableDocumentsExpression(expression);
        }

        public virtual void CheckPersist(Net.TheVpc.Upa.Document document) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            @base.CheckPersist(document);
        }

        public virtual void CheckUpdate(Net.TheVpc.Upa.Document updates, Net.TheVpc.Upa.Expressions.Expression condition) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            @base.CheckUpdate(updates, condition);
        }

        public virtual void CheckLoad() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            @base.CheckLoad();
        }

        public virtual void CheckNavigate() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            @base.CheckNavigate();
        }

        public virtual void CheckRemove(Net.TheVpc.Upa.Expressions.Expression condition, bool recurse, long toRemoveCount) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            @base.CheckRemove(condition, recurse, toRemoveCount);
        }

        public virtual bool IsPersistEnabled() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return @base.IsPersistEnabled();
        }

        public virtual bool IsUpdateEnabled() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return @base.IsUpdateEnabled();
        }

        public virtual bool IsDeleteEnabled() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return @base.IsDeleteEnabled();
        }

        public virtual bool IsRenameEnabled() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return @base.IsRenameEnabled();
        }

        public virtual bool IsCloneEnabled() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return @base.IsCloneEnabled();
        }


        public virtual bool IsClearSupported() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return @base.IsClearSupported();
        }


        public virtual bool IsPrivate() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return @base.IsPrivate();
        }


        public virtual bool IsTransient() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return @base.IsTransient();
        }


        public virtual void AddVeto(Net.TheVpc.Upa.VetoableOperation operation, Net.TheVpc.Upa.EntityShieldVeto veto) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            @base.AddVeto(operation, veto);
        }


        public virtual void RemoveVeto(Net.TheVpc.Upa.VetoableOperation operation, Net.TheVpc.Upa.EntityShieldVeto veto) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            @base.RemoveVeto(operation, veto);
        }


        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.EntityShieldVeto> GetVetoList(Net.TheVpc.Upa.VetoableOperation operation) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return @base.GetVetoList(operation);
        }


        public virtual void CheckInitialize() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            @base.CheckInitialize();
        }


        public virtual void CheckClear() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            @base.CheckClear();
        }

        public virtual bool IsSystem() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return @base.IsSystem();
        }
    }
}
