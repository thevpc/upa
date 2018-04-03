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
     * @author taha.bensalah@gmail.com
     */
    public class DefaultEntitySecurityManager : Net.Vpc.Upa.EntitySecurityManager {


        public virtual bool IsAllowedPersist(Net.Vpc.Upa.Entity entity) {
            return IsAllowedKey(entity, "Persist");
        }


        public virtual bool IsAllowedPersist(Net.Vpc.Upa.Entity entity, object @object) {
            return IsAllowedKey(entity, "Persist");
        }


        public virtual bool IsAllowedUpdate(Net.Vpc.Upa.Entity entity) {
            return IsAllowedKey(entity, "Update");
        }


        public virtual bool IsAllowedUpdate(Net.Vpc.Upa.Entity entity, object id, object @value) {
            return IsAllowedKey(entity, "Update");
        }


        public virtual bool IsAllowedRemove(Net.Vpc.Upa.Entity entity) {
            return IsAllowedKey(entity, "Remove");
        }


        public virtual bool IsAllowedRemove(Net.Vpc.Upa.Entity entity, object id, object @object) {
            return IsAllowedKey(entity, "Remove");
        }


        public virtual bool IsAllowedClone(Net.Vpc.Upa.Entity entity) {
            return IsAllowedKey(entity, "Clone");
        }

        public virtual bool IsAllowedClone(Net.Vpc.Upa.Entity entity, object instance, object newId) {
            return IsAllowedKey(entity, "Clone");
        }


        public virtual bool IsAllowedRename(Net.Vpc.Upa.Entity entity) {
            return IsAllowedKey(entity, "Rename");
        }


        public virtual bool IsAllowedRename(Net.Vpc.Upa.Entity entity, object instance, object newId) {
            return IsAllowedKey(entity, "Rename");
        }


        public virtual bool IsAllowedLoad(Net.Vpc.Upa.Entity entity) {
            return IsAllowedKey(entity, "Load");
        }


        public virtual bool IsAllowedLoad(Net.Vpc.Upa.Entity entity, object id, object @object) {
            return IsAllowedKey(entity, "Load");
        }


        public virtual bool IsAllowedNavigate(Net.Vpc.Upa.Entity entity) {
            return IsAllowedKey(entity, "Navigate");
        }


        public virtual bool IsAllowedNavigate(Net.Vpc.Upa.Entity entity, string navigationMode) {
            return IsAllowedKey(entity, ("Navigate") + ((navigationMode == null || (navigationMode.Length==0)) ? "" : ("." + navigationMode)));
        }


        public virtual bool IsAllowedNavigate(Net.Vpc.Upa.Entity entity, object id, object @object) {
            return IsAllowedKey(entity, "Navigate");
        }


        public virtual bool IsAllowedRead(Net.Vpc.Upa.Field field) {
            return IsAllowedLoad(field.GetEntity()) && IsAllowedKey(field, "Read");
        }


        public virtual bool IsAllowedRead(Net.Vpc.Upa.Field field, object id, object @object) {
            return IsAllowedLoad(field.GetEntity(), id, @object) && IsAllowedKey(field, "Read");
        }


        public virtual bool IsAllowedWrite(Net.Vpc.Upa.Field field) {
            return IsAllowedUpdate(field.GetEntity()) && IsAllowedKey(field, "Write");
        }


        public virtual bool IsAllowedWrite(Net.Vpc.Upa.Field field, object id, object @object) {
            return IsAllowedUpdate(field.GetEntity()) && IsAllowedKey(field, "Write");
        }


        public virtual Net.Vpc.Upa.Expressions.Expression GetEntityFilter(Net.Vpc.Upa.Entity entity) {
            return null;
        }

        public virtual bool IsAllowedKey(Net.Vpc.Upa.Entity e, string key) {
            if (key == null) {
                return true;
            }
            return IsAllowedKey(e.GetPersistenceUnit().GetPersistenceGroup(), e.GetAbsoluteName() + "." + key);
        }

        public virtual bool IsAllowedKey(Net.Vpc.Upa.Field e, string key) {
            if (key == null) {
                return true;
            }
            return IsAllowedKey(e.GetPersistenceUnit().GetPersistenceGroup(), e.GetEntity().GetAbsoluteName() + "." + e.GetName() + "." + key);
        }

        public virtual bool IsAllowedKey(Net.Vpc.Upa.PersistenceGroup g, string key) {
            Net.Vpc.Upa.PersistenceGroupSecurityManager s = g.GetPersistenceGroupSecurityManager();
            return s == null ? true : s.IsAllowedKey(key);
        }
    }
}
