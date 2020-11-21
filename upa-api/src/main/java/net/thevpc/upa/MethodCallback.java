/**
 * ====================================================================
 * UPA (Unstructured Persistence API)
 * Yet another ORM Framework
 * ++++++++++++++++++++++++++++++++++
 * Unstructured Persistence API, referred to as UPA, is a genuine effort
 * to raise programming language frameworks managing relational data in
 * applications using Java Platform, Standard Edition and Java Platform,
 * Enterprise Edition and Dot Net Framework equally to the next level of
 * handling ORM for mutable data structures. UPA is intended to provide
 * a solid reflection mechanisms to the mapped data structures while
 * affording to make changes at runtime of those data structures.
 * Besides, UPA has learned considerably of the leading ORM
 * (JPA, Hibernate/NHibernate, MyBatis and Entity Framework to name a few)
 * failures to satisfy very common even known to be trivial requirement in
 * enterprise applications.
 * <p>
 * Copyright (C) 2014-2015 Taha BEN SALAH
 * <p>
 * This program is free software; you can redistribute it and/or modify it under
 * the terms of the GNU General Public License as published by the Free Software
 * Foundation; either version 2 of the License, or (at your option) any later
 * version.
 * <p>
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE. See the GNU General Public License for more
 * details.
 * <p>
 * You should have received a copy of the GNU General Public License along with
 * this program; if not, write to the Free Software Foundation, Inc., 51
 * Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 * ====================================================================
 */
package net.thevpc.upa;

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
    private EventType eventType;
    private EventPhase phase;
    private Map<String, Object> configuration;

    public MethodCallback() {
    }

    public MethodCallback(Object instance, Method method, EventType eventType, EventPhase phase) {
        this.instance = instance;
        this.method = method;
        this.phase = phase;
        this.eventType = eventType;
    }

    public MethodCallback(Object instance, Method method, ObjectType objectType,EventType eventType, EventPhase phase, Map<String, Object> configuration) {
        this.instance = instance;
        this.objectType = objectType;
        this.method = method;
        this.eventType = eventType;
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

    public EventType getEventType() {
        return eventType;
    }

    public MethodCallback setEventType(EventType eventType) {
        this.eventType = eventType;
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
                ", eventType=" + eventType +
                ", phase=" + phase +
                ", configuration=" + configuration +
                '}';
    }
}
