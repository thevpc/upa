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
     * Created by vpc on 7/25/15.
     */
    public interface Callback {

         object Invoke(params object [] arguments);

         Net.Vpc.Upa.CallbackType GetCallbackType();

         Net.Vpc.Upa.EventPhase GetPhase();

         Net.Vpc.Upa.ObjectType GetObjectType();
    }
}
