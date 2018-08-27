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

import net.vpc.upa.events.PersistenceGroupDefinitionListener;
import net.vpc.upa.config.ScanFilter;
import net.vpc.upa.config.ScanSource;
import net.vpc.upa.persistence.UPAContextConfig;

import java.lang.annotation.Annotation;
import java.util.List;
import java.util.Map;
import net.vpc.upa.exceptions.NoSuchPersistenceGroupException;
import net.vpc.upa.exceptions.PersistenceGroupAlreadyExistsException;

/**
 * Singleton instance holding UPA context information. 
 * Contains Bootstrap information, Persistence Group definitions
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/11/12 9:54 PM
 */
public interface UPAContext {

    /**
     * start context and load config. Context configuration is built based on
     * <code>contextConfig</code>, <code>configClasses</code> and
     * bootstrapContextConfig (see {@link  #getBootstrapContextConfig() }
     *
     * @param factory object factory to use for creating instances
     * @param contextConfig static contextConfigs
     * @param configClasses static configClasses
     */
    void start(ObjectFactory factory, UPAContextConfig[] contextConfig, Class[] configClasses);

    /**
     * context factory defined in {@link #start(net.vpc.upa.ObjectFactory, net.vpc.upa.persistence.UPAContextConfig[], java.lang.Class[])
     * }.
     *
     * @return context factory
     */
    UPAContextFactory getFactory();

    /**
     * default configuration used in {@link #start(net.vpc.upa.ObjectFactory, net.vpc.upa.persistence.UPAContextConfig[], java.lang.Class[])
     * }.
     *
     * @return default configuration
     */
    UPAContextConfig getBootstrapContextConfig();

    /**
     * scans <code>scanSource</code> according to the configuration
     * <code>contextConfig</code>
     *
     * @param contextConfig configuration to parse ofr
     * @param scanSource sources of classes/XML configurations
     * @param listener if not null, will be notified by visited classes
     * @param configure if true, scanned UPA objects will be added to context
     */
    void scan(ScanSource scanSource, UPAContextConfig contextConfig, ScanListener listener, boolean configure);

    /**
     * current context PersistenceUnit
     *
     * @return current context PersistenceUnit
     */
    PersistenceUnit getPersistenceUnit();

    /**
     * current context PersistenceGroup
     *
     * @return current context PersistenceGroup
     */
    PersistenceGroup getPersistenceGroup();

    /**
     * changes the current Persistence Group by name
     *
     * @param name name of the selected Persistence Group
     * @throws NoSuchPersistenceGroupException when the name is invalid
     */
    void setPersistenceGroup(String name) throws NoSuchPersistenceGroupException;

    /**
     * finds PersistenceGroup by name
     * @param name selected name
     * @return PersistenceGroup named <code>name</code>
     * @throws NoSuchPersistenceGroupException when the name is invalid
     */
    PersistenceGroup getPersistenceGroup(String name) throws NoSuchPersistenceGroupException;

    /**
     * Persistence groups list.
     *
     * @return all Persistence groups
     */
    List<PersistenceGroup> getPersistenceGroups();

    /**
     * test if the name is a valid and existing Persistence Group name
     * @param name persistence group name
     * @return true if the name exists
     */
    boolean containsPersistenceGroup(String name);

    /**
     * creates a new persistence group with name <code>name</code> if it does not exist.
     * Event OnCreatePersistenceGroup is Fired
     * @param name persistence group name
     * @return newly created Persistence Group
     * @throws PersistenceGroupAlreadyExistsException if the name already exists
     */
    PersistenceGroup addPersistenceGroup(String name) throws PersistenceGroupAlreadyExistsException;

    /**
     * Removes the persistence group named <code>name</code>.
     * The persistence group should be closed before removal ({@link PersistenceGroup#close()}).
     * Event OnDropPersistenceGroup is fired.
     * Current Persistence Group should be set to null if it corresponds to the removed group.
     * @param name group name
     * @throws NoSuchPersistenceGroupException if the group oes not exist
     */
    void removePersistenceGroup(String name) throws NoSuchPersistenceGroupException;

    /**
     * adds listener
     * @param persistenceGroupDefinitionListener listener
     */
    void addPersistenceGroupDefinitionListener(PersistenceGroupDefinitionListener persistenceGroupDefinitionListener);

    /**
     * all PersistenceGroupDefinitionListener listeners
     * @return all listeners
     */
    PersistenceGroupDefinitionListener[] getPersistenceGroupDefinitionListeners();

    /**
     * remove listener
     * @param persistenceGroupDefinitionListener listener
     */
    void removePersistenceGroupDefinitionListener(PersistenceGroupDefinitionListener persistenceGroupDefinitionListener);

    /**
     * wrap instance to handles UPA session creation. All public methods are wrapped 
     * with create/destroy UPA session mechanism.
     * @param <T> instance type
     * @param instance instance to wrap
     * @return new instance of Type T that handles UPA session creation
     */
    <T> T makeSessionAware(T instance);

