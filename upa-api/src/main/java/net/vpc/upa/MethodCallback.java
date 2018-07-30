/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa;

import java.lang.reflect.Method;
import java.util.HashMap;
import java.util.Map;

/**
 * @author taha.bensalah@gmail.com
 */
public class MethodCallback {

    private Object instance;
    private Method method;
    private ObjectType objectType;
    private CallbackType callbackType;
    private EventPhase phase;
    private Map<String, Object> configuration;

    public MethodCallback() {
    }

    public MethodCallback(Object instance, Method method, CallbackType callbackType, EventPhase phase) {
        this.instance = instance;
        this.method = method;
        this.phase = phase;
        this.callbackType = callbackType;
    }

    public MethodCallback(Object instance, Method method, ObjectType objectType,CallbackType callbackType, EventPhase phase, Map<String, Object> configuration) {
        this.instance = instance;
        this.objectType = objectType;
        this.method = method;
        this.callbackType = callbackType;
        this.phase = phase;
        this.configuration = configuration;
    }

    public ObjectType getObjectType() {
        return objectType;
    }

    public EventPhase getPhase() {
        return phase;
    }

    public Object getInstance() {
        return instance;
    }

    public MethodCallback setInstance(Object instance) {
        this.instance = instance;
        return this;
    }

    public Method getMethod() {
        return method;
    }

    public MethodCallback setMethod(Method method) {
        this.method = method;
        return this;
    }

    public CallbackType getCallbackType() {
        return callbackType;
    }

    public MethodCallback setCallbackType(CallbackType callbackType) {
        this.callbackType = callbackType;
        return this;
    }

    public Map<String, Object> getConfiguration() {
        return configuration;
    }

    public MethodCallback setConfiguration(Map<String, Object> configuration) {
        this.configuration = configuration;
        return this;
    }

    public MethodCallback putConfig(String name, Object value) {
        if (configuration == null) {
            configuration = new HashMap<String, Object>();
        }
        configuration.put(name, value);
        return this;
    }

    @Override
    public String toString() {
        return "MethodCallback{" +
                "instance=" + instance +
                ", method=" + method +
                ", objectType=" + objectType +
                ", callbackType=" + callbackType +
                ", phase=" + phase +
                ", configuration=" + configuration +
                '}';
    }
}
