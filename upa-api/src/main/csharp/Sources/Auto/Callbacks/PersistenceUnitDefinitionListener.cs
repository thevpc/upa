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
    public interface PersistenceUnitDefinitionListener : Net.Vpc.Upa.Callbacks.DefinitionListener {

         void OnPreCreatePersistenceUnit(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event);

         void OnCreatePersistenceUnit(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event);

         void OnPreDropPersistenceUnit(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event);

         void OnDropPersistenceUnit(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event);
    }
}
