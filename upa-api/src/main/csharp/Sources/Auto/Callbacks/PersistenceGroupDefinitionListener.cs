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
     * @creationdate 11/27/12 8:40 PM
     */
    public interface PersistenceGroupDefinitionListener : Net.Vpc.Upa.Callbacks.DefinitionListener {

         void OnPreCreatePersistenceGroup(Net.Vpc.Upa.Callbacks.PersistenceGroupEvent @event);

         void OnCreatePersistenceGroup(Net.Vpc.Upa.Callbacks.PersistenceGroupEvent @event);

         void OnPreDropPersistenceGroup(Net.Vpc.Upa.Callbacks.PersistenceGroupEvent @event);

         void OnDropPersistenceGroup(Net.Vpc.Upa.Callbacks.PersistenceGroupEvent @event);
    }
}
