package net.thevpc.upa.impl.event;


import net.thevpc.upa.impl.context.DefaultEntityTriggerContext;
import net.thevpc.upa.events.SingleEntityListener;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.expressions.Expression;

import net.thevpc.upa.events.EntityEvent;
import net.thevpc.upa.events.EntityListenerAdapter;
import net.thevpc.upa.events.PersistEvent;
import net.thevpc.upa.events.RemoveEvent;
import net.thevpc.upa.events.UpdateEvent;
import net.thevpc.upa.events.UpdateFormulaEvent;

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
