/**
 * ==================================================================== 
 * UPA (Unstructured Persistence API)
 *    Yet another ORM Framework
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
 *
 * Copyright (C) 2014-2015 Taha BEN SALAH
 *
 * This program is free software; you can redistribute it and/or modify it under
 * the terms of the GNU General Public License as published by the Free Software
 * Foundation; either version 2 of the License, or (at your option) any later
 * version.
 *
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE. See the GNU General Public License for more
 * details.
 *
 * You should have received a copy of the GNU General Public License along with
 * this program; if not, write to the Free Software Foundation, Inc., 51
 * Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 * ====================================================================
 */
package net.vpc.upa;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.types.I18NString;

import java.lang.annotation.Annotation;

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

    static boolean contextProviderCreated = false;

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
            throw new UPAException(e, new I18NString("UPAContextProviderLazyHolderError"));
        }

        UPAContext context = contextProvider.getContext();
        //Double Checking Lock will/should work here because we are not about to instantiate the object,
        //this is the responsibility of the contextProvider
        if (context == null) {
            synchronized (UPAContext.class) {
                context = contextProvider.getContext();
                if (context == null) {
                    ObjectFactory bootstrapFactory = getBootstrapFactory();
                    context = bootstrapFactory.createObject(UPAContext.class);
                    context.start(bootstrapFactory);
                    contextProvider.setContext(context);
                }
            }
        }
        return context;
    }

    public static ObjectFactory getBootstrapFactory() {
        try {
            return BootstrapObjectFactoryLazyHolder.INSTANCE;
        } catch (Throwable e) {
            /**
             * @PortabilityHint(target = "C#",name = "suppress")
             */
            if (e instanceof java.lang.ExceptionInInitializerError) {
                java.lang.ExceptionInInitializerError ee = (java.lang.ExceptionInInitializerError) e;
                if (ee.getCause() instanceof UPAException) {
                    throw (UPAException) ee.getCause();
                }
                throw new UPAException(ee.getCause(), new I18NString("LoadBootstrapFactoryException"));
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
            throw new UPAException(e, new I18NString("UnableToLoadBootstrapFactory"));
        }
    }

    public static void close() {
        if (contextProviderCreated) {
            UPAContext context = UPAContextProviderLazyHolder.INSTANCE.getContext();
            if (context != null) {
                context.close();
            }
        }
    }

}
