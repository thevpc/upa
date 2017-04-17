package net.vpc.upa;

/**
 * Created by vpc on 7/25/15.
 */
public interface Callback {

    Object invoke(Object... arguments);

    CallbackType getCallbackType();

    EventPhase getPhase();

    ObjectType getObjectType();
}
