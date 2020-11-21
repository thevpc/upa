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
     * @creationdate 8/27/12 11:59 PM
     */
    public class EntitySequenceManager : Net.TheVpc.Upa.Impl.SequenceManager {

        private Net.TheVpc.Upa.Entity entity;

        public EntitySequenceManager(Net.TheVpc.Upa.Entity entity) {
            this.entity = entity;
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        public virtual Net.TheVpc.Upa.Impl.PrivateSequence GetOrCreateSequence(string name, string pattern, int initialValue, int increment) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            //        System.out.println(">>>>>>>>>>>>>>>>>>> getOrCreateSequence("+name+","+pattern+")");
            Net.TheVpc.Upa.Impl.PrivateSequence r = entity.CreateQueryBuilder().ById(entity.CreateId(name, pattern)).GetEntity<R>();
            if (r == null) {
                CreateSequence(name, pattern, initialValue, increment);
                r = entity.CreateQueryBuilder().ById(entity.CreateId(name, pattern)).GetEntity<R>();
            }
            return r;
        }


        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        public virtual void CreateSequence(string name, string pattern, int initialValue, int increment) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (increment == 0) {
                throw new System.ArgumentException ("increment zero");
            }
            Net.TheVpc.Upa.Impl.PrivateSequence r = (Net.TheVpc.Upa.Impl.PrivateSequence) entity.GetBuilder().CreateObject<R>();
            r.SetName(name);
            r.SetGroup(pattern);
            r.SetLocked(false);
            r.SetValue(initialValue);
            r.SetIncrement(increment);
            entity.Persist(r);
        }


        public virtual Net.TheVpc.Upa.Impl.PrivateSequence GetSequence(string name, string pattern) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Impl.PrivateSequence r = entity.CreateQueryBuilder().ById(entity.CreateId(name, pattern)).GetEntity<R>();
            if (r == null) {
                throw new Net.TheVpc.Upa.Exceptions.UPAException("Sequence " + pattern + " not found");
            }
            return r;
        }


        public virtual bool IsLocked(string name, string pattern) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Impl.PrivateSequence r = GetSequence(name, pattern);
            return (r.IsLocked());
        }


        public virtual bool IsLockedBySelf(string name, string pattern) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return IsLockedBy(name, pattern, entity.GetPersistenceUnit().GetUserPrincipal().GetName());
        }


        public virtual bool IsLockedBy(string name, string pattern, string user) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Impl.PrivateSequence r = GetSequence(name, pattern);
            return (r.IsLocked() && r.GetLockUserId().Equals(user));
        }


        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        public virtual int LockValue(string name, string pattern) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Impl.PrivateSequence r = GetSequence(name, pattern);
            if (r.IsLocked()) {
                throw new Net.TheVpc.Upa.Exceptions.UPAException("Already locked");
            }
            r.SetLocked(true);
            r.SetLockUserId(entity.GetPersistenceUnit().GetUserPrincipal().GetName());
            r.SetLockDate(new Net.TheVpc.Upa.Types.DateTime());
            entity.CreateUpdateQuery().SetValues(r).ById(entity.CreateId(name, pattern));
            return r.GetValue();
        }


        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        public virtual int GetCurrentValue(string name, string pattern) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Impl.PrivateSequence r = entity.CreateQueryBuilder().ById(entity.CreateId(name, pattern)).GetEntity<R>();
            if (r == null) {
                return -1;
            }
            return r.GetValue();
        }


        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        public virtual int NextValue(string name, string pattern, int initialValue, int increment) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return NextValue0(name, pattern, initialValue, increment, true);
        }

        public int NextValue0(string name, string pattern, int initialValue, int increment, bool autoCreate) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Impl.PrivateSequence r = autoCreate ? GetOrCreateSequence(name, pattern, initialValue, increment) : GetSequence(name, pattern);
            if (r.IsLocked() && !r.GetLockUserId().Equals(entity.GetPersistenceUnit().GetUserPrincipal().GetName())) {
                throw new Net.TheVpc.Upa.Exceptions.UPAException("Already locked");
            }
            int v = r.GetValue();
            r.SetValue(v + r.GetIncrement());
            r.SetLocked(false);
            r.SetLockUserId(null);
            r.SetLockDate(null);
            Net.TheVpc.Upa.Expressions.Expression idToExpression = entity.GetBuilder().IdToExpression(entity.CreateId(name, pattern), entity.GetName());
            Net.TheVpc.Upa.Expressions.And condition = new Net.TheVpc.Upa.Expressions.And(idToExpression, new Net.TheVpc.Upa.Expressions.Or(new Net.TheVpc.Upa.Expressions.Different(new Net.TheVpc.Upa.Expressions.Var(new Net.TheVpc.Upa.Expressions.Var(entity.GetName()), "locked"), Net.TheVpc.Upa.Expressions.Literal.TRUE), new Net.TheVpc.Upa.Expressions.Equals(new Net.TheVpc.Upa.Expressions.Var(new Net.TheVpc.Upa.Expressions.Var(entity.GetName()), "lockUserId"), new Net.TheVpc.Upa.Expressions.Param("lockUserId", entity.GetPersistenceUnit().GetUserPrincipal().GetName()))));
            Net.TheVpc.Upa.QueryBuilder q = null;
            try {
                q = entity.CreateQueryBuilder().ByExpression(condition);
                q.SetUpdatable(true);
                int oldValue;
                foreach (Net.TheVpc.Upa.Impl.PrivateSequence s in q.GetEntityList<Net.TheVpc.Upa.Impl.PrivateSequence>()) {
                    oldValue = s.GetValue();
                    s.SetValue(oldValue + s.GetIncrement());
                    q.UpdateCurrent();
                    //                System.out.println(">>>>>>>>>>>>>>>>>>> nextValue(" + name + "," + pattern + ") =>> "+oldValue);
                    return oldValue;
                }
            } finally {
                if (q != null) {
                    q.Close();
                }
            }
            //not found !
            //check if problem of locking
            if (entity.GetEntityCount(new Net.TheVpc.Upa.Expressions.And(idToExpression, new Net.TheVpc.Upa.Expressions.Equals(new Net.TheVpc.Upa.Expressions.Var("locked"), Net.TheVpc.Upa.Expressions.Literal.TRUE))) > 0) {
                throw new Net.TheVpc.Upa.Exceptions.UPAException("Already locked");
            }
            throw new Net.TheVpc.Upa.Exceptions.UPAException("Unexpected error");
        }


        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        public virtual int Unlock(string name, string pattern) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Impl.PrivateSequence r = GetSequence(name, pattern);
            if (!r.IsLocked()) {
                throw new Net.TheVpc.Upa.Exceptions.UPAException("not locked");
            }
            if (!r.GetLockUserId().Equals(entity.GetPersistenceUnit().GetUserPrincipal().GetName())) {
                throw new Net.TheVpc.Upa.Exceptions.UPAException("locked by others");
            }
            int v = r.GetValue();
            r.SetLocked(false);
            r.SetLockUserId(null);
            r.SetLockDate(null);
            entity.CreateUpdateQuery().SetValues(r).ById(entity.CreateId(pattern));
            return v;
        }
    }
}
