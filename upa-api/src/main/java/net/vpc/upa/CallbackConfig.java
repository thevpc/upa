/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa;

import java.lang.reflect.Method;
import java.util.HashMap;
import java.util.Map;

/**
 *
 * @author vpc
 */
public class CallbackConfig {

    private Object instance;
    private Method method;
    private CallbackType callbackType;
    private Map<String, Object> configuration;

    public CallbackConfig() {
    }

    public CallbackConfig(Object instance, Method method, CallbackType callbackType) {
        this.instance = instance;
        this.method = method;
        this.callbackType = callbackType;
    }

    public CallbackConfig(Object instance, Method method, CallbackType callbackType, Map<String, Object> configuration) {
        this.instance = instance;
        this.method = method;
        this.callbackType = callbackType;
        this.configuration = configuration;
    }

    public Object getInstance() {
        return instance;
    }

    public CallbackConfig setInstance(Object instance) {
        this.instance = instance;
        return this;
    }

    public Method getMethod() {
        return method;
    }

    public CallbackConfig setMethod(Method method) {
        this.method = method;
        return this;
    }

    public CallbackType getCallbackType() {
        return callbackType;
    }

    public CallbackConfig setCallbackType(CallbackType callbackType) {
        this.callbackType = callbackType;
        return this;
    }

    public Map<String, Object> getConfiguration() {
        return configuration;
    }

    public CallbackConfig setConfiguration(Map<String, Object> configuration) {
        this.configuration = configuration;
        return this;
    }

    public CallbackConfig putConfig(String name, Object value) {
        if (configuration == null) {
            configuration = new HashMap<String, Object>();
        }
        configuration.put(name, value);
        return this;
    }
}
