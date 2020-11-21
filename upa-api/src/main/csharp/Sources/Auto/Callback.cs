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
     * Callback ae Framework hooks to object (@see {@link ObjectType}) manipulation phases (@see {@link EventPhase}).
     * They are invoked before or after un object action (@see {@link CallbackType})
     * @author taha.bensalah@gmail.com on 7/25/15.
     * @see UPAContext#addCallback(Callback)
     * @see UPAContext#addCallback(MethodCallback)
     * @see PersistenceGroup#addCallback(Callback)
     * @see PersistenceGroup#addCallback(MethodCallback)
     * @see PersistenceUnit#addCallback(Callback)
     * @see PersistenceUnit#addCallback(MethodCallback)
     */
    public interface Callback {

         object Invoke(params object [] arguments);

         Net.TheVpc.Upa.CallbackType GetCallbackType();

         Net.TheVpc.Upa.EventPhase GetPhase();

         Net.TheVpc.Upa.ObjectType GetObjectType();

         System.Collections.Generic.IDictionary<string , object> GetConfiguration();
    }
}
