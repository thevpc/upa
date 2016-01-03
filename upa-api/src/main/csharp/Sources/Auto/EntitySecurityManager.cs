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
     * Created with IntelliJ IDEA. User: vpc Date: 8/22/12 Time: 4:13 AM To change
     * this template use File | Settings | File Templates.
     */
    public interface EntitySecurityManager {

         bool IsAllowedPersist(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsAllowedPersist(Net.Vpc.Upa.Entity entity, object instance) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsAllowedUpdate(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsAllowedUpdate(Net.Vpc.Upa.Entity entity, object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsAllowedRemove(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsAllowedRemove(Net.Vpc.Upa.Entity entity, object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsAllowedClone(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsAllowedClone(Net.Vpc.Upa.Entity entity, object instance, object newId) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsAllowedRename(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsAllowedRename(Net.Vpc.Upa.Entity entity, object instance, object newId) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsAllowedLoad(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsAllowedLoad(Net.Vpc.Upa.Entity entity, object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsAllowedNavigate(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsAllowedNavigate(Net.Vpc.Upa.Entity entity, string navigationMode) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsAllowedRead(Net.Vpc.Upa.Field entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsAllowedRead(Net.Vpc.Upa.Entity entity, object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsAllowedWrite(Net.Vpc.Upa.Field field) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsAllowedWrite(Net.Vpc.Upa.Field field, object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Expressions.Expression GetEntityFilter(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;
    }
}
