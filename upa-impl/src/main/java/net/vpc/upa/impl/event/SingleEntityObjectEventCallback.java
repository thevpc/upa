/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.event;

import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;
import java.util.Map;
import net.vpc.upa.CallbackType;
import net.vpc.upa.EventPhase;
import net.vpc.upa.ObjectType;
import net.vpc.upa.PreparedCallback;
import net.vpc.upa.callbacks.EntityEvent;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.impl.config.callback.DefaultCallback;
import net.vpc.upa.impl.config.callback.MethodArgumentsConverter;
import net.vpc.upa.expressions.IdExpression;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.persistence.EntityExecutionContext;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public abstract class SingleEntityObjectEventCallback extends DefaultCallback implements PreparedCallback{

    public SingleEntityObjectEventCallback(Object o, Method m, CallbackType callbackType, EventPhase phase, ObjectType objectType, MethodArgumentsConverter converter, Map<String, Object> configuration) {
        super(o, m, callbackType, phase,objectType, converter,configuration);
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
