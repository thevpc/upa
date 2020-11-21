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
    public interface UPASecurityManager {

         bool IsAllowedPersist(Net.TheVpc.Upa.Entity entity) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsAllowedPersist(Net.TheVpc.Upa.Entity entity, object instance) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsAllowedUpdate(Net.TheVpc.Upa.Entity entity) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsAllowedUpdate(Net.TheVpc.Upa.Entity entity, object id, object @value) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsAllowedRemove(Net.TheVpc.Upa.Entity entity) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsAllowedRemove(Net.TheVpc.Upa.Entity entity, object id) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsAllowedClone(Net.TheVpc.Upa.Entity entity) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsAllowedClone(Net.TheVpc.Upa.Entity entity, object instance, object newId) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsAllowedRename(Net.TheVpc.Upa.Entity entity) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsAllowedRename(Net.TheVpc.Upa.Entity entity, object instance, object newId) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsAllowedLoad(Net.TheVpc.Upa.Entity entity) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsAllowedLoad(Net.TheVpc.Upa.Entity entity, object id, object @object) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsAllowedNavigate(Net.TheVpc.Upa.Entity entity) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsAllowedNavigate(Net.TheVpc.Upa.Entity entity, string navigationMode) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsAllowedNavigate(Net.TheVpc.Upa.Entity entity, object id, object @object) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsAllowedRead(Net.TheVpc.Upa.Field field) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsAllowedRead(Net.TheVpc.Upa.Field field, object id, object @object) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsAllowedWrite(Net.TheVpc.Upa.Field field) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsAllowedWrite(Net.TheVpc.Upa.Field field, object id, object @object) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsAllowedKey(Net.TheVpc.Upa.Entity entity, string key) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsAllowedKey(string key) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Expressions.Expression GetEntityFilter(Net.TheVpc.Upa.Entity entity) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.UserPrincipal GetUserPrincipal() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.UserPrincipal Login(string login, string credentials) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.UserPrincipal LoginPrivileged(string login) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;
    }
}
