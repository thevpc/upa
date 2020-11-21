/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.event;

import java.lang.reflect.Method;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;
import java.util.Map;

import net.thevpc.upa.impl.config.callback.DefaultCallback;
import net.thevpc.upa.impl.config.callback.MethodArgumentsConverter;
import net.thevpc.upa.EventType;
import net.thevpc.upa.EventPhase;
import net.thevpc.upa.ObjectType;
import net.thevpc.upa.PreparedCallback;
import net.thevpc.upa.events.EntityEvent;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.expressions.Expression;
import net.thevpc.upa.expressions.IdExpression;
import net.thevpc.upa.impl.util.PlatformUtils;
import net.thevpc.upa.persistence.EntityExecutionContext;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public abstract class SingleEntityObjectEventCallback extends DefaultCallback implements PreparedCallback{

    public SingleEntityObjectEventCallback(Object o, Method m, EventType eventType, EventPhase phase, ObjectType objectType, MethodArgumentsConverter converter, Map<String, Object> configuration) {
        super(o, m, eventType, phase,objectType, converter,configuration);
    }


    
    protected void invokeSingle(EntityEvent singleEvent) {
        try {
            method.invoke(instance, converter.convert(new Object[]{singleEvent}));
        } catch (Exception ex) {
            throw PlatformUtils.createRuntimeException(ex);
        }
    }

    public static List<Object> resolveIdListUtility(EntityEvent event, Expression whereExpression) throws UPAException {
        EntityExecutionContext executionContext = event.getContext();
        if (whereExpression instanceof IdExpression) {
            Object id = ((IdExpression) whereExpression).getId();
            return id==null? Collections.EMPTY_LIST:Arrays.asList(id);
        } else {
            if (!executionContext.isSet("ALL_IDS")) {
                if(event.getPhase()== EventPhase.AFTER){
                    throw new UPAException("SingleEntityEventCalledInPostProcessButNeverInPreProcess");
                }
                List<Object> idList = event.getEntity().createQueryBuilder().byExpression(whereExpression).getIdList();
                executionContext.setObject("ALL_IDS", idList);
            }
            return (List<Object>) executionContext.getObject("ALL_IDS");
        }
    }

    protected List<Object> resolveIdList(EntityEvent event, Expression whereExpression) throws UPAException {
        return resolveIdListUtility(event,whereExpression);
    }

}
