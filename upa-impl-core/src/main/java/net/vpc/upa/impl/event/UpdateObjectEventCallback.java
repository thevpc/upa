/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.event;

import net.vpc.upa.events.UpdateEvent;
import net.vpc.upa.events.UPAEvent;
import net.vpc.upa.events.UpdateObjectEvent;
import java.lang.reflect.Method;
import java.util.Map;
import net.vpc.upa.EventType;
import net.vpc.upa.Document;
import net.vpc.upa.EventPhase;
import net.vpc.upa.ObjectType;
import net.vpc.upa.impl.config.callback.MethodArgumentsConverter;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class UpdateObjectEventCallback extends SingleEntityObjectEventCallback {

    public UpdateObjectEventCallback(Object o, Method m, EventType eventType, EventPhase phase, ObjectType objectType, MethodArgumentsConverter converter, Map<String, Object> configuration) {
        super(o, m, eventType, phase,objectType, converter, configuration);
    }

    @Override
    public void prepare(UPAEvent event) {
        UpdateEvent ev = (UpdateEvent) event;
        resolveIdList(ev, ev.getFilterExpression());
    }

    @Override
    public Object invoke(Object... arguments) {
        UpdateEvent ev = (UpdateEvent) arguments[0];
        for (Object id : resolveIdList(ev, ev.getFilterExpression())) {
            Document updatesDocument = ev.getUpdatesDocument().copy();
            ev.getEntity().getBuilder().setObjectId(updatesDocument,id);
            UpdateObjectEvent oe = new UpdateObjectEvent(id, updatesDocument, ev.getFilterExpression(), ev.getContext(),getEventPhase());
            invokeSingle(oe);
        }
        return null;
    }
}
