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



namespace Net.Vpc.Upa.Callbacks
{

    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/27/12 9:17 PM
     */
    public interface TriggerDefinitionListener : Net.Vpc.Upa.Callbacks.DefinitionListener {

         void OnPreCreateTrigger(Net.Vpc.Upa.Callbacks.TriggerEvent @event);

         void OnCreateTrigger(Net.Vpc.Upa.Callbacks.TriggerEvent @event);

         void OnPreDropTrigger(Net.Vpc.Upa.Callbacks.TriggerEvent @event);

         void OnDropTrigger(Net.Vpc.Upa.Callbacks.TriggerEvent @event);
    }
}
