package net.vpc.upa.impl.util;

import net.vpc.upa.CallbackType;
import net.vpc.upa.ObjectType;

/**
 * Created by vpc on 7/25/15.
 */
public final class CallbackInvokerKey {
    private CallbackType callbackType;
    private ObjectType objectType;
    private boolean system;
    private String name;

    public CallbackInvokerKey(CallbackType callbackType, ObjectType objectType, String name, boolean system) {
        this.callbackType = callbackType;
        this.objectType = objectType;
        this.system = system;
        this.name = name;
    }

    public CallbackType getCallbackType() {
        return callbackType;
    }

    public ObjectType getObjectType() {
        return objectType;
    }

    public boolean isSystem() {
        return system;
    }

    public String getName() {
        return name;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        CallbackInvokerKey that = (CallbackInvokerKey) o;

        if (system != that.system) return false;
        if (callbackType != that.callbackType) return false;
        if (objectType != that.objectType) return false;
        return !(name != null ? !name.equals(that.name) : that.name != null);

    }

    @Override
    public int hashCode() {
        int result = callbackType != null ? callbackType.hashCode() : 0;
        result = 31 * result + (objectType != null ? objectType.hashCode() : 0);
        result = 31 * result + (system ? 1 : 0);
        result = 31 * result + (name != null ? name.hashCode() : 0);
        return result;
    }
}
