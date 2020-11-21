/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.event;

import net.thevpc.upa.impl.config.callback.MethodArgumentsConverter;
import net.thevpc.upa.events.UpdateEvent;
import net.thevpc.upa.events.UPAEvent;
import net.thevpc.upa.events.UpdateObjectEvent;
import java.lang.reflect.Method;
import java.util.Map;
import net.thevpc.upa.EventType;
import net.thevpc.upa.Document;
import net.thevpc.upa.EventPhase;
import net.thevpc.upa.ObjectType;

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
