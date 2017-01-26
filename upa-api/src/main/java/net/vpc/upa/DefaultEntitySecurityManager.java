/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Expression;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class DefaultEntitySecurityManager implements EntitySecurityManager {

    @Override
    public boolean isAllowedPersist(Entity entity)  {
        return isAllowedKey(entity, "Persist");
    }

    @Override
    public boolean isAllowedPersist(Entity entity, Object object)  {
        return isAllowedKey(entity, "Persist");
    }

    @Override
    public boolean isAllowedUpdate(Entity entity)  {
        return isAllowedKey(entity, "Update");
    }

    @Override
    public boolean isAllowedUpdate(Entity entity, Object id,Object value)  {
        return isAllowedKey(entity, "Update");
    }

    @Override
    public boolean isAllowedRemove(Entity entity)  {
        return isAllowedKey(entity, "Remove");
    }

    @Override
    public boolean isAllowedRemove(Entity entity, Object id, Object object)  {
        return isAllowedKey(entity, "Remove");
    }

    @Override
    public boolean isAllowedClone(Entity entity)  {
        return isAllowedKey(entity, "Clone");
    }

    public boolean isAllowedClone(Entity entity, Object instance, Object newId)  {
        return isAllowedKey(entity, "Clone");
    }

    @Override
    public boolean isAllowedRename(Entity entity)  {
        return isAllowedKey(entity, "Rename");
    }

    @Override
    public boolean isAllowedRename(Entity entity, Object instance, Object newId)  {
        return isAllowedKey(entity, "Rename");
    }

    @Override
    public boolean isAllowedLoad(Entity entity)  {
        return isAllowedKey(entity, "Load");
    }

    @Override
    public boolean isAllowedLoad(Entity entity, Object id, Object object)  {
        return isAllowedKey(entity, "Load");
    }

    @Override
    public boolean isAllowedNavigate(Entity entity)  {
        return isAllowedKey(entity, "Navigate");
    }

    @Override
    public boolean isAllowedNavigate(Entity entity, String navigationMode)  {
        return isAllowedKey(entity, ("Navigate") + ((navigationMode == null || navigationMode.isEmpty()) ? "" : ("." + navigationMode)));
    }

    @Override
    public boolean isAllowedNavigate(Entity entity, Object id, Object object)  {
        return isAllowedKey(entity, "Navigate");
    }

    @Override
    public boolean isAllowedRead(Field field)  {
        return isAllowedLoad(field.getEntity())
                &&
                isAllowedKey(field, "Read");
    }

    @Override
    public boolean isAllowedRead(Field field, Object id, Object object)  {
        return isAllowedLoad(field.getEntity(), id, object)
                &&
                isAllowedKey(field, "Read");
    }

    @Override
    public boolean isAllowedWrite(Field field)  {
        return isAllowedUpdate(field.getEntity())
                &&
                isAllowedKey(field, "Write");
    }

    @Override
    public boolean isAllowedWrite(Field field, Object id, Object object)  {
        return isAllowedUpdate(field.getEntity())
                &&
                isAllowedKey(field, "Write");
    }

    @Override
    public Expression getEntityFilter(Entity entity)  {
        return null;
    }

    public boolean isAllowedKey(Entity e, String key)  {
        if (key == null) {
            return true;
        }
        return isAllowedKey(e.getPersistenceUnit().getPersistenceGroup(), e.getAbsoluteName() + "." + key);
    }

    public boolean isAllowedKey(Field e, String key)  {
        if (key == null) {
            return true;
        }
        return isAllowedKey(e.getPersistenceUnit().getPersistenceGroup(), e.getEntity().getAbsoluteName()+"."+e.getName() + "." + key);
    }

    public boolean isAllowedKey(PersistenceGroup g, String key)  {
        PersistenceGroupSecurityManager s = g.getPersistenceGroupSecurityManager();
        return s == null ? true : s.isAllowedKey(key);
    }

}
