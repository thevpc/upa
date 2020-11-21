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



namespace Net.TheVpc.Upa.Impl.Security
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/26/12 11:42 PM
     */
    public class DefaultSecurityManager : Net.TheVpc.Upa.UPASecurityManager {


        public virtual bool IsAllowedPersist(Net.TheVpc.Upa.Entity entity) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.EntitySecurityManager s = entity.GetEntitySecurityManager();
            if (s != null) {
                return s.IsAllowedPersist(entity);
            }
            return IsAllowedKey(entity, "Persist");
        }


        public virtual bool IsAllowedPersist(Net.TheVpc.Upa.Entity entity, object @object) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.EntitySecurityManager s = entity.GetEntitySecurityManager();
            if (s != null) {
                return s.IsAllowedPersist(entity, @object);
            }
            return IsAllowedKey(entity, "Persist");
        }


        public virtual bool IsAllowedUpdate(Net.TheVpc.Upa.Entity entity) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.EntitySecurityManager s = entity.GetEntitySecurityManager();
            if (s != null) {
                return s.IsAllowedUpdate(entity);
            }
            return IsAllowedKey(entity, "Update");
        }


        public virtual bool IsAllowedUpdate(Net.TheVpc.Upa.Entity entity, object id, object @value) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.EntitySecurityManager s = entity.GetEntitySecurityManager();
            if (s != null) {
                return s.IsAllowedUpdate(entity, id, @value);
            }
            return IsAllowedKey(entity, "Update");
        }


        public virtual bool IsAllowedRemove(Net.TheVpc.Upa.Entity entity) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.EntitySecurityManager s = entity.GetEntitySecurityManager();
            if (s != null) {
                return s.IsAllowedRemove(entity);
            }
            return IsAllowedKey(entity, "Remove");
        }


        public virtual bool IsAllowedRemove(Net.TheVpc.Upa.Entity entity, object id) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.EntitySecurityManager s = entity.GetEntitySecurityManager();
            if (s != null) {
                return s.IsAllowedRemove(entity, id, null);
            }
            return IsAllowedKey(entity, "Delete");
        }


        public virtual bool IsAllowedClone(Net.TheVpc.Upa.Entity entity) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.EntitySecurityManager s = entity.GetEntitySecurityManager();
            if (s != null) {
                return s.IsAllowedClone(entity);
            }
            return IsAllowedKey(entity, "Clone");
        }

        public virtual bool IsAllowedClone(Net.TheVpc.Upa.Entity entity, object instance, object newId) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.EntitySecurityManager s = entity.GetEntitySecurityManager();
            if (s != null) {
                return s.IsAllowedClone(entity, instance, newId);
            }
            return IsAllowedKey(entity, "Clone");
        }


        public virtual bool IsAllowedRename(Net.TheVpc.Upa.Entity entity) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.EntitySecurityManager s = entity.GetEntitySecurityManager();
            if (s != null) {
                return s.IsAllowedRename(entity);
            }
            return IsAllowedKey(entity, "Rename");
        }


        public virtual bool IsAllowedRename(Net.TheVpc.Upa.Entity entity, object instance, object newId) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.EntitySecurityManager s = entity.GetEntitySecurityManager();
            if (s != null) {
                return s.IsAllowedRename(entity, instance, newId);
            }
            return IsAllowedKey(entity, "Rename");
        }


        public virtual bool IsAllowedLoad(Net.TheVpc.Upa.Entity entity) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.EntitySecurityManager s = entity.GetEntitySecurityManager();
            if (s != null) {
                return s.IsAllowedLoad(entity);
            }
            return IsAllowedKey(entity, "Load");
        }


        public virtual bool IsAllowedLoad(Net.TheVpc.Upa.Entity entity, object id, object @object) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.EntitySecurityManager s = entity.GetEntitySecurityManager();
            if (s != null) {
                return s.IsAllowedLoad(entity, id, @object);
            }
            return IsAllowedKey(entity, "Load");
        }


        public virtual bool IsAllowedNavigate(Net.TheVpc.Upa.Entity entity) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.EntitySecurityManager s = entity.GetEntitySecurityManager();
            if (s != null) {
                return s.IsAllowedNavigate(entity);
            }
            return IsAllowedKey(entity, "Navigate");
        }


        public virtual bool IsAllowedNavigate(Net.TheVpc.Upa.Entity entity, string navigationMode) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.EntitySecurityManager s = entity.GetEntitySecurityManager();
            if (s != null) {
                return s.IsAllowedNavigate(entity, navigationMode);
            }
            return IsAllowedKey(entity, "Navigate");
        }


        public virtual bool IsAllowedNavigate(Net.TheVpc.Upa.Entity entity, object id, object @object) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.EntitySecurityManager s = entity.GetEntitySecurityManager();
            if (s != null) {
                return s.IsAllowedNavigate(entity, id, @object);
            }
            return IsAllowedKey(entity, "Navigate");
        }


        public virtual bool IsAllowedRead(Net.TheVpc.Upa.Field field) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.EntitySecurityManager s = field.GetEntity().GetEntitySecurityManager();
            if (s != null) {
                return s.IsAllowedRead(field);
            }
            return IsAllowedKey(field.GetEntity(), "Load");
        }


        public virtual bool IsAllowedRead(Net.TheVpc.Upa.Field field, object id, object @object) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.EntitySecurityManager s = field.GetEntity().GetEntitySecurityManager();
            if (s != null) {
                return s.IsAllowedRead(field, id, @object);
            }
            return IsAllowedKey(field.GetEntity(), "Load");
        }


        public virtual bool IsAllowedWrite(Net.TheVpc.Upa.Field field) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.EntitySecurityManager s = field.GetEntity().GetEntitySecurityManager();
            if (s != null) {
                return s.IsAllowedWrite(field);
            }
            return IsAllowedKey(field.GetEntity(), "Update");
        }

        /**
             *
             * @param field
             * @param id
             * @param object
             * @return
             * @throws UPAException
             */

        public virtual bool IsAllowedWrite(Net.TheVpc.Upa.Field field, object id, object @object) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.EntitySecurityManager s = field.GetEntity().GetEntitySecurityManager();
            if (s != null) {
                return s.IsAllowedWrite(field, id, @object);
            }
            return IsAllowedKey(field.GetEntity(), "Update");
        }

        /**
             *
             * @param entity
             * @return
             * @throws UPAException
             */

        public virtual Net.TheVpc.Upa.Expressions.Expression GetEntityFilter(Net.TheVpc.Upa.Entity entity) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.EntitySecurityManager s = entity.GetEntitySecurityManager();
            if (s != null) {
                return s.GetEntityFilter(entity);
            }
            return null;
        }

        /**
             *
             * @param e
             * @param key
             * @return
             * @throws UPAException
             */

        public virtual bool IsAllowedKey(Net.TheVpc.Upa.Entity e, string key) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (key == null) {
                return true;
            }
            return IsAllowedKey(e.GetAbsoluteName() + "." + key);
        }

        /**
             *
             * @param key
             * @return
             * @throws UPAException
             */

        public virtual bool IsAllowedKey(string key) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.PersistenceGroupSecurityManager s = Net.TheVpc.Upa.UPA.GetPersistenceGroup().GetPersistenceGroupSecurityManager();
            return s == null ? true : s.IsAllowedKey(key);
        }


        public virtual Net.TheVpc.Upa.UserPrincipal GetUserPrincipal() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.PersistenceGroupSecurityManager s = Net.TheVpc.Upa.UPA.GetPersistenceGroup().GetPersistenceGroupSecurityManager();
            return s == null ? ((Net.TheVpc.Upa.UserPrincipal)(new Net.TheVpc.Upa.DefaultUserPrincipal("anonymous", null))) : s.GetUserPrincipal();
        }

        /**
             *
             * @param login
             * @param credentials
             * @return
             * @throws UPAException
             */

        public virtual Net.TheVpc.Upa.UserPrincipal Login(string login, string credentials) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.PersistenceGroupSecurityManager s = Net.TheVpc.Upa.UPA.GetPersistenceGroup().GetPersistenceGroupSecurityManager();
            if (s == null) {
                throw new Net.TheVpc.Upa.Exceptions.UPAException("MissingPersistenceGroupSecurityManager");
            }
            return s.Login(login, credentials);
        }


        public virtual Net.TheVpc.Upa.UserPrincipal LoginPrivileged(string login) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.PersistenceGroupSecurityManager s = Net.TheVpc.Upa.UPA.GetPersistenceGroup().GetPersistenceGroupSecurityManager();
            if (s == null) {
                throw new Net.TheVpc.Upa.Exceptions.UPAException("MissingPersistenceGroupSecurityManager");
            }
            return s.LoginPrivileged(login);
        }
    }
}
