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

    public interface PersistenceUnitListener {

         void OnPreModelChanged(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event);

         void OnModelChanged(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event);

         void OnPreStorageChanged(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event);

         void OnStorageChanged(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event);

         void OnPreStart(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event);

         void OnStart(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event);

         void OnPreClear(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event);

         void OnClear(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event);

         void OnPreReset(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event);

         void OnReset(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event);

         void OnPreClose(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event);

         void OnClose(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event);

         void OnPreUpdateFormulas(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event);

         void OnUpdateFormulas(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event);
    }
}
