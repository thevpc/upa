package net.vpc.upa;

import java.util.Map;

/**
 * Created by vpc on 6/9/17.
 */
public abstract class AbstractCallback implements Callback {
    private CallbackType callbackType;

    private EventPhase phase;

    private ObjectType objectType;

    private Map<String, Object> configuration;

    public AbstractCallback(CallbackType callbackType, EventPhase phase, ObjectType objectType, Map<String, Object> configuration) {
        this.callbackType = callbackType;
        this.phase = phase;
        this.objectType = objectType;
        this.configuration = configuration;
    }

    @Override
    public CallbackType getCallbackType() {
        return callbackType;
    }

    @Override
    public EventPhase getPhase() {
        return phase;
    }

    @Override
    public ObjectType getObjectType() {
        return objectType;
    }

    @Override
    public Map<String, Object> getConfiguration() {
        return configuration;
    }

}
