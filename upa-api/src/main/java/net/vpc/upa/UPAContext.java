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

import net.vpc.upa.callbacks.PersistenceGroupDefinitionListener;
import net.vpc.upa.config.ScanFilter;
import net.vpc.upa.config.ScanSource;
import net.vpc.upa.persistence.UPAContextConfig;

import java.lang.annotation.Annotation;
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
     * @
     */
    void start(ObjectFactory factory,UPAContextConfig[] contextConfig,Class[] configClasses) ;

    UPAContextFactory getFactory();

    UPAContextConfig getBootstrapContextConfig();

    void scan(UPAContextConfig contextConfig,ScanSource configurationStrategy, ScanListener listener, boolean configure);

    PersistenceUnit getPersistenceUnit() ;

    List<PersistenceGroup> getPersistenceGroups() ;

    PersistenceGroup  getPersistenceGroup() ;

    void setPersistenceGroup(String name) ;

    PersistenceGroup  getPersistenceGroup(String name) ;

    boolean containsPersistenceGroup(String name) ;

    PersistenceGroup addPersistenceGroup(String name) ;

    void removePersistenceGroup(String name) ;

    void addPersistenceGroupDefinitionListener(PersistenceGroupDefinitionListener persistenceGroupDefinitionListener) ;

    PersistenceGroupDefinitionListener[] getPersistenceGroupDefinitionListeners();

    void removePersistenceGroupDefinitionListener(PersistenceGroupDefinitionListener persistenceGroupDefinitionListener) ;

    <T> T makeSessionAware(T instance) ;

    <T> T makeSessionAware(T instance, Class<Annotation> sessionAwareMethodAnnotation) ;

    <T> T makeSessionAware(T instance, MethodFilter methodFilter) ;

    <T> T makeSessionAware(Class<T> type, MethodFilter methodFilter) ;

    <T> T invoke(Action<T> action, InvokeContext invokeContext) ;

    <T> T invoke(Action<T> action) ;

    <T> T invokePrivileged(Action<T> action, InvokeContext invokeContext) ;

    <T> T invokePrivileged(Action<T> action) ;

    void invoke(VoidAction action, InvokeContext invokeContext) ;

    void invoke(VoidAction action) ;

    void invokePrivileged(VoidAction action, InvokeContext invokeContext) ;

    void invokePrivileged(VoidAction action) ;

    /**
     * closes context and removed all persistence groups
     *
     * @
     */
    void close() ;

    void addCloseListener(CloseListener listener);

    void removeCloseListener(CloseListener listener);

    CloseListener[] getCloseListeners();


    void addScanFilter(ScanFilter filter);

    void removeScanFilter(ScanFilter filter);

    ScanFilter[] getScanFilters();

    Map<String, Object> getProperties();

    void setProperties(Map<String, Object> properties);

    Callback createCallback(MethodCallback methodCallback);

    Callback addCallback(MethodCallback methodCallback);

    void addCallback(Callback callback);

    void removeCallback(Callback callback);

    Callback[] getCallbacks(CallbackType callbackType, ObjectType objectType, String nameFilter, boolean system, boolean preparedOnly, EventPhase phase);

    Properties getThreadProperties();

    PersistenceContextInfo getInfo();
}
