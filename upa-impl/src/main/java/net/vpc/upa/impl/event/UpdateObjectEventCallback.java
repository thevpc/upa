/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.event;

import java.lang.reflect.Method;
import java.util.Map;
import net.vpc.upa.CallbackType;
import net.vpc.upa.ObjectType;
import net.vpc.upa.callbacks.UpdateEvent;
import net.vpc.upa.callbacks.UpdateObjectEvent;
import net.vpc.upa.impl.config.callback.MethodArgumentsConverter;

/**
 *
 * @author vpc
 */
public class UpdateObjectEventCallback extends SingleEntityObjectEventCallback {

    public UpdateObjectEventCallback(Object o, Method m, CallbackType callbackType, ObjectType objectType, MethodArgumentsConverter converter, Map<String, Object> configuration) {
        super(o, m, callbackType, objectType, converter, configuration);
    }

    @Override
    public Object invoke(Object... arguments) {
        UpdateEvent ev = (UpdateEvent) arguments[0];
        for (Object id : resolveIdList(ev, ev.getFilterExpression())) {
            UpdateObjectEvent oe = new UpdateObjectEvent(id, ev.getUpdatesRecord(), ev.getFilterExpression(), ev.getContext(),getPhase());
            invokeSingle(oe);
        }
        return null;
    }
}
