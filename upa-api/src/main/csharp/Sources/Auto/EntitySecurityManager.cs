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
     * Created with IntelliJ IDEA. User: vpc Date: 8/22/12 Time: 4:13 AM To change
     * this template use File | Settings | File Templates.
     */
    public interface EntitySecurityManager {

         bool IsAllowedPersist(Net.TheVpc.Upa.Entity entity);

         bool IsAllowedPersist(Net.TheVpc.Upa.Entity entity, object instance);

         bool IsAllowedUpdate(Net.TheVpc.Upa.Entity entity);

         bool IsAllowedUpdate(Net.TheVpc.Upa.Entity entity, object id, object @value);

         bool IsAllowedRemove(Net.TheVpc.Upa.Entity entity);

         bool IsAllowedRemove(Net.TheVpc.Upa.Entity entity, object id, object @value);

         bool IsAllowedClone(Net.TheVpc.Upa.Entity entity);

         bool IsAllowedClone(Net.TheVpc.Upa.Entity entity, object instance, object newId);

         bool IsAllowedRename(Net.TheVpc.Upa.Entity entity);

         bool IsAllowedRename(Net.TheVpc.Upa.Entity entity, object instance, object newId);

         bool IsAllowedLoad(Net.TheVpc.Upa.Entity entity);

         bool IsAllowedLoad(Net.TheVpc.Upa.Entity entity, object id, object @value);

         bool IsAllowedNavigate(Net.TheVpc.Upa.Entity entity);

         bool IsAllowedNavigate(Net.TheVpc.Upa.Entity entity, string navigationMode);

         bool IsAllowedNavigate(Net.TheVpc.Upa.Entity entity, object id, object @value);

         bool IsAllowedRead(Net.TheVpc.Upa.Field field);

         bool IsAllowedRead(Net.TheVpc.Upa.Field field, object id, object @object);

         bool IsAllowedWrite(Net.TheVpc.Upa.Field field);

         bool IsAllowedWrite(Net.TheVpc.Upa.Field field, object id, object @value);

         Net.TheVpc.Upa.Expressions.Expression GetEntityFilter(Net.TheVpc.Upa.Entity entity);
    }
}
