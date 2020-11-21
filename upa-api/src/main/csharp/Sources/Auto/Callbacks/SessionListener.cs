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



namespace Net.TheVpc.Upa.Callbacks
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/16/12 3:33 PM
     */
    public interface SessionListener {

         void CloseSession(Net.TheVpc.Upa.Session session);

         void PushContext(Net.TheVpc.Upa.Session session);

         void PopContext(Net.TheVpc.Upa.Session session);
    }
}
