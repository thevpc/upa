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

    public String getName() throws UPAException;

    /**
     * if true, when no scan filter is specified will scan all class-path
     *
     * @return true if auto scan is enabled
     */
    public boolean isAutoScan();

    public void setAutoScan(boolean autoScan);

    public UPAContext getContext();

    public PersistenceUnit getPersistenceUnit() throws UPAException;

    public void setPersistenceUnit(String name) throws UPAException;

    public List<PersistenceUnit> getPersistenceUnits() throws UPAException;

    public PersistenceUnit getPersistenceUnit(String name) throws UPAException;

    public ObjectFactory getFactory() throws UPAException;

    public boolean containsPersistenceUnit(String name) throws UPAException;

    public PersistenceUnit addPersistenceUnit(String name) throws UPAException;

    public void dropPersistenceUnit(String name) throws UPAException;

    public boolean currentSessionExists();

    public Session getCurrentSession() throws UPAException;

    public void setCurrentSession(Session session) throws UPAException;

    public Session openSession() throws UPAException;

    public boolean isClosed() throws UPAException;

    public void close() throws UPAException;

    public void addPersistenceUnitDefinitionListener(PersistenceUnitDefinitionListener definitionListener);

    public void removePersistenceUnitDefinitionListener(PersistenceUnitDefinitionListener definitionListener);

    public void addContextAnnotationStrategyFilter(ScanFilter filter);

    public void removeContextAnnotationStrategyFilter(ScanFilter filter);

    public ScanFilter[] getContextAnnotationStrategyFilters();

    public UPASecurityManager getSecurityManager();

    public PersistenceGroupSecurityManager getPersistenceGroupSecurityManager();

    public void setPersistenceGroupSecurityManager(PersistenceGroupSecurityManager securityManager);

    public void addCallback(Callback callback);

    public void removeCallback(Callback callback);

    public Callback[] getCallbacks(CallbackType nameFilter, ObjectType objectType, String name, boolean system, EventPhase phase);

}
