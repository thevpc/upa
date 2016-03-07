/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.event;

import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;
import java.util.Arrays;
import java.util.List;
import java.util.Map;
import net.vpc.upa.CallbackType;
import net.vpc.upa.ObjectType;
import net.vpc.upa.callbacks.EntityEvent;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.impl.config.callback.DefaultCallback;
import net.vpc.upa.impl.config.callback.MethodArgumentsConverter;
import net.vpc.upa.expressions.IdExpression;
import net.vpc.upa.persistence.EntityExecutionContext;

/**
 *
 * @author vpc
 */
public abstract class SingleEntityObjectEventCallback extends DefaultCallback {

    public SingleEntityObjectEventCallback(Object o, Method m, CallbackType callbackType, ObjectType objectType, MethodArgumentsConverter converter, Map<String, Object> configuration) {
        super(o, m, callbackType, objectType, converter,configuration);
    }


    
    protected void invokeSingle(EntityEvent singleEvent) {
        try {
            method.invoke(instance, converter.convert(new Object[]{singleEvent}));
        } catch (IllegalAccessException e) {
            throw new IllegalArgumentException(e);
        } catch (InvocationTargetException e) {
            throw new IllegalArgumentException(e);
        }
    }

    protected Iterable<Object> resolveIdList(EntityEvent event, Expression whereExpression) throws UPAException {
        EntityExecutionContext executionContext = event.getContext();
        if (whereExpression instanceof IdExpression) {
            return Arrays.asList(((IdExpression) whereExpression).getId());
        } else {
            if (!executionContext.isSet("ALL_KEYS")) {
                List<Object> idList = event.getEntity().createQueryBuilder().setExpression(whereExpression).getIdList();
                executionContext.setObject("ALL_KEYS", idList);
            }
            return (List<Object>) executionContext.getObject("ALL_KEYS");
        }
    }

}
