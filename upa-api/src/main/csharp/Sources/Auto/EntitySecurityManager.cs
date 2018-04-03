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
     * Created with IntelliJ IDEA. User: vpc Date: 8/22/12 Time: 4:13 AM To change
     * this template use File | Settings | File Templates.
     */
    public interface EntitySecurityManager {

         bool IsAllowedPersist(Net.Vpc.Upa.Entity entity);

         bool IsAllowedPersist(Net.Vpc.Upa.Entity entity, object instance);

         bool IsAllowedUpdate(Net.Vpc.Upa.Entity entity);

         bool IsAllowedUpdate(Net.Vpc.Upa.Entity entity, object id, object @value);

         bool IsAllowedRemove(Net.Vpc.Upa.Entity entity);

         bool IsAllowedRemove(Net.Vpc.Upa.Entity entity, object id, object @value);

         bool IsAllowedClone(Net.Vpc.Upa.Entity entity);

         bool IsAllowedClone(Net.Vpc.Upa.Entity entity, object instance, object newId);

         bool IsAllowedRename(Net.Vpc.Upa.Entity entity);

         bool IsAllowedRename(Net.Vpc.Upa.Entity entity, object instance, object newId);

         bool IsAllowedLoad(Net.Vpc.Upa.Entity entity);

         bool IsAllowedLoad(Net.Vpc.Upa.Entity entity, object id, object @value);

         bool IsAllowedNavigate(Net.Vpc.Upa.Entity entity);

         bool IsAllowedNavigate(Net.Vpc.Upa.Entity entity, string navigationMode);

         bool IsAllowedNavigate(Net.Vpc.Upa.Entity entity, object id, object @value);

         bool IsAllowedRead(Net.Vpc.Upa.Field field);

         bool IsAllowedRead(Net.Vpc.Upa.Field field, object id, object @object);

         bool IsAllowedWrite(Net.Vpc.Upa.Field field);

         bool IsAllowedWrite(Net.Vpc.Upa.Field field, object id, object @value);

         Net.Vpc.Upa.Expressions.Expression GetEntityFilter(Net.Vpc.Upa.Entity entity);
    }
}
