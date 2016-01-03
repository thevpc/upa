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



namespace Net.Vpc.Upa.Impl
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/2/12 5:47 PM
     */
    public class DefaultEntityShield : Net.Vpc.Upa.EntityShield {

        private static readonly Net.Vpc.Upa.Filters.FieldFilter PERSISTENT_NON_FORMULA = Net.Vpc.Upa.Filters.Fields.ByModifiersNoneOf(Net.Vpc.Upa.FieldModifier.PERSIST_FORMULA, Net.Vpc.Upa.FieldModifier.UPDATE_FORMULA, Net.Vpc.Upa.FieldModifier.TRANSIENT);

        private Net.Vpc.Upa.Entity entity;

        private System.Collections.Generic.IDictionary<Net.Vpc.Upa.VetoableOperation , System.Collections.Generic.IList<Net.Vpc.Upa.EntityShieldVeto>> vetoMap = new System.Collections.Generic.Dictionary<Net.Vpc.Upa.VetoableOperation , System.Collections.Generic.IList<Net.Vpc.Upa.EntityShieldVeto>>();

        private Net.Vpc.Upa.Expressions.Expression nonDeletableRecordsExpression;

        private Net.Vpc.Upa.Expressions.Expression nonUpdatableRecordsExpression;

        private Net.Vpc.Upa.Expressions.Expression nonRenamableRecordsExpression;

        private Net.Vpc.Upa.Expressions.Expression nonCloneableRecordsExpression;

        public virtual void Init(Net.Vpc.Upa.Entity entity) {
            this.entity = entity;
        }


        public virtual Net.Vpc.Upa.Expressions.Expression GetNonDeletableRecordsExpression() {
            return nonDeletableRecordsExpression;
        }


        public virtual void SetNonDeletableRecordsExpression(Net.Vpc.Upa.Expressions.Expression expression) {
            this.nonDeletableRecordsExpression = expression;
        }


        public virtual Net.Vpc.Upa.Expressions.Expression GetNonUpdatableRecordsExpression() {
            return nonUpdatableRecordsExpression;
        }


        public virtual void SetNonUpdatableRecordsExpression(Net.Vpc.Upa.Expressions.Expression expression) {
            this.nonUpdatableRecordsExpression = expression;
        }


        public virtual Net.Vpc.Upa.Expressions.Expression GetNonRenamableRecordsExpression() {
            return nonRenamableRecordsExpression;
        }


        public virtual void SetNonRenamableRecordsExpression(Net.Vpc.Upa.Expressions.Expression expression) {
            this.nonRenamableRecordsExpression = expression;
        }


        public virtual Net.Vpc.Upa.Expressions.Expression GetNonCloneableRecordsExpression() {
            return nonCloneableRecordsExpression;
        }


        public virtual void SetNonCloneableRecordsExpression(Net.Vpc.Upa.Expressions.Expression expression) {
            this.nonCloneableRecordsExpression = expression;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetFullNonRenamableRecordsExpression() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Entity parent = entity.GetParentEntity();
            Net.Vpc.Upa.Expressions.Expression a = GetNonRenamableRecordsExpression();
            Net.Vpc.Upa.Expressions.Expression b = parent == null ? null : entity.ParentToChildExpression(parent.GetShield().GetFullNonRenamableRecordsExpression());
            a = (a == null) ? ((Net.Vpc.Upa.Expressions.Expression)(b)) : new Net.Vpc.Upa.Expressions.Or(a, b);
            return (a == null || !a.IsValid()) ? null : a;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetFullNonCloneableRecordsExpression() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Entity parent = entity.GetParentEntity();
            Net.Vpc.Upa.Expressions.Expression a = GetNonCloneableRecordsExpression();
            Net.Vpc.Upa.Expressions.Expression b = parent == null ? null : entity.ParentToChildExpression(parent.GetShield().GetFullNonRenamableRecordsExpression());
            a = (a == null) ? ((Net.Vpc.Upa.Expressions.Expression)(b)) : new Net.Vpc.Upa.Expressions.Or(a, b);
            return (a == null || !a.IsValid()) ? null : a;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetFullNonDeletableRecordsExpression() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Entity parent = entity.GetParentEntity();
            Net.Vpc.Upa.Expressions.Expression a = GetNonDeletableRecordsExpression();
            Net.Vpc.Upa.Expressions.Expression b = parent == null ? null : entity.ParentToChildExpression(parent.GetShield().GetFullNonUpdatableRecordsExpression());
            a = (a == null) ? ((Net.Vpc.Upa.Expressions.Expression)(b)) : new Net.Vpc.Upa.Expressions.Or(a, b);
            return (a == null || !a.IsValid()) ? null : a;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetFullNonUpdatableRecordsExpression() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Entity parent = entity.GetParentEntity();
            Net.Vpc.Upa.Expressions.Expression a = GetNonUpdatableRecordsExpression();
            Net.Vpc.Upa.Expressions.Expression b = parent == null ? null : entity.ParentToChildExpression(parent.GetShield().GetFullNonUpdatableRecordsExpression());
            a = (a == null) ? ((Net.Vpc.Upa.Expressions.Expression)(b)) : new Net.Vpc.Upa.Expressions.Or(a, b);
            return (a == null || !a.IsValid()) ? null : a;
        }

        protected internal virtual Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> GetEffectiveModifiers() {
            return entity.GetModifiers();
        }


        public virtual bool IsLockingSupported() {
            return GetEffectiveModifiers().Contains(Net.Vpc.Upa.EntityModifier.LOCK);
        }


        public virtual bool IsUpdateFormulaOnPersistSupported() {
            return GetEffectiveModifiers().Contains(Net.Vpc.Upa.EntityModifier.VALIDATE_INSERT);
        }


        public virtual bool IsUpdateFormulaOnUpdateSupported() {
            return GetEffectiveModifiers().Contains(Net.Vpc.Upa.EntityModifier.VALIDATE_UPDATE);
        }


        public virtual bool IsUpdateFormulaSupported() {
            return !IsTransient() && (GetEffectiveModifiers().Contains(Net.Vpc.Upa.EntityModifier.VALIDATE_INSERT) || GetEffectiveModifiers().Contains(Net.Vpc.Upa.EntityModifier.VALIDATE_UPDATE));
        }

        public bool IsPersistSupported() {
            return (!IsTransient()) && GetEffectiveModifiers().Contains(Net.Vpc.Upa.EntityModifier.PERSIST);
        }

        public bool IsUpdateSupported() {
            return !IsTransient() && GetEffectiveModifiers().Contains(Net.Vpc.Upa.EntityModifier.UPDATE);
        }

        public bool IsDeleteSupported() {
            return !IsTransient() && GetEffectiveModifiers().Contains(Net.Vpc.Upa.EntityModifier.REMOVE);
        }

        public bool IsCloneSupported() {
            return !IsTransient() && GetEffectiveModifiers().Contains(Net.Vpc.Upa.EntityModifier.CLONE);
        }

        public bool IsRenameSupported() {
            return !IsTransient() && GetEffectiveModifiers().Contains(Net.Vpc.Upa.EntityModifier.RENAME);
        }

        public virtual bool IsClearSupported() {
            return GetEffectiveModifiers().Contains(Net.Vpc.Upa.EntityModifier.CLEAR);
        }

        public virtual bool IsPersistEnabled() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return IsPersistSupported() && entity.GetPersistenceUnit().GetSecurityManager().IsAllowedPersist(entity) && IsNoVeto(Net.Vpc.Upa.VetoableOperation.insertEnabled);
        }

        public virtual bool IsUpdateEnabled() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return IsUpdateSupported() && entity.GetPersistenceUnit().GetSecurityManager().IsAllowedUpdate(entity) && IsNoVeto(Net.Vpc.Upa.VetoableOperation.updateEnabled);
        }

        public virtual bool IsDeleteEnabled() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return IsDeleteSupported() && entity.GetPersistenceUnit().GetSecurityManager().IsAllowedRemove(entity) && IsNoVeto(Net.Vpc.Upa.VetoableOperation.deleteEnabled);
        }

        public virtual bool IsRenameEnabled() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return IsRenameSupported() && entity.GetPersistenceUnit().GetSecurityManager().IsAllowedRename(entity) && IsNoVeto(Net.Vpc.Upa.VetoableOperation.renameEnabled);
        }

        public virtual bool IsCloneEnabled() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return IsCloneSupported() && entity.GetPersistenceUnit().GetSecurityManager().IsAllowedClone(entity) && IsNoVeto(Net.Vpc.Upa.VetoableOperation.cloneEnabled);
        }

        public virtual bool IsKeyEditionSupported() {
            return GetEffectiveModifiers().Contains(Net.Vpc.Upa.EntityModifier.USER_ID);
        }

        public virtual bool IsNavigateSupported() {
            return GetEffectiveModifiers().Contains(Net.Vpc.Upa.EntityModifier.NAVIGATE);
        }

        public virtual bool IsGeneratedId() {
            foreach (Net.Vpc.Upa.Field field in entity.GetPrimaryFields()) {
                if (field.GetModifiers().Contains(Net.Vpc.Upa.FieldModifier.PERSIST_FORMULA)) {
                    if (field.GetInsertFormula() is Net.Vpc.Upa.Sequence) {
                        return true;
                    }
                }
            }
            return false;
        }

        public virtual void CheckLoad() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (!entity.GetPersistenceUnit().GetSecurityManager().IsAllowedLoad(entity)) {
                throw new Net.Vpc.Upa.Exceptions.LoadRecordNotAllowedException(entity);
            }
            CheckVeto(Net.Vpc.Upa.VetoableOperation.checkLoad);
        }

        public virtual void CheckNavigate() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (!IsNavigateSupported()) {
                throw new Net.Vpc.Upa.Exceptions.NavigateEntityNotSupportedException(entity);
            }
            if (!entity.GetPersistenceUnit().GetSecurityManager().IsAllowedNavigate(entity)) {
                throw new Net.Vpc.Upa.Exceptions.NavigateEntityNotAllowedException(entity);
            }
            CheckVeto(Net.Vpc.Upa.VetoableOperation.checkNavigate);
        }

        public virtual void CheckRemove(Net.Vpc.Upa.Expressions.Expression condition, bool recurse) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (entity.GetEntityCount(condition) == 0) {
                //nothing to remove!!
                return;
            }
            if (!IsDeleteSupported()) {
                throw new Net.Vpc.Upa.Exceptions.UndeletableRecordException(entity);
            }
            if (!entity.GetPersistenceUnit().GetSecurityManager().IsAllowedRemove(entity)) {
                throw new Net.Vpc.Upa.Exceptions.DeleteRecordNotAllowedException(entity);
            }
            Net.Vpc.Upa.Expressions.Expression e = GetFullNonDeletableRecordsExpression();
            if (e != null && e.IsValid()) {
                Net.Vpc.Upa.Expressions.Expression a = (condition == null) ? ((Net.Vpc.Upa.Expressions.Expression)(e)) : new Net.Vpc.Upa.Expressions.And(condition, e);
                if (entity.GetEntityCount(a) > 0) {
                    throw new Net.Vpc.Upa.Exceptions.UndeletableRecordException(entity);
                }
            }
            Net.Vpc.Upa.Entity p = entity.GetParentEntity();
            if (p != null) {
                Net.Vpc.Upa.Expressions.Expression ss = entity.ChildToParentExpression(condition);
                p.GetShield().CheckRemove(ss, recurse);
            }
            CheckVeto(Net.Vpc.Upa.VetoableOperation.checkDelete, condition, recurse);
        }

        /**
             * @param oldId
             * @param newId
             * @throws net.vpc.upa.exceptions.UPAException
             * CloneRecordNotAllowedException, CloneRecordNotAllowedException,
             * CloneRecordNotAllowedException, CloneRecordOldKeyNotFoundException,
             * CloneRecordNewKeyInUseException
             */
        public virtual void CheckClone(object oldId, object newId) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (!entity.GetPersistenceUnit().GetSecurityManager().IsAllowedClone(entity)) {
                throw new Net.Vpc.Upa.Exceptions.CloneRecordNotAllowedException(entity);
            }
            if (!IsCloneSupported()) {
                throw new Net.Vpc.Upa.Exceptions.CloneRecordNotAllowedException(entity);
            }
            if (oldId != null) {
                Net.Vpc.Upa.Expressions.Expression e = GetFullNonCloneableRecordsExpression();
                if (e != null && e.IsValid()) {
                    Net.Vpc.Upa.Expressions.And a = new Net.Vpc.Upa.Expressions.And(entity.GetBuilder().IdToExpression(oldId, null), e);
                    if (entity.GetEntityCount(a) > 0) {
                        throw new Net.Vpc.Upa.Exceptions.CloneRecordNotAllowedException(entity);
                    }
                }
                object o = entity.CreateQueryBuilder().SetId(oldId).SetFieldFilter(PERSISTENT_NON_FORMULA).GetEntity<object>();
                if (o == null) {
                    throw new Net.Vpc.Upa.Exceptions.CloneRecordOldKeyNotFoundException(entity);
                }
            }
            if (newId != null) {
                if (entity.Contains(newId)) {
                    throw new Net.Vpc.Upa.Exceptions.CloneRecordNewKeyInUseException(entity);
                }
            }
            CheckVeto(Net.Vpc.Upa.VetoableOperation.checkClone, oldId, newId);
        }

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
        public virtual void CheckRename(object oldId, object newId) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (!entity.GetPersistenceUnit().GetSecurityManager().IsAllowedRename(entity)) {
                throw new Net.Vpc.Upa.Exceptions.RenameRecordNotAllowedException(entity);
            }
            if (!IsRenameSupported()) {
                throw new Net.Vpc.Upa.Exceptions.UnrenamableRecordException(entity);
            }
            if (oldId != null) {
                Net.Vpc.Upa.Expressions.Expression e = GetFullNonRenamableRecordsExpression();
                if (e != null && e.IsValid()) {
                    Net.Vpc.Upa.Expressions.And a = new Net.Vpc.Upa.Expressions.And(entity.GetBuilder().IdToExpression(oldId, null), e);
                    if (entity.GetEntityCount(a) > 0) {
                        throw new Net.Vpc.Upa.Exceptions.UnrenamableRecordException(entity);
                    }
                }
                object o = entity.CreateQueryBuilder().SetId(oldId).SetFieldFilter(PERSISTENT_NON_FORMULA).GetEntity<object>();
                if (o == null) {
                    throw new Net.Vpc.Upa.Exceptions.RenameRecordOldKeyNotFoundException(entity);
                }
            }
            if (newId != null) {
                if (entity.Contains(newId)) {
                    throw new Net.Vpc.Upa.Exceptions.RenameRecordNewKeyInUseException(entity);
                }
            }
            CheckVeto(Net.Vpc.Upa.VetoableOperation.checkRename, oldId, newId);
        }

        public virtual void CheckUpdate(Net.Vpc.Upa.Record updates, Net.Vpc.Upa.Expressions.Expression condition) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (!entity.GetPersistenceUnit().GetSecurityManager().IsAllowedUpdate(entity)) {
                throw new Net.Vpc.Upa.Exceptions.UpdateRecordNotAllowedException(entity);
            }
            if (!IsUpdateSupported()) {
                throw new Net.Vpc.Upa.Exceptions.UnupdatableRecordException(entity);
            }
            Net.Vpc.Upa.Expressions.Expression e = GetFullNonUpdatableRecordsExpression();
            if (e != null && e.IsValid()) {
                Net.Vpc.Upa.Expressions.Expression a = (condition == null) ? ((Net.Vpc.Upa.Expressions.Expression)(e)) : new Net.Vpc.Upa.Expressions.And(condition, e);
                if (entity.GetEntityCount(a) > 0) {
                    throw new Net.Vpc.Upa.Exceptions.UnupdatableRecordException(entity);
                }
            }
            long updated = 0;
            if ((updated = entity.GetEntityCount(condition)) == 0) {
                throw new Net.Vpc.Upa.Exceptions.UpdateRecordKeyNotFoundException(entity, condition);
            }
            //TODO c koa cet unique fields qui n'impose pas toutes les validations
            if (false) {
                return;
            } else if (updated == 1) {
                if (condition != null) {
                    if (updates != null) {
                        Net.Vpc.Upa.Expressions.Expression or = null;
                        foreach (Net.Vpc.Upa.Index index in entity.GetIndexes(true)) {
                            Net.Vpc.Upa.Field[] f = index.GetFields();
                            Net.Vpc.Upa.Expressions.Expression a = null;
                            int found = 0;
                            foreach (Net.Vpc.Upa.Field aF in f) {
                                if (updates.IsSet(aF.GetName())) {
                                    found++;
                                    Net.Vpc.Upa.Expressions.Expression b = (new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var(aF.GetName()), Net.Vpc.Upa.Expressions.ExpressionFactory.ToLiteral(updates.GetObject<object>(aF.GetName()))));
                                    a = a == null ? ((Net.Vpc.Upa.Expressions.Expression)(b)) : new Net.Vpc.Upa.Expressions.And(a, b);
                                }
                            }
                            if (found != 0 && found != f.Length) {
                                throw new Net.Vpc.Upa.Exceptions.UPAException("NotFound");
                            } else if (found == f.Length) {
                                or = or == null ? ((Net.Vpc.Upa.Expressions.Expression)(a)) : new Net.Vpc.Upa.Expressions.Or(or, a);
                            }
                        }
                        if (or != null) {
                            Net.Vpc.Upa.Expressions.And and = new Net.Vpc.Upa.Expressions.And(new Net.Vpc.Upa.Expressions.Not(condition), or);
                            if (entity.GetEntityCount(and) > 0) {
                                throw new Net.Vpc.Upa.Exceptions.UpdateRecordDuplicateKeyException(entity);
                            }
                        }
                    }
                }
            } else {
                if (updates != null) {
                    foreach (Net.Vpc.Upa.Index index in entity.GetIndexes(true)) {
                        Net.Vpc.Upa.Field[] f = index.GetFields();
                        foreach (Net.Vpc.Upa.Field aF in f) {
                            if (updates.IsSet(aF.GetName())) {
                                throw new Net.Vpc.Upa.Exceptions.UpdateRecordDuplicateKeyException(entity);
                            }
                        }
                    }
                }
            }
            Net.Vpc.Upa.Entity p = entity.GetParentEntity();
            if (p != null) {
                Net.Vpc.Upa.Expressions.Expression ss = entity.ChildToParentExpression(condition);
                p.GetShield().CheckUpdate(null, ss);
            }
            CheckVeto(Net.Vpc.Upa.VetoableOperation.checkUpdate, updates, condition);
        }


        public virtual void CheckInitialize() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
        }


        public virtual void CheckClear() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (!IsDeleteSupported()) {
                throw new Net.Vpc.Upa.Exceptions.UndeletableRecordException(entity);
            }
        }

        public virtual void CheckPersist(Net.Vpc.Upa.Record record) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (!entity.GetPersistenceUnit().GetSecurityManager().IsAllowedPersist(entity)) {
                throw new Net.Vpc.Upa.Exceptions.InsertRecordNotAllowedException(entity);
            }
            if (!IsPersistSupported()) {
                throw new Net.Vpc.Upa.Exceptions.InsertRecordNotAllowedException(entity);
            }
            if (record != null) {
                // check parent is not read only
                if (entity.GetParentEntity() != null) {
                    Net.Vpc.Upa.Expressions.Expression parentUnupdatable = entity.GetParentEntity().GetShield().GetFullNonUpdatableRecordsExpression();
                    if (parentUnupdatable != null && parentUnupdatable.IsValid()) {
                        Net.Vpc.Upa.Relationship r = entity.GetCompositionRelation();
                        System.Collections.Generic.IList<Net.Vpc.Upa.Field> df = r.GetSourceRole().GetFields();
                        System.Collections.Generic.IList<Net.Vpc.Upa.Field> mf = r.GetTargetRole().GetFields();
                        object[] pko = new object[(mf).Count];
                        for (int i = 0; i < pko.Length; i++) {
                            pko[i] = record.GetObject<object>(df[i].GetName());
                        }
                        object pk = entity.CreateId(pko);
                        long c = entity.GetParentEntity().GetEntityCount(new Net.Vpc.Upa.Expressions.And(parentUnupdatable, entity.GetParentEntity().GetBuilder().IdToExpression(pk, null)));
                        if (c > 0) {
                            throw new Net.Vpc.Upa.Exceptions.UnupdatableRecordException(entity.GetParentEntity());
                        }
                    }
                }
                bool keyGenerated = IsGeneratedId();
                Net.Vpc.Upa.Expressions.Expression keyExpresson = null;
                if (!keyGenerated) {
                    object key = entity.GetBuilder().RecordToId(record);
                    keyExpresson = entity.GetBuilder().IdToExpression(key, null);
                }
                Net.Vpc.Upa.Entity p = entity.GetParentEntity();
                if (p != null) {
                    //Expression ss = childToParentExpression(toExpression(key));
                    Net.Vpc.Upa.Expressions.Expression ss = entity.ChildToParentExpression(record);
                    p.GetShield().CheckUpdate(null, ss);
                }
                System.Collections.Generic.IList<Net.Vpc.Upa.Index> uniqueIndexes = entity.GetIndexes(true);
                if ((uniqueIndexes.Count==0)) {
                    if (!keyGenerated) {
                        if (entity.GetEntityCount(keyExpresson) > 0) {
                            throw new Net.Vpc.Upa.Exceptions.InsertRecordDuplicateKeyException(entity);
                        }
                    }
                } else {
                    Net.Vpc.Upa.Expressions.Expression or = null;
                    if (!keyGenerated) {
                        or = keyExpresson;
                    }
                    foreach (Net.Vpc.Upa.Index index in uniqueIndexes) {
                        Net.Vpc.Upa.Field[] f = index.GetFields();
                        Net.Vpc.Upa.Expressions.Expression e1 = null;
                        if (f.Length == 1) {
                            e1 = new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var(f[0].GetName()), Net.Vpc.Upa.Expressions.ExpressionFactory.ToLiteral(record.GetObject<object>(f[0].GetName())));
                        } else {
                            Net.Vpc.Upa.Expressions.Expression a = null;
                            foreach (Net.Vpc.Upa.Field aF in f) {
                                Net.Vpc.Upa.Expressions.Expression b = (new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var(aF.GetName()), Net.Vpc.Upa.Expressions.ExpressionFactory.ToLiteral(record.GetObject<object>(aF.GetName()))));
                                a = a == null ? ((Net.Vpc.Upa.Expressions.Expression)(b)) : new Net.Vpc.Upa.Expressions.And(a, b);
                            }
                            e1 = a;
                        }
                        or = or == null ? ((Net.Vpc.Upa.Expressions.Expression)(e1)) : new Net.Vpc.Upa.Expressions.Or(or, e1);
                    }
                    if (entity.GetEntityCount(or) > 0) {
                        // finer lookup of problem
                        if (!keyGenerated) {
                            if (entity.GetEntityCount(keyExpresson) > 0) {
                                throw new Net.Vpc.Upa.Exceptions.InsertRecordDuplicateKeyException(entity);
                            }
                        }
                        foreach (Net.Vpc.Upa.Index index in uniqueIndexes) {
                            Net.Vpc.Upa.Field[] f = index.GetFields();
                            Net.Vpc.Upa.Expressions.Expression e1 = null;
                            if (f.Length == 1) {
                                e1 = new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var(f[0].GetName()), Net.Vpc.Upa.Expressions.ExpressionFactory.ToLiteral(record.GetObject<object>(f[0].GetName())));
                            } else {
                                Net.Vpc.Upa.Expressions.Expression a = null;
                                foreach (Net.Vpc.Upa.Field aF in f) {
                                    Net.Vpc.Upa.Expressions.Expression b = (new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var(aF.GetName()), Net.Vpc.Upa.Expressions.ExpressionFactory.ToLiteral(record.GetObject<object>(aF.GetName()))));
                                    a = a == null ? ((Net.Vpc.Upa.Expressions.Expression)(b)) : new Net.Vpc.Upa.Expressions.And(a, b);
                                }
                                e1 = a;
                            }
                            if (entity.GetEntityCount(e1) > 0) {
                                throw new Net.Vpc.Upa.Exceptions.InsertRecordDuplicateUniqueFieldsException(entity, index, record.GetObject<object>(f[0].GetName()));
                            }
                        }
                        throw new System.Exception("WouldNeverBeThrownException");
                    }
                }
            }
            CheckVeto(Net.Vpc.Upa.VetoableOperation.checkPersist, record);
        }

        public virtual bool IsSystem() {
            return GetEffectiveModifiers().Contains(Net.Vpc.Upa.EntityModifier.SYSTEM);
        }

        public virtual bool IsPrivate() {
            return GetEffectiveModifiers().Contains(Net.Vpc.Upa.EntityModifier.PRIVATE);
        }

        public virtual bool IsTransient() {
            return GetEffectiveModifiers().Contains(Net.Vpc.Upa.EntityModifier.TRANSIENT);
        }

        public virtual bool IsDeletableRecord(object k, bool recurse) {
            try {
                if (!entity.GetPersistenceUnit().GetSecurityManager().IsAllowedRemove(entity)) {
                    return false;
                }
                Net.Vpc.Upa.Expressions.Expression e = GetFullNonDeletableRecordsExpression();
                if (e != null && e.IsValid()) {
                    Net.Vpc.Upa.Expressions.Expression a = new Net.Vpc.Upa.Expressions.And(entity.GetBuilder().IdToExpression(k, null), e);
                    if (entity.GetEntityCount(a) > 0) {
                        return false;
                    }
                }
                CheckVeto(Net.Vpc.Upa.VetoableOperation.deletableRecord, k, recurse);
                return true;
            } catch (Net.Vpc.Upa.Exceptions.UPAException e) {
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
                Net.Vpc.Upa.Expressions.Expression e = GetFullNonUpdatableRecordsExpression();
                if (e != null && e.IsValid()) {
                    Net.Vpc.Upa.Expressions.Expression a = new Net.Vpc.Upa.Expressions.And(entity.GetBuilder().IdToExpression(id, null), e);
                    if (entity.GetEntityCount(a) > 0) {
                        return false;
                    }
                }
                CheckVeto(Net.Vpc.Upa.VetoableOperation.updatableRecord, id);
                return true;
            } catch (Net.Vpc.Upa.Exceptions.UPAException e) {
            }
            // e.printStackTrace(); //To change body of catch statement use
            // Options | File Templates.
            return false;
        }


        public virtual void AddVeto(Net.Vpc.Upa.VetoableOperation operation, Net.Vpc.Upa.EntityShieldVeto veto) {
            GetVetoList(operation, true).Add(veto);
        }


        public virtual void RemoveVeto(Net.Vpc.Upa.VetoableOperation operation, Net.Vpc.Upa.EntityShieldVeto veto) {
            System.Collections.Generic.IList<Net.Vpc.Upa.EntityShieldVeto> vetoList = GetVetoList(operation, false);
            if (vetoList != null) {
                vetoList.Remove(veto);
            }
        }


        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.EntityShieldVeto> GetVetoList(Net.Vpc.Upa.VetoableOperation operation) {
            System.Collections.Generic.IList<Net.Vpc.Upa.EntityShieldVeto> vetoList = GetVetoList(operation, false);
            if (vetoList == null) {
                return Net.Vpc.Upa.Impl.Util.PlatformUtils.EmptyList<Net.Vpc.Upa.EntityShieldVeto>();
            }
            return new System.Collections.Generic.List<Net.Vpc.Upa.EntityShieldVeto>(vetoList);
        }

        protected internal virtual System.Collections.Generic.IList<Net.Vpc.Upa.EntityShieldVeto> GetVetoList(Net.Vpc.Upa.VetoableOperation operation, bool create) {
            System.Collections.Generic.IList<Net.Vpc.Upa.EntityShieldVeto> entityShieldVetos = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<Net.Vpc.Upa.VetoableOperation,System.Collections.Generic.IList<Net.Vpc.Upa.EntityShieldVeto>>(vetoMap,operation);
            if (entityShieldVetos == null && create) {
                entityShieldVetos = new System.Collections.Generic.List<Net.Vpc.Upa.EntityShieldVeto>();
                vetoMap[operation]=entityShieldVetos;
            }
            return entityShieldVetos;
        }

        protected internal virtual bool IsNoVeto(Net.Vpc.Upa.VetoableOperation operation, params object [] @params) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            foreach (Net.Vpc.Upa.EntityShieldVeto v in GetVetoList(operation)) {
                try {
                    v.CheckVeto(operation, entity, @params);
                } catch (Net.Vpc.Upa.Exceptions.VetoException e) {
                    return false;
                }
            }
            return true;
        }

        protected internal virtual void CheckVeto(Net.Vpc.Upa.VetoableOperation operation, params object [] @params) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            foreach (Net.Vpc.Upa.EntityShieldVeto v in GetVetoList(operation)) {
                v.CheckVeto(operation, entity, @params);
            }
        }
    }
}
