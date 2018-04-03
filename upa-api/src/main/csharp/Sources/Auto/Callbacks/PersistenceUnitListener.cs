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

    public interface PersistenceUnitListener {

         void OnPreModelChanged(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event);

         void OnModelChanged(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event);

         void OnPreStorageChanged(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event);

         void OnStorageChanged(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event);

         void OnPreStart(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event);

         void OnStart(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event);

         void OnPreClear(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event);

         void OnClear(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event);

         void OnPreReset(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event);

         void OnReset(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event);

         void OnPreClose(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event);

         void OnClose(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event);

         void OnPreUpdateFormulas(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event);

         void OnUpdateFormulas(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event);
    }
}
