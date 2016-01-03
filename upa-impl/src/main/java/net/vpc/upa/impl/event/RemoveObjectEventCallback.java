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
import net.vpc.upa.callbacks.RemoveEvent;
import net.vpc.upa.callbacks.RemoveObjectEvent;
import net.vpc.upa.impl.config.callback.MethodArgumentsConverter;

/**
 *
 * @author vpc
 */
public class RemoveObjectEventCallback extends SingleEntityObjectEventCallback {

    public RemoveObjectEventCallback(Object o, Method m, CallbackType callbackType, ObjectType objectType, MethodArgumentsConverter converter, Map<String, Object> configuration) {
        super(o, m, callbackType, objectType, converter,configuration);
    }

    @Override
    public Object invoke(Object... arguments) {
        RemoveEvent ev = (RemoveEvent) arguments[0];
        for (Object id : resolveIdList(ev, ev.getFilterExpression())) {
            RemoveObjectEvent oe = new RemoveObjectEvent(id, ev.getFilterExpression(), ev.getContext());
            invokeSingle(oe);
        }
        return null;
    }
}
