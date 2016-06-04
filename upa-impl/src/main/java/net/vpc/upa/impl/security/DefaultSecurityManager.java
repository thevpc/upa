package net.vpc.upa.impl.security;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.PersistenceGroupSecurityManager;
import net.vpc.upa.expressions.Expression;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/26/12 11:42 PM
 */
public class DefaultSecurityManager implements UPASecurityManager {
//    static Logger log= Logger.getLogger(DummySecurityManager.class);

    @Override
    public boolean isAllowedPersist(Entity entity) throws UPAException {
        EntitySecurityManager s = entity.getEntitySecurityManager();
        if (s != null) {
            return s.isAllowedPersist(entity);
        }
        return isAllowedKey(entity, "Persist");
    }

    @Override
    public boolean isAllowedPersist(Entity entity, Object object) throws UPAException {
        EntitySecurityManager s = entity.getEntitySecurityManager();
        if (s != null) {
            return s.isAllowedPersist(entity, object);
        }
        return isAllowedKey(entity, "Persist");
    }

    @Override
    public boolean isAllowedUpdate(Entity entity) throws UPAException {
        EntitySecurityManager s = entity.getEntitySecurityManager();
        if (s != null) {
            return s.isAllowedUpdate(entity);
        }
        return isAllowedKey(entity, "Update");
    }

    @Override
    public boolean isAllowedUpdate(Entity entity, Object id, Object value) throws UPAException {
        EntitySecurityManager s = entity.getEntitySecurityManager();
        if (s != null) {
            return s.isAllowedUpdate(entity, id, value);
        }
        return isAllowedKey(entity, "Update");
    }

    @Override
    public boolean isAllowedRemove(Entity entity) throws UPAException {
        EntitySecurityManager s = entity.getEntitySecurityManager();
        if (s != null) {
            return s.isAllowedRemove(entity);
        }
        return isAllowedKey(entity, "Remove");
    }

    @Override
    public boolean isAllowedRemove(Entity entity, Object id) throws UPAException {
        EntitySecurityManager s = entity.getEntitySecurityManager();
        if (s != null) {
            return s.isAllowedRemove(entity, id, null);
        }
        return isAllowedKey(entity, "Delete");
    }

    @Override
    public boolean isAllowedClone(Entity entity) throws UPAException {
        EntitySecurityManager s = entity.getEntitySecurityManager();
        if (s != null) {
            return s.isAllowedClone(entity);
        }
        return isAllowedKey(entity, "Clone");
    }

    public boolean isAllowedClone(Entity entity, Object instance, Object newId) throws UPAException {
        EntitySecurityManager s = entity.getEntitySecurityManager();
        if (s != null) {
            return s.isAllowedClone(entity, instance, newId);
        }
        return isAllowedKey(entity, "Clone");
    }

    @Override
    public boolean isAllowedRename(Entity entity) throws UPAException {
        EntitySecurityManager s = entity.getEntitySecurityManager();
        if (s != null) {
            return s.isAllowedRename(entity);
        }
        return isAllowedKey(entity, "Rename");
    }

    @Override
    public boolean isAllowedRename(Entity entity, Object instance, Object newId) throws UPAException {
        EntitySecurityManager s = entity.getEntitySecurityManager();
        if (s != null) {
            return s.isAllowedRename(entity, instance, newId);
        }
        return isAllowedKey(entity, "Rename");
    }

    @Override
    public boolean isAllowedLoad(Entity entity) throws UPAException {
        EntitySecurityManager s = entity.getEntitySecurityManager();
        if (s != null) {
            return s.isAllowedLoad(entity);
        }
        return isAllowedKey(entity, "Load");
    }

    @Override
    public boolean isAllowedLoad(Entity entity, Object id, Object object) throws UPAException {
        EntitySecurityManager s = entity.getEntitySecurityManager();
        if (s != null) {
            return s.isAllowedLoad(entity, id, object);
        }
        return isAllowedKey(entity, "Load");
    }

    @Override
    public boolean isAllowedNavigate(Entity entity) throws UPAException {
        EntitySecurityManager s = entity.getEntitySecurityManager();
        if (s != null) {
            return s.isAllowedNavigate(entity);
        }
        return isAllowedKey(entity, "Navigate");
    }

