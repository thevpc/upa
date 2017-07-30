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

import net.vpc.upa.callbacks.PersistenceUnitDefinitionListener;
import net.vpc.upa.config.ScanFilter;
import net.vpc.upa.config.ScanSource;
import net.vpc.upa.exceptions.UPAException;

import java.util.List;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/11/12 9:38 PM
 */
public interface PersistenceGroup extends Closeable {

    void scan(ScanSource strategy, ScanListener listener, boolean configure) throws UPAException;

    String getName() throws UPAException;

    /**
     * if true, when no scan filter is specified will scan all class-path
     *
     * @return true if auto scan is enabled
     */
    boolean isAutoScan();

    void setAutoScan(boolean autoScan);

    UPAContext getContext();

    PersistenceUnit getPersistenceUnit() throws UPAException;

    void setPersistenceUnit(String name) throws UPAException;

    List<PersistenceUnit> getPersistenceUnits() throws UPAException;

    PersistenceUnit getPersistenceUnit(String name) throws UPAException;

    ObjectFactory getFactory() throws UPAException;

    boolean containsPersistenceUnit(String name) throws UPAException;

    PersistenceUnit addPersistenceUnit(String name) throws UPAException;

    void dropPersistenceUnit(String name) throws UPAException;

    boolean currentSessionExists();

    Session getCurrentSession() throws UPAException;

    Session findCurrentSession() throws UPAException;

    void setCurrentSession(Session session) throws UPAException;

    Session openSession();

    boolean isClosed();


    void addPersistenceUnitDefinitionListener(PersistenceUnitDefinitionListener definitionListener);

    void removePersistenceUnitDefinitionListener(PersistenceUnitDefinitionListener definitionListener);

    void addContextAnnotationStrategyFilter(ScanFilter filter);

    void removeContextAnnotationStrategyFilter(ScanFilter filter);

    ScanFilter[] getContextAnnotationStrategyFilters();

    UPASecurityManager getSecurityManager();

    PersistenceGroupSecurityManager getPersistenceGroupSecurityManager();

    void setPersistenceGroupSecurityManager(PersistenceGroupSecurityManager securityManager);

    void addCallback(Callback callback);

    void removeCallback(Callback callback);

    Callback[] getCallbacks(CallbackType nameFilter, ObjectType objectType, String name, boolean system, boolean preparedOnly, EventPhase phase);

    <T> T invoke(Action<T> action, InvokeContext invokeContext);

    <T> T invoke(Action<T> action);

    <T> T invokePrivileged(Action<T> action, InvokeContext invokeContext);

    <T> T invokePrivileged(Action<T> action);

    void invoke(VoidAction action, InvokeContext invokeContext);

    void invoke(VoidAction action);

    void invokePrivileged(VoidAction action, InvokeContext invokeContext);

    void invokePrivileged(VoidAction action);

    Properties getProperties();
}
