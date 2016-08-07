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
     *
     * @author taha.bensalah@gmail.com
     */
    public class DefaultEntitySecurityManager : Net.Vpc.Upa.EntitySecurityManager {


        public virtual bool IsAllowedPersist(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return IsAllowedKey(entity, "Persist");
        }


        public virtual bool IsAllowedPersist(Net.Vpc.Upa.Entity entity, object @object) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return IsAllowedKey(entity, "Persist");
        }


        public virtual bool IsAllowedUpdate(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return IsAllowedKey(entity, "Update");
        }


        public virtual bool IsAllowedUpdate(Net.Vpc.Upa.Entity entity, object id, object @value) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return IsAllowedKey(entity, "Update");
        }


        public virtual bool IsAllowedRemove(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return IsAllowedKey(entity, "Remove");
        }


        public virtual bool IsAllowedRemove(Net.Vpc.Upa.Entity entity, object id, object @object) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return IsAllowedKey(entity, "Remove");
        }


        public virtual bool IsAllowedClone(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return IsAllowedKey(entity, "Clone");
        }

        public virtual bool IsAllowedClone(Net.Vpc.Upa.Entity entity, object instance, object newId) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return IsAllowedKey(entity, "Clone");
        }


        public virtual bool IsAllowedRename(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return IsAllowedKey(entity, "Rename");
        }


        public virtual bool IsAllowedRename(Net.Vpc.Upa.Entity entity, object instance, object newId) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return IsAllowedKey(entity, "Rename");
        }


        public virtual bool IsAllowedLoad(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return IsAllowedKey(entity, "Load");
        }


        public virtual bool IsAllowedLoad(Net.Vpc.Upa.Entity entity, object id, object @object) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return IsAllowedKey(entity, "Load");
        }


        public virtual bool IsAllowedNavigate(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return IsAllowedKey(entity, "Navigate");
        }


        public virtual bool IsAllowedNavigate(Net.Vpc.Upa.Entity entity, string navigationMode) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return IsAllowedKey(entity, ("Navigate") + ((navigationMode == null || navigationMode.Length==0) ? "" : ("." + navigationMode)));
        }


        public virtual bool IsAllowedNavigate(Net.Vpc.Upa.Entity entity, object id, object @object) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return IsAllowedKey(entity, "Navigate");
        }


        public virtual bool IsAllowedRead(Net.Vpc.Upa.Field field) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return IsAllowedKey(field.GetEntity(), "Load");
        }


        public virtual bool IsAllowedRead(Net.Vpc.Upa.Field field, object id, object @object) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return IsAllowedKey(field.GetEntity(), "Load");
        }


        public virtual bool IsAllowedWrite(Net.Vpc.Upa.Field field) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return IsAllowedKey(field.GetEntity(), "Update");
        }


        public virtual bool IsAllowedWrite(Net.Vpc.Upa.Field field, object id, object @object) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return IsAllowedKey(field.GetEntity(), "Update");
        }


        public virtual Net.Vpc.Upa.Expressions.Expression GetEntityFilter(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return null;
        }

        public virtual bool IsAllowedKey(Net.Vpc.Upa.Entity e, string key) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (key == null) {
                return true;
            }
            return IsAllowedKey(e.GetPersistenceUnit().GetPersistenceGroup(), e.GetAbsoluteName() + "." + key);
        }

        public virtual bool IsAllowedKey(Net.Vpc.Upa.PersistenceGroup g, string key) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.PersistenceGroupSecurityManager s = g.GetPersistenceGroupSecurityManager();
            return s == null ? true : s.IsAllowedKey(key);
        }
    }
}
