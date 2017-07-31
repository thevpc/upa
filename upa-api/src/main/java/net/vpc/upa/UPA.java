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
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.types.I18NString;

import java.lang.annotation.Annotation;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 * UPA (Unstructured Persistence API) is a simple yet powerful ORM aiming to
 * replace JPA. This class is the Entry Point for using UPA.
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/9/12 12:42 PM
 */
public final class UPA {

    public static final String UNDEFINED_STRING = "<<Undefined>>";
    public static final String CONNECTION_STRING = "upa.connection";
    public static final String ROOT_CONNECTION_STRING = "upa.root-connection";
    protected static final Logger log = Logger.getLogger(UPA.class.getName());

    private static final UPABootstrap bootstrap = new UPABootstrap();
    private static final int CONTEXT_NOT_INITIALIZED=0;
    private static final int CONTEXT_INITIALIZING=1;
    private static final int CONTEXT_INITIALIZED=2;
    private static int bootstrapStatus = CONTEXT_NOT_INITIALIZED;

    private UPA() {
    }

    /**
     * Current PersistenceGroup of the current context. Equivalent to
     * <pre>
     *     UPA.getContext().getPersistenceGroup()
     * </pre>
     *
     * @return current PersistenceGroup of the current context
     * @throws UPAException
     */
    public static PersistenceGroup getPersistenceGroup() throws UPAException {
        return getContext().getPersistenceGroup();
    }

    /**
     * PersistenceGroup by name {@code name}. Equivalent to
     * <pre>
     *     UPA.getContext().getPersistenceGroup(name)
     * </pre>
     *
     * @return current PersistenceGroup of the current context
     * @throws UPAException
     */
    public static PersistenceGroup getPersistenceGroup(String name) throws UPAException {
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
     * @throws UPAException
     */
    public static PersistenceUnit getPersistenceUnit() throws UPAException {
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
     * @throws UPAException
     */
    public static PersistenceUnit getPersistenceUnit(String name) throws UPAException {
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
     * @throws UPAException
     */
    public static PersistenceUnit getPersistenceUnit(String persistenceGroup, String persistenceUnit) throws UPAException {
        return getContext().getPersistenceGroup(persistenceGroup).getPersistenceUnit(persistenceUnit);
    }

    public static <T> T makeSessionAware(T instance) throws UPAException {
        return makeSessionAware(instance, (MethodFilter) null);
    }

    public static <T> T makeSessionAware(T instance, final Class<Annotation> sessionAwareMethodAnnotation) throws UPAException {
        return getContext().makeSessionAware(instance, sessionAwareMethodAnnotation);
    }

    public static <T> T makeSessionAware(T instance, MethodFilter methodFilter) throws UPAException {
        return getContext().makeSessionAware(instance, methodFilter);
    }

    /**
     * Thread Safe retrieval of UPAContext
     *
     * @return current UPAContext
     */
    public static UPAContext getContext() throws UPAException {
        if(bootstrapStatus==CONTEXT_INITIALIZING){
            throw new UPAException("UPAAlreadyInitializing");
        }
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
                java.lang.ExceptionInInitializerError ee = (java.lang.ExceptionInInitializerError) e;
                if (ee.getCause() instanceof UPAException) {
                    throw (UPAException) ee.getCause();
                }
                throw new UPAException(ee.getCause(), new I18NString("LoadUPAContextException"));
            }
            if (e instanceof UPAException) {
                throw (UPAException) e;
            }
            /**
             * @PortabilityHint(target = "C#",name = "suppress")
             */
            if (e instanceof RuntimeException) {
                throw (RuntimeException) e;
            }
            throw new BootstrapException("UPAContextProviderLazyHolderError", e);
        }

        bootstrap.setContextInitialized();
        UPAContext context = contextProvider.getContext();
        //Double Checking Lock will/should work here because we are not about to instantiate the object,
        //this is the responsibility of the contextProvider
        if (context == null) {
            synchronized (bootstrap) {
                context = contextProvider.getContext();
                if (context == null) {
                    bootstrapStatus=CONTEXT_INITIALIZING;
                    long start = System.currentTimeMillis();
                    ObjectFactory bootstrapFactory = bootstrap.getFactory();
                    context = bootstrapFactory.createObject(UPAContext.class);
                    context.start(bootstrapFactory);
                    contextProvider.setContext(context);
                    long end = System.currentTimeMillis();
                    log.log(Level.FINE, "UPA Context Loaded in " + (end - start) + " ms");
                    bootstrapStatus=CONTEXT_INITIALIZED;
                }
            }
        }else{
            if(bootstrapStatus!=CONTEXT_INITIALIZED){
                throw new BootstrapException("UPAContextStatusInvalid");
            }
        }
        return context;
    }

    public static UPABootstrap getBootstrap() {
        return bootstrap;
    }


    public static void close() {
        if (bootstrap.isContextInitialized()) {
            UPAContext context = UPAContextProviderLazyHolder.INSTANCE.getContext();
            if (context != null) {
                context.close();
            }
        }
    }

}
