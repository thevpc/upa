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



namespace Net.Vpc.Upa.Impl.Security
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/26/12 11:42 PM
     */
    public class DefaultSecurityManager : Net.Vpc.Upa.UPASecurityManager {


        public virtual bool IsAllowedPersist(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.EntitySecurityManager s = entity.GetEntitySecurityManager();
            if (s != null) {
                return s.IsAllowedPersist(entity);
            }
            return IsAllowedKey(entity, "Persist");
        }


        public virtual bool IsAllowedPersist(Net.Vpc.Upa.Entity entity, object @object) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.EntitySecurityManager s = entity.GetEntitySecurityManager();
            if (s != null) {
                return s.IsAllowedPersist(entity, @object);
            }
            return IsAllowedKey(entity, "Persist");
        }


        public virtual bool IsAllowedUpdate(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.EntitySecurityManager s = entity.GetEntitySecurityManager();
            if (s != null) {
                return s.IsAllowedUpdate(entity);
            }
            return IsAllowedKey(entity, "Update");
        }


        public virtual bool IsAllowedUpdate(Net.Vpc.Upa.Entity entity, object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.EntitySecurityManager s = entity.GetEntitySecurityManager();
            if (s != null) {
                return s.IsAllowedUpdate(entity, id);
            }
            return IsAllowedKey(entity, "Update");
        }


        public virtual bool IsAllowedRemove(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.EntitySecurityManager s = entity.GetEntitySecurityManager();
            if (s != null) {
                return s.IsAllowedRemove(entity);
            }
            return IsAllowedKey(entity, "Remove");
        }


        public virtual bool IsAllowedRemove(Net.Vpc.Upa.Entity entity, object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.EntitySecurityManager s = entity.GetEntitySecurityManager();
            if (s != null) {
                return s.IsAllowedRemove(entity, id);
            }
            return IsAllowedKey(entity, "Delete");
        }


        public virtual bool IsAllowedClone(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.EntitySecurityManager s = entity.GetEntitySecurityManager();
            if (s != null) {
                return s.IsAllowedClone(entity);
            }
            return IsAllowedKey(entity, "Clone");
        }

        public virtual bool IsAllowedClone(Net.Vpc.Upa.Entity entity, object instance, object newId) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.EntitySecurityManager s = entity.GetEntitySecurityManager();
            if (s != null) {
                return s.IsAllowedClone(entity, instance, newId);
            }
            return IsAllowedKey(entity, "Clone");
        }


        public virtual bool IsAllowedRename(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.EntitySecurityManager s = entity.GetEntitySecurityManager();
            if (s != null) {
                return s.IsAllowedRename(entity);
            }
            return IsAllowedKey(entity, "Rename");
        }


        public virtual bool IsAllowedRename(Net.Vpc.Upa.Entity entity, object instance, object newId) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.EntitySecurityManager s = entity.GetEntitySecurityManager();
            if (s != null) {
                return s.IsAllowedRename(entity, instance, newId);
            }
            return IsAllowedKey(entity, "Rename");
        }


        public virtual bool IsAllowedLoad(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.EntitySecurityManager s = entity.GetEntitySecurityManager();
            if (s != null) {
                return s.IsAllowedLoad(entity);
            }
            return IsAllowedKey(entity, "Load");
        }


        public virtual bool IsAllowedLoad(Net.Vpc.Upa.Entity entity, object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.EntitySecurityManager s = entity.GetEntitySecurityManager();
            if (s != null) {
                return s.IsAllowedLoad(entity, id);
            }
            return IsAllowedKey(entity, "Load");
        }


        public virtual bool IsAllowedNavigate(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.EntitySecurityManager s = entity.GetEntitySecurityManager();
            if (s != null) {
                return s.IsAllowedNavigate(entity);
            }
            return IsAllowedKey(entity, "Navigate");
        }


        public virtual bool IsAllowedNavigate(Net.Vpc.Upa.Entity entity, string navigationMode) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.EntitySecurityManager s = entity.GetEntitySecurityManager();
            if (s != null) {
                return s.IsAllowedNavigate(entity, navigationMode);
            }
            return IsAllowedKey(entity, "Navigate");
        }


        public virtual bool IsAllowedRead(Net.Vpc.Upa.Field field) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.EntitySecurityManager s = field.GetEntity().GetEntitySecurityManager();
            if (s != null) {
                return s.IsAllowedRead(field);
            }
            return IsAllowedKey(null);
        }


        public virtual bool IsAllowedRead(Net.Vpc.Upa.Entity entity, object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.EntitySecurityManager s = entity.GetEntitySecurityManager();
            if (s != null) {
                return s.IsAllowedRead(entity, id);
            }
            return IsAllowedKey(entity, "Navigate");
        }


        public virtual bool IsAllowedWrite(Net.Vpc.Upa.Field field) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.EntitySecurityManager s = field.GetEntity().GetEntitySecurityManager();
            if (s != null) {
                return s.IsAllowedWrite(field);
            }
            return IsAllowedKey(null);
        }


        public virtual bool IsAllowedWrite(Net.Vpc.Upa.Field field, object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.EntitySecurityManager s = field.GetEntity().GetEntitySecurityManager();
            if (s != null) {
                return s.IsAllowedWrite(field, id);
            }
            return IsAllowedKey(field.GetEntity(), null);
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetEntityFilter(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.EntitySecurityManager s = entity.GetEntitySecurityManager();
            if (s != null) {
                return s.GetEntityFilter(entity);
            }
            return null;
        }

        public virtual bool IsAllowedKey(Net.Vpc.Upa.Entity e, string key) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (key == null) {
                return true;
            }
            return IsAllowedKey(e.GetAbsoluteName() + "." + key);
        }

        public virtual bool IsAllowedKey(string key) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.PersistenceGroupSecurityManager s = Net.Vpc.Upa.UPA.GetPersistenceGroup().GetPersistenceGroupSecurityManager();
            return s == null ? true : s.IsAllowedKey(key);
        }

        public virtual Net.Vpc.Upa.UserPrincipal GetUserPrincipal() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.PersistenceGroupSecurityManager s = Net.Vpc.Upa.UPA.GetPersistenceGroup().GetPersistenceGroupSecurityManager();
            return s == null ? ((Net.Vpc.Upa.UserPrincipal)(new Net.Vpc.Upa.DefaultUserPrincipal("anonymous", null))) : s.GetUserPrincipal();
        }

        public virtual Net.Vpc.Upa.UserPrincipal Login(string login, string credentials) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.PersistenceGroupSecurityManager s = Net.Vpc.Upa.UPA.GetPersistenceGroup().GetPersistenceGroupSecurityManager();
            if (s == null) {
                throw new System.ArgumentException ("Unsupported");
            }
            return s.Login(login, credentials);
        }

        public virtual Net.Vpc.Upa.UserPrincipal LoginPrivileged(string login) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.PersistenceGroupSecurityManager s = Net.Vpc.Upa.UPA.GetPersistenceGroup().GetPersistenceGroupSecurityManager();
            if (s == null) {
                throw new System.ArgumentException ("Unsupported");
            }
            return s.LoginPrivileged(login);
        }
    }
}
