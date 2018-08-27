package net.vpc.upa.impl.util;

import net.vpc.upa.EventType;
import net.vpc.upa.ObjectType;

/**
 * Created by vpc on 7/25/15.
 */
public final class CallbackInvokerKey {
    private EventType eventType;
    private ObjectType objectType;
    private boolean system;
    private String name;

    public CallbackInvokerKey(EventType eventType, ObjectType objectType, String name, boolean system) {
        this.eventType = eventType;
        this.objectType = objectType;
        this.system = system;
        this.name = name;
    }

    public EventType getEventType() {
        return eventType;
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
        if (eventType != that.eventType) return false;
        if (objectType != that.objectType) return false;
        return !(name != null ? !name.equals(that.name) : that.name != null);

    }

    @Override
    public int hashCode() {
        int result = eventType != null ? eventType.hashCode() : 0;
        result = 31 * result + (objectType != null ? objectType.hashCode() : 0);
        result = 31 * result + (system ? 1 : 0);
        result = 31 * result + (name != null ? name.hashCode() : 0);
        return result;
    }
}
