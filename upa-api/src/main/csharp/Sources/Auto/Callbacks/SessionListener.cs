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



namespace Net.Vpc.Upa.Callbacks
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/16/12 3:33 PM
     */
    public interface SessionListener {

         void CloseSession(Net.Vpc.Upa.Session session);

         void PushContext(Net.Vpc.Upa.Session session);

         void PopContext(Net.Vpc.Upa.Session session);
    }
}
