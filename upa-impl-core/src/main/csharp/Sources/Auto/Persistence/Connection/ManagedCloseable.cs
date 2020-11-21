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



namespace Net.TheVpc.Upa.Impl.Persistence.Connection
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/24/12 8:40 AM
     */
    public interface ManagedCloseable : Net.TheVpc.Upa.Closeable {

         void AddCloseListener(Net.TheVpc.Upa.CloseListener closeListener);

         void RemoveCloseListener(Net.TheVpc.Upa.CloseListener closeListener);
    }
}
