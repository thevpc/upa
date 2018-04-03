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
    public interface PersistenceGroupSecurityManager {

         bool IsAllowedKey(string key) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.UserPrincipal GetUserPrincipal() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.UserPrincipal Login(string login, string credentials) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.UserPrincipal LoginPrivileged(string login) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;
    }
}
