/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.event;

import net.vpc.upa.events.UpdateFormulaObjectEvent;
import net.vpc.upa.events.RemoveEvent;
import net.vpc.upa.events.UpdateFormulaEvent;
import net.vpc.upa.events.UPAEvent;
import java.lang.reflect.Method;
import java.util.Map;
import net.vpc.upa.EventType;
import net.vpc.upa.EventPhase;
import net.vpc.upa.ObjectType;
import net.vpc.upa.impl.config.callback.MethodArgumentsConverter;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class UpdateFormulaObjectEventCallback extends SingleEntityObjectEventCallback {

    public UpdateFormulaObjectEventCallback(Object o, Method m, EventType eventType, EventPhase phase, ObjectType objectType, MethodArgumentsConverter converter, Map<String, Object> configuration) {
        super(o, m, eventType, phase,objectType, converter,configuration);
    }

    @Override
    public void prepare(UPAEvent event) {
        RemoveEvent ev = (RemoveEvent) event;
        resolveIdList(ev, ev.getFilterExpression());
    }

    @Override
    public Object invoke(Object... arguments) {
        UpdateFormulaEvent ev = (UpdateFormulaEvent) arguments[0];
        for (Object id : resolveIdList(ev, ev.getFilterExpression())) {
            UpdateFormulaObjectEvent oe = new UpdateFormulaObjectEvent(id, ev.getUpdates(), ev.getFilterExpression(), ev.getContext(),getEventPhase());
            invokeSingle(oe);
        }
        return null;
    }
}
