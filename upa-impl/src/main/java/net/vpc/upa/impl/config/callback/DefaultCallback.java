package net.vpc.upa.impl.config.callback;

import net.vpc.upa.Callback;
import net.vpc.upa.CallbackType;
import net.vpc.upa.ObjectType;

import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;
import java.util.Map;
import net.vpc.upa.EventPhase;
import net.vpc.upa.impl.util.PlatformUtils;

/**
 * Created by vpc on 7/25/15.
 */
public class DefaultCallback implements Callback {

    protected MethodArgumentsConverter converter;
    protected Object instance;
    protected Method method;
    private CallbackType callbackType;
    private ObjectType objectType;
    private Map<String, Object> configuration;
    private EventPhase phase;

    public DefaultCallback(Object o, Method m, CallbackType callbackType, EventPhase phase,ObjectType objectType, MethodArgumentsConverter converter, Map<String, Object> configuration) {
        this.converter = converter;
        this.instance = o;
        this.method = m;
        this.method.setAccessible(true);
        this.objectType = objectType;
        this.callbackType = callbackType;
        this.configuration = configuration;
        this.phase = phase;
    }

    public EventPhase getPhase() {
        return phase;
    }

    public Map<String, Object> getConfiguration() {
        return configuration;
    }

    public CallbackType getCallbackType() {
        return callbackType;
    }

    public ObjectType getObjectType() {
        return objectType;
    }

    @Override
    public Object invoke(Object... arguments) {
        try {
            return method.invoke(instance, converter.convert(arguments));
        } catch (Exception e) {
            throw PlatformUtils.createRuntimeException(e);
        }
    }

    @Override
    public boolean equals(Object o1) {
        if (this == o1) {
            return true;
        }
        if (o1 == null || getClass() != o1.getClass()) {
            return false;
        }

        DefaultCallback that = (DefaultCallback) o1;

        if (converter != null ? !converter.equals(that.converter) : that.converter != null) {
            return false;
        }
        if (instance != null ? !instance.equals(that.instance) : that.instance != null) {
            return false;
        }
        return !(method != null ? !method.equals(that.method) : that.method != null);

    }

    @Override
    public int hashCode() {
        int result = converter != null ? converter.hashCode() : 0;
        result = 31 * result + (instance != null ? instance.hashCode() : 0);
        result = 31 * result + (method != null ? method.hashCode() : 0);
        return result;
    }
}
