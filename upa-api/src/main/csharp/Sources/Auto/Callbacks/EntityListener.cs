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

    public interface EntityListener : Net.Vpc.Upa.Callbacks.EntityInterceptor {

         void OnPrePersist(Net.Vpc.Upa.Callbacks.PersistEvent @event);

         void OnPersist(Net.Vpc.Upa.Callbacks.PersistEvent @event);

         void OnPreUpdate(Net.Vpc.Upa.Callbacks.UpdateEvent @event);

         void OnUpdate(Net.Vpc.Upa.Callbacks.UpdateEvent @event);

         void OnPreRemove(Net.Vpc.Upa.Callbacks.RemoveEvent @event);

         void OnRemove(Net.Vpc.Upa.Callbacks.RemoveEvent @event);

         void OnPreUpdateFormula(Net.Vpc.Upa.Callbacks.UpdateFormulaEvent @event);

         void OnUpdateFormula(Net.Vpc.Upa.Callbacks.UpdateFormulaEvent @event);

         void OnPreInitialize(Net.Vpc.Upa.Callbacks.EntityEvent @event);

        /**
             * called when Entity is initialized aka default entities / records where
             * inserted
             *
             * @param event
             */
         void OnInitialize(Net.Vpc.Upa.Callbacks.EntityEvent @event);

         void OnPreClear(Net.Vpc.Upa.Callbacks.EntityEvent @event);

         void OnClear(Net.Vpc.Upa.Callbacks.EntityEvent @event);

         void OnPreReset(Net.Vpc.Upa.Callbacks.EntityEvent @event);

         void OnReset(Net.Vpc.Upa.Callbacks.EntityEvent @event);
    }
}
