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
    public interface EntityDefinitionListener : Net.TheVpc.Upa.Callbacks.DefinitionListener {

         void OnPreCreateEntity(Net.TheVpc.Upa.Callbacks.EntityEvent @event);

         void OnCreateEntity(Net.TheVpc.Upa.Callbacks.EntityEvent @event);

         void OnPrePrepareEntity(Net.TheVpc.Upa.Callbacks.EntityEvent @event);

         void OnPrepareEntity(Net.TheVpc.Upa.Callbacks.EntityEvent @event);

         void OnPreDropEntity(Net.TheVpc.Upa.Callbacks.EntityEvent @event);

         void OnDropEntity(Net.TheVpc.Upa.Callbacks.EntityEvent @event);

         void OnPreMoveEntity(Net.TheVpc.Upa.Callbacks.EntityEvent @event);

         void OnMoveEntity(Net.TheVpc.Upa.Callbacks.EntityEvent @event);
    }
}
