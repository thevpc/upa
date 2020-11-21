/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.event;

import net.thevpc.upa.impl.config.callback.MethodArgumentsConverter;
import net.thevpc.upa.events.UpdateFormulaObjectEvent;
import net.thevpc.upa.events.RemoveEvent;
import net.thevpc.upa.events.UpdateFormulaEvent;
import net.thevpc.upa.events.UPAEvent;
import java.lang.reflect.Method;
import java.util.Map;
import net.thevpc.upa.EventType;
import net.thevpc.upa.EventPhase;
import net.thevpc.upa.ObjectType;

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
