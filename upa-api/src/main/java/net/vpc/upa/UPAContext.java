/**
 * ==================================================================== UPA
 * (Unstructured Persistence API) Yet another ORM Framework
 * ++++++++++++++++++++++++++++++++++ Unstructured Persistence API, referred to
 * as UPA, is a genuine effort to raise programming language frameworks managing
 * relational data in applications using Java Platform, Standard Edition and
 * Java Platform, Enterprise Edition and Dot Net Framework equally to the next
 * level of handling ORM for mutable data structures. UPA is intended to provide
 * a solid reflection mechanisms to the mapped data structures while affording
 * to make changes at runtime of those data structures. Besides, UPA has learned
 * considerably of the leading ORM (JPA, Hibernate/NHibernate, MyBatis and
 * Entity Framework to name a few) failures to satisfy very common even known to
 * be trivial requirement in enterprise applications.
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

import net.vpc.upa.callbacks.PersistenceGroupDefinitionListener;
import net.vpc.upa.config.ScanFilter;
import net.vpc.upa.config.ScanSource;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.persistence.UPAContextConfig;

import java.lang.annotation.Annotation;
import java.lang.reflect.Method;
import java.util.List;
import java.util.Map;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/11/12 9:54 PM
 */
public interface UPAContext {

    /**
     * start context and load config
     *
     * @param factory
     * @throws UPAException
     */
    public void start(ObjectFactory factory) throws UPAException;

    public UPAContextFactory getFactory();

    public UPAContextConfig getBootstrapContextConfig();

    public void scan(ScanSource configurationStrategy, ScanListener listener, boolean configure);

    public PersistenceUnit getPersistenceUnit() throws UPAException;

    public List<PersistenceGroup> getPersistenceGroups() throws UPAException;

    public PersistenceGroup getPersistenceGroup() throws UPAException;

    public void setPersistenceGroup(String name) throws UPAException;

    public PersistenceGroup getPersistenceGroup(String name) throws UPAException;

    public boolean containsPersistenceGroup(String name) throws UPAException;

    public PersistenceGroup addPersistenceGroup(String name) throws UPAException;

    public void removePersistenceGroup(String name) throws UPAException;

    public void addPersistenceGroupDefinitionListener(PersistenceGroupDefinitionListener persistenceGroupDefinitionListener) throws UPAException;

    public PersistenceGroupDefinitionListener[] getPersistenceGroupDefinitionListeners();

    public void removePersistenceGroupDefinitionListener(PersistenceGroupDefinitionListener persistenceGroupDefinitionListener) throws UPAException;

    public <T> T makeSessionAware(T instance) throws UPAException;

    public <T> T makeSessionAware(T instance, Class<Annotation> sessionAwareMethodAnnotation) throws UPAException;

    public <T> T makeSessionAware(T instance, MethodFilter methodFilter) throws UPAException;

    public <T> T makeSessionAware(Class<T> type, MethodFilter methodFilter) throws UPAException;

    public <T> T invoke(Action<T> action, InvokeContext invokeContext) throws UPAException;

    public <T> T invoke(Action<T> action) throws UPAException;

    public <T> T invokePrivileged(Action<T> action, InvokeContext invokeContext) throws UPAException;

    public <T> T invokePrivileged(Action<T> action) throws UPAException;

    public void invoke(VoidAction action, InvokeContext invokeContext) throws UPAException;

    public void invoke(VoidAction action) throws UPAException;

    public void invokePrivileged(VoidAction action, InvokeContext invokeContext) throws UPAException;

    public void invokePrivileged(VoidAction action) throws UPAException;

    /**
     * closes context and removed all persistence groups
     *
     * @throws UPAException
     */
    public void close() throws UPAException;

    public void addCloseListener(CloseListener listener);

    public void removeCloseListener(CloseListener listener);

    public CloseListener[] getCloseListeners();

    /**
     * prepare UPA context for method invocation. This method is same as
     * beginInvocation(Map<String, Object> properties) but includes also
     * annotation configurations for the method to invoke. Actually
     * beginInvocation does not invoke the given method.
     *
     * @param method method to be invoked
     * @param properties non null Map to be shared between beginInvocation and
     * endInvocation
     */
    public void beginInvocation(Method method, Map<String, Object> properties);

    /**
     * prepare UPA context for method invocation. This will prepare session and
     * transaction Actually beginInvocation does not invoke the given method.
     *
     * @param properties non null Map to be shared between beginInvocation and
     * endInvocation
     */
    public void beginInvocation(Map<String, Object> properties);

    /**
     * finalize method invocation and catch error if not null
     *
     * @param error error if any
     * @param properties non null Map to be shared between beginInvocation and
     * endInvocation
     */
    public void endInvocation(Throwable error, Map<String, Object> properties);

    public void addScanFilter(ScanFilter filter);

    public void removeScanFilter(ScanFilter filter);

    public ScanFilter[] getContextAnnotationStrategyFilters();

    public Map<String, Object> getProperties();

    public void setProperties(Map<String, Object> properties);

    public Callback createCallback(CallbackConfig callbackConfig);

    public Callback addCallback(CallbackConfig callbackConfig);

    public void addCallback(Callback callback);

    public void removeCallback(Callback callback);

    public Callback[] getCallbacks(CallbackType callbackType, ObjectType objectType, String nameFilter, boolean system, EventPhase phase);
}
