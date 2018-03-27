/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.event;

import java.lang.reflect.Method;
import java.util.Map;
import net.vpc.upa.CallbackType;
import net.vpc.upa.EventPhase;
import net.vpc.upa.ObjectType;
import net.vpc.upa.callbacks.*;
import net.vpc.upa.impl.config.callback.MethodArgumentsConverter;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class UpdateFormulaObjectEventCallback extends SingleEntityObjectEventCallback {

    public UpdateFormulaObjectEventCallback(Object o, Method m, CallbackType callbackType, EventPhase phase, ObjectType objectType, MethodArgumentsConverter converter, Map<String, Object> configuration) {
        super(o, m, callbackType, phase,objectType, converter,configuration);
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
            UpdateFormulaObjectEvent oe = new UpdateFormulaObjectEvent(id, ev.getUpdates(), ev.getFilterExpression(), ev.getContext(),getPhase());
            invokeSingle(oe);
        }
        return null;
    }
}
