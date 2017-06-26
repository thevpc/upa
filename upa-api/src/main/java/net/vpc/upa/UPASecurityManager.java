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

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Expression;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/22/12 Time: 4:13 AM To change
 * this template use File | Settings | File Templates.
 */
public interface UPASecurityManager {

    boolean isAllowedPersist(Entity entity) throws UPAException;

    boolean isAllowedPersist(Entity entity, Object instance) throws UPAException;

    boolean isAllowedUpdate(Entity entity) throws UPAException;

    boolean isAllowedUpdate(Entity entity, Object id, Object value) throws UPAException;

    boolean isAllowedRemove(Entity entity) throws UPAException;

    boolean isAllowedRemove(Entity entity, Object id) throws UPAException;

    boolean isAllowedClone(Entity entity) throws UPAException;

    boolean isAllowedClone(Entity entity, Object instance, Object newId) throws UPAException;

    boolean isAllowedRename(Entity entity) throws UPAException;

    boolean isAllowedRename(Entity entity, Object instance, Object newId) throws UPAException;

    boolean isAllowedLoad(Entity entity) throws UPAException;

    boolean isAllowedLoad(Entity entity, Object id, Object object) throws UPAException;

    boolean isAllowedNavigate(Entity entity) throws UPAException;

    boolean isAllowedNavigate(Entity entity, String navigationMode) throws UPAException;

    boolean isAllowedNavigate(Entity entity, Object id, Object object) throws UPAException;

    boolean isAllowedRead(Field field) throws UPAException;

    boolean isAllowedRead(Field field, Object id, Object object) throws UPAException;

    boolean isAllowedWrite(Field field) throws UPAException;

    boolean isAllowedWrite(Field field, Object id, Object object) throws UPAException;

    boolean isAllowedKey(Entity entity, String key) throws UPAException;

    boolean isAllowedKey(String key) throws UPAException;

    Expression getEntityFilter(Entity entity) throws UPAException;

    UserPrincipal getUserPrincipal() throws UPAException;

    UserPrincipal login(String login, String credentials) throws UPAException;

    UserPrincipal loginPrivileged(String login) throws UPAException;
}
