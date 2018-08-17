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

import net.vpc.upa.expressions.Expression;

/**
 * @author taha.bensalah@gmail.com
 */
public class DefaultEntitySecurityManager implements EntitySecurityManager {

    @Override
    public boolean isAllowedPersist(Entity entity) {
        return isAllowedKey(entity, "Persist");
    }

    @Override
    public boolean isAllowedPersist(Entity entity, Object object) {
        return isAllowedKey(entity, "Persist");
    }

    @Override
    public boolean isAllowedUpdate(Entity entity) {
        return isAllowedKey(entity, "Update");
    }

    @Override
    public boolean isAllowedUpdate(Entity entity, Object id, Object value) {
        return isAllowedKey(entity, "Update");
    }

    @Override
    public boolean isAllowedRemove(Entity entity) {
        return isAllowedKey(entity, "Remove");
    }

    @Override
    public boolean isAllowedRemove(Entity entity, Object id, Object object) {
        return isAllowedKey(entity, "Remove");
    }

    @Override
    public boolean isAllowedClone(Entity entity) {
        return isAllowedKey(entity, "Clone");
    }

    public boolean isAllowedClone(Entity entity, Object instance, Object newId) {
        return isAllowedKey(entity, "Clone");
    }

    @Override
    public boolean isAllowedRename(Entity entity) {
        return isAllowedKey(entity, "Rename");
    }

    @Override
    public boolean isAllowedRename(Entity entity, Object instance, Object newId) {
        return isAllowedKey(entity, "Rename");
    }

    @Override
    public boolean isAllowedLoad(Entity entity) {
        return isAllowedKey(entity, "Load");
    }

    @Override
    public boolean isAllowedLoad(Entity entity, Object id, Object object) {
        return isAllowedKey(entity, "Load");
    }

    @Override
    public boolean isAllowedNavigate(Entity entity) {
        return isAllowedKey(entity, "Navigate");
    }

    @Override
    public boolean isAllowedNavigate(Entity entity, String navigationMode) {
        return isAllowedKey(entity, ("Navigate") + ((navigationMode == null || navigationMode.isEmpty()) ? "" : ("." + navigationMode)));
    }

    @Override
    public boolean isAllowedNavigate(Entity entity, Object id, Object object) {
        return isAllowedKey(entity, "Navigate");
    }

    @Override
    public boolean isAllowedRead(Field field) {
        return isAllowedLoad(field.getEntity())
                &&
                isAllowedKey(field, "Read");
    }

    @Override
    public boolean isAllowedRead(Field field, Object id, Object object) {
        return isAllowedLoad(field.getEntity(), id, object)
                &&
                isAllowedKey(field, "Read");
    }

    @Override
    public boolean isAllowedWrite(Field field) {
        return isAllowedUpdate(field.getEntity())
                &&
                isAllowedKey(field, "Write");
    }

    @Override
    public boolean isAllowedWrite(Field field, Object id, Object object) {
        return isAllowedUpdate(field.getEntity())
                &&
                isAllowedKey(field, "Write");
    }

    @Override
    public Expression getEntityFilter(Entity entity) {
        return null;
    }

    public boolean isAllowedKey(Entity e, String key) {
        if (key == null) {
            return true;
        }
        return isAllowedKey(e.getPersistenceUnit().getPersistenceGroup(), e.getAbsoluteName() + "." + key);
    }

    public boolean isAllowedKey(Field e, String key) {
        if (key == null) {
            return true;
        }
        return isAllowedKey(e.getPersistenceUnit().getPersistenceGroup(), e.getEntity().getAbsoluteName() + "." + e.getName() + "." + key);
    }

    public boolean isAllowedKey(PersistenceGroup g, String key) {
        PersistenceGroupSecurityManager s = g.getPersistenceGroupSecurityManager();
        return s == null ? true : s.isAllowedKey(key);
    }

}