    /**
     * wrap instance to handles UPA session creation. All public methods with 
     * <code>sessionAwareMethodAnnotation</code> are wrapped 
     * with create/destroy UPA session mechanism. 
     * if sessionAwareMethodAnnotation is null, all public methods methods are 
     * wrapped.
     * @param <T> instance type
     * @param instance instance to wrap
     * @param sessionAwareMethodAnnotation annotation enabling the wrapping
     * @return new instance of Type T that handles UPA session creation
     */
    <T> T makeSessionAware(T instance, Class<Annotation> sessionAwareMethodAnnotation);

    /**
     * wrap instance to handles UPA session creation. All public methods accepted 
     * by <code>methodFilter</code> are wrapped 
     * with create/destroy UPA session mechanism. 
     * if sessionAwareMethodAnnotation is null, all public methods methods are 
     * wrapped.
     * @param <T> instance type
     * @param instance instance to wrap
     * @param methodFilter method filter
     * @return new instance of Type T that handles UPA session creation
     */
    <T> T makeSessionAware(T instance, MethodFilter methodFilter);

    /**
     * create instance and wrap it to handles UPA session creation. All public methods accepted 
     * by <code>methodFilter</code> are wrapped 
     * with create/destroy UPA session mechanism. 
     * if sessionAwareMethodAnnotation is null, all public methods methods are 
     * wrapped.
     * @param <T> instance type
     * @param type instance type
     * @param methodFilter method filter
     * @return new instance of Type T that handles UPA session creation
     */
    <T> T makeSessionAware(Class<T> type, MethodFilter methodFilter);

    /**
     * invoke action in a session aware context
     * @param <T>
     * @param action
     * @param invokeContext
     * @return
     */
    <T> T invoke(Action<T> action, InvokeContext invokeContext);

    /**
     * invoke action in a session aware context
     * @param <T>
     * @param action
     * @return
     */
    <T> T invoke(Action<T> action);

    /**
     * invoke action in a session aware context
     * @param <T>
     * @param action
     * @param invokeContext
     * @return
     */
    <T> T invokePrivileged(Action<T> action, InvokeContext invokeContext);

    /**
     * invoke action in a session aware context
     * @param <T>
     * @param action
     * @return
     */
    <T> T invokePrivileged(Action<T> action);

    /**
     * invoke action in a session aware context
     * @param action
     * @param invokeContext
     */
    void invoke(VoidAction action, InvokeContext invokeContext);

    /**
     * invoke action in a session aware context
     * @param action
     */
    void invoke(VoidAction action);

    /**
     * invoke action in a session aware context
     * @param action
     * @param invokeContext
     */
    void invokePrivileged(VoidAction action, InvokeContext invokeContext);

    /**
     * invoke action in a session aware context
     * @param action
     */
    void invokePrivileged(VoidAction action);

    /**
     * Closes this instance and resets it to its initial state. All groups are
     * removed. The instance becomes reusable after its closing. If the
     * instance is not yet initialized, calling this method has no side effects.
     * Multiple calls to this method has no side effects either. If the current
     * group is removed it will be replaced by <code>null</code> instance. It is
     * upto the user to set a another current group on need.
     */
    void close();

    /**
     * add close listener
     * @param listener listener
     */
    void addCloseListener(CloseListener listener);

    /**
     * remove close listener
     * @param listener listener
     */
    void removeCloseListener(CloseListener listener);

    /**
     * Close listeners list
     * @return all listeners
     */
    CloseListener[] getCloseListeners();

    /**
     * add scan filter
     * @param filter filter
     */
    void addScanFilter(ScanFilter filter);

    /**
     * remove scan filter
     * @param filter filter
     */
    void removeScanFilter(ScanFilter filter);

    /**
     * Scan filters list
     * @return Scan filters list
     */
    ScanFilter[] getScanFilters();

    /**
     * Context properties
     * @return context properties
     */
    Map<String, Object> getProperties();

    /**
     * sets Context properties
     * @param properties context properties
     */
    void setProperties(Map<String, Object> properties);

    /**
     * add a callback to the context
     * @param methodCallback methodCallback
     * @return added callback
     */
    Callback createCallback(MethodCallback methodCallback);

    /**
     * add a callback to the context
     * @param methodCallback methodCallback
     * @return added callback
     */
    Callback addCallback(MethodCallback methodCallback);

    /**
     * add a callback to the context
     * @param callback callback
     */
    void addCallback(Callback callback);

    /**
     * remove callback from context
     * @param callback callback
     */
    void removeCallback(Callback callback);

    /**
     * get all callbacks matching filter.
     * @param eventType
     * @param objectType
     * @param nameFilter
     * @param system
     * @param preparedOnly
     * @param phase
     * @return
     */
    Callback[] getCallbacks(EventType eventType, ObjectType objectType, String nameFilter, boolean system, boolean preparedOnly, EventPhase phase);

    /**
     * Useful Thread local Properties instance.
     * @return Thread local Properties instance.
     */
    Properties getThreadProperties();

    /**
     * Serializable info for the current context
     * @return PersistenceContext Info
     */
    PersistenceContextInfo getInfo();
}
