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
    public interface SequenceManager {

         Net.TheVpc.Upa.Impl.PrivateSequence GetOrCreateSequence(string name, string pattern, int initialValue, int increment) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Impl.PrivateSequence GetSequence(string name, string pattern) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void CreateSequence(string name, string pattern, int initialValue, int increment) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsLocked(string name, string pattern) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsLockedBySelf(string name, string pattern) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsLockedBy(string name, string pattern, string user) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         int LockValue(string name, string pattern) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         int GetCurrentValue(string name, string pattern) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         int NextValue(string name, string pattern, int initialValue, int increment) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         int Unlock(string name, string pattern) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;
    }
}
