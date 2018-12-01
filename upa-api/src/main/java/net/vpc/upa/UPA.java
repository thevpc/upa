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
package net.vpc.upa;

import net.vpc.upa.exceptions.BootstrapException;

import java.lang.annotation.Annotation;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.persistence.UPAContextConfig;

/**
 * UPA (Unstructured Persistence API) is a simple yet powerful ORM aiming to
 * replace JPA. This class is the Entry Point for using UPA.
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/9/12 12:42 PM
 */
public final class UPA {

    /**
     * string to use if string value is undefined.
     */
    public static final String UNDEFINED_STRING = "<<Undefined>>";

    /**
     * Connection string parameter name
     */
    public static final String CONNECTION_STRING = "upa.connection";

    /**
     * Root connection string parameter name
     */
    public static final String ROOT_CONNECTION_STRING = "upa.root-connection";
    protected static final Logger log = Logger.getLogger(UPA.class.getName());

    private static final UPABootstrap BOOTSTRAP = new UPABootstrap();

    /**
     * Private constructor
     */
    private UPA() {
    }

    /**
     * Current PersistenceGroup of the current context. Equivalent to
     * <pre>
     *     UPA.getContext().getPersistenceGroup()
     * </pre>
     *
     * @return current PersistenceGroup of the current context
     */
    public static PersistenceGroup getPersistenceGroup() {
        return getContext().getPersistenceGroup();
    }

    /**
     * PersistenceGroup by name {@code name}. Equivalent to
     * <pre>
     *     UPA.getContext().getPersistenceGroup(name)
     * </pre>
     *
     * @param name group name
     * @return current PersistenceGroup of the current context
     */
    public static PersistenceGroup getPersistenceGroup(String name) {
        return getContext().getPersistenceGroup(name);
    }

    /**
     * Current PersistenceUnit of the current PersistenceGroup of the current
     * context. Equivalent to
     * <pre>
     *     UPA.getContext().getPersistenceGroup().getPersistenceUnit()
     * </pre>
     *
     * @return Current PersistenceUnit of teh current PersistenceGroup of the
     * current context
     * @
     */
    public static PersistenceUnit getPersistenceUnit() {
        return getContext().getPersistenceGroup().getPersistenceUnit();
    }

    /**
     * PersistenceUnit named {@code name} in the current PersistenceGroup of the
     * current context. Equivalent to
     * <pre>
     *     UPA.getContext().getPersistenceGroup().getPersistenceUnit(name)
     * </pre>
     *
     * @param name PersistenceUnit name
     * @return PersistenceUnit named {@code name} in the current
     * PersistenceGroup of the current context
     * @
     */
    public static PersistenceUnit getPersistenceUnit(String name) {
        return getContext().getPersistenceGroup().getPersistenceUnit(name);
    }

    /**
     * PersistenceUnit named {@code persistenceUnit} in the PersistenceGroup
     * named {@code persistenceGroup} of the current context. Equivalent to
     * <pre>
     *     UPA.getContext().getPersistenceGroup(persistenceGroup).getPersistenceUnit(persistenceUnit)
     * </pre>
     *
     * @param persistenceGroup PersistenceGroup name. Should not be null
     * @param persistenceUnit PersistenceUnit name. Should not be null
     * @return PersistenceUnit named {@code persistenceUnit} in the current
     * PersistenceGroup of the current context
     * @
     */
    public static PersistenceUnit getPersistenceUnit(String persistenceGroup, String persistenceUnit) {
        return getContext().getPersistenceGroup(persistenceGroup).getPersistenceUnit(persistenceUnit);
    }

    public static <T> T makeSessionAware(T instance) {
        return makeSessionAware(instance, (MethodFilter) null);
    }

    public static <T> T makeSessionAware(T instance, final Class<Annotation> sessionAwareMethodAnnotation) {
        return getContext().makeSessionAware(instance, sessionAwareMethodAnnotation);
    }

    public static <T> T makeSessionAware(T instance, MethodFilter methodFilter) {
        return getContext().makeSessionAware(instance, methodFilter);
    }

    /**
     * Thread Safe retrieval of UPAContext
     *
     * @return current UPAContext
     */
    public static UPAContext getContext() {
        BOOTSTRAP.checkUninitialized();
        UPAContextProvider contextProvider = null;
        /**
         * @PortabilityHint(target="C#",name="suppress")
         */
        try {
            contextProvider = UPAContextProviderLazyHolder.INSTANCE;
        } catch (Throwable e) {
            /**
             * @PortabilityHint(target = "C#",name = "suppress")
             */
            if (e instanceof java.lang.ExceptionInInitializerError) {
                throw new BootstrapException("UPAContextProviderInitializationFailed", e.getCause());
            }
            throw new BootstrapException("UPAContextProviderInitializationFailed", e);
        }

        BOOTSTRAP.setContextCreated();
        UPAContext context = contextProvider.getContext();
        //Double Checking Lock will/should work here because we are not about to instantiate the object,
        //this is the responsibility of the contextProvider
        if (context == null) {
            synchronized (BOOTSTRAP) {
                context = contextProvider.getContext();
                if (context == null) {
                    BOOTSTRAP.setContextInitializing();
                    boolean success = false;
                    try {
                        long start = System.currentTimeMillis();
                        ObjectFactory bootstrapFactory = BOOTSTRAP.getFactory();
                        context = bootstrapFactory.createObject(UPAContext.class);
                        context.start(bootstrapFactory, BOOTSTRAP.getConfigInstances(), BOOTSTRAP.getConfigClasses());
                        contextProvider.setContext(context);
                        long end = System.currentTimeMillis();
                        log.log(Level.FINE, "UPA Context Loaded in {0} ms", end - start);
                        BOOTSTRAP.setContextInitialized();
                        success = true;
                    } finally {
                        //startup failed!
                        //reset status
                        if (!success) {
                            BOOTSTRAP.setContextError();
                        }
                    }
                }
            }
        } else {
            BOOTSTRAP.checkUninitialized();
        }
        return context;
    }

    public static ObjectFactory getBootstrapFactory() {
        return BOOTSTRAP.getFactory();
    }

    public static UPABootstrap getBootstrap() {
        return BOOTSTRAP;
    }

    /**
     * Closes the UPA context and resets it to its initial state. UPA context
     * becomes reusable after its closing. If the context is not yet
     * initialized, calling this method has no side effects. Multiple calls to
     * this method has no side effects either.
     */
    public static void close() {
        if (BOOTSTRAP.isClosable()) {
            log.log(Level.WARNING, "Closing UPA context.");
            UPAContext context = UPAContextProviderLazyHolder.INSTANCE.getContext();
            if (context != null) {
                context.close();
            }
            UPAContextProviderLazyHolder.INSTANCE.close();
            BOOTSTRAP.close();
            log.log(Level.WARNING, "Closing UPA closed successfully.");
        }
    }

    public static void configure(UPAContextConfig config) {
        BOOTSTRAP.configure(config);
    }

    public static void configure(Class config) {
        BOOTSTRAP.configure(config);
    }
}
