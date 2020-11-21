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
     * @creationdate 11/27/12 9:17 PM
     */
    public interface TriggerDefinitionListener : Net.TheVpc.Upa.Callbacks.DefinitionListener {

         void OnPreCreateTrigger(Net.TheVpc.Upa.Callbacks.TriggerEvent @event);

         void OnCreateTrigger(Net.TheVpc.Upa.Callbacks.TriggerEvent @event);

         void OnPreDropTrigger(Net.TheVpc.Upa.Callbacks.TriggerEvent @event);

         void OnDropTrigger(Net.TheVpc.Upa.Callbacks.TriggerEvent @event);
    }
}
