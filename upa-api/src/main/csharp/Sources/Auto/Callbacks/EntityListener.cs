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

    public interface EntityListener : Net.TheVpc.Upa.Callbacks.EntityInterceptor {

         void OnPrePersist(Net.TheVpc.Upa.Callbacks.PersistEvent @event);

         void OnPersist(Net.TheVpc.Upa.Callbacks.PersistEvent @event);

         void OnPreUpdate(Net.TheVpc.Upa.Callbacks.UpdateEvent @event);

         void OnUpdate(Net.TheVpc.Upa.Callbacks.UpdateEvent @event);

         void OnPreRemove(Net.TheVpc.Upa.Callbacks.RemoveEvent @event);

         void OnRemove(Net.TheVpc.Upa.Callbacks.RemoveEvent @event);

         void OnPreUpdateFormula(Net.TheVpc.Upa.Callbacks.UpdateFormulaEvent @event);

         void OnUpdateFormula(Net.TheVpc.Upa.Callbacks.UpdateFormulaEvent @event);

         void OnPreInitialize(Net.TheVpc.Upa.Callbacks.EntityEvent @event);

        /**
             * called when Entity is initialized aka default entities / Documents where
             * inserted
             *
             * @param event
             */
         void OnInitialize(Net.TheVpc.Upa.Callbacks.EntityEvent @event);

         void OnPreClear(Net.TheVpc.Upa.Callbacks.EntityEvent @event);

         void OnClear(Net.TheVpc.Upa.Callbacks.EntityEvent @event);

         void OnPreReset(Net.TheVpc.Upa.Callbacks.EntityEvent @event);

         void OnReset(Net.TheVpc.Upa.Callbacks.EntityEvent @event);
    }
}
