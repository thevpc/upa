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
     * @creationdate 11/27/12 8:40 PM
     */
    public interface PersistenceUnitDefinitionListener : Net.TheVpc.Upa.Callbacks.DefinitionListener {

         void OnPreCreatePersistenceUnit(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event);

         void OnCreatePersistenceUnit(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event);

         void OnPreDropPersistenceUnit(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event);

         void OnDropPersistenceUnit(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event);
    }
}
