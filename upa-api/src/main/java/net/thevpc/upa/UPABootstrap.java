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

import java.util.ArrayList;
import java.util.List;

import net.thevpc.upa.exceptions.BootstrapException;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.persistence.UPAContextConfig;

import java.util.Map;

/**
 * Created by vpc on 8/6/16.
 */
public class UPABootstrap {

    private boolean contextProviderCreated = false;
    private final Properties properties = new BootstrapProperties();

    static final int CONTEXT_NOT_INITIALIZED = 0;
    static final int CONTEXT_INITIALIZING = 1;
    static final int CONTEXT_INITIALIZED = 2;
    static final int CONTEXT_INITIALIZATION_ERROR = 3;
    int bootstrapStatus = CONTEXT_NOT_INITIALIZED;

    private final List<UPAContextConfig> configInstances = new ArrayList<UPAContextConfig>();
    private final List<Class> configClasses = new ArrayList<Class>();

    UPABootstrap() {
        init();
    }

    private void init() {
        contextProviderCreated = false;
        bootstrapStatus = CONTEXT_NOT_INITIALIZED;
        configInstances.clear();
        configClasses.clear();
        for (Map.Entry<Object, Object> ee : System.getProperties().entrySet()) {
            properties.setString((String) ee.getKey(), (String) ee.getValue());
        }
    }

    /**
     * Closes this instance and resets it to its initial state. The instance
     * becomes reusable after its closing. If the instance is not yet
     * initialized, calling this method has no side effects. Multiple calls to
     * this method has no side effects either.
     */
    public void close() {
        init();
    }

    public boolean isClosable() {
        return contextProviderCreated || bootstrapStatus != CONTEXT_NOT_INITIALIZED;
    }

    public boolean isContextInitialized() {
        return contextProviderCreated;
    }

    void checkUninitialized() {
        if (bootstrapStatus == CONTEXT_INITIALIZING) {
            throw new UPAException("UPAAlreadyInitializing");
        }
        if (bootstrapStatus == CONTEXT_INITIALIZATION_ERROR) {
            throw new UPAException("UPAInitializationError.TryClose");
        }
    }

    void setContextCreated() {
        contextProviderCreated = true;
    }

    void setContextInitializing() {
        bootstrapStatus = CONTEXT_INITIALIZING;
    }

    void setContextInitialized() {
        bootstrapStatus = CONTEXT_INITIALIZED;
    }

    void checkContextInitialized() {
        if (bootstrapStatus != CONTEXT_INITIALIZED) {
            throw new BootstrapException("UPANonInitializedContext");
        }
    }

    void setContextError() {
        bootstrapStatus = CONTEXT_INITIALIZATION_ERROR;
    }

    public ObjectFactory getFactory() {
        try {
            return BootstrapObjectFactoryLazyHolder.INSTANCE;
        } catch (Throwable e) {
            /**
             * @PortabilityHint(target = "C#",name = "suppress")
             */
            if (e instanceof java.lang.ExceptionInInitializerError) {
                throw new BootstrapException("ObjectFactoryInitializationFailed",e.getCause());
            }
            throw new BootstrapException("ObjectFactoryInitializationFailed",e);
        }
    }

    public Properties getProperties() {
        return properties;
    }

    public void configure(UPAContextConfig config) {
        if (bootstrapStatus != CONTEXT_NOT_INITIALIZED) {
            if (bootstrapStatus == CONTEXT_INITIALIZATION_ERROR) {
                throw new UPAException("UPAContexError");
            }
            throw new UPAException("UPAAlreadyInitializing");
        }
        if (config != null) {
            configInstances.add(config);
        }
    }

    public void configure(Class config) {
        if (bootstrapStatus != CONTEXT_NOT_INITIALIZED) {
            if (bootstrapStatus == CONTEXT_INITIALIZATION_ERROR) {
                throw new UPAException("UPAContexError");
            }
            throw new UPAException("UPAAlreadyInitializing");
        }
        if (config != null) {
            configClasses.add(config);
        }
    }

    public UPAContextConfig[] getConfigInstances() {
        return configInstances.toArray(new UPAContextConfig[configInstances.size()]);
    }

    public Class[] getConfigClasses() {
        return configClasses.toArray(new Class[configClasses.size()]);
    }

}
