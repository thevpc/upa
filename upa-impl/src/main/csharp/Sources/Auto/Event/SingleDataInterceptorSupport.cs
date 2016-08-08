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



namespace Net.Vpc.Upa.Impl.Event
{


    /**
     * Created by IntelliJ IDEA.
     * User: root
     * Date: 29 avr. 2003
     * Time: 12:59:47
     * To change this template use Options | File Templates.
     */
    public class SingleDataInterceptorSupport : Net.Vpc.Upa.Callbacks.EntityListenerAdapter {

        private Net.Vpc.Upa.Callbacks.SingleEntityListener keyInterceptor;

        public SingleDataInterceptorSupport(Net.Vpc.Upa.Callbacks.SingleEntityListener keyInterceptor) {
            this.keyInterceptor = keyInterceptor;
        }


        public override void OnPrePersist(Net.Vpc.Upa.Callbacks.PersistEvent @event) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.Context.DefaultEntityTriggerContext context = new Net.Vpc.Upa.Impl.Context.DefaultEntityTriggerContext(@event.GetEntity(), @event.GetTrigger(), @event.GetContext());
            keyInterceptor.BeforePersist(context, @event.GetPersistedId(), @event.GetPersistedRecord());
        }


        public override void OnPersist(Net.Vpc.Upa.Callbacks.PersistEvent @event) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.Context.DefaultEntityTriggerContext context = new Net.Vpc.Upa.Impl.Context.DefaultEntityTriggerContext(@event.GetEntity(), @event.GetTrigger(), @event.GetContext());
            keyInterceptor.AfterPersist(context, @event.GetPersistedId(), @event.GetPersistedRecord());
        }


        public override void OnPreUpdate(Net.Vpc.Upa.Callbacks.UpdateEvent @event) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.Context.DefaultEntityTriggerContext context = new Net.Vpc.Upa.Impl.Context.DefaultEntityTriggerContext(@event.GetEntity(), @event.GetTrigger(), @event.GetContext());
            foreach (object aK in ResolveIdList(@event, @event.GetFilterExpression())) {
                keyInterceptor.BeforeUpdate(context, aK, @event.GetUpdatesRecord());
            }
        }


        public override void OnUpdate(Net.Vpc.Upa.Callbacks.UpdateEvent @event) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.Context.DefaultEntityTriggerContext context = new Net.Vpc.Upa.Impl.Context.DefaultEntityTriggerContext(@event.GetEntity(), @event.GetTrigger(), @event.GetContext());
            foreach (object aK in ResolveIdList(@event, @event.GetFilterExpression())) {
                keyInterceptor.AfterUpdate(context, aK, @event.GetUpdatesRecord());
            }
        }


        public override void OnPreRemove(Net.Vpc.Upa.Callbacks.RemoveEvent @event) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.Context.DefaultEntityTriggerContext context = new Net.Vpc.Upa.Impl.Context.DefaultEntityTriggerContext(@event.GetEntity(), @event.GetTrigger(), @event.GetContext());
            foreach (object aK in ResolveIdList(@event, @event.GetFilterExpression())) {
                keyInterceptor.BeforeDelete(context, aK);
            }
        }


        public override void OnRemove(Net.Vpc.Upa.Callbacks.RemoveEvent @event) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.Context.DefaultEntityTriggerContext context = new Net.Vpc.Upa.Impl.Context.DefaultEntityTriggerContext(@event.GetEntity(), @event.GetTrigger(), @event.GetContext());
            foreach (object aK in ResolveIdList(@event, @event.GetFilterExpression())) {
                keyInterceptor.AfterDelete(context, aK);
            }
        }


        public override void OnPreUpdateFormula(Net.Vpc.Upa.Callbacks.UpdateFormulaEvent @event) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.Context.DefaultEntityTriggerContext context = new Net.Vpc.Upa.Impl.Context.DefaultEntityTriggerContext(@event.GetEntity(), @event.GetTrigger(), @event.GetContext());
            foreach (object aK in ResolveIdList(@event, @event.GetFilterExpression())) {
                keyInterceptor.BeforeUpdateFormulas(context, aK, @event.GetUpdates());
            }
        }


        public override void OnUpdateFormula(Net.Vpc.Upa.Callbacks.UpdateFormulaEvent @event) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.Context.DefaultEntityTriggerContext context = new Net.Vpc.Upa.Impl.Context.DefaultEntityTriggerContext(@event.GetEntity(), @event.GetTrigger(), @event.GetContext());
            foreach (object aK in ResolveIdList(@event, @event.GetFilterExpression())) {
                keyInterceptor.AfterUpdateFormulas(context, aK, @event.GetUpdates());
            }
        }

        protected internal virtual System.Collections.Generic.IEnumerable<object> ResolveIdList(Net.Vpc.Upa.Callbacks.EntityEvent @event, Net.Vpc.Upa.Expressions.Expression whereExpression) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Net.Vpc.Upa.Impl.Event.SingleEntityObjectEventCallback.ResolveIdListUtility(@event, whereExpression);
        }
    }
}
