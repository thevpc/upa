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



namespace Net.TheVpc.Upa.Impl
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/2/12 5:47 PM
     */
    public class DefaultEntityShield : Net.TheVpc.Upa.EntityShield {

        private static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.TheVpc.Upa.Impl.DefaultEntityShield)).FullName);

        private Net.TheVpc.Upa.Entity entity;

        private System.Collections.Generic.IDictionary<Net.TheVpc.Upa.VetoableOperation , System.Collections.Generic.IList<Net.TheVpc.Upa.EntityShieldVeto>> vetoMap = new System.Collections.Generic.Dictionary<Net.TheVpc.Upa.VetoableOperation , System.Collections.Generic.IList<Net.TheVpc.Upa.EntityShieldVeto>>();

        private Net.TheVpc.Upa.Expressions.Expression nonDeletableRecordsExpression;

        private Net.TheVpc.Upa.Expressions.Expression nonUpdatableRecordsExpression;

        private Net.TheVpc.Upa.Expressions.Expression nonRenamableRecordsExpression;

        private Net.TheVpc.Upa.Expressions.Expression nonCloneableRecordsExpression;

        public virtual void Init(Net.TheVpc.Upa.Entity entity) {
            this.entity = entity;
        }


        public virtual Net.TheVpc.Upa.Expressions.Expression GetNonDeletableRecordsExpression() {
            return nonDeletableRecordsExpression;
        }


        public virtual void SetNonDeletableRecordsExpression(Net.TheVpc.Upa.Expressions.Expression expression) {
            this.nonDeletableRecordsExpression = expression;
        }


        public virtual Net.TheVpc.Upa.Expressions.Expression GetNonUpdatableRecordsExpression() {
            return nonUpdatableRecordsExpression;
        }


        public virtual void SetNonUpdatableRecordsExpression(Net.TheVpc.Upa.Expressions.Expression expression) {
            this.nonUpdatableRecordsExpression = expression;
        }


        public virtual Net.TheVpc.Upa.Expressions.Expression GetNonRenamableRecordsExpression() {
            return nonRenamableRecordsExpression;
        }


        public virtual void SetNonRenamableRecordsExpression(Net.TheVpc.Upa.Expressions.Expression expression) {
            this.nonRenamableRecordsExpression = expression;
        }


        public virtual Net.TheVpc.Upa.Expressions.Expression GetNonCloneableRecordsExpression() {
            return nonCloneableRecordsExpression;
        }


        public virtual void SetNonCloneableRecordsExpression(Net.TheVpc.Upa.Expressions.Expression expression) {
            this.nonCloneableRecordsExpression = expression;
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetFullNonRenamableRecordsExpression() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Entity parent = entity.GetParentEntity();
            Net.TheVpc.Upa.Expressions.Expression a = GetNonRenamableRecordsExpression();
            Net.TheVpc.Upa.Expressions.Expression b = parent == null ? null : entity.ParentToChildExpression(parent.GetShield().GetFullNonRenamableRecordsExpression());
            a = (a == null) ? ((Net.TheVpc.Upa.Expressions.Expression)(b)) : new Net.TheVpc.Upa.Expressions.Or(a, b);
            return (a == null || !a.IsValid()) ? null : a;
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetFullNonCloneableRecordsExpression() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Entity parent = entity.GetParentEntity();
            Net.TheVpc.Upa.Expressions.Expression a = GetNonCloneableRecordsExpression();
            Net.TheVpc.Upa.Expressions.Expression b = parent == null ? null : entity.ParentToChildExpression(parent.GetShield().GetFullNonRenamableRecordsExpression());
            a = (a == null) ? ((Net.TheVpc.Upa.Expressions.Expression)(b)) : new Net.TheVpc.Upa.Expressions.Or(a, b);
            return (a == null || !a.IsValid()) ? null : a;
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetFullNonDeletableRecordsExpression() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Entity parent = entity.GetParentEntity();
            Net.TheVpc.Upa.Expressions.Expression a = GetNonDeletableRecordsExpression();
            Net.TheVpc.Upa.Expressions.Expression b = parent == null ? null : entity.ParentToChildExpression(parent.GetShield().GetFullNonUpdatableRecordsExpression());
            a = (a == null) ? ((Net.TheVpc.Upa.Expressions.Expression)(b)) : new Net.TheVpc.Upa.Expressions.Or(a, b);
            return (a == null || !a.IsValid()) ? null : a;
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetFullNonUpdatableRecordsExpression() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Entity parent = entity.GetParentEntity();
            Net.TheVpc.Upa.Expressions.Expression a = GetNonUpdatableRecordsExpression();
            //if hierarchical entity then ignore parent
            Net.TheVpc.Upa.Expressions.Expression b = (parent == null || parent.GetName().Equals(entity.GetName())) ? null : entity.ParentToChildExpression(parent.GetShield().GetFullNonUpdatableRecordsExpression());
            a = (a == null) ? ((Net.TheVpc.Upa.Expressions.Expression)(b)) : new Net.TheVpc.Upa.Expressions.Or(a, b);
            return (a == null || !a.IsValid()) ? null : a;
        }

        protected internal virtual Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.EntityModifier> GetEffectiveModifiers() {
            return entity.GetModifiers();
        }


        public virtual bool IsLockingSupported() {
            return GetEffectiveModifiers().Contains(Net.TheVpc.Upa.EntityModifier.LOCK);
        }


        public virtual bool IsUpdateFormulaOnPersistSupported() {
            return GetEffectiveModifiers().Contains(Net.TheVpc.Upa.EntityModifier.VALIDATE_PERSIST);
        }


        public virtual bool IsUpdateFormulaOnUpdateSupported() {
            return GetEffectiveModifiers().Contains(Net.TheVpc.Upa.EntityModifier.VALIDATE_UPDATE);
        }


        public virtual bool IsUpdateFormulaSupported() {
            return !IsTransient() && (GetEffectiveModifiers().Contains(Net.TheVpc.Upa.EntityModifier.VALIDATE_PERSIST) || GetEffectiveModifiers().Contains(Net.TheVpc.Upa.EntityModifier.VALIDATE_UPDATE));
        }

        public bool IsPersistSupported() {
            return (!IsTransient()) && GetEffectiveModifiers().Contains(Net.TheVpc.Upa.EntityModifier.PERSIST);
        }

        public bool IsUpdateSupported() {
            return !IsTransient() && GetEffectiveModifiers().Contains(Net.TheVpc.Upa.EntityModifier.UPDATE);
        }

        public bool IsDeleteSupported() {
            return !IsTransient() && GetEffectiveModifiers().Contains(Net.TheVpc.Upa.EntityModifier.REMOVE);
        }

        public bool IsCloneSupported() {
            return !IsTransient() && GetEffectiveModifiers().Contains(Net.TheVpc.Upa.EntityModifier.CLONE);
        }

        public bool IsRenameSupported() {
            return !IsTransient() && GetEffectiveModifiers().Contains(Net.TheVpc.Upa.EntityModifier.RENAME);
        }

        public virtual bool IsClearSupported() {
            return GetEffectiveModifiers().Contains(Net.TheVpc.Upa.EntityModifier.CLEAR);
        }

        public virtual bool IsPersistEnabled() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return IsPersistSupported() && entity.GetPersistenceUnit().GetSecurityManager().IsAllowedPersist(entity) && IsNoVeto(Net.TheVpc.Upa.VetoableOperation.persistEnabled);
        }

        public virtual bool IsUpdateEnabled() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return IsUpdateSupported() && entity.GetPersistenceUnit().GetSecurityManager().IsAllowedUpdate(entity) && IsNoVeto(Net.TheVpc.Upa.VetoableOperation.updateEnabled);
        }

        public virtual bool IsDeleteEnabled() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return IsDeleteSupported() && entity.GetPersistenceUnit().GetSecurityManager().IsAllowedRemove(entity) && IsNoVeto(Net.TheVpc.Upa.VetoableOperation.removeEnabled);
        }

        public virtual bool IsRenameEnabled() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return IsRenameSupported() && entity.GetPersistenceUnit().GetSecurityManager().IsAllowedRename(entity) && IsNoVeto(Net.TheVpc.Upa.VetoableOperation.renameEnabled);
        }

        public virtual bool IsCloneEnabled() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return IsCloneSupported() && entity.GetPersistenceUnit().GetSecurityManager().IsAllowedClone(entity) && IsNoVeto(Net.TheVpc.Upa.VetoableOperation.cloneEnabled);
        }

        public virtual bool IsKeyEditionSupported() {
            return GetEffectiveModifiers().Contains(Net.TheVpc.Upa.EntityModifier.USER_ID);
        }

        public virtual bool IsNavigateSupported() {
            return GetEffectiveModifiers().Contains(Net.TheVpc.Upa.EntityModifier.NAVIGATE);
        }

        public virtual bool IsGeneratedId() {
            foreach (Net.TheVpc.Upa.Field field in entity.GetPrimaryFields()) {
                if (field.GetModifiers().Contains(Net.TheVpc.Upa.FieldModifier.PERSIST_FORMULA)) {
                    if (field.GetPersistFormula() is Net.TheVpc.Upa.Sequence) {
                        return true;
                    }
                }
            }
            return false;
        }

        public virtual void CheckLoad() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (!entity.GetPersistenceUnit().GetSecurityManager().IsAllowedLoad(entity)) {
                throw new Net.TheVpc.Upa.Exceptions.LoadRecordNotAllowedException(entity);
            }
            CheckVeto(Net.TheVpc.Upa.VetoableOperation.checkLoad);
        }

        public virtual void CheckNavigate() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (!IsNavigateSupported()) {
                throw new Net.TheVpc.Upa.Exceptions.NavigateEntityNotSupportedException(entity);
            }
            if (!entity.GetPersistenceUnit().GetSecurityManager().IsAllowedNavigate(entity)) {
                throw new Net.TheVpc.Upa.Exceptions.NavigateEntityNotAllowedException(entity);
            }
            CheckVeto(Net.TheVpc.Upa.VetoableOperation.checkNavigate);
        }

        public virtual void CheckRemove(Net.TheVpc.Upa.Expressions.Expression condition, bool recurse) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (entity.GetEntityCount(condition) == 0) {
                //nothing to remove!!
                return;
            }
            if (!IsDeleteSupported()) {
                throw new Net.TheVpc.Upa.Exceptions.UndeletableRecordException(entity);
            }
            if (!entity.GetPersistenceUnit().GetSecurityManager().IsAllowedRemove(entity)) {
                throw new Net.TheVpc.Upa.Exceptions.DeleteRecordNotAllowedException(entity);
            }
            Net.TheVpc.Upa.Expressions.Expression e = GetFullNonDeletableRecordsExpression();
            if (e != null && e.IsValid()) {
                Net.TheVpc.Upa.Expressions.Expression a = (condition == null) ? ((Net.TheVpc.Upa.Expressions.Expression)(e)) : new Net.TheVpc.Upa.Expressions.And(condition, e);
                if (entity.GetEntityCount(a) > 0) {
                    throw new Net.TheVpc.Upa.Exceptions.UndeletableRecordException(entity);
                }
            }
            Net.TheVpc.Upa.Entity p = entity.GetParentEntity();
            if (p != null) {
                Net.TheVpc.Upa.Expressions.Expression ss = entity.ChildToParentExpression(condition);
                //            p.getShield().checkRemove(ss, recurse);
                p.GetShield().CheckUpdate(p.GetBuilder().CreateRecord(), ss);
            }
            CheckVeto(Net.TheVpc.Upa.VetoableOperation.checkDelete, condition, recurse);
        }

        /**
             * @param oldId
             * @param newId
             * @throws Net.TheVpc.Upa.exceptions.UPAException
             * CloneRecordNotAllowedException, CloneRecordNotAllowedException,
             * CloneRecordNotAllowedException, CloneRecordOldKeyNotFoundException,
             * CloneRecordNewKeyInUseException
             */
        public virtual void CheckClone(object oldId, object newId) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (!entity.GetPersistenceUnit().GetSecurityManager().IsAllowedClone(entity)) {
                throw new Net.TheVpc.Upa.Exceptions.CloneRecordNotAllowedException(entity);
            }
            if (!IsCloneSupported()) {
                throw new Net.TheVpc.Upa.Exceptions.CloneRecordNotAllowedException(entity);
            }
            if (oldId != null) {
                Net.TheVpc.Upa.Expressions.Expression e = GetFullNonCloneableRecordsExpression();
                if (e != null && e.IsValid()) {
                    Net.TheVpc.Upa.Expressions.And a = new Net.TheVpc.Upa.Expressions.And(entity.GetBuilder().IdToExpression(oldId, null), e);
                    if (entity.GetEntityCount(a) > 0) {
                        throw new Net.TheVpc.Upa.Exceptions.CloneRecordNotAllowedException(entity);
                    }
                }
                object o = entity.CreateQueryBuilder().ById(oldId).SetFieldFilter(Net.TheVpc.Upa.Impl.Util.Filters.Fields2.PERSISTENT_NON_FORMULA).GetEntity<R>();
                if (o == null) {
                    throw new Net.TheVpc.Upa.Exceptions.CloneRecordOldKeyNotFoundException(entity);
                }
            }
            if (newId != null) {
                if (entity.Contains(newId)) {
                    throw new Net.TheVpc.Upa.Exceptions.CloneRecordNewKeyInUseException(entity);
                }
            }
            CheckVeto(Net.TheVpc.Upa.VetoableOperation.checkClone, oldId, newId);
        }

        /**
             * Check for the faisabilty of the rename operation. When oldId is null, the
             * verification is done for ALL keys (rname should be supported+enabled for
             * the curent user) When newId is null, the verification is done only on
             * oldId
             *
             * @param oldId old id
             * @param newId new id
             * @throws Net.TheVpc.Upa.exceptions.UPAException :
             * RenameRecordNotAllowedException, UnrenamableRecordException,
             * RenameRecordOldKeyNotFoundException, RenameRecordNewKeyInUseException
             */
        public virtual void CheckRename(object oldId, object newId) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (!entity.GetPersistenceUnit().GetSecurityManager().IsAllowedRename(entity)) {
                throw new Net.TheVpc.Upa.Exceptions.RenameRecordNotAllowedException(entity);
            }
            if (!IsRenameSupported()) {
                throw new Net.TheVpc.Upa.Exceptions.UnrenamableRecordException(entity);
            }
            if (oldId != null) {
                Net.TheVpc.Upa.Expressions.Expression e = GetFullNonRenamableRecordsExpression();
                if (e != null && e.IsValid()) {
                    Net.TheVpc.Upa.Expressions.And a = new Net.TheVpc.Upa.Expressions.And(entity.GetBuilder().IdToExpression(oldId, null), e);
                    if (entity.GetEntityCount(a) > 0) {
                        throw new Net.TheVpc.Upa.Exceptions.UnrenamableRecordException(entity);
                    }
                }
                object o = entity.CreateQueryBuilder().ById(oldId).SetFieldFilter(Net.TheVpc.Upa.Impl.Util.Filters.Fields2.PERSISTENT_NON_FORMULA).GetEntity<R>();
                if (o == null) {
                    throw new Net.TheVpc.Upa.Exceptions.RenameRecordOldKeyNotFoundException(entity);
                }
            }
            if (newId != null) {
                if (entity.Contains(newId)) {
                    throw new Net.TheVpc.Upa.Exceptions.RenameRecordNewKeyInUseException(entity);
                }
            }
            CheckVeto(Net.TheVpc.Upa.VetoableOperation.checkRename, oldId, newId);
        }


        public virtual void CheckUpdate(Net.TheVpc.Upa.Record updates, Net.TheVpc.Upa.Expressions.Expression condition) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (!entity.GetPersistenceUnit().GetSecurityManager().IsAllowedUpdate(entity)) {
                throw new Net.TheVpc.Upa.Exceptions.UpdateRecordNotAllowedException(entity);
            }
            if (!IsUpdateSupported()) {
                throw new Net.TheVpc.Upa.Exceptions.UnupdatableRecordException(entity);
            }
            Net.TheVpc.Upa.Expressions.Expression e = GetFullNonUpdatableRecordsExpression();
            if (e != null && e.IsValid()) {
                Net.TheVpc.Upa.Expressions.Expression a = (condition == null) ? ((Net.TheVpc.Upa.Expressions.Expression)(e)) : new Net.TheVpc.Upa.Expressions.And(condition, e);
                if (entity.GetEntityCount(a) > 0) {
                    throw new Net.TheVpc.Upa.Exceptions.UnupdatableRecordException(entity);
                }
            }
            long updated = 0;
            if ((updated = entity.GetEntityCount(condition)) == 0) {
                throw new Net.TheVpc.Upa.Exceptions.UpdateRecordKeyNotFoundException(entity, condition);
            }
            //TODO c koa cet unique fields qui n'impose pas toutes les validations
            if (false) {
                return;
            } else if (updated == 1) {
                if (condition != null) {
                    if (updates != null) {
                        Net.TheVpc.Upa.Expressions.Expression or = null;
                        foreach (Net.TheVpc.Upa.Index index in entity.GetIndexes(true)) {
                            Net.TheVpc.Upa.Field[] f = index.GetFields();
                            Net.TheVpc.Upa.Expressions.Expression a = null;
                            int found = 0;
                            foreach (Net.TheVpc.Upa.Field aF in f) {
                                if (updates.IsSet(aF.GetName())) {
                                    found++;
                                    Net.TheVpc.Upa.Expressions.Expression b = (new Net.TheVpc.Upa.Expressions.Equals(new Net.TheVpc.Upa.Expressions.Var(aF.GetName()), Net.TheVpc.Upa.Expressions.ExpressionFactory.ToLiteral(updates.GetObject<T>(aF.GetName()))));
                                    a = a == null ? ((Net.TheVpc.Upa.Expressions.Expression)(b)) : new Net.TheVpc.Upa.Expressions.And(a, b);
                                }
                            }
                            if (found != 0 && found != f.Length) {
                                throw new Net.TheVpc.Upa.Exceptions.UPAException("NotFound");
                            } else if (found == f.Length) {
                                or = or == null ? ((Net.TheVpc.Upa.Expressions.Expression)(a)) : new Net.TheVpc.Upa.Expressions.Or(or, a);
                            }
                        }
                        if (or != null) {
                            Net.TheVpc.Upa.Expressions.And and = new Net.TheVpc.Upa.Expressions.And(new Net.TheVpc.Upa.Expressions.Not(condition), or);
                            if (entity.GetEntityCount(and) > 0) {
                                throw new Net.TheVpc.Upa.Exceptions.UpdateRecordDuplicateKeyException(entity);
                            }
                        }
                    }
                }
            } else {
                if (updates != null) {
                    foreach (Net.TheVpc.Upa.Index index in entity.GetIndexes(true)) {
                        Net.TheVpc.Upa.Field[] f = index.GetFields();
                        foreach (Net.TheVpc.Upa.Field aF in f) {
                            if (updates.IsSet(aF.GetName())) {
                                throw new Net.TheVpc.Upa.Exceptions.UpdateRecordDuplicateKeyException(entity);
                            }
                        }
                    }
                }
            }
            Net.TheVpc.Upa.Entity p = entity.GetParentEntity();
            if (p != null) {
                Net.TheVpc.Upa.Expressions.Expression ss = entity.ChildToParentExpression(condition);
                try {
                    p.GetShield().CheckUpdate(null, ss);
                } catch (Net.TheVpc.Upa.Exceptions.UpdateRecordKeyNotFoundException ex) {
                    log.Warning(entity.GetName() + "'s parent seems not to be resolvable for condition (" + condition + "): " + ex);
                }
            }
            //ignore if parent not found!
            CheckVeto(Net.TheVpc.Upa.VetoableOperation.checkUpdate, updates, condition);
        }


        public virtual void CheckInitialize() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
        }


        public virtual void CheckClear() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (!IsDeleteSupported()) {
                throw new Net.TheVpc.Upa.Exceptions.UndeletableRecordException(entity);
            }
        }

        public virtual void CheckPersist(Net.TheVpc.Upa.Record record) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (!entity.GetPersistenceUnit().GetSecurityManager().IsAllowedPersist(entity)) {
                throw new Net.TheVpc.Upa.Exceptions.PersistRecordNotAllowedException(entity);
            }
            if (!IsPersistSupported()) {
                throw new Net.TheVpc.Upa.Exceptions.PersistRecordNotAllowedException(entity);
            }
            if (record != null) {
                // check parent is not read only
                if (entity.GetParentEntity() != null) {
                    Net.TheVpc.Upa.Expressions.Expression parentUnupdatable = entity.GetParentEntity().GetShield().GetFullNonUpdatableRecordsExpression();
                    if (parentUnupdatable != null && parentUnupdatable.IsValid()) {
                        Net.TheVpc.Upa.Relationship r = entity.GetCompositionRelation();
                        System.Collections.Generic.IList<Net.TheVpc.Upa.Field> df = r.GetSourceRole().GetFields();
                        System.Collections.Generic.IList<Net.TheVpc.Upa.Field> mf = r.GetTargetRole().GetFields();
                        object[] pko = new object[(mf).Count];
                        for (int i = 0; i < pko.Length; i++) {
                            pko[i] = record.GetObject<T>(df[i].GetName());
                        }
                        object pk = entity.CreateId(pko);
                        long c = entity.GetParentEntity().GetEntityCount(new Net.TheVpc.Upa.Expressions.And(parentUnupdatable, entity.GetParentEntity().GetBuilder().IdToExpression(pk, null)));
                        if (c > 0) {
                            throw new Net.TheVpc.Upa.Exceptions.UnupdatableRecordException(entity.GetParentEntity());
                        }
                    }
                }
                bool keyGenerated = IsGeneratedId();
                Net.TheVpc.Upa.Expressions.Expression keyExpresson = null;
                if (!keyGenerated) {
                    object key = entity.GetBuilder().RecordToId(record);
                    keyExpresson = entity.GetBuilder().IdToExpression(key, null);
                }
                Net.TheVpc.Upa.Entity p = entity.GetParentEntity();
                if (p != null) {
                    //Expression ss = childToParentExpression(toExpression(key));
                    Net.TheVpc.Upa.Expressions.Expression ss = entity.ChildToParentExpression(record);
                    if (ss != null) {
                        p.GetShield().CheckUpdate(null, ss);
                    }
                }
                System.Collections.Generic.IList<Net.TheVpc.Upa.Index> uniqueIndexes = entity.GetIndexes(true);
                if ((uniqueIndexes.Count==0)) {
                    if (!keyGenerated) {
                        if (entity.GetEntityCount(keyExpresson) > 0) {
                            throw new Net.TheVpc.Upa.Exceptions.InsertRecordDuplicateKeyException(entity);
                        }
                    }
                } else {
                    Net.TheVpc.Upa.Expressions.Expression or = null;
                    if (!keyGenerated) {
                        or = keyExpresson;
                    }
                    foreach (Net.TheVpc.Upa.Index index in uniqueIndexes) {
                        Net.TheVpc.Upa.Field[] f = index.GetFields();
                        Net.TheVpc.Upa.Expressions.Expression e1 = null;
                        if (f.Length == 1) {
                            e1 = new Net.TheVpc.Upa.Expressions.Equals(new Net.TheVpc.Upa.Expressions.Var(f[0].GetName()), Net.TheVpc.Upa.Expressions.ExpressionFactory.ToLiteral(record.GetObject<T>(f[0].GetName())));
                        } else {
                            Net.TheVpc.Upa.Expressions.Expression a = null;
                            foreach (Net.TheVpc.Upa.Field aF in f) {
                                Net.TheVpc.Upa.Expressions.Expression b = (new Net.TheVpc.Upa.Expressions.Equals(new Net.TheVpc.Upa.Expressions.Var(aF.GetName()), Net.TheVpc.Upa.Expressions.ExpressionFactory.ToLiteral(record.GetObject<T>(aF.GetName()))));
                                a = a == null ? ((Net.TheVpc.Upa.Expressions.Expression)(b)) : new Net.TheVpc.Upa.Expressions.And(a, b);
                            }
                            e1 = a;
                        }
                        or = or == null ? ((Net.TheVpc.Upa.Expressions.Expression)(e1)) : new Net.TheVpc.Upa.Expressions.Or(or, e1);
                    }
                    if (entity.GetEntityCount(or) > 0) {
                        // finer lookup of problem
                        if (!keyGenerated) {
                            if (entity.GetEntityCount(keyExpresson) > 0) {
                                throw new Net.TheVpc.Upa.Exceptions.InsertRecordDuplicateKeyException(entity);
                            }
                        }
                        foreach (Net.TheVpc.Upa.Index index in uniqueIndexes) {
                            Net.TheVpc.Upa.Field[] f = index.GetFields();
                            Net.TheVpc.Upa.Expressions.Expression e1 = null;
                            if (f.Length == 1) {
                                e1 = new Net.TheVpc.Upa.Expressions.Equals(new Net.TheVpc.Upa.Expressions.Var(f[0].GetName()), Net.TheVpc.Upa.Expressions.ExpressionFactory.ToLiteral(record.GetObject<T>(f[0].GetName())));
                            } else {
                                Net.TheVpc.Upa.Expressions.Expression a = null;
                                foreach (Net.TheVpc.Upa.Field aF in f) {
                                    Net.TheVpc.Upa.Expressions.Expression b = (new Net.TheVpc.Upa.Expressions.Equals(new Net.TheVpc.Upa.Expressions.Var(aF.GetName()), Net.TheVpc.Upa.Expressions.ExpressionFactory.ToLiteral(record.GetObject<T>(aF.GetName()))));
                                    a = a == null ? ((Net.TheVpc.Upa.Expressions.Expression)(b)) : new Net.TheVpc.Upa.Expressions.And(a, b);
                                }
                                e1 = a;
                            }
                            if (entity.GetEntityCount(e1) > 0) {
                                throw new Net.TheVpc.Upa.Exceptions.InsertRecordDuplicateUniqueFieldsException(entity, index, record.GetObject<T>(f[0].GetName()));
                            }
                        }
                        throw new System.Exception("WouldNeverBeThrownException");
                    }
                }
            }
            CheckVeto(Net.TheVpc.Upa.VetoableOperation.checkPersist, record);
        }

        public virtual bool IsSystem() {
            return GetEffectiveModifiers().Contains(Net.TheVpc.Upa.EntityModifier.SYSTEM);
        }

        public virtual bool IsPrivate() {
            return GetEffectiveModifiers().Contains(Net.TheVpc.Upa.EntityModifier.PRIVATE);
        }

        public virtual bool IsTransient() {
            return GetEffectiveModifiers().Contains(Net.TheVpc.Upa.EntityModifier.TRANSIENT);
        }

        public virtual bool IsDeletableRecord(object k, bool recurse) {
            try {
                if (!entity.GetPersistenceUnit().GetSecurityManager().IsAllowedRemove(entity)) {
                    return false;
                }
                Net.TheVpc.Upa.Expressions.Expression e = GetFullNonDeletableRecordsExpression();
                if (e != null && e.IsValid()) {
                    Net.TheVpc.Upa.Expressions.Expression a = new Net.TheVpc.Upa.Expressions.And(entity.GetBuilder().IdToExpression(k, null), e);
                    if (entity.GetEntityCount(a) > 0) {
                        return false;
                    }
                }
                CheckVeto(Net.TheVpc.Upa.VetoableOperation.deletableRecord, k, recurse);
                return true;
            } catch (Net.TheVpc.Upa.Exceptions.UPAException e) {
            }
            // e.printStackTrace(); //To change body of catch statement use
            // Options | File Templates.
            return false;
        }

        public virtual bool IsUpdatableRecord(object id) {
            try {
                if (!entity.GetPersistenceUnit().GetSecurityManager().IsAllowedUpdate(entity)) {
                    return false;
                }
                Net.TheVpc.Upa.Expressions.Expression e = GetFullNonUpdatableRecordsExpression();
                if (e != null && e.IsValid()) {
                    Net.TheVpc.Upa.Expressions.Expression a = new Net.TheVpc.Upa.Expressions.And(entity.GetBuilder().IdToExpression(id, null), e);
                    if (entity.GetEntityCount(a) > 0) {
                        return false;
                    }
                }
                CheckVeto(Net.TheVpc.Upa.VetoableOperation.updatableRecord, id);
                return true;
            } catch (Net.TheVpc.Upa.Exceptions.UPAException e) {
            }
            // e.printStackTrace(); //To change body of catch statement use
            // Options | File Templates.
            return false;
        }


        public virtual void AddVeto(Net.TheVpc.Upa.VetoableOperation operation, Net.TheVpc.Upa.EntityShieldVeto veto) {
            GetVetoList(operation, true).Add(veto);
        }


        public virtual void RemoveVeto(Net.TheVpc.Upa.VetoableOperation operation, Net.TheVpc.Upa.EntityShieldVeto veto) {
            System.Collections.Generic.IList<Net.TheVpc.Upa.EntityShieldVeto> vetoList = GetVetoList(operation, false);
            if (vetoList != null) {
                vetoList.Remove(veto);
            }
        }


        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.EntityShieldVeto> GetVetoList(Net.TheVpc.Upa.VetoableOperation operation) {
            System.Collections.Generic.IList<Net.TheVpc.Upa.EntityShieldVeto> vetoList = GetVetoList(operation, false);
            if (vetoList == null) {
                return Net.TheVpc.Upa.Impl.Util.PlatformUtils.EmptyList<T>();
            }
            return new System.Collections.Generic.List<Net.TheVpc.Upa.EntityShieldVeto>(vetoList);
        }

        protected internal virtual System.Collections.Generic.IList<Net.TheVpc.Upa.EntityShieldVeto> GetVetoList(Net.TheVpc.Upa.VetoableOperation operation, bool create) {
            System.Collections.Generic.IList<Net.TheVpc.Upa.EntityShieldVeto> entityShieldVetos = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<Net.TheVpc.Upa.VetoableOperation,System.Collections.Generic.IList<Net.TheVpc.Upa.EntityShieldVeto>>(vetoMap,operation);
            if (entityShieldVetos == null && create) {
                entityShieldVetos = new System.Collections.Generic.List<Net.TheVpc.Upa.EntityShieldVeto>();
                vetoMap[operation]=entityShieldVetos;
            }
            return entityShieldVetos;
        }

        protected internal virtual bool IsNoVeto(Net.TheVpc.Upa.VetoableOperation operation, params object [] @params) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            foreach (Net.TheVpc.Upa.EntityShieldVeto v in GetVetoList(operation)) {
                try {
                    v.CheckVeto(operation, entity, @params);
                } catch (Net.TheVpc.Upa.Exceptions.VetoException e) {
                    return false;
                }
            }
            return true;
        }

        protected internal virtual void CheckVeto(Net.TheVpc.Upa.VetoableOperation operation, params object [] @params) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            foreach (Net.TheVpc.Upa.EntityShieldVeto v in GetVetoList(operation)) {
                v.CheckVeto(operation, entity, @params);
            }
        }
    }
}
