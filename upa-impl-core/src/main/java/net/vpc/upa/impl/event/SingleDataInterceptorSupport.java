package net.vpc.upa.impl.event;


import net.vpc.upa.events.SingleEntityListener;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Expression;

import net.vpc.upa.events.EntityEvent;
import net.vpc.upa.events.EntityListenerAdapter;
import net.vpc.upa.events.PersistEvent;
import net.vpc.upa.events.RemoveEvent;
import net.vpc.upa.events.UpdateEvent;
import net.vpc.upa.events.UpdateFormulaEvent;
import net.vpc.upa.impl.context.DefaultEntityTriggerContext;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 29 avr. 2003
 * Time: 12:59:47
 * 
 */
public class SingleDataInterceptorSupport extends EntityListenerAdapter {
    private SingleEntityListener keyInterceptor;

    public SingleDataInterceptorSupport(SingleEntityListener keyInterceptor) {
        this.keyInterceptor = keyInterceptor;
    }

    @Override
    public void onPrePersist(PersistEvent event) throws UPAException {
        DefaultEntityTriggerContext context = new DefaultEntityTriggerContext(event.getEntity(), event.getTrigger(), event.getContext());
        keyInterceptor.beforePersist(context, event.getPersistedId(), event.getPersistedDocument());
    }

    @Override
    public void onPersist(PersistEvent event) throws UPAException {
        DefaultEntityTriggerContext context = new DefaultEntityTriggerContext(event.getEntity(), event.getTrigger(), event.getContext());
        keyInterceptor.afterPersist(context, event.getPersistedId(), event.getPersistedDocument());
    }

    @Override
    public void onPreUpdate(UpdateEvent event)
            throws UPAException {
        DefaultEntityTriggerContext context = new DefaultEntityTriggerContext(event.getEntity(), event.getTrigger(), event.getContext());
        for (Object aK : resolveIdList(event, event.getFilterExpression())) {
            keyInterceptor.beforeUpdate(context, aK, event.getUpdatesDocument());
        }
    }

    @Override
    public void onUpdate(UpdateEvent event)
            throws UPAException {
        DefaultEntityTriggerContext context = new DefaultEntityTriggerContext(event.getEntity(), event.getTrigger(), event.getContext());
        for (Object aK : resolveIdList(event, event.getFilterExpression())) {
            keyInterceptor.afterUpdate(context, aK, event.getUpdatesDocument());
        }
    }

    @Override
    public void onPreRemove(RemoveEvent event)
            throws UPAException {
        DefaultEntityTriggerContext context = new DefaultEntityTriggerContext(event.getEntity(), event.getTrigger(), event.getContext());
        for (Object aK : resolveIdList(event, event.getFilterExpression())) {
            keyInterceptor.beforeRemove(context, aK);
        }
    }

    @Override
    public void onRemove(RemoveEvent event)
            throws UPAException {
        DefaultEntityTriggerContext context = new DefaultEntityTriggerContext(event.getEntity(), event.getTrigger(), event.getContext());
        for (Object aK : resolveIdList(event, event.getFilterExpression())) {
            keyInterceptor.afterRemove(context, aK);
        }
    }

    @Override
    public void onPreUpdateFormula(UpdateFormulaEvent event) throws UPAException {
        DefaultEntityTriggerContext context = new DefaultEntityTriggerContext(event.getEntity(), event.getTrigger(), event.getContext());
        for (Object aK : resolveIdList(event, event.getFilterExpression())) {
            keyInterceptor.beforeUpdateFormulas(context, aK, event.getUpdates());
        }
    }

    @Override
    public void onUpdateFormula(UpdateFormulaEvent event) throws UPAException {
        DefaultEntityTriggerContext context = new DefaultEntityTriggerContext(event.getEntity(), event.getTrigger(), event.getContext());
        for (Object aK : resolveIdList(event, event.getFilterExpression())) {
            keyInterceptor.afterUpdateFormulas(context, aK, event.getUpdates());
        }
    }

    protected Iterable<Object> resolveIdList(EntityEvent event, Expression whereExpression) throws UPAException {
        return SingleEntityObjectEventCallback.resolveIdListUtility(event,whereExpression);
    }
}