    @Override
    public boolean isAllowedNavigate(Entity entity, String navigationMode) throws UPAException {
        EntitySecurityManager s = entity.getEntitySecurityManager();
        if (s != null) {
            return s.isAllowedNavigate(entity, navigationMode);
        }
        return isAllowedKey(entity, "Navigate");
    }

    @Override
    public boolean isAllowedNavigate(Entity entity, Object id, Object object) throws UPAException {
        EntitySecurityManager s = entity.getEntitySecurityManager();
        if (s != null) {
            return s.isAllowedNavigate(entity, id, object);
        }
        return isAllowedKey(entity, "Navigate");
    }

    @Override
    public boolean isAllowedRead(Field field) throws UPAException {
        EntitySecurityManager s = field.getEntity().getEntitySecurityManager();
        if (s != null) {
            return s.isAllowedRead(field);
        }
        return isAllowedKey(field.getEntity(), "Load");
    }

    @Override
    public boolean isAllowedRead(Field field, Object id, Object object) throws UPAException {
        EntitySecurityManager s = field.getEntity().getEntitySecurityManager();
        if (s != null) {
            return s.isAllowedRead(field, id, object);
        }
        return isAllowedKey(field.getEntity(), "Load");
    }

    @Override
    public boolean isAllowedWrite(Field field) throws UPAException {
        EntitySecurityManager s = field.getEntity().getEntitySecurityManager();
        if (s != null) {
            return s.isAllowedWrite(field);
        }
        return isAllowedKey(field.getEntity(), "Update");
    }

    /**
     *
     * @param field
     * @param id
     * @param object
     * @return
     * @throws UPAException
     */
    @Override
    public boolean isAllowedWrite(Field field, Object id, Object object) throws UPAException {
        EntitySecurityManager s = field.getEntity().getEntitySecurityManager();
        if (s != null) {
            return s.isAllowedWrite(field, id, object);
        }
        return isAllowedKey(field.getEntity(), "Update");
    }

    /**
     *
     * @param entity
     * @return
     * @throws UPAException
     */
    @Override
    public Expression getEntityFilter(Entity entity) throws UPAException {
        EntitySecurityManager s = entity.getEntitySecurityManager();
        if (s != null) {
            return s.getEntityFilter(entity);
        }
        return null;
    }

    /**
     *
     * @param e
     * @param key
     * @return
     * @throws UPAException
     */
    @Override
    public boolean isAllowedKey(Entity e, String key) throws UPAException {
        if (key == null) {
            return true;
        }
        return isAllowedKey(e.getAbsoluteName() + "." + key);
    }

    /**
     *
     * @param key
     * @return
     * @throws UPAException
     */
    @Override
    public boolean isAllowedKey(String key) throws UPAException {
        PersistenceGroupSecurityManager s = UPA.getPersistenceGroup().getPersistenceGroupSecurityManager();
        return s == null ? true : s.isAllowedKey(key);
    }

    @Override
    public UserPrincipal getUserPrincipal() throws UPAException {
        PersistenceGroupSecurityManager s = UPA.getPersistenceGroup().getPersistenceGroupSecurityManager();
        return s == null ? new DefaultUserPrincipal("anonymous", null) : s.getUserPrincipal();
    }

    /**
     *
     * @param login
     * @param credentials
     * @return
     * @throws UPAException
     */
    @Override
    public UserPrincipal login(String login, String credentials) throws UPAException {
        PersistenceGroupSecurityManager s = UPA.getPersistenceGroup().getPersistenceGroupSecurityManager();
        if (s == null) {
            throw new UPAException("MissingPersistenceGroupSecurityManager");
        }
        return s.login(login, credentials);
    }

    @Override
    public UserPrincipal loginPrivileged(String login) throws UPAException {
        PersistenceGroupSecurityManager s = UPA.getPersistenceGroup().getPersistenceGroupSecurityManager();
        if (s == null) {
            throw new UPAException("MissingPersistenceGroupSecurityManager");
        }
        return s.loginPrivileged(login);
    }

}
