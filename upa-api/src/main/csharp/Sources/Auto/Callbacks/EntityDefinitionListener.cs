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
     * @creationdate 11/27/12 8:40 PM
     */
    public interface EntityDefinitionListener : Net.Vpc.Upa.Callbacks.DefinitionListener {

         void OnPreCreateEntity(Net.Vpc.Upa.Callbacks.EntityEvent @event);

         void OnCreateEntity(Net.Vpc.Upa.Callbacks.EntityEvent @event);

         void OnPreInitEntity(Net.Vpc.Upa.Callbacks.EntityEvent @event);

         void OnInitEntity(Net.Vpc.Upa.Callbacks.EntityEvent @event);

         void OnPreDropEntity(Net.Vpc.Upa.Callbacks.EntityEvent @event);

         void OnDropEntity(Net.Vpc.Upa.Callbacks.EntityEvent @event);

         void OnPreMoveEntity(Net.Vpc.Upa.Callbacks.EntityEvent @event);

         void OnMoveEntity(Net.Vpc.Upa.Callbacks.EntityEvent @event);
    }
}
