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



namespace Net.TheVpc.Upa.Impl.Event
{


    /**
     * Created by IntelliJ IDEA.
     * User: root
     * Date: 29 avr. 2003
     * Time: 12:59:47
     * To change this template use Options | File Templates.
     */
    public class SingleDataInterceptorSupport : Net.TheVpc.Upa.Callbacks.EntityListenerAdapter {

        private Net.TheVpc.Upa.Callbacks.SingleEntityListener keyInterceptor;

        public SingleDataInterceptorSupport(Net.TheVpc.Upa.Callbacks.SingleEntityListener keyInterceptor) {
            this.keyInterceptor = keyInterceptor;
        }


        public override void OnPrePersist(Net.TheVpc.Upa.Callbacks.PersistEvent @event) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Impl.Context.DefaultEntityTriggerContext context = new Net.TheVpc.Upa.Impl.Context.DefaultEntityTriggerContext(@event.GetEntity(), @event.GetTrigger(), @event.GetContext());
            keyInterceptor.BeforePersist(context, @event.GetPersistedId(), @event.GetPersistedRecord());
        }


        public override void OnPersist(Net.TheVpc.Upa.Callbacks.PersistEvent @event) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Impl.Context.DefaultEntityTriggerContext context = new Net.TheVpc.Upa.Impl.Context.DefaultEntityTriggerContext(@event.GetEntity(), @event.GetTrigger(), @event.GetContext());
            keyInterceptor.AfterPersist(context, @event.GetPersistedId(), @event.GetPersistedRecord());
        }


        public override void OnPreUpdate(Net.TheVpc.Upa.Callbacks.UpdateEvent @event) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Impl.Context.DefaultEntityTriggerContext context = new Net.TheVpc.Upa.Impl.Context.DefaultEntityTriggerContext(@event.GetEntity(), @event.GetTrigger(), @event.GetContext());
            foreach (object aK in ResolveIdList(@event, @event.GetFilterExpression())) {
                keyInterceptor.BeforeUpdate(context, aK, @event.GetUpdatesRecord());
            }
        }


        public override void OnUpdate(Net.TheVpc.Upa.Callbacks.UpdateEvent @event) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Impl.Context.DefaultEntityTriggerContext context = new Net.TheVpc.Upa.Impl.Context.DefaultEntityTriggerContext(@event.GetEntity(), @event.GetTrigger(), @event.GetContext());
            foreach (object aK in ResolveIdList(@event, @event.GetFilterExpression())) {
                keyInterceptor.AfterUpdate(context, aK, @event.GetUpdatesRecord());
            }
        }


        public override void OnPreRemove(Net.TheVpc.Upa.Callbacks.RemoveEvent @event) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Impl.Context.DefaultEntityTriggerContext context = new Net.TheVpc.Upa.Impl.Context.DefaultEntityTriggerContext(@event.GetEntity(), @event.GetTrigger(), @event.GetContext());
            foreach (object aK in ResolveIdList(@event, @event.GetFilterExpression())) {
                keyInterceptor.BeforeDelete(context, aK);
            }
        }


        public override void OnRemove(Net.TheVpc.Upa.Callbacks.RemoveEvent @event) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Impl.Context.DefaultEntityTriggerContext context = new Net.TheVpc.Upa.Impl.Context.DefaultEntityTriggerContext(@event.GetEntity(), @event.GetTrigger(), @event.GetContext());
            foreach (object aK in ResolveIdList(@event, @event.GetFilterExpression())) {
                keyInterceptor.AfterDelete(context, aK);
            }
        }


        public override void OnPreUpdateFormula(Net.TheVpc.Upa.Callbacks.UpdateFormulaEvent @event) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Impl.Context.DefaultEntityTriggerContext context = new Net.TheVpc.Upa.Impl.Context.DefaultEntityTriggerContext(@event.GetEntity(), @event.GetTrigger(), @event.GetContext());
            foreach (object aK in ResolveIdList(@event, @event.GetFilterExpression())) {
                keyInterceptor.BeforeUpdateFormulas(context, aK, @event.GetUpdates());
            }
        }


        public override void OnUpdateFormula(Net.TheVpc.Upa.Callbacks.UpdateFormulaEvent @event) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Impl.Context.DefaultEntityTriggerContext context = new Net.TheVpc.Upa.Impl.Context.DefaultEntityTriggerContext(@event.GetEntity(), @event.GetTrigger(), @event.GetContext());
            foreach (object aK in ResolveIdList(@event, @event.GetFilterExpression())) {
                keyInterceptor.AfterUpdateFormulas(context, aK, @event.GetUpdates());
            }
        }

        protected internal virtual System.Collections.Generic.IEnumerable<object> ResolveIdList(Net.TheVpc.Upa.Callbacks.EntityEvent @event, Net.TheVpc.Upa.Expressions.Expression whereExpression) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return Net.TheVpc.Upa.Impl.Event.SingleEntityObjectEventCallback.ResolveIdListUtility(@event, whereExpression);
        }
    }
}
