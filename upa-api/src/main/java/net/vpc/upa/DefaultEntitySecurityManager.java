/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Expression;

/**
 *
 * @author vpc
 */
public class DefaultEntitySecurityManager implements EntitySecurityManager {

    @Override
    public boolean isAllowedPersist(Entity entity) throws UPAException {
        return isAllowedKey(entity, "Persist");
    }

    @Override
    public boolean isAllowedPersist(Entity entity, Object object) throws UPAException {
        return isAllowedKey(entity, "Persist");
    }

    @Override
    public boolean isAllowedUpdate(Entity entity) throws UPAException {
        return isAllowedKey(entity, "Update");
    }

    @Override
    public boolean isAllowedUpdate(Entity entity, Object id,Object value) throws UPAException {
        return isAllowedKey(entity, "Update");
    }

    @Override
    public boolean isAllowedRemove(Entity entity) throws UPAException {
        return isAllowedKey(entity, "Remove");
    }

    @Override
    public boolean isAllowedRemove(Entity entity, Object id, Object object) throws UPAException {
        return isAllowedKey(entity, "Remove");
    }

    @Override
    public boolean isAllowedClone(Entity entity) throws UPAException {
        return isAllowedKey(entity, "Clone");
    }

    public boolean isAllowedClone(Entity entity, Object instance, Object newId) throws UPAException {
        return isAllowedKey(entity, "Clone");
    }

    @Override
    public boolean isAllowedRename(Entity entity) throws UPAException {
        return isAllowedKey(entity, "Rename");
    }

    @Override
    public boolean isAllowedRename(Entity entity, Object instance, Object newId) throws UPAException {
        return isAllowedKey(entity, "Rename");
    }

    @Override
    public boolean isAllowedLoad(Entity entity) throws UPAException {
        return isAllowedKey(entity, "Load");
    }

    @Override
    public boolean isAllowedLoad(Entity entity, Object id, Object object) throws UPAException {
        return isAllowedKey(entity, "Load");
    }

    @Override
    public boolean isAllowedNavigate(Entity entity) throws UPAException {
        return isAllowedKey(entity, "Navigate");
    }

    @Override
    public boolean isAllowedNavigate(Entity entity, String navigationMode) throws UPAException {
        return isAllowedKey(entity, ("Navigate") + ((navigationMode == null || navigationMode.isEmpty()) ? "" : ("." + navigationMode)));
    }

    @Override
    public boolean isAllowedNavigate(Entity entity, Object id, Object object) throws UPAException {
        return isAllowedKey(entity, "Navigate");
    }

    @Override
    public boolean isAllowedRead(Field field) throws UPAException {
        return isAllowedKey(field.getEntity(), "Load");
    }

    @Override
    public boolean isAllowedRead(Field field, Object id, Object object) throws UPAException {
        return isAllowedKey(field.getEntity(), "Load");
    }

    @Override
    public boolean isAllowedWrite(Field field) throws UPAException {
        return isAllowedKey(field.getEntity(), "Update");
    }

    @Override
    public boolean isAllowedWrite(Field field, Object id, Object object) throws UPAException {
        return isAllowedKey(field.getEntity(), "Update");
    }

    @Override
    public Expression getEntityFilter(Entity entity) throws UPAException {
        return null;
    }

    public boolean isAllowedKey(Entity e, String key) throws UPAException {
        if (key == null) {
            return true;
        }
        return isAllowedKey(e.getPersistenceUnit().getPersistenceGroup(), e.getAbsoluteName() + "." + key);
    }

    public boolean isAllowedKey(PersistenceGroup g, String key) throws UPAException {
        PersistenceGroupSecurityManager s = g.getPersistenceGroupSecurityManager();
        return s == null ? true : s.isAllowedKey(key);
    }

}
