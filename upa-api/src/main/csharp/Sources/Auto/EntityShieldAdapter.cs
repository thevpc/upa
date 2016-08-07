/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE AS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.Vpc.Upa
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/2/12 6:30 PM
     */
    public class EntityShieldAdapter : Net.Vpc.Upa.EntityShield {

        private Net.Vpc.Upa.EntityShield @base;

        public EntityShieldAdapter(Net.Vpc.Upa.EntityShield @base) {
            this.@base = @base;
        }


        public virtual void Init(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            @base.Init(entity);
        }


        public virtual void CheckClone(object oldId, object newId) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            @base.CheckClone(oldId, newId);
        }


        public virtual void CheckRename(object oldId, object newId) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            @base.CheckRename(oldId, newId);
        }


        public virtual bool IsDeletableRecord(object k, bool recurse) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return @base.IsDeletableRecord(k, recurse);
        }


        public virtual bool IsUpdatableRecord(object k) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return @base.IsUpdatableRecord(k);
        }


        public virtual bool IsUpdateFormulaSupported() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return @base.IsUpdateFormulaSupported();
        }


        public virtual bool IsUpdateFormulaOnPersistSupported() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return @base.IsUpdateFormulaOnPersistSupported();
        }


        public virtual bool IsUpdateFormulaOnUpdateSupported() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return @base.IsUpdateFormulaOnUpdateSupported();
        }

        public virtual bool IsLockingSupported() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return @base.IsLockingSupported();
        }

        public virtual bool IsPersistSupported() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return @base.IsPersistSupported();
        }

        public virtual bool IsUpdateSupported() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return @base.IsUpdateSupported();
        }

        public virtual bool IsDeleteSupported() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return @base.IsDeleteSupported();
        }

        public virtual bool IsCloneSupported() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return @base.IsCloneSupported();
        }

        public virtual bool IsRenameSupported() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return @base.IsRenameSupported();
        }

        public virtual bool IsKeyEditionSupported() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return @base.IsKeyEditionSupported();
        }

        public virtual bool IsNavigateSupported() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return @base.IsNavigateSupported();
        }

        public virtual bool IsGeneratedId() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return @base.IsGeneratedId();
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetFullNonDeletableRecordsExpression() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return @base.GetFullNonDeletableRecordsExpression();
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetFullNonRenamableRecordsExpression() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return @base.GetFullNonRenamableRecordsExpression();
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetFullNonCloneableRecordsExpression() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return @base.GetFullNonCloneableRecordsExpression();
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetFullNonUpdatableRecordsExpression() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return @base.GetFullNonUpdatableRecordsExpression();
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetNonDeletableRecordsExpression() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return @base.GetNonDeletableRecordsExpression();
        }

        public virtual void SetNonDeletableRecordsExpression(Net.Vpc.Upa.Expressions.Expression expression) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            @base.SetNonDeletableRecordsExpression(expression);
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetNonUpdatableRecordsExpression() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return @base.GetNonUpdatableRecordsExpression();
        }

        public virtual void SetNonUpdatableRecordsExpression(Net.Vpc.Upa.Expressions.Expression expression) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            @base.SetNonUpdatableRecordsExpression(expression);
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetNonRenamableRecordsExpression() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return @base.GetNonRenamableRecordsExpression();
        }

        public virtual void SetNonRenamableRecordsExpression(Net.Vpc.Upa.Expressions.Expression expression) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            @base.SetNonRenamableRecordsExpression(expression);
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetNonCloneableRecordsExpression() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return @base.GetNonCloneableRecordsExpression();
        }

        public virtual void SetNonCloneableRecordsExpression(Net.Vpc.Upa.Expressions.Expression expression) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            @base.SetNonCloneableRecordsExpression(expression);
        }

        public virtual void CheckPersist(Net.Vpc.Upa.Record record) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            @base.CheckPersist(record);
        }

        public virtual void CheckUpdate(Net.Vpc.Upa.Record updates, Net.Vpc.Upa.Expressions.Expression condition) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            @base.CheckUpdate(updates, condition);
        }

        public virtual void CheckLoad() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            @base.CheckLoad();
        }

        public virtual void CheckNavigate() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            @base.CheckNavigate();
        }

        public virtual void CheckRemove(Net.Vpc.Upa.Expressions.Expression condition, bool recurse) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            @base.CheckRemove(condition, recurse);
        }

        public virtual bool IsPersistEnabled() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return @base.IsPersistEnabled();
        }

        public virtual bool IsUpdateEnabled() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return @base.IsUpdateEnabled();
        }

        public virtual bool IsDeleteEnabled() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return @base.IsDeleteEnabled();
        }

        public virtual bool IsRenameEnabled() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return @base.IsRenameEnabled();
        }

        public virtual bool IsCloneEnabled() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return @base.IsCloneEnabled();
        }


        public virtual bool IsClearSupported() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return @base.IsClearSupported();
        }


        public virtual bool IsPrivate() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return @base.IsPrivate();
        }


        public virtual bool IsTransient() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return @base.IsTransient();
        }


        public virtual void AddVeto(Net.Vpc.Upa.VetoableOperation operation, Net.Vpc.Upa.EntityShieldVeto veto) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            @base.AddVeto(operation, veto);
        }


        public virtual void RemoveVeto(Net.Vpc.Upa.VetoableOperation operation, Net.Vpc.Upa.EntityShieldVeto veto) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            @base.RemoveVeto(operation, veto);
        }


        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.EntityShieldVeto> GetVetoList(Net.Vpc.Upa.VetoableOperation operation) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return @base.GetVetoList(operation);
        }


        public virtual void CheckInitialize() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            @base.CheckInitialize();
        }


        public virtual void CheckClear() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            @base.CheckClear();
        }

        public virtual bool IsSystem() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return @base.IsSystem();
        }
    }
}
