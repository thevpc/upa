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
     * @creationdate 9/9/12 4:09 PM
     */
    public interface Trigger : Net.Vpc.Upa.UPAObject {

         Net.Vpc.Upa.Entity GetEntity();

         Net.Vpc.Upa.Callbacks.EntityInterceptor GetInterceptor();

         Net.Vpc.Upa.Callbacks.EntityListener GetListener();
    }
}
