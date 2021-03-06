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

import net.thevpc.upa.expressions.Expression;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/22/12 Time: 4:13 AM To change
 * this template use File | Settings | File Templates.
 */
public interface UPASecurityManager {

    boolean isAllowedPersist(Entity entity) ;

    boolean isAllowedPersist(Entity entity, Object instance) ;

    boolean isAllowedUpdate(Entity entity) ;

    boolean isAllowedUpdate(Entity entity, Object id, Object value) ;

    boolean isAllowedRemove(Entity entity) ;

    boolean isAllowedRemove(Entity entity, Object id) ;

    boolean isAllowedClone(Entity entity) ;

    boolean isAllowedClone(Entity entity, Object instance, Object newId) ;

    boolean isAllowedRename(Entity entity) ;

    boolean isAllowedRename(Entity entity, Object instance, Object newId) ;

    boolean isAllowedLoad(Entity entity) ;

    boolean isAllowedLoad(Entity entity, Object id, Object object) ;

    boolean isAllowedNavigate(Entity entity) ;

    boolean isAllowedNavigate(Entity entity, String navigationMode) ;

    boolean isAllowedNavigate(Entity entity, Object id, Object object) ;

    boolean isAllowedRead(Field field) ;

    boolean isAllowedRead(Field field, Object id, Object object) ;

    boolean isAllowedWrite(Field field) ;

    boolean isAllowedWrite(Field field, Object id, Object object) ;

    boolean isAllowedKey(Entity entity, String key) ;

    boolean isAllowedKey(String key) ;

    Expression getEntityFilter(Entity entity) ;

    UserPrincipal getUserPrincipal() ;

    UserPrincipal login(String login, String credentials) ;

    UserPrincipal loginPrivileged(String login) ;
}
